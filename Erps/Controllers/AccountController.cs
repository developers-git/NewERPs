

using Erps.DAO;
using Erps.DAO.security;
using Erps.Models;
using Newtonsoft.Json;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Erps.Controllers
{
    public class AccountController : Controller
    {
        //private SBoardContext db = new SBoardContext();

        static int counter = 0;
        static object lockObj = new object();
        SBoardContext Context = new SBoardContext();
        //
        // GET: /Account/
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginViewModel model, string returnUrl = "")
        {


            if (ModelState.IsValid)
            {
                model.Password = ComputeHash(model.Password, new SHA256CryptoServiceProvider());
                var user = Context.Users.Where(u => u.Username.ToLower() == model.Username.ToLower() && u.Password == model.Password && u.LockCount == 0).FirstOrDefault();
                if (user != null)
                {
                    var roles = user.Roles.Select(m => m.RoleName).ToArray();

                    CustomPrincipalSerializeModel serializeModel = new CustomPrincipalSerializeModel();
                    serializeModel.UserId = user.UserId;
                    serializeModel.FirstName = user.FirstName;
                    serializeModel.LastName = user.LastName;
                    serializeModel.roles = roles;
                    string role = user.role;
                    string userData = JsonConvert.SerializeObject(serializeModel);
                    FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(
                             1,
                            user.Email,
                             DateTime.Now,
                             DateTime.Now.AddMinutes(60),
                             false,
                             userData);

                    string encTicket = FormsAuthentication.Encrypt(authTicket);
                    HttpCookie faCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encTicket);
                    Response.Cookies.Add(faCookie);



                    if (roles.Contains(role))
                    {
                        counter = 0;
                        return Redirect("~/" + role + "/Index");
                    }
                    else
                    {
                        return RedirectToAction("Index", "Account");
                    }
                }
                if (counter == 0)
                {
                    var users = Context.Users.ToList().Where(a => a.Username == model.Username);
                    string name = "";
                    foreach (var p in users)
                    {
                        name = p.Username;
                    }
                    if (name == model.Username)
                    {
                        lock (lockObj)
                        {
                            counter++;
                        }
                        System.Web.HttpContext.Current.Session["Status"] = model.Username;
                    }

                }
                else
                {
                    var users = Context.Users.ToList().Where(a => a.Username == model.Username);
                    string name = "";
                    foreach (var p in users)
                    {
                        name = p.Username;
                    }
                    if (name == model.Username)
                    {
                        if (name == System.Web.HttpContext.Current.Session["Status"].ToString())
                        {
                            lock (lockObj)
                            {
                                counter++;
                            }
                        }
                        else
                        {
                            counter = 1;
                            System.Web.HttpContext.Current.Session["Status"] = model.Username;
                        }


                    }
                }



                var locks = Context.Users.ToList().Where(a => a.Username == model.Username && a.LockCount != 0);
                string name2 = "";

                foreach (var x in locks)
                {
                    name2 = x.Username;
                }
                if (name2 == null)
                {
                    name2 = "@";
                }

                if (name2 == model.Username)
                {
                    ModelState.Clear();
                    ViewBag.Attempts = "Contact the administrator you have been locked out";
                }
                else
                {
                    if (counter > 3)
                    {
                        var users = Context.Users.ToList().Where(b => b.Username == model.Username);
                        int id = 0;
                        foreach (var p in users)
                        {
                            id = p.UserId;
                        }
                        //lock the user

                        var a = Context.Users.Find(id);
                        a.LockCount = 5;
                        Context.Users.AddOrUpdate(a);
                        Context.SaveChanges("SystemLock");
                        ViewBag.Attempts = "Contact the administrator you have been locked out";
                    }
                    else
                    {
                        ModelState.Clear();
                        ViewBag.Attempts = "Number of Login attempts " + counter;
                    }

                }
                ModelState.AddModelError("", "Incorrect username and/or password");
            }
            model.Username = "";
            model.Password = "";
            return View(model);
        }

        [AllowAnonymous]
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account", null);
        }

        [AllowAnonymous]
        public ActionResult StartUp()
        {

            string baseUrl = Request.Url.Scheme + "://" + Request.Url.Authority + Request.ApplicationPath.TrimEnd('/'); ;
            return Redirect(baseUrl);

        }
        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }

        //setting forgot passsword
        public ActionResult ForgotPassword(LoginViewModel model)
        {


            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ForgotPassword(LoginViewModel model, string returnUrl = "")
        {

            var p = Context.Users.Where(u => u.Email == model.Username).ToList().Take(1);
            // this
            if (p.Count() != 0)
            {
                foreach (var user in p)
                {


                    var mod = ModelState.First(c => c.Key == "Username");  // this
                    mod.Value.Errors.Add("Check your inbox an email has been sent with your new password");    // this
                                                                                                               // ViewBag.Message = "In database";

                    User userData = Context.Users.Where(u => u.UserId == user.UserId).SingleOrDefault();
                    //Update the Database
                    //Autogenerate password
                    string allowedChars = "";
                    allowedChars = "a,b,c,d,e,f,g,h,i,j,k,l,m,n,o,p,q,r,s,t,u,v,w,x,y,z,";
                    allowedChars += "A,B,C,D,E,F,G,H,I,J,K,L,M,N,O,P,Q,R,S,T,U,V,W,X,Y,Z,";
                    allowedChars += "1,2,3,4,5,6,7,8,9,0,!,@,#,$,%,&,?";
                    char[] sep = { ',' };
                    string[] arr = allowedChars.Split(sep);
                    string passwordString = "";
                    string password = "";
                    string temp = "";
                    Random rand = new Random();
                    for (int i = 0; i < 14; i++)
                    {
                        temp = arr[rand.Next(0, arr.Length)];
                        passwordString += temp;
                    }
                    password = passwordString;
                    string hPassword = ComputeHash(password, new SHA256CryptoServiceProvider());

                    userData.Password = hPassword;
                    userData.ConfirmPassword = hPassword;
                    if (userData.BrokerName == null)
                    {
                        userData.BrokerCode = "MORCO";
                        userData.BrokerName = "Dry Associates";
                    }
                    Context.Entry(userData).State = EntityState.Modified;
                    Context.SaveChanges();
                    //sending emails
                    //content supposition

                    string messageBody = "<html><body ><p stlyle='color:lightblue;align:justify'>Username :  " + user.Email + "  Password:" + password
                        + "<br/>Dry Associates<br/>" +
                       "62 Quorn Avenue, Arundel, Harare<br/>" +
                       "Tel: +263 4 301201/3, 301422, 301203 / Mob: +263 777 726 850 " +
                       " <img src=cid:myImageID></p></body></ html > ";

                    //create Alrternative HTML view
                    AlternateView htmlView = AlternateView.CreateAlternateViewFromString(messageBody, null, "text/html");

                    //Add Image
                    LinkedResource theEmailImage = new LinkedResource(Server.MapPath("~/images/MORCObos.jpg"));
                    theEmailImage.ContentId = "myImageID";

                    //Add the Image to the Alternate view
                    htmlView.LinkedResources.Add(theEmailImage);

                    //Add view to the Email Message


                    //var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                    var message = new MailMessage();
                    message.To.Add(new MailAddress(user.Email)); // replace with valid value 
                    message.From = new MailAddress("tech@escrowgroup.org"); // replace with valid value
                    message.Subject = "MORCObos Broker Back Office Login Credentials";
                    //message.Body = string.Format(body, "Admin", "info@greenpastures.co.sz", messageBody);
                    message.IsBodyHtml = true;
                    message.AlternateViews.Add(htmlView);
                    using (var smtp = new SmtpClient())
                    {

                        smtp.Host = "smtp.gmail.com";
                        smtp.Port = 587;
                        smtp.EnableSsl = true;
                        ServicePointManager.ServerCertificateValidationCallback =
          delegate (object s, X509Certificate certificate,
                  X509Chain chain, SslPolicyErrors sslPolicyErrors)
          { return true; };
                        smtp.Timeout = 10000;
                        smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                        smtp.UseDefaultCredentials = false;
                        smtp.Credentials = new System.Net.NetworkCredential("edocwebapp@gmail.com", "escrow123456789");

                        await smtp.SendMailAsync(message);

                    }
                }
            }
            else
            {
                var mod = ModelState.First(c => c.Key == "Username");  // this
                mod.Value.Errors.Add("Email does not exist in our records");
            }




            return View(model);

        }
    }
}