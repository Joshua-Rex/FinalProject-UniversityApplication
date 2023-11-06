using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using University_Portal.Areas.Identity.Data;
using University_Portal.Data;

namespace University_Portal.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly UsersDbContext _context;
        private readonly UserManager<User> _userManager;

        public AdminController(UsersDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: AdminController
        public async Task<ActionResult> Index()
        {
            // Collects all the user id's and puts them in a list
            var allUserIds = _context.Users.Select(x => x.Id).ToList();
            List<User> newUsers = new List<User>();

            // Filters the list to contain only new users
            for (int i = 0; i < allUserIds.Count; i++)
            {
                var temp = await _context.Users.FindAsync(allUserIds[i]);
                if (IsOfRole(temp, "NewUser").Result)
                {
                    newUsers.Add(temp);
                }
            }
            ViewData["Users"] = newUsers;
            return View();
        }

        // Assigns the selected user as a Student and remove the New User role
        public async Task<IActionResult> CreateStudent(string id)
        {
            // This shouldn't get hit and is purely a precaution
            if (id == null)
            {
                return NotFound();
            }

            // Finds the user by id and assigns it to the role of Student
            var user = await _context.Users.FindAsync(id);
            var result = await _userManager.AddToRoleAsync(user, "Student");
            // Flags up any errors if they occur
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            //Removes the role of New User
            result = await _userManager.RemoveFromRoleAsync(user, "NewUser");
            // Flags up any errors if they occur
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Refreshes Index page
            return RedirectToAction(nameof(Index));
        }

        // Assignes the selected user as a Tutor and removes the New User role
        public async Task<IActionResult> CreateTutor(string id)
        {
            // This shouldn't get hit and is purely a precaution
            if (id == null)
            {
                return NotFound();
            }

            // Finds the user by id and assigns it to the role of Tutor
            var user = await _context.Users.FindAsync(id);
            var result = await _userManager.AddToRoleAsync(user, "Tutor");
            // Flags up any errors if they occur
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Removes the role of New User
            result = await _userManager.RemoveFromRoleAsync(user, "NewUser");
            // Flags up any errors if they occur
            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // Refreshes Index page
            return RedirectToAction(nameof(Index));
        }

        // GET: AdminController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AdminController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AdminController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public async Task<bool> IsOfRole(User user, string roleName) 
        {
            return await _userManager.IsInRoleAsync(user, "NewUser");
        }
    }
}
