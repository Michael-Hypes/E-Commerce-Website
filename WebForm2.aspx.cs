using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AliffOuimetHypesScheduler
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        dataHandler dh;
        List<string> buildings;

        protected void Page_Load(object sender, EventArgs e)
        {
            dh = new dataHandler();

            if(!IsPostBack)
            {
                buildings = new List<string>();
                SqlDataReader dr = dh.getDataReader("select * from eLocation");

                while (dr.Read())
                {
                    if (!buildings.Contains((string)dr["building"]))
                        buildings.Add((string)dr["building"]);
                }//while

                Building.DataSource = buildings;
                Building.DataBind();

                calendar.TodaysDate = DateTime.Now;
                calendar.SelectedDate = calendar.TodaysDate;
                dr.Close();

                Building.SelectedIndex = 0;
                calendar_SelectionChanged(calendar, EventArgs.Empty);
            }//!IsPostBack
        }//page_Load

        protected void Building_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<string> room = new List<string>();
            SqlDataReader dr = dh.getDataReader("select room from eLocation where building = '" + 
                Building.SelectedItem.Value + "'");

            while (dr.Read())
                room.Add((string)dr["room"]);
            Room.DataSource = room;
            Room.DataBind();

            dr.Close();

            Room.SelectedIndex = 0;
            Room_SelectedIndexChanged(Building, EventArgs.Empty);
        }//Building_SelectedIndexChanged

        protected void Room_SelectedIndexChanged(object sender, EventArgs e)
        {
            DateTime time = calendar.SelectedDate;
                SqlDataReader dr = dh.getDataReader("select eStartTime from roomEvent where building = '"+
                    Building.SelectedItem.Value+"' and room = '"+Room.SelectedItem.Value+ "' and eDate = '" + 
                    calendar.SelectedDate.ToString("yyyy/MM/dd") + "'");

            if (dr.HasRows)
            {

                SqlDataReader dr2 = dh.getDataReader("select eEndTime from roomEvent where building ='" +
                    Building.SelectedItem.Value + "' and room = '" + Room.SelectedItem.Value + "' and eDate = '" + 
                    calendar.SelectedDate.ToString("yyyy/MM/dd") + "'");
                List<string> sTimes = new List<string>(), eTimes = new List<string>();
                while (dr.Read() && dr2.Read())
                {
                    sTimes.Add(dr["eStartTime"].ToString());
                    eTimes.Add(dr2["eEndTime"].ToString());
                }

                List<DateTime> t = fillTime();

                for (int i = 0; i < t.Count; i++)
                    for (int j = 0; j < sTimes.Count; j++)
                        if (t[i].TimeOfDay.ToString().Equals(sTimes[j]))
                            while (t[i].TimeOfDay.ToString().CompareTo(eTimes[j]) < 0)
                                t.RemoveAt(i);
                List<TimeSpan> timeSpans = new List<TimeSpan>();
                for (int i = 0; i < t.Count; i++)
                    timeSpans.Add(t[i].TimeOfDay);

                sTime.DataSource = timeSpans;
            }
            else
            {
                List<DateTime> t = fillTime();
                List<TimeSpan> timeSpans = new List<TimeSpan>();
                for (int i = 0; i < t.Count; i++)
                    timeSpans.Add(t[i].TimeOfDay);
                sTime.DataSource = timeSpans;
            }

            sTime.DataBind();
            dr.Close();

            sTime.SelectedIndex = 0;
            sTime_SelectedIndexChanged(Building, EventArgs.Empty);

        }//Room_SelectedIndexChanged

        private List<DateTime> fillTime()
        {
            List<DateTime> times = new List<DateTime>();
            DateTime time = new DateTime(1, 1, 1, 8, 0, 0);
            while (time < new DateTime(1, 1, 1, 23, 0, 0))
            {
                times.Add(time);
                time = time.AddMinutes(30);
            }
            return times;
        }//fillTime

        protected void Building_DataBound(object sender, EventArgs e)
        {

        }//Building_DataBound

        protected void sTime_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlDataReader dr = dh.getDataReader("select eStartTime from roomEvent where building = '" + 
                Building.SelectedItem.Value + "' and room = '" + Room.SelectedItem.Value + "' and eDate = '" 
                + calendar.SelectedDate.ToString("yyyy/MM/dd") + "'");

            string[] temp = this.sTime.SelectedItem.Value.Split(':');
            DateTime time = calendar.SelectedDate;
            time = time.AddHours(int.Parse(temp[0]));
            time = time.AddMinutes(int.Parse(temp[1]));
            //DateTime time = new DateTime(1, 1, 1, int.Parse(temp[0]), int.Parse(temp[1]), int.Parse(temp[2]));

            List<DateTime> times = new List<DateTime>();
            if (dr.HasRows)
            {
                dr.Read();

                string sTime = dr["eStartTime"].ToString();
                while (time.TimeOfDay.ToString().CompareTo(sTime) < 0)
                {
                    time = time.AddMinutes(30);
                    times.Add(time);
                }
            }
            else
            {
                times = fillTime();
                while (times[0].TimeOfDay.ToString().CompareTo(time.TimeOfDay.ToString()) <= 0)
                    times.RemoveAt(0);
            }

            List<TimeSpan> timeSpans = new List<TimeSpan>();
            for (int i = 0; i < times.Count; i++)
                timeSpans.Add(times[i].TimeOfDay);

            eTime.DataSource = timeSpans;
            eTime.DataBind();
            dr.Close();

            eTime.SelectedIndex = 0;
        }//sTime_SelectedIndexChanged

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (!TextBoxDes.Equals(""))
            {
                dh.executeSql("insert into roomEvent(eDate, building, room, eStartTime, eEndTime, eDesc, eUserEmail) values " + 
                    "( '"
                              + calendar.SelectedDate.ToString("yyyy/MM/dd") + "', '"
                              + Building.SelectedValue + "', '"
                              + Room.SelectedValue + "', '"
                              + sTime.SelectedValue + "', '"
                              + eTime.SelectedValue + "', '"
                              + TextBoxDes.Text + "', '"
                              + Session["eUserEmail"] + "')");

                calendar_SelectionChanged(calendar, EventArgs.Empty);
                LabelDes.Visible = false;
            }
            else
                LabelDes.Visible = true;
        }//ButtonSubmit_Click

        protected void calendar_SelectionChanged(object sender, EventArgs e)
        {
            ListBoxEvents.Items.Clear();
            LabelDate.Text = calendar.SelectedDate.ToString("MM/dd/yyyy");
            SqlDataReader dr = dh.getDataReader
                ("select building, room, eDesc, eStartTime, eEndTime, uName from roomEvent, validUser where eDate = '" 
                + calendar.SelectedDate.ToString("yyyy/MM/dd") + "' and roomEvent.eUserEmail = validUser.uEmail");

            if (dr.HasRows)
            {
                string tabs = "\xA0\xA0\xA0\xA0\xA0\xA0\xA0\xA0";
                //email desc, starttime - endtime building room
                while (dr.Read())
                    ListBoxEvents.Items.Add(dr["uName"].ToString() + tabs
                                            + dr["eDesc"].ToString() + tabs
                                            + dr["eStartTime"].ToString() + "-" + dr["eEndTime"].ToString() + tabs
                                            + dr["building"].ToString() + " " + dr["room"].ToString());
                
            }//dr.HasRows
            else
                ListBoxEvents.Items.Add("None");

            ListBoxEvents.SelectedIndex = 0;
            Building_SelectedIndexChanged(Building, EventArgs.Empty);
        }//calendar_SelectionChanged

        protected void ButtonRemove_Click(object sender, EventArgs e)
        {
            if(!ListBoxEvents.SelectedValue.ToString().Equals("None"))
            {
                string temp = ListBoxEvents.SelectedValue.ToString();
                string[] selectedEvent = temp.Split("(\xA0\xA0\xA0\xA0\xA0\xA0\xA0\xA0)".ToCharArray(), 
                    StringSplitOptions.RemoveEmptyEntries);

                //roomEvent(eDate, building, room, eStartTime, eEndTime, eDesc, eUserEmail)
                dh.executeSql("delete from roomEvent where eDate = '" + LabelDate.Text.Trim() + "' and building = '" + 
                    selectedEvent[3].Substring(0, selectedEvent[3].LastIndexOf(" ")).Trim() + "' and room = '" + 
                    selectedEvent[3].Substring(selectedEvent[3].LastIndexOf(" ")).Trim() + "' and eStartTime = '" + 
                    selectedEvent[2].Substring(0, selectedEvent[2].IndexOf("-")).Trim() + "'");

                calendar_SelectionChanged(calendar, EventArgs.Empty);
            }//if
        }//ButtonRemove_Click

        protected void ButtonAddNewUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm3.aspx");
        }//ButtonAddNewUser_Click

        protected void ButtonLocations_Click(object sender, EventArgs e)
        {
            Response.Redirect("WebForm4.aspx");
        }//ButtonLocations_Click
    }//WebForm2
}//AliffOuimetHypesScheduler