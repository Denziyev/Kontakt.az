using Kontakt.App.Services.Interfaces;
using Kontakt.App.ViewModels;
using Kontakt.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Net.Mail;

namespace Kontakt.App.Controllers
{
    public class AccountController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signinManager;
        private readonly IMailService _mailService;

        public AccountController(RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, SignInManager<AppUser> signinManager, IMailService mailService)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _signinManager = signinManager;
            _mailService = mailService;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            registerViewModel.IsTerms = true;
            if (!ModelState.IsValid)
            {
                return View(registerViewModel);
            }
            AppUser appUser = new AppUser();
            appUser.Email = registerViewModel.Email;
            appUser.Name = registerViewModel.Name;
            appUser.Surname = registerViewModel.Surname;
            appUser.UserName = registerViewModel.UserName;
            //appUser.EmailConfirmed = true;
            IdentityResult identityResult = await _userManager.CreateAsync(appUser, registerViewModel.Password);
            if (!identityResult.Succeeded)
            {
                foreach (var error in identityResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(registerViewModel);
            }
            await _userManager.AddToRoleAsync(appUser, "User");
            

            string token = await _userManager.GenerateEmailConfirmationTokenAsync(appUser);

            var link = Url.Action(action: "VerifyEmail", controller: "account",
              values: new { token = token, email = appUser.Email },
              protocol: Request.Scheme);

            await _mailService.Send("ilkinhd@code.edu.az", appUser.Email, link, "Təsdiqləmə maili","E-Poçt ünvanınızı təsdiq etmək üçün klik edin");

            TempData["Register"] = "Zəhmət olmasa, e-poçt ünvanınızı yoxlayın.";
            return RedirectToAction("index", "home");
        }

        public async Task<IActionResult> VerifyEmail(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                NotFound();
            }
            await _userManager.ConfirmEmailAsync(user, token);
            await _signinManager.SignInAsync(user, true);
            return RedirectToAction(nameof(Info));

        }
        public async Task<IActionResult> Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            AppUser appUser = await _userManager.FindByEmailAsync(loginViewModel.email);
            if (appUser == null)
            {
                ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yanlışdır");
                return View(loginViewModel);
            }
            if (!await _userManager.IsInRoleAsync(appUser, "User"))
            {
                ModelState.AddModelError("", "Admin daxil ola bilməz");
                return View(loginViewModel);
            }
            var result = await _signinManager.PasswordSignInAsync(appUser, loginViewModel.Password, loginViewModel.isRememberMe, true);
            if (!result.Succeeded)
            {
                if (result.IsLockedOut)
                {
                    ModelState.AddModelError("", "Hesabınız 5 dəq bloklandı");
                    return View();
                }
                ModelState.AddModelError("", "İstifadəçi adı və ya şifrə yanlışdır");
                return View();
            }

            TempData["Login"] = "Artıq üstünlüklərdən yararlana bilərsiz.";
            return RedirectToAction("index", "home");

        }
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signinManager.SignOutAsync();
            TempData["Logout"] = "Hesabdan uğurla çıxış olundu";

            return RedirectToAction("index", "home");
        }
        public async Task<IActionResult> Info()
        {
            string UserName = User.Identity.Name;
            AppUser appUser = await _userManager.FindByNameAsync(UserName);

            return View(appUser);
        }

        [HttpGet]
        public async Task<IActionResult> ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgetPassword(string? email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            string token = await _userManager.GeneratePasswordResetTokenAsync(user);

            UriBuilder uriBuilder = new UriBuilder();

            var link = Url.Action(action: "resetpassword", controller: "account",
                values: new { token = token, email = email },
                protocol: Request.Scheme);

            await _mailService.Send("ilkinhd@code.edu.az", user.Email, link, "Reset password","Click me for Reset Password");
            TempData["ForgetPassword"] = "Zəhmət olmasa, e-poçt ünvanınızı yoxlayın.";
            return RedirectToAction("index", "home");
        }
        [HttpGet]
        public async Task<IActionResult> ResetPassword(string token, string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                return NotFound();
            }
            ResetPasswordViewModel resetPasswordViewModel = new ResetPasswordViewModel
            {
                Token = token,
                Email = email
            };
            return View(resetPasswordViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPassword)
        {
            var user = await _userManager.FindByEmailAsync(resetPassword.Email);
            if (user == null)
            {
                return NotFound();
            }
            var result = await _userManager.ResetPasswordAsync(user, resetPassword.Token, resetPassword.Password);
            if (!result.Succeeded)
            {
                return Json(result.Errors);
            }
            TempData["ResetPassword"] = "Şifrə uğurla dəyişdirildi";
            return RedirectToAction("login", "account");

        }

        [Authorize]
        public async Task<IActionResult> Update()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            UserUpdateViewModel userUpdateView = new UserUpdateViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };
            return View(userUpdateView);
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(UserUpdateViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (user == null)
            {
                return NotFound();
            }
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Email = model.Email;
            user.PhoneNumber = model.PhoneNumber;
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }
            if (!string.IsNullOrWhiteSpace(model.NewPassword))
            {
                result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                if (!result.Succeeded)
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                    return View(model);
                }
            }
            await _signinManager.SignInAsync(user, true);
            TempData["UserUpdate"] = "İstifadəçi məlumatları uğurla yeniləndi";
            return RedirectToAction(nameof(Info));
        }


        [Authorize]
        public async Task<IActionResult> changedestination()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            AdressUpdateViewModel adressUpdateView = new AdressUpdateViewModel
            {
                Name = user.Name,
                Surname = user.Surname,
                City = user.City,
                StreetAdress = user.StreetAdress,
                Province = user.Province,
                Country = user.Country,
                PhoneNumber = user.PhoneNumber,
                ZipCode = user.ZipCode,
                Company= user.Company,
                Email=user.Email

            };
            return View(adressUpdateView);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> changedestination(AdressUpdateViewModel model)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            if (user == null)
            {
                return NotFound();
            }
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.City = model.City;
            user.Company= model.Company;
            user.Country = model.Country;
            user.PhoneNumber = model.PhoneNumber;
            user.Province = model.Province;
            user.StreetAdress = model.StreetAdress;
            user.ZipCode = model.ZipCode;
            var result = await _userManager.UpdateAsync(user);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                return View(model);
            }

            await _signinManager.SignInAsync(user, true);
            TempData["UserUpdated"] = "Ünvan məlumatları uğurla dəyişdirildi";
            return RedirectToAction(nameof(Info));
        }



        public async Task<IActionResult> CreateRole()
        {
            IdentityRole identityRole1 = new IdentityRole { Name = "SuperAdmin" };
            IdentityRole identityRole2 = new IdentityRole { Name = "Admin" };
            IdentityRole identityRole3 = new IdentityRole { Name = "User" };

            await _roleManager.CreateAsync(identityRole1);

            await _roleManager.CreateAsync(identityRole2);

            await _roleManager.CreateAsync(identityRole3);

            return Json("ok");
        }
    }
}
