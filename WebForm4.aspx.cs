using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AliffOuimetHypesScheduler
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        dataHandler dh;
        protected void Page_Load(object sender, EventArgs e)
        {
            dh = new dataHandler();

            if (!IsPostBack)
            {
                refreshList();
            }//if (!IsPostBack)
        }//Page_Load

        private void refreshList()
        {
            ListBoxUsers.Items.Clear();

            SqlDataReader dr = dh.getDataReader("Select building, room from eLocation");

            if (dr.HasRows)
            {
                while (dr.Read())
                    ListBoxUsers.Items.Add(dr["building"] + ": " + dr["room"]);
            }//dr.HasRows
            else
                ListBoxUsers.Items.Add("None");

            ListBoxUsers.SelectedIndex = 0;
        }

        protected void ButtonRemove_Click(object sender, EventArgs e)
        {
            string building = ListBoxUsers.SelectedValue.ToString().Substring(0, 
                ListBoxUsers.SelectedValue.ToString().IndexOf(':')).Trim();
            string room = ListBoxUsers.SelectedValue.ToString().Substring
                (ListBoxUsers.SelectedValue.ToString().IndexOf(':') + 1).Trim();

            SqlDataReader dr = dh.getDataReader("select * from roomEvent where building = '"+
                building+"' and room = '"+room+"'");

            if (!dr.HasRows)
            {
                dh.executeSql("delete from eLocation where building = '" + building + "' and room = '" + 
                    room + "'");
                LabelRemoveError.Visible = false;
            }
            else
                LabelRemoveError.Visible = true;

                refreshList();
        }//ButtonRemove_Click

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            string building = TextBoxBuilding.Text, room = TextBoxRoom.Text;

            if (!building.Equals("") && !room.Equals(""))
            {
                SqlDataReader dr = dh.getDataReader("select * from eLocation where building = '" + building + 
                    "' and room = '" + room + "'");
                if(!dr.HasRows)
                {
                    dh.executeSql("insert into eLocation(building, room) values ('" + building + "', '" + 
                        room + "')");
                    LabelError.Visible = false;
                    refreshList();
                }//if(!dr.HasRows)
                else
                {
                    LabelError.Text = "The location already exists";
                    LabelError.Visible = true;
                }//else(!dr.HasRows)
            }//if (!building.Equals("") && !room.Equals(""))
            else
            {
                LabelError.Text = "Please fill all fields";
                LabelError.Visible = true;
            }//else (!building.Equals("") && !room.Equals(""))
        }//ButtonAdd_Click
    }//WebForm4
}//AliffOuimetHypesScheduler