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
/// Summary description for SalesService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class SalesService : System.Web.Services.WebService
{

    public SalesService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    /// <summary>
    /// /
    /// </summary>
    /// <param name="InventoryTransfer"></param>
    /// <returns></returns>
    [WebMethod]
    public string CreateInventoryTransfer(string UserID, string TransferFrom, string TransferTo, string InventoryDetailId, float TransferFee, float Deduction)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_InventoryTransfer";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InventoryTransferId", Guid.NewGuid());
            //cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@TransferFrom", TransferFrom);
            cmd.Parameters.AddWithValue("@TransferTo", TransferTo);
            cmd.Parameters.AddWithValue("@InventoryDetailId", InventoryDetailId);
          //  cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
            cmd.Parameters.AddWithValue("@TransferFee", TransferFee);
            cmd.Parameters.AddWithValue("@Deduction", Deduction);
            
            cmd.Parameters.AddWithValue("@InsertedBy", UserID);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string UpdateInventoryTransfer(string InventoryTransferId, string ProjectId, string TransferFrom, string TransferTo, string InventoryDetailId, string InventoryNumber, float TransferFee, float Deduction)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_InventoryTransfer";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InventoryTransferId", InventoryTransferId);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@TransferFrom", TransferFrom);
            cmd.Parameters.AddWithValue("@TransferTo", TransferTo);
            cmd.Parameters.AddWithValue("@InventoryDetailId", InventoryDetailId);
            cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
            cmd.Parameters.AddWithValue("@TransferFee", TransferFee);
            cmd.Parameters.AddWithValue("@Deduction", Deduction);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }


    [WebMethod]
    public string GetInventoryTransfer()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryTransfer";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;

            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InventoryTransferList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryTransferList
                {
                    InventoryTransferId = dt.Rows[i]["InventoryTransferId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    TransferFrom = dt.Rows[i]["TransferFrom"].ToString(),
                    TransferTo = dt.Rows[i]["TransferTo"].ToString(),
                    InventoryDetailId = dt.Rows[i]["InventoryDetailId"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    TransferFee = dt.Rows[i]["TransferFee"].ToString(),
                    Deduction = dt.Rows[i]["Deduction"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetInventoryTransferById(string InventoryTransferById)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryTransfer";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InventoryTransferId", InventoryTransferById);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InventoryTransferList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryTransferList
                {
                    InventoryTransferId = dt.Rows[i]["InventoryTransferId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    TransferFrom = dt.Rows[i]["TransferFrom"].ToString(),
                    TransferTo = dt.Rows[i]["TransferTo"].ToString(),
                    InventoryDetailId = dt.Rows[i]["InventoryDetailId"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    TransferFee = dt.Rows[i]["TransferFee"].ToString(),
                    Deduction = dt.Rows[i]["Deduction"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    [WebMethod]
    public string GetInventoryTransferByProject(string ProjectId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryTransfer";
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

            var SubUser = new List<InventoryTransferList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryTransferList
                {
                    InventoryTransferId = dt.Rows[i]["InventoryTransferId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    TransferFrom = dt.Rows[i]["TransferFrom"].ToString(),
                    TransferTo = dt.Rows[i]["TransferTo"].ToString(),
                    InventoryDetailId = dt.Rows[i]["InventoryDetailId"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    TransferFee = dt.Rows[i]["TransferFee"].ToString(),
                    Deduction = dt.Rows[i]["Deduction"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    [WebMethod]
    public string GetInventoryDetail(string InventoryDetailId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryTransfer";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InventoryDetailId", InventoryDetailId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InventoryTransferList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryTransferList
                {
                    InventoryTransferId = dt.Rows[i]["InventoryTransferId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    TransferFrom = dt.Rows[i]["TransferFrom"].ToString(),
                    TransferTo = dt.Rows[i]["TransferTo"].ToString(),
                    InventoryDetailId = dt.Rows[i]["InventoryDetailId"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    TransferFee = dt.Rows[i]["TransferFee"].ToString(),
                    Deduction = dt.Rows[i]["Deduction"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetInventoryByInventoryNumber(string InventoryNumber)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryTransfer";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InventoryTransferList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryTransferList
                {
                    InventoryTransferId = dt.Rows[i]["InventoryTransferId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    TransferFrom = dt.Rows[i]["TransferFrom"].ToString(),
                    TransferTo = dt.Rows[i]["TransferTo"].ToString(),
                    InventoryDetailId = dt.Rows[i]["InventoryDetailId"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    TransferFee = dt.Rows[i]["TransferFee"].ToString(),
                    Deduction = dt.Rows[i]["Deduction"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    /// <summary>
    /// /
    /// </summary>
    /// <param name="InventoryAllocation"></param>
    /// <returns></returns>


    [WebMethod]
    public string CreateInventoryAllocation(string UserID,  string ProjectInventoryDetailId, string AllocatedTo, string AllocatedToType,  string AllocationDate, float TotalPrice, float PaidAmount)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_InventoryAllocation";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InventoryAllocationId", Guid.NewGuid());
          //  cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@ProjectInventoryDetailId", ProjectInventoryDetailId);
            cmd.Parameters.AddWithValue("@AllocatedTo", AllocatedTo);
            //cmd.Parameters.AddWithValue("@OfficeLocationId", OfficeLocationId);
            cmd.Parameters.AddWithValue("@AllocatedToType", AllocatedToType);
           // cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
            cmd.Parameters.AddWithValue("@AllocationDate", AllocationDate);
            cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
            cmd.Parameters.AddWithValue("@PaidAmount", PaidAmount);

            cmd.Parameters.AddWithValue("@InsertedBy", UserID);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }
    
    
    [WebMethod]
    public string UpdateInventoryAllocation(string InventoryAllocationId, string ProjectId, string ProjectInventoryDetailId, string AllocatedTo, string OfficeLocationId, string AllocatedToType, string InventoryNumber, string AllocationDate, float TotalPrice, float PaidAmount)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_InventoryAllocation";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InventoryAllocationId", InventoryAllocationId);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@ProjectInventoryDetailId", ProjectInventoryDetailId);
            cmd.Parameters.AddWithValue("@AllocatedTo", AllocatedTo);
            cmd.Parameters.AddWithValue("@OfficeLocationId", OfficeLocationId);
            cmd.Parameters.AddWithValue("@AllocatedToType", AllocatedToType);
            cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
            cmd.Parameters.AddWithValue("@AllocationDate", AllocationDate);
            cmd.Parameters.AddWithValue("@TotalPrice", TotalPrice);
            cmd.Parameters.AddWithValue("@PaidAmount", PaidAmount);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }


    [WebMethod]
    public string GetInventoryAllocation()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryAllocation";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            //cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InventoryAllocationList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryAllocationList
                {
                    InventoryAllocationId = dt.Rows[i]["InventoryAllocationId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    AllocatedTo = dt.Rows[i]["AllocatedTo"].ToString(),
                    OfficeLocationId = dt.Rows[i]["OfficeLocationId"].ToString(),
                    AllocatedToType = dt.Rows[i]["AllocatedToType"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    AllocationDate = dt.Rows[i]["AllocationDate"].ToString(),
                    TotalPrice = dt.Rows[i]["TotalPrice"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetInventoryAllocationById(string InventoryAllocationId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryAllocation";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InventoryAllocationId", InventoryAllocationId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InventoryAllocationList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryAllocationList
                {
                    InventoryAllocationId = dt.Rows[i]["InventoryAllocationId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    AllocatedTo = dt.Rows[i]["AllocatedTo"].ToString(),
                    OfficeLocationId = dt.Rows[i]["OfficeLocationId"].ToString(),
                    AllocatedToType = dt.Rows[i]["AllocatedToType"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    AllocationDate = dt.Rows[i]["AllocationDate"].ToString(),
                    TotalPrice = dt.Rows[i]["TotalPrice"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetInventoryAllocationByProject(string ProjectId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryAllocation";
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

            var SubUser = new List<InventoryAllocationList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryAllocationList
                {
                    InventoryAllocationId = dt.Rows[i]["InventoryAllocationId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    AllocatedTo = dt.Rows[i]["AllocatedTo"].ToString(),
                    OfficeLocationId = dt.Rows[i]["OfficeLocationId"].ToString(),
                    AllocatedToType = dt.Rows[i]["AllocatedToType"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    AllocationDate = dt.Rows[i]["AllocationDate"].ToString(),
                    TotalPrice = dt.Rows[i]["TotalPrice"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    [WebMethod]
    public string GetInventoryAllocationByProjectInventoryDetail(string ProjectInventoryDetailId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryAllocation";
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

            var SubUser = new List<InventoryAllocationList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryAllocationList
                {
                    InventoryAllocationId = dt.Rows[i]["InventoryAllocationId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    AllocatedTo = dt.Rows[i]["AllocatedTo"].ToString(),
                    OfficeLocationId = dt.Rows[i]["OfficeLocationId"].ToString(),
                    AllocatedToType = dt.Rows[i]["AllocatedToType"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    AllocationDate = dt.Rows[i]["AllocationDate"].ToString(),
                    TotalPrice = dt.Rows[i]["TotalPrice"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    [WebMethod]
    public string GetInventoryAllocationByInventoryNumber(string InventoryNumber)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryAllocation";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InventoryAllocationList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryAllocationList
                {
                    InventoryAllocationId = dt.Rows[i]["InventoryAllocationId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    AllocatedTo = dt.Rows[i]["AllocatedTo"].ToString(),
                    OfficeLocationId = dt.Rows[i]["OfficeLocationId"].ToString(),
                    AllocatedToType = dt.Rows[i]["AllocatedToType"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    AllocationDate = dt.Rows[i]["AllocationDate"].ToString(),
                    TotalPrice = dt.Rows[i]["TotalPrice"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }



    [WebMethod]
    public string GetInventoryAllocationByAllocatedToType(string AllocatedToType)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryAllocation";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@AllocatedToType", AllocatedToType);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InventoryAllocationList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryAllocationList
                {
                    InventoryAllocationId = dt.Rows[i]["InventoryAllocationId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    AllocatedTo = dt.Rows[i]["AllocatedTo"].ToString(),
                    OfficeLocationId = dt.Rows[i]["OfficeLocationId"].ToString(),
                    AllocatedToType = dt.Rows[i]["AllocatedToType"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    AllocationDate = dt.Rows[i]["AllocationDate"].ToString(),
                    TotalPrice = dt.Rows[i]["TotalPrice"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }
    
    
    [WebMethod]
    public string GetInventoryAllocationByOfficeLocationId(string OfficeLocationId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryAllocation";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@OfficeLocationId", OfficeLocationId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InventoryAllocationList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryAllocationList
                {
                    InventoryAllocationId = dt.Rows[i]["InventoryAllocationId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    AllocatedTo = dt.Rows[i]["AllocatedTo"].ToString(),
                    OfficeLocationId = dt.Rows[i]["OfficeLocationId"].ToString(),
                    AllocatedToType = dt.Rows[i]["AllocatedToType"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    AllocationDate = dt.Rows[i]["AllocationDate"].ToString(),
                    TotalPrice = dt.Rows[i]["TotalPrice"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

     [WebMethod]
    public string GetInventoryAllocationByAllocatedTo(string AllocatedTo)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryAllocation";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@AllocatedTo", AllocatedTo);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InventoryAllocationList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryAllocationList
                {
                    InventoryAllocationId = dt.Rows[i]["InventoryAllocationId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    AllocatedTo = dt.Rows[i]["AllocatedTo"].ToString(),
                    OfficeLocationId = dt.Rows[i]["OfficeLocationId"].ToString(),
                    AllocatedToType = dt.Rows[i]["AllocatedToType"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    AllocationDate = dt.Rows[i]["AllocationDate"].ToString(),
                    TotalPrice = dt.Rows[i]["TotalPrice"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    //////////////////Get FUnction
    ///

    [WebMethod]
    public string GetInventoryAllocationDetil(string ProjectInventoryDetailId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInventoryAllocationDetil";
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

            var SubUser = new List<InventoryAllocationList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InventoryAllocationList
                {
                    InventoryAllocationId = dt.Rows[i]["InventoryAllocationId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    AllocatedTo = dt.Rows[i]["AllocatedTo"].ToString(),
                    OfficeLocationId = dt.Rows[i]["OfficeLocationId"].ToString(),
                    AllocatedToType = dt.Rows[i]["AllocatedToType"].ToString(),
                    InventoryNumber = dt.Rows[i]["InventoryNumber"].ToString(),
                    AllocationDate = Convert.ToDateTime( dt.Rows[i]["AllocationDate"]).ToShortDateString(),
                    TotalPrice = dt.Rows[i]["TotalPrice"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                    //Firstname = dt.Rows[i]["Firstname"].ToString(),
                    //Lastname = dt.Rows[i]["Lastname"].ToString(),
                    FromInvestorsAndAgents = dt.Rows[i]["FromInvestorsAndAgents"].ToString(),
                    FromCustomer = dt.Rows[i]["FromTransferFrom"].ToString(),
                    InvestorAndAgentName = dt.Rows[i]["InvestorAndAgentName"].ToString(),
                    CustomerName = dt.Rows[i]["CustomerName"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }



}

internal class InventoryAllocationList
{
    public string InventoryAllocationId { get; set; }
    public string ProjectId { get; set; }
    public string ProjectInventoryDetailId { get; set; }
    public string AllocatedTo { get; set; }
    public string OfficeLocationId { get; set; }
    public string AllocatedToType { get; set; }
    public string InventoryNumber { get; set; }
    public string AllocationDate { get; set; }
    public string TotalPrice { get; set; }
    public string PaidAmount { get; set; }
    public string Firstname { get; internal set; }
    public string Lastname { get; internal set; }
    public string TransferFrom { get; internal set; }
    public string FromInvestorsAndAgents { get; internal set; }
    public string FromCustomer { get; internal set; }
    public string InvestorAndAgentName { get; internal set; }
    public string CustomerName { get; internal set; }
}

internal class InventoryTransferList
{
    public string InventoryTransferId { get; set; }
    public string ProjectId { get; set; }
    public string TransferFrom { get; set; }
    public string TransferTo { get; set; }
    public string InventoryDetailId { get; set; }
    public string InventoryNumber { get; set; }
    public string TransferFee { get; set; }
    public string Deduction { get; set; }
}