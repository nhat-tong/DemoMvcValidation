using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace NewValidationMvc.Controllers
{
    public class BaseController : Controller
    {
        protected override void Initialize(System.Web.Routing.RequestContext requestContext)
        {
            LoadCultureInfo();
            base.Initialize(requestContext);
        }

        /// <summary>
        /// Load culture info
        /// </summary>
        private void LoadCultureInfo()
        {
            var cultureInfo = new CultureInfo("fr-FR");

            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = cultureInfo;
        }
    }
}