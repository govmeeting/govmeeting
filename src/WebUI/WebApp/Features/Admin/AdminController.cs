using GM.Infrastructure.InfraCore.Data;
using GM.Infrastructure.InfraCore.Identity;
using GM.WebUI.WebApp.Models;
using GM.WebUI.WebApp.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GM.WebUI.WebApp.Features.Admin
{
    [Authorize(Policy = "Administrator")]

    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IEmailSender _emailSender;
        private readonly ISmsSender _smsSender;
        private readonly ILogger _logger;

        public AdminController(
            ApplicationDbContext dbContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IEmailSender emailSender,
            ISmsSender smsSender,
            ILoggerFactory loggerFactory)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _signInManager = signInManager;
            _emailSender = emailSender;
            _smsSender = smsSender;
            _logger = loggerFactory.CreateLogger<AdminController>();
        }

        //
        // GET: /Manage/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> EditUsers()
        {
            IQueryable<ApplicationUser> users = _userManager.Users;
            IList<UserInfo> userInfos = await CopyUserInfo(users);
            return View(userInfos);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            await _userManager.DeleteAsync(user);
            return RedirectToAction("EditUsers");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteUserClaim(string userId, string type, string value)
        {
            try
            {
                ApplicationUser user = await _userManager.FindByIdAsync(userId);
                await _userManager.RemoveClaimAsync(user, new Claim(type, value));
                return RedirectToAction("EditUsers");
            }
            catch
            {
                // TODO - handle error
                return RedirectToAction("EditUsers");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUserClaim(string userId, string type, string value)
        {
            try
            {

                ApplicationUser user = await _userManager.FindByIdAsync(userId);
                await _userManager.AddClaimAsync(user, new Claim(type, value));
                ViewBag.ResultMessage = "Claim created successfully !";
                return RedirectToAction("EditUsers");
            }
            catch
            {
                // TODO - handle error
                return RedirectToAction("EditUsers");
            }
        }

        public async Task<IList<UserInfo>> CopyUserInfo(IQueryable<ApplicationUser> usersIn)
        {
            IList<UserInfo> userInfos = new List<UserInfo>();
            foreach (ApplicationUser user in usersIn)
            {
                UserInfo userInfo = new UserInfo();
                userInfo.id = user.Id;
                userInfo.userName = user.UserName;
                userInfo.email = user.Email;
                userInfo.phoneNumber = user.PhoneNumber;
                userInfo.claims = await CopyClaimInfo(user.Id);
                userInfos.Add(userInfo);
            }
            return userInfos;
        }

        public async Task<IList<ClaimInfo>> CopyClaimInfo (string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            var claims = await _userManager.GetClaimsAsync((ApplicationUser)user);
            IList<ClaimInfo> claimInfos = new List<ClaimInfo>();
            foreach (Claim claim in claims)
            {
                ClaimInfo claimInfo = new ClaimInfo();
                claimInfo.userId = id;
                claimInfo.type = claim.Type;
                claimInfo.value = claim.Value;
                claimInfos.Add(claimInfo);
            }
            return claimInfos;
        }

        //////////////////////////////////////////////////////////////////////////////////////////
        // The following are stubs of routines for adding/removing claims from the "GovmeetingClaim" DBSet
        // which will store in the database the names of possible claims that can be assigned to a user.
        //////////////////////////////////////////////////////////////////////////////////////////

        public IActionResult EditClaims()
        {
            return View();
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteClaim(string type, string value)
        //// This is old code for deleting roles.
        //{
        //    return View("EditClaims");
        //}

        ////////////////////////////////////////////////////////////////////////////////////////////////////////
        // The routines below are for editing other user information besides claims. -- NOT FINISHED CODING
        /// ////////////////////////////////////////////////////////////////////////////////////////////////////

        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(id);
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> EditUser(ApplicationUser newUser)
        {
            ApplicationUser user = await _userManager.FindByIdAsync(newUser.Id);
            if (newUser.Email != user.Email)
            {
                await ChangeEmailWithConfirmation(user, newUser.Email);
            }
            if (newUser.PhoneNumber != user.PhoneNumber)
            {
                await _userManager.ChangePhoneNumberAsync(user, newUser.PhoneNumber, null);
            }

            return View(user);
        }

        public async Task<IActionResult> ChangeEmailWithConfirmation(ApplicationUser u, string email) {

            // get user object from the storage
            var user = await _userManager.FindByIdAsync(u.Id);

            // change username and email
            //user.UserName = "NewUsername";
            user.Email = email;

            // Persist the changes
            await _userManager.UpdateAsync(user);

            // generage email confirmation code
            var emailConfirmationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            // generate url for page where you can confirm the email
            var callbackurl = "http://example.com/ConfirmEmail";

            // append userId and confirmation code as parameters to the url
            callbackurl += String.Format("?userId={0}&code={1}", user.Id, System.Net.WebUtility.UrlEncode(emailConfirmationCode));

            var htmlContent = String.Format(
                    @"Thank you for updating your email. Please confirm the email by clicking this link: 
                <br><a href='{0}'>Confirm new email</a>",
                    callbackurl);

            // send email to the user with the confirmation link
            // await _userManager.SendEmailAsync(user.Id, subject: "Email confirmation", body: htmlContent);

            return View();

        }

        // Then this is the action to confirm the email of the user.
        // The link in the email should be pointing here
        public async Task<ActionResult> ConfirmEmail(ApplicationUser user, string code)
        {
            var confirmResult = await _userManager.ConfirmEmailAsync(user, code);

            return RedirectToAction("Index");
        }
    }
}
