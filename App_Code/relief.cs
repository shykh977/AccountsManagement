using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

/// <summary>
/// Summary description for relief
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class relief : System.Web.Services.WebService {

    public relief () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    public class Relief1
    {
        public string Sno { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public string CNIC { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Tehsil { get; set; }
        public string Village { get; set; }
        public string Gender { get; set; }
        public string Issued { get; set; }
        public string Status { get; set; }

    }

    [WebMethod]
    public string HelloWorld() {
        return "Hello World";
    }
    [WebMethod]
    [ScriptMethod]
    public List<Relief1> getReliefData(string userDistrict)
    {
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        var Major_Acc_List = new List<Relief1>();
        using (var con = new SqlConnection(cs))
        {

            //string msql = "select  (cast(year(newsdate) as varchar(4)) + ' ' +CONVERT(varchar(3), NewsDate, 100) +' ' + cast(day(newsdate) as varchar(2)) ) as NewsDate,NewsTitle, Replace(left([NewsDetail],300),',','@') as NewsDetail,NewsID from [Setup].[News] where status=1 order by newsdate ";
            string msql = "Select * from MergedDistrict where district='" + userDistrict + "'";


            var cmd = new SqlDataAdapter(msql, con);
            cmd.SelectCommand.CommandTimeout = 0;
            DataTable dt = new DataTable();
            cmd.Fill(dt);



            for (int i = 0; i < dt.Rows.Count; i++)

            {
                //string mBite = "";
                //if (DBNull.Value.Equals(dt.Rows[i]["NewsImage"]))
                //{ }
                //else
                //{  mBite = Convert.ToBase64String((byte[])dt.Rows[i]["NewsImage"]); }


                var Major_Acc_Current = new Relief1
                {
                    Sno = dt.Rows[i]["Sno"].ToString(),
                    Name = dt.Rows[i]["Name"].ToString(),
                    FatherName = dt.Rows[i]["FHNAME"].ToString(),
                    CNIC = dt.Rows[i]["CNIC"].ToString(),
                    Address = dt.Rows[i]["Address"].ToString(),
                    District = dt.Rows[i]["District"].ToString(),
                    Tehsil = dt.Rows[i]["Tehsil"].ToString(),
                    Status = dt.Rows[i]["Status"].ToString(),
                    Issued = dt.Rows[i]["Issued"].ToString(),
                    Gender = dt.Rows[i]["Gender"].ToString(),
                    Village = dt.Rows[i]["Village"].ToString(),



                    //NewsImage=   mBite,
                    //NewsImage= loadImage( dt.Rows[i]["NewsImage"].ToString()).Replace(",", "$-$"),
                    // SNo = dt.Rows[i]["SNo"].ToString(),


                };

                Major_Acc_List.Add(Major_Acc_Current);
            }
        }
        var js = new JavaScriptSerializer();
        //string myData = js.Serialize(Major_Acc_List);
        //Context.Response.Write(js.Serialize(Major_Acc_List)+']');
        //return Major_Acc_List;
        return Major_Acc_List;


    }

}
