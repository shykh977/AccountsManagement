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
/// Summary description for ProjectCustomers
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class ProjectCustomers : System.Web.Services.WebService
{

    public ProjectCustomers()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string CreateProjectCustomers(string Firstname, string Lastname, string Address, string Cnic, string Contact, string Email, string Password, string ProjectId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_ProjectCustomers";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;          
            cmd.Parameters.AddWithValue("@CustomerId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@Firstname",Firstname);
            cmd.Parameters.AddWithValue("@Lastname",Lastname);
            cmd.Parameters.AddWithValue("@Address",Address);
            cmd.Parameters.AddWithValue("@Cnic",Cnic);
            cmd.Parameters.AddWithValue("@Contact",Contact);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);
           // cmd.Parameters.AddWithValue("@Attachments", Attachments);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);




            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

     [WebMethod]
    public string UpdateProjectCustomers(string CustomerId, string Firstname, string Lastname, string Address, string Cnic, string Contact, string Email, string Password, string ProjectId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_ProjectCustomers";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;          
            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmd.Parameters.AddWithValue("@Firstname",Firstname);
            cmd.Parameters.AddWithValue("@Lastname",Lastname);
            cmd.Parameters.AddWithValue("@Address",Address);
            cmd.Parameters.AddWithValue("@Cnic",Cnic);
            cmd.Parameters.AddWithValue("@Contact",Contact);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", Password);
           // cmd.Parameters.AddWithValue("@Attachments", Attachments);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);




            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string GetProjectCustomers(string ProjectId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "GetProjectCustomers";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectCustomersList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectCustomersList
                {

                    CustomerId = dt.Rows[i]["CustomerId"].ToString(),
                    Firstname  = dt.Rows[i]["Firstname"].ToString(),
                    Lastname   = dt.Rows[i]["Lastname"].ToString(),
                    Address    = dt.Rows[i]["Address"].ToString(),
                    Cnic       = dt.Rows[i]["Cnic"].ToString(),
                    Contact    = dt.Rows[i]["Contact"].ToString(),
                    Email      = dt.Rows[i]["Email"].ToString(),
                    Password   = dt.Rows[i]["Password"].ToString(),
                    Attachments= dt.Rows[i]["Attachments"].ToString(),
                    IsDeleted  = dt.Rows[i]["IsDeleted"].ToString(),
                    IsActive   = dt.Rows[i]["IsActive"].ToString(),
                    InsertedOn = dt.Rows[i]["InsertedOn"].ToString(),
                    ProjectId  = dt.Rows[i]["ProjectId"].ToString(),


                };
                SubUser.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;

        }

    }

    [WebMethod]
    public string GetProjectCustomersById(string CustomerId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "GetProjectCustomers";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectCustomersList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectCustomersList
                {

                    CustomerId = dt.Rows[i]["CustomerId"].ToString(),
                    Firstname = dt.Rows[i]["Firstname"].ToString(),
                    Lastname = dt.Rows[i]["Lastname"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    Cnic = dt.Rows[i]["Cnic"].ToString(),
                    Contact = dt.Rows[i]["Contact"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    Password = dt.Rows[i]["Password"].ToString(),
                    Attachments = dt.Rows[i]["Attachments"].ToString(),
                    IsDeleted = dt.Rows[i]["IsDeleted"].ToString(),
                    IsActive = dt.Rows[i]["IsActive"].ToString(),
                    InsertedOn = dt.Rows[i]["InsertedOn"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),


                };
                SubUser.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;

        }

    }

    [WebMethod]
    public string DeleteProjectCustomers(string CustomerId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "DeleteProjectCustomers";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
          
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }



    [WebMethod]
    public string GetProjectInventoryForBookingPlan(string ProjectId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventoryForBookingPlan";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InventoryList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryList
                {


                    ProjectInventoryId          = dt.Rows[i]["ProjectInventoryId"].ToString(),
                    ProjectId                   = dt.Rows[i]["ProjectId"].ToString(),
                    InventoryType               = dt.Rows[i]["InventoryType"].ToString(),
                    Commerical                  = dt.Rows[i]["Commerical"].ToString(),
                    Residential                 = dt.Rows[i]["Residential"].ToString(),
                    Floors                      = dt.Rows[i]["Floors"].ToString(),
                    OfficesAndAppartments       = dt.Rows[i]["OfficesAndAppartments"].ToString(),
                    Houses = dt.Rows[i]["Houses"].ToString(),

                   

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }



    [WebMethod]
    public string CreateCustomerBookingPlan(string ProjectInventoryId,string CustomerId,string ProjectId,float OnBooking,int InstallmentsMonths,float InstallmentsAmount,   string CustomInstallments,   int CustomInstallmentsMonths,   float CustomInstallmentsAmount, float PropertyValue)

    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_CustomerBookingPlan";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@CustomerBookingPlanId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@ProjectInventoryId", ProjectInventoryId);
            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmd.Parameters.AddWithValue("@PropertyValue", PropertyValue);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@OnBooking", OnBooking);
            cmd.Parameters.AddWithValue("@InstallmentsMonths", InstallmentsMonths);
            cmd.Parameters.AddWithValue("@InstallmentsAmount", InstallmentsAmount);
            cmd.Parameters.AddWithValue("@CustomInstallments", CustomInstallments);
            cmd.Parameters.AddWithValue("@CustomInstallmentsMonths", CustomInstallmentsMonths);
            cmd.Parameters.AddWithValue("@CustomInstallmentsAmount", CustomInstallmentsAmount);
           
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string UpdateCustomerBookingPlan(string CustomerBookingPlanId, string ProjectInventoryId, string CustomerId, string ProjectId, float OnBooking, int InstallmentsMonths, float InstallmentsAmount, string CustomInstallments, int CustomInstallmentsMonths, float CustomInstallmentsAmount, float PropertyValue)

    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_CustomerBookingPlan";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@CustomerBookingPlanId", CustomerBookingPlanId);
            cmd.Parameters.AddWithValue("@ProjectInventoryId", ProjectInventoryId);
            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmd.Parameters.AddWithValue("@PropertyValue", PropertyValue);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@OnBooking", OnBooking);
            cmd.Parameters.AddWithValue("@InstallmentsMonths", InstallmentsMonths);
            cmd.Parameters.AddWithValue("@InstallmentsAmount", InstallmentsAmount);
            cmd.Parameters.AddWithValue("@CustomInstallments", CustomInstallments);
            cmd.Parameters.AddWithValue("@CustomInstallmentsMonths", CustomInstallmentsMonths);
            cmd.Parameters.AddWithValue("@CustomInstallmentsAmount", CustomInstallmentsAmount);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }


    [WebMethod]
    public string GetCustomerBookingPlan(string ProjectId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetCustomerBookingPlan";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<CustomerBookingPlanList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new CustomerBookingPlanList
                {
                    Firstname                       = dt.Rows[i]["Firstname"].ToString(),
                    Lastname                        = dt.Rows[i]["Lastname"].ToString(),
                    InventoryType                   = dt.Rows[i]["InventoryType"].ToString(),
                    FloorNo                         = dt.Rows[i]["FloorNo"].ToString(),
                    Bath                            = dt.Rows[i]["Bath"].ToString(),
                    Bed = dt.Rows[i]["Bed"].ToString(),
                    PropertyNo = dt.Rows[i]["PropertyNo"].ToString(),
                    CustomerBookingPlanId           = dt.Rows[i]["CustomerBookingPlanId"].ToString(),
                    ProjectId                       = dt.Rows[i]["ProjectId"].ToString(),
                    ProjectInventoryId              = dt.Rows[i]["ProjectInventoryId"].ToString(),
                    OnBooking                       = dt.Rows[i]["OnBooking"].ToString(),
                    InstallmentsMonths              = dt.Rows[i]["InstallmentsMonths"].ToString(),
                    InstallmentsAmount              = dt.Rows[i]["InstallmentsAmount"].ToString(),
                    CustomInstallments              = dt.Rows[i]["CustomInstallments"].ToString(),
                    CustomInstallmentsMonths        = dt.Rows[i]["CustomInstallmentsMonths"].ToString(),
                    CustomInstallmentsAmount        = dt.Rows[i]["CustomInstallmentsAmount"].ToString(),
                    CustomerId                      = dt.Rows[i]["CustomerId"].ToString(),
                    PropertyValue = dt.Rows[i]["PropertyValue"].ToString(),


                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }
    
    
    
    [WebMethod]
    public string GetCustomerBookingPlanByCustomer(string CustomerId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetCustomerBookingPlanByCustomer";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<CustomerBookingPlanList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new CustomerBookingPlanList
                {
                    Firstname                       = dt.Rows[i]["Firstname"].ToString(),
                    Lastname                        = dt.Rows[i]["Lastname"].ToString(),
                    InventoryType                   = dt.Rows[i]["InventoryType"].ToString(),
                    FloorNo                         = dt.Rows[i]["FloorNo"].ToString(),
                    Bath                            = dt.Rows[i]["Bath"].ToString(),
                    Bed = dt.Rows[i]["Bed"].ToString(),
                    PropertyNo = dt.Rows[i]["PropertyNo"].ToString(),
                    CustomerBookingPlanId           = dt.Rows[i]["CustomerBookingPlanId"].ToString(),
                    ProjectId                       = dt.Rows[i]["ProjectId"].ToString(),
                    ProjectInventoryId              = dt.Rows[i]["ProjectInventoryId"].ToString(),
                    OnBooking                       = dt.Rows[i]["OnBooking"].ToString(),
                    InstallmentsMonths              = dt.Rows[i]["InstallmentsMonths"].ToString(),
                    InstallmentsAmount              = dt.Rows[i]["InstallmentsAmount"].ToString(),
                    CustomInstallments              = dt.Rows[i]["CustomInstallments"].ToString(),
                    CustomInstallmentsMonths        = dt.Rows[i]["CustomInstallmentsMonths"].ToString(),
                    CustomInstallmentsAmount        = dt.Rows[i]["CustomInstallmentsAmount"].ToString(),
                    CustomerId                      = dt.Rows[i]["CustomerId"].ToString(),
                    PropertyValue = dt.Rows[i]["PropertyValue"].ToString(),


                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetCustomerBookingPlanById(string CustomerBookingPlanId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetCustomerBookingPlan";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@CustomerBookingPlanId", CustomerBookingPlanId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<CustomerBookingPlanList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new CustomerBookingPlanList
                {
                    Firstname = dt.Rows[i]["Firstname"].ToString(),
                    Lastname = dt.Rows[i]["Lastname"].ToString(),
                    InventoryType = dt.Rows[i]["InventoryType"].ToString(),
                    FloorNo = dt.Rows[i]["FloorNo"].ToString(),
                    Bath = dt.Rows[i]["Bath"].ToString(),
                    Bed = dt.Rows[i]["Bed"].ToString(),
                    PropertyNo = dt.Rows[i]["PropertyNo"].ToString(),
                    CustomerBookingPlanId = dt.Rows[i]["CustomerBookingPlanId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    ProjectInventoryId = dt.Rows[i]["ProjectInventoryId"].ToString(),
                    OnBooking = dt.Rows[i]["OnBooking"].ToString(),
                    InstallmentsMonths = dt.Rows[i]["InstallmentsMonths"].ToString(),
                    InstallmentsAmount = dt.Rows[i]["InstallmentsAmount"].ToString(),
                    CustomInstallments = dt.Rows[i]["CustomInstallments"].ToString(),
                    CustomInstallmentsMonths = dt.Rows[i]["CustomInstallmentsMonths"].ToString(),
                    CustomInstallmentsAmount = dt.Rows[i]["CustomInstallmentsAmount"].ToString(),
                    CustomerId = dt.Rows[i]["CustomerId"].ToString(),
                    PropertyValue = dt.Rows[i]["PropertyValue"].ToString(),
                    ProjectInventoryIdd = dt.Rows[i]["ProjectInventoryIdd"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }





    [WebMethod]
    public string GetProjectBookingPlanById(string BookingPlanId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectBookingPlan";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@BookingPlanId", BookingPlanId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<BookingPlanList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new BookingPlanList
                {

                    BookingPlanId = dt.Rows[i]["BookingPlanId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    OnBooking = dt.Rows[i]["OnBooking"].ToString(),
                    InstallmentsMonths = dt.Rows[i]["InstallmentsMonths"].ToString(),
                    InstallmentsAmount = dt.Rows[i]["InstallmentsAmount"].ToString(),
                    CustomInstallments = dt.Rows[i]["CustomInstallments"].ToString(),
                    CustomInstallmentsMonths = dt.Rows[i]["CustomInstallmentsMonths"].ToString(),
                    CustomInstallmentsAmount = dt.Rows[i]["CustomInstallmentsAmount"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    [WebMethod]
    public string DeleteCustomerBookingPlan(string CustomerBookingPlanId)

    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "DeleteCustomerBookingPlan";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@CustomerBookingPlanId", CustomerBookingPlanId);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }





    [WebMethod]
    public string CreateProjectStaff(string Name, string Designation, string ContactNo, string email, string cnic, string gender, string ProjectId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_ProjectStaff";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectStaffId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@Name", Name);
            cmd.Parameters.AddWithValue("@Designation", Designation);
            cmd.Parameters.AddWithValue("@ContactNo", ContactNo);
            cmd.Parameters.AddWithValue("@email", email);
            cmd.Parameters.AddWithValue("@cnic", cnic);
            cmd.Parameters.AddWithValue("@gender", gender);
            // cmd.Parameters.AddWithValue("@Attachments", Attachments);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);




            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }




}

internal class CustomerBookingPlanList
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string InventoryType { get; set; }
    public string FloorNo { get; set; }
    public string Bath { get; set; }
    public string Bed { get; set; }
    public string CustomerBookingPlanId { get; set; }
    public string ProjectId { get; set; }
    public string ProjectInventoryId { get; set; }
    public string OnBooking { get; set; }
    public string InstallmentsMonths { get; set; }
    public string InstallmentsAmount { get; set; }
    public string CustomInstallments { get; set; }
    public string CustomInstallmentsMonths { get; set; }
    public string CustomInstallmentsAmount { get; set; }
    public string CustomerId { get; set; }
    public string PropertyValue { get; set; }
    public string PropertyNo { get; internal set; }
    public string ProjectInventoryIdd { get; internal set; }
}

internal class InventoryList
{
    public string ProjectInventoryId { get; set; }
    public string ProjectId { get; set; }
    public string InventoryType { get; set; }
    public string Commerical { get; set; }
    public string Residential { get; set; }
    public string Floors { get; set; }
    public string OfficesAndAppartments { get; set; }
    public string Houses { get; set; }
}

internal class ProjectCustomersList
{
    public string CustomerId { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public string Cnic { get; set; }
    public string Contact { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Attachments { get; set; }
    public string IsDeleted { get; set; }
    public string IsActive { get; set; }
    public string InsertedOn { get; set; }
    public string ProjectId { get; set; }
}