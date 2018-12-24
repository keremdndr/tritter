using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TP.Core;
using TP.Core.IoC;
using System.Web;
using TP.Data.Entities;
using System;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TP.Web.Core
{
    public class BaseController : Controller
    {
        protected readonly IViewRenderService _viewRenderService;

        public BaseController()
        {
            _viewRenderService = AutofacBootstrapper.Resolve<IViewRenderService>();
        }

        protected virtual void AddNotification(NotifyType type, string message)
        {
            var dataKey = string.Format("tp.notifications.{0}", type);
            var messageList = new List<string>();

            if (TempData[dataKey] == null)
            {
                TempData[dataKey] = new List<string>();
            }
            else
            {
                messageList = (List<string>)TempData[dataKey];
            }
            messageList.Add(message);
            TempData[dataKey] = messageList.ToArray();
        }

        public ActionResult GetPartial(string partialcode)
        {
            Result resultModel = new Result();
            try
            {
                resultModel.Content = _viewRenderService.RenderToStringAsync(partialcode, null);
                resultModel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Message = ex.Message;
            }
            return Json(resultModel);
        }

        public Result GetPartialWithModel(string partialcode, object model)
        {
            Result resultModel = new Result();
            try
            {
                resultModel.Content = _viewRenderService.RenderToStringAsync(partialcode, model);
                resultModel.IsSuccess = true;
            }
            catch (Exception ex)
            {
                resultModel.IsSuccess = false;
                resultModel.Message = ex.Message;
            }
            return resultModel;
        }
    }
}