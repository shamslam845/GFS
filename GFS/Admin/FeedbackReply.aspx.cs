using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GFS.Models;
using System.Web.ModelBinding;
using System.Net;
using System.Net.Mail;


namespace GFS.Admin
{
    public partial class FeedbackReply : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        
        public IQueryable<Email> GetEmails([QueryString("sectionId")] int? sectionID)
        {
            var _db = new GFS.Models.GFSContext();
            IQueryable<Email> query = _db.Emails;
            if (sectionID.HasValue && sectionID > 0)
            {
                query = query.Where(o => o.SectionID == sectionID);
            }
            else
            {
                query = null;
            }
            return query;
        }

        //http://stackoverflow.com/questions/23412152/asp-net-get-value-from-textbox-in-aspx-to-code-behind
        protected void SendReply(object sender, EventArgs e)
        {
            System.Net.Mail.MailMessage mail = new System.Net.Mail.MailMessage();
            mail.To.Add(To.Text);
            mail.From = new MailAddress("gofmansfeedback@gmail.com", "Email head", System.Text.Encoding.UTF8);
            mail.Subject = Subject.Text;
            mail.SubjectEncoding = System.Text.Encoding.UTF8;
            mail.Body = Message.Text;
            mail.BodyEncoding = System.Text.Encoding.UTF8;
            mail.IsBodyHtml = true;
            mail.Priority = MailPriority.High;
            SmtpClient client = new SmtpClient();
            client.Credentials = new System.Net.NetworkCredential("gofmansfeedback@gmail.com", "Gofmantest");
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;

            try
            {
                client.Send(mail);
                Page.RegisterStartupScript("UserMsg", "<script>alert('Successfully Send...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
            catch (Exception ex)
            {
                Exception ex2 = ex;
                string errorMessage = string.Empty;
                while (ex2 != null)
                {
                    errorMessage += ex2.ToString();
                    ex2 = ex2.InnerException;
                }
                Page.RegisterStartupScript("UserMsg", "<script>alert('Sending Failed...');if(alert){ window.location='SendMail.aspx';}</script>");
            }
        }
    }
}