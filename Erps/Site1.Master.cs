using Erps.DAO;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebMatrix.WebData;

namespace Erps
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        public string BrokerName = "";
        public string codename = "";
        public String baseUrl = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.User.Identity.IsAuthenticated == false)
            {
                //msgbox("Session Timeout");
                //Response.Redirect("~/Account");
                Response.Redirect("~/Account", false);        //write redirect
                Context.ApplicationInstance.CompleteRequest(); // end response
            }
            else
            {
                baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/'); ;

                string vx = "";
                try
                {
                    SBoardContext db = new SBoardContext();
                    var c = db.Users.ToList().Where(a => a.Email == WebSecurity.CurrentUserName);

                    foreach (var d in c)
                    {
                        vx = d.BrokerName;
                        codename = d.role;
                    }

                }
                catch (Exception f)
                {

                    vx = "";
                }
                BrokerName = vx;
            }

        }

        public void msgbox(string strMessage)
        {
            string strScript = "<script language=JavaScript>";
            strScript += "window.alert(\"" + strMessage + "\");";
            strScript += "</script>";
            System.Web.UI.WebControls.Label lbl = new System.Web.UI.WebControls.Label();
            lbl.Text = strScript;
            Page.Controls.Add(lbl);
        }

    }
}
