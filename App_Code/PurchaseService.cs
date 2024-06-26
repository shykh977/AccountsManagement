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
/// Summary description for PurchaseService
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
 [System.Web.Script.Services.ScriptService]
public class PurchaseService : System.Web.Services.WebService
{

    public PurchaseService()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }


    /// <summary>
    /// 
    /// </summary>  
    /// <param name="Purchase"></param>
    /// <returns></returns>

    [WebMethod]
    public string CreatePurchase(string UserID, string SupplierId, string PurchaseDate, string PaymentType, string Details, float PaidAmount, float DueAmount)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_Purchase";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@PurchaseId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
            cmd.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmd.Parameters.AddWithValue("@Details", Details);
            cmd.Parameters.AddWithValue("@DueAmount", DueAmount);
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
    public string UpdatePurchase(string PurchaseId, string SupplierId, string PurchaseDate, string PaymentType, string Details, float PaidAmount, float DueAmount)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_Purchase";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@PurchaseId", PurchaseId);
            cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
            cmd.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);
            cmd.Parameters.AddWithValue("@PaymentType", PaymentType);
            cmd.Parameters.AddWithValue("@Details", Details);
            cmd.Parameters.AddWithValue("@DueAmount", DueAmount);
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
    public string GetPurchase()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetPurchase";
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

            var SubUser = new List<PurchaseList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new PurchaseList
                {
                    SupplierId = dt.Rows[i]["SupplierId"].ToString(),
                    PurchaseId = dt.Rows[i]["PurchaseId"].ToString(),
                    PurchaseDate = dt.Rows[i]["PurchaseDate"].ToString(),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    PaymentType = dt.Rows[i]["PaymentType"].ToString(),
                    Details = dt.Rows[i]["Details"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                    DueAmount = dt.Rows[i]["DueAmount"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }



    [WebMethod]
    public string GetPurchaseBySupplier(string SupplierId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetPurchase";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@SupplierId", SupplierId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<PurchaseList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new PurchaseList
                {
                    SupplierId = dt.Rows[i]["SupplierId"].ToString(),
                    PurchaseId = dt.Rows[i]["PurchaseId"].ToString(),
                    PurchaseDate = dt.Rows[i]["PurchaseDate"].ToString(),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    PaymentType = dt.Rows[i]["PaymentType"].ToString(),
                    Details = dt.Rows[i]["Details"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                    DueAmount = dt.Rows[i]["DueAmount"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetPurchaseByPurchase(string PurchaseId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetPurchase";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@PurchaseId", PurchaseId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<PurchaseList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new PurchaseList
                {
                    SupplierId = dt.Rows[i]["SupplierId"].ToString(),
                    PurchaseId = dt.Rows[i]["PurchaseId"].ToString(),
                    PurchaseDate = dt.Rows[i]["PurchaseDate"].ToString(),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    PaymentType = dt.Rows[i]["PaymentType"].ToString(),
                    Details = dt.Rows[i]["Details"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                    DueAmount = dt.Rows[i]["DueAmount"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }
    
    
    [WebMethod]
    public string GetPurchaseByPurchaseDate(DateTime PurchaseDate)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetPurchase";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@PurchaseDate", PurchaseDate);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<PurchaseList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new PurchaseList
                {
                    SupplierId = dt.Rows[i]["SupplierId"].ToString(),
                    PurchaseId = dt.Rows[i]["PurchaseId"].ToString(),
                    PurchaseDate = dt.Rows[i]["PurchaseDate"].ToString(),
                    InvoiceNo = dt.Rows[i]["InvoiceNo"].ToString(),
                    PaymentType = dt.Rows[i]["PaymentType"].ToString(),
                    Details = dt.Rows[i]["Details"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                    DueAmount = dt.Rows[i]["DueAmount"].ToString(),

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
    /// <param name="PurchaseDetail"></param>
    /// <returns></returns>

    [WebMethod]
    public string CreatePurchaseDetail(string UserID, string PurchaseId, string ItemInformation, string Qty, float Rates, float Total)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_Purchase";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@PurchaseDetailId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@PurchaseId", PurchaseId);
            cmd.Parameters.AddWithValue("@ItemInformation", ItemInformation);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Rates", Rates);
           
            cmd.Parameters.AddWithValue("@PaidAmount", Total);

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
    public string UpdatePurchaseDetail(string PurchaseDetailId, string PurchaseId, string ItemInformation, string Qty, float Rates, float Total)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_Purchase";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@PurchaseDetailId", PurchaseDetailId);
            cmd.Parameters.AddWithValue("@PurchaseId", PurchaseId);
            cmd.Parameters.AddWithValue("@ItemInformation", ItemInformation);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Rates", Rates);
            cmd.Parameters.AddWithValue("@PaidAmount", Total);
            //cmd.Parameters.AddWithValue("@InsertedBy", UserID);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string GetPurchaseDetail(string PurchaseId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetPurchaseDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@PurchaseId", PurchaseId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<PurchaseDetailList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new PurchaseDetailList
                {
                    PurchaseDetailId = dt.Rows[i]["PurchaseDetailId"].ToString(),
                    PurchaseId = dt.Rows[i]["PurchaseId"].ToString(),
                    ItemInformation = dt.Rows[i]["ItemInformation"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    Rates = dt.Rows[i]["Rates"].ToString(),
                    Total = dt.Rows[i]["Total"].ToString()
                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    [WebMethod]
    public string GetPurchaseDetailById(string PurchaseDetailId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetPurchaseDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@PurchaseDetailId", PurchaseDetailId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<PurchaseDetailList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new PurchaseDetailList
                {
                    PurchaseDetailId = dt.Rows[i]["PurchaseDetailId"].ToString(),
                    PurchaseId = dt.Rows[i]["PurchaseId"].ToString(),
                    ItemInformation = dt.Rows[i]["ItemInformation"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    Rates = dt.Rows[i]["Rates"].ToString(),
                    Total = dt.Rows[i]["Total"].ToString()
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
    /// <param name="Services Provide"></param>
    /// <returns></returns>
    /// 

    [WebMethod]
    public string CreateServicesProvide(string UserID, string ServiceName, string ServiceCharge, string ServiceDescription)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_ServicesProvide";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;

            //ServiceProvideId
            //ServiceName
            //ServiceCharge
            //ServiceDescription

            cmd.Parameters.AddWithValue("@ServiceProvideId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@ServiceName", ServiceName);
            cmd.Parameters.AddWithValue("@ServiceCharge", ServiceCharge);
            cmd.Parameters.AddWithValue("@ServiceDescription", ServiceDescription);            
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
    public string CreateServicesProvideDetail(string ServicesProvideId,
         string ServiceName,
         string Qty,
         string Charges,
         string ShippingCharges,
         string Total,
         string Discount,
         string GrandTotal

         )
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_ServicesProvideDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;

            cmd.Parameters.AddWithValue("@ServicesProvideDetailId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@ServicesProvideId", ServicesProvideId);
            cmd.Parameters.AddWithValue("@ServiceName", ServiceName);
            cmd.Parameters.AddWithValue("@Qty", Qty);            
            cmd.Parameters.AddWithValue("@Charges", Charges);           
            cmd.Parameters.AddWithValue("@ShippingCharges", ShippingCharges);
            cmd.Parameters.AddWithValue("@Total", Total);
            cmd.Parameters.AddWithValue("@Discount", Discount);
            cmd.Parameters.AddWithValue("@GrandTotal", GrandTotal);

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }


    [WebMethod]
    public string GetServicesProvide()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetServicesProvide";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            //cmd.Parameters.AddWithValue("@PurchaseId", PurchaseId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<ServiceDetailList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new ServiceDetailList
                {
                    ServiceProvideId = dt.Rows[i]["ServiceProvideId"].ToString(),
                    ServiceName = dt.Rows[i]["ServiceName"].ToString(),
                    ServiceCharge = dt.Rows[i]["ServiceCharge"].ToString(),
                    ServiceDescription = dt.Rows[i]["ServiceDescription"].ToString(),
                   
                    //ServiceProvideId
                    //CustomerId
                    //ServiceName
                    //ServiceCharge
                    //ServiceDescription



                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetServicesProvideById(string ServiceProvideId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetServicesProvide";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ServiceProvideId", ServiceProvideId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<PurchaseDetailList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new PurchaseDetailList
                {
                    PurchaseDetailId = dt.Rows[i]["PurchaseDetailId"].ToString(),
                    PurchaseId = dt.Rows[i]["PurchaseId"].ToString(),
                    ItemInformation = dt.Rows[i]["ItemInformation"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    Rates = dt.Rows[i]["Rates"].ToString(),
                    Total = dt.Rows[i]["Total"].ToString()
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
    /// <param name="Quotations"></param>
    /// <returns></returns>

    [WebMethod]
    public string CreateQuotations(string UserID, string CustomerId, string QuotationsDate, string QuotationsExpireDate, string Details, float PaidAmount, float DueAmount, float DiscountAmount)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_Quotations";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@QuotationsId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmd.Parameters.AddWithValue("@QuotationsDate", QuotationsDate);
            cmd.Parameters.AddWithValue("@QuotationsExpireDate", QuotationsExpireDate);
            cmd.Parameters.AddWithValue("@Details", Details);
            cmd.Parameters.AddWithValue("@DueAmount", DueAmount);
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
    public string UpdateQuotations(string QuotationsId, string CustomerId, string QuotationsDate, string QuotationsExpireDate, string Details, float PaidAmount, float DueAmount, float DiscountAmount)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_Quotations";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@QuotationsId", QuotationsId);
            cmd.Parameters.AddWithValue("@CustomerId", CustomerId);
            cmd.Parameters.AddWithValue("@QuotationsDate", QuotationsDate);
            cmd.Parameters.AddWithValue("@QuotationsExpireDate", QuotationsExpireDate);
            cmd.Parameters.AddWithValue("@Details", Details);
            cmd.Parameters.AddWithValue("@DueAmount", DueAmount);
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
    public string GetQuotations()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetQuotations";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            //cmd.Parameters.AddWithValue("@PurchaseDetailId", PurchaseDetailId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<QuotationsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new QuotationsList
                {
                    QuotationsId = dt.Rows[i]["QuotationsId"].ToString(),
                    CustomerId = dt.Rows[i]["CustomerId"].ToString(),
                    QuotationsDate = dt.Rows[i]["QuotationsDate"].ToString(),
                    QuotationsExpireDate = dt.Rows[i]["QuotationsExpireDate"].ToString(),
                    QuotationsNo = dt.Rows[i]["QuotationsNo"].ToString(),
                    PaymentType = dt.Rows[i]["PaymentType"].ToString(),
                    Details = dt.Rows[i]["Details"].ToString(),
                    DiscountAmount = dt.Rows[i]["DiscountAmount"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                    DueAmount = dt.Rows[i]["DueAmount"].ToString()

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }
    
    [WebMethod]
    public string GetQuotationsByCustomer(string CustomerId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetQuotations";
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

            var SubUser = new List<QuotationsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new QuotationsList
                {
                    QuotationsId = dt.Rows[i]["QuotationsId"].ToString(),
                    CustomerId = dt.Rows[i]["CustomerId"].ToString(),
                    QuotationsDate = dt.Rows[i]["QuotationsDate"].ToString(),
                    QuotationsExpireDate = dt.Rows[i]["QuotationsExpireDate"].ToString(),
                    QuotationsNo = dt.Rows[i]["QuotationsNo"].ToString(),
                    PaymentType = dt.Rows[i]["PaymentType"].ToString(),
                    Details = dt.Rows[i]["Details"].ToString(),
                    DiscountAmount = dt.Rows[i]["DiscountAmount"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                    DueAmount = dt.Rows[i]["DueAmount"].ToString(),

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetQuotationsById(string QuotationsId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetQuotations";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@QuotationsId", QuotationsId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<QuotationsList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new QuotationsList
                {
                    QuotationsId = dt.Rows[i]["QuotationsId"].ToString(),
                    CustomerId = dt.Rows[i]["CustomerId"].ToString(),
                    QuotationsDate = dt.Rows[i]["QuotationsDate"].ToString(),
                    QuotationsExpireDate = dt.Rows[i]["QuotationsExpireDate"].ToString(),
                    QuotationsNo = dt.Rows[i]["QuotationsNo"].ToString(),
                    PaymentType = dt.Rows[i]["PaymentType"].ToString(),
                    Details = dt.Rows[i]["Details"].ToString(),
                    DiscountAmount = dt.Rows[i]["DiscountAmount"].ToString(),
                    PaidAmount = dt.Rows[i]["PaidAmount"].ToString(),
                    DueAmount = dt.Rows[i]["DueAmount"].ToString(),

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
    /// <param name="QuotationsDetail"></param>
    /// <returns></returns>

    [WebMethod]
    public string CreateQuotationsDetail(string UserID, string QuotationsId, string ItemInformation, string Qty, float Rates, float Total)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_QuotationsDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@QuotationsDetailId", Guid.NewGuid());
            cmd.Parameters.AddWithValue("@QuotationsId", QuotationsId);
            cmd.Parameters.AddWithValue("@ItemInformation", ItemInformation);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Rates", Rates);

            cmd.Parameters.AddWithValue("@PaidAmount", Total);

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
    public string UpdateQuotationsDetail(string QuotationsDetailId, string QuotationsId, string ItemInformation, string Qty, float Rates, float Total)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "usp_Create_Update_QuotationsDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@QuotationsDetailId", QuotationsDetailId);
            cmd.Parameters.AddWithValue("@QuotationsId", QuotationsId);
            cmd.Parameters.AddWithValue("@ItemInformation", ItemInformation);
            cmd.Parameters.AddWithValue("@Qty", Qty);
            cmd.Parameters.AddWithValue("@Rates", Rates);

            cmd.Parameters.AddWithValue("@PaidAmount", Total);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }


    [WebMethod]
    public string GetQuotationsDetail()
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetQuotationsDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            //cmd.Parameters.AddWithValue("@PurchaseId", PurchaseId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<QuotationsDetaillList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new QuotationsDetaillList
                {
                    QuotationsDetailId = dt.Rows[i]["QuotationsDetailId"].ToString(),
                    QuotationsId = dt.Rows[i]["QuotationsId"].ToString(),
                    ItemInformation = dt.Rows[i]["ItemInformation"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    Rates = dt.Rows[i]["Rates"].ToString(),
                    Total = dt.Rows[i]["Total"].ToString()

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }

    [WebMethod]
    public string GetQuotationsDetailById(string QuotationsDetailId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetQuotationsDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@QuotationsDetailId", QuotationsDetailId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<QuotationsDetaillList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new QuotationsDetaillList
                {
                    QuotationsDetailId = dt.Rows[i]["QuotationsDetailId"].ToString(),
                    QuotationsId = dt.Rows[i]["QuotationsId"].ToString(),
                    ItemInformation = dt.Rows[i]["ItemInformation"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    Rates = dt.Rows[i]["Rates"].ToString(),
                    Total = dt.Rows[i]["Total"].ToString()

                };
                SubUser.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(SubUser);
            return myData;
        }

    }


    [WebMethod]
    public string GetQuotationsDetailByQuotations(string QuotationsId)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string spName = "GetQuotationsDetail";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@QuotationsId", QuotationsId);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var SubUser = new List<QuotationsDetaillList>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                var myCat = new QuotationsDetaillList
                {
                    QuotationsDetailId = dt.Rows[i]["QuotationsDetailId"].ToString(),
                    QuotationsId = dt.Rows[i]["QuotationsId"].ToString(),
                    ItemInformation = dt.Rows[i]["ItemInformation"].ToString(),
                    Qty = dt.Rows[i]["Qty"].ToString(),
                    Rates = dt.Rows[i]["Rates"].ToString(),
                    Total = dt.Rows[i]["Total"].ToString()

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
    public string CreateSuplier(
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
            cmd.Parameters.AddWithValue("@EntryType", "supplier");

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }

    }

    [WebMethod]
    public string UpdateSuplier(
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
    public string GetSuplier()
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
            cmd.Parameters.AddWithValue("@EntryType", "supplier");
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
    public string GetSuplierById(string InvestorsAndAgentsId)
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





}

internal class ServiceDetailList
{
    public string ServiceProvideId { get; set; }
    public string ServiceName { get; set; }
    public string ServiceCharge { get; set; }
    public string ServiceDescription { get; set; }
}

internal class QuotationsDetaillList
{
    public string QuotationsDetailId { get; set; }
    public string QuotationsId { get; set; }
    public string ItemInformation { get; set; }
    public string Qty { get; set; }
    public string Rates { get; set; }
    public string Total { get; set; }
}

internal class QuotationsList
{
    public string QuotationsId { get; set; }
    public string CustomerId { get; set; }
    public string QuotationsDate { get; set; }
    public string QuotationsExpireDate { get; set; }
    public string QuotationsNo { get; set; }
    public string PaymentType { get; set; }
    public string Details { get; set; }
    public string DiscountAmount { get; set; }
    public string PaidAmount { get; set; }
    public string DueAmount { get; set; }
}

internal class PurchaseDetailList
{
    public string PurchaseDetailId { get; set; }
    public string PurchaseId { get; set; }
    public string ItemInformation { get; set; }
    public string Qty { get; set; }
    public string Rates { get; set; }
    public string Total { get; set; }
}

internal class PurchaseList
{
    public string SupplierId { get; set; }
    public string PurchaseId { get; set; }
    public string PurchaseDate { get; set; }
    public string InvoiceNo { get; set; }
    public string PaymentType { get; set; }
    public string Details { get; set; }
    public string PaidAmount { get; set; }
    public string DueAmount { get; set; }
}