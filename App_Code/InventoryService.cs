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
/// Summary description for InventoryService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class InventoryService : System.Web.Services.WebService
{

    public InventoryService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }
    /// <summary>
    /// /
    /// </summary>   
    /// <param name="ProjectLocation"></param>
    /// <returns></returns>
    [WebMethod]
    public string CreateProjectLocation(string UserID, string ProjectLocation, string ProjectId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_ProjectLocation";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectLocationId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@ProjectLocation", ProjectLocation);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
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
    public string UpdateProjectLocation(string UserID, string ProjectLocation,string ProjectLocationId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_ProjectLocation";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectLocationId", ProjectLocationId);
            cmd.Parameters.AddWithValue("@ProjectLocation", ProjectLocation);
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
    public string GetProjectLocation()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectLocation";
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

            var SubUser = new List<ProjectLocationList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectLocationList
                {
                    ProjectLocationId = dt.Rows[i]["ProjectLocationId"].ToString(),
                    ProjectLocation = dt.Rows[i]["ProjectLocation"].ToString(),
                    

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetProjectLocationById(string ProjectLocationId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectLocation";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectLocationId", ProjectLocationId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectLocationList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectLocationList
                {
                    ProjectLocationId = dt.Rows[i]["ProjectLocationId"].ToString(),
                    ProjectLocation = dt.Rows[i]["ProjectLocation"].ToString(),


                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    [WebMethod]
    public string GetProjectLocationByProjectId(string ProjectId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectLocation";
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

            var SubUser = new List<ProjectLocationList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectLocationList
                {
                    ProjectLocationId = dt.Rows[i]["ProjectLocationId"].ToString(),
                    ProjectLocation = dt.Rows[i]["ProjectLocation"].ToString(),


                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }
    
    /// <summary>
    ///
    /// </summary>
    /// <param name=""></param>
    /// <param name="Project"></param>
    /// <returns></returns>

    [WebMethod]
    public string CreateProjects(string UserID, string ProjectName, string ProjectLocationId)
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
            cmd.Parameters.AddWithValue("@ProjectLocationId", ProjectLocationId);
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
    public string UpdateProjects(string UserID, string ProjectID, string ProjectName, string ProjectLocationId)
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
            cmd.Parameters.AddWithValue("@ProjectLocationId", ProjectLocationId);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string GetProjects()
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
    public string GetProjectsByLocation(string ProjectLocationId)
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
            cmd.Parameters.AddWithValue("@ProjectLocationId", ProjectLocationId);
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

    /// <summary>
    /// 
    /// </summary>

    /// <param name="ProjectPhases"></param>

    /// <returns></returns>
    ///
    
   [WebMethod]
    public string CreateProjectPhases(string UserID, string ProjectId, string PhaseName)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_ProjectPhases";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectPhasesId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@PhaseName", PhaseName);
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
    public string UpdateProjectPhases(string ProjectPhasesId, string ProjectId, string PhaseName)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_ProjectPhases";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectID", ProjectId);
            cmd.Parameters.AddWithValue("@ProjectName", PhaseName);
            cmd.Parameters.AddWithValue("@ProjectPhasesId", ProjectPhasesId);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string GetProjectPhases()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectPhases";
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

            var SubUser = new List<ProjectPhasesList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectPhasesList
                {
                    ProjectPhasesId = dt.Rows[i]["ProjectPhasesId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    PhaseName = dt.Rows[i]["PhaseName"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetProjectPhasesById(string ProjectPhasesId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectPhases";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectPhasesId", ProjectPhasesId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectPhasesList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectPhasesList
                {
                    ProjectPhasesId = dt.Rows[i]["ProjectPhasesId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    PhaseName = dt.Rows[i]["PhaseName"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetProjectPhasesByProject(string ProjectId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectPhases";
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

            var SubUser = new List<ProjectPhasesList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectPhasesList
                {
                    ProjectPhasesId = dt.Rows[i]["ProjectPhasesId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    PhaseName = dt.Rows[i]["PhaseName"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    /// </summary>
    /// <param name="ProjectPhasesBlocks"></param>
    /// <returns></returns>
    ///

    [WebMethod]
    public string CreatePhaseBlocks(string UserID, string ProjectPhasesId, string Blocks)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_PhaseBlocks";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@PhaseBlocksId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@ProjectPhasesId", ProjectPhasesId);
            cmd.Parameters.AddWithValue("@Blocks", Blocks);
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
    public string UpdatePhaseBlocks(string PhaseBlocksId, string ProjectPhasesId, string Blocks)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_PhaseBlocks";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@PhaseBlocksId", PhaseBlocksId);
            cmd.Parameters.AddWithValue("@ProjectPhasesId", ProjectPhasesId);
            cmd.Parameters.AddWithValue("@Blocks", Blocks);
           
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string GetPhaseBlocks()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetPhaseBlocks";
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

            var SubUser = new List<ProjectPhasesBlocksList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectPhasesBlocksList
                {
                    PhaseBlocksId = dt.Rows[i]["PhaseBlocksId"].ToString(),
                    ProjectPhasesId = dt.Rows[i]["ProjectPhasesId"].ToString(),
                    Blocks = dt.Rows[i]["Blocks"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetPhaseBlocksById(string PhaseBlocksId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetPhaseBlocks";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@PhaseBlocksId", PhaseBlocksId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectPhasesBlocksList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectPhasesBlocksList
                {
                    PhaseBlocksId = dt.Rows[i]["PhaseBlocksId"].ToString(),
                    ProjectPhasesId = dt.Rows[i]["ProjectPhasesId"].ToString(),
                    Blocks = dt.Rows[i]["Blocks"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetPhaseBlocksByPhases(string ProjectPhasesId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetPhaseBlocks";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectPhasesId", ProjectPhasesId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectPhasesBlocksList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectPhasesBlocksList
                {
                    PhaseBlocksId = dt.Rows[i]["PhaseBlocksId"].ToString(),
                    ProjectPhasesId = dt.Rows[i]["ProjectPhasesId"].ToString(),
                    Blocks = dt.Rows[i]["Blocks"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }



    /// </summary>
    /// <param name="PhaseBlockType"></param>
    /// <returns></returns>
    ///

    [WebMethod]
    public string CreatePhaseBlockType(string UserID, string BlockId, string BlockTypeName)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_BlockType";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@BlockTypeId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@BlockId", BlockId);
            cmd.Parameters.AddWithValue("@BlockTypeName", BlockTypeName);
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
    public string UpdatePhaseBlockType(string BlockTypeId, string BlockId, string BlockTypeName)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_BlockType";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@BlockTypeId", BlockTypeId);
            cmd.Parameters.AddWithValue("@BlockId", BlockId);
            cmd.Parameters.AddWithValue("@BlockTypeName", BlockTypeName);
           

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string GetPhaseBlockType()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetBlockType";
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

            var SubUser = new List<PhasesBlockTypeList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new PhasesBlockTypeList
                {
                    BlockTypeId = dt.Rows[i]["BlockTypeId"].ToString(),
                    BlockId = dt.Rows[i]["BlockId"].ToString(),
                    BlockTypeName = dt.Rows[i]["BlockTypeName"].ToString(),
                     
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetPhaseBlockTypeById(string BlockTypeId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetBlockType";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@BlockTypeId", BlockTypeId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<PhasesBlockTypeList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new PhasesBlockTypeList
                {
                    BlockTypeId = dt.Rows[i]["BlockTypeId"].ToString(),
                    BlockId = dt.Rows[i]["BlockId"].ToString(),
                    BlockTypeName = dt.Rows[i]["BlockTypeName"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    [WebMethod]
    public string GetPhaseBlockTypeByBlock(string BlockId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetBlockType";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@BlockId", BlockId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<PhasesBlockTypeList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new PhasesBlockTypeList
                {
                    BlockTypeId = dt.Rows[i]["BlockTypeId"].ToString(),
                    BlockId = dt.Rows[i]["BlockId"].ToString(),
                    BlockTypeName = dt.Rows[i]["BlockTypeName"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    /// </summary>
    /// <param name="BlockTypeCategory"></param>
    /// <returns></returns>
    ///

    [WebMethod]
    public string CreateBlockTypeCategory(string UserID, string BlockTypeId, string BlockTypeName)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_BlockTypeCategory";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@BlockTypeCategoryId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@BlockTypeId", BlockTypeId);
            cmd.Parameters.AddWithValue("@BlockTypeCategory", BlockTypeName);
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
    public string UpdateBlockTypeCategory(string BlockTypeCategoryId, string BlockTypeId, string BlockTypeName)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_BlockTypeCategory";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@BlockTypeCategoryId", BlockTypeCategoryId);
            cmd.Parameters.AddWithValue("@BlockTypeId", BlockTypeId);
            cmd.Parameters.AddWithValue("@BlockTypeCategory", BlockTypeName);
          
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string GetBlockTypeCategory()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetBlockTypeCategory";
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

            var SubUser = new List<BlockTypeCategoryList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new BlockTypeCategoryList
                {
                    BlockTypeCategoryId = dt.Rows[i]["BlockTypeCategoryId"].ToString(),
                    BlockTypeId = dt.Rows[i]["BlockTypeId"].ToString(),
                    BlockTypeCategory = dt.Rows[i]["BlockTypeCategory"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetBlockTypeCategoryById(string BlockTypeCategoryId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetBlockTypeCategory";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@BlockTypeCategoryId", BlockTypeCategoryId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<PhasesBlockTypeList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new PhasesBlockTypeList
                {
                    BlockTypeId = dt.Rows[i]["BlockTypeId"].ToString(),
                    BlockId = dt.Rows[i]["BlockId"].ToString(),
                    BlockTypeName = dt.Rows[i]["BlockTypeName"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    [WebMethod]
    public string GetBlockTypeCategoryByBlockType(string BlockTypeId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetBlockTypeCategory";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@BlockTypeId", BlockTypeId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<BlockTypeCategoryList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new BlockTypeCategoryList
                {
                    BlockTypeCategoryId = dt.Rows[i]["BlockTypeCategoryId"].ToString(),
                    BlockTypeId = dt.Rows[i]["BlockTypeId"].ToString(),
                    BlockTypeCategory = dt.Rows[i]["BlockTypeCategory"].ToString(),
                    

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    /// </summary>
    /// <param name="CategorySize"></param>
    /// <returns></returns>
    ///

    [WebMethod]
    public string CreateBlockTypeCategorySize(string UserID, string BlockTypeCategoryId, string CategorySizeDescription)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_CategorySize";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@CategorySizeId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@BlockTypeCategoryId", BlockTypeCategoryId);
            cmd.Parameters.AddWithValue("@CategorySizeDescription", CategorySizeDescription);
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
    public string UpdateBlockTypeCategorySize(string CategorySizeId, string BlockTypeCategoryId, string CategorySizeDescription)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_CategorySize";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@CategorySizeId", CategorySizeId);
            cmd.Parameters.AddWithValue("@BlockTypeCategoryId", BlockTypeCategoryId);
            cmd.Parameters.AddWithValue("@CategorySizeDescription", CategorySizeDescription);
            

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string GetBlockTypeCategorySize()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetCategorySize";
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

            var SubUser = new List<BlockTypeCategorySizeList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new BlockTypeCategorySizeList
                {
                    CategorySizeId = dt.Rows[i]["CategorySizeId"].ToString(),
                    BlockTypeCategoryId = dt.Rows[i]["BlockTypeCategoryId"].ToString(),
                    CategorySizeDescription = dt.Rows[i]["CategorySizeDescription"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetBlockTypeCategorySizeById(string CategorySizeId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetCategorySize";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@CategorySizeId", CategorySizeId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<BlockTypeCategorySizeList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new BlockTypeCategorySizeList
                {
                    CategorySizeId = dt.Rows[i]["CategorySizeId"].ToString(),
                    BlockTypeCategoryId = dt.Rows[i]["BlockTypeCategoryId"].ToString(),
                    CategorySizeDescription = dt.Rows[i]["CategorySizeDescription"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    [WebMethod]
    public string GetBlockTypeCategorySizeByTypeCategory(string BlockTypeCategoryId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetCategorySize";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@BlockTypeCategoryId", BlockTypeCategoryId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<BlockTypeCategorySizeList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new BlockTypeCategorySizeList
                {
                    CategorySizeId = dt.Rows[i]["CategorySizeId"].ToString(),
                    BlockTypeCategoryId = dt.Rows[i]["BlockTypeCategoryId"].ToString(),
                    CategorySizeDescription = dt.Rows[i]["CategorySizeDescription"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }





    /// </summary>
    /// <param name="ProjectInventory"></param>
    /// <returns></returns>
    ///




    [WebMethod]
    public string CreateProjectInventory(string UserID, string OfficeLocationId,      
     string ProjectId,
     string ProjectPhasesId,
     string PhaseBlocksId,
     string BlockTypeId,
     string BlockTypeCategoryId,
     string CategorySizeId,    
     string SalePrice,
     string InventoryName,
     string InventoryCount,
     string NoteNo,
     string Characters,
     
     string InventoryDetails                )
    
    
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
            cmd.Parameters.AddWithValue("@ProjectInventoryId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@OfficeLocationId", OfficeLocationId);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@ProjectPhasesId", ProjectPhasesId);
            cmd.Parameters.AddWithValue("@PhaseBlocksId", PhaseBlocksId);
            cmd.Parameters.AddWithValue("@BlockTypeId", BlockTypeId);
            cmd.Parameters.AddWithValue("@BlockTypeCategoryId", BlockTypeCategoryId);
            cmd.Parameters.AddWithValue("@CategorySizeId", CategorySizeId);
            
            cmd.Parameters.AddWithValue("@SalePrice", SalePrice);
            cmd.Parameters.AddWithValue("@InventoryName", InventoryName);
            cmd.Parameters.AddWithValue("@InventoryCount", InventoryCount);
            cmd.Parameters.AddWithValue("@NoteNo", NoteNo);
            cmd.Parameters.AddWithValue("@Characters", Characters);
           // cmd.Parameters.AddWithValue("@InventoryAdditionalFeatureId", InventoryAdditionalFeatureId);
            cmd.Parameters.AddWithValue("@InventoryDetails", InventoryDetails);
            cmd.Parameters.AddWithValue("@UserId", UserID);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string UpdateProjectInventory(string ProjectInventoryId, string OfficeLocationId,
     string ProjectId,
     string PhaseBlocksId,
     string SizeTypeId,
     string SalePrice,
     string InventoryName,
     string InventoryCount,
     string NoteNo,
     string Characters,
     string InventoryAdditionalFeatureId,
     string InventoryDetails)
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
            cmd.Parameters.AddWithValue("@OfficeLocationId", OfficeLocationId);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@PhaseBlocksId", PhaseBlocksId);
            cmd.Parameters.AddWithValue("@SizeTypeId", SizeTypeId);
            cmd.Parameters.AddWithValue("@SalePrice", SalePrice);
            cmd.Parameters.AddWithValue("@InventoryName", InventoryName);
            cmd.Parameters.AddWithValue("@InventoryCount", InventoryCount);
            cmd.Parameters.AddWithValue("@NoteNo", NoteNo);
            cmd.Parameters.AddWithValue("@Characters", Characters);
            cmd.Parameters.AddWithValue("@InventoryAdditionalFeatureId", InventoryAdditionalFeatureId);
            cmd.Parameters.AddWithValue("@InventoryDetails", InventoryDetails);
           


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string GetProjectInventory(

     
      string  OfficeLocationId,
      string  ProjectId,
      string  ProjectPhasesId,
      string  PhaseBlocksId,
      string  BlockTypeId,
      string  BlockTypeCategoryId,
      string  CategorySizeId

        )
    {


        if (OfficeLocationId == "") { OfficeLocationId = null; }
        if (ProjectPhasesId == "") { ProjectPhasesId = null; }
        if (PhaseBlocksId == "") { PhaseBlocksId = null; }
        if (BlockTypeId == "") { BlockTypeId = null; }
        if (BlockTypeCategoryId == "") { BlockTypeCategoryId = null; }
        if (CategorySizeId == "") { CategorySizeId = null; }


        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventory";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
           // cmd.Parameters.AddWithValue("@ProjectInventoryId", ProjectInventoryId);
            cmd.Parameters.AddWithValue("@OfficeLocationId", OfficeLocationId);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@ProjectPhasesId", ProjectPhasesId);
            cmd.Parameters.AddWithValue("@PhaseBlocksId", PhaseBlocksId);
            cmd.Parameters.AddWithValue("@BlockTypeId", BlockTypeId);
            cmd.Parameters.AddWithValue("@BlockTypeCategoryId", BlockTypeCategoryId);
            cmd.Parameters.AddWithValue("@CategorySizeId", CategorySizeId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectInventoryListNew>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryListNew
                {
                    ProjectInventoryId = dt.Rows[i]["ProjectInventoryId"].ToString(),
                    SalePrice = dt.Rows[i]["SalePrice"].ToString(),
                    InventoryName = dt.Rows[i]["InventoryName"].ToString(),
                    InventoryCount = dt.Rows[i]["InventoryCount"].ToString(),
                    NoteNo = dt.Rows[i]["NoteNo"].ToString(),
                    Characters = dt.Rows[i]["Characters"].ToString(),
                    InventoryDetails = dt.Rows[i]["InventoryDetails"].ToString(),
  
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetProjectInventoryById(string ProjectInventoryId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventory";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectInventoryId", ProjectInventoryId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectInventoryListNew>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryListNew
                {
                    SalePrice = dt.Rows[i]["SalePrice"].ToString(),
                    InventoryName = dt.Rows[i]["InventoryName"].ToString(),
                    InventoryCount = dt.Rows[i]["InventoryCount"].ToString(),
                    NoteNo = dt.Rows[i]["NoteNo"].ToString(),
                    Characters = dt.Rows[i]["Characters"].ToString(),
                    InventoryDetails = dt.Rows[i]["InventoryDetails"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetProjectInventoryByOfficeLocation(string OfficeLocationId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventory";
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

            var SubUser = new List<ProjectInventoryListNew>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryListNew
                {
                    SalePrice = dt.Rows[i]["SalePrice"].ToString(),
                    InventoryName = dt.Rows[i]["InventoryName"].ToString(),
                    InventoryCount = dt.Rows[i]["InventoryCount"].ToString(),
                    NoteNo = dt.Rows[i]["NoteNo"].ToString(),
                    Characters = dt.Rows[i]["Characters"].ToString(),
                    InventoryDetails = dt.Rows[i]["InventoryDetails"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetProjectInventoryByProject(string ProjectId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventory";
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

            var SubUser = new List<ProjectInventoryListNew>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryListNew
                {
                    SalePrice = dt.Rows[i]["SalePrice"].ToString(),
                    InventoryName = dt.Rows[i]["InventoryName"].ToString(),
                    InventoryCount = dt.Rows[i]["InventoryCount"].ToString(),
                    NoteNo = dt.Rows[i]["NoteNo"].ToString(),
                    Characters = dt.Rows[i]["Characters"].ToString(),
                    InventoryDetails = dt.Rows[i]["InventoryDetails"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetProjectInventoryByPhaseBlocks(string PhaseBlocksId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventory";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@PhaseBlocksId", PhaseBlocksId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectInventoryListNew>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryListNew
                {
                    SalePrice = dt.Rows[i]["SalePrice"].ToString(),
                    InventoryName = dt.Rows[i]["InventoryName"].ToString(),
                    InventoryCount = dt.Rows[i]["InventoryCount"].ToString(),
                    NoteNo = dt.Rows[i]["NoteNo"].ToString(),
                    Characters = dt.Rows[i]["Characters"].ToString(),
                    InventoryDetails = dt.Rows[i]["InventoryDetails"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetProjectInventoryBySizeType(string SizeTypeId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventory";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@SizeTypeId", SizeTypeId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectInventoryListNew>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryListNew
                {
                    SalePrice = dt.Rows[i]["SalePrice"].ToString(),
                    InventoryName = dt.Rows[i]["InventoryName"].ToString(),
                    InventoryCount = dt.Rows[i]["InventoryCount"].ToString(),
                    NoteNo = dt.Rows[i]["NoteNo"].ToString(),
                    Characters = dt.Rows[i]["Characters"].ToString(),
                    InventoryDetails = dt.Rows[i]["InventoryDetails"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }




    /// </summary>
    /// <param name="Investors"></param>
    /// <returns></returns>
    ///

    [WebMethod]
    public string CreateInvestorsAndAgents(
        string UserID, 
        string InvestorAndAgentName,
        string CNIC,
        string ContactPerson,
        string PhoneNo,
        string Country,
        string State,
        string City,
        string Area,
        string OfficeLocation,
        string Remarks)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_InvestorsAndAgents";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InvestorsAndAgentsId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@InvestorAndAgentName", InvestorAndAgentName);
            cmd.Parameters.AddWithValue("@CNIC", CNIC);
            cmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Area", Area);
            cmd.Parameters.AddWithValue("@OfficeLocation", OfficeLocation);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@EntryType", "Investor");
            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string UpdateInvestorsAndAgents(
        string InvestorsAndAgentsId,
        string InvestorAndAgentName,
        string CategorySizeDescription,
        string CNIC,
        string ContactPerson,
        string PhoneNo,
        string Country,
        string State,
        string City,
        string Area,
        string OfficeLocation,
        string Remarks
        )
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_InvestorsAndAgents";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InvestorsAndAgentsId", InvestorsAndAgentsId);
            cmd.Parameters.AddWithValue("@InvestorAndAgentName", InvestorAndAgentName);
            cmd.Parameters.AddWithValue("@CNIC", CNIC);
            cmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Area", Area);
            cmd.Parameters.AddWithValue("@OfficeLocation", OfficeLocation);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@EntryType", "Investor");


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string GetInvestors()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInvestorsAndAgents";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@EntryType", "Investor");
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InvestorsAndAgentsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InvestorsAndAgentsList
                {
                    InvestorsAndAgentsId = dt.Rows[i]["InvestorsAndAgentsId"].ToString(),
                    InvestorAndAgentName = dt.Rows[i]["InvestorAndAgentName"].ToString(),
                    CNIC = dt.Rows[i]["CNIC"].ToString(),
                    ContactPerson = dt.Rows[i]["ContactPerson"].ToString(),
                    PhoneNo = dt.Rows[i]["PhoneNo"].ToString(),
                    Country = dt.Rows[i]["Country"].ToString(),
                    State = dt.Rows[i]["State"].ToString(),
                    City = dt.Rows[i]["City"].ToString(),
                    Area = dt.Rows[i]["Area"].ToString(),
                    OfficeLocation = dt.Rows[i]["OfficeLocation"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetInvestorsById(string InvestorsAndAgentsId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInvestorsAndAgents";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InvestorsAndAgentsId", InvestorsAndAgentsId);
            cmd.Parameters.AddWithValue("@EntryType", "Investor");
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InvestorsAndAgentsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InvestorsAndAgentsList
                {
                    InvestorsAndAgentsId = dt.Rows[i]["InvestorsAndAgentsId"].ToString(),
                    InvestorAndAgentName = dt.Rows[i]["InvestorAndAgentName"].ToString(),
                    CNIC = dt.Rows[i]["CNIC"].ToString(),
                    ContactPerson = dt.Rows[i]["ContactPerson"].ToString(),
                    PhoneNo = dt.Rows[i]["PhoneNo"].ToString(),
                    Country = dt.Rows[i]["Country"].ToString(),
                    State = dt.Rows[i]["State"].ToString(),
                    City = dt.Rows[i]["City"].ToString(),
                    Area = dt.Rows[i]["Area"].ToString(),
                    OfficeLocation = dt.Rows[i]["OfficeLocation"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }



    /// </summary>
    /// <param name="Agents"></param>
    /// <returns></returns>
    ///

    [WebMethod]
    public string CreateAgents(
        string UserID,
        string InvestorAndAgentName,
        string CNIC,
        string ContactPerson,
        string PhoneNo,
        string Country,
        string State,
        string City,
        string Area,
        string OfficeLocation,
        string Remarks)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_InvestorsAndAgents";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InvestorsAndAgentsId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@InvestorAndAgentName", InvestorAndAgentName);
            cmd.Parameters.AddWithValue("@CNIC", CNIC);
            cmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Area", Area);
            cmd.Parameters.AddWithValue("@OfficeLocation", OfficeLocation);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@EntryType", "Agents");

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string UpdateAgents(
        string InvestorsAndAgentsId,
        string InvestorAndAgentName,
        string CNIC,
        string ContactPerson,
        string PhoneNo,
        string Country,
        string State,
        string City,
        string Area,
        string OfficeLocation,
        string Remarks
        )
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_InvestorsAndAgents";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InvestorsAndAgentsId", InvestorsAndAgentsId);
            cmd.Parameters.AddWithValue("@InvestorAndAgentName", InvestorAndAgentName);
            cmd.Parameters.AddWithValue("@CNIC", CNIC);
            cmd.Parameters.AddWithValue("@ContactPerson", ContactPerson);
            cmd.Parameters.AddWithValue("@PhoneNo", PhoneNo);
            cmd.Parameters.AddWithValue("@Country", Country);
            cmd.Parameters.AddWithValue("@State", State);
            cmd.Parameters.AddWithValue("@City", City);
            cmd.Parameters.AddWithValue("@Area", Area);
            cmd.Parameters.AddWithValue("@OfficeLocation", OfficeLocation);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@EntryType", "Agents");


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string GetAgents()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInvestorsAndAgents";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@EntryType", "Agents");
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InvestorsAndAgentsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InvestorsAndAgentsList
                {
                    InvestorsAndAgentsId = dt.Rows[i]["InvestorsAndAgentsId"].ToString(),
                    InvestorAndAgentName = dt.Rows[i]["InvestorAndAgentName"].ToString(),
                    CNIC = dt.Rows[i]["CNIC"].ToString(),
                    ContactPerson = dt.Rows[i]["ContactPerson"].ToString(),
                    PhoneNo = dt.Rows[i]["PhoneNo"].ToString(),
                    Country = dt.Rows[i]["Country"].ToString(),
                    State = dt.Rows[i]["State"].ToString(),
                    City = dt.Rows[i]["City"].ToString(),
                    Area = dt.Rows[i]["Area"].ToString(),
                    OfficeLocation = dt.Rows[i]["OfficeLocation"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetAgentsById(string InvestorsAndAgentsId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInvestorsAndAgents";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InvestorsAndAgentsId", InvestorsAndAgentsId);
            cmd.Parameters.AddWithValue("@EntryType", "Agents");
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<InvestorsAndAgentsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InvestorsAndAgentsList
                {
                    InvestorsAndAgentsId = dt.Rows[i]["InvestorsAndAgentsId"].ToString(),
                    InvestorAndAgentName = dt.Rows[i]["InvestorAndAgentName"].ToString(),
                    CNIC = dt.Rows[i]["CNIC"].ToString(),
                    ContactPerson = dt.Rows[i]["ContactPerson"].ToString(),
                    PhoneNo = dt.Rows[i]["PhoneNo"].ToString(),
                    Country = dt.Rows[i]["Country"].ToString(),
                    State = dt.Rows[i]["State"].ToString(),
                    City = dt.Rows[i]["City"].ToString(),
                    Area = dt.Rows[i]["Area"].ToString(),
                    OfficeLocation = dt.Rows[i]["OfficeLocation"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }



    /// </summary>
    /// <param name="InvertoryUnit"></param>
    /// <returns></returns>
    ///

    [WebMethod]
    public string CreateInvertoryUnit(string UserID, string InventoryUnitName)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_InvertoryUnit";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InvertoryUnitId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@InventoryUnitName", InventoryUnitName);           
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
    public string UpdateInvertoryUnit(string UserID, string InventoryUnitName, string InvertoryUnitId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_InvertoryUnit";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InvertoryUnitId", InvertoryUnitId);
            cmd.Parameters.AddWithValue("@InventoryUnitName", InventoryUnitName);
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
    public string GetInvertoryUnit()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInvertoryUnit";
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

            var SubUser = new List<InvertoryUnitList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new InvertoryUnitList
                {
                    InvertoryUnitId = dt.Rows[i]["InvertoryUnitId"].ToString(),
                    InventoryUnitName = dt.Rows[i]["InventoryUnitName"].ToString(),
                   
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetInvertoryUnitById(string InvertoryUnitId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetInvertoryUnit";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InvertoryUnitId", InvertoryUnitId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<BlockTypeCategorySizeList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new BlockTypeCategorySizeList
                {
                    CategorySizeId = dt.Rows[i]["CategorySizeId"].ToString(),
                    BlockTypeCategoryId = dt.Rows[i]["BlockTypeCategoryId"].ToString(),
                    CategorySizeDescription = dt.Rows[i]["CategorySizeDescription"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    /// </summary>
    /// <param name="ProjectInventoryDetail"></param>
    /// <returns></returns>
    ///

    [WebMethod]
    public string CreateInventoryDetail(
        string UserID,      
       
        string FileNo,
        string Status,
        string NoteNo,
        string Printed,
        string Type,
        string ProjectInventoryId


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
            //cmd.Parameters.AddWithValue("@CategorySizeId", CategorySizeId);
            //cmd.Parameters.AddWithValue("@FileNoFrom", FileNoFrom);
            //cmd.Parameters.AddWithValue("@FileNoTo", FileNoTo);
            cmd.Parameters.AddWithValue("@FileNo", FileNo);
            //cmd.Parameters.AddWithValue("@ProjectLocationId", ProjectLocationId);
            //cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
            //cmd.Parameters.AddWithValue("@InvertoryUnitId", InvertoryUnitId);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@NoteNo", NoteNo);
            //cmd.Parameters.AddWithValue("@InvestorId", InvestorId);
            cmd.Parameters.AddWithValue("@Printed", Printed);
            cmd.Parameters.AddWithValue("@Type", Type);
            //cmd.Parameters.AddWithValue("@ParentAgent", ParentAgent);
            //cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
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
    public string UpdateInventoryDetail(
        string ProjectInventoryDetailId,
        string FileNoFrom,
        string FileNoTo,
        string FileNo,
        string ProjectLocationId,
        string CustomerId,
        string InvertoryUnitId,
        string Status,
        string NoteNo,
        string InvestorId,
        string Printed,
        string Type,
        string ParentAgent,
        string ProjectId,
        string CategorySizeId
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
            cmd.Parameters.AddWithValue("@ProjectInventoryDetailId", ProjectInventoryDetailId);
            cmd.Parameters.AddWithValue("@CategorySizeId", CategorySizeId);
            cmd.Parameters.AddWithValue("@FileNoFrom", FileNoFrom);
            cmd.Parameters.AddWithValue("@FileNoTo", FileNoTo);
            cmd.Parameters.AddWithValue("@FileNo", FileNo);
            cmd.Parameters.AddWithValue("@ProjectLocationId", ProjectLocationId);
            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmd.Parameters.AddWithValue("@InvertoryUnitId", InvertoryUnitId);
            cmd.Parameters.AddWithValue("@Status", Status);
            cmd.Parameters.AddWithValue("@NoteNo", NoteNo);
            cmd.Parameters.AddWithValue("@InvestorId", InvestorId);
            cmd.Parameters.AddWithValue("@Printed", Printed);
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@ParentAgent", ParentAgent);
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
    public string GetProjectInventoryDetail(string ProjectInventoryId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventoryDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectInventoryId", ProjectInventoryId);
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectInventoryDetailList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryDetailList
                {

                    ProjectInventoryDetailId    = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    FileNoFrom                  = dt.Rows[i]["FileNoFrom"].ToString(),
                    FileNoTo                    = dt.Rows[i]["FileNoTo"].ToString(),
                    FileNo                      = dt.Rows[i]["FileNo"].ToString(),
                    ProjectLocationId           = dt.Rows[i]["ProjectLocationId"].ToString(),
                    CustomerId                  = dt.Rows[i]["CustomerId"].ToString(),
                    InvertoryUnitId             = dt.Rows[i]["InvertoryUnitId"].ToString(),
                    Status                      = dt.Rows[i]["Status"].ToString(),
                    NoteNo                      = dt.Rows[i]["NoteNo"].ToString(),
                    InvestorId                  = dt.Rows[i]["InvestorId"].ToString(),
                    Printed                     = dt.Rows[i]["Printed"].ToString(),
                    Type                        = dt.Rows[i]["Type"].ToString(),
                    ParentAgent                 = dt.Rows[i]["ParentAgent"].ToString(),
                    ProjectId                   = dt.Rows[i]["ProjectId"].ToString(),
                    CategorySizeId              = dt.Rows[i]["CategorySizeId"].ToString(),
                    IsAllocated                 = dt.Rows[i]["IsAllocated"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }
    
    
    [WebMethod]
    public string InventoryDetailProjectByLocation(string ProjectLocationId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventoryDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ProjectLocationId", ProjectLocationId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectInventoryDetailList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryDetailList
                {

                    ProjectInventoryDetailId    = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    FileNoFrom                  = dt.Rows[i]["FileNoFrom"].ToString(),
                    FileNoTo                    = dt.Rows[i]["FileNoTo"].ToString(),
                    FileNo                      = dt.Rows[i]["FileNo"].ToString(),
                    ProjectLocationId           = dt.Rows[i]["ProjectLocationId"].ToString(),
                    CustomerId                  = dt.Rows[i]["CustomerId"].ToString(),
                    InvertoryUnitId             = dt.Rows[i]["InvertoryUnitId"].ToString(),
                    Status                      = dt.Rows[i]["Status"].ToString(),
                    NoteNo                      = dt.Rows[i]["NoteNo"].ToString(),
                    InvestorId                  = dt.Rows[i]["InvestorId"].ToString(),
                    Printed                     = dt.Rows[i]["Printed"].ToString(),
                    Type                        = dt.Rows[i]["Type"].ToString(),
                    ParentAgent                 = dt.Rows[i]["ParentAgent"].ToString(),
                    ProjectId                   = dt.Rows[i]["ProjectId"].ToString(),
                    CategorySizeId              = dt.Rows[i]["CategorySizeId"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string InventoryDetailProjectByInvertoryUnit(string InvertoryUnitId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventoryDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InvertoryUnitId", InvertoryUnitId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectInventoryDetailList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryDetailList
                {

                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    FileNoFrom = dt.Rows[i]["FileNoFrom"].ToString(),
                    FileNoTo = dt.Rows[i]["FileNoTo"].ToString(),
                    FileNo = dt.Rows[i]["FileNo"].ToString(),
                    ProjectLocationId = dt.Rows[i]["ProjectLocationId"].ToString(),
                    CustomerId = dt.Rows[i]["CustomerId"].ToString(),
                    InvertoryUnitId = dt.Rows[i]["InvertoryUnitId"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    NoteNo = dt.Rows[i]["NoteNo"].ToString(),
                    InvestorId = dt.Rows[i]["InvestorId"].ToString(),
                    Printed = dt.Rows[i]["Printed"].ToString(),
                    Type = dt.Rows[i]["Type"].ToString(),
                    ParentAgent = dt.Rows[i]["ParentAgent"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    CategorySizeId = dt.Rows[i]["CategorySizeId"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string InventoryDetailById(string ProjectInventoryDetailId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventoryDetail";
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

            var SubUser = new List<ProjectInventoryDetailList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryDetailList
                {

                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    FileNoFrom = dt.Rows[i]["FileNoFrom"].ToString(),
                    FileNoTo = dt.Rows[i]["FileNoTo"].ToString(),
                    FileNo = dt.Rows[i]["FileNo"].ToString(),
                    ProjectLocationId = dt.Rows[i]["ProjectLocationId"].ToString(),
                    CustomerId = dt.Rows[i]["CustomerId"].ToString(),
                    InvertoryUnitId = dt.Rows[i]["InvertoryUnitId"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    NoteNo = dt.Rows[i]["NoteNo"].ToString(),
                    InvestorId = dt.Rows[i]["InvestorId"].ToString(),
                    Printed = dt.Rows[i]["Printed"].ToString(),
                    Type = dt.Rows[i]["Type"].ToString(),
                    ParentAgent = dt.Rows[i]["ParentAgent"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    CategorySizeId = dt.Rows[i]["CategorySizeId"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string InventoryDetailByInvestorId(string InvestorId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventoryDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@InvestorId", InvestorId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectInventoryDetailList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryDetailList
                {

                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    FileNoFrom = dt.Rows[i]["FileNoFrom"].ToString(),
                    FileNoTo = dt.Rows[i]["FileNoTo"].ToString(),
                    FileNo = dt.Rows[i]["FileNo"].ToString(),
                    ProjectLocationId = dt.Rows[i]["ProjectLocationId"].ToString(),
                    CustomerId = dt.Rows[i]["CustomerId"].ToString(),
                    InvertoryUnitId = dt.Rows[i]["InvertoryUnitId"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    NoteNo = dt.Rows[i]["NoteNo"].ToString(),
                    InvestorId = dt.Rows[i]["InvestorId"].ToString(),
                    Printed = dt.Rows[i]["Printed"].ToString(),
                    Type = dt.Rows[i]["Type"].ToString(),
                    ParentAgent = dt.Rows[i]["ParentAgent"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    CategorySizeId = dt.Rows[i]["CategorySizeId"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string InventoryDetailByProject(string ProjectId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventoryDetail";
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

            var SubUser = new List<ProjectInventoryDetailList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryDetailList
                {

                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    FileNoFrom = dt.Rows[i]["FileNoFrom"].ToString(),
                    FileNoTo = dt.Rows[i]["FileNoTo"].ToString(),
                    FileNo = dt.Rows[i]["FileNo"].ToString(),
                    ProjectLocationId = dt.Rows[i]["ProjectLocationId"].ToString(),
                    CustomerId = dt.Rows[i]["CustomerId"].ToString(),
                    InvertoryUnitId = dt.Rows[i]["InvertoryUnitId"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    NoteNo = dt.Rows[i]["NoteNo"].ToString(),
                    InvestorId = dt.Rows[i]["InvestorId"].ToString(),
                    Printed = dt.Rows[i]["Printed"].ToString(),
                    Type = dt.Rows[i]["Type"].ToString(),
                    ParentAgent = dt.Rows[i]["ParentAgent"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    CategorySizeId = dt.Rows[i]["CategorySizeId"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string InventoryDetailByParentAgent(string ParentAgent)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventoryDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ParentAgent", ParentAgent);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectInventoryDetailList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryDetailList
                {

                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    FileNoFrom = dt.Rows[i]["FileNoFrom"].ToString(),
                    FileNoTo = dt.Rows[i]["FileNoTo"].ToString(),
                    FileNo = dt.Rows[i]["FileNo"].ToString(),
                    ProjectLocationId = dt.Rows[i]["ProjectLocationId"].ToString(),
                    CustomerId = dt.Rows[i]["CustomerId"].ToString(),
                    InvertoryUnitId = dt.Rows[i]["InvertoryUnitId"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    NoteNo = dt.Rows[i]["NoteNo"].ToString(),
                    InvestorId = dt.Rows[i]["InvestorId"].ToString(),
                    Printed = dt.Rows[i]["Printed"].ToString(),
                    Type = dt.Rows[i]["Type"].ToString(),
                    ParentAgent = dt.Rows[i]["ParentAgent"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    CategorySizeId = dt.Rows[i]["CategorySizeId"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string InventoryDetailByCategorySize(string CategorySizeId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetProjectInventoryDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@CategorySizeId", CategorySizeId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectInventoryDetailList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectInventoryDetailList
                {

                    ProjectInventoryDetailId = dt.Rows[i]["ProjectInventoryDetailId"].ToString(),
                    FileNoFrom = dt.Rows[i]["FileNoFrom"].ToString(),
                    FileNoTo = dt.Rows[i]["FileNoTo"].ToString(),
                    FileNo = dt.Rows[i]["FileNo"].ToString(),
                    ProjectLocationId = dt.Rows[i]["ProjectLocationId"].ToString(),
                    CustomerId = dt.Rows[i]["CustomerId"].ToString(),
                    InvertoryUnitId = dt.Rows[i]["InvertoryUnitId"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    NoteNo = dt.Rows[i]["NoteNo"].ToString(),
                    InvestorId = dt.Rows[i]["InvestorId"].ToString(),
                    Printed = dt.Rows[i]["Printed"].ToString(),
                    Type = dt.Rows[i]["Type"].ToString(),
                    ParentAgent = dt.Rows[i]["ParentAgent"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    CategorySizeId = dt.Rows[i]["CategorySizeId"].ToString(),

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
    /// <param name="SizeType"></param>
    /// <returns></returns>

    

    [WebMethod]
    public string CreateSizeType(string UserID, string SizeTypeDescription)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_SizeType";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@SizeTypeId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@SizeTypeDescription", SizeTypeDescription);
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
    public string UpdateSizeType(string UserID,string SizeTypeId, string SizeTypeDescription)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_SizeType";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@SizeTypeId", SizeTypeId);
            cmd.Parameters.AddWithValue("@SizeTypeDescription", SizeTypeDescription);
           

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }
    [WebMethod]
    public string GetSizeType()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetSizeType";
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

            var SubUser = new List<SizeTypeList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new SizeTypeList
                {
                    SizeTypeId = dt.Rows[i]["SizeTypeId"].ToString(),
                    SizeTypeDescription = dt.Rows[i]["SizeTypeDescription"].ToString(),
                    


                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetSizeTypeById(string SizeTypeId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetSizeType";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@SizeTypeId", SizeTypeId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ProjectLocationList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ProjectLocationList
                {
                    ProjectLocationId = dt.Rows[i]["ProjectLocationId"].ToString(),
                    ProjectLocation = dt.Rows[i]["ProjectLocation"].ToString(),


                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }





}

internal class SizeTypeList
{
    public string SizeTypeId { get; set; }
    public string SizeTypeDescription { get; set; }
}

internal class ProjectInventoryDetailList
{
    public string ProjectInventoryDetailId { get; set; }
    public string FileNoFrom { get; set; }
    public string FileNoTo { get; set; }
    public string FileNo { get; set; }
    public string ProjectLocationId { get; set; }
    public string CustomerId { get; set; }
    public string InvertoryUnitId { get; set; }
    public string Status { get; set; }
    public string NoteNo { get; set; }
    public string InvestorId { get; set; }
    public string Printed { get; set; }
    public string Type { get; set; }
    public string ParentAgent { get; set; }
    public string ProjectId { get; set; }
    public string CategorySizeId { get; set; }
    public string IsAllocated { get; internal set; }
}

internal class InvertoryUnitList
{
    public string InvertoryUnitId { get; set; }
    public string InventoryUnitName { get; set; }
}

internal class InvestorsAndAgentsList
{
    public string InvestorsAndAgentsId { get; set; }
    public string InvestorAndAgentName { get; set; }
    public string CNIC { get; set; }
    public string ContactPerson { get; set; }
    public string PhoneNo { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string Area { get; set; }
    public string OfficeLocation { get; set; }
    public string Remarks { get; set; }
}

internal class ProjectInventoryListNew
{
    public string SalePrice { get; set; }
    public string InventoryName { get; set; }
    public string InventoryCount { get; set; }
    public string NoteNo { get; set; }
    public string Characters { get; set; }
    public string InventoryDetails { get; set; }
    public string ProjectInventoryId { get; internal set; }
}

internal class BlockTypeCategorySizeList
{
    public string CategorySizeId { get; set; }
    public string BlockTypeCategoryId { get; set; }
    public string CategorySizeDescription { get; set; }
}

internal class BlockTypeCategoryList
{
    public string BlockTypeCategoryId { get; set; }
    public string BlockTypeId { get; set; }
    public string BlockTypeCategory { get; set; }
}

internal class PhasesBlockTypeList
{
    public string BlockTypeId { get; set; }
    public string BlockId { get; set; }
    public string BlockTypeName { get; set; }
}

internal class ProjectPhasesBlocksList
{
    public string PhaseBlocksId { get; set; }
    public string ProjectPhasesId { get; set; }
    public string Blocks { get; set; }
}

internal class ProjectPhasesList
{
    public string ProjectPhasesId { get; set; }
    public string ProjectId { get; set; }
    public string PhaseName { get; set; }
}

internal class ProjectLocationList
{
    public string ProjectLocationId { get; set; }
    public string ProjectLocation { get; set; }
}