using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cursito
{
    public partial class contact : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {       //necesitamos cargar jquery atraves de los controles de servidor
            ScriptManager.ScriptResourceMapping.AddDefinition
                ("jquery", new ScriptResourceDefinition {
                    Path = "~/public/js/jquery.js",
                    DebugPath = "~/public/js/jquery.js",
                    CdnSupportsSecureConnection = true,
                    LoadSuccessExpression= "window.jQuery"

                });
        }
    }
}