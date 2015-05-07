using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GFS.Models;
using System.Web.ModelBinding;

namespace GFS
{
    public partial class CreateFeedbackForm : System.Web.UI.Page
    {
        private GFSContext _db = new GFSContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddSections(object sender, EventArgs e)
        {
            IQueryable<Section> query = _db.Sections;
            //section ids
            List<int> someSectionIDs = query.Select(p => p.SectionID).ToList();
            string someCourseID;
            int someSectionName;
            string tempString;
            foreach( int item in someSectionIDs )
            {
                // get the courseID of this section
                someCourseID = query.Where(p => p.SectionID == item).Select(p => p.CourseName).First();
                // get the section name of this section
                someSectionName = query.Where(p => p.SectionID == item).Select(p => p.SectionNumber).First();
                tempString = someCourseID + "  -  " + someSectionName.ToString();
                SectionCheckboxList.Items.Add( new ListItem(tempString, item.ToString()) );
            }
        }

        protected void CreateButton_Click(object sender, EventArgs e)
        {
            // create a new form container
            FormContainer aFormContainer = new FormContainer
            {
                Name = TextBox1.Text,
                Description = TextBox2.Text,
            };
            _db.FormContainers.Add(aFormContainer);
            _db.SaveChanges();
            Form aForm = new Form
            {
                Title = TextBox1.Text,
                FormType = 1,
                FormContainerID = aFormContainer.FormContainerID,
            };
            _db.Forms.Add(aForm);
            _db.SaveChanges();
            int temp;
            // get the checked boxes
            foreach( ListItem item in SectionCheckboxList.Items )
            {
                if(item.Selected)
                {
                    temp = Convert.ToInt32(item.Value);
                    var myItem = (from c in _db.Sections where c.SectionID == temp select c).FirstOrDefault();
                    myItem.FormContainerID = aFormContainer.FormContainerID;
                }
            }
            _db.SaveChanges();
            CreateButton.Visible = false;
            TextBox1.Visible = false;
            TextBox2.Visible = false;
            SectionCheckboxList.Visible = false;
            Label1.Visible = false;
            Label2.Visible = false;
            NameLabel.Text = "Your new form has been created!";
        }
    }
}