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
/// Summary description for Leads
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class MobileService : System.Web.Services.WebService
{

    public MobileService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectLocation()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectLocation";
        //cmd.Parameters.AddWithValue("@BusinessId", BusinessId);


        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectLocationById(string ProjectLocationId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectLocation";
        cmd.Parameters.AddWithValue("@ProjectLocationId", ProjectLocationId);


        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectLocationByProjectId(string ProjectId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectLocation";
        cmd.Parameters.AddWithValue("@ProjectId", ProjectId);

        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    //[WebMethod]
    //[ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    //public void GetProjects()
    //{
    //    System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

    //    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
    //    SqlCommand cmd = new SqlCommand();
    //    cmd.CommandType = CommandType.StoredProcedure;
    //    cmd.CommandText = "GetProjects";
    //   // cmd.Parameters.AddWithValue("@ProjectId", ProjectId);

    //    DataSet ds = new DataSet();
    //    DataTable dt = new DataTable();
    //    SqlDataAdapter da = new SqlDataAdapter(cmd);
    //    da.SelectCommand.Connection = con;
    //    da.Fill(dt);
    //    con.Close();

    //    List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
    //    Dictionary<string, object> row = null;
    //    foreach (DataRow rs in dt.Rows)
    //    {
    //        row = new Dictionary<string, object>();
    //        foreach (DataColumn col in dt.Columns)
    //        {
    //            row.Add(col.ColumnName, rs[col]);
    //        }
    //        rows.Add(row);
    //    }

    //    this.Context.Response.ContentType = "application/json; charset=utf-8";
    //    this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
    //    //return "Success";
    //}


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectsById(string ProjectId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjects";
        cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectsByLocation(string ProjectLocationId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjects";
        cmd.Parameters.AddWithValue("@ProjectLocationId", ProjectLocationId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectPhases()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectPhases";
        //cmd.Parameters.AddWithValue("@ProjectLocationId", ProjectLocationId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectPhasesById(string ProjectPhasesId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectPhases";
        cmd.Parameters.AddWithValue("@ProjectPhasesId", ProjectPhasesId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectPhasesByProject(string ProjectId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectPhases";
        cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetPhaseBlocks()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetPhaseBlocks";
        //cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetPhaseBlocksById(string PhaseBlocksId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetPhaseBlocks";
        cmd.Parameters.AddWithValue("@PhaseBlocksId", PhaseBlocksId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetPhaseBlocksByPhases(string ProjectPhasesId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetPhaseBlocks";
        cmd.Parameters.AddWithValue("@ProjectPhasesId", ProjectPhasesId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetPhaseBlockType()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetBlockType";
        //cmd.Parameters.AddWithValue("@ProjectPhasesId", ProjectPhasesId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetPhaseBlockTypeById(string BlockTypeId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetBlockType";
        cmd.Parameters.AddWithValue("@BlockTypeId", BlockTypeId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetPhaseBlockTypeByBlock(string BlockId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetBlockType";
        cmd.Parameters.AddWithValue("@BlockId", BlockId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetBlockTypeCategory()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetBlockTypeCategory";
       // cmd.Parameters.AddWithValue("@BlockId", BlockId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetBlockTypeCategoryById(string BlockTypeCategoryId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetBlockTypeCategory";
        cmd.Parameters.AddWithValue("@BlockTypeCategoryId", BlockTypeCategoryId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetBlockTypeCategoryByBlockType(string BlockTypeId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetBlockTypeCategory";
        cmd.Parameters.AddWithValue("@BlockTypeId", BlockTypeId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetBlockTypeCategorySize()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetCategorySize";
        //cmd.Parameters.AddWithValue("@BlockTypeId", BlockTypeId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetBlockTypeCategorySizeById(string CategorySizeId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetCategorySize";
        cmd.Parameters.AddWithValue("@CategorySizeId", CategorySizeId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetBlockTypeCategorySizeByTypeCategory(string BlockTypeCategoryId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetCategorySize";
        cmd.Parameters.AddWithValue("@BlockTypeCategoryId", BlockTypeCategoryId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectInventory(


      string OfficeLocationId,
      string ProjectId,
      string ProjectPhasesId,
      string PhaseBlocksId,
      string BlockTypeId,
      string BlockTypeCategoryId,
      string CategorySizeId)
    {


        if (OfficeLocationId == "") { OfficeLocationId = null; }
        if (ProjectPhasesId == "") { ProjectPhasesId = null; }
        if (PhaseBlocksId == "") { PhaseBlocksId = null; }
        if (BlockTypeId == "") { BlockTypeId = null; }
        if (BlockTypeCategoryId == "") { BlockTypeCategoryId = null; }
        if (CategorySizeId == "") { CategorySizeId = null; }
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventory";
        cmd.Parameters.AddWithValue("@OfficeLocationId", OfficeLocationId);
        cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
        cmd.Parameters.AddWithValue("@ProjectPhasesId", ProjectPhasesId);
        cmd.Parameters.AddWithValue("@PhaseBlocksId", PhaseBlocksId);
        cmd.Parameters.AddWithValue("@BlockTypeId", BlockTypeId);
        cmd.Parameters.AddWithValue("@BlockTypeCategoryId", BlockTypeCategoryId);
        cmd.Parameters.AddWithValue("@CategorySizeId", CategorySizeId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectInventoryById(string ProjectInventoryId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventory";
        cmd.Parameters.AddWithValue("@ProjectInventoryId", ProjectInventoryId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectInventoryByOfficeLocation(string OfficeLocationId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventory";
        cmd.Parameters.AddWithValue("@OfficeLocationId", OfficeLocationId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectInventoryByProject(string ProjectId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventory";
        cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectInventoryByPhaseBlocks(string PhaseBlocksId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventory";
        cmd.Parameters.AddWithValue("@PhaseBlocksId", PhaseBlocksId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectInventoryBySizeType(string SizeTypeId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventory";
        cmd.Parameters.AddWithValue("@SizeTypeId", SizeTypeId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInvestors()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInvestorsAndAgents";
        cmd.Parameters.AddWithValue("@EntryType", "Investor");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInvestorsById(string InvestorsAndAgentsId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInvestorsAndAgents";
        cmd.Parameters.AddWithValue("@InvestorsAndAgentsId", InvestorsAndAgentsId);
        cmd.Parameters.AddWithValue("@EntryType", "Investor");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAgents()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInvestorsAndAgents";
        cmd.Parameters.AddWithValue("@EntryType", "Agents");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetAgentsById(string InvestorsAndAgentsId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInvestorsAndAgents";
        cmd.Parameters.AddWithValue("@InvestorsAndAgentsId", InvestorsAndAgentsId);
        cmd.Parameters.AddWithValue("@EntryType", "Agents");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInvertoryUnit()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInvertoryUnit";
        
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInvertoryUnitById(string InvertoryUnitId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInvertoryUnit";
        cmd.Parameters.AddWithValue("@InvertoryUnitId", InvertoryUnitId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectInventoryDetail(string ProjectInventoryId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventoryDetail";
        cmd.Parameters.AddWithValue("@ProjectInventoryId", ProjectInventoryId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InventoryDetailProjectByLocation(string ProjectLocationId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventoryDetail";
        cmd.Parameters.AddWithValue("@ProjectLocationId", ProjectLocationId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InventoryDetailProjectByInvertoryUnit(string InvertoryUnitId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventoryDetail";
        cmd.Parameters.AddWithValue("@InvertoryUnitId", InvertoryUnitId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InventoryDetailById(string ProjectInventoryDetailId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventoryDetail";
        cmd.Parameters.AddWithValue("@ProjectInventoryDetailId", ProjectInventoryDetailId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InventoryDetailByInvestorId(string InvestorId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventoryDetail";
        cmd.Parameters.AddWithValue("@InvestorId", InvestorId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InventoryDetailByProject(string ProjectId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventoryDetail";
        cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }  
    
    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InventoryDetailByParentAgent(string ParentAgent)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventoryDetail";
        cmd.Parameters.AddWithValue("@ParentAgent", ParentAgent);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void InventoryDetailByCategorySize(string CategorySizeId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectInventoryDetail";
        cmd.Parameters.AddWithValue("@CategorySizeId", CategorySizeId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetSizeType()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetSizeType";
        //cmd.Parameters.AddWithValue("@CategorySizeId", CategorySizeId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetSizeTypeById(string SizeTypeId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetSizeType";
        cmd.Parameters.AddWithValue("@SizeTypeId", SizeTypeId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
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
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void AppLogin(string UserName, string Password)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = "select * from users where (username=@username or email=@username or cellno=@username) and password=@password";
        cmd.Parameters.AddWithValue("@username", UserName);
        cmd.Parameters.AddWithValue("@password", Password);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjects(string UserId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjects";
        cmd.Parameters.AddWithValue("@UserId", UserId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectBookingPlan(string ProjectId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectBookingPlan";
        cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void  GetProjectCustomers(string ProjectId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectCustomers";
        cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetServicesProvide()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetServicesProvide";
       // cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetSuplier()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInvestorsAndAgents";
        cmd.Parameters.AddWithValue("@EntryType", "supplier");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void getCashBankNewUI(string UserID, string type)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "showAccountsByUserID_forCashBank_NewUILevel5";
        cmd.Parameters.AddWithValue("@userid", UserID);
        cmd.Parameters.AddWithValue("@type", type);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryTransfer()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryTransfer";
       //cmd.Parameters.AddWithValue("@userid", UserID);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryAllocation()
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryAllocation";
        //cmd.Parameters.AddWithValue("@userid", UserID);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }
    //============================== Dasboard Service ========================

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void loadCatParent(string Type, string UserID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "loadCatParent";
        cmd.Parameters.AddWithValue("@userid", UserID);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void loadCatParentFilter(string Type, string UserID, string StartDate, string EndDate)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "loadCatParentFilter";
        cmd.Parameters.AddWithValue("@userid", UserID);
        cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
        cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }

    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void loadCatMain(string Type, string UserID, string CatParentID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "loadCatMain";
        cmd.Parameters.AddWithValue("@userid", UserID);
        cmd.Parameters.AddWithValue("@CatParentID", CatParentID);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void loadCatMainFilter(string Type, string UserID, string StartDate, string EndDate, string CatParentID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "loadCatMainFilter";
        cmd.Parameters.AddWithValue("@userid", UserID);
        cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
        cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
        cmd.Parameters.AddWithValue("@CatParentID", CatParentID);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void loadAccountsbyID(string SubCatID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "loadAccountsbyID_withBudget";
        cmd.Parameters.AddWithValue("@subcatid", SubCatID);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void loadAccountsbyIDFilter(string SubCatID, string StartDate, string EndDate)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "loadAccountsbyIDFilter_withBudget";
        cmd.Parameters.AddWithValue("@subcatid", SubCatID);
        cmd.Parameters.AddWithValue("@StartDate", StartDate);
        cmd.Parameters.AddWithValue("@EndDate", EndDate);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void loadCatbyID(string CatID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "loadSubCatbyID";
        cmd.Parameters.AddWithValue("catid", CatID);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void loadCatbyIDFilter(string CatID, string StartDate, string EndDate)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "loadSubCatbyIDFilter";
        cmd.Parameters.AddWithValue("catid", CatID);
        cmd.Parameters.AddWithValue("StartDate", StartDate);
        cmd.Parameters.AddWithValue("EndDate", EndDate);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void loadCat(string Type, string UserID, string CatMainID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "loadcat";
        cmd.Parameters.AddWithValue("@userid", UserID);
        cmd.Parameters.AddWithValue("@CatMainID", CatMainID);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }

    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void loadCatFilter(string Type, string UserID, string StartDate, string EndDate, string CatMainID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "loadCatFilter";
        cmd.Parameters.AddWithValue("@userid", UserID);
        cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
        cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
        cmd.Parameters.AddWithValue("@CatMainID", CatMainID);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }




    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void loadRP(string UserID, string StartDate, string EndDate)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "loadReceiptPaymentLevel5";
        cmd.Parameters.AddWithValue("@userid", UserID);
        cmd.Parameters.AddWithValue("@StartDate", StartDate);
        cmd.Parameters.AddWithValue("@EndDate", EndDate);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    //======================================== Sale Service ==========================================


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryAllocationByAllocatedTo(string AllocatedTo)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryAllocation";
        cmd.Parameters.AddWithValue("@AllocatedTo", AllocatedTo);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryAllocationByAllocatedToType(string AllocatedToType)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryAllocation";
        cmd.Parameters.AddWithValue("@AllocatedToType", AllocatedToType);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryAllocationById(string InventoryAllocationId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryAllocation";
        cmd.Parameters.AddWithValue("@InventoryAllocationId", InventoryAllocationId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryAllocationByInventoryNumber(string InventoryNumber)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryAllocation";
        cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryAllocationByOfficeLocationId(string OfficeLocationId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryAllocation";
        cmd.Parameters.AddWithValue("@OfficeLocationId", OfficeLocationId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryAllocationByProject(string ProjectId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryAllocation";
        cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryAllocationByProjectInventoryDetail(string ProjectInventoryDetailId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryAllocation";
        cmd.Parameters.AddWithValue("@ProjectInventoryDetailId", ProjectInventoryDetailId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryAllocationDetil(string ProjectInventoryDetailId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryAllocationDetil";
        cmd.Parameters.AddWithValue("@ProjectInventoryDetailId", ProjectInventoryDetailId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryByInventoryNumber(string InventoryNumber)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryTransfer";
        cmd.Parameters.AddWithValue("@InventoryNumber", InventoryNumber);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryDetail(string InventoryDetailId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryTransfer";
        cmd.Parameters.AddWithValue("@InventoryDetailId", InventoryDetailId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryTransferById(string InventoryTransferById)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryTransfer";
        cmd.Parameters.AddWithValue("@InventoryTransferId", InventoryTransferById);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetInventoryTransferByProject(string ProjectId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetInventoryTransfer";
        cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


     [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetProjectStaff(string ProjectId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetProjectStaff";
        cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetTrialBalance(string UserID, string StartDate, string EndDate, string ReportType)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GteTrialBalance";
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@ReportType", ReportType);
        cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
        cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetChaquesreports(string Type, string UserID, string ChequeType, string StartDate, string EndDate)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetClearedChaques";
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@Type", Type);
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@ChequeType", ChequeType);
        cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
        cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void getLedger(string UserID)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getLedger";
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@userid", UserID);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetUpCommingClearing(string Type, string UserID, string StartDate, string ChequeType, string EndDate)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GetUpCommingClearing";
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@Type", Type);
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@ChequeType", ChequeType);
        cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
        cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void getCashBank(string UserID, string type)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "showAccountsByUserID_forCashBank";
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@userid", UserID);
        cmd.Parameters.AddWithValue("@type", type);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }



    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void LoadTransacion_history_ledger(string Type, string UserID, string StartDate, string EndDate)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "LoadTransaction_History_Ledger";
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@Type", Type);
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
        cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void GetTrialBalanceByAccount(string UserID, string StartDate, string EndDate, string ReportType, string AccountId)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "GteTrialBalance";
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@UserID", UserID);
        cmd.Parameters.AddWithValue("@ReportType", ReportType);
        cmd.Parameters.AddWithValue("@AccountId", AccountId);
        cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
        cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }


    [WebMethod]
    [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
    public void getWorth(string UserID, string StartDate)
    {
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConStr"].ToString());
        SqlCommand cmd = new SqlCommand();
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.CommandText = "getWorth";
        cmd.CommandTimeout = 0;
        cmd.Parameters.AddWithValue("@userid", UserID);
        cmd.Parameters.AddWithValue("@StartDate", StartDate);
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        SqlDataAdapter da = new SqlDataAdapter(cmd);
        da.SelectCommand.Connection = con;
        da.Fill(dt);
        con.Close();

        List<Dictionary<string, object>> rows = new List<Dictionary<string, object>>();
        Dictionary<string, object> row = null;
        foreach (DataRow rs in dt.Rows)
        {
            row = new Dictionary<string, object>();
            foreach (DataColumn col in dt.Columns)
            {
                row.Add(col.ColumnName, rs[col]);
            }
            rows.Add(row);
        }

        this.Context.Response.ContentType = "application/json; charset=utf-8";
        this.Context.Response.Write(serializer.Serialize(new { Response = rows }));
        //return "Success";
    }

}

