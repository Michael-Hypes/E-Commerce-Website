using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AliffOuimetHypesScheduler
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        dataHandler dh;
        protected void Page_Load(object sender, EventArgs e)
        {
            dh = new dataHandler();

            if (!IsPostBack)
            {
                refreshList();
            }//!IsPostBack
        }//Page_Load

        private void refreshList()
        {
            ListBoxUsers.Items.Clear();

            SqlDataReader dr = dh.getDataReader("Select uEmail, uName from validUser");

            if (dr.HasRows)
            {
                while (dr.Read())
                    ListBoxUsers.Items.Add(dr["uName"] + ": " + dr["uEmail"]);
            }//dr.HasRows
            else
                ListBoxUsers.Items.Add("None");

            ListBoxUsers.SelectedIndex = 0;
        }
        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            string email = TextBoxEmail.Text, name = TextBoxName.Text, pass1 = TextBoxPass1.Text, 
                pass2 = TextBoxPass2.Text;

            if (!email.Equals("") && !name.Equals("") && !pass1.Equals("") && !pass2.Equals(""))
            {
                if (pass1.Equals(pass2))
                {
                    SqlDataReader dr = dh.getDataReader("Select uName from validUser where uEmail ='" + email + "'");
                    if (!dr.HasRows)
                    {
                        dh.executeSql("insert into validUser(uEmail, uPass, uName) values ('" + email + "', '" + pass1 + 
                            "', '" + name + "')");
                        LabelError.Visible = false;
                        refreshList();
                    }//if (!dr.HasRows)
                    else
                    {
                        LabelError.Text = "Your email already exists";
                        LabelError.Visible = true;
                    }//else (!dr.HasRows)
                }//if (pass1.Equals(pass2))
                else
                {
                    LabelError.Text = "Your passwords do not match";
                    LabelError.Visible = true;
                }//else (pass1.Equals(pass2))
            }//if (!email.Equals("") && !name.Equals("") && !pass1.Equals("") && !pass2.Equals(""))
            else
            {
                LabelError.Text = "Please fill all fields";
                LabelError.Visible = true;
            }//else (!email.Equals("") && !name.Equals("") && !pass1.Equals("") && !pass2.Equals(""))
        }//ButtonAdd_Click

        protected void ButtonRemove_Click(object sender, EventArgs e)
        {
            string email = ListBoxUsers.SelectedValue.ToString().Substring(ListBoxUsers.SelectedValue.ToString().IndexOf(':')+1).Trim();

            SqlDataReader dr = dh.getDataReader("select * from roomEvent where eUserEmail = '" + email + "'");

            if (!dr.HasRows)
            {
                dh.executeSql("delete from validUser where uEmail = '"+email+"'");
                LabelRemoveError.Visible = false;
            }//if (!dr.HasRows)
            else
                LabelRemoveError.Visible = true;

            refreshList();
        }//ButtonRemove_Click
    }//WebForm3
}//AliffOuimetHypesScheduler