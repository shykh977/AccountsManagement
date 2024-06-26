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
public class Leads : System.Web.Services.WebService
{

    public Leads()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    [WebMethod]
    public string CreateLeads(string ProjectId, string LeadFrom, string Firstname, string Lastname, string Address,
                                 string Cnic,string Contact,string Email)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "usp_Create_Update_Leads";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@LeadId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@LeadFrom", LeadFrom);
            cmd.Parameters.AddWithValue("@Firstname", Firstname);
            cmd.Parameters.AddWithValue("@Lastname", Lastname);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Cnic", Cnic);
            cmd.Parameters.AddWithValue("@Contact", Contact);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", "123");

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string UpdateLeads(string LeadId, string ProjectId, string LeadFrom, string Firstname, string Lastname, string Address,
                                 string Cnic, string Contact, string Email)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "usp_Create_Update_Leads";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@LeadId", LeadId);
            cmd.Parameters.AddWithValue("@ProjectId", ProjectId);
            cmd.Parameters.AddWithValue("@LeadFrom", LeadFrom);
            cmd.Parameters.AddWithValue("@Firstname", Firstname);
            cmd.Parameters.AddWithValue("@Lastname", Lastname);
            cmd.Parameters.AddWithValue("@Address", Address);
            cmd.Parameters.AddWithValue("@Cnic", Cnic);
            cmd.Parameters.AddWithValue("@Contact", Contact);
            cmd.Parameters.AddWithValue("@Email", Email);
            cmd.Parameters.AddWithValue("@Password", "123");

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }


    [WebMethod]
    public string DeleteLead(string LeadId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "DeleteLead";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@LeadId", LeadId);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();
        }
    }


    [WebMethod]
    public string GetLeads(string ProjectId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "GetLeads";
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

            var SubUser = new List<LeadsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new LeadsList
                {

                    LeadId = dt.Rows[i]["LeadId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    LeadFrom = dt.Rows[i]["LeadFrom"].ToString(),
                    Firstname = dt.Rows[i]["Firstname"].ToString(),
                    Lastname = dt.Rows[i]["Lastname"].ToString(),
                    Cnic = dt.Rows[i]["Cnic"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    Contact = dt.Rows[i]["Contact"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    IsAssigned = dt.Rows[i]["IsAssigned"].ToString(),



                };
                SubUser.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;

        }

    }


    [WebMethod]
    public string GetLeadsById(string LeadId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "GetLeads";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@LeadId", LeadId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<LeadsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new LeadsList
                {

                    LeadId = dt.Rows[i]["LeadId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    LeadFrom = dt.Rows[i]["LeadFrom"].ToString(),
                    Firstname = dt.Rows[i]["Firstname"].ToString(),
                    Lastname = dt.Rows[i]["Lastname"].ToString(),
                    Cnic = dt.Rows[i]["Cnic"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    Contact = dt.Rows[i]["Contact"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    IsAssigned = dt.Rows[i]["IsAssigned"].ToString(),
                    //Email
                    //Password
                    //Attachments
                };
                SubUser.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;

        }

    }



    [WebMethod]
    public string GetLeadsByDate(string Date)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "GetLeads";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@Date", Date);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<LeadsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new LeadsList
                {

                    LeadId = dt.Rows[i]["LeadId"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    LeadFrom = dt.Rows[i]["LeadFrom"].ToString(),
                    Firstname = dt.Rows[i]["Firstname"].ToString(),
                    Lastname = dt.Rows[i]["Lastname"].ToString(),
                    Cnic = dt.Rows[i]["Cnic"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    Contact = dt.Rows[i]["Contact"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    IsAssigned = dt.Rows[i]["IsAssigned"].ToString(),
                    //Email
                    //Password
                    //Attachments
                };
                SubUser.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;

        }

    }



    /////Assigned Leads
    ///

    [WebMethod]
    public string CreateAssigndLeads(string LeadId,string  SubUserId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "usp_Create_Update_AssigndLeads";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@AssigndLeadId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@LeadId", LeadId);
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
    public string UpdateAssigndLeads(string AssigndLeadId, string LeadId, string SubUserId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "usp_Create_Update_AssigndLeads";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@AssigndLeadId", AssigndLeadId);
            cmd.Parameters.AddWithValue("@LeadId", LeadId);
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
    public string DeleteAssignedLeads(string AssigndLeadId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "DeleteAssignedLeads";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@AssigndLeadId", AssigndLeadId);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();
        }
    }


    [WebMethod]
    public string UnAssignLead(string LeadId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "UnAssignLead";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@LeadId", LeadId);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();
        }
    }



    [WebMethod]
    public string GetAssignedLeads(string ProjectId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "GetAssignedLeads";
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

            var SubUser = new List<AssignedLeadsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new AssignedLeadsList
                {

                    SubUserName = dt.Rows[i]["SubUserName"].ToString(),
                    UserEmail = dt.Rows[i]["UserEmail"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    LeadFrom = dt.Rows[i]["LeadFrom"].ToString(),
                    Firstname = dt.Rows[i]["Firstname"].ToString(),
                    Lastname = dt.Rows[i]["Lastname"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    Cnic = dt.Rows[i]["Cnic"].ToString(),
                    Contact = dt.Rows[i]["Contact"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    LeadAssignedTime = dt.Rows[i]["LeadAssignedTime"].ToString(),

                    AssigndLeadId = dt.Rows[i]["AssigndLeadId"].ToString(),
                    LeadId = dt.Rows[i]["LeadId"].ToString(),
                    SubUserId = dt.Rows[i]["SubUserId"].ToString(),

                };
                SubUser.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;

        }

    }

    [WebMethod]
    public string GetAssignedLeadsByLead(string LeadId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "GetAssignedLeads";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@LeadId", LeadId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<AssignedLeadsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new AssignedLeadsList
                {

                    SubUserName = dt.Rows[i]["SubUserName"].ToString(),
                    UserEmail = dt.Rows[i]["UserEmail"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    LeadFrom = dt.Rows[i]["LeadFrom"].ToString(),
                    Firstname = dt.Rows[i]["Firstname"].ToString(),
                    Lastname = dt.Rows[i]["Lastname"].ToString(),
                    Cnic = dt.Rows[i]["Cnic"].ToString(),
                    Contact = dt.Rows[i]["Contact"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    LeadAssignedTime = dt.Rows[i]["LeadAssignedTime"].ToString(),

                    //Email
                    //Password
                    //Attachments
                };
                SubUser.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;

        }

    }

    [WebMethod]
    public string GetAssignedLeadsBySubUser(string SubUserId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "GetAssignedLeads";
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

            var SubUser = new List<AssignedLeadsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new AssignedLeadsList
                {

                    SubUserName = dt.Rows[i]["SubUserName"].ToString(),
                    UserEmail = dt.Rows[i]["UserEmail"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    LeadFrom = dt.Rows[i]["LeadFrom"].ToString(),
                    Firstname = dt.Rows[i]["Firstname"].ToString(),
                    Lastname = dt.Rows[i]["Lastname"].ToString(),
                    Cnic = dt.Rows[i]["Cnic"].ToString(),
                    Contact = dt.Rows[i]["Contact"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    LeadAssignedTime = dt.Rows[i]["LeadAssignedTime"].ToString(),
                    //Email
                    //Password
                    //Attachments
                };
                SubUser.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;

        }

    }



    [WebMethod]
    public string GetAssignedLeadsById(string AssigndLeadId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "GetAssignedLeads";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@AssigndLeadId", AssigndLeadId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<AssignedLeadsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new AssignedLeadsList
                {

                    SubUserName = dt.Rows[i]["SubUserName"].ToString(),
                    UserEmail = dt.Rows[i]["UserEmail"].ToString(),
                    ProjectId = dt.Rows[i]["ProjectId"].ToString(),
                    LeadFrom = dt.Rows[i]["LeadFrom"].ToString(),
                    Firstname = dt.Rows[i]["Firstname"].ToString(),
                    Lastname = dt.Rows[i]["Lastname"].ToString(),
                    Cnic = dt.Rows[i]["Cnic"].ToString(),
                    Contact = dt.Rows[i]["Contact"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    LeadAssignedTime = dt.Rows[i]["LeadAssignedTime"].ToString(),
                    //Email
                    //Password
                    //Attachments
                };
                SubUser.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;

        }

    }

    ////// LeadsFollow up

    [WebMethod]
    public string CreateLeadsFollowUp(string AssignedLeadId, string Remarks,string OfficeMeeting,string Status)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "usp_Create_Update_LeadsFollowUp";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@LeadsFollowUpId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@AssignedLeadId", AssignedLeadId);
            cmd.Parameters.AddWithValue("@Remarks", Remarks);
            cmd.Parameters.AddWithValue("@OfficeMeeting", OfficeMeeting);
            cmd.Parameters.AddWithValue("@Status", Status);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();
        }

    }
   
    
    [WebMethod]
    public string ChangeLeadsFollowUpStatus(string LeadsFollowUpId, string Status)
    {

        //LeadsFollowUpId
        //AssignedLeadId
        //Remarks
        //OfficeMeeting
        //Status
        //InsertedOn



        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "ChangeLeadsFollowUpStatus";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@LeadsFollowUpId", LeadsFollowUpId);
            
            cmd.Parameters.AddWithValue("@Status", Status);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();
        }

    }

    [WebMethod]
    public string GetLeadsFollowUp(string ProjectId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetLeadsFollowUp";
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

            var SubUser = new List<LeadsFollowUpList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new LeadsFollowUpList
                {
                    Firstname = dt.Rows[i]["Firstname"].ToString(),
                    Lastname = dt.Rows[i]["Lastname"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    Contact = dt.Rows[i]["Contact"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    LeadsFollowUpId = dt.Rows[i]["LeadsFollowUpId"].ToString(),
                    AssignedLeadId = dt.Rows[i]["AssignedLeadId"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                  
                    OfficeMeeting = Convert.ToDateTime( dt.Rows[i]["OfficeMeeting"]).ToString(),
                   
                    Status = dt.Rows[i]["Status"].ToString(),                    
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }
    }
    
    [WebMethod]
    public string GetLeadsFollowUpByAssignedLead(string AssignedLeadId)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetLeadsFollowUp";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@AssignedLeadId", AssignedLeadId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<LeadsFollowUpList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new LeadsFollowUpList
                {
                    Firstname = dt.Rows[i]["Firstname"].ToString(),
                    Lastname = dt.Rows[i]["Lastname"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    Contact = dt.Rows[i]["Contact"].ToString(),
                    Email = dt.Rows[i]["Email"].ToString(),
                    LeadsFollowUpId = dt.Rows[i]["LeadsFollowUpId"].ToString(),
                    AssignedLeadId = dt.Rows[i]["AssignedLeadId"].ToString(),
                    Remarks = dt.Rows[i]["Remarks"].ToString(),
                  
                    OfficeMeeting = Convert.ToDateTime( dt.Rows[i]["OfficeMeeting"]).ToString(),
                   
                    Status = dt.Rows[i]["Status"].ToString(),                    
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }
    }


    [WebMethod]
    public string CreateCustomerFromLead(string AssigndLeadId)
    {

        //LeadsFollowUpId
        //AssignedLeadId
        //Remarks
        //OfficeMeeting
        //Status
        //InsertedOn



        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "CreateCustomerFromLead";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@AssigndLeadId", AssigndLeadId);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();
        }

    }

}

internal class LeadsFollowUpList
{
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public string Email { get; set; }
    public string LeadsFollowUpId { get; set; }
    public string AssignedLeadId { get; set; }
    public string Remarks { get; set; }
    public string OfficeMeeting { get; set; }
    public string Status { get; set; }
}

internal class AssignedLeadsList
{
    public string SubUserName { get; set; }
    public string UserEmail { get; set; }
    public string ProjectId { get; set; }
    public string LeadFrom { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Cnic { get; set; }
    public string Contact { get; set; }
    public string Email { get; set; }
    public string LeadAssignedTime { get; set; }
    public string Address { get; internal set; }
    public string AssigndLeadId { get; internal set; }
    public string LeadId { get; internal set; }
    public string SubUserId { get; internal set; }
}

internal class LeadsList
{
    public string LeadId { get; set; }
    public string ProjectId { get; set; }
    public string LeadFrom { get; set; }
    public string Firstname { get; set; }
    public string Lastname { get; set; }
    public string Cnic { get; set; }
    public string Address { get; set; }
    public string Contact { get; set; }
    public string Email { get; set; }
    public string IsAssigned { get; internal set; }
}