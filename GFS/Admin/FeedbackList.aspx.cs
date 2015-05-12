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
    public partial class FeedbackList1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        // The return type can be changed to IEnumerable, however to support
        // paging and sorting, the following parameters must be added:
        //     int maximumRows
        //     int startRowIndex
        //     out int totalRowCount
        //     string sortByExpression
        public IQueryable<Section> GetCourses()
        {
            var _db = new GFS.Models.GFSContext();
            IQueryable<Section> query = _db.Sections;

            return query;
        }

        //TODO: THIS NEEDS query multiple tables to get the columns needed to display. When someone clicks on the course, It
        //should only display that particular course feedback.
        /*public IQueryable<Feedback> GetFeedbacks([QueryString("id")] int? sectionID)
        {
            GFSContext db = new GFS.Models.GFSContext();

            var query = db.Feedbacks.Include(e => e.Section).Where(e => e.SectionID == sectionID);

            return query;
        }*/

        public IQueryable<Feedback> GetFeedbackDetails([QueryString("feedbackID")] int? feedbackID)
        {
            var db = new GFS.Models.GFSContext();

            IQueryable<Feedback> query = db.Feedbacks;
            if(feedbackID.HasValue && feedbackID > 0)
            {
                query = query.Where(p => p.FeedbackID == feedbackID);
            }
            else
            {
                query = null;
            }
            return query;
        }
        /*
        public IQueryable<Course> GetCourses()
        {
            var _db = new GFS.Models.FeedbackContext();
            IQueryable<Course> query = _db.Courses;

            return query;
        }

        public IQueryable<Feedback> GetFeedbacks([QueryString("id")] int? courseId)
        {
            var _db = new GFS.Models.FeedbackContext();
            IQueryable<Feedback> query = _db.Feedbacks;
            if(courseId.HasValue && courseId > 0)
            {
                query = query.Where(c => c.CourseId == courseId);
            }
            return query;
        }

        public IQueryable<Feedback> GetFeedbackDetails([QueryString("feedbackId")] int? feedbackID)
        {
            var _db = new GFS.Models.FeedbackContext();
            IQueryable<Feedback> query = _db.Feedbacks;
            if(feedbackID.HasValue && feedbackID > 0)
            {
                query = query.Where(p => p.FeedbackId == feedbackID);
            }
            else
            {
                query = null;
            }
            return query;
        }
        */
        protected void Reply_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string redirects = "/Admin/FeedbackReply?sectionId=" + btn.CommandArgument.ToString();
            Response.Redirect(redirects);
        }
    }
}