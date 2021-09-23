using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;

namespace GestionLocationWebApplication.Filtre
{
    public class ArticleActionFilter : ActionFilterAttribute
    {
        private IHostEnvironment _environment;

        public ArticleActionFilter(IHostEnvironment environment)
        {
            _environment = environment;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var actionName = filterContext.ActionDescriptor.RouteValues["action"];
            using (var fs = new FileStream("D:\\logs\\log.txt", FileMode.Create))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(actionName + $"Début {_environment.EnvironmentName}");
                }
            }
        }


        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var actionName = filterContext.ActionDescriptor.RouteValues["action"];
            using (var fs = new FileStream("D:\\logs\\log.txt", FileMode.Append))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine(actionName + "Fin");
                }
            }
        }
        
        
        public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            using (var fs = new FileStream("D:\\logs\\log.txt", FileMode.Append))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine("OnResultExecuting");
                }
            }
        }
        
        
        public override void OnResultExecuted(ResultExecutedContext filterContext)
        {
            var result = (ContentResult) filterContext.Result;
            using (var fs = new FileStream("D:\\logs\\log.txt", FileMode.Append))
            {
                using (var sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Résultat: " + result.Content);
                }
            }
        }
    }
}