using DemoApp.Model;
using DemoApp.Repository;
using DemoWeb.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWeb.Controllers
{
    [Authorize(Roles="Admin")]
    public class UserProfileController : Controller
    {
       readonly MyDemoDbContext _context;
        readonly FileUpload fileUpload;
        public UserProfileController(MyDemoDbContext context,FileUpload fileUpload)
        {
            this._context = context;
            this.fileUpload = fileUpload;
        }
        // GET: UserProfileController
        public ActionResult Index()
        {
            var res = _context.userProfiles.OrderByDescending(x => x.RegisteredDate).ToList();
            return View(res);
        }

        // GET: UserProfileController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserProfileController/Create
        public ActionResult Create()
        {
            ViewBag.Roles = new SelectList(_context.Roles.Where(x => x.RoleName != Roles.Admin.ToString()), "PkRoleId", "RoleName");
            return View();
        }

        // POST: UserProfileController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserProfile userProfile,IFormFile userimage,int fkroleId)
        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    userProfile.Image = fileUpload.UploadFile(userimage);
                    userProfile.RegisteredDate = DateTime.Now;
                    userProfile.Password = PasswordHashSecurity.HashPassword(userProfile.Password);
                    userProfile.FkRoleId = fkroleId;
                    _context.Add(userProfile);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));

                }
                catch(Exception ex)
                {
                    return View();
                }
            }
            return View(userProfile);

        }

        // GET: UserProfileController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var userprofile = _context.userProfiles.Find(id);
            return View(userprofile);
        }

        // POST: UserProfileController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id,UserProfile userProfile,IFormFile userImage)
        {
            if (id != userProfile.PkUserId)
            {
                return NotFound();
            }
            
            if (ModelState.IsValid)
            {

                try
                {
                    var user = _context.userProfiles.AsNoTracking().FirstOrDefault(x => x.PkUserId == userProfile.PkUserId);
                    //var image = user.Image;
                    if (userImage != null)
                    {
                        user.Image = fileUpload.UploadFile(userImage);
                    }
                    user.UserName = userProfile.UserName;
                    user.EmailId = userProfile.EmailId;
                    user.IsActive = userProfile.IsActive;
                    _context.Update(user);
                    _context.SaveChanges();
                }
                catch(DbUpdateConcurrencyException)
                {
                    if (!UserProfileExists(userProfile.PkUserId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userProfile);
        }

        // GET: UserProfileController/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = _context.userProfiles.FirstOrDefault(u=>u.PkUserId==id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        // POST: UserProfileController/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                var userprofile = _context.userProfiles.Find(id);
                _context.Remove(userprofile);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        private bool UserProfileExists(int id)
        {
          return  _context.userProfiles.Any(u => u.PkUserId == id);
        }
    }
}
