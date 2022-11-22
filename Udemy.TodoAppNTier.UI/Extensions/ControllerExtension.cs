using Microsoft.AspNetCore.Mvc;
using Udemy.ToDoAppNTier.Common.ResponseObjects;

namespace Udemy.TodoAppNTier.UI.Extensions
{
    public static class ControllerExtension
    {
        public static IActionResult ResponseRedirectToAction<T>(this Controller controller, IResponse<T> response, string actionname)
        {
            if (response.ResposeType==ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            if (response.ResposeType==ResponseType.ValidationError)
            {
                foreach (var error in response.ValidationErrors)
                {
                    controller.ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
                }
                return controller.View(response.Data);
            }
            return controller.RedirectToAction(actionname);
        }
        public static IActionResult ResponseView<T> (this Controller controller, IResponse<T> response)
        {
            if (response.ResposeType==ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.View(response.Data);
        }
        public static IActionResult ResponseRedirectToAction(this Controller controller, IResponse response, string actionname)
        {
            if (response.ResposeType==ResponseType.NotFound)
            {
                return controller.NotFound();
            }
            return controller.RedirectToAction(actionname);
        }
    }
}
