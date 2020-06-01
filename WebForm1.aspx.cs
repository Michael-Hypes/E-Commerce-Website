using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AliffOuimetHypesScheduler
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        dataHandler dh;
        protected void Page_Load(object sender, EventArgs e)
        {
            dh = new dataHandler();
            
        }//Page_Load

        protected void confirm_Click(object sender, EventArgs e)
        {
            SqlDataReader dr = dh.getDataReader("select uEmail, uPass from validUser where uEmail ='" + 
                email.Text + "'");

            if (dr != null)
                dr.Read();

            if (dr!=null && dr.HasRows && (string)dr["uPass"] == password.Text)
            {
                Session["eUserEmail"] = email.Text;
                Response.Redirect("WebForm2.aspx");
            }//if
            else
            {
                incorrect.Visible = true;
            }//else
        }//confirm_Click
    }//WebForm1
}//AliffOuimetHypesScheduler