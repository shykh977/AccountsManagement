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
using System.IO;
using System.Drawing;

/// <summary>
/// Summary description for Accounts
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class Accounts : System.Web.Services.WebService
{
    public class Category
    {
        public string CatId { get; set; }
        public string category { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public string Balance { get; set; }
        public string Balance2 { get; set; }
        public string ACount { get; set; }
        public string Main { get; set; }
        public string MainID { get; set; }
        public string Source { get; set; }
        public string Nature { get; set; }

    }
    public class Account
    {
        public string AccountID { get; set; }
        public string AccountTitle { get; set; }
        public string Color { get; set; }
        public string Icon { get; set; }
        public string CatColor { get; set; }
        public string CatIcon { get; set; }
        public string SubColor { get; set; }
        public string SubIcon { get; set; }
        public string DateofCreation { get; set; }
        public string ODR { get; set; }
        public string OCR { get; set; }
        public string Status { get; set; }
        public string CellNo { get; set; }
        public string Email { get; set; }
        public string SubCatID { get; set; }
        public string SubCatName { get; set; }
        public string CatID { get; set; }
        public string CatName { get; set; }
        public string Balance { get; set; }
        public string PaySource { get; set; }
        public string Inc { get; set; }
        public string Exp { get; set; }
        public string Tcount { get; set; }
        public string Balance2 { get; set; }
        public string Main { get; set; }
        public string data { get; set; }
        public string FullName { get; set; }
        public string Nature { get; set; }
        public string BudgetAmount { get; set; }



        public string CatPID { get; set; }
        public string CatPName { get; set; }
        public string CatMID { get; set; }
        public string CatMName { get; set; }




    }
    public class CashBank
    {
        public string AccID { get; set; }
        public string Title { get; set; }
        public double Limit { get; set; }
        public int Status { get; set; }
        public string Type { get; set; }
        public string Balance { get; set; }


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
        public string Vtype { get; set; }
        public string UserID { get; set; }
        public string SharedRead { get; set; }
        public string Opening { get; set; }
        public string Clicked { get; set; }
        public string UserName { get; set; }
        public string AccEmail { get; set; }
        public string AccCellNo { get; set; }
        public string Transferable { get; set; }
        public string TransferStatus { get; set; }
        public string Balance2 { get; set; }
        public string SortDate { get; set; }
        public string EndDate { get; set; }
        public string ActiveStatus { get; set; }
        public string DetailActiveStatus { get; set; }
        public string Highlighter { get; set; }
        public string Attachments { get; set; }
       
        public string ChaqueNo { get; internal set; }
        public string ChaqueDate { get; internal set; }
        public string ChaquePostedDate { get; internal set; }
        public string ChaqueClaringDate { get; internal set; }
        public string ChaqueStatus { get; internal set; }
        public string ChequeType { get; internal set; }
        public string Nature { get; internal set; }
    }
    public class RP
    {
        public string Receipt { get; set; }
        public string Payment { get; set; }
    }
    public class BudgetAccount
    {
        public string BudgetID { get; set; }
        public string AccountID { get; set; }
        public string AccountTitle { get; set; }
        public string budgetamount { get; set; }
        public string intrans { get; set; }
        public string inledger { get; set; }
        public string innetworth { get; set; }
        public string infullstatement { get; set; }
        public string inbalancesheet { get; set; }
        public string budgettype { get; set; }
        public string TotalAmount { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
    public Accounts()
    {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public string HelloWorld()
    {
        return "Hello World";
    }

    [WebMethod]
    public int AddCat(string Category,string mColor,string mIcon, string Type, string UserID)
    {
        var myCat = new Category();
        myCat.category = Category;
        myCat.Color = mColor;
        myCat.Icon = mIcon;
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {


                {
                    mSQL = "insert into CatExp (Category,Color,Icon,UserID,nature,CatMainID) values ('" + Category + "','" + mColor + "','" + mIcon + "','" + UserID + "','"+ Type + "','" + Guid.Parse("00000000-0000-0000-0000-000000000000") + "')";
                }

                SqlCommand cmd = new SqlCommand(mSQL, con);
                cmd.CommandTimeout = 0;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                return cmd.ExecuteNonQuery();
            }
            catch(Exception e)
            {
                return 0;

            }
           
        }
      
    }


    



    [WebMethod]

    public int AddCatMain(string Category, string mColor, string mIcon, string Type, string UserID, string CatParentID)
    {
        var myCat = new Category();
        myCat.category = Category;
        myCat.Color = mColor;
        myCat.Icon = mIcon;
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {


                {
                    mSQL = "insert into CatMain (CategoryMain,Color,Icon,UserID,nature,CatPID) values ('" + Category + "','" + mColor + "','" + mIcon + "','" + UserID + "','" + Type + "','" + CatParentID + "')";
                }

                SqlCommand cmd = new SqlCommand(mSQL, con);
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



    [WebMethod]

    public int AddCatParent(string Category, string mColor, string mIcon, string Type, string UserID)
    {
        var myCat = new Category();
        myCat.category = Category;
        myCat.Color = mColor;
        myCat.Icon = mIcon;
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {


                {
                    mSQL = "insert into CatParent (CategoryP,Color,Icon,UserID,nature) values ('" + Category + "','" + mColor + "','" + mIcon + "','" + UserID + "','" + Type + "')";
                }

                SqlCommand cmd = new SqlCommand(mSQL, con);
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





    [WebMethod]

    public string addAccount(string Title, string opDR, string opCR, string Email, string Mobile,    string mColor, string mIcon,  string SubCatId,string payrec, string incacc, string expacc, string Nature)
    {
        int payrec1 = 0; int incacc1 = 0; int expacc1=0;
        payrec1 = Convert.ToInt32(payrec);
        incacc1= Convert.ToInt32(incacc);
        expacc1= Convert.ToInt32(expacc);

        if (opDR == "")
        {
            opDR = "0";
        }
        if (opCR == "")
        {
            opCR = "0";
        }

        //////SIR FAROOQ
        //double opcr;
        //opcr = Double.TryParse("", out opcr) ? opcr : 0.00;
        //double opdr;
        //opdr = Double.TryParse("", out opdr) ? opdr : 0.00;
        //////SIR FAROOQ
        double opdr = Convert.ToDouble(opDR);
        double opcr = Convert.ToDouble(opCR);


        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {
                
                mSQL = "insert into AccountTitle (AccountTitle,Color,Icon,SubCatID,openingdebit,openingcredit,Email,CellNo,paysource,inc,exp,Nature) values ('" + Title + "','" + mColor + "','" + mIcon + "','" + SubCatId + "','"+opdr+ "','" + opcr + "','"+Email+"','"+Mobile+"','"+payrec1+ "','" + incacc1 + "','"+expacc1+ "','" + Nature + "')";
                SqlCommand cmd = new SqlCommand(mSQL, con);
                cmd.CommandTimeout = 0;
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                cmd.ExecuteNonQuery();
                return "Category Added";
            }
            catch (SqlException  e)
            {
                if (e.GetBaseException().GetType() == typeof(SqlException))
                {
                    string ErrMsg;
                    Int32 ErrorCode = e.Number;
                    switch (ErrorCode)
                    {
                        case 2627:  // Unique constraint error
                            {
                                ErrMsg = "Account Title Not Unique";
                                break;
                            }
                        case 547:   // Constraint check violation
                            {
                                ErrMsg = "Account Title Not Unique";
                                break;
                            }
                            
                        case 2601:  // Duplicated key row error
                            {
                                ErrMsg = "Account Title Not Unique";
                                break;
                            }
                        default:
                            {
                                ErrMsg = "Account Title Not Unique";
                                break;
                            }
                    }
                    return ErrMsg;
                }
                else
                {
                    return "Some Error/Issue Occurs";
                }
                

            }

        }

    }

    [WebMethod]

    public int AddSubCat(string Category, string mColor, string mIcon, string CatId,string Type)
    {
        
        
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {


             
                mSQL = "insert into SubCat (SubCatTitle,Color,Icon,CatID,Nature) values ('" + Category + "','" + mColor + "','" + mIcon + "','"+CatId+"','"+ Type + "')";
                SqlCommand cmd = new SqlCommand(mSQL, con);
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
    [WebMethod]

    public int addTransaction_WOAttach(string Source, string TrDate, string TrAccount, double Amount, string NarrationS,string NarrationT, string Type,string TType,string LID,string UserID)
    {
        string lid;
        if (LID == "None")
        {
             lid = Guid.NewGuid().ToString();
        }
        else
        {
            lid = LID;
        }
            
        int mR = 0;
        string mSQL1,mSQL2;
        string mSQL3 = "";
        string mSQL4 = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            if (Type == "R")
            {
                
                if(TType=="New")
                { 
                    mSQL1 = @"insert into Transactions (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid) values ('" + Source+"','"+TrDate+"','"+NarrationT+"','"+Amount+"',0,'"+lid+ "',1,'R','0','" + UserID + "') ";
                    mSQL2 = @"insert into Transactions (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid) values ('" + TrAccount + "','" + TrDate + "','" + NarrationS + "',0,'" + Amount + "','" + lid + "',1,'R','0','" + UserID + "') ";
                    mSQL3 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid) values ('" + Source + "','" + TrDate + "','" + NarrationT + "','" + Amount + "',0,'" + lid + "',1,'R','0','" + UserID + "') ";
                    mSQL4 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid) values ('" + TrAccount + "','" + TrDate + "','" + NarrationS + "',0,'" + Amount + "','" + lid + "',1,'R','0','" + UserID + "') ";

                }
                else
                {
                    mSQL1 = @"Update Transactions set AccountID='" + Source + "',TDate='" + TrDate + "',Narration='" + NarrationT + "',DR='" + Amount + "',CR=0,LID='" + lid + "',ActiveStatus=1,VoucherType='R',SharedRead='0' where Lid='" +lid +"' and cr=0";
                    mSQL2 = @"Update Transactions set AccountID='" + TrAccount + "',TDate='" + TrDate + "',Narration='" + NarrationS + "',DR=0,CR='" + Amount + "',LID='" + lid + "',ActiveStatus=1,VoucherType='R',SharedRead='0' where Lid='" + lid + "' and dr=0";

                    mSQL3 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid) values ('" + Source + "','" + TrDate + "','" + NarrationT + "','" + Amount + "',0,'" + lid + "',1,'R','0','" + UserID + "') ";
                    mSQL4 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid) values ('" + TrAccount + "','" + TrDate + "','" + NarrationS + "',0,'" + Amount + "','" + lid + "',1,'R','0','" + UserID + "') ";

                }


            }
            else
            {
                if (TType == "New")
                {
                    mSQL1 = @"insert into Transactions (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid) values ('" + Source + "','" + TrDate + "','" + NarrationT + "',0,'" + Amount + "','" + lid + "',1,'P','0','"+ UserID +"') ";
                    mSQL2 = @"insert into Transactions (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid) values ('" + TrAccount + "','" + TrDate + "','" + NarrationS + "','" + Amount + "',0,'" + lid + "',1,'P','0','" + UserID + "') ";
                    mSQL3 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid) values ('" + Source + "','" + TrDate + "','" + NarrationT + "',0,'" + Amount + "','" + lid + "',1,'P','0','" + UserID + "') ";
                    mSQL4 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid) values ('" + TrAccount + "','" + TrDate + "','" + NarrationS + "','" + Amount + "',0,'" + lid + "',1,'P','0','" + UserID + "') ";

                }
                else
                {
                    mSQL1 = @"Update Transactions set AccountID='" + TrAccount + "',TDate='" + TrDate + "',Narration='" + NarrationS + "',DR='" + Amount + "',CR=0,LID='" + lid + "',ActiveStatus=1,VoucherType='P',SharedRead='0' where Lid='" + lid + "' and cr=0";
                    mSQL2 = @"Update Transactions set AccountID='" + Source + "',TDate='" + TrDate + "',Narration='" + NarrationT + "',DR=0,CR='" + Amount + "',LID='" + lid + "',ActiveStatus=1,VoucherType='P',SharedRead='0' where Lid='" + lid + "' and dr=0";

                    mSQL3 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid) values ('" + Source + "','" + TrDate + "','" + NarrationT + "',0,'" + Amount + "','" + lid + "',1,'P','0','" + UserID + "') ";
                    mSQL4 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid) values ('" + TrAccount + "','" + TrDate + "','" + NarrationS + "','" + Amount + "',0,'" + lid + "',1,'P','0','" + UserID + "') ";

                }

            }

            SqlCommand cmd = new SqlCommand(mSQL1, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //mR = cmd.ExecuteNonQuery();
            mR = cmd.ExecuteNonQuery();
            cmd.CommandText = mSQL2;
            mR = mR + cmd.ExecuteNonQuery();
            if(mSQL3!="")
            {
                cmd.CommandText = mSQL3;
                cmd.ExecuteNonQuery();
                cmd.CommandText = mSQL4;
                cmd.ExecuteNonQuery();

            }
            return (mR);

        }

    }

    [WebMethod]
    public string loadRP(string UserID,string StartDate,string EndDate)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            
            string spName = "loadReceiptPaymentLevel5";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<RP>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new RP
                {
                    
                    Payment = (Convert.ToDouble(dt.Rows[i]["Payment"].ToString())).ToString("#########0.00"),//("#########"),
                    Receipt = (Convert.ToDouble(dt.Rows[i]["Receipt"].ToString())).ToString("#########0.00"),//("#########"),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }
    public string GetRequestHeaders()
    {
        HttpContext ctx = HttpContext.Current;
        if (ctx == null || ctx.Request == null || ctx.Request.Headers == null)
        {
            return string.Empty;
        }
        string headers = string.Empty;
        foreach (string header in ctx.Request.Headers.AllKeys)
        {
            string[] values = ctx.Request.Headers.GetValues(header);
            headers += string.Format("{0}: {1}", header, string.Join(",", values));
        }

        return headers;
    }
    [WebMethod]
    //public string loadCat(string Type, string UserID , string CatMainID)
    public string loadCat(string Type, string UserID )
    {

        //HttpContext ctx = HttpContext.Current;
        //if (ctx == null || ctx.Request == null || ctx.Request.Headers == null)
        //{
        //    return string.Empty;
        //}
        //string headers = string.Empty;
        //foreach (string header in ctx.Request.Headers.AllKeys)
        //{
        //    string[] values = ctx.Request.Headers.GetValues(header);
        //    headers += string.Format("{0}: {1}", header, string.Join(",", values));
        //}


        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            if (Type=="I")
            {
                mSQL = "select CatID, category,color,icon from CatInc where userid='"+UserID+"' order by Category";
            }
            else
            {
                mSQL = "select CatID, category,color,icon from CatExp where userid='" + UserID + "' order by Category";
            }
            string spName = "loadcat";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            // Change When 5 level Active
           // cmd.Parameters.AddWithValue("@CatMainID", CatMainID);
            sda.SelectCommand = cmd;
                DataTable dt = new DataTable();

          
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new  List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId= dt.Rows[i][0].ToString(),
                    category = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    Balance=  (Convert.ToDouble( dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("##,###,##"),
                    ACount = dt.Rows[i]["cnt"].ToString(),
                    Source = dt.Rows[i]["source"].ToString(),
                    Balance2 = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("#########0.00"),
                    Nature = dt.Rows[i]["nature"].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }





    [WebMethod]
    public string loadCatMain(string Type, string UserID, string CatParentID)
    {

        //HttpContext ctx = HttpContext.Current;
        //if (ctx == null || ctx.Request == null || ctx.Request.Headers == null)
        //{
        //    return string.Empty;
        //}
        //string headers = string.Empty;
        //foreach (string header in ctx.Request.Headers.AllKeys)
        //{
        //    string[] values = ctx.Request.Headers.GetValues(header);
        //    headers += string.Format("{0}: {1}", header, string.Join(",", values));
        //}


        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
             
            string spName = "loadCatMain";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@CatParentID", CatParentID);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i][0].ToString(),
                    category = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("##,###,##"),
                    ACount = dt.Rows[i]["cnt"].ToString(),
                    Source = dt.Rows[i]["source"].ToString(),
                    Balance2 = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("#########0.00"),
                    Nature = dt.Rows[i]["nature"].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }



    [WebMethod]
    public string loadCatParent(string Type, string UserID)
    {

        //HttpContext ctx = HttpContext.Current;
        //if (ctx == null || ctx.Request == null || ctx.Request.Headers == null)
        //{
        //    return string.Empty;
        //}
        //string headers = string.Empty;
        //foreach (string header in ctx.Request.Headers.AllKeys)
        //{
        //    string[] values = ctx.Request.Headers.GetValues(header);
        //    headers += string.Format("{0}: {1}", header, string.Join(",", values));
        //}


        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "loadCatParent";
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
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i][0].ToString(),
                    category = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("##,###,##"),
                    ACount = dt.Rows[i]["cnt"].ToString(),
                    Source = dt.Rows[i]["source"].ToString(),
                    Balance2 = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("#########0.00"),
                    Nature = dt.Rows[i]["nature"].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }





    [WebMethod]
    //public string loadCatFilter(string Type, string UserID, string StartDate, string EndDate, string CatMainID)
    public string loadCatFilter(string Type, string UserID, string StartDate, string EndDate)
    {

        
           
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            if (Type == "I")
            {
                mSQL = "select CatID, category,color,icon from CatInc where userid='" + UserID + "' order by Category";
            }
            else
            {
                mSQL = "select CatID, category,color,icon from CatExp where userid='" + UserID + "' order by Category";
            }
            string spName = "loadCatFilter";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
            cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
           // cmd.Parameters.AddWithValue("@CatMainID", CatMainID);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i][0].ToString(),
                    category = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i][4].ToString()) ).ToString("##,###,##"),
                    ACount = dt.Rows[i]["cnt"].ToString(),
                    Source = dt.Rows[i]["source"].ToString(),
                    Balance2 = (Convert.ToDouble(dt.Rows[i][4].ToString()) ).ToString("#########0.00"),
                    Nature = dt.Rows[i]["nature"].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }




    [WebMethod]
    public string loadCatMainFilter(string Type, string UserID, string StartDate, string EndDate, string CatParentID)
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
            //{
            //    mSQL = "select CatID, category,color,icon from CatExp where userid='" + UserID + "' order by Category";
            //}
            string spName = "loadCatMainFilter";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
            cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@CatParentID", CatParentID);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i][0].ToString(),
                    category = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i][4].ToString())).ToString("##,###,##"),
                    ACount = dt.Rows[i]["cnt"].ToString(),
                    Source = dt.Rows[i]["source"].ToString(),
                    Balance2 = (Convert.ToDouble(dt.Rows[i][4].ToString())).ToString("#########0.00"),
                    Nature = dt.Rows[i]["nature"].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }







    [WebMethod]
    public string loadCatParentFilter(string Type, string UserID, string StartDate, string EndDate)
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
            //{
            //    mSQL = "select CatID, category,color,icon from CatExp where userid='" + UserID + "' order by Category";
            //}
            string spName = "loadCatParentFilter";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
            cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i][0].ToString(),
                    category = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i][4].ToString())).ToString("##,###,##"),
                    ACount = dt.Rows[i]["cnt"].ToString(),
                    Source = dt.Rows[i]["source"].ToString(),
                    Balance2 = (Convert.ToDouble(dt.Rows[i][4].ToString())).ToString("#########0.00"),
                    Nature = dt.Rows[i]["nature"].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }






    [WebMethod]
    public string LoadCatforSharing(string owneruserid, string Shareduserid)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            
            string spName = "LoadCatforSharing";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@owneruserid", owneruserid);
            cmd.Parameters.AddWithValue("@Shareduserid", Shareduserid);
            
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i]["CatID"].ToString(),
                    category = dt.Rows[i]["Category"].ToString(),
                    Color = dt.Rows[i]["catcolor"].ToString(),
                    Icon = dt.Rows[i]["caticon"].ToString(),
                    Balance = "0",
                    ACount = dt.Rows[i]["totalsubcat"].ToString(),
                    Source = dt.Rows[i]["SharedCount"].ToString(),
                    Balance2 = "0",
                    Nature = "",

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }

    [WebMethod]

    public string loadAccounts(string Type, string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            if (Type == "I")
            {
                mSQL = "select CatID, category,color,icon from CatInc where userid='" + UserID + "' order by Category";

            }
            else
            {
                mSQL = "select CatID, category,color,icon from CatExp where userid='" + UserID + "' order by Category";
            }

            SqlDataAdapter sda = new SqlDataAdapter(mSQL, con);
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i][0].ToString(),
                    category = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }

    [WebMethod]
    public string BudgetAnalysisMonth(string AccountID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "BudgetAnalysisMonth";
            //
            //   mSQL = "select AccountID, AccountTitle,color,icon,DateofCreation,OpeningDebit,OpeningCredit,ActiveStatus,CellNo,Email,SubCatId from AccountTitle where SubCatID='" + SubCatID + "' order by AccountTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@AccountID", AccountID);
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {

                var myCat = new Account
                {

                    AccountID = dt.Rows[i]["AccountID"].ToString(),
                    
                    Balance = dt.Rows[i]["TAmount"].ToString(),
                    Main = dt.Rows[i]["FortheMonth"].ToString(),
                    
                    BudgetAmount = dt.Rows[i]["Amount"].ToString(),


                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }

    [WebMethod]
    public string BudgetAmountTillDate(string AccountID,string StartDate)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "BudgetAmountTillDate";
            //
            //   mSQL = "select AccountID, AccountTitle,color,icon,DateofCreation,OpeningDebit,OpeningCredit,ActiveStatus,CellNo,Email,SubCatId from AccountTitle where SubCatID='" + SubCatID + "' order by AccountTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@AccountID", AccountID);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {

                var myCat = new Account
                {

                    

                    Balance = dt.Rows[i]["balance2"].ToString(),
                    

                    BudgetAmount = dt.Rows[i]["budgetamount"].ToString(),


                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }


    [WebMethod]

    public string loadAccountsbyID(string SubCatID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "loadAccountsbyID_withBudget";
            //
         //   mSQL = "select AccountID, AccountTitle,color,icon,DateofCreation,OpeningDebit,OpeningCredit,ActiveStatus,CellNo,Email,SubCatId from AccountTitle where SubCatID='" + SubCatID + "' order by AccountTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@subcatid", SubCatID);
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                
                   var myCat = new Account
                {
                    
                    AccountID = dt.Rows[i][0].ToString(),
                    AccountTitle = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    DateofCreation=dt.Rows[i][4].ToString(),
                    ODR=dt.Rows[i][5].ToString(),
                    OCR=dt.Rows[i][6].ToString(),
                    Status=dt.Rows[i][7].ToString(),
                    CellNo=dt.Rows[i][8].ToString(),
                    Email=dt.Rows[i][9].ToString(),
                    SubCatID=dt.Rows[i][10].ToString(),
                    Balance= (Convert.ToDouble( dt.Rows[i]["Balance"].ToString())+ Convert.ToDouble(dt.Rows[i]["op"].ToString())).ToString("###,###,###0.00"),
                    Balance2 = (Convert.ToDouble(dt.Rows[i]["Balance"].ToString()) + Convert.ToDouble(dt.Rows[i]["op"].ToString())).ToString("#########0.00"),
                    Main  = dt.Rows[i]["SubCatTitle"].ToString(),
                    Exp = dt.Rows[i]["Exp"].ToString(),
                    Inc = dt.Rows[i]["Inc"].ToString(),
                    PaySource=  dt.Rows[i]["PaySource"].ToString(),
                    BudgetAmount = dt.Rows[i]["bAmount"].ToString(),


                   };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }

    [WebMethod]
    public string loadAccountsbyUserID(string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "loadAccountsbyUserID";
            //
            //   mSQL = "select AccountID, AccountTitle,color,icon,DateofCreation,OpeningDebit,OpeningCredit,ActiveStatus,CellNo,Email,SubCatId from AccountTitle where SubCatID='" + SubCatID + "' order by AccountTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@UserID", UserID);
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {

                var myCat = new Account
                {

                    AccountID = dt.Rows[i][0].ToString(),
                    AccountTitle = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    DateofCreation = dt.Rows[i][4].ToString(),
                    ODR = dt.Rows[i][5].ToString(),
                    OCR = dt.Rows[i][6].ToString(),
                    Status = dt.Rows[i][7].ToString(),
                    CellNo = dt.Rows[i][8].ToString(),
                    Email = dt.Rows[i][9].ToString(),
                    SubCatID = dt.Rows[i][10].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i]["Balance"].ToString()) + Convert.ToDouble(dt.Rows[i]["op"].ToString())).ToString("###,###,###0.00"),
                    Balance2 = (Convert.ToDouble(dt.Rows[i]["Balance"].ToString()) + Convert.ToDouble(dt.Rows[i]["op"].ToString())).ToString("#########0.00"),
                    Main = dt.Rows[i]["SubCatTitle"].ToString(),
                    Exp = dt.Rows[i]["Exp"].ToString(),
                    Inc = dt.Rows[i]["Inc"].ToString(),
                    PaySource = dt.Rows[i]["PaySource"].ToString(),
                    Nature= dt.Rows[i]["ACCNature"].ToString(),
                    BudgetAmount = dt.Rows[i]["Bamount"].ToString(),


                };

                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }


    [WebMethod]
    public string loadAccountsbyIDFilter(string SubCatID, string StartDate,string EndDate)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "loadAccountsbyIDFilter_withBudget";
            //
            //   mSQL = "select AccountID, AccountTitle,color,icon,DateofCreation,OpeningDebit,OpeningCredit,ActiveStatus,CellNo,Email,SubCatId from AccountTitle where SubCatID='" + SubCatID + "' order by AccountTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@subcatid", SubCatID);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {

                var myCat = new Account
                {

                    AccountID = dt.Rows[i][0].ToString(),
                    AccountTitle = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    DateofCreation = dt.Rows[i][4].ToString(),
                    ODR = dt.Rows[i][5].ToString(),
                    OCR = dt.Rows[i][6].ToString(),
                    Status = dt.Rows[i][7].ToString(),
                    CellNo = dt.Rows[i][8].ToString(),
                    Email = dt.Rows[i][9].ToString(),
                    SubCatID = dt.Rows[i][10].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i]["Balance"].ToString()) ).ToString("###,###,###0.00"),
                    Balance2 = (Convert.ToDouble(dt.Rows[i]["Balance"].ToString()) ).ToString("#########0.00"),
                    Main = dt.Rows[i]["SubCatTitle"].ToString(),
                    Exp = dt.Rows[i]["Exp"].ToString(),
                    Inc = dt.Rows[i]["Inc"].ToString(),
                    PaySource = dt.Rows[i]["PaySource"].ToString(),
                    BudgetAmount = dt.Rows[i]["Bamount"].ToString(),


                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }
    [WebMethod]
    public string loadAccountsbyUserIDFilter(string UserID, string StartDate, string EndDate)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "loadAccountsbyUserIDFilter";
            //
            //   mSQL = "select AccountID, AccountTitle,color,icon,DateofCreation,OpeningDebit,OpeningCredit,ActiveStatus,CellNo,Email,SubCatId from AccountTitle where SubCatID='" + SubCatID + "' order by AccountTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {

                var myCat = new Account
                {

                    AccountID = dt.Rows[i][0].ToString(),
                    AccountTitle = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    DateofCreation = dt.Rows[i][4].ToString(),
                    ODR = dt.Rows[i][5].ToString(),
                    OCR = dt.Rows[i][6].ToString(),
                    Status = dt.Rows[i][7].ToString(),
                    CellNo = dt.Rows[i][8].ToString(),
                    Email = dt.Rows[i][9].ToString(),
                    SubCatID = dt.Rows[i][10].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i]["Balance"].ToString())).ToString("###,###,###0.00"),
                    Balance2 = (Convert.ToDouble(dt.Rows[i]["Balance"].ToString())).ToString("#########0.00"),
                    Main = dt.Rows[i]["SubCatTitle"].ToString(),
                    Exp = dt.Rows[i]["Exp"].ToString(),
                    Inc = dt.Rows[i]["Inc"].ToString(),
                    PaySource = dt.Rows[i]["PaySource"].ToString(),
                    Nature = dt.Rows[i]["ACCNature"].ToString(),
                    BudgetAmount = dt.Rows[i]["Bamount"].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }


    [WebMethod]
 

    public string LoadAccountForChart_byID(string param, string AccountID, string SDate, string EDate)
    {
        
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "sp_AccountGraphData";
            //
            //   mSQL = "select AccountID, AccountTitle,color,icon,DateofCreation,OpeningDebit,OpeningCredit,ActiveStatus,CellNo,Email,SubCatId from AccountTitle where SubCatID='" + SubCatID + "' order by AccountTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.CommandTimeout = 0;
            
            cmd.Parameters.AddWithValue("@param", param);
            cmd.Parameters.AddWithValue("@AccountID", AccountID);
            cmd.Parameters.AddWithValue("@StartDate", SDate);
            cmd.Parameters.AddWithValue("@EndDate", EDate);
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {

                var myCat = new Account
                {

                    AccountID = dt.Rows[i]["accountid"].ToString(),
                    AccountTitle = dt.Rows[i]["accountTitle"].ToString(),
                    data = dt.Rows[i]["data"].ToString(),
                    ODR = dt.Rows[i]["dr"].ToString(),
                    OCR = dt.Rows[i]["cr"].ToString(),

                    Balance2 = (Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString())).ToString("#########"),
                    Main = dt.Rows[i]["accountTitle"].ToString(),
                    


                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }

    [WebMethod]
    public string getOpeningAccountsbyID(string AccountID,string StartDate, string EndDate)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "getOpeningAccountsbyID";
            //
            //   mSQL = "select AccountID, AccountTitle,color,icon,DateofCreation,OpeningDebit,OpeningCredit,ActiveStatus,CellNo,Email,SubCatId from AccountTitle where SubCatID='" + SubCatID + "' order by AccountTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@AccountID", AccountID);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Account
                {

                    AccountID = dt.Rows[i][0].ToString(),
                    AccountTitle = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    DateofCreation = dt.Rows[i][4].ToString(),
                    ODR = dt.Rows[i][5].ToString(),
                    OCR = dt.Rows[i][6].ToString(),
                    Status = dt.Rows[i][7].ToString(),
                    CellNo = dt.Rows[i][8].ToString(),
                    Email = dt.Rows[i][9].ToString(),
                    SubCatID = dt.Rows[i][10].ToString(),
                    PaySource = dt.Rows[i]["PaySource"].ToString(),
                    Inc= dt.Rows[i]["Inc"].ToString(),
                    Exp = dt.Rows[i]["Exp"].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i]["op"].ToString())).ToString(),
                    Tcount= dt.Rows[i]["cnt"].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }


    [WebMethod]
    public string getOpeningAccountsbyID_forSharing(string AccountID, string StartDate, string EndDate,string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "getOpeningAccountsbyID_forSharing";
            //
            //   mSQL = "select AccountID, AccountTitle,color,icon,DateofCreation,OpeningDebit,OpeningCredit,ActiveStatus,CellNo,Email,SubCatId from AccountTitle where SubCatID='" + SubCatID + "' order by AccountTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@AccountID", AccountID);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            cmd.Parameters.AddWithValue("@UserID", UserID);

            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Account
                {

                    AccountID = dt.Rows[i][0].ToString(),
                    AccountTitle = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    DateofCreation = dt.Rows[i][4].ToString(),
                    ODR = dt.Rows[i][5].ToString(),
                    OCR = dt.Rows[i][6].ToString(),
                    Status = dt.Rows[i][7].ToString(),
                    CellNo = dt.Rows[i][8].ToString(),
                    Email = dt.Rows[i][9].ToString(),
                    SubCatID = dt.Rows[i][10].ToString(),
                    PaySource = dt.Rows[i]["PaySource"].ToString(),
                    Inc = dt.Rows[i]["Inc"].ToString(),
                    Exp = dt.Rows[i]["Exp"].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i]["op"].ToString())).ToString(),
                    Tcount = dt.Rows[i]["cnt"].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }


    [WebMethod]
    public string getOwnerOfAccountsbyID(string AccountID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName = "getOwnerOfAccountsbyID";
            //
            //   mSQL = "select AccountID, AccountTitle,color,icon,DateofCreation,OpeningDebit,OpeningCredit,ActiveStatus,CellNo,Email,SubCatId from AccountTitle where SubCatID='" + SubCatID + "' order by AccountTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.CommandTimeout = 0;
            cmd.Parameters.AddWithValue("@AccountID", AccountID);
            
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Account
                {
                    //a.accountid,a.accounttitle,a.catid,a.category,a.subcatid,a.subcattitle,a.openingdebit,a.openingcredit,u.userid,u.UserName,u.cellno,u.email
                    AccountID = dt.Rows[i]["accountid"].ToString(),
                    AccountTitle = dt.Rows[i]["accounttitle"].ToString(),


                    ODR = dt.Rows[i]["openingdebit"].ToString(),
                    OCR = dt.Rows[i]["openingcredit"].ToString(),
                   
                    CellNo = dt.Rows[i]["cellno"].ToString(),
                    Email = dt.Rows[i]["email"].ToString(),
                    FullName = dt.Rows[i]["fullname"].ToString(),
                    Balance2 = dt.Rows[i]["currencycode"].ToString(),
                    



                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }
    
        [WebMethod]
    public string loadSubCatbyUserID(string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            var spName = "loadSubCatbyUserID";
            //mSQL = "select SubCatID, SubCatTitle,color,icon from SubCat where catid='" + CatID + "' order by SubCatTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("UserID", UserID);
            cmd.CommandTimeout = 0;
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i][0].ToString(),
                    category = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("##,###,##"),
                    ACount = dt.Rows[i]["cnt"].ToString(),
                    Main = dt.Rows[i]["Category"].ToString(),
                    Balance2 = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("#########0.00"),
                    MainID = dt.Rows[i]["CatID"].ToString(),
                    Nature= dt.Rows[i]["SubNature"].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }
    
        [WebMethod]
    public string loadSubCatbyUserIDFilter(string UserID, string StartDate, string EndDate)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            var spName = "loadSubCatbyUserIDFilter";
            //mSQL = "select SubCatID, SubCatTitle,color,icon from SubCat where catid='" + CatID + "' order by SubCatTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("UserID", UserID);
            cmd.Parameters.AddWithValue("StartDate", StartDate);
            cmd.Parameters.AddWithValue("EndDate", EndDate);
            cmd.CommandTimeout = 0;
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i][0].ToString(),
                    category = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i]["Balance"].ToString())).ToString("##,###,##"),
                    ACount = dt.Rows[i]["cnt"].ToString(),
                    Main = dt.Rows[i]["Category"].ToString(),
                    Balance2 = (Convert.ToDouble(dt.Rows[i]["Balance"].ToString())).ToString("#########0.00"),
                    MainID = dt.Rows[i]["CatID"].ToString(),
                    Nature = dt.Rows[i]["SubNature"].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }
    [WebMethod]
    public string loadCatbyID(string CatID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            var spName = "loadSubCatbyID";
            //mSQL = "select SubCatID, SubCatTitle,color,icon from SubCat where catid='" + CatID + "' order by SubCatTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("catid", CatID);
            cmd.CommandTimeout = 0;
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i][0].ToString(),
                    category = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("##,###,##"),
                    ACount = dt.Rows[i]["cnt"].ToString(),
                    Main = dt.Rows[i]["Category"].ToString(),
                    Balance2 = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("#########0.00"),
                    MainID = CatID,

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }

    [WebMethod]
    public string loadSubCat(string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            var spName = "loadSubCat";
            //mSQL = "select SubCatID, SubCatTitle,color,icon from SubCat where catid='" + CatID + "' order by SubCatTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("UserID", UserID);
            cmd.CommandTimeout = 0;
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i][0].ToString(),
                    category = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("##,###,##"),
                    ACount = dt.Rows[i]["cnt"].ToString(),
                    Main = dt.Rows[i]["Category"].ToString(),
                    Balance2 = (Convert.ToDouble(dt.Rows[i][4].ToString()) + Convert.ToDouble(dt.Rows[i][5].ToString())).ToString("#########0.00"),
                     

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }






    [WebMethod]
    public string loadCatbyIDFilter(string CatID,string StartDate,string EndDate)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            var spName = "loadSubCatbyIDFilter";
            //mSQL = "select SubCatID, SubCatTitle,color,icon from SubCat where catid='" + CatID + "' order by SubCatTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("catid", CatID);
            cmd.Parameters.AddWithValue("StartDate", StartDate);
            cmd.Parameters.AddWithValue("EndDate", EndDate);
            cmd.CommandTimeout = 0;
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i][0].ToString(),
                    category = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i]["Balance"].ToString())).ToString("##,###,##"),
                    ACount = dt.Rows[i]["cnt"].ToString(),
                    Main = dt.Rows[i]["Category"].ToString(),
                    Balance2 = (Convert.ToDouble(dt.Rows[i]["Balance"].ToString()) ).ToString("#########0.00"),
                    MainID = CatID,

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }

    [WebMethod]
    public string LoadSubCatforSharing(string owneruserid,string Shareduserid, string CatID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            var spName = "LoadSubCatforSharing";
            //mSQL = "select SubCatID, SubCatTitle,color,icon from SubCat where catid='" + CatID + "' order by SubCatTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;

            cmd.Parameters.AddWithValue("@catid", CatID);
            cmd.Parameters.AddWithValue("@owneruserid", owneruserid);
            cmd.Parameters.AddWithValue("@Shareduserid", Shareduserid);
            cmd.CommandTimeout = 0;
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i]["SubcatID"].ToString(),
                    category = dt.Rows[i]["SubcatTitle"].ToString(),
                    Color = dt.Rows[i]["subcatcolor"].ToString(),
                    Icon = dt.Rows[i]["subcaticon"].ToString(),
                    Balance = "0",
                    ACount = dt.Rows[i]["totalsubcat"].ToString(),
                    Main = dt.Rows[i]["Category"].ToString(),
                    Source = dt.Rows[i]["SharedCount"].ToString(),
                    Balance2 = "0",
                    MainID = CatID,

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }


    [WebMethod]
    public string LoadSubCatforSharingForLevel2(string owneruserid, string Shareduserid, string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            var spName = "LoadSubCatforSharingForLevel2";
            
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;

           
            cmd.Parameters.AddWithValue("@owneruserid", owneruserid);
            cmd.Parameters.AddWithValue("@Shareduserid", Shareduserid);
            //cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.CommandTimeout = 0;
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i]["SubcatID"].ToString(),
                    category = dt.Rows[i]["SubcatTitle"].ToString(),
                    Color = dt.Rows[i]["subcatcolor"].ToString(),
                    Icon = dt.Rows[i]["subcaticon"].ToString(),
                    Balance = "0",
                    ACount = dt.Rows[i]["totalsubcat"].ToString(),
                    Main = dt.Rows[i]["Category"].ToString(),
                    Source = dt.Rows[i]["SharedCount"].ToString(),
                    Balance2 = "0",
                    

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }



    [WebMethod]
    public string loadCatbyIDforCharts(string UserID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            var spName = "loadSubCatbyIDForCharts";
            //mSQL = "select SubCatID, SubCatTitle,color,icon from SubCat where catid='" + CatID + "' order by SubCatTitle";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("UserID", UserID);
            cmd.CommandTimeout = 0;
            sda.SelectCommand = cmd;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i]["SubCatID"].ToString(),
                    category = dt.Rows[i]["SubCatTitle"].ToString(),
                    Color = dt.Rows[i]["Color"].ToString(),
                    Icon = dt.Rows[i]["Icon"].ToString(),
                    Balance = (Convert.ToDouble(dt.Rows[i]["Balance"].ToString()) + Convert.ToDouble(dt.Rows[i]["Op"].ToString())).ToString("##,###,##"),
                    ACount = dt.Rows[i]["cnt"].ToString(),
                    Main= dt.Rows[i]["Category"].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }

    [WebMethod]

    public string getCashBank(string UserID,string type)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            mSQL = "select BankId as ID, BankName as Title, 'Bank' as Type, '0' as Limit, ";
            mSQL = mSQL + " isnull((Select ( sum(dr)-sum(cr)) from Transactions t where t.accountid=b.bankid),0) as Balance ";
            mSQL = mSQL + " from Banks b where userid='" + UserID + "'";
            mSQL = mSQL + " union";
            mSQL = mSQL + " select CashID as ID, AccountTitle as Title, 'Cash' as Type, Limit,";
            mSQL = mSQL + " isnull((Select ( sum(dr)-sum(cr)) from Transactions t where t.accountid=c.cashid),0) as Balance ";
            mSQL = mSQL + " from Cash c where userid='" + UserID + "'";


            var spName = "showAccountsByUserID_forCashBank";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@type", type);
            sda.SelectCommand = cmd;

            
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<CashBank>();
            for (int i = 0; i < dt.Rows.Count; i++)
                
              //  &#xf0a4
            {
                var myCat = new CashBank
                {
                    AccID = dt.Rows[i][0].ToString(),
                    Title = dt.Rows[i][1].ToString() ,
                    
                  //  Type = dt.Rows[i][2].ToString(),
                  //  Limit = Convert.ToDouble( dt.Rows[i][3].ToString()),
                    Balance= " &#xf0a4; " + "["+  (Convert.ToDouble(dt.Rows[i][6].ToString()) + Convert.ToDouble(dt.Rows[i][7].ToString())).ToString("###,####,##") + "]" ,

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }

    [WebMethod]

    public string getCashBankNewUI(string UserID, string type)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
           


            //var spName = "showAccountsByUserID_forCashBank_NewUILevel5";
            var spName = "showAccountsByUserID_forCashBank_NewUI";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@type", type);
            sda.SelectCommand = cmd;


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)
            //accountid,AccountName,SubCategory,subcatid,Category,catid,balance,op
            //  &#xf0a4
            {
                var myCat = new Account
                {
                    AccountID = dt.Rows[i]["accountid"].ToString(),
                    AccountTitle = dt.Rows[i]["AccountName"].ToString(),
                    SubCatID = dt.Rows[i]["subcatid"].ToString(),
                    SubCatName = dt.Rows[i]["SubCategory"].ToString(),
                    CatID = dt.Rows[i]["catid"].ToString(),
                    CatName = dt.Rows[i]["Category"].ToString(),


                    //CatPID = dt.Rows[i]["CatPID"].ToString(),
                    //CatPName = dt.Rows[i]["CategoryP"].ToString(),
                    //CatMID = dt.Rows[i]["CatMainID"].ToString(),
                    //CatMName = dt.Rows[i]["CategoryMain"].ToString(),



                    //  Type = dt.Rows[i][2].ToString(),
                    //  Limit = Convert.ToDouble( dt.Rows[i][3].ToString()),




                    Balance = type=="All"? " ":  "  [ " + (Convert.ToDouble(dt.Rows[i]["balance"].ToString()) + Convert.ToDouble(dt.Rows[i]["op"].ToString())).ToString("###,####,#0") + " ]",

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }

    [WebMethod]

    public string getCashBankNewUI_Budget(string UserID, string type)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {



            var spName = "showAccountsByUserID_forCashBank_NewUI_budget";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@type", type);
            sda.SelectCommand = cmd;


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)
            //accountid,AccountName,SubCategory,subcatid,Category,catid,balance,op
            //  &#xf0a4
            {
                var myCat = new Account
                {
                    AccountID = dt.Rows[i]["accountid"].ToString(),
                    AccountTitle = dt.Rows[i]["AccountName"].ToString(),
                    SubCatID = dt.Rows[i]["subcatid"].ToString(),
                    SubCatName = dt.Rows[i]["SubCategory"].ToString(),
                    CatID = dt.Rows[i]["catid"].ToString(),
                    CatName = dt.Rows[i]["Category"].ToString(),

                    //  Type = dt.Rows[i][2].ToString(),
                    //  Limit = Convert.ToDouble( dt.Rows[i][3].ToString()),
                    Balance = type == "All" ? " " : "  [" + (Convert.ToDouble(dt.Rows[i]["balance"].ToString()) + Convert.ToDouble(dt.Rows[i]["op"].ToString())).ToString("###,####,##") + "]",

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }
    [WebMethod]
    public string BudgetCheck(string UserID,string AccountID, string StartDate,string EndDate,string BudgetID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {



            var spName = "BudgetCheck";
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 0;
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@AccountID", AccountID);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            cmd.Parameters.AddWithValue("@EndDate", EndDate);
            cmd.Parameters.AddWithValue("@BudgetID", BudgetID);
            
            sda.SelectCommand = cmd;


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)
            //accountid,AccountName,SubCategory,subcatid,Category,catid,balance,op
            //  &#xf0a4
            {
                var myCat = new Account
                {
                    AccountID = "Found",
                    AccountTitle = "Found",
                    SubCatID = "Found",
                    SubCatName = "Found",
                    CatID = "Found",
                    CatName = "Found",

                    //  Type = dt.Rows[i][2].ToString(),
                    //  Limit = Convert.ToDouble( dt.Rows[i][3].ToString()),
                    //Balance = type == "All" ? " " : "  [" + (Convert.ToDouble(dt.Rows[i]["balance"].ToString()) + Convert.ToDouble(dt.Rows[i]["op"].ToString())).ToString("###,####,##") + "]",

                };
                expcat.Add(myCat);
            }
            if(dt.Rows.Count==0)
            {
                var myCat = new Account
                {
                    AccountID = "Not Found",
                    AccountTitle = "Not Found",
                    SubCatID = "Not Found",
                    SubCatName = "Not Found",
                    CatID = "Not Found",
                    CatName = "Not Found",

                    //  Type = dt.Rows[i][2].ToString(),
                    //  Limit = Convert.ToDouble( dt.Rows[i][3].ToString()),
                    //Balance = type == "All" ? " " : "  [" + (Convert.ToDouble(dt.Rows[i]["balance"].ToString()) + Convert.ToDouble(dt.Rows[i]["op"].ToString())).ToString("###,####,##") + "]",

                };
                expcat.Add(myCat);
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }
    [WebMethod]

    public string findCategory(string CatID,string Type)
    {

        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            if (Type=="I")
            {
                mSQL = "select CatID, category,color,icon from CatInc  where catID='" + CatID + "' order by Category";
            }
            
       
            else
            {
             mSQL = "select CatID, category,color,icon from CatExp  where catID='"+CatID+ "' order by Category";
            }
          
            SqlDataAdapter sda = new SqlDataAdapter(mSQL, con);
            DataTable dt = new DataTable();

            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i][0].ToString(),
                    category = dt.Rows[i][1].ToString(),
                    Color = dt.Rows[i][2].ToString(),
                    Icon = dt.Rows[i][3].ToString(),

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }

    }

    [WebMethod]
    public string loadTodayTrans(string Type,DateTime tDate,string userid)
    {

       
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
           

            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "getTodayTrans";
            cmd.CommandTimeout = 0;
           cmd.CommandText = spName;
           cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@TDate", tDate);
            cmd.Parameters.AddWithValue("@userid", userid);

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
                if (Convert.ToDouble(dt.Rows[i][0].ToString())>0)
                {
                    var myCat = new Transaction
                    {
                        TotalAmount = Convert.ToDouble(dt.Rows[i][0].ToString()).ToString("###,###,##"),
                        AccId = dt.Rows[i][1].ToString(),
                        AccTitle = dt.Rows[i][2].ToString(),
                        Icon = dt.Rows[i][3].ToString(),
                        Color = dt.Rows[i][4].ToString(),
                        Total = Convert.ToDouble(dt.Rows[i][5].ToString()).ToString("##,###,##"),
                        TodayPercent = ((Convert.ToDouble(dt.Rows[i][0].ToString()) / Convert.ToDouble(dt.Rows[i][5].ToString())) * 100).ToString("##.##") + "%",

                    };
                    expcat.Add(myCat);
                }
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }

    [WebMethod]
    public string getLedgerbyID(string AccID,string UserID)
    {

        var accid = AccID;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "getLedgerbyID";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@AccId", accid);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Transaction>();
            double bal1 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Transaction
                {
                    TDate = dt.Rows[i]["TDate"].ToString(),
                    Narration = dt.Rows[i]["Narration"].ToString(),
                    TransType = dt.Rows[i]["vouchertype"].ToString(),

                    TotalAmount = (Math.Abs(Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString()))).ToString("##,###,##"),
                    Total = Convert.ToDouble(dt.Rows[i]["Total"].ToString()).ToString("##,###,##"),
                    PaymentAmt = Convert.ToDouble(dt.Rows[i]["dr"].ToString()).ToString("##,###,##"),
                    ReceiptAmt = Convert.ToDouble(dt.Rows[i]["cr"].ToString()).ToString("##,###,##"),
                    Sharing = dt.Rows[i]["Sharing"].ToString(),
                    Lid = dt.Rows[i]["lid"].ToString(),
                    Vtype= dt.Rows[i]["Vtype"].ToString(),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    SharedRead = dt.Rows[i]["SharedRead"].ToString(),
                    UserName = dt.Rows[i]["usertitle"].ToString(),
                    AccCellNo= dt.Rows[i]["AccCellNo"].ToString(),
                    AccEmail = dt.Rows[i]["AccEmail"].ToString(),


                };
                if(dt.Rows[i]["UserID"].ToString()== UserID || dt.Rows[i]["SharedRead"].ToString()=="3")
                bal1 =bal1 + Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString());


                expcat.Add(myCat);
            }
            for(int j=0;j<expcat.Count;j++)
            {
                expcat[j].Total = bal1.ToString("##,###,##");
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }


    [WebMethod]
    public string getLedgerbyID2(string AccID, string UserID, string StartDate, string EndDate)
    {

        var accid = AccID;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "getLedgerbyID2";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@AccId", accid);
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
            var expcat = new List<Transaction>();
            double bal1 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Transaction
                {
                    TDate = dt.Rows[i]["TDate"].ToString(),
                    Narration = dt.Rows[i]["Narration"].ToString().Replace("?</u>", "</u>"),
                    TransType = dt.Rows[i]["vouchertype"].ToString(),

                    TotalAmount = (Convert.ToDouble(dt.Rows[i]["Balance"])).ToString(),//+(Convert.ToDouble(dt.Rows[i]["dr"].ToString())- Convert.ToDouble(dt.Rows[i]["cr"].ToString()))).ToString(),
                    Total = Convert.ToDouble(dt.Rows[i]["Total"].ToString()).ToString("##,###,##.00"),
                    PaymentAmt = Convert.ToDouble(dt.Rows[i]["dr"].ToString()).ToString("##,###,##.00"),
                    ReceiptAmt = Convert.ToDouble(dt.Rows[i]["cr"].ToString()).ToString("##,###,##.00"),
                    Sharing = dt.Rows[i]["Sharing"].ToString(),
                    Lid = dt.Rows[i]["lid"].ToString(),
                    Vtype = dt.Rows[i]["Vtype"].ToString(),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    SharedRead = dt.Rows[i]["SharedRead"].ToString(),
                    UserName = dt.Rows[i]["usertitle"].ToString(),
                    AccCellNo = dt.Rows[i]["AccCellNo"].ToString(),
                    AccEmail = dt.Rows[i]["AccEmail"].ToString(),
                    Transferable = dt.Rows[i]["Transferable"].ToString(),
                    TransferStatus = dt.Rows[i]["TransferStatus"].ToString(),
                    EndDate = dt.Rows[i]["EndDate"].ToString(),

                };
                if (dt.Rows[i]["UserID"].ToString() == UserID || dt.Rows[i]["SharedRead"].ToString() == "3")
                    bal1 = bal1 + Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString());


                expcat.Add(myCat);
            }
            for (int j = 0; j < expcat.Count; j++)
            {
                expcat[j].Total = bal1.ToString("##,###,##");
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }


    [WebMethod]
    public string getLedgerbyID2_forShareing(string AccID, string UserID, string StartDate, string EndDate)
    {

        var accid = AccID;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "getLedgerbyID2_forShareing";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@AccId", accid);
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
            var expcat = new List<Transaction>();
            double bal1 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Transaction
                {
                    TDate = dt.Rows[i]["TDate"].ToString(),
                    Narration = dt.Rows[i]["Narration"].ToString().Replace("?</u>", "</u>"),
                    TransType = dt.Rows[i]["vouchertype"].ToString(),

                    TotalAmount = (Convert.ToDouble(dt.Rows[i]["Balance"])).ToString(),//+(Convert.ToDouble(dt.Rows[i]["dr"].ToString())- Convert.ToDouble(dt.Rows[i]["cr"].ToString()))).ToString(),
                    Total = Convert.ToDouble(dt.Rows[i]["Total"].ToString()).ToString("##,###,##.00"),
                    PaymentAmt = Convert.ToDouble(dt.Rows[i]["dr"].ToString()).ToString("##,###,##.00"),
                    ReceiptAmt = Convert.ToDouble(dt.Rows[i]["cr"].ToString()).ToString("##,###,##.00"),
                    Sharing = dt.Rows[i]["Sharing"].ToString(),
                    Lid = dt.Rows[i]["lid"].ToString(),
                    Vtype = dt.Rows[i]["Vtype"].ToString(),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    SharedRead = dt.Rows[i]["SharedRead"].ToString(),
                    UserName = dt.Rows[i]["usertitle"].ToString(),
                    AccCellNo = dt.Rows[i]["AccCellNo"].ToString(),
                    AccEmail = dt.Rows[i]["AccEmail"].ToString(),
                    Transferable = dt.Rows[i]["Transferable"].ToString(),
                    TransferStatus = dt.Rows[i]["TransferStatus"].ToString(),
                    EndDate = dt.Rows[i]["EndDate"].ToString(),
                    Highlighter=dt.Rows[i]["highlighter"].ToString(),
                    Attachments = dt.Rows[i]["Attachments"].ToString(),

                };
                if (dt.Rows[i]["UserID"].ToString() == UserID || dt.Rows[i]["SharedRead"].ToString() == "3")
                    bal1 = bal1 + Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString());


                expcat.Add(myCat);
            }
            for (int j = 0; j < expcat.Count; j++)
            {
                expcat[j].Total = bal1.ToString("##,###,##");
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }


    //public string getLedgerbyID2(string AccID, string UserID,string StartDate,string EndDate)
    //{

    //    var accid = AccID;
    //    var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
    //    using (var con = new SqlConnection(cs))
    //    {


    //        SqlDataAdapter sda = new SqlDataAdapter();
    //        SqlCommand cmd = new SqlCommand();
    //        cmd.CommandType = CommandType.StoredProcedure;
    //        cmd.Connection = con;
    //        string spName = "getLedgerbyID2";
    //        cmd.CommandTimeout = 0;
    //        cmd.CommandText = spName;
    //        cmd.Parameters.AddWithValue("@AccId", accid);
    //        cmd.Parameters.AddWithValue("@UserID", UserID);
    //        cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
    //        cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
    //        sda.SelectCommand = cmd;

    //        DataTable dt = new DataTable();



    //        if (con.State == ConnectionState.Closed)
    //        {
    //            con.Open();
    //        }
    //        sda.Fill(dt);
    //        var expcat = new List<Transaction>();
    //        double bal1 = 0;
    //        for (int i = 0; i < dt.Rows.Count; i++)

    //        {
    //            var myCat = new Transaction
    //            {
    //                TDate = dt.Rows[i]["TDate"].ToString(),
    //                Narration = dt.Rows[i]["Narration"].ToString(),
    //                TransType = dt.Rows[i]["vouchertype"].ToString(),

    //                TotalAmount = (Math.Abs(Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString()))).ToString("##,###,##"),
    //                Total = Convert.ToDouble(dt.Rows[i]["Total"].ToString()).ToString("##,###,##"),
    //                PaymentAmt = Convert.ToDouble(dt.Rows[i]["dr"].ToString()).ToString("##,###,##"),
    //                ReceiptAmt = Convert.ToDouble(dt.Rows[i]["cr"].ToString()).ToString("##,###,##"),
    //                Sharing = dt.Rows[i]["Sharing"].ToString(),
    //                Lid = dt.Rows[i]["lid"].ToString(),
    //                Vtype = dt.Rows[i]["Vtype"].ToString(),
    //                UserID = dt.Rows[i]["UserID"].ToString(),
    //                SharedRead = dt.Rows[i]["SharedRead"].ToString(),
    //                UserName = dt.Rows[i]["usertitle"].ToString(),
    //                AccCellNo = dt.Rows[i]["AccCellNo"].ToString(),
    //                AccEmail = dt.Rows[i]["AccEmail"].ToString(),
    //                Transferable= dt.Rows[i]["Transferable"].ToString(),
    //                TransferStatus = dt.Rows[i]["TransferStatus"].ToString(),

    //            };
    //            if (dt.Rows[i]["UserID"].ToString() == UserID || dt.Rows[i]["SharedRead"].ToString() == "3")
    //                bal1 = bal1 + Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString());


    //            expcat.Add(myCat);
    //        }
    //        for (int j = 0; j < expcat.Count; j++)
    //        {
    //            expcat[j].Total = bal1.ToString("##,###,##");
    //        }
    //        var js = new JavaScriptSerializer();
    //        string myData = js.Serialize(expcat);
    //        return myData;

    //    }
    //}


    [WebMethod]
    public string LoadTransacion_history_ledger (string Type, string UserID, string StartDate, string EndDate)
    {

        //var accid = AccID;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "LoadTransaction_History_Ledger";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@Type", Type);
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
            var expcat = new List<Transaction>();
            double bal1 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Transaction
                {
                    TDate = dt.Rows[i]["TDate"].ToString(),
                    Narration = dt.Rows[i]["Narration"].ToString(),
                    TransType = dt.Rows[i]["vouchertype"].ToString(),

                    TotalAmount = (Math.Abs(Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString()))).ToString("##,###,##"),
                    Total = Convert.ToDouble(dt.Rows[i]["Total"].ToString()).ToString("##,###,##"),
                    PaymentAmt = Convert.ToDouble(dt.Rows[i]["dr"].ToString()).ToString("##,###,##"),
                    ReceiptAmt = Convert.ToDouble(dt.Rows[i]["cr"].ToString()).ToString("##,###,##"),
                    Sharing = dt.Rows[i]["Sharing"].ToString(),
                    Lid = dt.Rows[i]["lid"].ToString(),
                    Vtype = dt.Rows[i]["Vtype"].ToString(),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    AccTitle = dt.Rows[i]["AccountTitle"].ToString() ,
                    SharedRead= dt.Rows[i]["SharedRead"].ToString(),
                    Attachments = dt.Rows[i]["Attachments"].ToString(),



                };
                if (dt.Rows[i]["UserID"].ToString() == UserID || dt.Rows[i]["SharedRead"].ToString() == "3")
                    bal1 = bal1 + Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString());


                expcat.Add(myCat);
            }
            for (int j = 0; j < expcat.Count; j++)
            {
                expcat[j].Total = bal1.ToString("##,###,##");
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }

    [WebMethod]
    public string BudgetAccount_List(string UserID)
    {

        //var accid = AccID;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "BudgetAccount_List";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
          
            cmd.Parameters.AddWithValue("@UserID", UserID);
           
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<BudgetAccount>();
            double bal1 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new BudgetAccount
                {
                    BudgetID = dt.Rows[i]["BudgetID"].ToString(),
                    AccountID = dt.Rows[i]["AccountID"].ToString(),
                    AccountTitle = dt.Rows[i]["AccountTitle"].ToString(),
                    budgetamount = dt.Rows[i]["Amount"].ToString(),
                    budgettype = dt.Rows[i]["budgettype"].ToString(),
                    inbalancesheet = dt.Rows[i]["inbalancesheet"].ToString(),
                    infullstatement = dt.Rows[i]["infullstatment"].ToString(),
                    inledger = dt.Rows[i]["inledger"].ToString(),
                    innetworth = dt.Rows[i]["innetworth"].ToString(),
                    intrans = dt.Rows[i]["intrans"].ToString(),
                    StartDate = Convert.ToDateTime(dt.Rows[i]["StartDate"].ToString()).ToString("yyyy-MM-dd"),
                   EndDate = Convert.ToDateTime(dt.Rows[i]["EndDate"].ToString()).ToString("yyyy-MM-dd"),

                };
                
                    bal1 = bal1 + Convert.ToDouble(dt.Rows[i]["Amount"].ToString());


                expcat.Add(myCat);
            }
            for (int j = 0; j < expcat.Count; j++)
            {
                expcat[j].TotalAmount = bal1.ToString("############");
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }


    /// <summary>
    // Created By Nouman
    /// </summary>
    /// <param name="Type"></param>
    /// <param name="UserID"></param>
    /// <param name="StartDate"></param>
    /// <param name="EndDate"></param>
    /// <returns></returns>

    [WebMethod]
    public string GetUpCommingClearing(string Type, string UserID, string StartDate, string ChequeType,string EndDate)
    {

        //var accid = AccID;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "GetUpCommingClearing";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@ChequeType", ChequeType);
            cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
            cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Transaction>();
            double bal1 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Transaction
                {
                    TDate = dt.Rows[i]["TDate"].ToString(),
                    Narration = dt.Rows[i]["Narration"].ToString(),
                    TransType = dt.Rows[i]["vouchertype"].ToString(),

                    TotalAmount = (Math.Abs(Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString()))).ToString("##,###,##"),
                    Total = Convert.ToDouble(dt.Rows[i]["Total"].ToString()).ToString("##,###,##"),
                    PaymentAmt = Convert.ToDouble(dt.Rows[i]["dr"].ToString()).ToString("##,###,##"),
                    ReceiptAmt = Convert.ToDouble(dt.Rows[i]["cr"].ToString()).ToString("##,###,##"),
                    Sharing = dt.Rows[i]["Sharing"].ToString(),
                    Lid = dt.Rows[i]["lid"].ToString(),
                    Vtype = dt.Rows[i]["Vtype"].ToString(),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    AccTitle = dt.Rows[i]["AccountTitle"].ToString(),
                    SharedRead = dt.Rows[i]["SharedRead"].ToString(),
                    Attachments = dt.Rows[i]["Attachments"].ToString(),
                    
                    ChaqueNo              = dt.Rows[i]["ChaqueNo"].ToString(),
                    ChaqueDate            = Convert.ToDateTime( dt.Rows[i]["ChaqueDate"]).ToShortDateString(),
                    ChaquePostedDate      = Convert.ToDateTime(dt.Rows[i]["ChaquePostedDate"]).ToShortDateString(),
                    ChaqueClaringDate     = Convert.ToDateTime(dt.Rows[i]["ChaqueClaringDate"]).ToShortDateString(),
                    ChaqueStatus = dt.Rows[i]["ChaqueStatus"].ToString(),
                    ChequeType = dt.Rows[i]["ChequeType"].ToString(),

                };
                if (dt.Rows[i]["UserID"].ToString() == UserID || dt.Rows[i]["SharedRead"].ToString() == "3")
                    bal1 = bal1 + Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString());


                expcat.Add(myCat);
            }
            for (int j = 0; j < expcat.Count; j++)
            {
                expcat[j].Total = bal1.ToString("##,###,##");
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }

  
    [WebMethod]
    public string GetClearedChaques(string Type, string UserID,string ChequeType, string StartDate, string EndDate)
    {

        //var accid = AccID;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "GetClearedChaques";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@Type", Type);
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@ChequeType", ChequeType);
            cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
            cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Transaction>();
            double bal1 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Transaction
                {
                    TDate = dt.Rows[i]["TDate"].ToString(),
                    Narration = dt.Rows[i]["Narration"].ToString(),
                    TransType = dt.Rows[i]["vouchertype"].ToString(),

                    TotalAmount = (Math.Abs(Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString()))).ToString("##,###,##"),
                    Total = Convert.ToDouble(dt.Rows[i]["Total"].ToString()).ToString("##,###,##"),
                    PaymentAmt = Convert.ToDouble(dt.Rows[i]["dr"].ToString()).ToString("##,###,##"),
                    ReceiptAmt = Convert.ToDouble(dt.Rows[i]["cr"].ToString()).ToString("##,###,##"),
                    Sharing = dt.Rows[i]["Sharing"].ToString(),
                    Lid = dt.Rows[i]["lid"].ToString(),
                    Vtype = dt.Rows[i]["Vtype"].ToString(),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    AccTitle = dt.Rows[i]["AccountTitle"].ToString(),
                    SharedRead = dt.Rows[i]["SharedRead"].ToString(),
                    Attachments = dt.Rows[i]["Attachments"].ToString(),



                };
                if (dt.Rows[i]["UserID"].ToString() == UserID || dt.Rows[i]["SharedRead"].ToString() == "3")
                    bal1 = bal1 + Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString());


                expcat.Add(myCat);
            }
            for (int j = 0; j < expcat.Count; j++)
            {
                expcat[j].Total = bal1.ToString("##,###,##");
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }


    [WebMethod]
    public string GetTrialBalance(string UserID, string StartDate, string EndDate,string ReportType)
    {

        //var accid = AccID;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "GteTrialBalance";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@ReportType", ReportType);
            cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
            cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Transaction>();
            double bal1 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Transaction
                {
                    TDate = dt.Rows[i]["TDate"].ToString(),
                    Narration = dt.Rows[i]["Narration"].ToString(),
                    TransType = dt.Rows[i]["vouchertype"].ToString(),

                    TotalAmount = (Math.Abs(Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString()))).ToString("##,###,##"),
                    Total = Convert.ToDouble(dt.Rows[i]["Total"].ToString()).ToString("##,###,##"),
                    PaymentAmt = Convert.ToDouble(dt.Rows[i]["dr"].ToString()).ToString("##,###,##"),
                    ReceiptAmt = Convert.ToDouble(dt.Rows[i]["cr"].ToString()).ToString("##,###,##"),
                    Sharing = dt.Rows[i]["Sharing"].ToString(),
                    Lid = dt.Rows[i]["lid"].ToString(),
                    Vtype = dt.Rows[i]["Vtype"].ToString(),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    AccTitle = dt.Rows[i]["AccountTitle"].ToString(),
                    SharedRead = dt.Rows[i]["SharedRead"].ToString(),
                    Attachments = dt.Rows[i]["Attachments"].ToString(),

                    ChaqueNo = dt.Rows[i]["ChaqueNo"].ToString(),
                    ChaqueDate = Convert.ToDateTime(dt.Rows[i]["ChaqueDate"]).ToShortDateString(),
                    ChaquePostedDate = Convert.ToDateTime(dt.Rows[i]["ChaquePostedDate"]).ToShortDateString(),
                    ChaqueClaringDate = Convert.ToDateTime(dt.Rows[i]["ChaqueClaringDate"]).ToShortDateString(),
                    ChaqueStatus = dt.Rows[i]["ChaqueStatus"].ToString(),
                    ChequeType = dt.Rows[i]["ChequeType"].ToString(),
                    Nature = dt.Rows[i]["Nature"].ToString(),

                };
                if (dt.Rows[i]["UserID"].ToString() == UserID || dt.Rows[i]["SharedRead"].ToString() == "3")
                    bal1 = bal1 + Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString());


                expcat.Add(myCat);
            }
            for (int j = 0; j < expcat.Count; j++)
            {
                expcat[j].Total = bal1.ToString("##,###,##");
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }


    [WebMethod]
    public string GetTrialBalanceByAccount(string UserID, string StartDate, string EndDate, string ReportType, string AccountId)
    {

        //var accid = AccID;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "GteTrialBalance";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@UserID", UserID);
            cmd.Parameters.AddWithValue("@ReportType", ReportType);
            cmd.Parameters.AddWithValue("@AccountId", AccountId);
            cmd.Parameters.AddWithValue("@StartDate", StartDate + " 00:00:00");
            cmd.Parameters.AddWithValue("@EndDate", EndDate + " 23:59:59");
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Transaction>();
            double bal1 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Transaction
                {
                    TDate = dt.Rows[i]["TDate"].ToString(),
                    Narration = dt.Rows[i]["Narration"].ToString(),
                    TransType = dt.Rows[i]["vouchertype"].ToString(),

                    TotalAmount = (Math.Abs(Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString()))).ToString("##,###,##"),
                    Total = Convert.ToDouble(dt.Rows[i]["Total"].ToString()).ToString("##,###,##"),
                    
                    PaymentAmt = Convert.ToDouble(dt.Rows[i]["cr"].ToString()).ToString("##,###,##"),
                    ReceiptAmt = Convert.ToDouble(dt.Rows[i]["dr"].ToString()).ToString("##,###,##"),
                   
                    Sharing = dt.Rows[i]["Sharing"].ToString(),
                    Lid = dt.Rows[i]["lid"].ToString(),
                    Vtype = dt.Rows[i]["Vtype"].ToString(),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    AccTitle = dt.Rows[i]["AccountTitle"].ToString(),
                    SharedRead = dt.Rows[i]["SharedRead"].ToString(),
                    Attachments = dt.Rows[i]["Attachments"].ToString(),

                    ChaqueNo = dt.Rows[i]["ChaqueNo"].ToString(),
                    ChaqueDate = Convert.ToDateTime(dt.Rows[i]["ChaqueDate"]).ToShortDateString(),
                    ChaquePostedDate = Convert.ToDateTime(dt.Rows[i]["ChaquePostedDate"]).ToShortDateString(),
                    ChaqueClaringDate = Convert.ToDateTime(dt.Rows[i]["ChaqueClaringDate"]).ToShortDateString(),
                    ChaqueStatus = dt.Rows[i]["ChaqueStatus"].ToString(),
                    ChequeType = dt.Rows[i]["ChequeType"].ToString(),
                    Nature = dt.Rows[i]["Nature"].ToString(),

                };
                if (dt.Rows[i]["UserID"].ToString() == UserID || dt.Rows[i]["SharedRead"].ToString() == "3")
                    bal1 = bal1 + Convert.ToDouble(dt.Rows[i]["dr"].ToString()) - Convert.ToDouble(dt.Rows[i]["cr"].ToString());


                expcat.Add(myCat);
            }
            for (int j = 0; j < expcat.Count; j++)
            {
                expcat[j].Total = bal1.ToString("##,###,##");
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }




    /// <summary>
    /// END
    /// </summary>
    /// <param name="Type"></param>
    /// <param name="UserID"></param>
    /// <param name="StartDate"></param>
    /// <param name="EndDate"></param>
    /// <returns></returns>


    [WebMethod]
    public string GetsharedEntries(string Status, string UserID,string StartDate, string EndDate)
    {

        var accid = Status;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "GetsharedEntries";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@Status", accid);
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
            var expcat = new List<Transaction>();
            double bal1 = 0;
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Transaction
                {
                    TDate = dt.Rows[i]["TDate"].ToString(),
                    Narration = dt.Rows[i]["Narration"].ToString(),
                    TransType = dt.Rows[i]["vouchertype"].ToString(),

                    Balance2 = (Convert.ToDouble(dt.Rows[i]["Amount"].ToString())).ToString("############"),
                    TotalAmount = ( Convert.ToDouble(dt.Rows[i]["Amount"].ToString())).ToString("###,###,###,###"),
                    //Total = Convert.ToDouble(dt.Rows[i]["Total"].ToString()).ToString("##,###,##"),
                    Sharing = dt.Rows[i]["Sharing"].ToString(),
                    Lid = dt.Rows[i]["lid"].ToString(),
                    Vtype = dt.Rows[i]["VoucherType"].ToString(),
                    UserID = dt.Rows[i]["UserID"].ToString(),
                    SharedRead = dt.Rows[i]["NotificationStatus"].ToString(),
                    Clicked = dt.Rows[i]["Clicked"].ToString(),
                    UserName = dt.Rows[i]["UserTitle"].ToString(),
                    ActiveStatus= dt.Rows[i]["ActiveStatus"].ToString(),
                    DetailActiveStatus= dt.Rows[i]["DetailActiveStatus"].ToString(),
                };
                //if (dt.Rows[i]["UserID"].ToString() == UserID || dt.Rows[i]["SharedRead"].ToString() == "3")
                    bal1 = bal1 + Convert.ToDouble(dt.Rows[i]["Amount"].ToString());


                expcat.Add(myCat);
            }
            for (int j = 0; j < expcat.Count; j++)
            {
                expcat[j].Total = bal1.ToString("##,###,##");
            }
            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }

    public class LoadTransaction_Data
    {
        public string Tid { get; set; }
        public string AccId_Payment { get; set; }
        public string AccId_Cash { get; set; }
        //public string AccTitle { get; set; }
        //public string PaymentAmt { get; set; }
        public string Amount { get; set; }
       // public string Icon { get; set; }
        public string VoucherType { get; set; }
        //public string TotalAmount { get; set; }
       // public string Color { get; set; }
       // public string Total { get; set; }
       // public string TodayPercent { get; set; }
       // public string Balance { get; set; }
        public string TDate { get; set; }
        public string Narration { get; set; }
        public string AccId_CashT { get; set; }
        public string AccId_PaymentT { get; set; }
        public string Sharing { get; set; }
        public string Highlighter { get; set; }
        // public string Lid { get; set; }


       public string  TransectionId         { get; set; }
       public string  TransectionDate       { get; set; }
       public string  ChaqueNo              { get; set; }
       public string  ChaqueDate            { get; set; }
       public string  ChaquePostedDate      { get; set; }
       public string  ChaqueClaringDate     { get; set; }
       public string PaymentType { get; set; }
    }

    [WebMethod]
    public string LoadTransaction(string TransID, string TType, string UserID)
    {

        var lid = TransID;

        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            //string spName = "Select t.*,CONVERT(char(10), Tdate,126) LoadDate,a.accounttitle from [Transactions] t inner join accounttitle a on t.accountid=a.accountid  where t.LID=@LID and vouchertype='" + TType +"' order by cr";
            string spName = "LoadTransaction";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@LID", lid);
            cmd.Parameters.AddWithValue("@Type", TType);
            cmd.Parameters.AddWithValue("@userid", UserID);

            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<LoadTransaction_Data>();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            if (Convert.ToDouble(dt.Rows[0]["cr"].ToString()) == 0 && TType == "P")
            {
                var myCat = new LoadTransaction_Data
                {
                    TDate = dt.Rows[0]["LoadDate"].ToString(),
                    Narration = dt.Rows[0]["Narration"].ToString(),
                    VoucherType = dt.Rows[0]["vouchertype"].ToString(),
                    Amount = (Math.Abs(Convert.ToDouble(dt.Rows[0]["dr"].ToString()) - Convert.ToDouble(dt.Rows[0]["cr"].ToString()))).ToString("#######"),
                    Tid = dt.Rows[0]["LID"].ToString(),
                    AccId_Cash = dt.Rows[1]["AccountID"].ToString(),
                    AccId_CashT = dt.Rows[1]["AccountTitle"].ToString(),
                    AccId_Payment = dt.Rows[0]["AccountID"].ToString(),
                    AccId_PaymentT = dt.Rows[0]["AccountTitle"].ToString(),
                    Sharing = dt.Rows[0]["Status"].ToString(),
                    Highlighter = dt.Rows[0]["Highlighter"].ToString(),

                    TransectionId           = dt.Rows[0]["TransectionId"].ToString(),
                    TransectionDate         = Convert.ToDateTime( dt.Rows[0]["TransectionDate"]).ToShortDateString(),
                    ChaqueNo                = dt.Rows[0]["ChaqueNo"].ToString(),
                    ChaqueDate              = Convert.ToDateTime( dt.Rows[0]["ChaqueDate"]).ToShortDateString(),
                    ChaquePostedDate        = Convert.ToDateTime( dt.Rows[0]["ChaquePostedDate"]).ToShortDateString(),
                    ChaqueClaringDate       = Convert.ToDateTime(dt.Rows[0]["ChaqueClaringDate"]).ToShortDateString(),
                    PaymentType             = dt.Rows[0]["PaymentType"].ToString(),


                };

                expcat.Add(myCat);
            }
            else
            {
                var myCat = new LoadTransaction_Data
                {
                    TDate = dt.Rows[0]["LoadDate"].ToString(),
                    Narration = dt.Rows[0]["Narration"].ToString(),
                    VoucherType = dt.Rows[0]["vouchertype"].ToString(),
                    Amount = (Math.Abs(Convert.ToDouble(dt.Rows[0]["dr"].ToString()) - Convert.ToDouble(dt.Rows[0]["cr"].ToString()))).ToString("#######"),
                    Tid = dt.Rows[0]["LID"].ToString(),
                    AccId_Cash = dt.Rows[0]["AccountID"].ToString(),
                    AccId_CashT = dt.Rows[0]["AccountTitle"].ToString(),
                    AccId_Payment = dt.Rows[1]["AccountID"].ToString(),
                    AccId_PaymentT = dt.Rows[1]["AccountTitle"].ToString(),
                    Sharing = dt.Rows[0]["Status"].ToString(),
                    Highlighter = dt.Rows[0]["Highlighter"].ToString(),


                    TransectionId = dt.Rows[0]["TransectionId"].ToString(),
                    TransectionDate = Convert.ToDateTime(dt.Rows[0]["TransectionDate"]).ToShortDateString(),
                    ChaqueNo = dt.Rows[0]["ChaqueNo"].ToString(),
                    ChaqueDate = Convert.ToDateTime(dt.Rows[0]["ChaqueDate"]).ToShortDateString(),
                    ChaquePostedDate = Convert.ToDateTime(dt.Rows[0]["ChaquePostedDate"]).ToShortDateString(),
                    ChaqueClaringDate = Convert.ToDateTime(dt.Rows[0]["ChaqueClaringDate"]).ToShortDateString(),
                    PaymentType = dt.Rows[0]["PaymentType"].ToString(),

                };
                expcat.Add(myCat);
            }

            //}

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }



    public class LoadTransactionStatus_Data
    {
        public string NotificationID     { get; set; }
        public string Descrption         { get; set; }
        public string NotiDate           { get; set; }
        public string TransactionID      { get; set; }
        public string FromUserID         { get; set; }
        public string ToUserID           { get; set; }
        public string NotificationStatus { get; set; }
        public string Clicked            { get; set; }
        public string FromUserName { get; set; }
        public string ToUserName { get; set; }
        // public string Lid { get; set; }
    }
    [WebMethod]
    public string LoadTransactionStausDetail(string TransID, string UserID)
    {

        var lid = TransID;

        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            //string spName = "Select t.*,CONVERT(char(10), Tdate,126) LoadDate,a.accounttitle from [Transactions] t inner join accounttitle a on t.accountid=a.accountid  where t.LID=@LID and vouchertype='" + TType +"' order by cr";
            string spName = "LoadTransactionStausDetail";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@lid", lid);
            cmd.Parameters.AddWithValue("@userid", UserID);

            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<LoadTransactionStatus_Data>();

            for (int i = 0; i < dt.Rows.Count; i++)
            {
            
                var myCat = new LoadTransactionStatus_Data
                {
                     
                    NotificationID = dt.Rows[i]["NotificationID"].ToString(),
                    Descrption = dt.Rows[i]["Descrption"].ToString(),
                    NotiDate = Convert.ToDateTime(dt.Rows[i]["NotiDate"]).ToString("dd-MM-yyyy HH:mm:ss"),
                    TransactionID = dt.Rows[i]["TransactionID"].ToString(),
                    FromUserID = dt.Rows[i]["FromUserID"].ToString(),
                    ToUserID = dt.Rows[i]["ToUserID"].ToString(),
                    NotificationStatus = dt.Rows[i]["NotificationStatus"].ToString(),
                    FromUserName = dt.Rows[i]["FromUserName"].ToString(),
                    ToUserName = dt.Rows[i]["ToUserName"].ToString(),
                };

                expcat.Add(myCat);
            

            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }
    [WebMethod]
    public int deleteLedgerbyID(string Lid)
    {

        
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "deleteLedgerbyID";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@Lid", Lid);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.SelectCommand = cmd;
            return sda.SelectCommand.ExecuteNonQuery();
           



           
         
           
            

         
           

        }
    }
    [WebMethod]
    public string getLedger(string UserID)
    {


        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "getLedger";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            //cmd.Parameters.AddWithValue("@TDate", tDate);
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
                    Icon = dt.Rows[i][0].ToString(),
                    Color = dt.Rows[i][1].ToString(),
                    AccId = dt.Rows[i][2].ToString(),
                    AccTitle = dt.Rows[i]["AccountTitle"].ToString(), //+ " " + ( dt.Rows[i]["shared"].ToString() == "0" ? "" : "<i class='fa fa-users' > </i>"),
                    
                    PaymentAmt = Convert.ToDouble(dt.Rows[i][4].ToString()).ToString("##,###,##"),
                    ReceiptAmt = Convert.ToDouble(dt.Rows[i][5].ToString()).ToString("##,###,##"),
                    Balance = ((Convert.ToDouble(dt.Rows[i][5].ToString()) - Convert.ToDouble(dt.Rows[i][4].ToString()))+ (Convert.ToDouble(dt.Rows[i]["OpDB"].ToString()) - Convert.ToDouble(dt.Rows[i]["OpCr"].ToString()))).ToString("##,###,##"),
                    Balance2= ((Convert.ToDouble(dt.Rows[i][5].ToString()) - Convert.ToDouble(dt.Rows[i][4].ToString())) + (Convert.ToDouble(dt.Rows[i]["OpDB"].ToString()) - Convert.ToDouble(dt.Rows[i]["OpCr"].ToString()))).ToString(),
                    Sharing = dt.Rows[i]["shared"].ToString(),
                   Opening= (Convert.ToDouble(dt.Rows[i]["OpDB"].ToString()) - Convert.ToDouble(dt.Rows[i]["OpCr"].ToString())).ToString("##,###,##"),
                    // Icon = Convert.ToDouble(dt.Rows[i][0].ToString()).ToString("###,###,##"),
                    UserID = dt.Rows[i]["userid"].ToString(),
                    SortDate = dt.Rows[i]["entrydate"].ToString(),
                    // Total = Convert.ToDouble(dt.Rows[i][5].ToString()),
                    // TodayPercent = ((Convert.ToDouble(dt.Rows[i][0].ToString()) / Convert.ToDouble(dt.Rows[i][5].ToString())) * 100).ToString("##.##") + "%",

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }
    [WebMethod]
    public string getLedgerRev(string UserID)
    {


        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "getLedger";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            //cmd.Parameters.AddWithValue("@TDate", tDate);
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
                    Icon = dt.Rows[i][0].ToString(),
                    Color = dt.Rows[i][1].ToString(),
                    AccId = dt.Rows[i][2].ToString(),
                    AccTitle = dt.Rows[i]["AccountTitle"].ToString(), //+ " " + ( dt.Rows[i]["shared"].ToString() == "0" ? "" : "<i class='fa fa-users' > </i>"),

                    PaymentAmt = Convert.ToDouble(dt.Rows[i][4].ToString()).ToString("##,###,##"),
                    ReceiptAmt = Convert.ToDouble(dt.Rows[i][5].ToString()).ToString("##,###,##"),
                    Balance = ( Convert.ToDouble(dt.Rows[i][4].ToString())- (Convert.ToDouble(dt.Rows[i][5].ToString())) + (Convert.ToDouble(dt.Rows[i]["OpDB"].ToString()) - Convert.ToDouble(dt.Rows[i]["OpCr"].ToString()))).ToString("###,###,###,##0"),
                    Balance2 = (  Convert.ToDouble(dt.Rows[i][4].ToString()) - (Convert.ToDouble(dt.Rows[i][5].ToString())) + (Convert.ToDouble(dt.Rows[i]["OpDB"].ToString()) - Convert.ToDouble(dt.Rows[i]["OpCr"].ToString()))).ToString("###########0.00"),
                    Sharing = dt.Rows[i]["shared"].ToString(),
                    Opening = (Convert.ToDouble(dt.Rows[i]["OpDB"].ToString()) - Convert.ToDouble(dt.Rows[i]["OpCr"].ToString())).ToString("##,###,##"),
                    // Icon = Convert.ToDouble(dt.Rows[i][0].ToString()).ToString("###,###,##"),
                    UserID = dt.Rows[i]["userid"].ToString(),
                    SortDate = dt.Rows[i]["entrydate"].ToString(),
                    UserName = dt.Rows[i]["OwnerName"].ToString(),
                    // Total = Convert.ToDouble(dt.Rows[i][5].ToString()),
                    // TodayPercent = ((Convert.ToDouble(dt.Rows[i][0].ToString()) / Convert.ToDouble(dt.Rows[i][5].ToString())) * 100).ToString("##.##") + "%",

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }

    [WebMethod]
    public string getWorth(string UserID,string StartDate)
    {


        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "getWorth";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@StartDate", StartDate);
            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();



            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Account>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Account
                {

                                                         
                    Icon = dt.Rows[i]["Icon"].ToString(),
                    Color = dt.Rows[i]["Color"].ToString(),
                    AccountID = dt.Rows[i]["AccountID"].ToString(),
                    AccountTitle = dt.Rows[i]["AccountTitle"].ToString(), 
                    //+ " " + ( dt.Rows[i]["shared"].ToString() == "0" ? "" : "<i class='fa fa-users' > </i>"),
                    Balance =((Convert.ToDouble(dt.Rows[i]["Payments"].ToString())- Convert.ToDouble(dt.Rows[i]["Receipts"].ToString()))+(Convert.ToDouble(dt.Rows[i]["OpDB"].ToString()) - Convert.ToDouble(dt.Rows[i]["OpCR"].ToString()))).ToString("##############0.0"),
                    CatID = dt.Rows[i]["CatID"].ToString(),
                    CatName = dt.Rows[i]["Category"].ToString(),
                    CatColor = dt.Rows[i]["CatColor"].ToString(),
                    CatIcon = dt.Rows[i]["CatIcon"].ToString(),
                    SubCatID = dt.Rows[i]["subcatid"].ToString(),
                    SubCatName = dt.Rows[i]["SubCatTitle"].ToString(),
                    SubColor = dt.Rows[i]["SubColor"].ToString(),
                    SubIcon = dt.Rows[i]["SubIcon"].ToString(),
                    Nature = dt.Rows[i]["Nature"].ToString(),
                    BudgetAmount = dt.Rows[i]["BudgetAmount"].ToString(),
                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }

    [WebMethod]
    public int UpdateCat1(string catid, string Category, string mColor, string mIcon, string Type, string UserID)
    {
        var myCat = new Category();
        myCat.category = Category;
        myCat.Color = mColor;
        myCat.Icon = mIcon;
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {


                if (Type == "I")
                {
                    mSQL = "insert into CatInc(Category,Color,Icon,UserID) values ('" + Category + "','" + mColor + "','" + mIcon + "','" + UserID + "')";
                }
                else
                {
                    mSQL = "update CatExp  set Category='" + Category + "' ,Color='" + mColor + "' ,Icon='" + mIcon + "', UserID ='" + UserID + "' where catid='" + catid + "'";
                }

                SqlCommand cmd = new SqlCommand(mSQL, con);
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


    [WebMethod]
    public int DeleteCat(string catid)
    {
        var myCat = new Category();
        
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {


                
                    mSQL = "update CatExp c set c.status=0 where c.catid='" + catid + "' and (select count(*) from subcat s where c.catid=s.catid and ActiveStatus=1)=0";
                mSQL = @"update a set a.status=0 from catexp a where catid='"+ catid + "' and (select count(*) from subcat t where catid=a.catid and t.activestatus=1)=0";

                SqlCommand cmd = new SqlCommand(mSQL, con);
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



    [WebMethod]
    public int DeleteCatMain(string catid)
    {
        var myCat = new Category();

        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {



                mSQL = "update CatMain c set c.status=0 where c.catmainid='" + catid + "' and (select count(*) from catexp s where c.catmainid=s.catmainid and ActiveStatus=1)=0";
                mSQL = @"update a set a.status=0 from catmain a where catmainid='" + catid + "' and (select count(*) from catexp t where catmainid=a.catmainid and t.activestatus=1)=0";

                SqlCommand cmd = new SqlCommand(mSQL, con);
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



    [WebMethod]
    public int DeleteCatParent(string catid)
    {
        var myCat = new Category();

        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {



                mSQL = "update CatParent c set c.status=0 where c.catpid='" + catid + "' and (select count(*) from catmain s where c.catpid=s.catpid and ActiveStatus=1)=0";
                mSQL = @"update a set a.status=0 from catparent a where catpid='" + catid + "' and (select count(*) from catmain t where catpid=a.catpid and t.activestatus=1)=0";

                SqlCommand cmd = new SqlCommand(mSQL, con);
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



    [WebMethod]
    public int DeleteSubCat(string subcatid)
    {
        var myCat = new Category();

        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {



                //mSQL = "Update SubCat  set activestatus=0  where subcatid='" + subcatid + "' and (select count(*) from accounttitle s where subcatid=s.subcatid and s.ActiveStatus=1)=0";
                mSQL = @"update a set a.activestatus=0 from subcat a where subcatid='"+ subcatid  + "' and (select count(*) from accounttitle t where subcatid=a.subcatid and t.activestatus=1)=0";

                SqlCommand cmd = new SqlCommand(mSQL, con);
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


    
    [WebMethod]
    public int DeleteAccount(string AccountID)
    {
        var myCat = new Category();

        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {



               // mSQL = "update AccountTitle set activestatus=0  where AccountID='" + AccountID + "' and (select count(*) from transactions s where c.accountid=s.accountid and s.ActiveStatus=1)=0";

                mSQL = @"update a set a.activestatus=0 from accounttitle a where accountid='"+ AccountID + "' and (select count(*) from transactions t where accountid=a.accountid and t.activestatus=1)=0";
                SqlCommand cmd = new SqlCommand(mSQL, con);
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

    [WebMethod]
    public int UpdateAccountSubCat(string AccountID,string SubCatID)
    {
        var myCat = new Category();

        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {



                mSQL = "update AccountTitle set SubCatID=@subCatID  where AccountID='" + AccountID + "'";


                SqlCommand cmd = new SqlCommand(mSQL, con);
                
                cmd.Parameters.AddWithValue("@subCatID", SubCatID);
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




    [WebMethod]
    public int updateAccount(string AccountID, string AccountTitle,string OpeningDebit, string OpeningCredit, string ActiveStatus, string CellNo, string Email, string SubCatID, string color, string Icon, string PaySource, string Inc, string Exp,string Nature)
    {
        
        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {

                mSQL = @"UPDATE [AccountTitle] SET [AccountTitle] = @AccountTitle,[OpeningDebit] = @OpeningDebit,[OpeningCredit] = @OpeningCredit
                       ,[ActiveStatus] = @ActiveStatus,[CellNo] = @CellNo,[Email] = @Email,[SubCatID] = @SubCatID,[color] = @color,[Icon] = @Icon,[PaySource] = @PaySource
                       ,[Inc] = @Inc,[Exp] = @Exp,Nature=@Nature WHERE [AccountID] = @AccountID";

                

                SqlCommand cmd = new SqlCommand(mSQL, con);
                cmd.Parameters.AddWithValue("@AccountTitle", AccountTitle); 
                cmd.Parameters.AddWithValue("@OpeningDebit", OpeningDebit);
                cmd.Parameters.AddWithValue("@OpeningCredit", OpeningCredit);
                cmd.Parameters.AddWithValue("@ActiveStatus", ActiveStatus);
                cmd.Parameters.AddWithValue("@CellNo", CellNo);
                cmd.Parameters.AddWithValue("@Email", Email);
                cmd.Parameters.AddWithValue("@SubCatID", SubCatID);
                cmd.Parameters.AddWithValue("@color", color);
                cmd.Parameters.AddWithValue("@Icon", Icon);
                cmd.Parameters.AddWithValue("@PaySource", PaySource);
                cmd.Parameters.AddWithValue("@Inc", Inc);
                cmd.Parameters.AddWithValue("@Exp", Exp);
                cmd.Parameters.AddWithValue("@AccountID", AccountID);
                cmd.Parameters.AddWithValue("@Nature", Nature);

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

    [WebMethod]
    public int UpdateBudget(string BudgetID, string AccountID,  string budgetamount, string intrans, string inledger, string innetworth, string infullstatement, string inbalancesheet, string budgettype,string StartDate, string EndDate,string ActiveStatus)
    {

        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {

                mSQL = @"UPDATE [AccountBudget] SET [budgetamount] = @budgetamount,[intrans] = @intrans,[inledger] = @inledger
                       ,[innetworth] = @innetworth,[infullstatement] = @infullstatement,[inbalancesheet] = @inbalancesheet,[budgettype] = @budgettype,[AccountID] = @AccountID
                        ,StartDate=@StartDate,EndDate=@EndDate 
                        WHERE BudgetID=@BudgetID";

                //AccountID,Accounttitle,budgetamount,intrans,inledger,innetworth,infullstatement,inbalancesheet,budgettype

                SqlCommand cmd = new SqlCommand(mSQL, con);
                cmd.Parameters.AddWithValue("@AccountID", AccountID);
                cmd.Parameters.AddWithValue("@budgetamount", budgetamount);
                cmd.Parameters.AddWithValue("@intrans", intrans);
                cmd.Parameters.AddWithValue("@inledger", inledger);
                cmd.Parameters.AddWithValue("@innetworth", innetworth);
                cmd.Parameters.AddWithValue("@infullstatement", infullstatement);
                cmd.Parameters.AddWithValue("@inbalancesheet", inbalancesheet);
                cmd.Parameters.AddWithValue("@budgettype", budgettype);
                cmd.Parameters.AddWithValue("@BudgetID", BudgetID);
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                cmd.Parameters.AddWithValue("@ActiveStatus",ActiveStatus);


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

    [WebMethod]
    public int deleteBudget(string Bid)
    {


        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            string spName = "deleteBudget";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@Lid", Bid);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.SelectCommand = cmd;
            return sda.SelectCommand.ExecuteNonQuery();












        }
    }

    [WebMethod]
    public int InsertBudget( string AccountID, string budgetamount, string intrans, string inledger, string innetworth, string infullstatement, string inbalancesheet, string budgettype,string StartDate,string EndDate,string TType,string LID,string UserID)
    {
        string lid;
        if (LID == "None")
        {
            lid = Guid.NewGuid().ToString();
        }
        else
        {
            lid = LID;
        }

        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {
                if (TType == "New")
                {
                    mSQL = @"insert into [AccountBudget] (BudgetID,[Amount],[intrans],[inledger],[innetworth],[infullstatment],[inbalancesheet],[budgettype],[AccountID],StartDate,EndDate,ActiveStatus,UserID) values (
                       @BudgetID,@budgetamount,@intrans,@inledger,@innetworth,@infullstatement,@inbalancesheet,@budgettype,@AccountID,@StartDate,@EndDate,@ActiveStatus,@UserID)";
                }
                else
                {
                    mSQL = @"UPDATE [AccountBudget] SET [Amount] = @budgetamount,[intrans] = @intrans,[inledger] = @inledger
                       ,[innetworth] = @innetworth,[infullstatment] = @infullstatement,[inbalancesheet] = @inbalancesheet,[budgettype] = @budgettype,[AccountID] = @AccountID
                        ,StartDate=@StartDate,EndDate=@EndDate 
                        WHERE BudgetID=@BudgetID";
                }

                //AccountID,Accounttitle,budgetamount,intrans,inledger,innetworth,infullstatement,inbalancesheet,budgettype

                SqlCommand cmd = new SqlCommand(mSQL, con);
                cmd.Parameters.AddWithValue("@AccountID", AccountID);
                cmd.Parameters.AddWithValue("@budgetamount", budgetamount);
                cmd.Parameters.AddWithValue("@intrans", intrans=="true"?"1":"0");
                cmd.Parameters.AddWithValue("@inledger", inledger == "true" ? "1" : "0");
                cmd.Parameters.AddWithValue("@innetworth", innetworth == "true" ? "1" : "0");
                cmd.Parameters.AddWithValue("@infullstatement", infullstatement == "true" ? "1" : "0");
                cmd.Parameters.AddWithValue("@inbalancesheet", inbalancesheet == "true" ? "1" : "0");
                cmd.Parameters.AddWithValue("@budgettype", budgettype );
                cmd.Parameters.AddWithValue("@StartDate", StartDate);
                cmd.Parameters.AddWithValue("@EndDate", EndDate);
                cmd.Parameters.AddWithValue("@ActiveStatus", "1");
                cmd.Parameters.AddWithValue("@BudgetID", lid);
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


    [WebMethod]
    public int UpdateSubCat(string subcatid, string Category, string mColor, string Icon, string CatId,string Type)
    {

        string mSQL;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            try
            {



                mSQL = "update SubCat set SubCatTitle ='" + Category + "' ,Color='" + mColor + "',Icon='" + Icon + "',CatID='" + CatId + "',Nature = '" + Type + "' where subcatid='" + subcatid + "'";
                SqlCommand cmd = new SqlCommand(mSQL, con);
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

    [WebMethod]
    public int  UpdateCat(string CatID, string Category, string Color, string Icon, string Type)
    {


        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string mSQL = "";
            
            
                mSQL = @"update CatExp set Category='" + Category + "'," +
                   " Color='" + Color + "'," + " Icon = '" + Icon + "', " +
                   " Nature = '" + Type + "' " +
                    
                   "  where catID='" + CatID + "'";
            
            
        

            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return cmd.ExecuteNonQuery();
           

        }

    }


    [WebMethod]
    public int UpdateCatMain(string CatID, string Category, string Color, string Icon, string Type, string CatParentID)
    {


        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string mSQL = "";


            mSQL = @"update CatMain set CategoryMain='" + Category + "'," +
               " Color='" + Color + "'," + " Icon = '" + Icon + "', " +
               " Nature = '" + Type + "' " +
                  " CatPID = '" + CatParentID + "' " +
               "  where CatMainID='" + CatID + "'";




            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return cmd.ExecuteNonQuery();


        }

    }



    [WebMethod]
    public int UpdateCatParent(string CatID, string Category, string Color, string Icon, string Type)
    {


        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string mSQL = "";


            mSQL = @"update CatParent set CategoryP='" + Category + "'," +
               " Color='" + Color + "'," + " Icon = '" + Icon + "', " +
               " Nature = '" + Type + "' " +
               "  where CatPID='" + CatID + "'";




            SqlCommand cmd = new SqlCommand(mSQL, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return cmd.ExecuteNonQuery();


        }

    }






    [WebMethod]
    [ScriptMethod]
    public string updateIssue(string CNIC, string UserName, string issueDate, string lat, string lon)
    {
        // string UserID = "Dadu"; string Password = "dadu";
        //string mUser = user.UserID;
        //string mPass = user.Password;
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

        int abc;
        using (var con = new SqlConnection(cs))
        {
            var mIssueDate = issueDate;
            //string msql = "select  (cast(year(newsdate) as varchar(4)) + ' ' +CONVERT(varchar(3), NewsDate, 100) +' ' + cast(day(newsdate) as varchar(2)) ) as NewsDate,NewsTitle, Replace(left([NewsDetail],300),',','@') as NewsDetail,NewsID from [Setup].[News] where status=1 order by newsdate ";
            string msql = "update  MergedDistrict set issued=1 , UserName='" + UserName + "',IssueDate='" + mIssueDate + "' where cnic='" + CNIC + "'";


            SqlCommand cmd = new SqlCommand(msql, con);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }

            cmd.CommandTimeout = 0;
            abc = cmd.ExecuteNonQuery();
            DateTime mDate = DateTime.Today;
            //string lat = "";
            //string lon = "";
            string mDate1 = mIssueDate;//  DateTime.Now.ToString("yyyy-MM-dd");
            string ssql = "select cnic from issue where cnic='" + CNIC + "' and issuedate ='" + mDate1 + "'";
            SqlDataAdapter sda = new SqlDataAdapter(ssql, con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            if (dt.Rows.Count > 0)
            {

            }
            else
            {
                msql = "insert into Issue (CNIC,IssueDate,UserName,lat,lon) values ('" + CNIC + "','" + mDate1 + "', '" + UserName + "','" + lat + "','" + lon + "')";
                cmd = new SqlCommand(msql, con);
                cmd.ExecuteNonQuery();
                con.Close();
            }






        }
        var js = new JavaScriptSerializer();

        return abc.ToString() + " Record(s) updated";

    }

    
    [WebMethod]
    public string NatureCatID(string UserID, string Nature)
    {


        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string mSQL = "";


            mSQL = "Select CatID,Category from catexp where userid=@userid and nature=@nature";




            string spName = mSQL;
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@nature", Nature);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i]["CatID"].ToString(),
                    category = dt.Rows[i]["Category"].ToString(),
                    
                    

                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;



        }

    }
    [WebMethod]
    public string NatureSubCatID(string UserID, string Nature)
    {


        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {
            string mSQL = "";

            mSQL = "Select SubcatId,c.CatID,c.Category from catexp c inner join SubCat s on c.catid=s.catid where userid=@userid and s.nature=@nature and c.status=1 and s.activestatus=1";

            string spName = mSQL;
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@userid", UserID);
            cmd.Parameters.AddWithValue("@nature", Nature);
            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<Category>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var myCat = new Category
                {
                    CatId = dt.Rows[i]["SubcatId"].ToString(),
                    category = dt.Rows[i]["Category"].ToString(),
                    MainID= dt.Rows[i]["CatID"].ToString()



                };
                expcat.Add(myCat);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;



        }

    }

    //////////////////////////////////////////////////////// Abdullah //////////////////////////////////////////////////////////////



    [WebMethod]

    public int addTransaction(string Source, string TrDate, string TrAccount, double Amount, string NarrationS, string NarrationT, string Type, string TType, string LID, string UserID, string FileID, string Highlighter,
                               string TransectionId, string TransectionDate, string ChaqueNo, string ChaqueDate, string ChaquePostedDate, string ChaqueClaringDate,string PaymentType,string ChequeType)
    {

        string lid;
        if (LID == "None")
        {
            lid = Guid.NewGuid().ToString();
        }
        else
        {
            lid = LID;
        }

        int mR = 0;
        string mSQL1, mSQL2;
        string mSQL3 = "";
        string mSQL4 = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            if (Type == "R")
            {

                if (TType == "New")
                {
                    


                    mSQL1 = @"insert into Transactions (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid,Highlighter,TransectionId,TransectionDate,ChaqueNo,ChaqueDate,ChaquePostedDate,ChaqueClaringDate,PaymentType,ChequeType) values ('" + Source + "','" + TrDate + "','" + NarrationT + "','" + Amount + "',0,'" + lid + "',1,'R','0','" + UserID + "','" + Highlighter + "','" + TransectionId + "','" + TransectionDate + "','" + ChaqueNo + "','" + ChaqueDate + "','" + ChaquePostedDate + "','" + ChaqueClaringDate + "','" + PaymentType + "','" + ChequeType + "') ";
                    mSQL2 = @"insert into Transactions (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid,Highlighter,TransectionId,TransectionDate,ChaqueNo,ChaqueDate,ChaquePostedDate,ChaqueClaringDate,PaymentType,ChequeType) values ('" + TrAccount + "','" + TrDate + "','" + NarrationS + "',0,'" + Amount + "','" + lid + "',1,'R','0','" + UserID + "','" + Highlighter + "','" + TransectionId + "','" + TransectionDate + "','" + ChaqueNo + "','" + ChaqueDate + "','" + ChaquePostedDate + "','" + ChaqueClaringDate + "','" + PaymentType + "','" + ChequeType + "') ";
                    mSQL3 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid,Highlighter,TransectionId,TransectionDate,ChaqueNo,ChaqueDate,ChaquePostedDate,ChaqueClaringDate,PaymentType,ChequeType) values ('" + Source + "','" + TrDate + "','" + NarrationT + "','" + Amount + "',0,'" + lid + "',1,'R','0','" + UserID + "','" + Highlighter + "','" + TransectionId + "','" + TransectionDate + "','" + ChaqueNo + "','" + ChaqueDate + "','" + ChaquePostedDate + "','" + ChaqueClaringDate + "','" + PaymentType + "','" + ChequeType + "') ";
                    mSQL4 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid,Highlighter,TransectionId,TransectionDate,ChaqueNo,ChaqueDate,ChaquePostedDate,ChaqueClaringDate,PaymentType,ChequeType) values ('" + TrAccount + "','" + TrDate + "','" + NarrationS + "',0,'" + Amount + "','" + lid + "',1,'R','0','" + UserID + "','" + Highlighter + "','" + TransectionId + "','" + TransectionDate + "','" + ChaqueNo + "','" + ChaqueDate + "','" + ChaquePostedDate + "','" + ChaqueClaringDate + "','" + PaymentType + "','" + ChequeType + "') ";
                }
                else
                {
                    mSQL1 = @"Update Transactions set AccountID='" + Source + "',TDate='" + TrDate + "',Narration='" + NarrationT + "',DR='" + Amount + "',CR=0,LID='" + lid + "',ActiveStatus=1,VoucherType='R',SharedRead='0',Highlighter='" + Highlighter + "' ,TransectionId='" + TransectionId + "',TransectionDate='" + TransectionDate + "',ChaqueNo='" + ChaqueNo + "',ChaqueDate='" + ChaqueDate + "',ChaquePostedDate='" + ChaquePostedDate + "',ChaqueClaringDate='" + ChaqueClaringDate + "',PaymentType='" + PaymentType + "',ChequeType='" + ChequeType + "'      where Lid='" + lid + "' and cr=0";
                    mSQL2 = @"Update Transactions set AccountID='" + TrAccount + "',TDate='" + TrDate + "',Narration='" + NarrationS + "',DR=0,CR='" + Amount + "',LID='" + lid + "',ActiveStatus=1,VoucherType='R',SharedRead='0',Highlighter='" + Highlighter + "' ,TransectionId='" + TransectionId + "',TransectionDate='" + TransectionDate + "',ChaqueNo='" + ChaqueNo + "',ChaqueDate='" + ChaqueDate + "',ChaquePostedDate='" + ChaquePostedDate + "',ChaqueClaringDate='" + ChaqueClaringDate + "',PaymentType='" + PaymentType + "',ChequeType='" + ChequeType + "' where Lid='" + lid + "' and dr=0";

                    mSQL3 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid,Highlighter,TransectionId,TransectionDate,ChaqueNo,ChaqueDate,ChaquePostedDate,ChaqueClaringDate,PaymentType,ChequeType) values ('" + Source + "','" + TrDate + "','" + NarrationT + "','" + Amount + "',0,'" + lid + "',1,'R','0','" + UserID + "','" + Highlighter + "','" + TransectionId + "','" + TransectionDate + "','" + ChaqueNo + "','" + ChaqueDate + "','" + ChaquePostedDate + "','" + ChaqueClaringDate + "','" + PaymentType + "','" + ChequeType + "') ";
                    mSQL4 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid,Highlighter,TransectionId,TransectionDate,ChaqueNo,ChaqueDate,ChaquePostedDate,ChaqueClaringDate,PaymentType,ChequeType) values ('" + TrAccount + "','" + TrDate + "','" + NarrationS + "',0,'" + Amount + "','" + lid + "',1,'R','0','" + UserID + "','" + Highlighter + "','" + TransectionId + "','" + TransectionDate + "','" + ChaqueNo + "','" + ChaqueDate + "','" + ChaquePostedDate + "','" + ChaqueClaringDate + "','" + PaymentType + "','" + ChequeType + "') ";

                }


            }
            else
            {
                if (TType == "New")
                {
                    mSQL1 = @"insert into Transactions (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid,Highlighter,TransectionId,TransectionDate,ChaqueNo,ChaqueDate,ChaquePostedDate,ChaqueClaringDate,PaymentType,ChequeType) values ('" + Source + "','" + TrDate + "','" + NarrationT + "',0,'" + Amount + "','" + lid + "',1,'P','0','" + UserID + "','" + Highlighter + "','" + TransectionId + "','" + TransectionDate + "','" + ChaqueNo + "','" + ChaqueDate + "','" + ChaquePostedDate + "','" + ChaqueClaringDate + "','" + PaymentType + "','" + ChequeType + "') ";
                    mSQL2 = @"insert into Transactions (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid,Highlighter,TransectionId,TransectionDate,ChaqueNo,ChaqueDate,ChaquePostedDate,ChaqueClaringDate,PaymentType,ChequeType) values ('" + TrAccount + "','" + TrDate + "','" + NarrationS + "','" + Amount + "',0,'" + lid + "',1,'P','0','" + UserID + "','" + Highlighter + "','" + TransectionId + "','" + TransectionDate + "','" + ChaqueNo + "','" + ChaqueDate + "','" + ChaquePostedDate + "','" + ChaqueClaringDate + "','" + PaymentType + "','" + ChequeType + "') ";
                    mSQL3 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid,Highlighter,TransectionId,TransectionDate,ChaqueNo,ChaqueDate,ChaquePostedDate,ChaqueClaringDate,PaymentType,ChequeType) values ('" + Source + "','" + TrDate + "','" + NarrationT + "',0,'" + Amount + "','" + lid + "',1,'P','0','" + UserID + "','" + Highlighter + "','" + TransectionId + "','" + TransectionDate + "','" + ChaqueNo + "','" + ChaqueDate + "','" + ChaquePostedDate + "','" + ChaqueClaringDate + "','" + PaymentType + "','" + ChequeType + "') ";
                    mSQL4 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid,Highlighter,TransectionId,TransectionDate,ChaqueNo,ChaqueDate,ChaquePostedDate,ChaqueClaringDate,PaymentType,ChequeType) values ('" + TrAccount + "','" + TrDate + "','" + NarrationS + "','" + Amount + "',0,'" + lid + "',1,'P','0','" + UserID + "','" + Highlighter + "','" + TransectionId + "','" + TransectionDate + "','" + ChaqueNo + "','" + ChaqueDate + "','" + ChaquePostedDate + "','" + ChaqueClaringDate + "','" + PaymentType + "','" + ChequeType + "') ";

                }
                else
                {
                    mSQL1 = @"Update Transactions set AccountID='" + TrAccount + "',TDate='" + TrDate + "',Narration='" + NarrationS + "',DR='" + Amount + "',CR=0,LID='" + lid + "',ActiveStatus=1,VoucherType='P',SharedRead='0',Highlighter='" + Highlighter + "' ,TransectionId='" + TransectionId + "',TransectionDate='" + TransectionDate + "',ChaqueNo='" + ChaqueNo + "',ChaqueDate='" + ChaqueDate + "',ChaquePostedDate='" + ChaquePostedDate + "',ChaqueClaringDate='" + ChaqueClaringDate + "',PaymentType='" + PaymentType + "',ChequeType='" + ChequeType + "'  where Lid='" + lid + "' and cr=0";
                    mSQL2 = @"Update Transactions set AccountID='" + Source + "',TDate='" + TrDate + "',Narration='" + NarrationT + "',DR=0,CR='" + Amount + "',LID='" + lid + "',ActiveStatus=1,VoucherType='P',SharedRead='0',Highlighter='" + Highlighter + "',TransectionId='" + TransectionId + "',TransectionDate='" + TransectionDate + "',ChaqueNo='" + ChaqueNo + "',ChaqueDate='" + ChaqueDate + "',ChaquePostedDate='" + ChaquePostedDate + "',ChaqueClaringDate='" + ChaqueClaringDate + "',PaymentType='" + PaymentType + "',ChequeType='" + ChequeType + "' where Lid='" + lid + "' and dr=0";

                    mSQL3 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid,Highlighter,TransectionId,TransectionDate,ChaqueNo,ChaqueDate,ChaquePostedDate,ChaqueClaringDate,PaymentType,ChequeType) values ('" + Source + "','" + TrDate + "','" + NarrationT + "',0,'" + Amount + "','" + lid + "',1,'P','0','" + UserID + "','" + Highlighter + "','" + TransectionId + "','" + TransectionDate + "','" + ChaqueNo + "','" + ChaqueDate + "','" + ChaquePostedDate + "','" + ChaqueClaringDate + "','" + PaymentType + "','" + ChequeType + "') ";
                    mSQL4 = @"insert into TransactionsEditLog (AccountID,TDate,Narration,DR,CR,LID,ActiveStatus,VoucherType,SharedRead,Userid,Highlighter,TransectionId,TransectionDate,ChaqueNo,ChaqueDate,ChaquePostedDate,ChaqueClaringDate,PaymentType,ChequeType) values ('" + TrAccount + "','" + TrDate + "','" + NarrationS + "','" + Amount + "',0,'" + lid + "',1,'P','0','" + UserID + "','" + Highlighter + "','" + TransectionId + "','" + TransectionDate + "','" + ChaqueNo + "','" + ChaqueDate + "','" + ChaquePostedDate + "','" + ChaqueClaringDate + "','" + PaymentType + "','" + ChequeType + "') ";

                }

            }






            SqlCommand cmd = new SqlCommand(mSQL1, con);
            cmd.CommandTimeout = 0;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            //mR = cmd.ExecuteNonQuery();
            mR = cmd.ExecuteNonQuery();
            cmd.CommandText = mSQL2;
            mR = mR + cmd.ExecuteNonQuery();
            if (mSQL3 != "")
            {
                cmd.CommandText = mSQL3;
                cmd.ExecuteNonQuery();
                cmd.CommandText = mSQL4;
                cmd.ExecuteNonQuery();

            }




            /////////////////Abdullah




            if (FileID != "")
            {

                string strRep = FileID.Replace("*", "'");

                var cs1 = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;

                using (var con1 = new SqlConnection(cs1))
                {
                    string spName1 = "UpdateAttachments";


                    SqlDataAdapter sda1 = new SqlDataAdapter();
                    SqlCommand cmd1 = new SqlCommand();
                    cmd1.Connection = con1;
                    cmd1.CommandType = CommandType.StoredProcedure;

                    cmd1.CommandText = spName1;
                    cmd1.Parameters.AddWithValue("@TransactionID", "'" + lid + "'");
                    cmd1.Parameters.AddWithValue("@FileID", strRep);




                    if (con1.State == ConnectionState.Closed)
                    {
                        con1.Open();
                    }
                    cmd1.ExecuteNonQuery().ToString();
                    con1.Close();
                }
            }














            ////////////////Abdullah









            return (mR);

        }

    }



    [WebMethod]
    public string UpdateChaqueStatus(string ChaqueStatus, string LID)
    {
        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {


            string spName = "UpdateChaqueStatus";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@ChaqueStatus", ChaqueStatus);
            cmd.Parameters.AddWithValue("@LID", LID);
          
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            var option = cmd.ExecuteNonQuery();
            return option.ToString();

        }
    }



    [WebMethod]
    public string AddAttachment(string MyFile, string FileName, string FileExtension)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        var cal = "";
        using (var con = new SqlConnection(cs))
        {

            string spName = "AddAttachmentWithBytes";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = spName;

            cmd.Parameters.AddWithValue("@FileName", FileName);
            cmd.Parameters.AddWithValue("@FileExtension", FileExtension);
            cmd.Parameters.AddWithValue("@Bytes", MyFile.Length);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cal = cmd.ExecuteScalar().ToString();
            con.Close();
            if (cal.Contains("00000000"))
            {
                cal = "Error";
            }
            else
            {
                if (MyFile != "" && MyFile != "undefined")
                {
                    string[] str1 = MyFile.Split(',');
                    File.WriteAllBytes(Server.MapPath("/imgAttachments/") + cal + "." + FileExtension, Convert.FromBase64String(str1[1]));
                }


            }
            return cal;

        }


    }


    public class Attachemnts
    {
        public string FileID { set; get; }
        public string FileName { set; get; }
        public string FileExtension { set; get; }

    }
    [WebMethod]
    public string LoadAttachments(string FileID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string strRep = FileID.Replace("*", "'");


            string spName;

            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "LoadAttachments";
            cmd.Parameters.AddWithValue("@FileID", strRep);

            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var varAttachemnts = new List<Attachemnts>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var varAttachemntsList = new Attachemnts
                {

                    FileID = dt.Rows[i]["FileID"].ToString(),
                    FileName = dt.Rows[i]["FileName"].ToString(),
                    FileExtension = dt.Rows[i]["FileExtension"].ToString(),

                };

                varAttachemnts.Add(varAttachemntsList);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(varAttachemnts);
            return myData;

        }

    }



    [WebMethod]
    public string DeleteAttachments(string FileID)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            string spName;

            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "Update Attachments set Activestatus='1' where FileID=@FileID";
            cmd.Parameters.AddWithValue("@FileID", FileID);
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
    public string LoadAttachmentsTransactionIDwise(string TransactionID)
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
            cmd.CommandText = "LoadAttachmentsTransactionIDwise";
            cmd.Parameters.AddWithValue("@TransactionID", TransactionID);

            sda.SelectCommand = cmd;
            DataTable dt = new DataTable();


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);

            var varAttachemnts = new List<Attachemnts>();
            for (int i = 0; i < dt.Rows.Count; i++)

            {
                var varAttachemntsList = new Attachemnts
                {

                    FileID = dt.Rows[i]["FileID"].ToString(),
                    FileName = dt.Rows[i]["FileName"].ToString(),
                    FileExtension = dt.Rows[i]["FileExtension"].ToString(),

                };

                varAttachemnts.Add(varAttachemntsList);
            }

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(varAttachemnts);
            return myData;

        }

    }



    //////////////////////////////////////////////////// LOG
    ///


    [WebMethod]
    public string MunshiLog(string AjaxFunction, int POST, int GET, string InformationJSONString, string Email)
    {

        string mSQL = "";
        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        var cal = "";
        using (var con = new SqlConnection(cs))
        {

            string spName = "AddMunshiLog";
            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = spName;

            cmd.Parameters.AddWithValue("@AjaxFunction", AjaxFunction);
            cmd.Parameters.AddWithValue("@POST", POST);
            cmd.Parameters.AddWithValue("@GET", GET);
            cmd.Parameters.AddWithValue("@InformationJSONString", InformationJSONString);
            cmd.Parameters.AddWithValue("@Email", Email);


            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            cal = cmd.ExecuteScalar().ToString();
            con.Close();



        }
        return cal;

    }




    //////////////////////////////////////////////////////// Abdullah //////////////////////////////////////////////////////////////




    public class LoadTransaction_InvoiceData
    {
        public string Tid { get; set; }
        public string AccId_Payment { get; set; }
        public string AccId_Cash { get; set; } 
        public string Amount { get; set; } 
        public string VoucherType { get; set; } 
        public string TDate { get; set; }
        public string Narration { get; set; }
        public string AccId_CashT { get; set; }
        public string AccId_PaymentT { get; set; }
        public string Sharing { get; set; }
        public string Highlighter { get; set; } 
        public string Currency1 { get; set; }
        public string Currency2 { get; set; }
        public string Rate { get; set; }
        public string Amount2 { get; set; }
        public string CurrencyID { get; set; }
        public string TargetCurrencyID { get; set; }
        public string TXNID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Cell { get; set; }
    }



    [WebMethod]
    public string LoadTransactionInvoice(string TransID, string TType, string UserID)
    {

        var lid = TransID;

        var cs = ConfigurationManager.ConnectionStrings["ConStr"].ConnectionString;
        using (var con = new SqlConnection(cs))
        {

            SqlDataAdapter sda = new SqlDataAdapter();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            //string spName = "Select t.*,CONVERT(char(10), Tdate,126) LoadDate,a.accounttitle from [Transactions] t inner join accounttitle a on t.accountid=a.accountid  where t.LID=@LID and vouchertype='" + TType +"' order by cr";
            string spName = "LoadTransactionInvoice";
            cmd.CommandTimeout = 0;
            cmd.CommandText = spName;
            cmd.Parameters.AddWithValue("@LID", lid);
            cmd.Parameters.AddWithValue("@Type", TType);
            cmd.Parameters.AddWithValue("@userid", UserID);

            sda.SelectCommand = cmd;

            DataTable dt = new DataTable();

            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            sda.Fill(dt);
            var expcat = new List<LoadTransaction_InvoiceData>();
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            if (Convert.ToDouble(dt.Rows[0]["cr"].ToString()) == 0 && TType == "P")
            {
                var myCat = new LoadTransaction_InvoiceData
                {
                    TDate = dt.Rows[0]["LoadDate"].ToString(),
                    Narration = dt.Rows[0]["Narration"].ToString(),
                    VoucherType = dt.Rows[0]["vouchertype"].ToString(),
                    Amount = (Math.Abs(Convert.ToDouble(dt.Rows[0]["dr"].ToString()) - Convert.ToDouble(dt.Rows[0]["cr"].ToString()))).ToString("######0.00"),
                    Tid = dt.Rows[0]["LID"].ToString(),
                    AccId_Cash = dt.Rows[1]["AccountID"].ToString(),
                    AccId_CashT = dt.Rows[1]["AccountTitle"].ToString(),
                    AccId_Payment = dt.Rows[0]["AccountID"].ToString(),
                    AccId_PaymentT = dt.Rows[0]["AccountTitle"].ToString(),
                    Sharing = dt.Rows[0]["Status"].ToString(),
                    Highlighter = dt.Rows[0]["Highlighter"].ToString(),
                    //Amount2 = dt.Rows[0]["Amount2"].ToString(),
                    //CurrencyID = dt.Rows[0]["CurrencyID"].ToString(),
                    //Currency1 = dt.Rows[0]["Currency1"].ToString(),
                    //Currency2 = dt.Rows[0]["Currency2"].ToString(),
                    //Rate = dt.Rows[0]["Rate"].ToString(),
                    //TargetCurrencyID = dt.Rows[0]["TargetCurrencyID"].ToString(),
                    TXNID = dt.Rows[0]["TXNID"].ToString(),
                    Name = dt.Rows[0]["FullName"].ToString(),
                    Cell = dt.Rows[0]["CellNo"].ToString(),
                    Email = dt.Rows[0]["email"].ToString(),
                };

                expcat.Add(myCat);
            }
            else
            {
                var myCat = new LoadTransaction_InvoiceData
                {
                    TDate = dt.Rows[0]["LoadDate"].ToString(),
                    Narration = dt.Rows[0]["Narration"].ToString(),
                    VoucherType = dt.Rows[0]["vouchertype"].ToString(),
                    Amount = (Math.Abs(Convert.ToDouble(dt.Rows[0]["dr"].ToString()) - Convert.ToDouble(dt.Rows[0]["cr"].ToString()))).ToString("######0.00"),
                    Tid = dt.Rows[0]["LID"].ToString(),
                    AccId_Cash = dt.Rows[0]["AccountID"].ToString(),
                    AccId_CashT = dt.Rows[0]["AccountTitle"].ToString(),
                    AccId_Payment = dt.Rows[1]["AccountID"].ToString(),
                    AccId_PaymentT = dt.Rows[1]["AccountTitle"].ToString(),
                    Sharing = dt.Rows[0]["Status"].ToString(),
                    Highlighter = dt.Rows[0]["Highlighter"].ToString(),
                    //Amount2 = dt.Rows[0]["Amount2"].ToString(),
                    //CurrencyID = dt.Rows[0]["CurrencyID"].ToString(),
                    //Currency1 = dt.Rows[0]["Currency1"].ToString(),
                    //Currency2 = dt.Rows[0]["Currency2"].ToString(),
                    //Rate = dt.Rows[0]["Rate"].ToString(),
                    //TargetCurrencyID = dt.Rows[0]["TargetCurrencyID"].ToString(),
                    TXNID = dt.Rows[0]["TXNID"].ToString(),
                    Name = dt.Rows[0]["FullName"].ToString(),
                    Cell = dt.Rows[0]["CellNo"].ToString(),
                    Email = dt.Rows[0]["email"].ToString(),

                };
                expcat.Add(myCat);
            }

            //}

            var js = new JavaScriptSerializer();
            string myData = js.Serialize(expcat);
            return myData;

        }
    }




}
