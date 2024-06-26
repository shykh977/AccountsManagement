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
/// Summary description for Users
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Users : System.Web.Services.WebService
{

    public Users()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
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

    }
    public class AccountSharingStatus
    {
        //UserName, Password, CellNo, email, DateofCreation, ActiveStatus
        public string Receiver { get; set; }
        public string Reseveruserid { get; set; }
        public string NotiStatus { get; set; }
        public string Accounts { get; set; }
        public string sender { get; set; }




    }
    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public string SaveUsers(string UserName, string Password, string CellNo, string email, string DateofCreation, string ActiveStatus)
    {
        var myuser = new UserData();
        myuser.UserName = UserName;
        myuser.Password = Password;
        myuser.CellNo = CellNo;
        myuser.email = email;
        myuser.DateofCreation = (DateofCreation);
        myuser.ActiveStatus = Convert.ToInt32(ActiveStatus);
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            mSQL = "insert  into users(UserName,Password,CellNo, email,DateofCreation, ActiveStatus) output Inserted.UserID values ('" + UserName + "','" + Password + "','" + CellNo + "','" + email + "','" + Convert.ToDateTime(DateofCreation) + "','" + ActiveStatus + "')";

            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return cmd.ExecuteScalar().ToString();

        }

    }

    private string CheckMobileandEmail(string email, string cellno)
    {

        string mSQL;
        string msg = "Not Found";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            // mSQL = "insert  into users(FullName,UserName,Password,CellNo, email,DateofCreation, ActiveStatus) output Inserted.UserID values ('" + myuser.FullName + "','" + myuser.UserName + "','" + myuser.Password + "','" + myuser.CellNo + "','" + myuser.email + "','" + Convert.ToDateTime(myuser.DateofCreation) + "','" + myuser.ActiveStatus + "')";
            mSQL = "Select ltrim(rtrim(email)) email,ltrim(rtrim(cellno)) cellno from users where email=@email or cellno=@cellno";
            SqlDataAdapter cmd = new SqlDataAdapter(mSQL, con);
            cmd.SelectCommand.Parameters.AddWithValue("@email", email);
            cmd.SelectCommand.Parameters.AddWithValue("@cellno", cellno);
            cmd.SelectCommand.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dt = new DataTable();
            cmd.Fill(dt);

            if (dt.Rows.Count > 0)
            {
                msg = "";
                if (dt.Rows[0]["email"].ToString().ToUpper() == email.ToUpper() && dt.Rows[0]["email"].ToString().Replace(" ", "") != "")
                {
                    msg = msg + " Email already registered";
                }

                if (dt.Rows[0]["cellno"].ToString().ToUpper() == cellno.ToUpper() && dt.Rows[0]["cellno"].ToString().ToString().Replace(" ", "") != "")
                {
                    msg = msg + " Cell No. already registered";
                }
                if (msg == "")
                {
                    msg = "Not Found";
                }
            }

        }

        return msg;
    }


    public class userifo
    {

        public string Userid { get; set; }
    }

    [WebMethod]
    public string SaveUsers4()
    {
        var fullname = HttpContext.Current.Request.Params["fullname"];
        var username = HttpContext.Current.Request.Params["username"];
        var password = HttpContext.Current.Request.Params["password"];
        var cell = HttpContext.Current.Request.Params["cell"];
        var email = HttpContext.Current.Request.Params["email"];
        var dob = HttpContext.Current.Request.Params["dob"];
        var active = HttpContext.Current.Request.Params["active"];
        var img = HttpContext.Current.Request.Params["img"];
        var CountryID = HttpContext.Current.Request.Params["CountryID"];
        var Level = HttpContext.Current.Request.Params["Level"];
        ////Request.Form["guid"];
        ////Request.Files["FileUpload"];
        var myuser = new UserData();
        //myuser.FullName = HttpContext.Current.Request.Params["FullName"].ToString();
        //myuser.UserName = HttpContext.Current.Request.Params["UserName"].ToString();
        //myuser.Password = HttpContext.Current.Request.Params["Password"].ToString();
        //myuser.CellNo = HttpContext.Current.Request.Params["Cell"].ToString();
        //myuser.email = HttpContext.Current.Request.Params["email"].ToString();
        //myuser.DateofCreation = HttpContext.Current.Request.Params["DOB"].ToString();
        //myuser.ActiveStatus = Convert.ToInt32(HttpContext.Current.Request.Params["Active"].ToString());
        //string file = HttpContext.Current.Request.Params["imgfile"].ToString();
        string id1 = CheckMobileandEmail(email, cell);
        if (id1 == "Not Found")
        {
            if (email == "")
            {

            }

            myuser.FullName = fullname;
            myuser.UserName = username;
            myuser.Password = password;
            myuser.CellNo = cell;
            myuser.email = email;
            myuser.DateofCreation = dob;
            myuser.ActiveStatus = Convert.ToInt32(active);
            string file = img;
            // BinaryReader file = new BinaryReader(convert.HttpContext.Current.Request.Params["imgfile"])

            //string saveFile = file.FileName;
            //string[] ext1 = saveFile.Split('.');
            //string ext = ext1[1];
            var dt = myuser.DateofCreation.Split('/');
            // myuser.DateofCreation = dt[2] + "-" + dt[1] + "-" + dt[0];
            string mSQL;
            var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            using (var con = new SqlConnection(cs))
            {

                // mSQL = "insert  into users(FullName,UserName,Password,CellNo, email,DateofCreation, ActiveStatus) output Inserted.UserID values ('" + myuser.FullName + "','" + myuser.UserName + "','" + myuser.Password + "','" + myuser.CellNo + "','" + myuser.email + "','" + Convert.ToDateTime(myuser.DateofCreation) + "','" + myuser.ActiveStatus + "')";
                mSQL = "insert  into users(FullName,UserName,Password,CellNo, email,DateofCreation, ActiveStatus,CountryID,ChartofAccountLevel) output Inserted.UserID values ('" + myuser.FullName + "','" + myuser.UserName + "','" + myuser.Password + "','" + myuser.CellNo + "','" + myuser.email + "',getdate(),'" + myuser.ActiveStatus + "','" + CountryID + "','" + Level + "')";
                SqlCommand cmd = new SqlCommand(mSQL, con);
                cmd.CommandTimeout = 0;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                id1 = cmd.ExecuteScalar().ToString();
                if (file != "")
                {
                    //string[] str1 = file.Split(',');
                    File.WriteAllBytes(Server.MapPath("/UserPic/") + id1 + ".jpg", Convert.FromBase64String(file));
                }

                mSQL = "Update AccountSharing set UserID='" + id1 + "', ActiveStatus='" + myuser.ActiveStatus.ToString() + "' where Email='" + myuser.email + "' or CellNo='" + myuser.CellNo + "'";
                cmd = new SqlCommand(mSQL, con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GenerateNewUserAccount";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@userID", id1);
                cmd.Parameters.AddWithValue("@Business", "CA405627-9696-4FD0-A4B2-5CC070EEFE92");

                cmd.ExecuteNonQuery();

                //file.SaveAs(Server.MapPath("/UserPic/" + id1 + "."+ ext));
                //return cmd.ExecuteScalar().ToString();
            }
        }
        userifo urid = new userifo();
        urid.Userid = id1;
        var js = new JavaScriptSerializer();
        string myData = js.Serialize(urid);
        return myData;
        //return id1;


    }


    [WebMethod]
    public string UpdateUsersPassword4()
    {

        var Password = HttpContext.Current.Request.Params["Password"];
        var UserID = HttpContext.Current.Request.Params["UserID"];

        string id1 = "Not Found";
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            // mSQL = "insert  into users(FullName,UserName,Password,CellNo, email,DateofCreation, ActiveStatus) output Inserted.UserID values ('" + myuser.FullName + "','" + myuser.UserName + "','" + myuser.Password + "','" + myuser.CellNo + "','" + myuser.email + "','" + Convert.ToDateTime(myuser.DateofCreation) + "','" + myuser.ActiveStatus + "')";
            mSQL = "update users set Password=@Password output Inserted.UserID where userid=@userid";
            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.Parameters.AddWithValue("@UserID", UserID);

            cmd.Parameters.AddWithValue("@Password", Password);
            id1 = cmd.ExecuteScalar().ToString();

        }
        userifo urid = new userifo();
        urid.Userid = id1;
        var js = new JavaScriptSerializer();
        string myData = js.Serialize(urid);
        return myData;
        //return id1;


    }


    [WebMethod]
    public string UpdateUsers4()
    {

        var fullname = HttpContext.Current.Request.Params["fullname"];
        var username = HttpContext.Current.Request.Params["username"];
        var cell = HttpContext.Current.Request.Params["cell"];
        var email = HttpContext.Current.Request.Params["email"];
        var dob = HttpContext.Current.Request.Params["dob"];
        var active = HttpContext.Current.Request.Params["active"];
        var img = HttpContext.Current.Request.Params["img"];
        var CountryID = HttpContext.Current.Request.Params["CountryID"];
        var UserID = HttpContext.Current.Request.Params["UserID"];
        var CurrentEmail = HttpContext.Current.Request.Params["CurrentEmail"];
        var CurrentCellNo = HttpContext.Current.Request.Params["CurrentCellNo"];
        var Gender = HttpContext.Current.Request.Params["Gender"];
        var SearchField = HttpContext.Current.Request.Params["SearchField"];
        var SearchData = HttpContext.Current.Request.Params["SearchData"];
        var Level = HttpContext.Current.Request.Params["Level"];



        var myuser = new UserData();

        string id1 = "";
        if (!(CurrentCellNo == cell))
        {
            id1 = CheckMobile(cell);
        }
        if (id1 == "Not Found" || id1 == "")
        {
            myuser.FullName = fullname;
            myuser.UserName = username;
            //myuser.Password = password;
            myuser.CellNo = cell;
            myuser.email = email;
            myuser.DateofCreation = dob;
            myuser.ActiveStatus = Convert.ToInt32(active);
            string file = img;
            // BinaryReader file = new BinaryReader(convert.HttpContext.Current.Request.Params["imgfile"])

            //string saveFile = file.FileName;
            //string[] ext1 = saveFile.Split('.');
            //string ext = ext1[1];
            var dt = myuser.DateofCreation.Split('/');
            // myuser.DateofCreation = dt[2] + "-" + dt[1] + "-" + dt[0];
            string mSQL;
            var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            using (var con = new SqlConnection(cs))
            {

                // mSQL = "insert  into users(FullName,UserName,Password,CellNo, email,DateofCreation, ActiveStatus) output Inserted.UserID values ('" + myuser.FullName + "','" + myuser.UserName + "','" + myuser.Password + "','" + myuser.CellNo + "','" + myuser.email + "','" + Convert.ToDateTime(myuser.DateofCreation) + "','" + myuser.ActiveStatus + "')";
                mSQL = "update users set FullName=@FullName, CellNo=@CellNo, DateofCreation=@DateofCreation, ActiveStatus=@ActiveStatus,CountryID=@CountryID,Gender=@Gender,SearchField=@SearchField,SearchData=@SearchData,ChartofAccountLevel=@Level output Inserted.UserID where userid=@userid";
                SqlCommand cmd = new SqlCommand(mSQL, con);
                cmd.CommandTimeout = 0;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                //cmd.Parameters.AddWithValue("@UserName", email);
                //cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@CellNo", cell);
                //cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@DateofCreation", dob);
                cmd.Parameters.AddWithValue("@ActiveStatus", active);
                cmd.Parameters.AddWithValue("@CountryID", CountryID);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@SearchField", SearchField);
                cmd.Parameters.AddWithValue("@SearchData", SearchData);
                cmd.Parameters.AddWithValue("@Level", Level);





                id1 = cmd.ExecuteScalar().ToString();
                if (file != "")
                {
                    //string[] str1 = file.Split(',');
                    File.WriteAllBytes(Server.MapPath("/UserPic/") + id1 + ".jpg", Convert.FromBase64String(file));
                }

                mSQL = "Update AccountSharing set UserID='" + id1 + "', ActiveStatus='" + myuser.ActiveStatus.ToString() + "' where Email='" + myuser.email + "' or CellNo='" + myuser.CellNo + "'";
                cmd = new SqlCommand(mSQL, con);
                cmd.ExecuteNonQuery();

                //cmd = new SqlCommand();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "GenerateNewUserAccount";
                //cmd.Connection = con;
                //cmd.Parameters.AddWithValue("@userID", id1);
                //cmd.Parameters.AddWithValue("@Business", "CA405627-9696-4FD0-A4B2-5CC070EEFE92");

                //cmd.ExecuteNonQuery();

                //file.SaveAs(Server.MapPath("/UserPic/" + id1 + "."+ ext));
                //return cmd.ExecuteScalar().ToString();
            }
        }
        userifo urid = new userifo();
        urid.Userid = id1;
        var js = new JavaScriptSerializer();
        string myData = js.Serialize(urid);
        return myData;
        // return id1;


    }


    private string CheckMobile(string cellno)
    {

        string mSQL;
        string msg = "Not Found";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            // mSQL = "insert  into users(FullName,UserName,Password,CellNo, email,DateofCreation, ActiveStatus) output Inserted.UserID values ('" + myuser.FullName + "','" + myuser.UserName + "','" + myuser.Password + "','" + myuser.CellNo + "','" + myuser.email + "','" + Convert.ToDateTime(myuser.DateofCreation) + "','" + myuser.ActiveStatus + "')";
            mSQL = "Select ltrim(rtrim(cellno)) cellno from users where cellno=@cellno";
            SqlDataAdapter cmd = new SqlDataAdapter(mSQL, con);

            cmd.SelectCommand.Parameters.AddWithValue("@cellno", cellno);
            cmd.SelectCommand.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            DataTable dt = new DataTable();
            cmd.Fill(dt);

            if (dt.Rows.Count > 0)
            {

                if (dt.Rows[0]["cellno"].ToString().ToUpper() == cellno.ToUpper() && dt.Rows[0]["cellno"].ToString().ToString().Replace(" ", "") != "")
                {
                    msg = " Cell No. already registered";
                }
                if (msg == "")
                {
                    msg = "Not Found";
                }
            }

        }

        return msg;
    }

    [WebMethod]
    public string SaveUsers2(string fullname, string username, string password, string cell, string email, string dob, string active, string img, string CountryID, string Level)
    {
        ////Request.Form["guid"];
        ////Request.Files["FileUpload"];
        var myuser = new UserData();
        //myuser.FullName = HttpContext.Current.Request.Params["FullName"].ToString();
        //myuser.UserName = HttpContext.Current.Request.Params["UserName"].ToString();
        //myuser.Password = HttpContext.Current.Request.Params["Password"].ToString();
        //myuser.CellNo = HttpContext.Current.Request.Params["Cell"].ToString();
        //myuser.email = HttpContext.Current.Request.Params["email"].ToString();
        //myuser.DateofCreation = HttpContext.Current.Request.Params["DOB"].ToString();
        //myuser.ActiveStatus = Convert.ToInt32(HttpContext.Current.Request.Params["Active"].ToString());
        //string file = HttpContext.Current.Request.Params["imgfile"].ToString();
        string id1 = CheckMobileandEmail(email, cell);
        if (id1 == "Not Found")
        {
            myuser.FullName = fullname;
            myuser.UserName = username;
            myuser.Password = password;
            myuser.CellNo = cell;
            myuser.email = email;
            myuser.DateofCreation = dob;
            myuser.ActiveStatus = Convert.ToInt32(active);
            string file = img;
            // BinaryReader file = new BinaryReader(convert.HttpContext.Current.Request.Params["imgfile"])

            //string saveFile = file.FileName;
            //string[] ext1 = saveFile.Split('.');
            //string ext = ext1[1];
            var dt = myuser.DateofCreation.Split('/');
            // myuser.DateofCreation = dt[2] + "-" + dt[1] + "-" + dt[0];
            string mSQL;
            var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            using (var con = new SqlConnection(cs))
            {

                // mSQL = "insert  into users(FullName,UserName,Password,CellNo, email,DateofCreation, ActiveStatus) output Inserted.UserID values ('" + myuser.FullName + "','" + myuser.UserName + "','" + myuser.Password + "','" + myuser.CellNo + "','" + myuser.email + "','" + Convert.ToDateTime(myuser.DateofCreation) + "','" + myuser.ActiveStatus + "')"; Usama Maqbool Dogar -+- 
                mSQL = "insert  into users(FullName,UserName,Password,CellNo, email,DateofCreation, ActiveStatus,CountryID,ChartofAccountLevel,SearchData) output Inserted.UserID values ('" + myuser.FullName + "','" + myuser.UserName + "','" + myuser.Password + "','" + myuser.CellNo + "','" + myuser.email + "',getdate(),'" + myuser.ActiveStatus + "','" + CountryID + "','" + Level + "','" + myuser.FullName + "-+-')";
                SqlCommand cmd = new SqlCommand(mSQL, con);
                cmd.CommandTimeout = 0;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }



                id1 = cmd.ExecuteScalar().ToString();
                if (file != "")
                {
                    string[] str1 = file.Split(',');
                    File.WriteAllBytes(Server.MapPath("/UserPic/") + id1 + ".jpg", Convert.FromBase64String(str1[1]));
                }

                mSQL = "Update AccountSharing set UserID='" + id1 + "', ActiveStatus='" + myuser.ActiveStatus.ToString() + "' where Email='" + myuser.email + "' or CellNo='" + myuser.CellNo + "'";
                cmd = new SqlCommand(mSQL, con);
                cmd.ExecuteNonQuery();

                cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GenerateNewUserAccount";
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@userID", id1);

                if (Level == "1")
                {
                    cmd.Parameters.AddWithValue("@Business", "2A2B7B83-09BB-4A87-A1F6-22A42F87B8FD");
                }
                else if (Level == "2")
                {
                    cmd.Parameters.AddWithValue("@Business", "102A030A-652B-46EC-8FF3-47899E6988A2");
                }
                else if (Level == "3")
                { cmd.Parameters.AddWithValue("@Business", "CA405627-9696-4FD0-A4B2-5CC070EEFE92"); }

                cmd.ExecuteNonQuery();

                //file.SaveAs(Server.MapPath("/UserPic/" + id1 + "."+ ext));
                //return cmd.ExecuteScalar().ToString();
            }
        }

        return id1;


    }


    [WebMethod]
    public string UpdateUsersPassword2(string Password, string UserID)
    {
        string id1 = "Not Found";
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            // mSQL = "insert  into users(FullName,UserName,Password,CellNo, email,DateofCreation, ActiveStatus) output Inserted.UserID values ('" + myuser.FullName + "','" + myuser.UserName + "','" + myuser.Password + "','" + myuser.CellNo + "','" + myuser.email + "','" + Convert.ToDateTime(myuser.DateofCreation) + "','" + myuser.ActiveStatus + "')";
            mSQL = "update users set Password=@Password output Inserted.UserID where userid=@userid";
            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@Password", Password);
            id1 = cmd.ExecuteScalar().ToString();
        }
        return id1;
    }


    [WebMethod]
    public string UpdateAccountResetPassword(string email, string Status)
    {

        string id1 = "Not Found";
        string mSQL;
        string uservalue;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            mSQL = "Select fullname+'}'+cellno+'}'+email val1 from  users where email='" + email + "' ";
            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            uservalue = (string)cmd.ExecuteScalar();
        }
        if (uservalue == null)
        {
            return id1;
        }
        string[] arg = uservalue.Split('}');

        using (var con = new SqlConnection(cs))
        {

            // mSQL = "insert  into users(FullName,UserName,Password,CellNo, email,DateofCreation, ActiveStatus) output Inserted.UserID values ('" + myuser.FullName + "','" + myuser.UserName + "','" + myuser.Password + "','" + myuser.CellNo + "','" + myuser.email + "','" + Convert.ToDateTime(myuser.DateofCreation) + "','" + myuser.ActiveStatus + "')";
            mSQL = "update users set ResetPasswod='" + Status + "',PasswordToken=newid(),PasswordTokenTime=getdate() output Inserted.PasswordToken where email=@email";
            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.Parameters.AddWithValue("@email", email);

            // cmd.Parameters.AddWithValue("@Password", Password);
            id1 = cmd.ExecuteScalar().ToString();
            //id1 = id1 ?? "Not Found";
            if (id1.Length == 36)
            {
                string subject = "Password Reset Request Confirmation ";
                string body1 = "Dear " + arg[0] + ",<br/><br/>" + "You, or someone on your behalf, has requested to ";
                body1 = body1 + "issue a new password to account's email address that, we have in our record. <br/<br/> Please confirm through this link; <br/> ";
                body1 = body1 + "<br/><a href='http://Munshibaba.com/Forgotpassword.html?token=" + id1 + "'> Click Here to Reset Password </a> <br/>";
                body1 = body1 + "<br/> Note: If you did not initiate this request, please discard this message, and do not click on the link above (because otherwise that, will generate a new password for your account).";
                body1 = body1 + "<br/><br/><br/><br/>Regards,<br/><br/><br/>munshi<span style='color:#f49f21;'>baba</span>.com";
                EmailToSomeone(body1, subject, email);
            }
        }

        return id1;


    }
    [WebMethod]
    public string ResetPasswordSend(string TokenID)
    {

        string id1 = "Not Found";
        string mSQL;
        string uservalue;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            mSQL = "Select fullname+'}'+cellno+'}'+email val1 from  users where PasswordToken='" + TokenID + "' and DATEDIFF(minute, passwordtokentime, getdate())<121";
            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            uservalue = (string)cmd.ExecuteScalar();
        }
        if (uservalue == null)
        {
            return id1;
        }
        string[] arg = uservalue.Split('}');

        using (var con = new SqlConnection(cs))
        {

            string password = GeneratePassword();
            // mSQL = "insert  into users(FullName,UserName,Password,CellNo, email,DateofCreation, ActiveStatus) output Inserted.UserID values ('" + myuser.FullName + "','" + myuser.UserName + "','" + myuser.Password + "','" + myuser.CellNo + "','" + myuser.email + "','" + Convert.ToDateTime(myuser.DateofCreation) + "','" + myuser.ActiveStatus + "')";
            mSQL = "update users set password='" + password + "', ResetPasswod=0,PasswordToken=newid(),PasswordTokenTime=getdate() output Inserted.PasswordToken where PasswordToken=@TokenID";
            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cmd.Parameters.AddWithValue("@TokenID", TokenID);

            // cmd.Parameters.AddWithValue("@Password", Password);
            id1 = cmd.ExecuteScalar().ToString();
            //id1 = id1 ?? "Not Found";
            if (id1.Length == 36)
            {
                string subject = "Change Password Request";
                string body1 = "Dear " + arg[0] + "<br/>" + "You, or someone on your behalf, has requested to issue a new password to your email address, that we have in our record.<br/> This information is given below;";
                body1 = body1 + "<br/><br/>Your new password is: " + password;
                body1 = body1 + "<br/><br/>This request was initiated by the member. <br/><br/> Please login through this link <br/> ";
                body1 = body1 + "<br/>  <a href='http://Munshibaba.com'> Click Here to login </a> <br/>";
                body1 = body1 + "<br/><br/>You are advised to change the password after loging in with the system generated password.";
                //body1 = body1 + " Note: If you did not initiate this request, please discard this message, and do not click on the link above (because that will generate a new password for your account).";
                body1 = body1 + "<br/><br/><br/><br/>Regards,<br/><br/><br/><br/>munshi<span style='color:#f49f21;'>baba</span>.com";
                EmailToSomeone(body1, subject, arg[2]);
            }
        }

        return id1;


    }
    public string GeneratePassword()
    {
        var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        var stringChars = new char[8];
        var random = new Random();

        for (int i = 0; i < stringChars.Length; i++)
        {
            stringChars[i] = chars[random.Next(chars.Length)];
        }

        var finalString = new String(stringChars);
        return finalString;
    }
    public string EmailToSomeone(string Body1, string Subject, string email)
    {
        string HostAddress = ConfigurationManager.AppSettings["Host"].ToString();
        string FromEmailId = ConfigurationManager.AppSettings["Email"].ToString();
        string Pass = ConfigurationManager.AppSettings["password"].ToString();

        System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
        string message = Body1;
        mailMessage.From = new MailAddress(FromEmailId);
        mailMessage.Subject = Subject;

        string body1 = "" + message + "<br/>";
        body1 = body1 + "<br/>";
        mailMessage.Body = body1;
        mailMessage.IsBodyHtml = true;
        mailMessage.To.Add(email);
        SmtpClient smtp = new SmtpClient();
        // SmtpClient smtp2 = new SmtpClient();
        smtp.Host = HostAddress;
        smtp.EnableSsl = true;
        NetworkCredential NetworkCred = new NetworkCredential();
        NetworkCred.UserName = mailMessage.From.Address;
        NetworkCred.Password = Pass;

        smtp.UseDefaultCredentials = true;

        smtp.Credentials = NetworkCred;
        smtp.Port = 587;
        smtp.Send(mailMessage);
        return "Email Sent Successfully.";

    }

    [WebMethod]
    public string UpdateUsers2(string fullname, string username, string cell, string email, string dob, string active, string img, string CountryID, string UserID, string CurrentEmail, string CurrentCellNo, string Gender, string SearchField, string SearchData, string Level)
    {
        ////Request.Form["guid"];
        ////Request.Files["FileUpload"];
        var myuser = new UserData();
        //myuser.FullName = HttpContext.Current.Request.Params["FullName"].ToString();
        //myuser.UserName = HttpContext.Current.Request.Params["UserName"].ToString();
        //myuser.Password = HttpContext.Current.Request.Params["Password"].ToString();
        //myuser.CellNo = HttpContext.Current.Request.Params["Cell"].ToString();
        //myuser.email = HttpContext.Current.Request.Params["email"].ToString();
        //myuser.DateofCreation = HttpContext.Current.Request.Params["DOB"].ToString();
        //myuser.ActiveStatus = Convert.ToInt32(HttpContext.Current.Request.Params["Active"].ToString());
        //string file = HttpContext.Current.Request.Params["imgfile"].ToString();
        string id1 = "";
        if (!(CurrentCellNo == cell))
        {
            id1 = CheckMobile(cell);
        }
        if (id1 == "Not Found" || id1 == "")
        {
            myuser.FullName = fullname;
            myuser.UserName = username;
            //myuser.Password = password;
            myuser.CellNo = cell;
            myuser.email = email;
            myuser.DateofCreation = dob;
            myuser.ActiveStatus = Convert.ToInt32(active);
            string file = img;
            // BinaryReader file = new BinaryReader(convert.HttpContext.Current.Request.Params["imgfile"])

            //string saveFile = file.FileName;
            //string[] ext1 = saveFile.Split('.');
            //string ext = ext1[1];
            var dt = myuser.DateofCreation.Split('/');
            // myuser.DateofCreation = dt[2] + "-" + dt[1] + "-" + dt[0];
            string mSQL;
            var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            using (var con = new SqlConnection(cs))
            {

                // mSQL = "insert  into users(FullName,UserName,Password,CellNo, email,DateofCreation, ActiveStatus) output Inserted.UserID values ('" + myuser.FullName + "','" + myuser.UserName + "','" + myuser.Password + "','" + myuser.CellNo + "','" + myuser.email + "','" + Convert.ToDateTime(myuser.DateofCreation) + "','" + myuser.ActiveStatus + "')";
                mSQL = "update users set FullName=@FullName, CellNo=@CellNo, DateofCreation=@DateofCreation, ActiveStatus=@ActiveStatus,CountryID=@CountryID,Gender=@Gender,SearchField=@SearchField,SearchData=@SearchData,ChartofAccountLevel=@Level output Inserted.UserID where userid=@userid";
                SqlCommand cmd = new SqlCommand(mSQL, con);
                cmd.CommandTimeout = 0;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.Parameters.AddWithValue("@FullName", fullname);
                //cmd.Parameters.AddWithValue("@UserName", email);
                //cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@CellNo", cell);
                //cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@DateofCreation", dob);
                cmd.Parameters.AddWithValue("@ActiveStatus", active);
                cmd.Parameters.AddWithValue("@CountryID", CountryID);
                cmd.Parameters.AddWithValue("@Gender", Gender);
                cmd.Parameters.AddWithValue("@SearchField", SearchField);
                cmd.Parameters.AddWithValue("@SearchData", SearchData);
                cmd.Parameters.AddWithValue("@Level", Level);





                id1 = cmd.ExecuteScalar().ToString();
                if (file != "")
                {
                    string[] str1 = file.Split(',');
                    File.WriteAllBytes(Server.MapPath("/UserPic/") + id1 + ".jpg", Convert.FromBase64String(str1[1]));
                }

                mSQL = "Update AccountSharing set UserID='" + id1 + "', ActiveStatus='" + myuser.ActiveStatus.ToString() + "' where Email='" + myuser.email + "' or CellNo='" + myuser.CellNo + "'";
                cmd = new SqlCommand(mSQL, con);
                cmd.ExecuteNonQuery();

                //cmd = new SqlCommand();
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.CommandText = "GenerateNewUserAccount";
                //cmd.Connection = con;
                //cmd.Parameters.AddWithValue("@userID", id1);
                //cmd.Parameters.AddWithValue("@Business", "CA405627-9696-4FD0-A4B2-5CC070EEFE92");

                //cmd.ExecuteNonQuery();

                //file.SaveAs(Server.MapPath("/UserPic/" + id1 + "."+ ext));
                //return cmd.ExecuteScalar().ToString();
            }
        }

        return id1;


    }


    [WebMethod]
    public string sp_SearchExisitingSharedUser(string SenderUserID, string CellNo, string Email, string Permission)
    {
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        string msg = "Not Found";
        using (var con = new SqlConnection(cs))
        {
            //InvitationID,Descrption,InvitDate,TransactionID,FromUserID,ToUserID,InvitationStatus,Email,CellNo
            mSQL = "sp_SearchExisitingSharedUser";
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = mSQL;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@SenderUserID", SenderUserID);
            cmd.Parameters.AddWithValue("@CellNo", CellNo);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                msg = dr["msg"].ToString();
            }
            cmd.Dispose();
            dr.Close();
        }
        return msg;
    }

    [WebMethod]
    public string FirstSendInvitation(string UserName, string CellNo, string email, string Descrption, string InvitationStatus, string FromUser)
    {
        //var myuser = new UserData();
        //myuser.UserName = UserName;
        //myuser.Password = Password;
        //myuser.CellNo = CellNo;
        //myuser.email = email;
        //myuser.DateofCreation = (DateofCreation);
        //myuser.ActiveStatus = Convert.ToInt32(ActiveStatus);
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            //InvitationID,Descrption,InvitDate,TransactionID,FromUserID,ToUserID,InvitationStatus,Email,CellNo

            mSQL = "insert into userInvitation(UserName,CellNo, email,Descrption, InvitationStatus,FromUserID) values ('" + UserName + "','" + CellNo + "','" + email + "','" + Descrption + "','" + InvitationStatus + "','" + FromUser + "')";

            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return cmd.ExecuteNonQuery().ToString();

        }

    }























    [WebMethod]
    public string LoginValue(string UserName, string Password)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            mSQL = "select * from users where (username=@username or email=@username or cellno=@username) and password=@password";
            SqlDataAdapter sda = new SqlDataAdapter(mSQL, con);
            sda.SelectCommand.Parameters.AddWithValue("@username", UserName);
            sda.SelectCommand.Parameters.AddWithValue("@password", Password);
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
                usr.ActiveStatus = Convert.ToInt16(dt.Rows[i]["ActiveStatus"]);
                usr.UserTitle = dt.Rows[i]["FullName"].ToString();
                usr.ChartLevel = dt.Rows[i]["ChartofAccountLevel"].ToString();
                usr.WelcomeAlert = dt.Rows[i]["WelcomeAlert"].ToString();
                usr.Bandwidth = dt.Rows[i]["Bandwidth"].ToString();



            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(usr);
            return myData;

        }

    }

    [WebMethod]
    public string getUserInfo(string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            mSQL = "SELECT u.*,c.name CountryName,c.alpha2code,CONVERT(char(10), DateofCreation,126) DateOfBirth  FROM [Users] u inner join CountryCodesX c on u.countryid= c.countryID where userid=@userid";
            SqlDataAdapter sda = new SqlDataAdapter(mSQL, con);
            sda.SelectCommand.Parameters.AddWithValue("@userid", UserID);

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


            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(usr);
            return myData;

        }

    }

    [WebMethod]
    public string getAccountSharingStatus(string SharedID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "getAccountSharingStatus";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@sharedid", SharedID);
            sda.SelectCommand = cmd;





            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var expcat = new List<AccountSharingStatus>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new AccountSharingStatus
                {
                    Accounts = dt.Rows[i]["Accounts"].ToString(),
                    NotiStatus = dt.Rows[i]["NotiStatus"].ToString(),
                    Receiver = dt.Rows[i]["Receiver"].ToString(),
                    Reseveruserid = dt.Rows[i]["Reseveruserid"].ToString(),
                    sender = dt.Rows[i]["sender"].ToString()
                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }



    [WebMethod]
    public string UpdateAccountSharingStatus(string SharedID, string Status)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "Update AccountSharingDetail set NotiStatus='" + Status + "',readstatus=0 where SharedDetailID=@sharedid";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@sharedid", SharedID);





            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();




            return option.ToString();

        }

    }

    [WebMethod]
    public string SendEmailShareAccount(string UserName, string CellNo, string Email, string AccountID, string AccountName, string Permission, string EmailOption, string URL, string SenderName, string CountryID, string SenderID)
    {
        try
        {
            //
            /// Please check already a user then get user id
            string mSQL;
            string exe1;
            var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
            string Subj = "Welcome to munshibaba.com; Financial & Management Assistant";
            string Body1 = "Dear <strong>" + UserName + ",</strong> <br/><br/>";
            Body1 = Body1 + "You are invited by <strong> " + SenderName + " </strong> to down load the most useful, trusted and secure accounting and management software, munshi<span style='color:#f49f21;'>baba</span>.com<br/><br/>";
            Body1 = Body1 + "<br/>munshi<span style='color:#f49f21;'>baba</span>.com  is all about organizing your financial matters. It promises to bring about a discipline in your financial affairs. Please do facilitate yourself through this tool, you will never regret it.<br/>";






            if (EmailOption == "Reminder")
            {
                Body1 = "<span style='color:orange;font-size:17px;'>Still awaiting your response.</span> <br/><br/>" + Body1;
                using (var con = new SqlConnection(cs))
                {
                    mSQL = "Select SharedID from  AccountSharing where CellNo='" + CellNo + "' or Email='" + Email + "'";
                    SqlCommand cmd = new SqlCommand(mSQL, con);
                    cmd.CommandTimeout = 0;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    exe1 = cmd.ExecuteScalar().ToString();

                    //InvitationID,Descrption,InvitDate,TransactionID,FromUserID,ToUserID,InvitationStatus,Email,CellNo

                    mSQL = "Update AccountSharing set notistatus=0, DateofCreation=getdate(),Senderid='" + SenderID + "' where SharedID= '" + exe1 + "'";
                    SqlCommand cmd1 = new SqlCommand(mSQL, con);
                    cmd1.CommandTimeout = 0;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd1.ExecuteNonQuery().ToString();



                }
            }
            else
            {

                using (var con = new SqlConnection(cs))
                {
                    //InvitationID,Descrption,InvitDate,TransactionID,FromUserID,ToUserID,InvitationStatus,Email,CellNo
                    //Subj = "Account sharing activation message from munshibaba.com";
                    //Body1 = "Dear <strong>" + UserName + ",</strong> <br/><br/>";
                    //Body1 = Body1 + "<strong> " + SenderName + " </strong> has invited you to share his account / accounts. Name of account is mentioned below. Kindly click at the account name to activate the sharing. <br/><br/>";
                    //Body1 = Body1 + "<br/>munshibaba.com  is all about organizing your financial matters. It promises to bring about a discipline in your financial affairs. Please do facilitate yourself through this tool, you will never regret it.<br/>";

                    mSQL = "insert into AccountSharing(AccountID,UserID,UserAccountID,CellNo,Email,ActiveStatus,Permission,UserName,CountryID,SenderID) output Inserted.SharedID values ('" + AccountID + "',null,null,'" + CellNo + "','" + Email + "','" + "1" + "','" + Permission + "','" + UserName + "','" + CountryID + "','" + SenderID + "')";

                    SqlCommand cmd = new SqlCommand(mSQL, con);
                    cmd.CommandTimeout = 0;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    exe1 = cmd.ExecuteScalar().ToString();

                }
            }
            var filetoconnect = "index3.html";
            if (!AccountID.Contains("000000"))
            {
                using (var con = new SqlConnection(cs))
                {
                    mSQL = "insert into AccountSharingDetail(SharedID,AccountID,Permission,ActiveStatus,readstatus)  values ('" + exe1 + "','" + AccountID + "','" + Permission + "','1',0)";
                    SqlCommand cmd = new SqlCommand(mSQL, con);
                    cmd.CommandTimeout = 0;
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    cmd.ExecuteNonQuery();
                }
                filetoconnect = "invitation-share.html";
            }
            if (exe1.Length == 36)
            {



                Body1 = Body1 + "<br/>You are most welcome as a new member of munshi<span style='color:#f49f21;'>baba</span>.com<br/>";
                Body1 = Body1 + "<br/>Just <a href='http://munshibaba.com/" + filetoconnect + "?id1'>click on this link </a> and start experiencing convenience";
                Body1 = Body1 + "<br/><br/><br/><br/>Regards,<br/><br/><br/>munshi<span style='color:#f49f21;'>baba</span>.com";
                //Body1 = Body1 + "<div > <a href='" + URL + "User.html?id1'>Accept</a>   ";
                //Body1 = Body1 + "<div > <a href='" + URL + "Reject.html?id2'>Reject</a> ";
                //Body1 = Body1 + "</div>";
                string HostAddress = ConfigurationManager.AppSettings["Host"].ToString();
                string FromEmailId = ConfigurationManager.AppSettings["Email"].ToString();
                string Pass = ConfigurationManager.AppSettings["password"].ToString();

                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                string message = Body1;
                mailMessage.From = new MailAddress(FromEmailId);
                mailMessage.Subject = Subj;
                message = message.Replace("id1", "id=X" + exe1 + "/#box-5");
                message = message.Replace("id2", "id=R" + exe1 + "/#box-5");
                string body1 = "" + message + "<br/>";
                body1 = body1 + "<br/>";
                mailMessage.Body = body1;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(Email);
                SmtpClient smtp = new SmtpClient();
                // SmtpClient smtp2 = new SmtpClient();
                smtp.Host = HostAddress;
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = mailMessage.From.Address;
                NetworkCred.Password = Pass;

                smtp.UseDefaultCredentials = true;

                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
                return "Email Sent Successfully.";
            }
            else
            {
                return "Some Issue in Sharing";
            }
            // 
        }
        catch (Exception ex)
        {
            return "Error Occurred. Please Try Again.";
        }
    }



    [WebMethod]
    public string SendEmailShareAccountMulti(string UserID, string UserIDShared, string ids, string URL, string SenderName)
    {
        try
        {
            //
            string mSQL;
            string exe1;
            string exe2;
            var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;





            //Body1 = "Reminder From:" + UserName + "<br/> Waiting for your Response <br/>" + Body1;
            using (var con = new SqlConnection(cs))
            {
                mSQL = "Select fullname+'}'+cellno+'}'+email val1 from  users where userid='" + UserIDShared + "' ";
                SqlCommand cmd = new SqlCommand(mSQL, con);
                cmd.CommandTimeout = 0;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                exe1 = cmd.ExecuteScalar().ToString();
                SqlCommand cmd2 = new SqlCommand("Select   isnull((Select top 1 convert(nvarchar(50),isnull(UserID,'10000000-1000-0000-0000-000000000000'))+','+convert(nvarchar(50),isnull(SharedID,'10000000-1000-0000-0000-000000000000')) from Accountsharing where userid='" + UserIDShared + "') ,'*')", con);
                exe2 = cmd2.ExecuteScalar().ToString();
                con.Close();
            }

            string[] sharedArg = !exe2.Contains("*") ? exe2.Split(',') : "0,1".Split(',');
            string[] arg = exe1.Split('}');
            string Subj = "Account sharing activation message from munshibaba.com";

            //string Body1 = "Dear Mr. " + arg[0] + ", <br/>";

            //string Subj = "WelCome to Munshi Financial Assistant";
            string Body1 = "Dear <strong>" + arg[0] + ",</strong> <br/><br/>  <strong>" + SenderName + "</strong> has invited you to share his account / accounts. Name of account is mentioned below. Kindly click at the account name to activate the sharing. " + " <br/>";
            // Body1 = Body1 + "<br/>Following accounts are added to Shared Accounts List;<br/>";






            string[] id = ids.Split(',');
            string[] id2 = id[0].Split(':');
            string Accounts = "";
            using (var con = new SqlConnection(cs))
            {

                //InvitationID,Descrption,InvitDate,TransactionID,FromUserID,ToUserID,InvitationStatus,Email,CellNo
                mSQL = "insert into AccountSharing(AccountID,UserID,UserAccountID,CellNo,Email,ActiveStatus,Permission,UserName,SenderID) output Inserted.SharedID values ('" + id2[0] + "','" + UserIDShared + "',null,'" + arg[1] + "','" + arg[2] + "','" + "1" + "','" + "Readonly" + "','" + arg[0] + "','" + UserID + "')";

                SqlTransaction tran;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    try
                    {
                        if (sharedArg[0].ToUpper() == UserIDShared.ToUpper())
                        {
                            exe1 = sharedArg[1];
                            SqlCommand cmd5 = new SqlCommand("Update AccountSharing set notistatus='0', DateofCreation=getdate(),SenderID='" + UserID + "' where sharedid='" + exe1 + "'", con, tran);
                            cmd5.CommandTimeout = 0;
                            cmd5.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand cmd = new SqlCommand(mSQL, con, tran);
                            cmd.CommandTimeout = 0;
                            exe1 = cmd.ExecuteScalar().ToString();
                        }
                        for (int i = 0; i < id.Length - 1; i++)
                        {
                            string[] aid = id[i].Split(':');
                            mSQL = "insert into AccountSharingDetail(SharedID,AccountID,Permission,ActiveStatus,Transferable,readstatus)  values ('" + exe1 + "','" + aid[0] + "','" + aid[1] + "','1','" + aid[2] + "',0)";
                            SqlCommand cmd2 = new SqlCommand(mSQL, con, tran);
                            cmd2.ExecuteNonQuery();

                        }


                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                    }
                    tran.Dispose();

                    //mSQL = "Select * from AccountTitle where accountid in ('" + (ids.Substring(0, ids.Length - 1)).Replace(",", "','") + "')";
                    mSQL = "Select a.accounttitle,d.SharedDetailid from AccountTitle a inner join accountsharingdetail d on a.accountid=d.accountid where sharedid='" + exe1 + "' and d.notistatus=0";
                    SqlCommand cmd3 = new SqlCommand(mSQL, con);
                    SqlDataReader rd;
                    rd = cmd3.ExecuteReader();
                    int a = 1;
                    while (rd.Read())
                    {//http://munshibaba.com/invitation-share.html?id=XE76D80D3-3FE0-4AFA-A881-743A860BE17C
                        Accounts = Accounts + "<br/>" + a.ToString() + ". <a href='http://munshibaba.com/invitation-share.html?id=X" + rd["SharedDetailid"] + "'>Click Here to action for " + rd["AccountTitle"] + "</a>";
                        a = a + 1;
                    }
                    cmd3.Dispose();
                    rd.Close();

                }



            }

            if (exe1.Length == 36 && Accounts.Length > 2)
            {
                Body1 = Body1 + " ";
                Body1 = Body1 + "Following accounts are added to Shared Accounts List;<br>" + Accounts;

                //Body1 = Body1 + "<div > <a href='http://munshibaba.com/invitation-share.html?id1'>Click Here for Action</a>  ";
                ////Body1 = Body1 + "<div > <a href='http://munshibaba.com/Reject.html?id2'>Reject</a> ";
                //Body1 = Body1 + "</div>";
                string HostAddress = ConfigurationManager.AppSettings["Host"].ToString();
                string FromEmailId = ConfigurationManager.AppSettings["Email"].ToString();
                string Pass = ConfigurationManager.AppSettings["password"].ToString();

                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                string message = Body1;
                mailMessage.From = new MailAddress(FromEmailId);
                mailMessage.Subject = Subj;
                //message = message.Replace("id1", "id=X" + exe1);
                // message = message.Replace("id2", "id=R" + exe1);
                string body1 = "" + message + "<br/>";
                body1 = body1 + "<br/><br/><br/><br/>Regards,<br/><br/><br/>munshi<span style='color:#f49f21;'>baba</span>.com";
                mailMessage.Body = body1;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(arg[2]);
                SmtpClient smtp = new SmtpClient();
                // SmtpClient smtp2 = new SmtpClient();
                smtp.Host = HostAddress;
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = mailMessage.From.Address;
                NetworkCred.Password = Pass;

                smtp.UseDefaultCredentials = true;

                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
                return arg[0];
            }
            else
            {
                return "Technical issue while sharing account";
            }
            // 
        }
        catch (Exception ex)
        {
            return "Technical issue while sharing account. Please try again" + ex.Message;
        }
    }

    [WebMethod]
    public string SendEmailShareAccountMulti_Remove(string UserID, string UserIDShared, string ids, string URL, string SenderName)
    {
        try
        {
            //
            string mSQL;
            string exe1;
            string exe2;
            var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

            //Body1 = "Reminder From:" + UserName + "<br/> Waiting for your Response <br/>" + Body1;
            using (var con = new SqlConnection(cs))
            {
                mSQL = "Select fullname+'}'+cellno+'}'+email val1 from  users where userid='" + UserIDShared + "' ";
                SqlCommand cmd = new SqlCommand(mSQL, con);
                cmd.CommandTimeout = 0;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }

                exe1 = cmd.ExecuteScalar().ToString();
                SqlCommand cmd2 = new SqlCommand("Select convert(nvarchar(50),isnull(UserID,'10000000-1000-0000-0000-000000000000'))+','+convert(nvarchar(50),isnull(SharedID,'10000000-1000-0000-0000-000000000000')) from Accountsharing where userid='" + UserIDShared + "' ", con);
                exe2 = cmd2.ExecuteScalar().ToString();
                con.Close();
            }

            string[] sharedArg = !exe2.Contains("0000000") ? exe2.Split(',') : "0,1".Split(',');
            string[] arg = exe1.Split('}');
            string Subj = "Shared account de activation message from munshibaba.com";

            string Body1 = "Dear Mr. " + arg[0] + ", <br/>";
            string[] id = ids.Split(',');
            string Accounts = "";
            using (var con = new SqlConnection(cs))
            {
                //InvitationID,Descrption,InvitDate,TransactionID,FromUserID,ToUserID,InvitationStatus,Email,CellNo
                //mSQL = "insert into AccountSharing(AccountID,UserID,UserAccountID,CellNo,Email,ActiveStatus,Permission,UserName) output Inserted.SharedID values ('" + id[0] + "',null,null,'" + arg[1] + "','" + arg[2] + "','" + "1" + "','" + "Readonly" + "','" + arg[0] + "')";

                SqlTransaction tran;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                    tran = con.BeginTransaction();
                    try
                    {
                        if (sharedArg[0].ToUpper() == UserIDShared.ToUpper())
                        {
                            exe1 = sharedArg[1];
                        }
                        else
                        {
                            //SqlCommand cmd = new SqlCommand(mSQL, con, tran);
                            //cmd.CommandTimeout = 0;
                            //exe1 = cmd.ExecuteScalar().ToString();
                        }
                        for (int i = 0; i < id.Length - 1; i++)
                        {
                            mSQL = "Update AccountSharingDetail set ActiveStatus=0,readstatus=0 where SharedID='" + exe1 + "' and AccountID='" + id[i] + "'";
                            SqlCommand cmd2 = new SqlCommand(mSQL, con, tran);
                            cmd2.ExecuteNonQuery();
                        }


                        tran.Commit();
                    }
                    catch (Exception ex)
                    {
                        tran.Rollback();
                    }
                    tran.Dispose();
                    mSQL = "Select * from AccountTitle where accountid in ('" + (ids.Substring(0, ids.Length - 1)).Replace(",", "','") + "')";
                    SqlCommand cmd3 = new SqlCommand(mSQL, con);
                    SqlDataReader rd;
                    rd = cmd3.ExecuteReader();
                    while (rd.Read())
                    {
                        Accounts = Accounts + rd["AccountTitle"] + ", ";
                    }
                    cmd3.Dispose();
                    rd.Close();

                }



            }

            if (exe1.Length == 36 && Accounts.Length > 2)
            {
                // Body1 = Body1 + "This is to inform you that,  <Sender>  has de activated sharing of following account with you.";
                Body1 = Body1 + "This is to inform you that,  " + SenderName + "  has de activated sharing of following account with you.<br>" + Accounts;
                Body1 = Body1 + "Following accounts are de activated  from your Shared Accouts List by " + SenderName + "";
                //Body1 = Body1 + "<div > <a href='htttp://munshibaba.com/User.html?id1'>Accept</a>   ";
                //Body1 = Body1 + "<div > <a href='htttp://munshibaba.com/Reject.html?id2'>Reject</a> ";
                //Body1 = Body1 + "</div>";
                string HostAddress = ConfigurationManager.AppSettings["Host"].ToString();
                string FromEmailId = ConfigurationManager.AppSettings["Email"].ToString();
                string Pass = ConfigurationManager.AppSettings["password"].ToString();

                System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();
                string message = Body1;
                mailMessage.From = new MailAddress(FromEmailId);
                mailMessage.Subject = Subj;
                message = message.Replace("id1", "id=X" + exe1);
                message = message.Replace("id2", "id=R" + exe1);
                string body1 = "" + message + "<br/>";
                body1 = body1 + "<br/><br/><br/><br/>Regards,<br/><br/><br/>munshi<span style='color:#f49f21;'>baba</span>.com";
                mailMessage.Body = body1;
                mailMessage.IsBodyHtml = true;
                mailMessage.To.Add(arg[2]);
                SmtpClient smtp = new SmtpClient();
                // SmtpClient smtp2 = new SmtpClient();
                smtp.Host = HostAddress;
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = mailMessage.From.Address;
                NetworkCred.Password = Pass;

                smtp.UseDefaultCredentials = true;

                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mailMessage);
                return "Email Sent Successfully.";
            }
            else
            {
                return "Some Issue in Sharing";
            }
            // 
        }
        catch (Exception ex)
        {
            return "Error Occurred. Please Try Again." + ex.Message;
        }
    }



    [WebMethod]
    public string SendEmail(string UserName, string CellNo, string Email, string subject, string message)
    {
        try
        {

            string HostAddress = ConfigurationManager.AppSettings["Host"].ToString();
            string FromEmailId = ConfigurationManager.AppSettings["Email"].ToString();
            string Pass = ConfigurationManager.AppSettings["password"].ToString();

            System.Net.Mail.MailMessage mailMessage = new System.Net.Mail.MailMessage();

            mailMessage.From = new MailAddress(FromEmailId);
            mailMessage.Subject = subject;

            string body1 = "" + message + "<br/>";
            //body1 = body1 + "<br/>";
            body1 = body1 + "<br/><br/><br/><br/>Regards,<br/><br/><br/>munshi<span style='color:#f49f21;'>baba</span>.com";
            mailMessage.Body = body1;
            mailMessage.IsBodyHtml = true;
            mailMessage.To.Add(Email);
            SmtpClient smtp = new SmtpClient();
            // SmtpClient smtp2 = new SmtpClient();
            smtp.Host = HostAddress;
            smtp.EnableSsl = true;
            NetworkCredential NetworkCred = new NetworkCredential();
            NetworkCred.UserName = mailMessage.From.Address;
            NetworkCred.Password = Pass;

            smtp.UseDefaultCredentials = true;

            smtp.Credentials = NetworkCred;
            smtp.Port = 587;
            smtp.Send(mailMessage);


            return "Email Sent Successfully."; // 
        }
        catch (Exception ex)
        {
            return "Error Occurred. Please Try Again.";
        }
    }


    public class SharedAccountData
    {
        //UserName, Password, CellNo, email, DateofCreation, ActiveStatus
        public string AccountID { get; set; }
        public string AccountTitle { get; set; }
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string UserAccountID { get; set; }
        public string UserAccountName { get; set; }
        public string Status { get; set; }
        public string CellNo { get; set; }


    }

    //[WebMethod]
    //public string CheckSharedAccount(string AccountID)
    //{

    //    string mSQL;
    //    var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
    //    using (var con = new SqlConnection(cs))
    //    {
    //        mSQL = "sp_CheckSharedAccount";

    //        SqlCommand cmd = new SqlCommand(mSQL, con);
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Parameters.AddWithValue("@AccountID",AccountID);
    //        cmd.CommandTimeout = 0;
    //        if (con.State == ConnectionState.Closed)
    //        {
    //            con.Open();
    //        }

    //        SqlDataReader dr = cmd.ExecuteReader();
    //        DataTable dt = new DataTable();
    //        dt.Load(dr);
    //        var usr = new List<SharedAccountData>();
    //        for (int i = 0; i < dt.Rows.Count; i++)
    //        {
    //            var tmp = new SharedAccountData();
    //            tmp.AccountID = dt.Rows[i]["AccountID"].ToString();
    //            tmp.AccountTitle = dt.Rows[i]["AccountTitle"].ToString();
    //            tmp.UserID = dt.Rows[i]["Userid"].ToString();
    //            tmp.UserName = dt.Rows[i]["UserName"].ToString();
    //            tmp.Email = dt.Rows[i]["email"].ToString();
    //            tmp.UserAccountName = dt.Rows[i]["UserAccountName"].ToString();
    //            tmp.UserAccountID = dt.Rows[i]["UserAccountID"].ToString();
    //            tmp.CellNo = dt.Rows[i]["CellNo"].ToString();
    //            string status = "";
    //            if(dt.Rows[i]["ActiveStatus"].ToString()=="1")
    //            {
    //                status = "No Response";
    //            }
    //            if (dt.Rows[i]["ActiveStatus"].ToString() == "2")
    //            {
    //                status = "Active";
    //            }
    //            if (dt.Rows[i]["ActiveStatus"].ToString() == "3")
    //            {
    //                status = "Blocked by friend";
    //            }
    //            if (dt.Rows[i]["ActiveStatus"].ToString() == "3")
    //            {
    //                status = "Blocked by you";
    //            }
    //            tmp.Status= status;
    //            usr.Add(tmp);

    //        }
    //        string myData;
    //        var js = new JavaScriptSerializer();
    //        if (usr.Count >0)
    //        {
    //            myData = js.Serialize(usr);
    //        }
    //        else
    //        {
    //            var tmp = new SharedAccountData();

    //            tmp.AccountID = "Not Found";
    //            tmp.AccountTitle = "Not Found";
    //            tmp.UserID = "Not Found";
    //            tmp.UserName = "Not Found";
    //            tmp.Email = "Not Found";
    //            tmp.UserAccountName = "Not Found";
    //            tmp.UserAccountID = "Not Found";
    //            usr.Add(tmp);

    //        }
    //        myData = js.Serialize(usr);
    //        return myData;

    //    }

    //}
    [WebMethod]
    public string CheckSharedAccount(string AccountID)
    {

        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            mSQL = "sp_CheckSharedAccount2";

            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@AccountID", AccountID);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            var usr = new List<SharedAccountData>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var tmp = new SharedAccountData();
                tmp.AccountID = dt.Rows[i]["AccountID"].ToString();
                tmp.AccountTitle = dt.Rows[i]["AccountTitle"].ToString();
                tmp.UserID = dt.Rows[i]["Userid"].ToString();
                tmp.UserName = dt.Rows[i]["UserName"].ToString();
                tmp.Email = dt.Rows[i]["email"].ToString();
                tmp.UserAccountName = dt.Rows[i]["UserAccountName"].ToString();
                tmp.UserAccountID = dt.Rows[i]["UserAccountID"].ToString();
                tmp.CellNo = dt.Rows[i]["CellNo"].ToString();
                string status = "";
                if (dt.Rows[i]["ActiveStatus"].ToString() == "1")
                {
                    status = "No Response";
                }
                if (dt.Rows[i]["ActiveStatus"].ToString() == "2")
                {
                    status = "Active";
                }
                if (dt.Rows[i]["ActiveStatus"].ToString() == "3")
                {
                    status = "Blocked by friend";
                }
                if (dt.Rows[i]["ActiveStatus"].ToString() == "3")
                {
                    status = "Blocked by you";
                }
                tmp.Status = status;
                usr.Add(tmp);

            }
            string myData;
            var js = new JavaScriptSerializer();
            if (usr.Count > 0)
            {
                myData = js.Serialize(usr);
            }
            else
            {
                var tmp = new SharedAccountData();

                tmp.AccountID = "Not Found";
                tmp.AccountTitle = "Not Found";
                tmp.UserID = "Not Found";
                tmp.UserName = "Not Found";
                tmp.Email = "Not Found";
                tmp.UserAccountName = "Not Found";
                tmp.UserAccountID = "Not Found";
                usr.Add(tmp);

            }
            myData = js.Serialize(usr);
            return myData;

        }

    }
    [WebMethod]
    public string GetSharedAccountDetail(string ShareID)
    {

        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            mSQL = "Select *,'' AccountTitle,'' UserAccountName from [AccountSharing] where SharedID=@SharedID";

            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.AddWithValue("@SharedID", ShareID);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            SqlDataReader dr = cmd.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Load(dr);
            var usr = new List<SharedAccountData>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var tmp = new SharedAccountData();
                tmp.AccountID = dt.Rows[i]["AccountID"].ToString();
                tmp.AccountTitle = dt.Rows[i]["AccountTitle"].ToString();
                tmp.UserID = dt.Rows[i]["Userid"].ToString();
                tmp.UserName = dt.Rows[i]["UserName"].ToString();
                tmp.Email = dt.Rows[i]["email"].ToString();
                tmp.UserAccountName = dt.Rows[i]["UserAccountName"].ToString();
                tmp.UserAccountID = dt.Rows[i]["UserAccountID"].ToString();
                tmp.CellNo = dt.Rows[i]["CellNo"].ToString();
                string status = "";
                if (dt.Rows[i]["ActiveStatus"].ToString() == "1")
                {
                    status = "No Response";
                }
                if (dt.Rows[i]["ActiveStatus"].ToString() == "2")
                {
                    status = "Active";
                }
                if (dt.Rows[i]["ActiveStatus"].ToString() == "3")
                {
                    status = "Blocked by friend";
                }
                if (dt.Rows[i]["ActiveStatus"].ToString() == "3")
                {
                    status = "Blocked by you";
                }
                tmp.Status = status;
                usr.Add(tmp);

            }
            string myData;
            var js = new JavaScriptSerializer();
            if (usr.Count > 0)
            {
                myData = js.Serialize(usr);
            }
            else
            {
                var tmp = new SharedAccountData();

                tmp.AccountID = "Not Found";
                tmp.AccountTitle = "Not Found";
                tmp.UserID = "Not Found";
                tmp.UserName = "Not Found";
                tmp.Email = "Not Found";
                tmp.UserAccountName = "Not Found";
                tmp.UserAccountID = "Not Found";
                usr.Add(tmp);

            }
            myData = js.Serialize(usr);
            return myData;

        }

    }
    [WebMethod]
    public string SharingInsert(string UserName, string CellNo, string email, string Descrption, string InvitationStatus, string FromUser)
    {
        //var myuser = new UserData();
        //myuser.UserName = UserName;
        //myuser.Password = Password;
        //myuser.CellNo = CellNo;
        //myuser.email = email;
        //myuser.DateofCreation = (DateofCreation);
        //myuser.ActiveStatus = Convert.ToInt32(ActiveStatus);
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            //InvitationID,Descrption,InvitDate,TransactionID,FromUserID,ToUserID,InvitationStatus,Email,CellNo

            mSQL = "insert into userInvitation(UserName,CellNo, email,Descrption, InvitationStatus,FromUserID) values ('" + UserName + "','" + CellNo + "','" + email + "','" + Descrption + "','" + InvitationStatus + "','" + FromUser + "')";

            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return cmd.ExecuteNonQuery().ToString();

        }

    }



    public class Transaction
    {
        public string Tid { get; set; }
        public string AccId { get; set; }
        public string AccTitle { get; set; }
        public string PaymentAmt { get; set; }
        public string ReceiptAmt { get; set; }
        public string Icon { get; set; }
        public string TransType { get; set; }
        public string TotalAmount { get; set; }
        public string Color { get; set; }
        public string Total { get; set; }
        public string TodayPercent { get; set; }
        public string Balance { get; set; }
        public string TDate { get; set; }
        public string Narration { get; set; }
        public string Sharing { get; set; }
        public string Lid { get; set; }
        public string UserName { get; set; }
        public string Remarks { get; set; }
        public string FullName2 { get; set; }
        public string AccountTitle2 { get; set; }
        public string NotistatusD { get; set; }

    }
    [WebMethod]
    public string getSharedTransactionbyID(string UserID)
    {
        var accid = UserID;
        if (accid == "null")
            return "null";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "getSharedTransactionbyID_newforCheck";
            //string spName = "getSharedTransactionbyID";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@UserID", accid);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Transaction>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new Transaction
                {
                    TDate = Convert.ToDateTime(dt.Rows[i]["TDate"]).ToString("dd-MM-yyyy HH:mm:ss"),
                    Narration = dt.Rows[i]["Narration"].ToString(),
                    TransType = dt.Rows[i]["vouchertype"].ToString(),
                    AccTitle = dt.Rows[i]["AccountTitle"].ToString(),
                    TotalAmount = (Math.Abs(Convert.ToDouble(dt.Rows[i]["Amount"].ToString()))).ToString("##,###,##"),
                    //Total = Convert.ToDouble(dt.Rows[i]["Total"].ToString()).ToString("##,###,##"),
                    Sharing = dt.Rows[i]["Sharing"].ToString(),
                    Lid = dt.Rows[i]["lid"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }

    [WebMethod]
    public string getSharingNotification(string UserID, string Email)
    {
        var accid = UserID;
        if (accid == "null")
            return "null";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "getSharingNotification";
            //string spName = "getSharedTransactionbyID";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@UserID", accid);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Transaction>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new Transaction
                {
                    TDate = Convert.ToDateTime(dt.Rows[i]["TDate"]).ToString("dd-MM-yyyy HH:mm:ss"),
                    Narration = dt.Rows[i]["Narration"].ToString(),
                    TransType = dt.Rows[i]["vouchertype"].ToString(),
                    AccTitle = dt.Rows[i]["AccountTitle"].ToString(),
                    TotalAmount = "",
                    //Total = Convert.ToDouble(dt.Rows[i]["Total"].ToString()).ToString("##,###,##"),
                    Sharing = dt.Rows[i]["Sharing"].ToString(),
                    Lid = dt.Rows[i]["lid"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    FullName2 = dt.Rows[i]["FullName2"].ToString(),
                    AccountTitle2 = dt.Rows[i]["AccountTitle2"].ToString(),
                    NotistatusD = dt.Rows[i]["NotistatusD"].ToString(),
                    Remarks = "",

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }


    [WebMethod]
    public string ReadTranscation(string UserID, string LID, string status, string description)
    {
        string mSQL1 = "";
        string ret1 = "";
        var cs1 = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con1 = new SqlConnection(cs1))
        {

            {
                mSQL1 = "UpdateTransactionStatus";
            }
            string spName = mSQL1;

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = spName;
            cmd1.Parameters.AddWithValue("@Muserid", UserID);
            cmd1.Parameters.AddWithValue("@lid", LID);
            cmd1.Parameters.AddWithValue("@status", status);
            cmd1.Parameters.AddWithValue("@description", description);

            if (con1.State == ConnectionState.Closed)
            {
                con1.Open();
            }
            ret1 = cmd1.ExecuteNonQuery().ToString();

        }
        return ret1;
    }



    [WebMethod]
    public string UpdateTransferStatus(string TransID, string UserID)
    {
        string mSQL1 = "";
        string ret1 = "";
        var cs1 = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con1 = new SqlConnection(cs1))
        {
            {
                mSQL1 = "update userNotification set TransferStatus=1 where touserid=@userid and TransactionID=@TransID";
            }
            string spName = mSQL1;

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            cmd1.CommandType = CommandType.Text;
            cmd1.CommandText = spName;
            cmd1.Parameters.AddWithValue("@userid", UserID);
            cmd1.Parameters.AddWithValue("@TransID", TransID);

            if (con1.State == ConnectionState.Closed)
            {
                con1.Open();
            }
            ret1 = cmd1.ExecuteNonQuery().ToString();

        }
        return ret1;
    }
    [WebMethod]
    public string ReadNoti(string UserID, string SharedID, string Status)
    {
        string mSQL1 = "";
        string ret1 = "";
        var cs1 = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con1 = new SqlConnection(cs1))
        {
            {
                mSQL1 = "UpdateNotiFicationStatus";
            }
            string spName = mSQL1;

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = spName;
            cmd1.Parameters.AddWithValue("@userid", UserID);
            cmd1.Parameters.AddWithValue("@SharedID", SharedID);
            cmd1.Parameters.AddWithValue("@Status", SharedID);

            if (con1.State == ConnectionState.Closed)
            {
                con1.Open();
            }
            ret1 = cmd1.ExecuteNonQuery().ToString();

        }
        return ret1;
    }

    [WebMethod]
    public string ReadNoti_New(string UserID, string SharedID)
    {
        string mSQL1 = "";
        string ret1 = "";
        var cs1 = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con1 = new SqlConnection(cs1))
        {
            {
                mSQL1 = "UpdateNotiFicationStatus_New";
            }
            string spName = mSQL1;

            SqlCommand cmd1 = new SqlCommand();
            cmd1.Connection = con1;
            cmd1.CommandType = CommandType.StoredProcedure;
            cmd1.CommandText = spName;
            cmd1.Parameters.AddWithValue("@userid", UserID);
            cmd1.Parameters.AddWithValue("@SharedID", SharedID);


            if (con1.State == ConnectionState.Closed)
            {
                con1.Open();
            }
            ret1 = cmd1.ExecuteNonQuery().ToString();

        }
        return ret1;
    }



    [WebMethod]
    public string loadSearchedUsers(string Search, string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            //if (Type == "I")
            //{
            //    mSQL = "select CatID, category,color,icon from CatInc where userid='" + UserID + "' order by Category";

            //}
            //else
            {
                mSQL = "SearchforSharing";
            }
            string spName = mSQL;
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@Search", Search);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var Userd = new List<UserData>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var mUsers = new UserData
                {
                    UserID = dt.Rows[i]["Userid"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    email = dt.Rows[i]["CellNo"].ToString(),
                    CellNo = dt.Rows[i]["email"].ToString(),
                    SharedStatus = dt.Rows[i]["SharedStatus"].ToString(),
                    FullName = dt.Rows[i]["FullName"].ToString(),
                    SearchData = dt.Rows[i]["SearchData"].ToString(),
                    //Balance = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("##,###,##"),

                };
                Userd.Add(mUsers);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(Userd);
            return myData;


        }

    }


    [WebMethod]
    public string loadSearchedProfile(string Search, string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            //if (Type == "I")
            //{
            //    mSQL = "select CatID, category,color,icon from CatInc where userid='" + UserID + "' order by Category";

            //}
            //else
            {
                mSQL = "Select * from users where userid=@userid";
            }
            string spName = mSQL;
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var Userd = new List<UserData>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var mUsers = new UserData
                {
                    FullName = dt.Rows[i]["FullName"].ToString(),
                    UserID = dt.Rows[i]["Userid"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    email = dt.Rows[i]["CellNo"].ToString(),
                    CellNo = dt.Rows[i]["email"].ToString(),
                    ActiveStatus = Convert.ToInt16(dt.Rows[i]["ActiveStatus"].ToString()),
                    DateofCreation = dt.Rows[i]["DateofCreation"].ToString(),

                    //Balance = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("##,###,##"),

                };
                Userd.Add(mUsers);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(Userd);
            return myData;


        }
        //return "";

    }


    [WebMethod]
    public string ListofFriendsforSharing(string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            //if (Type == "I")
            //{
            //    mSQL = "select CatID, category,color,icon from CatInc where userid='" + UserID + "' order by Category";

            //}
            //else
            {
                mSQL = "ListofFriendsforSharing";
            }
            string spName = mSQL;
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);

            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var Userd = new List<UserData>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var mUsers = new UserData
                {
                    UserID = dt.Rows[i]["Userid"].ToString(),
                    UserName = dt.Rows[i]["UserName"].ToString(),
                    email = dt.Rows[i]["CellNo"].ToString(),
                    CellNo = dt.Rows[i]["email"].ToString(),
                    SharedStatus = dt.Rows[i]["SharedStatus"].ToString(),
                    FullName = dt.Rows[i]["FullName"].ToString(),
                    SearchData = dt.Rows[i]["SearchData"].ToString(),
                    //Balance = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("##,###,##"),

                };
                Userd.Add(mUsers);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(Userd);
            return myData;


        }

    }

    public class ShowAllAccountbyUserIDData
    {
        public string AccID { get; set; }
        public string Title { get; set; }
        public double Limit { get; set; }
        public int Status { get; set; }
        public string Cat { get; set; }
        public string SubCat { get; set; }
        public string CatID { get; set; }
        public string SubCatID { get; set; }
        public string Isshared { get; set; }
        public string Icon { get; set; }
        public string Color { get; set; }
        public string CatIcon { get; set; }
        public string CatColor { get; set; }
        public string Transferable { get; set; }
        public string Permission { get; set; }



    }
    [WebMethod]

    public string ShowAllAccountbyUserID(string UserID, string UserIDShared)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            var spName = "showAccountsByUserID_Sharing";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@UserIDShared", UserIDShared);

            sda.SelectCommand = cmd;


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<ShowAllAccountbyUserIDData>();
            for (int i = 0; i < dt.Rows.Count; i++)

            //  &#xf0a4
            {
                var myCat = new ShowAllAccountbyUserIDData
                {
                    AccID = dt.Rows[i]["accountId"].ToString(),
                    Title = "<i class='" + dt.Rows[i]["Icon"].ToString() + "' style='color:" + dt.Rows[i]["Color"].ToString() + ";'></i> " + dt.Rows[i]["AccountName"].ToString() + "",
                    Cat = "<i class='" + dt.Rows[i]["CatIcon"].ToString() + "' style='color:" + dt.Rows[i]["CatColor"].ToString() + ";'></i> " + dt.Rows[i]["Category"].ToString() + "",
                    SubCat = dt.Rows[i]["SubCategory"].ToString(),
                    SubCatID = dt.Rows[i]["SubCatID"].ToString(),
                    CatID = dt.Rows[i]["CatID"].ToString(),
                    Isshared = dt.Rows[i]["Isshared"].ToString(),
                    Transferable = dt.Rows[i]["Transferable"].ToString(),
                    Permission = dt.Rows[i]["Permission"].ToString(),
                    //Icon = dt.Rows[i]["Icon"].ToString(),
                    //Color = dt.Rows[i]["Color"].ToString(),
                    //CatIcon = dt.Rows[i]["CatIcon"].ToString(),
                    //CatColor = dt.Rows[i]["CatColor"].ToString(),
                    //  Type = dt.Rows[i][2].ToString(),
                    //  Limit = Convert.ToDouble( dt.Rows[i][3].ToString()),
                    //Balance = " &#xf0a4; " + "[" + (Convert.ToDouble(dt.Rows[i][6].ToString()) + Convert.ToDouble(dt.Rows[i][7].ToString())).ToString("###,####,##") + "]",

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }

    [WebMethod]

    public string ShowAllAccountbySubCatID(string UserID, string UserIDShared, string SubCatID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            var spName = "showAccountsByUserID_SharingSubCatID";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@UserIDShared", UserIDShared);
            cmd.Parameters.AddWithValue("@SubCatID", SubCatID);
            sda.SelectCommand = cmd;


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<ShowAllAccountbyUserIDData>();
            for (int i = 0; i < dt.Rows.Count; i++)

            //  &#xf0a4
            {
                var myCat = new ShowAllAccountbyUserIDData
                {
                    AccID = dt.Rows[i]["accountId"].ToString(),
                    Title = "<i class='" + dt.Rows[i]["Icon"].ToString() + "' style='color:" + dt.Rows[i]["Color"].ToString() + ";'></i> " + dt.Rows[i]["AccountName"].ToString() + "",
                    Cat = "<i class='" + dt.Rows[i]["CatIcon"].ToString() + "' style='color:" + dt.Rows[i]["CatColor"].ToString() + ";'></i> " + dt.Rows[i]["Category"].ToString() + "",
                    SubCat = dt.Rows[i]["SubCategory"].ToString(),
                    SubCatID = dt.Rows[i]["SubCatID"].ToString(),
                    CatID = dt.Rows[i]["CatID"].ToString(),
                    Isshared = dt.Rows[i]["Isshared"].ToString(),
                    Transferable = dt.Rows[i]["Transferable"].ToString(),
                    Permission = dt.Rows[i]["Permission"].ToString(),
                    Icon = dt.Rows[i]["Icon"].ToString(),
                    Color = dt.Rows[i]["Color"].ToString(),
                    //CatIcon = dt.Rows[i]["CatIcon"].ToString(),
                    //CatColor = dt.Rows[i]["CatColor"].ToString(),
                    //  Type = dt.Rows[i][2].ToString(),
                    //  Limit = Convert.ToDouble( dt.Rows[i][3].ToString()),
                    //Balance = " &#xf0a4; " + "[" + (Convert.ToDouble(dt.Rows[i][6].ToString()) + Convert.ToDouble(dt.Rows[i][7].ToString())).ToString("###,####,##") + "]",

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }
    [WebMethod]
    public string ShowAccountsByUserID_Sharing_OrderByAccountTitle(string UserID, string UserIDShared)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            var spName = "ShowAccountsByUserID_Sharing_OrderByAccountTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@UserIDShared", UserIDShared);

            sda.SelectCommand = cmd;


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<ShowAllAccountbyUserIDData>();
            for (int i = 0; i < dt.Rows.Count; i++)

            //  &#xf0a4
            {
                var myCat = new ShowAllAccountbyUserIDData
                {
                    AccID = dt.Rows[i]["accountId"].ToString(),
                    Title = "<i class='" + dt.Rows[i]["Icon"].ToString() + "' style='color:" + dt.Rows[i]["Color"].ToString() + ";'></i> " + dt.Rows[i]["AccountName"].ToString() + "",
                    Cat = "<i class='" + dt.Rows[i]["CatIcon"].ToString() + "' style='color:" + dt.Rows[i]["CatColor"].ToString() + ";'></i> " + dt.Rows[i]["Category"].ToString() + "",
                    SubCat = dt.Rows[i]["SubCategory"].ToString(),
                    SubCatID = dt.Rows[i]["SubCatID"].ToString(),
                    CatID = dt.Rows[i]["CatID"].ToString(),
                    Isshared = dt.Rows[i]["Isshared"].ToString(),
                    Transferable = dt.Rows[i]["Transferable"].ToString(),
                    Permission = dt.Rows[i]["Permission"].ToString(),
                    Icon = dt.Rows[i]["Icon"].ToString(),
                    Color = dt.Rows[i]["Color"].ToString(),
                    //CatIcon = dt.Rows[i]["CatIcon"].ToString(),
                    //CatColor = dt.Rows[i]["CatColor"].ToString(),
                    //  Type = dt.Rows[i][2].ToString(),
                    //  Limit = Convert.ToDouble( dt.Rows[i][3].ToString()),
                    //Balance = " &#xf0a4; " + "[" + (Convert.ToDouble(dt.Rows[i][6].ToString()) + Convert.ToDouble(dt.Rows[i][7].ToString())).ToString("###,####,##") + "]",

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }


    public string AccountSharedwithUserName(string AccountID, string UserID)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            var spName = "showAccountsByUserID_Sharing";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@AccountID", AccountID);

            sda.SelectCommand = cmd;


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<ShowAllAccountbyUserIDData>();
            for (int i = 0; i < dt.Rows.Count; i++)

            //  &#xf0a4
            {
                var myCat = new ShowAllAccountbyUserIDData
                {
                    AccID = dt.Rows[i]["accountId"].ToString(),
                    Title = "<i class='" + dt.Rows[i]["Icon"].ToString() + "' style='color:" + dt.Rows[i]["Color"].ToString() + ";'></i> " + dt.Rows[i]["AccountName"].ToString() + "",
                    Cat = "<i class='" + dt.Rows[i]["CatIcon"].ToString() + "' style='color:" + dt.Rows[i]["CatColor"].ToString() + ";'></i> " + dt.Rows[i]["Category"].ToString() + "",
                    SubCat = dt.Rows[i]["SubCategory"].ToString(),
                    SubCatID = dt.Rows[i]["SubCatID"].ToString(),
                    CatID = dt.Rows[i]["CatID"].ToString(),
                    Isshared = dt.Rows[i]["Isshared"].ToString(),
                    Transferable = dt.Rows[i]["Transferable"].ToString(),
                    Permission = dt.Rows[i]["Permission"].ToString(),
                    //Icon = dt.Rows[i]["Icon"].ToString(),
                    //Color = dt.Rows[i]["Color"].ToString(),
                    //CatIcon = dt.Rows[i]["CatIcon"].ToString(),
                    //CatColor = dt.Rows[i]["CatColor"].ToString(),
                    //  Type = dt.Rows[i][2].ToString(),
                    //  Limit = Convert.ToDouble( dt.Rows[i][3].ToString()),
                    //Balance = " &#xf0a4; " + "[" + (Convert.ToDouble(dt.Rows[i][6].ToString()) + Convert.ToDouble(dt.Rows[i][7].ToString())).ToString("###,####,##") + "]",

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }


    /// <summary>
    /// NEW WORK
    /// </summary>
    /// <param name></param>
    /// <returns></returns>

    [WebMethod]
    public int UpdateWelcomeAlert(string UserID)
    {
         

        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {



                mSQL = "update Users set WelcomeAlert=0  where UserID='" + UserID + "'";


                SqlCommand cmd = new SqlCommand(mSQL, con);

                cmd.Parameters.AddWithValue("@UserID", UserID);
                cmd.CommandTimeout = 0;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                return cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                return 0;

            }

        }

    }

    public class DataUsage
    {
         
        public string DataBytes { get; set; }
        public string AttachmentBytes { get; set; }
        public string Invites { get; set; }
        public string Accepted { get; set; }
        public string ActiveUsers { get; set; }
        public string Deactiveusers { get; set; }

    }

        [WebMethod]
    public string LoadDataUsageDetail(string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {




            string spName;

            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LoadDataUsageDetail";
            cmd.Parameters.AddWithValue("@UserID", UserID);
      

            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var varDataUsage = new List<DataUsage>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var varDataUsageList = new DataUsage
                {

                    DataBytes = dt.Rows[i]["DataBytes"].ToString(),
                    AttachmentBytes = dt.Rows[i]["AttachmentBytes"].ToString(),

                };

                varDataUsage.Add(varDataUsageList);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(varDataUsage);
            return myData;

        }

    }


    [WebMethod]
    public string LoadDataUsageDetailByFilter(string UserID, string StartDate, string EndDate)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {




            string spName;

            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LoadDataUsageDetailByFilter";
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
            cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");

            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var varDataUsage = new List<DataUsage>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var varDataUsageList = new DataUsage
                {

                    DataBytes = dt.Rows[i]["DataBytes"].ToString(),
                    AttachmentBytes = dt.Rows[i]["AttachmentBytes"].ToString(),

                };

                varDataUsage.Add(varDataUsageList);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(varDataUsage);
            return myData;

        }

    }



    [WebMethod]
    public string LoadReferralDetail(string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName;

            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LoadReferralDetail";
            cmd.Parameters.AddWithValue("@UserID", UserID);


            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var varDataUsage = new List<DataUsage>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var varDataUsageList = new DataUsage
                {

                    Invites = dt.Rows[i]["InviteSent"].ToString(),
                    Accepted = dt.Rows[i]["InviteAccepted"].ToString(),
                    ActiveUsers = dt.Rows[i]["ActiveUsers"].ToString(),
                    Deactiveusers = dt.Rows[i]["Deactiveusers"].ToString(),

                };

                varDataUsage.Add(varDataUsageList);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(varDataUsage);
            return myData;

        }

    }

}
