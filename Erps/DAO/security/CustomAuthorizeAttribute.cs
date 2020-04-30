using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;


namespace Erps.DAO.security
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        public string UsersConfigKey { get; set; }
        public string RolesConfigKey { get; set; }

        protected virtual CustomPrincipal CurrentUser
        {
            get { return HttpContext.Current.User as CustomPrincipal; }
        }
        private string _notifyUrl = "/Account/Index";

        public string NotifyUrl
        {
            get { return _notifyUrl; }
            set { _notifyUrl = value; }
        }

        public override void OnAuthorization(AuthorizationContext filterContext)
        {

            if (filterContext.HttpContext.Request.IsAuthenticated)
            {

                var authorizedUsers = ConfigurationManager.AppSettings[UsersConfigKey];
                var authorizedRoles = ConfigurationManager.AppSettings[RolesConfigKey];

                Users = String.IsNullOrEmpty(Users) ? authorizedUsers : Users;
                Roles = String.IsNullOrEmpty(Roles) ? authorizedRoles : Roles;


                if (!String.IsNullOrEmpty(Roles))
                {
                    if (!CurrentUser.IsInRole(Roles))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));


                    }
                }


                if (!String.IsNullOrEmpty(Users))
                {
                    if (!Users.Contains(CurrentUser.UserId.ToString()))
                    {
                        filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));

                        // base.OnAuthorization(filterContext); //returns to login url
                    }
                }


            }
            else
            {
                filterContext.Result = new RedirectToRouteResult(new
                     RouteValueDictionary(new { controller = "Account", action = "Index" }));
            }

        }
    }
}