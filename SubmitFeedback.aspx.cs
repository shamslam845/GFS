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
            ////<asp:TextBox ID="FeedbackMessage" runat="server" Height="230px" TextMode="MultiLine" Width="270px"></asp:TextBox>
            //PlaceHolder plcHolder = (PlaceHolder)e.Item.FindControl("TextBoxPlaceHolder");
            //TextBox txtbx = new TextBox();
            //txtbx.ID = "FeedbackTextBox";
            //txtbx.TextMode = TextBoxMode.MultiLine;
            //txtbx.EnableViewState = true;
            //if (plcHolder != null)
            //    plcHolder.Controls.Add(txtbx);
        }

        protected void FeedbackSubmitBtn_Click( object sender, EventArgs e )
        {
            // create a new feedback container
            int aFormContainerID = Convert.ToInt32(SectionDropdown.SelectedValue);
            FeedbackContainer aFeedbackContainer = new FeedbackContainer
            {
                //Title = feedbackBody,
                //FormType = 1,
                //FormContainerID = Convert.ToInt32(cid)
                FormContainerID = Convert.ToInt32(aFormContainerID),
            };
            // get its ID

            _db.FeedbackContainers.Add(aFeedbackContainer);
            _db.SaveChanges();

            int aFeedbackContainerID = aFeedbackContainer.FeedbackContainerID;
            foreach (ListViewDataItem item in feedbackFormList.Items)
            {
                TextBox aTextbox = (TextBox)item.FindControl("BodyTextbox");
                HiddenField aField = (HiddenField)item.FindControl("FormIDField");
                IQueryable<Section> sectionQuery = _db.Sections;
                int aSectionID = Convert.ToInt32(SectionDropdown.SelectedItem.Text);
                Feedback aFeedback = new Feedback
                {
                    SectionID = Convert.ToInt32(SectionDropdown.SelectedItem.Text),
                    Message = aTextbox.Text,
                    FeedbackContainerID = aFeedbackContainerID,
                    UserID = "049058e1-965c-40af-adad-5fdd8a15c68c",
                };
                _db.Feedbacks.Add(aFeedback);
                _db.SaveChanges();
            }
            
            
            // hide everything except the Thank You label
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
                query = query.Where(p => p.FormContainerID.ToString() == SectionDropdown && p.FormType == 1);
            }
            else
            {
                query = null;
            }
            
            return query;
        }

        public IQueryable<Form> GetRatingForms([Control] int? containerId)
        {
            IQueryable<Form> query = _db.Forms;
            if (containerId.HasValue && containerId > 0)
            {
                query = query.Where(p => p.FormContainerID == containerId && p.FormType == 2);
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
            SectionDropdown.AppendDataBoundItems = false;
        }

        public void SectionDropdown_SelectedIndexChanged(Object sender, EventArgs e)
        {
            if( SectionDropdown.SelectedValue == "null" )
                FeedbackSubmitBtn.Visible = false;
            else
                FeedbackSubmitBtn.Visible = true;
        }
    }
}

//<asp:ListView ID="ListView1" runat="server" 
//                DataKeyNames="FeedbackFormID" GroupItemCount="4"
//                ItemType="GFS.Models.FeedbackForm" SelectMethod="GetRatingForms">
//                <EmptyDataTemplate>
//                </EmptyDataTemplate>
//                <EmptyItemTemplate>
//                    <td/>
//                </EmptyItemTemplate>
//                <GroupTemplate>
//                    <tr id="itemPlaceholderContainer" runat="server">
//                        <td id="itemPlaceholder" runat="server"></td>
//                    </tr>
//                </GroupTemplate>
//                <ItemTemplate>
//                    <td runat="server">
//                        <table>
//                            <tr>
//                                <td>
//                                    <a href="Default.aspx?productID=<%#:Item.FeedbackFormID%>">
//                                    </a>
//                                </td>
//                            </tr>
//                            <tr>
//                                <td>
//                                    <b>Title: </b><%#:String.Format("{0:c}", Item.Title)%>
//                                    <br />
//                                        <b>Type: Rating</b>
//                                    <br />
//                                </td>
//                            </tr>
//                            <tr>
//                                <td>&nbsp;</td>
//                            </tr>
//                            <tr>
//                                <td>
//                                    <asp:DropDownList ID="DropDownList2" runat="server">
//                                        <asp:ListItem Value="1">1 Star</asp:ListItem>
//                                        <asp:ListItem Value="2">2 Stars</asp:ListItem>
//                                        <asp:ListItem Value="3">3 Stars</asp:ListItem>
//                                        <asp:ListItem Value="4">4 Stars</asp:ListItem>
//                                        <asp:ListItem Value="5">5 Stars</asp:ListItem>
//                                    </asp:DropDownList>
//                                </td>
//                            </tr>
//                        </table>
//                        </p>
//                    </td>
//                </ItemTemplate>
//                <LayoutTemplate>
//                    <table style="width:100%;">
//                        <tbody>
//                            <tr>
//                                <td>
//                                    <table id="groupPlaceholderContainer" runat="server" style="width:100%">
//                                        <tr id="groupPlaceholder"></tr>
//                                    </table>
//                                </td>
//                            </tr>
//                            <tr>
//                                <td></td>
//                            </tr>
//                            <tr></tr>
//                        </tbody>
//                    </table>
//                </LayoutTemplate>
//            </asp:ListView>