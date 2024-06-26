using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
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
/// Summary description for Settings
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Settings : System.Web.Services.WebService
{

    public Settings()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    public class CountryInfo
    {
        public string CountryID { get; set; }
        public string name{ get; set; }
        public string alpha2Code{ get; set; }
        public string alpha3Code { get; set; }
        
        public string topLevelDomain0{ get; set; }
        public string capital{ get; set; }
        public string region{ get; set; }
        public string subregion{ get; set; }
        public string latlng0{ get; set; }
        public string latlng1{ get; set; }
        public string timezones0{ get; set; }
        public string nativename{ get; set; }
        public string numericCode{ get; set; }
        public string currencies0code{ get; set; }
        public string currencies0name{ get; set; }
        public string currencies0symbol{ get; set; }
        public string languages0iso639_1{ get; set; }
        public string languages0iso639_2{ get; set; }
        public string languages0name{ get; set; }
        public string ForexID { get; set; }
        public string callingCodes0 { get; set; }


    }
    public class UserSettings
    {
            

        public string UserID { get; set; }
        public string SettingID { get; set; }
        public string DateofCreation { get; set; }
        public string ActiveStatus { get; set; }
        public string BaseCountry { get; set; }
        public string CountryName { get; set; }
        public string CallingCode { get; set; }
        public string CurrenyName { get; set; }
        public string CurrencySymbol { get; set; }
        public string CurrencyCode { get; set; }
        public string CurrencyFormat { get; set; }
        public string alpha2Code { get; set; }
        public string timeformat { get; set; }
        public string dateFormat1 { get; set; }
        public string Language { get; set; }
        public string Help { get; set; }


    }


    [WebMethod]
    public string LoadCountry()
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            
                mSQL = "" ;
            
            string spName = "LoadCountry";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            //cmd.Parameters.AddWithValue("@userid", UserID);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var MCountry = new List<CountryInfo>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var TCountry = new CountryInfo
                {
                    CountryID= dt.Rows[i]["CountryID"].ToString(),
                    alpha2Code = dt.Rows[i]["alpha2Code"].ToString(),
                    alpha3Code= dt.Rows[i]["alpha3Code"].ToString(),
                    capital = dt.Rows[i]["capital"].ToString(),
                    currencies0code = dt.Rows[i]["currencies0code"].ToString(),
                    currencies0name = dt.Rows[i]["currencies0name"].ToString(),
                    currencies0symbol = dt.Rows[i]["currencies0symbol"].ToString(),
                    ForexID = dt.Rows[i]["ForexID"].ToString(),
                    languages0iso639_1 = dt.Rows[i]["languages0iso639_1"].ToString(),
                    languages0iso639_2 = dt.Rows[i]["languages0iso639_2"].ToString(),
                    languages0name = dt.Rows[i]["languages0name"].ToString(),
                    latlng0 = dt.Rows[i]["latlng0"].ToString(),
                    latlng1 = dt.Rows[i]["latlng1"].ToString(),
                    name = dt.Rows[i]["name"].ToString(),
                    nativename = dt.Rows[i]["nativename"].ToString(),
                    numericCode = dt.Rows[i]["numericCode"].ToString(),
                    region = dt.Rows[i]["region"].ToString(),
                    subregion = dt.Rows[i]["subregion"].ToString(),
                    timezones0 = dt.Rows[i]["timezones0"].ToString(),
                    topLevelDomain0 = dt.Rows[i]["topLevelDomain0"].ToString(),
                    callingCodes0 = dt.Rows[i]["callingCodes0"].ToString(),


                };
                MCountry.Add(TCountry);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(MCountry);
            return myData;

        }

    }

    [WebMethod]
    public string LoadUserSettings(string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            mSQL = "";

            string spName = "LoadUserSettings";
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
            var MUserSettings = new List<UserSettings>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var TUserSettings = new UserSettings
                {
                    ActiveStatus = dt.Rows[i]["ActiveStatus"].ToString(),
                    BaseCountry = dt.Rows[i]["BaseCountry"].ToString(),
                    CallingCode = dt.Rows[i]["CallingCode"].ToString(),
                    CountryName = dt.Rows[i]["CountryName"].ToString(),
                    CurrencyCode = dt.Rows[i]["CurrencyCode"].ToString(),
                    CurrencyFormat = dt.Rows[i]["CurrencyFormat"].ToString(),
                    CurrencySymbol = dt.Rows[i]["CurrencySymbol"].ToString(),
                    CurrenyName = dt.Rows[i]["CurrenyName"].ToString(),
                    DateofCreation = dt.Rows[i]["DateofCreation"].ToString(),
                    SettingID = dt.Rows[i]["SettingID"].ToString(),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    alpha2Code = dt.Rows[i]["alpha2Code"].ToString(),
                    dateFormat1= dt.Rows[i]["dateFormat1"].ToString(),
                    timeformat = dt.Rows[i]["timeformat"].ToString(),
                    Language = dt.Rows[i]["Language"].ToString(),
                    Help= dt.Rows[i]["Help"].ToString(),

                };
                MUserSettings.Add(TUserSettings);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(MUserSettings);
            return myData;

        }

    }

    [WebMethod]
    public string SaveSettings
  (string ActiveStatus,

   string BaseCountry,
   string CallingCode,
   string CountryName,
   string CurrencyCode,
   string CurrencyFormat,
   string CurrencySymbol,
   string CurrenyName,
   string DateofCreation,
   string SettingID,
   string UserID,
   string alpha2Code,
   string dateFormat1,
   string timeformat,
   string Language,
   string Help)
    {
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string mSQL1 = @"update usersettings set  
 
                    
                    BaseCountry=@BaseCountry
                    ,CountryName=@CountryName
                    ,CallingCode=@CallingCode
                    ,CurrenyName=@CurrenyName
                    ,CurrencySymbol=@CurrencySymbol
                    ,CurrencyCode=@CurrencyCode
                    ,CurrencyFormat=@CurrencyFormat
                    ,alpha2Code=@alpha2Code
                    ,timeformat=@timeformat
                    ,dateFormat1=@dateFormat1
                    ,Language=@Language
                    ,Help=@Help
                    where SettingID  =@SettingID  
";


            SqlCommand cmd = new SqlCommand(mSQL1, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }


            cmd.Parameters.AddWithValue("@SettingID", SettingID);

            cmd.Parameters.AddWithValue("@BaseCountry", BaseCountry);
            cmd.Parameters.AddWithValue("@CountryName", CountryName);
            cmd.Parameters.AddWithValue("@CallingCode", CallingCode);
            cmd.Parameters.AddWithValue("@CurrenyName", CurrenyName);
            cmd.Parameters.AddWithValue("@CurrencySymbol", CurrencySymbol);
            cmd.Parameters.AddWithValue("@CurrencyCode", CurrencyCode);
            cmd.Parameters.AddWithValue("@CurrencyFormat", CurrencyFormat);
            cmd.Parameters.AddWithValue("@alpha2Code", alpha2Code);
            cmd.Parameters.AddWithValue("@timeformat", timeformat);
            cmd.Parameters.AddWithValue("@dateFormat1", dateFormat1);
            cmd.Parameters.AddWithValue("@Language", Language);
            cmd.Parameters.AddWithValue("@Help", Help);

            //mR = cmd.ExecuteNonQuery();
            cmd.ExecuteNonQuery();

        }
        return "1";
    }





    ///////////////////////////////////////Abdullah



    public class ExcelData
    {
        public string AccountTitle { get; set; }
        public string Category { get; set; }
        public string SubCatTitle { get; set; }
        public string OpeningDebit { get; set; }
        public string OpeningCredit { get; set; }
        public string PaySource { get; set; }
        public string BudgetAmount { get; set; }
        public string InTrans { get; set; }
        public string InLedger { get; set; }
        public string InNetWorth { get; set; }
        public string InFullStatement { get; set; }
        public string InBalanceSheet { get; set; }
        public string BudgetType { get; set; }


        public string Payments { get; set; }
        public string Receipts { get; set; }
        public string AccountHolders { get; set; }

        public string Date { get; set; }
        public string Narration { get; set; }
        public string Account { get; set; }



    }


    [WebMethod]
    public string ExportExcelAllAccounts_UserWise(string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            mSQL = "";

            string spName = "ExportExcelAllAccounts_UserWise";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@UserID", UserID);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var varExcelData = new List<ExcelData>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var varExcelDataList = new ExcelData
                {

                    AccountTitle = dt.Rows[i]["AccountTitle"].ToString(),
                    Category = dt.Rows[i]["Category"].ToString(),
                    SubCatTitle = dt.Rows[i]["SubCatTitle"].ToString(),
                    OpeningDebit = dt.Rows[i]["OpeningDebit"].ToString(),
                    OpeningCredit = dt.Rows[i]["OpeningCredit"].ToString(),
                    PaySource = dt.Rows[i]["PaySource"].ToString(),
                    BudgetAmount = dt.Rows[i]["BudgetAmount"].ToString(),
                    InTrans = dt.Rows[i]["InTrans"].ToString(),
                    InLedger = dt.Rows[i]["InLedger"].ToString(),
                    InNetWorth = dt.Rows[i]["InNetWorth"].ToString(),
                    InFullStatement = dt.Rows[i]["InFullStatement"].ToString(),
                    InBalanceSheet = dt.Rows[i]["InBalanceSheet"].ToString(),
                    BudgetType = dt.Rows[i]["BudgetType"].ToString(),

                };
                varExcelData.Add(varExcelDataList);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(varExcelData);
            return myData;

        }

    }




    [WebMethod]
    public string ExportExcelLedger_UserWise(string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            mSQL = "";

            string spName = "getLedger";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@UserID", UserID);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var varExcelData = new List<ExcelData>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var varExcelDataList = new ExcelData
                {

                    AccountTitle = dt.Rows[i]["AccountTitle"].ToString(),
                    Payments = dt.Rows[i]["Payments"].ToString(),
                    Receipts = dt.Rows[i]["Receipts"].ToString(),
                    OpeningDebit = dt.Rows[i]["OpDB"].ToString(),
                    OpeningCredit = dt.Rows[i]["OpCR"].ToString(),
                    AccountHolders = dt.Rows[i]["OwnerName"].ToString(),


                };
                varExcelData.Add(varExcelDataList);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(varExcelData);
            return myData;

        }

    }



    [WebMethod]
    public string ExportExcelAllLedger_UserWise(string UserID)
    {


        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            mSQL = "";

            string spName = "ExportExcelAllLedger_UserWise";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@UserID", UserID);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var varExcelData = new List<ExcelData>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var varExcelDataList = new ExcelData
                {

                    AccountTitle = dt.Rows[i]["accounttitle"].ToString(),
                    Date = dt.Rows[i]["TDate"].ToString(),
                    Narration = dt.Rows[i]["Narration"].ToString(),
                    Payments = dt.Rows[i]["Dr"].ToString(),
                    Receipts = dt.Rows[i]["Cr"].ToString(),
                    Account = dt.Rows[i]["usertitle"].ToString(),

                };
                varExcelData.Add(varExcelDataList);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(varExcelData);
            return myData;

        }

    }




    //////////////////////////-------------------------------------------------------------



    public class GroupLicense
    {
        public string GroupID { get; set; }
        public string UserID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Date { get; set; }
        public string TotalLicense { get; set; }
        public string InviteSent { get; set; }
        public string ConsumedLicense { get; set; }
        public string GroupDetailID { get; set; }
        public string Owner { get; set; }
        public string ActiveStatus { get; set; }
    }




    [WebMethod]
    public string AddGroupLicense(string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        var cal = "";
        using (var con = new SqlConnection(cs))
        {

            string spName = "AddGroupLicense";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = spName;

            cmd.Parameters.AddWithValue("@UserID", UserID);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cal = cmd.ExecuteScalar().ToString();
            con.Close();

            return cal;

        }


    }


    [WebMethod]
    public string AddGroupLicenseOwnerDetail(string GroupID, string UserID, string Name, string Email, string ContactNo)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        var cal = "";
        using (var con = new SqlConnection(cs))
        {

            string spName = "AddGroupLicenseOwnerDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = spName;

            cmd.Parameters.AddWithValue("@GroupID", GroupID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cal = cmd.ExecuteScalar().ToString();
            con.Close();

            return cal;

        }


    }


    [WebMethod]
    public string LoadGroupLicenseOwnerDetail(string UserID)
    {


        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            mSQL = "";

            string spName = "LoadGroupLicenseOwnerDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@UserID", UserID);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var varGroupLicense = new List<GroupLicense>();
            if (dt.Rows.Count > 0)
            {
                var varGroupLicenseList = new GroupLicense
                {

                    GroupID = dt.Rows[0]["GroupID"].ToString(),
                    UserID = dt.Rows[0]["UserID"].ToString(),
                    TotalLicense = dt.Rows[0]["TotalLicense"].ToString(),
                    InviteSent = dt.Rows[0]["InviteSent"].ToString(),
                    ConsumedLicense = dt.Rows[0]["ConsumedLicense"].ToString(),

                };
                varGroupLicense.Add(varGroupLicenseList);
            }
            else
            {
                var varGroupLicenseList = new GroupLicense
                {

                    GroupID = "0",
                    UserID = "0",
                    TotalLicense = "0",
                    ConsumedLicense = "0",

                };
                varGroupLicense.Add(varGroupLicenseList);

            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(varGroupLicense);
            return myData;

        }





    }



    [WebMethod]
    public string LoadGroupLicenseDetail(string UserID)
    {


        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            mSQL = "";

            string spName = "LoadGroupLicenseDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@UserID", UserID);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var varGroupLicense = new List<GroupLicense>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var varGroupLicenseList = new GroupLicense
                {

                    GroupID = dt.Rows[i]["GroupID"].ToString(),
                    GroupDetailID = dt.Rows[i]["GroupDetailID"].ToString(),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    Name = dt.Rows[i]["Name"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    ContactNo = dt.Rows[i]["ContactNo"].ToString(),
                    Date = dt.Rows[i]["Date"].ToString(),
                    Owner = dt.Rows[i]["Owner"].ToString(),
                    ActiveStatus = dt.Rows[i]["ActiveStatus"].ToString(),

                };
                varGroupLicense.Add(varGroupLicenseList);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(varGroupLicense);
            return myData;

        }

    }


    [WebMethod]
    public string AddGroupLicenseDetail(string GroupID, string UserID, string Name, string Email, string ContactNo)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        var cal = "";
        using (var con = new SqlConnection(cs))
        {

            string spName = "AddGroupLicenseDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = spName;

            cmd.Parameters.AddWithValue("@GroupID", GroupID);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cal = cmd.ExecuteScalar().ToString();
            con.Close();

            return cal;

        }


    }



    [WebMethod]
    public string DeleteGroupLicenseDetail(string GroupDetailID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "DeleteGroupLicenseDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = spName;

            cmd.Parameters.AddWithValue("@GroupDetailID", GroupDetailID);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int cal = cmd.ExecuteNonQuery();
            con.Close();

            var js = new JavaScriptSerializer();
            string myData = cal.ToString();
            return myData;

        }

    }



    [WebMethod]
    public string InviteGroupLicenseDetail(string GroupDetailID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "InviteGroupLicenseDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = spName;

            cmd.Parameters.AddWithValue("@GroupDetailID", GroupDetailID);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            int cal = cmd.ExecuteNonQuery();
            con.Close();

            var js = new JavaScriptSerializer();
            string myData = cal.ToString();
            return myData;

        }

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
    public string UpdateGroupLicenseStatus(string email)
    {


        string mSQL;
        string uservalue;

        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            mSQL = "Select Convert(nvarchar(50),GroupDetailID)+'}'+Name from  GroupLicenseDetail where Email='" + email + "' and IsInvite='1' and IsDelete='0' ";
            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            uservalue = (string)cmd.ExecuteScalar();

        }
        string[] arg = uservalue.Split('}');
        if (arg[0].Length == 36)
        {
            string subject = "Group License Invitation ";
            string body1 = "Dear " + arg[1] + ",<br/><br/>" + "You are invited to join Group License of munshibaba.com.";
            body1 = body1 + "<br/<br/> Please confirm through this link; <br/> ";
            body1 = body1 + "<br/><a href='http://munshibaba.com/GroupLicenseAccept.html?token=" + arg[0] + "'> Click Here to Accept </a> <br/>";
            body1 = body1 + "";
            body1 = body1 + "<br/><br/><br/><br/>Regards,<br/><br/><br/>munshi<span style='color:#f49f21;'>baba</span>.com";
            EmailToSomeone(body1, subject, email);
        }


        return uservalue;


    }



    [WebMethod]
    public string AcceptGroupLicense(string GroupDetailID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        var cal = "";
        using (var con = new SqlConnection(cs))
        {

            string spName = "AcceptGroupLicense";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@GroupDetailID", GroupDetailID);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cal = cmd.ExecuteNonQuery().ToString();
            con.Close();

        }
        return cal;

    }




    [WebMethod]
    public string AddSwitchLevel(string UserID, string LevelSwitchFrom, string LevelSwitchTo,string Email)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        var cal = "";
        using (var con = new SqlConnection(cs))
        {

            string spName = "AddSwitchLevel";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = spName;

            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@LevelSwitchFrom", LevelSwitchFrom);
            cmd.Parameters.AddWithValue("@LevelSwitchTo", LevelSwitchTo);
            cmd.Parameters.AddWithValue("@Email", Email);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cal = cmd.ExecuteScalar().ToString();
            con.Close();

            return cal;

        }


    }



    [WebMethod]
    public string SwitchLevelInvite(string SwitchID, string email,string UserName)
    {


        string mSQL;
        string uservalue;
        string cal;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            //mSQL = "Select SwitchID from  SwitchLevel where SwitchID='" + SwitchID + "' and  Email='" + email + "' and IsAccept='0'";
            //SqlCommand cmd = new SqlCommand(mSQL, con);
            //cmd.CommandTimeout = 0;
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}

            //cal = cmd.ExecuteScalar().ToString();

            mSQL = "Select Convert(nvarchar(50),SwitchID)+'}'+Convert(nvarchar(50),LevelSwitchFrom)+'}'+Convert(nvarchar(50),LevelSwitchTo) from  SwitchLevel where SwitchID='" + SwitchID + "' and  Email='" + email + "' and IsAccept='0'";
            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            uservalue = (string)cmd.ExecuteScalar();

        }
        string[] arg = uservalue.Split('}');
        if (arg[0].Length == 36)
        //if (cal.Length == 36)
        {
            string subject = "Level Switch Approval ";
            string body1 = "Dear "+ UserName +",<br/><br/>" + "You have sent request to change Account level from " + arg[1] + " to " + arg[2] + ".";
            body1 = body1 + "<br/<br/> Please confirm through this link; <br/> ";
            body1 = body1 + "<br/><a href='http://munshibaba.com/LevelSwitchApproval.html?token=" + arg[0] + "'> Click Here to Accept </a> <br/>";
            body1 = body1 + "";
            body1 = body1 + "<br/><br/><br/><br/>Regards,<br/><br/><br/>munshi<span style='color:#f49f21;'>baba</span>.com";
            EmailToSomeone(body1, subject, email);
        }


        return uservalue;


    }

    public class SwitchData
    {
        public string UserID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string LevelSwitchFrom { get; set; }
        public string LevelSwitchTo { get; set; }
        public string IsAccept { get; set; }
    }

    [WebMethod]
    public string SwitchApproval(string SwitchID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        var cal = "";
        using (var con = new SqlConnection(cs))
        {

            string spName = "LevelSwitchApproval";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@SwitchID", SwitchID);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            var varGroupLicense = new List<SwitchData>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var varGroupLicenseList = new SwitchData
                {
                    //u.UserID,u.FullName,s.Email,LevelSwitchfrom,LevelSwitchFrom,isAccept
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    FullName = dt.Rows[i]["FullName"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    IsAccept = dt.Rows[i]["isAccept"].ToString(),
                    LevelSwitchFrom = dt.Rows[i]["LevelSwitchfrom"].ToString(),
                    LevelSwitchTo = dt.Rows[i]["LevelSwitchTo"].ToString(),


                };
                varGroupLicense.Add(varGroupLicenseList);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(varGroupLicense);
            return myData;
        }
        

    }

    ///////////////////////////////////////Abdullah



    [WebMethod]
    public string ResetRequest(string UserID, string Email)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        var cal = "";
        using (var con = new SqlConnection(cs))
        {

            string spName = "AddResetRequest";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = spName;

            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@Email", Email);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cal = cmd.ExecuteScalar().ToString();
            con.Close();

            return cal;

        }


    }


    [WebMethod]
    public string SendResetRequest(string ResetID, string email)
    {


        string mSQL;

        string cal;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            //mSQL = "Select SwitchID from  SwitchLevel where SwitchID='" + SwitchID + "' and  Email='" + email + "' and IsAccept='0'";
            //SqlCommand cmd = new SqlCommand(mSQL, con);
            //cmd.CommandTimeout = 0;
            //if (con.State == ConnectionState.Closed)
            //{
            //    con.Open();
            //}

            //cal = cmd.ExecuteScalar().ToString();

            mSQL = "Select ResetID from  ResetRequest where ResetID='" + ResetID + "' and  Email='" + email + "' and IsAccept='0'";
            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cal = cmd.ExecuteScalar().ToString();

        }

        if (cal.Length == 36)
        {
            string subject = "Account Reset Approval ";
            string body1 = "Dear User,<br/><br/>";
             body1 = body1 + " You or someone on your behalf has requested to RESET ACCOUNT which means all categories, sub-categories, accounts and therefore all transactions carried so for will be deleted. ";
            body1 = body1 + "<br/><br/>Recommendation:<br/>It is highly recommended that you, must download data before you choose to RESET ACCOUNT. Because once you RESET ACCOUNT you will not be able to recover the deleted data. ";
            body1 = body1 + "<br/><br/>If you agree that, all data may be deleted, then click the following link to approve the";
  
            body1 = body1 + "<br/><br/><a href='http://munshibaba.com/ConfirmResetApproval.html?token=" + cal + "'> RESET ACCOUNT </a> <br/>";
            body1 = body1 + "";
            body1 = body1 + "<br/><br/><br/><br/>Regards,<br/><br/><br/>munshi<span style='color:#f49f21;'>baba</span>.com";
            EmailToSomeone(body1, subject, email);
        }


        return cal;


    }


    [WebMethod]
    public string ConfirmResetApproval(string ResetID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        var cal = "";
        using (var con = new SqlConnection(cs))
        {

            string spName = "ConfirmResetApproval";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ResetID", ResetID);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cal = cmd.ExecuteNonQuery().ToString();
            con.Close();

        }
        return cal;

    }








}
