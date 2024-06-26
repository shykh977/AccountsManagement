using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
//using System.Net.Mail;
using System.Web.Mail;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using System.Text;
using System.Net.Mail;
using System.Net;
using System.IO;

/// <summary>
/// Summary description for SubUsers
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class SubUsers : System.Web.Services.WebService
{

    public SubUsers()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string CreateSubUsers(string UserId, string SubUserName, string Password, string Email, string Contact)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "usp_Create_Update_SubUsers";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@SubUserName", SubUserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Contact", Contact);
            
            



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }
     
    
    [WebMethod]
    public string UpdateSubUsers(string SubUserId, string UserId, string SubUserName, string Password, string Email, string Contact)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "usp_Create_Update_SubUsers";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@SubUserId", SubUserId);
            cmd.Parameters.AddWithValue("@UserId", UserId);
            cmd.Parameters.AddWithValue("@SubUserName", SubUserName);
            cmd.Parameters.AddWithValue("@Password", Password);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Contact", Contact);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }
    
    
    [WebMethod]
    public string DeleteSubUsers(string SubUserId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "DeleteSubUsers";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@SubUserId", SubUserId);                     
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();
        }
    }


    [WebMethod]
    public string GetSubUsers(string UserId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "GetSubUsers";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@UserId", UserId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<SubUserList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new SubUserList
                {

                    SubUserId            = dt.Rows[i]["SubUserId"].ToString(),   
                    UserId               = dt.Rows[i]["UserId"].ToString(),
                    SubUserName          = dt.Rows[i]["SubUserName"].ToString(),
                    Password             = dt.Rows[i]["Password"].ToString(),
                    LastLogin = dt.Rows[i]["LastLogin"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    Contact = dt.Rows[i]["Contact"].ToString(),



                };
                SubUser.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;

        }

    }
     
    
    [WebMethod]
    public string GetSubUsersById(string SubUserId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "GetSubUsers";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@SubUserId", SubUserId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<SubUserList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new SubUserList
                {

                    SubUserId = dt.Rows[i]["SubUserId"].ToString(),
                    UserId = dt.Rows[i]["UserId"].ToString(),
                    SubUserName = dt.Rows[i]["SubUserName"].ToString(),
                    Password = dt.Rows[i]["Password"].ToString(),
                    LastLogin = dt.Rows[i]["LastLogin"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    Contact = dt.Rows[i]["Contact"].ToString(),



                };
                SubUser.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;

        }

    }


    [WebMethod]
    public string LoginSubUser(string UserName, string Password)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            mSQL = "select * from SubUsers  where (Email = @username or Contact = @username ) and Password = @password";
            SqlDataAdapter sda = new SqlDataAdapter(mSQL, con);
            sda.SelectCommand.Parameters.AddWithValue("@username", UserName);
            sda.SelectCommand.Parameters.AddWithValue("@password", Password);
            DataTable dt = new DataTable();

            var usr = new SubUserList();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)

            {
                usr.UserId = dt.Rows[i]["UserId"].ToString();
                usr.SubUserName = dt.Rows[i]["SubUserName"].ToString();
                usr.Email = dt.Rows[i]["Email"].ToString();
                usr.Contact = dt.Rows[i]["Contact"].ToString();
                usr.Password = dt.Rows[i]["Password"].ToString();
                
                usr.SubUserId = dt.Rows[i]["SubUserId"].ToString();
                //usr.DateofCreation = Convert.ToDateTime(dt.Rows[i]["DateofCreation"]).ToString();
                //usr.ActiveStatus = Convert.ToInt16(dt.Rows[i]["ActiveStatus"]);
                //usr.UserTitle = dt.Rows[i]["FullName"].ToString();
                //usr.ChartLevel = dt.Rows[i]["ChartofAccountLevel"].ToString();
                //usr.WelcomeAlert = dt.Rows[i]["WelcomeAlert"].ToString();
                //usr.Bandwidth = dt.Rows[i]["Bandwidth"].ToString();
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(usr);
            return myData;
        }

    }


    [WebMethod]
    public string getSubUserInfo(string SubUserId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            mSQL = "SELECT u.*,SU.*,SU.Email AS SubUserEmail,c.name CountryName,c.alpha2code,CONVERT(char(10), DateofCreation,126) DateOfBirth  FROM [Users] u inner join CountryCodesX c on u.countryid = c.countryID inner join SubUsers SU on SU.UserId = U.Userid where SU.SubUserId = @SubUserId";
            SqlDataAdapter sda = new SqlDataAdapter(mSQL, con);
            sda.SelectCommand.Parameters.AddWithValue("@SubUserId", SubUserId);

            DataTable dt = new DataTable();

            var usr = new UserData();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)

            {
                usr.UserID = dt.Rows[i]["UserID"].ToString();
                usr.UserName = dt.Rows[i]["UserName"].ToString();
                usr.Password = dt.Rows[i]["Password"].ToString();
                usr.email = dt.Rows[i]["email"].ToString();
                usr.CellNo = dt.Rows[i]["CellNo"].ToString();
                usr.DateofCreation = Convert.ToDateTime(dt.Rows[i]["DateofCreation"]).ToString();
                usr.DateOfBirth = dt.Rows[i]["DateOfBirth"].ToString();
                usr.ActiveStatus = Convert.ToInt16(dt.Rows[i]["ActiveStatus"]);
                usr.UserTitle = dt.Rows[i]["FullName"].ToString();
                usr.CountryID = dt.Rows[i]["CountryID"].ToString();
                usr.CountryName = dt.Rows[i]["CountryName"].ToString();
                usr.alpha2Code = dt.Rows[i]["alpha2code"].ToString();
                usr.Gender = dt.Rows[i]["Gender"].ToString();
                usr.SearchField = dt.Rows[i]["SearchField"].ToString();
                usr.ChartLevel = dt.Rows[i]["ChartofAccountLevel"].ToString();
                usr.Bandwidth = dt.Rows[i]["Bandwidth"].ToString();
                usr.WelcomeAlert = dt.Rows[i]["WelcomeAlert"].ToString();
               
                usr.SubUserName       = dt.Rows[i]["SubUserName"].ToString();
                usr.SubUserEmail = dt.Rows[i]["SubUserEmail"].ToString();
                usr.Contact = dt.Rows[i]["Contact"].ToString();

            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(usr);
            return myData;

        }

    }


    [WebMethod]
    public string UpdateSubUsersPassword(string Password, string SubUserId)
    {
        string id1 = "Not Found";
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            // mSQL = "insert  into users(FullName,UserName,Password,CellNo, email,DateofCreation, ActiveStatus) output Inserted.UserID values ('" + myuser.FullName + "','" + myuser.UserName + "','" + myuser.Password + "','" + myuser.CellNo + "','" + myuser.email + "','" + Convert.ToDateTime(myuser.DateofCreation) + "','" + myuser.ActiveStatus + "')";
            mSQL = "update SubUsers set Password = @Password where SubUserId = @SubUserId";
            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.Parameters.AddWithValue("@SubUserId", SubUserId);
            cmd.Parameters.AddWithValue("@Password", Password);
            id1 = cmd.ExecuteNonQuery().ToString();
        }
        return id1;
    }


}

internal class SubUserList
{
    public string SubUserId { get; set; }
    public string UserId { get; set; }
    public string SubUserName { get; set; }
    public string Password { get; set; }
    public string LastLogin { get; set; }
    public string Email { get; internal set; }
    public string Contact { get; internal set; }
}


public class UserData
{
    //UserName, Password, CellNo, email, DateofCreation, ActiveStatus
    public string FullName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string CellNo { get; set; }
    public string email { get; set; }
    public string DateofCreation { get; set; }
    public int ActiveStatus { get; set; }
    public string UserID { get; set; }
    public string UserTitle { get; set; }
    public string SharedStatus { get; set; }
    public string CountryID { get; set; }
    public string CountryName { get; set; }
    public string alpha2Code { get; set; }
    public string DateOfBirth { get; set; }
    public string SearchField { get; set; }
    public string Gender { get; set; }
    public string SearchData { get; set; }
    public string ChartLevel { get; set; }
    public string WelcomeAlert { get; set; }
    public string Bandwidth { get; set; }

    /// <summary>
    /// SubUserData
    /// </summary>

    public string SubUserId { get; set; }
    
    public string SubUserEmail { get; set; }  
    public string SubUserName   { get; set; }  
    public string Email         { get; internal set; }
    public string Contact       { get; internal set; }
}