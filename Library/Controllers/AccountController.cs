using Biblio;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Library.Data;
using Library.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace Library.Controllers
{
    public class AccountController : Controller
    {


        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContext;

        public AccountController(ApplicationDbContext dbContext, IHttpContextAccessor httpContext)
        {
            _dbContext = dbContext;
            _httpContext = httpContext;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            var response = new SignUpModel();
            return View(response);
        }

        [HttpPost]
        public IActionResult SignUp(SignUpModel user)
        {

            var existingUsername = _dbContext.Subscribers.SingleOrDefault(u => u.UserName == user.UserName);
            if (existingUsername != null)
            {
                ModelState.AddModelError(nameof(SignUpModel.UserName), "");
                TempData["Error"] = "Username existe dèja";
            }


            var existingEmail = _dbContext.Subscribers.SingleOrDefault(u => u.Email == user.Email);
            if (existingEmail != null)
            {
                ModelState.AddModelError(nameof(SignUpModel.Email), "");
                TempData["Error"] = "Email existe dèja";
            }

            if (ModelState.IsValid)
            {
                var newSubscriber = new Subscriber
                {
                    UserName = user.UserName,
                    FirstName = user.FirstName,
                    LastName = user.LastName,
                    DateOfBirth = user.DateOfBirth,
                    Address = user.Address,
                    Email = user.Email,
                    PhoneNumber = user.PhoneNumber,
                    Password = user.Password,
                };
                _dbContext.Subscribers.Add(newSubscriber);
                _dbContext.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }
        [HttpGet]
        public IActionResult Logout()
        {
            // Clear the user's session
            _httpContext.HttpContext.Session.Clear();

            // Redirect to the home page or any other desired page
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public IActionResult Login()
        {
            var response = new LoginModel();
            return View(response);
        }

        [HttpPost]
        public IActionResult Login(LoginModel user)
        {
            var existingUser = _dbContext.Subscribers.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

            if (existingUser != null)
            {
                // User found, perform login
                // You can set a session variable or cookie to maintain the user's authentication status.
                // For simplicity, we'll just redirect to a home page.
                _httpContext.HttpContext.Session.SetInt32("UserId", existingUser.SubscriberID);
                _httpContext.HttpContext.Session.SetString("Username", existingUser.UserName);
                return RedirectToAction("Index", "Display");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View(user);
        }
    }

}

