
        //document.getElementById("CurrencyName").innerHTML = SettingValues.CurrencyCode;
        tableSize();
        function tableSize() {
            // inputDiv

            var idh = $("#inputDiv").height();
            //$("#Table1").height($("#maincontents").height() - (idh + 55 ));
            
        }
        // document.getElementById("spandataloading").style.display = "block";
        var pc = 0;
        var cc = 0;
        var InputOption = sessionStorage.getItem("InputOption");

        var edit1 = [];
        edit1[0] = "addexpenses";
        edit1[1] = InputOption;
       
      
       
        var forText, ForText;
        function setValue(a) {
        
            mValTo = a.value;
            var ttfor = $("#paymentsID option:selected").text();
            var ttfor1 = ttfor.split("[");
            ForText = ttfor1[0];
         



          
        }
        var srcText;
        function setValeCash(a) {

            mValFrom = a.value;
            var tt = $("#cashID option:selected").text();
            var tt1 = tt.split("[");
            srcText = tt1[0].substr(0, tt1[0].length - 3);
         

        }
        function addPayment() {
          
            $('#loader').show();
            


            //  var ID = document.getElementById("")
            
            var userid = window.sessionStorage.getItem("UserID");
            var trAcc = mValTo;
            var source = mValFrom;
            //cashID, txtAmount, Btype, inTrans, inLedger, inNetWorth, inBalanceSheet, inFullStatement
            //LID1 = window.sessionStorage.getItem("BudjetID");
            
            var cashID = document.getElementById("cashID").value;
            var txtAmount = document.getElementById("txtAmount").value;
            var e = document.getElementById("Btype");
            var Btype = e.options[e.selectedIndex].value;
            
            var inTrans = document.getElementById("inTrans").checked;
            var inLedger = document.getElementById("inLedger").checked;
            var inNetWorth = document.getElementById("inNetWorth").checked;
            var inBalanceSheet = document.getElementById("inBalanceSheet").checked;
            var inFullStatement = document.getElementById("inFullStatement").checked;
            var varStartDate = document.getElementById("StartDate").value;
            var varEndDate = document.getElementById("EndDate").value;
            //var trdate = fd[2] + "-" + fd[1] + "-" + fd[0];
            
            if (typeof source == 'undefined' || txtAmount == "" || varStartDate == "" || varEndDate=="") {
                $.alert({ title: 'Alert!', content: 'Invalid input. Transaction Failed', });
                
                $('#loader').hide();
            }

            else {
               
                $('#spandataloading').show();
                $('#iSave').attr('class', 'fa fa-refresh fa-spin');
                var type = "P";
                // string AccountID, string budgetamount, string intrans, string inledger, string innetworth, string infullstatement, string inbalancesheet, string budgettype,string StartDate,string EndDate
 

                $.ajax({
                    type: 'POST',
                    url: 'Accounts.asmx/InsertBudget',
                    dataType: 'json',
                    data: "{'AccountID':'" + cashID + "','budgetamount':'" + txtAmount + "','intrans':'" + inTrans + "','inledger':'" + inLedger + "','innetworth':'" + inNetWorth + "','infullstatement':'" + inFullStatement + "','inbalancesheet':'" + inBalanceSheet + "','budgettype':'" + Btype + "','StartDate':'" + varStartDate + "','EndDate':'" + varEndDate + "','TType':'" + TType + "','LID':'" + LID1 + "','UserID':'" + userid + "'}",
                    contentType: 'application/json; charset=utf-8',

                    success: function (response) {
                         

                     
                        if (TType == "New") {
                            $.alert({ title: 'Alert!', content: 'Transaction Saved.', });
                            
                            $('#iSave').attr('class', 'fa fa-save');
                            //LoadFile('addexpense.html');
                            //document.location.href = "innerpageframe.html";
                            clearAll();
                            BudgetAccount_List();
                        }
                        else {
                            $.alert({ title: 'Alert!', content: 'Transaction Updated', });
                            
                            $('#iSave').attr('class', 'fa fa-save');
                            //LoadFile('dashboard.html');
                            //document.location.href = "innerpageframe.html";
                            clearAll();
                            BudgetAccount_List();
                        }
                        //var txt = '{"Row": ' + response.d + '}';
                        //var data = JSON.parse(txt);
                        clearAll();
                        $('#spandataloading').hide();

                        $('#loader').hide();

                        //$('#loadI').attr('class', 'fa fa-gear');


                    },
                    error: function (error) {
                        console.log(error);
                    }
                });

                

            }

        }
        function clearAll() {
            // document.getElementById('myform').reset();
            // document.getElementById("spandataloading").style.display = "block";
            TType = "New";
            LID1 = "None";
            window.sessionStorage.setItem("BudgetID","None");
            Opt = "";
            $('#spandataloading').show()
            $(':input').val('');
            $('#iSave').attr('class', 'fa fa-save');
            $("#paymentsID").select2("val", "");
            $("#paymentsID").trigger('change');
            $("#cashID").select2("val", "");
            $("#cashID").trigger('change');
            sessionStorage.setItem('InputOption', 'New');
            sessionStorage.setItem('BudgetID', 'None');
            //getDate();
            //   document.getElementById("spandataloading").style.display = "none";
            $('#spandataloading').hide()
        }
       

        
BudgetAccount_List();
var LedgerObj = [];
function FillTable(obj) {
    var str = "";
    var strPending = "";
    var dt = "";
    var mvalue;
    var mRow = 0;
    var mRow2 = 0;
    //var tpay;
    //var trec;
    var bal;
    var dTotal = 0.00;
    var cTotal = 0.00;
   

    for (var i = 0; i < obj.length; i++) {
        

        mRow = mRow + 1;
        dt = dt + " <tr>";
        dt = dt + "   <td class='mTD'>" + mRow + ".</td>";
        dt = dt + "   <td  class='mTD'> " + obj[i].AccountTitle + "</td>";//<a href='#' onclick='callPage(this);'><i style='color:" + obj[i].Color + ";' class='" + obj[i].Icon + "' ></i>" + " " + obj[i].AccTitle + "</a></td>";
        dt = dt + "   <td class='mTD' id='tdFrom'>" + obj[i].budgettype + "</td>";
        var nar = "";
        nar = nar + (obj[i].intrans == "1" ? "Transaction, " : "");
        nar = nar + (obj[i].inledger == "1" ? "Ledger, " : "");
        nar = nar + (obj[i].innetworth == "1" ? "Net Worth, " : "");
        nar = nar + (obj[i].infullstatement == "1" ? "Full Statement, " : "");
        nar = nar + (obj[i].inbalancesheet == "1" ? "Balance Sheet, " : "");


        dt = dt + "   <td class='mTD' id='tdNarration'>" + nar + "</td>";
        //dt = dt + "   <td id='tdNarration' >" + obj[i].Narration + "</td>";
        dt = dt + "   <td class='mTD  textar'>" + obj[i].StartDate + " to "+ obj[i].EndDate + "</td>";
        dt = dt + "   <td class='mTD  textar'>" + obj[i].budgetamount + "</td>";

        dt = dt + "   <td class='mTD  textac'><a href='#' onclick=loadpageEdit('" + obj[i].BudgetID + "" + "')><i class='fa fa-edit'></i></a></td>";
        dt = dt + "   <td class='mTD  textac'><a href='#' onclick=deleteBudget('" + obj[i].BudgetID + "" + "')><i class='fa fa-trash'></i></a></td>";
        


        dt = dt + "</tr>";

        str = str + dt;
        dt = "";
    }


    document.getElementById("ledger").innerHTML = str;
                    //AccountSharedwithUserName(accid, userid);
}
function BudgetAccount_List() {
                  
            var userid = sessionStorage.getItem("UserID");
       
    $('#loader').show();

 

            $.ajax({
                type: 'POST',
                url: 'Accounts.asmx/BudgetAccount_List',
                dataType: 'json',
                data: "{'UserID':'" + userid + "'}",
                contentType: 'application/json; charset=utf-8',

                success: function (response) {

                  

                    var txt = '{"Row": ' + response.d + '}';
                    var data = JSON.parse(txt);
                    LedgerObj = [];
                    for (var i = 0; i < data.Row.length; i++) {
                        //AccountID,Accounttitle,budgetamount,intrans,inledger,innetworth,infullstatement,inbalancesheet,budgettype
                        var Dvalue = {
                            BudgetID: data.Row[i].BudgetID
                            ,AccountID: data.Row[i].AccountID
                            , AccountTitle: data.Row[i].AccountTitle
                            , budgetamount: data.Row[i].budgetamount
                            , intrans: data.Row[i].intrans
                            , inledger: data.Row[i].inledger
                            , innetworth: data.Row[i].innetworth
                            , infullstatement: data.Row[i].infullstatement
                            , inbalancesheet: data.Row[i].inbalancesheet
                            , budgettype: data.Row[i].budgettype
                            , TotalAmount: data.Row[i].TotalAmount
                            , StartDate: data.Row[i].StartDate
                            , EndDate: data.Row[i].EndDate
                        }
                        LedgerObj.push(Dvalue);
                    }
                    FillTable(LedgerObj);
                    $('#spandataloading').hide();
                    $('#loader').hide();
                    //$('#loadI').attr('class', 'fa fa-gear');


                },
                error: function (error) {
                    console.log(error);
                }
    });
 


        }
        function loadpageEdit(c) {
           
            //var ids = c.split(":");
            LID1 = c;
            TType = "Edit";
            window.sessionStorage.setItem("BudgetID", c);
            var data1 = SearchValue(LedgerObj, c, "BudgetID")
            
            document.getElementById("cashID").value;
            $("#cashID").val(data1[0].AccountID);
            $('#cashID').trigger('change');
            document.getElementById("txtAmount").value = data1[0].budgetamount;
            document.getElementById("Btype").value = data1[0].budgettype;
            

            document.getElementById("inTrans").checked = data1[0].intrans=="1"? true:false;
            document.getElementById("inLedger").checked = data1[0].inledger == "1" ? true : false;
            document.getElementById("inNetWorth").checked = data1[0].innetworth == "1" ? true : false;
            document.getElementById("inBalanceSheet").checked = data1[0].inbalancesheet == "1" ? true : false;
            document.getElementById("inFullStatement").checked = data1[0].infullstatement == "1" ? true : false;
            document.getElementById("StartDate").value = data1[0].StartDate;
            document.getElementById("EndDate").value = data1[0].EndDate;
            //if (ids[1] == "R") {
            //    LoadFile("addIncome.html?id=Edit");
            //}
            
        }
function SearchValue(obj,value,field) {

    var sv = value.toUpperCase();
  
    if (sv == "" || sv == 'NaN') {
        FillTable(obj);
    
    }
    else {
        var newArray = [];
        obj.forEach(function (k) {
            
            var data1 = ( k[field].toUpperCase() );
          
            if (data1.match(sv) == sv) {
              
                newArray.push(k)
            };
        });
   
        return newArray;
    }
}
        
function BudgetCheck() {

    var userid = sessionStorage.getItem("UserID");
    var cashID = document.getElementById("cashID").value;
    var varStartDate = document.getElementById("StartDate").value;
    var varEndDate = document.getElementById("EndDate").value;
    $('#loader').show();

     
    $.ajax({
        type: 'POST',
        url: 'Accounts.asmx/BudgetCheck',
        dataType: 'json',
        data: "{'UserID':'" + userid + "','AccountID':'" + cashID + "','StartDate':'" + varStartDate + "','EndDate':'" + varEndDate + "','BudgetID':'" + LID1 + "'}",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            

            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            if (data.Row[0].AccountID == "Not Found") {
                addPayment();
            }
            else {
               // alert("You are already define budget with in given parameters");
                $.alert({ title: 'Alert!:', content: 'You are already define budget with in given parameters', });
            }
            $('#spandataloading').hide();
            $('#loader').hide();
            //$('#loadI').attr('class', 'fa fa-gear');


        },
        error: function (error) {
            console.log(error);
        }
    });

 


}       

function deleteBudget(dd) {
    var lid = dd;

    $.confirm({
        theme: 'light',
        title: 'Confirm!',
        content: 'Delete Budget; confirm!',
        buttons: {
            confirm: function () {


                $.ajax({
                    type: 'POST',
                    url: 'Accounts.asmx/deleteBudget',
                    dataType: 'json',
                    data: "{'Bid':'" + lid + "'}",
                    contentType: 'application/json; charset=utf-8',

                    success: function (response) {
                       
                        $.alert({ title: 'Alert!', content: 'Transaction  Deleted', });
                        //alert("");
                        location.reload();
                    },
                    error: function (error) {
                        console.log(error);
                    }
                });

                 
            },
            cancel: function () {

            }

        }
    });



}
        $(function () {
            $('#datetimepicker12').datetimepicker({
                format: 'LD',
                inline: true,
                sideBySide: true
            });
            $('#datetimepicker12').on('dp.change', function (e) {
                var dd = new Date(e.date);
                var dd11 = "00" + dd.getDate();
                var mm11 = dd.getMonth() + 1;
                var mm22 = "00" + mm11;
                document.getElementById("txtDate").value = dd.getFullYear() + "-" + (mm22.substr(mm22.length - 2, 2)) + "-" + dd11.substr(dd11.length - 2, 2);

                
            });

            var dd = new Date();
            var dd11 = "00" + dd.getDate();
            var mm11 = dd.getMonth() + 1;
            var mm22 = "00" + mm11;
            document.getElementById("txtDate").value = dd.getFullYear() + "-" + (mm22.substr(mm22.length - 2, 2)) + "-" + dd11.substr(dd11.length - 2, 2);
        });
        function CallDtChange(a) {

            var dd1 = new Date(a);
            $('#datetimepicker12').data("DateTimePicker").date(dd1);
        }
    
        function OnselectionTo(a) {
           
            document.getElementById("textbox1").value = $("#" + a.id + " option:selected").text();
            $(a).hide();
        }
        function ShowHide(a) {

            $("#" + a).toggle();

        }
   
        
        loadCashBankNewUI("All", "cashID");
        function loadCashBankNewUI(t, control) {
            
            var userid = sessionStorage.getItem("UserID");

            var ChartLevel = window.sessionStorage.getItem("ChartLevel", ChartLevel);


            var type = t;
            $('#spandataloading').show();
            //  var type = "E";
            //$('#loadI').attr('class', 'fa fa-refresh fa-spin');
            //AccountID, AccountTitle.SubCatID, SubCatName, CatID, CatName

      
            $.ajax({
                type: 'POST',
                url: 'Accounts.asmx/getCashBankNewUI_Budget',
                dataType: 'json',
                data: "{'UserID':'" + userid + "','type':'" + type + "'}",
                contentType: 'application/json; charset=utf-8',

                success: function (response) {

                    

                    var txt = '{"Row": ' + response.d + '}';
                    var data = JSON.parse(txt);
                    $('#spandataloading').hide()
                    
                    // yaha loop lage ga na
                    var str = "";
                    var dt = "";
                    var mvalue;
                    var optg = "";
                    var Ccat
                    ////////if (data.Row.length > 0) {
                        
                    ////////    dt = "<option></option><optgroup label='" + data.Row[0].CatName + " - " + data.Row[0].SubCatName + "' > ";
                    ////////    Ccat = data.Row[0].CatName + " - " + data.Row[0].SubCatName;
                    ////////}
                    //////////dt = "<option> Select Source </option>";
                    ////////for (var i = 0; i < data.Row.length; i++) {

                   
                    ////////    if ((data.Row[i].CatName + " - " + data.Row[i].SubCatName) == Ccat) {
                    ////////        balance = data.Row[i].Balance;
                    ////////        // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;
                    ////////        dt = dt + "<option value=" + data.Row[i].AccountID + ">" + data.Row[i].AccountTitle + balance + "</option > ";
                    ////////        Ccat = data.Row[i].CatName + " - " + data.Row[i].SubCatName;
                    ////////    }
                    ////////    else {
                        
                    ////////        dt = dt + "</optgroup>";
                    ////////        str = str + dt;
                    ////////        dt = "<optgroup label='" + data.Row[i].CatName + " - " + data.Row[i].SubCatName + "' > ";
                    ////////        Ccat = data.Row[i].CatName + " - " + data.Row[i].SubCatName;
                    ////////        balance = data.Row[i].Balance;
                    ////////        // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;
                    ////////        dt = dt + "<option value=" + data.Row[i].AccountID + ">" + data.Row[i].AccountTitle + balance + "</option > ";

                    ////////    }


                    ////////}
                    ////////dt = dt + "</optgroup>";



                    if (ChartLevel == '3') {



                        if (data.Row.length > 0) {
                            //alert(data.Row[0].CatName + " - " + data.Row[0].SubCatName);

                            dt = "<option></option><optgroup label='" + data.Row[0].CatName + " - " + data.Row[0].SubCatName + "' > ";
                            Ccat = data.Row[0].CatName + " - " + data.Row[0].SubCatName;
                        }

                        for (var i = 0; i < data.Row.length; i++) {

                            //  alert(data.Row[i].Category);
                            if ((data.Row[i].CatName + " - " + data.Row[i].SubCatName) == Ccat) {
                                balance = data.Row[i].Balance;
                                // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;
                                dt = dt + "<option value=" + data.Row[i].AccountID + ">" + data.Row[i].AccountTitle + balance + "</option > ";
                                Ccat = data.Row[i].CatName + " - " + data.Row[i].SubCatName;
                            }
                            else {
                                // alert(data.Row[i].CatName + " - " + data.Row[i].SubCatName);
                                dt = dt + "</optgroup>";
                                str = str + dt;
                                dt = "<optgroup label='" + data.Row[i].CatName + " - " + data.Row[i].SubCatName + "' > ";
                                Ccat = data.Row[i].CatName + " - " + data.Row[i].SubCatName;
                                balance = data.Row[i].Balance;
                                // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;
                                dt = dt + "<option value=" + data.Row[i].AccountID + ">" + data.Row[i].AccountTitle + balance + "</option > ";

                            }


                        }
                        dt = dt + "</optgroup>";

                    }

                    else if (ChartLevel == '2') {



                        if (data.Row.length > 0) {
                            //alert(data.Row[0].CatName + " - " + data.Row[0].SubCatName);

                            dt = "<option></option><optgroup label='" + data.Row[0].SubCatName + "' > ";
                            Ccat = data.Row[0].SubCatName;
                        }

                        for (var i = 0; i < data.Row.length; i++) {

                            //  alert(data.Row[i].Category);
                            if ((data.Row[i].SubCatName) == Ccat) {
                                balance = data.Row[i].Balance;
                                // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;
                                dt = dt + "<option value=" + data.Row[i].AccountID + ">" + data.Row[i].AccountTitle + balance + "</option > ";
                                Ccat = data.Row[i].SubCatName;
                            }
                            else {
                                // alert(data.Row[i].CatName + " - " + data.Row[i].SubCatName);
                                dt = dt + "</optgroup>";
                                str = str + dt;
                                dt = "<optgroup label='" + data.Row[i].SubCatName + "' > ";
                                Ccat = data.Row[i].SubCatName;
                                balance = data.Row[i].Balance;
                                // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;
                                dt = dt + "<option value=" + data.Row[i].AccountID + ">" + data.Row[i].AccountTitle + balance + "</option > ";

                            }


                        }
                        dt = dt + "</optgroup>";

                    }

                    else if (ChartLevel == '1') {



                        if (data.Row.length > 0) {
                            dt = "<option></option><optgroup> ";

                        }

                        for (var i = 0; i < data.Row.length; i++) {


                            balance = data.Row[i].Balance;

                            dt = dt + "<option value=" + data.Row[i].AccountID + ">" + data.Row[i].AccountTitle + balance + "</option > ";



                        }
                        dt = dt + "</optgroup>";

                    }









                    str = str + dt;
                    document.getElementById(control).innerHTML = str;
                    //$.fn.select2.defaults.set("theme", "bootstrap");
                    $("#" + control).select2({

                        placeholder: "Select Account",
                        allowClear: true

                    });
                    $(".select2-container").css({ "width": "100% !important" })
                    //$('#loadI').attr('class', 'fa fa-gear');
                    if (t == "All") cc = 1;
                    if (t == "Source") pc = 1;

                  
                    if (pc == 1 && cc == 1) {
                      
                        LoadTransaction();
                    }

                },
                error: function (error) {
                    console.log(error);
                }
            });



         


            function EditRow(a) {
            
                //var mDiv = document.getElementById("ID" + a.id);
                //var mIcon = document.getElementById("C" + a.id);
                
                //mIcon.className = mIcon.className + " border1";
                // mIcon.addEventListener('click', function () { loadIcon(); }, false);
               
                document.location.href = "EditCategory.html?ID=" + a.id;


            }

        }
  