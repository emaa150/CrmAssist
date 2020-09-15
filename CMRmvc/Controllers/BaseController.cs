using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace CMRmvc.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        private readonly ILogger<BaseController> logger;

        private static Stopwatch stopwatch;
        private const string startMethod = "********************************** Inicio {0} **********************************";
        private const string endMethod = "********************************** Fin {0} **********************************";
        private const string elapsedTime = "Tiempo transcurrido: {0} ms.";

        public BaseController(ILogger<BaseController> logger)
        {
            try
            {
                logger.LogInformation(startMethod + "BaseController()" + endMethod);

                this.logger = logger;
            }
            catch (Exception ex)
            {

                logger.LogError(ex.Message + ex.StackTrace);
            }

        }

        internal void StartMethod([CallerMemberName] string methodName = "")
        {
            stopwatch = Stopwatch.StartNew();
            logger.LogInformation(string.Format(startMethod, methodName));
        }

        internal void EndMethod([CallerMemberName] string methodName = "")
        {
            if (stopwatch != null)
            {
                stopwatch.Stop();
                logger.LogInformation(string.Format(elapsedTime, stopwatch.ElapsedMilliseconds.ToString()));
                logger.LogInformation(string.Format(endMethod, methodName));
            }
        }
    }
}
