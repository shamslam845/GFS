﻿using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Linq;
using GFS.Models;

namespace GFS
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<FormContainer> GetFeedbackContainers()
        {
            var _db = new GFS.Models.GFSContext();
            IQueryable<FormContainer> query = _db.FormContainers;
            return query;
        }
    }

    
}