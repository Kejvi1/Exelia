using BeerAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Collections.Generic;
using System.Linq;

namespace BeerAPI.Extensions
{
    /// <summary>
    /// Filter for validating request object
    /// </summary>
    public class RequestObjValidationFilter : ActionFilterAttribute
    {
        /// <summary>
        /// On action execution check if model state is valid
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                ExceptionResponse<Dictionary<string, List<string>>> model = new ExceptionResponse<Dictionary<string, List<string>>>
                {
                    Message = "One or more validation errors occurred!",
                    Errors = new Dictionary<string, List<string>>()
                };

                foreach (var modelState in context.ModelState)
                {
                    model.Errors.Add(modelState.Key.Replace("$.", ""), modelState.Value.Errors.Select(a => a.ErrorMessage).ToList());
                }

                context.Result = new BadRequestObjectResult(model);
            }
        }
    }
}