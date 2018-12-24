using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TP.Business.Contracts;
using TP.Core;
using TP.Data.Entities;
using TP.Web.Core;
using Microsoft.AspNetCore.Http;
using TP.Data.Entities.PageModels.UserModel;
using TP.Data.Entities.PageModels.DashboardPageModel;
using TP.Data.Entities.PageModels.TritModel;
using TP.Data.Entities.PageModels.ProfilePageModel;

namespace TP.Web.Agent.Controllers
{
    public class HomeController : AgentBaseController
    {
        private readonly IUserEngine _userEngine;
        private readonly ITritEngine _tritEngine;

        public HomeController(IUserEngine userEngine, ITritEngine tritEngine)
        {
            _userEngine = userEngine;
            _tritEngine = tritEngine;
        }

        public IActionResult Index()
        {
            
            try
            {
                return View();
            }
            catch
            {
                AddNotification(NotifyType.Error, Keywords.OpenPageError);
                return RedirectToAction("Index", "Home");
            }

            
        }

        public IActionResult Register()
        {
            UserCreateModel userCreateModel = new UserCreateModel();
            try
            {
                return View(userCreateModel);
            }
            catch
            {
                AddNotification(NotifyType.Error, Keywords.OpenPageError);
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Dashboard(string userId)
        {
            var userResult = _userEngine.GetByUserId(userId);
            var tritResult = _tritEngine.GetTritsOfOthers(userId);
            DashboardPageUserModel dashboardPageUserModel = new DashboardPageUserModel();
            ViewBag.UserId = userId;

            if (userResult.IsSuccess)
            {
                dashboardPageUserModel.UserCreateModel = userResult.Data;
            }
            else
                throw new Exception(userResult.Message);

            if (userResult.IsSuccess)
            {
                dashboardPageUserModel.TritOthersListModel = tritResult.Data;
            }
            else
                throw new Exception(tritResult.Message);

            ViewBag.FullName = dashboardPageUserModel.UserCreateModel.user_name + " " + dashboardPageUserModel.UserCreateModel.user_surname;
            ViewBag.Email = dashboardPageUserModel.UserCreateModel.user_email;
                return View(dashboardPageUserModel);
        }



        [HttpPost]
        public IActionResult Register(UserCreateModel userCreateModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = _userEngine.Create(userCreateModel);
                    if (result.IsSuccess)
                    {
                        AddNotification(NotifyType.Success, result.Message);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        AddNotification(NotifyType.Error, result.Message);
                        return View(userCreateModel);
                    }
                }
                else
                {
                    AddNotification(NotifyType.Warning, Keywords.ModelMustBeValid);
                    return View(userCreateModel);
                }
            }
            catch
            {
                AddNotification(NotifyType.Error, Keywords.CreateError);
                return View(userCreateModel);
            }
        }

        public IActionResult CheckUserLogin(string username, string password)
        {
            var result = _userEngine.CheckUserLogin(username, password);

            return Json(result);
        }

        [HttpPost]
        public IActionResult SendTritToDB(string user_id, string trit)
        {
            TritCreateModel tritCreateModel = new TritCreateModel
            {
                trit_text = trit,
                trit_time = DateTime.Now,
                trit_user_id = user_id
            };

            var result = _tritEngine.Create(tritCreateModel);

            if (result.IsSuccess == true)
            {
                return View("Dashboard", user_id);
            }
            else
            {
                return Json(result);
            }
            

        }

        public IActionResult Profile(string userId)
        {
            var userResult = _userEngine.GetByUserId(userId);
            var tritResult = _tritEngine.GetTritsByUserId(userId);
            ProfilePageUserModel profilePageUserModel = new ProfilePageUserModel();
            ViewBag.UserId = userId;

            if (userResult.IsSuccess)
            {
                profilePageUserModel.UserCreateModel = userResult.Data;
            }
            else
                throw new Exception(userResult.Message);

            if (userResult.IsSuccess)
            {
                profilePageUserModel.TritListModel = tritResult.Data;
            }
            else
                throw new Exception(tritResult.Message);

            ViewBag.FullName = profilePageUserModel.UserCreateModel.user_name + " " + profilePageUserModel.UserCreateModel.user_surname;
            ViewBag.Email = profilePageUserModel.UserCreateModel.user_email;
            return View(profilePageUserModel);
        }

        //public IActionResult GetTritsOfOthers(string user_id)
        //{
        //    var result = _tritEngine.GetTritsOfOthers(user_id);

        //    var tritsListView = GetPartialWithModel("Home/_PartialTrits", result.Data);

        //    result.Content = tritsListView.Content;

        //    return Json(result);
        //}

        //public IActionResult Dashboard(string userId)
        //{
        //    var userResult = _userEngine.GetByUserId(userId);
        //    var tritResult = _tritEngine.GetTritsByUserId(userId);
        //    DashboardPageUserModel dashboardPageUserModel = new DashboardPageUserModel();
        //    ViewBag.UserId = userId;

        //    if (userResult.IsSuccess)
        //    {
        //        dashboardPageUserModel.UserCreateModel = userResult.Data;
        //    }
        //    else
        //        throw new Exception(userResult.Message);

        //    if (userResult.IsSuccess)
        //    {
        //        dashboardPageUserModel.TritListModel = tritResult.Data;
        //    }
        //    else
        //        throw new Exception(tritResult.Message);


        //    return View(dashboardPageUserModel);
        //}
    }
}