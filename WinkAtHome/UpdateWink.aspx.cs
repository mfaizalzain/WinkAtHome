﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WinkAtHome
{
    public partial class UpdateWink : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Padding to circumvent IE's buffer.
            Response.Write(new string('*', 256));
            Response.Flush();
            Wink.clearWink();

            UpdateProgress(0, "Getting Devices...");
            List<Wink.Device> devices =  Wink.Devices;

            UpdateProgress(25, "Getting Shortcuts...");
            List<Wink.Shortcut> shortcuts = Wink.Shortcuts;

            UpdateProgress(40, "Getting Groups...");
            List<Wink.Group> groups = Wink.Groups;

            UpdateProgress(100, "Last Refreshed: " + DateTime.Now.ToString(""));
        }

        protected void UpdateProgress(int PercentComplete, string Message)
        {
            // Write out the parent script callback.
            Response.Write(String.Format("<script type=\"text/javascript\">parent.UpdateProgress({0}, '{1}');</script>", PercentComplete, Message));
            // To be sure the response isn't buffered on the server.    
            Response.Flush();
        }
    }
}