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

namespace GFS
{
    public partial class SubmitFeedback : System.Web.UI.Page
    {

        private GFSContext _db = new GFSContext();

        protected void Page_Load(object sender, EventArgs e)
        {

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

        protected void FeedbackSubmitBtn_Click( object sender, EventArgs e )
        {
            int missedCount = 0;
            //create feedback container to hold the feedback
            int aFormContainerID = Convert.ToInt32(SectionDropdown.SelectedValue);
            FeedbackContainer aFeedbackContainer = new FeedbackContainer
            {
                DateTimes = DateTime.Now,
                FormContainerID = Convert.ToInt32(aFormContainerID),
            };

            _db.FeedbackContainers.Add(aFeedbackContainer);
            _db.SaveChanges();
            int aFeedbackContainerID = aFeedbackContainer.FeedbackContainerID;

            string aString;
            TextBox aTextbox;
            DropDownList aDropDown;
            HiddenField aField;

            foreach (ListViewDataItem item in feedbackFormList.Items)
            {
                aTextbox = (TextBox)item.FindControl("BodyTextbox");
                aDropDown = (DropDownList)item.FindControl("RatingDropDown");
                aField = (HiddenField)item.FindControl("FormTypeField");

                if(aField.Value == "1")
                {
                    if(aTextbox.Text == "")
                    {
                        aTextbox.Visible = true;
                        missedCount++;
                    }
                    else
                    {
                        aString = aTextbox.Text;
                        item.Visible = false;
                        Feedback aFeedback = new Feedback
                        {
                            Message = aString,
                            UserID = "049058e1-965c-40af-adad-5fdd8a15c68c",
                            FeedbackContainerID = aFeedbackContainerID,
                            SectionID = Convert.ToInt32(SectionDropdown.SelectedItem.Text),
                        };
                        _db.Feedbacks.Add(aFeedback);
                        _db.SaveChanges();
                    }
                        
                }
                else if (aField.Value == "2")
                {
                    if (aDropDown.SelectedValue == "null")
                    {
                        aDropDown.Visible = true;
                        missedCount++;
                    }
                    else
                    {
                        aString = aDropDown.SelectedValue;
                        item.Visible = false;
                        Feedback aFeedback = new Feedback
                        {
                            Message = aString + " stars.",
                            UserID = "049058e1-965c-40af-adad-5fdd8a15c68c",
                            FeedbackContainerID = aFeedbackContainerID,
                            SectionID = Convert.ToInt32(SectionDropdown.SelectedItem.Text),
                        };
                        _db.Feedbacks.Add(aFeedback);
                        _db.SaveChanges();
                    }
                }
                item.Visible = false;
            }
            //feedbackFormList.Items.Clear();
            //feedbackFormList.Visible = false;
            FeedbackSubmitBtn.Visible = false;
            ThankYouLabel.Visible = true;
            SectionDropdown.Items.Clear();
            CourseDropdown.Items.Clear();
            SectionDropdown.Visible = false;
            CourseDropdown.Visible = false;
            SectionLabel.Visible = false;
            CourseLabel.Visible = false;
        }

        public IQueryable<Form> GetQuestionForms([Control] string SectionDropdown)
        {
            IQueryable<Form> query = _db.Forms;

            if (SectionDropdown != null && SectionDropdown != "null")
            {
                // get the form container ID
                //var aContainerID = _db.Sections.Where(p => p.SectionName.ToString() == SectionDropdown).Select(p => p.FormContainerID).FirstOrDefault();
                query = query.Where(p => p.FormContainerID.ToString() == SectionDropdown );
            }
            else
            {
                query = null;
            }
            return query;
        }

        protected void CourseDropdown_Init(object sender, EventArgs e)
        {
            IQueryable<Section> query = _db.Sections;
            List<string> someCourseNames = query.Select(p => p.CourseName).Distinct().ToList();
            foreach (string aCourseName in someCourseNames)
            {
                CourseDropdown.Items.Add(new ListItem(aCourseName, aCourseName));
            }
        }

        // fill the SectionId Dropdown Box when selection changes
        public void CourseDropdown_SelectedIndexChanged(Object sender, EventArgs e)
        {
            FeedbackSubmitBtn.Visible = false;
            // get the selection
            string selectedCourse = CourseDropdown.SelectedValue;
            if (selectedCourse != "null")
            {
                IQueryable<Section> query = _db.Sections;
                //get the sections with that CourseID
                List<int> someSectionIDs = query.Where(p => p.CourseName == selectedCourse).Select(p => p.SectionID).ToList();
                SectionDropdown.Items.Clear();
                SectionDropdown.Items.Add( new ListItem("--Select One--", "null") );
                foreach (int aSectionID in someSectionIDs)
                {
                    // get container ID
                    var aContainerID = _db.Sections.Where(s => s.SectionID == aSectionID).Select(p => p.FormContainerID).FirstOrDefault();
                    // get the section name
                    var aSectionName = _db.Sections.Where(s => s.SectionID == aSectionID).Select(p => p.SectionNumber).FirstOrDefault();

                    SectionDropdown.Items.Add( new ListItem(aSectionName.ToString(), aContainerID.ToString()));
                }
                SectionDropdown.Visible = true;
                SectionLabel.Visible = true;
            }
            else
            {
                SectionDropdown.Items.Clear();
                SectionDropdown.Visible = false;
                SectionLabel.Visible = false;
                FeedbackSubmitBtn.Visible = false;
            }
        }

        public void SectionDropdown_SelectedIndexChanged(Object sender, EventArgs e)
        {
            feedbackFormList.Items.Clear();
            if (SectionDropdown.SelectedValue == "null")
            {
                FeedbackSubmitBtn.Visible = false;
            }
            else
            {
                FeedbackSubmitBtn.Visible = true;
            }
                
        }
            
    }
}