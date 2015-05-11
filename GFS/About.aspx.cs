using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;
using System.Data;

namespace GFS
{
    public partial class About : Page
    {
        SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["GFS"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            conn.Open();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            int number = 0;
            int id = 0;
            string[] info = new string[100];
            int counter = 0;
            string sentence;
            if (FileUpload1.HasFile)
            {
                FileUpload1.PostedFile.SaveAs(Server.MapPath("~/Files/") + FileUpload1.FileName);

            }

            foreach (string strFile in Directory.GetFiles(Server.MapPath("~/Files/")))
            {

                Stream msgstream = File.Open(strFile, FileMode.Open, FileAccess.Read);
                StreamReader dafile = new StreamReader(msgstream);
                while ((sentence = dafile.ReadLine()) != null)
                {

                    info[counter] += sentence;

                    counter++;

                    //SqlCommand cmd = new SqlCommand("insert into Upload values('" + id++ + "','" + info[number] + "','" + info[number + 1] + "'," + Convert.ToInt32(info[number + 2]) + ")", conn);
                    SqlCommand cmd = new SqlCommand("update Upload set Email='" + info[number] + "'where UploadId=" + id++ + "", conn);
                    number++;
                    cmd.ExecuteNonQuery();
                }
                msgstream.Close();
            }
        }

        protected void lbInsert_Click(object sender, EventArgs e)
        {
            SqlDataSource1.InsertParameters["EmailAddress"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("EmailName")).Text;
            SqlDataSource1.InsertParameters["SectionID"].DefaultValue = ((TextBox)GridView1.FooterRow.FindControl("SectionName")).Text;
            SqlDataSource1.Insert();
        }



        
    }
}