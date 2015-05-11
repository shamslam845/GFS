// Coded By: Nicholas Irikawa
// Project: GFS
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
            DropDownList aDropDownList = (DropDownList)e.Item.FindControl("RatingDropDown");
            if (aForm != null)
            {
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
    }
}