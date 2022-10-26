using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cursito
{
    public partial class Index : System.Web.UI.Page
    {
        private int id;
        private string name;

        public Index()
        {
            //inicializo las variables del constructor
            id = 1;
            name ="WebForms";
        }

        protected void Page_Load(object sender, EventArgs e)
        {
          
               
        }
       protected void btnStatic_Click(object sender,EventArgs e)
        {
            if (name != null)
            {
                Console.WriteLine("Estoy haciendo un proceso estatico");
            }
        }
       public String btnReturn(object sender, EventArgs e)
        {

            return "<p>Estoy retornando<p>";
        }
        protected void btnEjec(object sender, EventArgs e)
        {

        }
    }
}