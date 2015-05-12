// Coded By: Nicholas Irikawa
// Project: GFS Anonymous Feedback System
// Class: 462
// Group: 2

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using GFS.Models;
using System.Web.ModelBinding;


namespace GFS.Admin
{
    public partial class EditTemplate : System.Web.UI.Page
    {
        private GFSContext _db = new GFSContext();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DropDownList1_Init(object sender, EventArgs e)
        {
            // add all the container names to the drop down list
            IQueryable<FormContainer> query = _db.FormContainers;

            List<FormContainer> someContainers = query.Select(p => p).ToList();

            DropDownList1.Items.Add(new ListItem("--Select One--", "null"));

            foreach (FormContainer aContainer in someContainers)
            {
                DropDownList1.Items.Add( new ListItem( aContainer.Name, aContainer.FormContainerID.ToString() ) );
            }
        }

        protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(DropDownList1.SelectedValue != "null")
            {

            }
            else
            {

            }
        }

        public IQueryable<Form> GetQuestionForms([Control] string DropDownList1)
        {
            IQueryable<Form> query = _db.Forms;

            if (DropDownList1 != null && DropDownList1 != "null")
            {
                // get the form container ID
                //var aContainerID = _db.Sections.Where(p => p.SectionName.ToString() == SectionDropdown).Select(p => p.FormContainerID).FirstOrDefault();
                query = query.Where(p => p.FormContainerID.ToString() == DropDownList1 );
            }
            else
            {
                query = null;
            }
            return query;
        }

        protected void feedbackFormList_ItemCreated(object sender, ListViewItemEventArgs e)
        {
            Form aForm = (Form)e.Item.DataItem;
            string check = e.Item.GetType().ToString();
            TextBox aTextbox = (TextBox)e.Item.FindControl("BodyTextbox");
            TextBox aTextbox2 = (TextBox)e.Item.FindControl("TitleBox");
            DropDownList aDropDownList = (DropDownList)e.Item.FindControl("RatingDropDown");
            if (aForm != null)
            {
                aTextbox2.Visible = true;
                if (aForm.FormType == 1)
                {
                    aTextbox.Visible = true;
                }
                else if (aForm.FormType == 2)
                {
                    aDropDownList.Visible = true;
                }
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            Button b = (Button)sender;
            ListViewDataItem thisListView = (ListViewDataItem)b.NamingContainer;
            DropDownList aDropDownList = (DropDownList)thisListView.FindControl("TypeDropDown");
            TextBox aTextBox = (TextBox)thisListView.FindControl("TitleBox");
            aTextBox.ReadOnly = false;
            Button aButton = (Button)thisListView.FindControl("SaveButton");
            aButton.Visible = true;
            HiddenField aField = (HiddenField)thisListView.FindControl("FormTypeField");
            TextBox bodyText = (TextBox)thisListView.FindControl("BodyTextBox");
            DropDownList ratingDrop = (DropDownList)thisListView.FindControl("RatingDropDown");
            if (aField.Value == "1")
            {
                bodyText.Visible = true;
                aDropDownList.Items.Add(new ListItem("Change to Rating Form", "2"));
            }
            else
            {
                ratingDrop.Visible = true;
                aDropDownList.Items.Add(new ListItem("Change to Question Form", "1"));
            }
            aDropDownList.Visible = true;
            b.Visible = false;
        }

        protected void TypeDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList thisDropDown = (DropDownList)sender;
            ListViewDataItem thisListView = (ListViewDataItem)thisDropDown.NamingContainer;
            TextBox bodyText = (TextBox)thisListView.FindControl("BodyTextBox");
            DropDownList ratingDrop = (DropDownList)thisListView.FindControl("RatingDropDown");
            
            if(thisDropDown.SelectedValue == "1")
            {
                thisDropDown.Items.Clear();
                thisDropDown.Items.Add(new ListItem("--Select One--", "null"));
                thisDropDown.Items.Add(new ListItem("Change to Rating Form", "2"));
                bodyText.Visible = true;
                ratingDrop.Visible = false;
            }
            else if(thisDropDown.SelectedValue == "2")
            {
                thisDropDown.Items.Clear();
                thisDropDown.Items.Add(new ListItem("--Select One--", "null"));
                thisDropDown.Items.Add(new ListItem("Change to Question Form", "1"));
                bodyText.Visible = false;
                ratingDrop.Visible = true;
            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            Button thisButton = (Button)sender;
            ListViewDataItem thisListView = (ListViewDataItem)thisButton.NamingContainer;
            HiddenField aField = (HiddenField)thisListView.FindControl("FormIDField");
            HiddenField aTypeField = (HiddenField)thisListView.FindControl("FormTypeField");
            TextBox aTextBox = (TextBox)thisListView.FindControl("TitleBox");
            Button editButton = (Button)thisListView.FindControl("EditButton");
            editButton.Visible = true;
            string aString = aTextBox.Text;
            DropDownList aDropDownList = (DropDownList)thisListView.FindControl("TypeDropDown");
            aTextBox.ReadOnly = true;
            //aDropDownList.Visible = false;
            thisButton.Visible = false;


            int temp;
            temp = Convert.ToInt32(aField.Value);
            var myItem = (from c in _db.Forms where c.FormID == temp select c).FirstOrDefault();
            myItem.Title = aTextBox.Text;

            TextBox bodyText = (TextBox)thisListView.FindControl("BodyTextBox");
            DropDownList ratingDrop = (DropDownList)thisListView.FindControl("RatingDropDown");
            if (bodyText.Visible)
                myItem.FormType = 1;
            else
                myItem.FormType = 2;
            _db.SaveChanges();
            
        }
    }
}