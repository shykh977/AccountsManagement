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
/// Summary description for Project
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Project : System.Web.Services.WebService
{

    public Project()
    {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public string CreateProjects(string UserID, string ProjectName)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_Projects";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectID", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@ProjectName", ProjectName);
            cmd.Parameters.AddWithValue("@UserID", UserID);
                        
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }
 
    [WebMethod]
    public string UpdateProjects(string UserID,string ProjectID, string ProjectName)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_Projects";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
            cmd.Parameters.AddWithValue("@ProjectName", ProjectName);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string GetProjects(string UserId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjects";
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

            var SubUser = new List<ProjectList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectList
                {
                    ProjectID = dt.Rows[i]["ProjectID"].ToString(),
                    ProjectName = dt.Rows[i]["ProjectName"].ToString(),
                    
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    } 
       
    [WebMethod]
    public string GetProjectsById(string ProjectId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjects";
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

            var SubUser = new List<ProjectList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectList
                {
                    ProjectID = dt.Rows[i]["ProjectID"].ToString(),
                    ProjectName = dt.Rows[i]["ProjectName"].ToString(),
                    
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string DeleteProjects(string ProjectID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "DeleteProjects";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectID", ProjectID);
           
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }
    
    
    

    [WebMethod]
    public string AssignedProject(string SubUserId, string ProjectId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_AssignedProject";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@SubUserId", SubUserId);
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
    public string GetAssignedProject(string SubUserId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetAssignedProject";
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

            var SubUser = new List<ProjectAssignedList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectAssignedList
                {
                    SubUserName = dt.Rows[i]["SubUserName"].ToString(),
                    ProjectName = dt.Rows[i]["ProjectName"].ToString(),
                    AssignedProjectId   = dt.Rows[i]["AssignedProjectId"].ToString(),
                    SubUserId           = dt.Rows[i]["SubUserId"].ToString(),
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
    public string DeleteAssignedProject(string AssignedProjectId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "DeleteAssignedProject";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@AssignedProjectId", AssignedProjectId);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }


    
    
    
    [WebMethod]
    public string CreateProjectInventory(
        string ProjectInventoryId,       
        string ProjectId,       
        string InventoryType,
        string Commerical,
        string Residential,
        string Floors,
        string OfficesAndAppartments,
        string Houses  
        )
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_ProjectInventory";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectInventoryId", ProjectInventoryId);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@InventoryType", InventoryType);
            cmd.Parameters.AddWithValue("@Commerical", Commerical);
            cmd.Parameters.AddWithValue("@Residential", Residential);
            cmd.Parameters.AddWithValue("@Floors", Floors);
            cmd.Parameters.AddWithValue("@OfficesAndAppartments", OfficesAndAppartments);
            cmd.Parameters.AddWithValue("@Houses", Houses);
            

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

   
    
    [WebMethod]
    public string CreateProjectInventoryDetail(
        string ProjectInventoryId,
        string PropertyNo,
        string Area,
        string Bed,
        string Bath,
        string PriceTo,
        string PriceFrom,
        string PeymentPlan,
        string Block,
        string FloorNo
        )
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_ProjectInventoryDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectInventoryDetailId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@ProjectInventoryId", ProjectInventoryId);
            cmd.Parameters.AddWithValue("@PropertyNo", PropertyNo);
            cmd.Parameters.AddWithValue("@Area", Area);
            cmd.Parameters.AddWithValue("@Bed", Bed);
            cmd.Parameters.AddWithValue("@Bath", Bath);
            cmd.Parameters.AddWithValue("@PriceTo", PriceTo);
            cmd.Parameters.AddWithValue("@PriceFrom", PriceFrom);
            cmd.Parameters.AddWithValue("@PeymentPlan", PeymentPlan);
            cmd.Parameters.AddWithValue("@Block", Block);
            cmd.Parameters.AddWithValue("@FloorNo", FloorNo);
            cmd.Parameters.AddWithValue("@PlotNo", "");

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }


    [WebMethod]
    public string GetprojectInventory(string ProjectId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_GetprojectInventory";
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

            var SubUser = new List<ProjectInventoryList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryList
                {
                    
                    
                    
                    ProjectInventoryDetailId= dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    ProjectInventoryId= dt.Rows[i]["ProjectInventoryId"].ToString(),
                    PropertyNo= dt.Rows[i]["PropertyNo"].ToString(),
                    Area= dt.Rows[i]["Area"].ToString(),
                    Bed= dt.Rows[i]["Bed"].ToString(),
                    Bath= dt.Rows[i]["Bath"].ToString(),
                    PriceTo= dt.Rows[i]["PriceTo"].ToString(),
                    PriceFrom= dt.Rows[i]["PriceFrom"].ToString(),
                    PeymentPlan= dt.Rows[i]["PeymentPlan"].ToString(),
                    Block= dt.Rows[i]["Block"].ToString(),
                    IsActive= dt.Rows[i]["IsActive"].ToString(),
                    IsDeleted= dt.Rows[i]["IsDeleted"].ToString(),
                    FloorNo= dt.Rows[i]["FloorNo"].ToString(),
                    PlotNo = dt.Rows[i]["PlotNo"].ToString(),


                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }
  
    
    [WebMethod]
    public string GetAppartmentsInFloor(string ProjectId,string FloorNo)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_GetAppartmentsInFloor";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@FloorNo", FloorNo);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectInventoryList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryList
                {
                    
                    
                    
                    ProjectInventoryDetailId= dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    ProjectInventoryId= dt.Rows[i]["ProjectInventoryId"].ToString(),
                    PropertyNo= dt.Rows[i]["PropertyNo"].ToString(),
                    Area= dt.Rows[i]["Area"].ToString(),
                    Bed= dt.Rows[i]["Bed"].ToString(),
                    Bath= dt.Rows[i]["Bath"].ToString(),
                    PriceTo= dt.Rows[i]["PriceTo"].ToString(),
                    PriceFrom= dt.Rows[i]["PriceFrom"].ToString(),
                    PeymentPlan= dt.Rows[i]["PeymentPlan"].ToString(),
                    Block= dt.Rows[i]["Block"].ToString(),
                    IsActive= dt.Rows[i]["IsActive"].ToString(),
                    IsDeleted= dt.Rows[i]["IsDeleted"].ToString(),
                    FloorNo= dt.Rows[i]["FloorNo"].ToString(),
                    PlotNo = dt.Rows[i]["PlotNo"].ToString(),


                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }
   
    
    
    [WebMethod]
    public string GetInventoryDetailById(string ProjectInventoryDetailId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryDetailById";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectInventoryDetailId", ProjectInventoryDetailId);
           
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectInventoryList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryList
                {
                    
                    
                    
                    ProjectInventoryDetailId= dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    ProjectInventoryId= dt.Rows[i]["ProjectInventoryId"].ToString(),
                    PropertyNo= dt.Rows[i]["PropertyNo"].ToString(),
                    Area= dt.Rows[i]["Area"].ToString(),
                    Bed= dt.Rows[i]["Bed"].ToString(),
                    Bath= dt.Rows[i]["Bath"].ToString(),
                    PriceTo= dt.Rows[i]["PriceTo"].ToString(),
                    PriceFrom= dt.Rows[i]["PriceFrom"].ToString(),
                    PeymentPlan= dt.Rows[i]["PeymentPlan"].ToString(),
                    Block= dt.Rows[i]["Block"].ToString(),
                    IsActive= dt.Rows[i]["IsActive"].ToString(),
                    IsDeleted= dt.Rows[i]["IsDeleted"].ToString(),
                    FloorNo= dt.Rows[i]["FloorNo"].ToString(),
                    PlotNo = dt.Rows[i]["PlotNo"].ToString(),


                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }
   
    
    [WebMethod]
    public string GetFloorsInProject(string ProjectId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_GetFloorsInProject";
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

            var SubUser = new List<ProjectInventoryList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryList
                {                                                           
                    FloorNo= dt.Rows[i]["FloorNo"].ToString(),                   
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    [WebMethod]
    public string CreateBookingPlan(
   string ProjectId,
   float OnBooking,
   int InstallmentsMonths,
   float InstallmentsAmount,
   string CustomInstallments,
   int CustomInstallmentsMonths,
   float CustomInstallmentsAmount
       )

    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_BookingPlan";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@BookingPlanId", Guid.NewGuid());
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
    public string UpdateBookingPlan(
   string BookingPlanId,
   string ProjectId,
   float OnBooking,
   int InstallmentsMonths,
   float InstallmentsAmount,
   string CustomInstallments,
   int CustomInstallmentsMonths,
   float CustomInstallmentsAmount
       )

    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_BookingPlan";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@BookingPlanId", BookingPlanId);
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
    public string GetProjectBookingPlan(string ProjectId)
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
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
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
                    
                    BookingPlanId                = dt.Rows[i]["BookingPlanId"].ToString(),
                    ProjectId                    = dt.Rows[i]["ProjectId"].ToString(),
                    OnBooking                    = dt.Rows[i]["OnBooking"].ToString(),
                    InstallmentsMonths           = dt.Rows[i]["InstallmentsMonths"].ToString(),
                    InstallmentsAmount           = dt.Rows[i]["InstallmentsAmount"].ToString(),
                    CustomInstallments           = dt.Rows[i]["CustomInstallments"].ToString(),
                    CustomInstallmentsMonths     = dt.Rows[i]["CustomInstallmentsMonths"].ToString(),
                    CustomInstallmentsAmount     = dt.Rows[i]["CustomInstallmentsAmount"].ToString(),

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
    public string DeleteProjectBookingPlan( string BookingPlanId)

    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "DeleteProjectBookingPlan";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@BookingPlanId", BookingPlanId);
            

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }


}

internal class BookingPlanList
{
    public string BookingPlanId { get; set; }
    public string ProjectId { get; set; }
    public string OnBooking { get; set; }
    public string InstallmentsMonths { get; set; }
    public string InstallmentsAmount { get; set; }
    public string CustomInstallments { get; set; }
    public string CustomInstallmentsMonths { get; set; }
    public string CustomInstallmentsAmount { get; set; }
}

internal class ProjectInventoryList
{
    public string ProjectInventoryDetailId { get; set; }
    public string ProjectInventoryId { get; set; }
    public string PropertyNo { get; set; }
    public string Area { get; set; }
    public string Bed { get; set; }
    public string Bath { get; set; }
    public string PriceTo { get; set; }
    public string PriceFrom { get; set; }
    public string PeymentPlan { get; set; }
    public string Block { get; set; }
    public string IsActive { get; set; }
    public string IsDeleted { get; set; }
    public string FloorNo { get; set; }
    public string PlotNo { get; set; }
}

internal class ProjectAssignedList
{
    public string SubUserName { get; set; }
    public string ProjectName { get; set; }
    public string AssignedProjectId { get; set; }
    public string SubUserId { get; set; }
    public string ProjectId { get; set; }
}

internal class ProjectList
{
    public string ProjectID { get; set; }
    public string ProjectName { get; set; }
}