using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Reflection;

namespace AliffOuimetHypesScheduler
{
    public class dataHandler
    {
        #region Global Variables
        private string cString;
        private SqlConnection cn = null;
        private SqlCommand cmd;
        #endregion

        public dataHandler()
        {
            setConnectionString();
        }//default Constructor

        public string getPath()
        {
            string s = HttpRuntime.AppDomainAppPath;
            string name = Assembly.GetCallingAssembly().GetName().Name;
            int i = s.IndexOf(name);
            s = s.Substring(0, i + name.Length + 1);
            return s;
        }//getPath

        private void setConnectionString()
        {
            //ConnectionString.txt
            cString = "Server=" + File.ReadAllText(getPath() + "ConnectionString.txt") + ";" +
                "Database=myEvent;" +
                "User Id=sa;" +
                "Password=Fred17dbase";
        }//getConnectionString

        public string getId(string query)
        {
            SqlDataReader dr;
            string result = "";

            try
            {
                cn = new SqlConnection(cString);
                cmd = new SqlCommand(query, cn);
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                dr.Read();
                result = (string)dr["sidno"];
                dr.Close();
            }//try
            catch (Exception e)
            {
                Console.WriteLine(e);
                cn.Close();
            }//catch(Exception e)

            return result;
        }//getId

        public SqlDataReader getDataReader(string query)
        {
            SqlDataReader dr;

            try
            {
                cn = new SqlConnection(cString);
                cmd = new SqlCommand(query, cn);
                cn.Open();
                dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                return dr;
                
            }//try
            catch (Exception e)
            {
                Console.WriteLine(e);
                cn.Close();
            }//catch(Exception e)

            return null;
        }//getDataReader

        public DataTable getDataTable(string query)
        {
            DataTable dt;
            SqlDataAdapter da;

            try
            {
                cn = new SqlConnection(cString);
                cmd = new SqlCommand(query, cn);
                dt = new DataTable();

                da = new SqlDataAdapter(cmd);
                da.Fill(dt);

            }//try
            finally
            {
                cn.Close();
            }//finally

            return dt;
        }//getDataTable

        public void executeSql(string query)
        {

            try
            {
                cn = new SqlConnection(cString);
                cmd = new SqlCommand(query, cn);
                cn.Open();
                cmd.ExecuteNonQuery();
            }//try
            finally
            {
                cn.Close();
            }//finally
        }//executeSql

        public object getScalar(string query)
        {
            object o;

            try
            {
                cn = new SqlConnection(cString);
                cmd = new SqlCommand(query, cn);
                cn.Open();
                o = cmd.ExecuteScalar();
            }//try
            finally
            {
                cn.Close();
            }//finally

            return o;
        }//getScalar
    }//dataHandler
}//AliffOuimetHypesScheduler