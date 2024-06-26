var FileID = "";
document.getElementById("CurrencyName").innerHTML = SettingValues.CurrencyCode;
tableSize();
function tableSize() {
    // inputDiv

    var idh = $("#inputDiv").height();
    //$("#Table1").height($("#maincontents").height() - (idh + 55 ));
    //alert($("#maincontents").height());
    //alert(idh);
}
// document.getElementById("spandataloading").style.display = "block";
var pc = 0;
var cc = 0;
var InputOption = sessionStorage.getItem("InputOption");

var edit1 = [];
edit1[0] = "addexpenses";
edit1[1] = InputOption;
getDate();
//loadPAccounts();
//loadCashBank();
// document.getElementById("spandataloading").style.display = "none";

function getDate() {
    var date = new Date();

    var day = date.getDate();
    var month = date.getMonth() + 1;
    var year = date.getFullYear();

    if (month < 10) month = "0" + month;
    if (day < 10) day = "0" + day;

    var today = year + "-" + month + "-" + day;
    //alert(today);

    document.getElementById('txtDate').value = today;
}
function loadPAccounts() {
    var userid = sessionStorage.getItem("UserID");
    var userid = sessionStorage.getItem("UserID");
    $('#spandataloading').show();
    var type = "All";
    //$('#loadI').attr('class', 'fa fa-refresh fa-spin');


  $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/getCashBank',
            dataType: 'json',
            data: "{'UserID':'" + userid + "','type':'" + type + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {

               

                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);

                //  alert(data.Row[0].District);
                // yaha loop lage ga na
                var str = "";
                var dt = "";
                var mvalue;
                dt = "<option> Select Account </option>";
                for (var i = 0; i < data.Row.length; i++) {
                    //  alert(data.Row[i].Category);



                    dt = dt + "<option value=" + data.Row[i].AccID + ">" + data.Row[i].Title + "</option > "



                }

                document.getElementById("paymentsID").innerHTML = dt;
                $('#spandataloading').hide();
                pc = 1;
                //alert(cc + " pc " + pc);
                if (pc == 1 && cc == 1) {
                    LoadTransaction();
                }
                //$('#loadI').attr('class', 'fa fa-gear');


            },
            error: function (error) {
                console.log(error);
            }
        });
   

    function EditRow(a) {
        // alert(a.id);
        //var mDiv = document.getElementById("ID" + a.id);
        //var mIcon = document.getElementById("C" + a.id);
        //alert(mIcon.className);
        //mIcon.className = mIcon.className + " border1";
        // mIcon.addEventListener('click', function () { loadIcon(); }, false);
        //alert(mIcon.className);
        document.location.href = "EditCategory.html?ID=" + a.id;


    }

}
function loadCashBank() {
    var userid = sessionStorage.getItem("UserID");
    var type = "source";
    $('#spandataloading').show();
    //  var type = "E";
    //$('#loadI').attr('class', 'fa fa-refresh fa-spin');
    //AccountID, AccountTitle.SubCatID, SubCatName, CatID, CatName


 

        $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/getCashBank',
            dataType: 'json',
            data: "{'UserID':'" + userid + "','type':'" + type + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {

                



                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);
                $('#spandataloading').hide()
                //  alert(data.Row[0].District);
                // yaha loop lage ga na
                var str = "";
                var dt = "";
                var mvalue;
                var optg = "";
                dt = "<option> Select Source </option>";
                for (var i = 0; i < data.Row.length; i++) {

                    //  alert(data.Row[i].Category);


                    balance = data.Row[i].Balance;
                    // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;

                    dt = dt + "<option value=" + data.Row[i].AccID + ">" + data.Row[i].Title + balance + "</option > ";



                }

                document.getElementById("cashID").innerHTML = dt;


                //$('#loadI').attr('class', 'fa fa-gear');
                cc = 1;
                //alert(cc + " cc " + pc);
                if (pc == 1 && cc == 1) {
                    LoadTransaction();
                }

            },
            error: function (error) {
                console.log(error);
            }
        });


 

    function EditRow(a) {
        // alert(a.id);
        //var mDiv = document.getElementById("ID" + a.id);
        //var mIcon = document.getElementById("C" + a.id);
        //alert(mIcon.className);
        //mIcon.className = mIcon.className + " border1";
        // mIcon.addEventListener('click', function () { loadIcon(); }, false);
        //alert(mIcon.className);
        document.location.href = "EditCategory.html?ID=" + a.id;


    }

}
var forText, ForText;
function setValue(a) {
    // alert(a.id);
    mValTo = a.value;
    var ttfor = $("#paymentsID option:selected").text();
    var ttfor1 = ttfor.split("[");
    ForText = ttfor1[0];
    // alert(a.value + "---" + ttfor);



    // alert(a.value);
}
var srcText;
function setValeCash(a) {

    mValFrom = a.value;
    var tt = $("#cashID option:selected").text();
    var tt1 = tt.split("[");
    srcText = tt1[0].substr(0, tt1[0].length - 3);
    //alert(a.value+"---" + tt);

}
function addPayment() {
    // alert("1");
    //alert("payment");
    $('#loader').show();
    //string Source, DateTime TrDate, string TrAccount, double Amount, string Narration, string Type


    //  var ID = document.getElementById("")
    //alert("Payment AccountID: " + mValTo);
    //alert("Source AccountID: " + mValFrom);
    var userid = window.sessionStorage.getItem("UserID");
    var trAcc = mValTo;
    var source = mValFrom;

    var fd = document.getElementById("txtDate").value.split("-");
    if (fd[0] == "dd") {
        $.alert({ title: 'Alert!', content: 'Please Enter Date', });
        // alert("Please Enter Date");
        return 0;
    }


    //var trdate = fd[2] + "-" + fd[1] + "-" + fd[0];
    var trdate = document.getElementById("txtDate").value;//  "2018-01-01";
    var amt = document.getElementById("txtAmount").value;//5000;
    var narS = document.getElementById("txtNarration").value + ' [From: <a id=' + source + ' href="#" onclick=loadpage(this)><u>' + srcText + '</u><a>]'; //"Paid for Testing';
    var narT = document.getElementById("txtNarration").value + ' [To: <a id=' + trAcc + ' href="#" onclick=loadpage(this)><u>' + ForText + '</u><a>]'; //"Paid for Testing';



    var PaymentType =       document.getElementById("PaymentType").value;

    var ChaqueDate =        document.getElementById("ChaqueDate").value;
    var txtClearingDate =   document.getElementById("txtClearingDate").value;
    var txtPostedDate =     document.getElementById("txtPostedDate").value;
    var txtChaqueNo =       document.getElementById("txtChaqueNo").value;


    var TransectionDate =   document.getElementById("TransectionDate").value;
    var txtTransection =    document.getElementById("txtTransection").value;
    var ChequeType = document.getElementById("ChequeType").value;

    if (ChaqueDate == '') {
        ChaqueDate = '1900-01-01'
    }
    if (TransectionDate == '') {
        TransectionDate = '1900-01-01'
    }
    if (txtClearingDate == '') {
        txtClearingDate = '1900-01-01'
    }
    if (txtPostedDate == '') {
        txtPostedDate = '1900-01-01'
    }
   
    

    if (typeof trAcc == 'undefined' || typeof source == 'undefined' || amt == "") {
        $.alert({ title: 'Alert!', content: 'Invalid input. Transaction Failed', });
        //alert("Invalid input. Transaction Failed");
        $('#loader').hide();
    }

    else {

        FileID = FileID.replace(/,\s*$/, "");
        //alert(FileID);
        FileID = FileID.replace(/'/g, '*');
        //alert(FileID);
        // alert(trdate);
        $('#spandataloading').show();
        $('#iSave').attr('class', 'fa fa-refresh fa-spin');
        var type = "P";

        var Highlighter = document.getElementById("divColor").style.backgroundColor;

        
      //  alert("{'Source':'" + source + "','TrDate':'" + trdate + "','TrAccount':'" + trAcc + "','Amount':'" + amt + "','NarrationS':'" + narS + "','NarrationT':'" + narT + "','Type':'" + type + "','TType':'" + TType + "','LID':'" + LID1 + "','UserID':'" + userid + "','FileID':'" + FileID + "','Highlighter':'" + Highlighter + "','TransectionId':'" + txtTransection + "','TransectionDate':'" + TransectionDate + "','ChaqueNo':'" + txtChaqueNo + "','ChaqueDate':'" + ChaqueDate + "','ChaquePostedDate':'" + txtPostedDate + "','ChaqueClaringDate':'" + txtClearingDate + "','PaymentType':'" + PaymentType + "'}")

            $.ajax({
                type: 'POST',
                url: 'Accounts.asmx/addTransaction',
                dataType: 'json',
                data: "{'Source':'" + source + "','TrDate':'" + trdate + "','TrAccount':'" + trAcc + "','Amount':'" + amt + "','NarrationS':'" + narS + "','NarrationT':'" + narT + "','Type':'" + type + "','TType':'" + TType + "','LID':'" + LID1 + "','UserID':'" + userid + "','FileID':'" + FileID + "','Highlighter':'" + Highlighter + "','TransectionId':'" + txtTransection + "','TransectionDate':'" + TransectionDate + "','ChaqueNo':'" + txtChaqueNo + "','ChaqueDate':'" + ChaqueDate + "','ChaquePostedDate':'" + txtPostedDate + "','ChaqueClaringDate':'" + txtClearingDate + "','PaymentType':'" + PaymentType + "','ChequeType':'" + ChequeType + "'}",
                contentType: 'application/json; charset=utf-8',
                success: function (response) {
                    //alert(response.d);
                    if (TType == "New") {
                        $.alert({ title: 'Alert!', content: 'Transaction Saved.', });
                        // alert("Transaction Saved.");
                        $('#iSave').attr('class', 'fa fa-save');
                        //LoadFile('addexpense.html');
                        //document.location.href = "innerpageframe.html";
                        clearAll();
                    }
                    else {
                        $.alert({ title: 'Alert!', content: 'Transaction Updated', });
                        //alert("Transaction Updated");
                        $('#iSave').attr('class', 'fa fa-save');
                        //LoadFile('dashboard.html');
                        //document.location.href = "innerpageframe.html";
                        clearAll();
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
    Opt = "";
    $('#spandataloading').show()
    $(':input').val('');
    $('#iSave').attr('class', 'fa fa-save');
    $("#paymentsID").select2("val", "");
    $("#paymentsID").trigger('change');
    $("#cashID").select2("val", "");
    $("#cashID").trigger('change');
    $("#AttachmentData").html("<br/>");
    sessionStorage.setItem('InputOption', 'New');
    sessionStorage.setItem('TransID', '');
FileID = "";
    getDate();
    LoadTransaction_List();
    //   document.getElementById("spandataloading").style.display = "none";
    $('#spandataloading').hide()
}
function Sharing() {
    // Shared
    if (document.getElementById("Shared").style.display == "block")
        document.getElementById("Shared").style.display = "none";
    else
        document.getElementById("Shared").style.display = "block";
}

function LoadTransaction() {


    //alert(edit1[1]);
    if (edit1[1] == "Edit") {
        //LoadTransaction();
        TType = "Edit";
        LID1 = sessionStorage.getItem("TransID");

        var TransID = sessionStorage.getItem("TransID");
        var userid = sessionStorage.getItem("UserID");

 
            $.ajax({
                type: 'POST',
                url: 'Accounts.asmx/LoadTransaction',
                dataType: 'json',
                data: "{'TransID':'" + TransID + "', 'TType':'P', 'UserID':'" + userid + "'}",
                contentType: 'application/json; charset=utf-8',

                success: function (response) { 

                    var txt = '{"Row": ' + response.d + '}';
                    var data = JSON.parse(txt);
          
                    var str = "";
                    var dt = "";
                    var mvalue;
                    //dt = "<option> Select Account </option>";
                    //for (var i = 0; i < data.Row.length; i++) {
                    //    //  alert(data.Row[i].Category);
                    //    dt = dt + "<option value=" + data.Row[i].AccID + ">" + data.Row[i].Title + "</option > "
                    //}
                    //$("#paymentsID").val(data.Row[0].AccId_Payment).trigger('change');
                    //document.getElementById("paymentsID").value = data.Row[0].AccId_Payment;
                    //alert("*"+data.Row[0].AccId_Payment + "*  *" + data.Row[0].AccId_Cash+"*" );
                    $("#paymentsID").val(data.Row[0].AccId_Payment);
                    $('#paymentsID').trigger('change');
                    //document.getElementById("cashID").value = data.Row[0].AccId_Cash;
                    $("#cashID").val(data.Row[0].AccId_Cash);
                    $('#cashID').trigger('change');
                    var payment1 = document.getElementById("paymentsID");
                    var cash1 = document.getElementById("cashID");

                    //setValue(payment1);
                    //setValeCash(cash1);
                    mValTo = data.Row[0].AccId_Payment;
                    mValFrom = data.Row[0].AccId_Cash;
                    //var tt = $("#cashID option:selected").text();
                    //var tt1 = tt.split("[");
                    srcText = data.Row[0].AccId_CashT
                    //var ttfor = $("#paymentsID option:selected").text();
                    //var ttfor1 = ttfor.split("[");
                    ForText = data.Row[0].AccId_PaymentT;

                    document.getElementById("txtAmount").value = data.Row[0].Amount;
                    var nar = data.Row[0].Narration.split("[");
                    document.getElementById("txtNarration").value = nar[0];
                    document.getElementById("txtDate").value = data.Row[0].TDate;

                    if (data.Row[0].Highlighter == "") { document.getElementById("divColor").style.backgroundColor = "rgb(255, 255, 255)" } else {
                        document.getElementById("divColor").style.backgroundColor = data.Row[0].Highlighter;
                    }

                    document.getElementById("PaymentType").value = data.Row[0].PaymentType
                    document.getElementById("ChaqueDate").value = GetPatternDate( data.Row[0].ChaqueDate)
                    document.getElementById("txtClearingDate").value = GetPatternDate(data.Row[0].ChaqueClaringDate)
                    document.getElementById("txtPostedDate").value = GetPatternDate( data.Row[0].ChaquePostedDate)
                    document.getElementById("txtChaqueNo").value = data.Row[0].ChaqueNo
                    document.getElementById("TransectionDate").value = GetPatternDate(data.Row[0].TransectionDate)
                    document.getElementById("txtTransection").value = data.Row[0].TransectionId

                    

                    PaymentType(data.Row[0].PaymentType)

                    // alert(data.Row[0]);
                    $('#spandataloading').hide();

                    //$('#loadI').attr('class', 'fa fa-gear');
                    //alert(TransID);
                    LoadAttachmentsTransactionIDwise(TransID);

                },
                error: function (error) {
                    //alert("err111");
                    console.log(error);
                }
            });


         

    }
}

function GetPatternDate(date) {
    var PatternDate = new Date(date);
    return PatternDate.getFullYear() + '-' + ('0' + (PatternDate.getMonth() + 1)).slice(-2) + '-' + ('0' + PatternDate.getDate()).slice(-2);

}


LoadTransaction_List();

function LoadTransaction_List() {
    var edate = new Date();
    var sdate = new Date(edate.getFullYear(), edate.getMonth() - 1, edate.getDate());

    var accTitle = sessionStorage.getItem("AccountTitle");
    var userid = sessionStorage.getItem("UserID");
    //var Sdate = document.getElementById("txtDate1").value;
    //var Edate = document.getElementById("txtDate2").value;
    var Sdate = sdate.getFullYear() + "/" + (sdate.getMonth() + 1) + "/" + sdate.getDate();
    var Edate = edate.getFullYear() + "/" + (edate.getMonth() + 1) + "/" + edate.getDate();
    var SD = Sdate.split("/");
    var ED = Edate.split("/");
    //Sdate = SD[2] + "/" + SD[1] + "/" + SD[0];
    //Edate = ED[2] + "/" + ED[1] + "/" + ED[0];
    $('#loader').show();
 

        $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/LoadTransacion_history_ledger',
            dataType: 'json',
            data: "{'Type':'" + "P" + "','UserID':'" + userid + "','StartDate':'" + Sdate + "','EndDate':'" + Edate + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {

                

                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);


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
                //alert(data.Row.length);

                for (var i = 0; i < data.Row.length; i++) {

                    mRow = mRow + 1;


                    dt = dt + " <tr>";
                    dt = dt + "   <td class='mTD'>" + mRow + ".</td>";
                    dt = dt + "   <td  class='mTD'> " + data.Row[i].TDate + "</td>";//<a href='#' onclick='callPage(this);'><i style='color:" + data.Row[i].Color + ";' class='" + data.Row[i].Icon + "' ></i>" + " " + data.Row[i].AccTitle + "</a></td>";
                    dt = dt + "   <td class='mTD' id='tdFrom'>" + data.Row[i].AccTitle + "</td>";
                    var nar = data.Row[i].Narration.split("<u>");
                    var nar2 = nar[1].split("</u>");
                    dt = dt + "   <td class='mTD' id='tdNarration'>" + nar2[0] + "</td>";
                    //dt = dt + "   <td id='tdNarration' >" + data.Row[i].Narration + "</td>";
                    dt = dt + "   <td class='mTD  textar'>" + data.Row[i].TotalAmount + "</td>";
                    //dt = dt + "   <td class='mTD  textac'>" + data.Row[i].SharedRead + "</td>";
                    dt = dt + "   <td class='mTD  textac'><a href='#' onclick=loadpageEdit('" + data.Row[i].Lid + ":P" + "')><i class='fa fa-edit'></i></a></td>";
                    dt = dt + "  <td class='mTD textac'><a href='#' style='color:red;' onclick=deleteIT('" + data.Row[i].Lid + "')><i class='fa fa-trash'></i></a></td>"
                    dt = dt + "   <td class='mTD textac'> <a href='#' id=" + data.Row[i].Lid + " onclick='GetPDF(this.id)' style='text-align:right;color:#757472;'><i class='fa fa-file-pdf-o'> </i></a></td>";


                    dt = dt + "</tr>";



                    str = str + dt;
                    dt = "";
                }


                document.getElementById("ledger").innerHTML = str;
                //AccountSharedwithUserName(accid, userid);

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
    //alert(c);
    var ids = c.split(":");

    sessionStorage.setItem("TransID", ids[0]);
    sessionStorage.setItem("TransType", ids[1]);
    sessionStorage.setItem("InputOption", "Edit");
    edit1[0] = "addexpenses";
    edit1[1] = "Edit";
    if (ids[1] == "P") {
        LoadTransaction();
    }
    //if (ids[1] == "R") {
    //    LoadFile("addIncome.html?id=Edit");
    //}
    //alert(c.id);
}

function deleteIT(dd) {
    var lid = dd;

    $.confirm({
        theme: 'light',
        title: 'Confirm!',
        content: 'Delete Transaction; confirm!',
        buttons: {
            confirm: function () {
 
                    $.ajax({

                        type: 'POST',
                        url: 'Accounts.asmx/deleteLedgerbyID',
                        dataType: 'json',
                        data: "{'Lid':'" + lid + "'}",
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
go();
window.addEventListener('resize', go);

function go() {


    var cardContainerW = $("#dFlexWW").width();
    var cardContainerH = $("#dFlexWW").height();
    var w = window.innerWidth
        || document.documentElement.clientWidth
        || document.body.clientWidth;
    if (w < 1200) {
        $("#CalHead").hide();
    }
    else {
        $("#CalHead").show();

    }
    if (w < 800) {
        $("#Table1").hide();
    }
    else {
        $("#Table1").show();
    }
    var IH = $("#inputDiv").height();
    // maincontents
    var MH = $("#maincontents").height();

    // $("#Table1").height((MH - IH) - 35);

    //alert(w);

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

        //alert(mm22);//.substring(dd11.length - 3, 2));
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
// $('#datetimepicker12').on('dp.change', function (e) { console.log(e.date); });

//$(function () {

//    $("#OptGroupText").children("optgroup").children("option").hide();
//    $("#OptGroupText").hide()
//});
//var lastoptgroup;
//function expend99(a) {
//    //$("#OptGroupText").children("optgroup").children("option").hide();
//    if (lastoptgroup != null)
//        $(lastoptgroup).children("option").hide();
//    //else
//    $(a).children("option").show();

//    //alert(lastoptgroup.id);
//    lastoptgroup = a;
//    ////$("#OptGroupText").children("optgroup").children("option").show();
//    //alert(lastoptgroup.id);
//}
function OnselectionTo(a) {
    //alert(a.value);
    document.getElementById("textbox1").value = $("#" + a.id + " option:selected").text();
    $(a).hide();
}
function ShowHide(a) {

    $("#" + a).toggle();

}

//GetCategory();
//function GetCategory() {
//    var userid = sessionStorage.getItem("UserID");
//    var type = "source";
//    $('#spandataloading').show();
//    //  var type = "E";
//    //$('#loadI').attr('class', 'fa fa-refresh fa-spin');

//    $.ajax({
//        type: 'POST',
//        url: 'Accounts.asmx/loadCat',
//        dataType: 'json',
//        data: "{'Type':'ALL','UserID':'" + userid + "'}",
//        contentType: 'application/json; charset=utf-8',

//        success: function (response) {

//            var txt = '{"Row": ' + response.d + '}';
//            var data = JSON.parse(txt);
//            $('#spandataloading').hide()
//            //  alert(data.Row[0].District);
//            // yaha loop lage ga na
//            var str = "";
//            var dt = "";
//            var mvalue;
//            dt = "<option value='00000000-0000-0000-0000-000000001234'> Select </option>";
//            for (var i = 0; i < data.Row.length; i++) {
//                //  alert(data.Row[i].Category);


//                balance = data.Row[i].Balance;
//                // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;

//                dt = dt + "<option value=" + data.Row[i].CatId + ">" + data.Row[i].category + "(" + data.Row[i].Balance + ")" + "</option > ";



//            }

//            document.getElementById("Category").innerHTML = dt;
//            //document.getElementById("NCategory").innerHTML = dt;


//            //$('#loadI').attr('class', 'fa fa-gear');


//        },
//        error: function (error) {
//            console.log(error);
//        }
//    });
//}

//function GetSubCategory(catid, cbo) {
//    var userid = sessionStorage.getItem("UserID");
//    var type = "source";
//    $('#spandataloading').show();
//    //  var type = "E";
//    //$('#loadI').attr('class', 'fa fa-refresh fa-spin');

//    $.ajax({
//        type: 'POST',
//        url: 'Accounts.asmx/loadCatbyID',
//        dataType: 'json',
//        data: "{'CatID':'" + catid + "'}",
//        contentType: 'application/json; charset=utf-8',

//        success: function (response) {

//            var txt = '{"Row": ' + response.d + '}';
//            var data = JSON.parse(txt);
//            $('#spandataloading').hide()
//            //  alert(data.Row[0].District);
//            // yaha loop lage ga na
//            var str = "";
//            var dt = "";
//            var mvalue;
//            dt = "<option value='00000000-0000-0000-0000-000000001234'> Select </option>";
//            for (var i = 0; i < data.Row.length; i++) {
//                //  alert(data.Row[i].Category);


//                balance = data.Row[i].Balance;
//                // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;

//                dt = dt + "<option value=" + data.Row[i].CatId + ">" + data.Row[i].category + "(" + data.Row[i].Balance + ")" + "</option > ";



//            }

//            document.getElementById(cbo).innerHTML = dt;


//            //$('#loadI').attr('class', 'fa fa-gear');


//        },
//        error: function (error) {
//            console.log(error);
//        }
//    });
//}

//function getAccountbySubCatID(subcatID, cbo) {
//    var userid = window.sessionStorage.getItem("UserID");



//    $('#loadI').attr('class', 'fa fa-refresh fa-spin');
//    //loading script
//    $.ajax({
//        type: 'POST',
//        url: 'Accounts.asmx/loadAccountsbyID',
//        dataType: 'json',
//        data: "{'SubCatID':'" + subcatID + "'}",
//        contentType: 'application/json; charset=utf-8',

//        success: function (response) {

//            var txt = '{"Row": ' + response.d + '}';
//            var data = JSON.parse(txt);

//            //  alert(data.Row[0].District);
//            // yaha loop lage ga na
//            var dt = "";
//            var mvalue;
//            dt = "<option value='00000000-0000-0000-0000-000000001234'> Select </option>";
//            for (var i = 0; i < data.Row.length; i++) {
//                //  alert(data.Row[i].Category);


//                balance = data.Row[i].Balance;
//                // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;

//                dt = dt + "<option value=" + data.Row[i].AccountID + ">" + data.Row[i].AccountTitle + "(" + data.Row[i].Balance + ")" + "</option > ";



//            }

//            document.getElementById(cbo).innerHTML = dt;
//            //  $('#loadI').removeAttr('class');// attr('class', 'fa fa-gear');

//            $('#loadI').attr('class', 'fa fa-gear');


//        },
//        error: function (error) {
//            console.log(error);
//        }
//    });
//}

//var FormOption = "";
//function ShowPopup(a) {
//   // alert(a);
//    $("#ModelTitle").html('Select <span style="color:oranged;">' + a+ '</span> Account');
//    $("#myAddExpes").modal();
//    FormOption = a;

//}
//$('#myAddExpes').on('hidden.bs.modal', function (e) {
//    if (Opt == "Cancel") {
//        //alert("Reminder");
//        //SendInvite("Reminder");
//        alert(FormOption + " Cancel");
//    }
//    else if (Opt == "Submit") {
//        //alert("newInvitation");
//        //SendInvite("newInvitation");
//        var tt;
//        if (FormOption == "To") {
//            tt = $("#AccountTitle option:selected").text();
//            document.getElementById("paymentsID").value = tt;
//            ForText = tt;
//            mValTo = $("#AccountTitle").val();
//            alert(tt + ForText + mValTo);
//        }
//        else {
//           // document.getElementById("cashID").value = document.getElementById("AccountTitle").value;
//            tt = $("#AccountTitle option:selected").text();
//            document.getElementById("cashID").value = tt;
//            srcText = tt;
//            mValFrom = $("#AccountTitle").val();
//            alert(tt + srcText + mValFrom);
//        }
//        //alert(FormOption + " Submit");
//    }

//    // this handler is detached after it has run once
//});




loadCashBankNewUI("All", "paymentsID");
loadCashBankNewUI("Source", "cashID");
function loadCashBankNewUI(t, control) {
    //alert("newUI");
    var userid = sessionStorage.getItem("UserID");
    var ChartLevel = window.sessionStorage.getItem("ChartLevel", ChartLevel);
    var type = t;
    $('#spandataloading').show();
    //  var type = "E";
    //$('#loadI').attr('class', 'fa fa-refresh fa-spin');
    //AccountID, AccountTitle.SubCatID, SubCatName, CatID, CatName


 
        $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/getCashBankNewUI',
            dataType: 'json',
            data: "{'UserID':'" + userid + "','type':'" + type + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {

               


                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);
                $('#spandataloading').hide()
                //  alert(data.Row[0].District);
                // yaha loop lage ga na
                var str = "";
                var dt = "";
                var mvalue;
                var optg = "";
                var Ccat



                if (ChartLevel == '3') { 



                if (data.Row.length > 0) {
                    //alert(data.Row[0].CatName + " - " + data.Row[0].SubCatName);
              
                    //dt = "<option></option><optgroup label='" + data.Row[0].CatPName + " - " + data.Row[0].CatMName + " - " + data.Row[0].CatName + " - " + data.Row[0].SubCatName + "' > ";
                    dt = "<option></option><optgroup label='" + data.Row[0].CatName + " - " + data.Row[0].SubCatName + "' > ";
                    Ccat = data.Row[0].CatName + " - " + data.Row[0].SubCatName;
                }
         
                for (var i = 0; i < data.Row.length; i++) {

                    //  alert(data.Row[i].Category);
                    if ((data.Row[i].CatName + " - " + data.Row[i].SubCatName) == Ccat) {

                        
                        if (data.Row[i].Balance == "[]") { balance = " [0]" }
                        else { balance = data.Row[i].Balance; }

                        //balance = data.Row[i].Balance;
                        // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;
                        dt = dt + "<option value=" + data.Row[i].AccountID + ">" + data.Row[i].AccountTitle + balance + "</option > ";
                        Ccat = data.Row[i].CatName + " - " + data.Row[i].SubCatName;
                    }
                    else {
                        // alert(data.Row[i].CatName + " - " + data.Row[i].SubCatName);
                        dt = dt + "</optgroup>";
                        str = str + dt;
                        dt = "<optgroup label='" + data.Row[i].CatPName + " - " + data.Row[i].CatMName + " - " + data.Row[i].CatName + " - " + data.Row[i].SubCatName + "' > ";
                        Ccat = data.Row[i].CatName + " - " + data.Row[i].SubCatName;

                        if (data.Row[i].Balance == "[]") { balance = " [0]" }
                        else { balance = data.Row[i].Balance; }

                        //balance = data.Row[i].Balance;
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

                //alert(cc + " cc1 " + pc);
                if (pc == 1 && cc == 1) {
                    // alert(cc + " cc " + pc);
                    LoadTransaction();
                }

            },
            error: function (error) {
                console.log(error);
            }
        });


   


    function EditRow(a) {
        // alert(a.id);
        //var mDiv = document.getElementById("ID" + a.id);
        //var mIcon = document.getElementById("C" + a.id);
        //alert(mIcon.className);
        //mIcon.className = mIcon.className + " border1";
        // mIcon.addEventListener('click', function () { loadIcon(); }, false);
        //alert(mIcon.className);
        document.location.href = "EditCategory.html?ID=" + a.id;


    }

}









///////////////////////////////////////////Abdullah





function AddAttchement() {

    $('#imgfile').click();


}

var file2;
$('#imgfile').hide();
var filename1 = [];


function MyFile() {
    var elm = document.getElementById("imgfile").files[0];
    var filepath = document.getElementById("imgfile").value;

    var filename3 = filepath.substr(filepath.lastIndexOf('\\') + 1);
    var extension = filename3.substr(filename3.lastIndexOf('.') + 1);

    var filename2 = filename3.replace("." + extension, "");
    filename1[0] = filename2;
    filename1[1] = extension;
    getBase64(elm);

}


function getBase64(file) {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
        file2 = reader.result;
        //document.getElementById("MyImage").src = file2;
        SaveAttachemnt(file2);
        return "";
    };
    reader.onerror = function (error) {
        return "";
    };
}
function SaveAttachemnt(file) {
    $('#loader').show();
    if (file.length > 0) {

     
            $.ajax({
                type: 'POST',
                url: 'Accounts.asmx/AddAttachment',
                dataType: 'json',
                data: "{'MyFile':'" + file + "','FileName':'" + filename1[0] + "','FileExtension':'" + filename1[1] + "'}",
                contentType: 'application/json; charset=utf-8',

                success: function (response) {

 


                    window.sessionStorage.setItem("FileID", "'" + response.d + "',");

                    if (FileID.length < 76) {
                        FileID = FileID + sessionStorage.getItem("FileID");
                    }
                    else {
                        //alert("Max two attachments can be attached");

                        $.alert({ title: 'Alert!:', content: 'Maximum two attachments allowed', });

                    }

                    LoadAttachment(FileID);
                    $('#loader').hide();
                },
                error: function (error) {
                    $('#loader').hide();
                    console.log(error);
                }
            });

 
    }
}
function LoadAttachment(FileID) {
    //alert(FileID);

    if (FileID == '') { document.getElementById("AttachmentData").innerHTML = "";}
    else {


        $('#loader').show();
        FileID = FileID.replace(/,\s*$/, "");
        FileID = FileID.replace(/'/g, '*');

        //alert(FileID);

       

            $.ajax({
                type: 'POST',
                url: 'Accounts.asmx/LoadAttachments',
                dataType: 'json',
                data: "{'FileID':'" + FileID + "'}",
                contentType: 'application/json; charset=utf-8',

                success: function (response) {
 


                    var str = "";
                    var dt = "";
                    var mvalue;
                    var optg = "";
                    var txt = '{"Row": ' + response.d + '}';
                    var data = JSON.parse(txt);
                    dt = "";
                    var dt2 = "";
                    for (var i = 0; i < data.Row.length; i++) {

                        var icon1 = "";
                        if (data.Row[i].FileExtension == "pdf") {
                            icon1 = '<i class="fa fa-file-pdf-o" aria-hidden="true"></i>';
                        }
                        else
                            icon1 = '<i class="fa fa-picture-o" aria-hidden="true"></i>';
                        dt = dt + "<a onclick='FilterShowPopup();' id='" + data.Row[i].FileID + "'>" + icon1 + " " + data.Row[i].FileName + "." + data.Row[i].FileExtension + "</a>&nbsp;&nbsp;&nbsp;<a id='" + data.Row[i].FileID + "' href='#' Onclick='DeleteAttachments(this.id)' style='color:red'><i class='fa fa-times-circle'></i></a><br/> ";



                        //dt2 = dt2 + "<center><img style='width:80%;' class='mySlides' id='" + data.Row[i].FileID + "' src='../imgAttachments/" + data.Row[i].FileID + "." + data.Row[i].FileExtension + "'/></center>";
                        if (data.Row[i].FileExtension == "pdf") {
                            dt2 = dt2 + "<center><embed style='width:80%;' height='600px;' class='mySlides' id='" + data.Row[i].FileID + "' src='../imgAttachments/" + data.Row[i].FileID + "." + data.Row[i].FileExtension + "'/></center>";
                        }
                        else {
                            dt2 = dt2 + "<center><embed style='width:80%;' class='mySlides' id='" + data.Row[i].FileID + "' src='../imgAttachments/" + data.Row[i].FileID + "." + data.Row[i].FileExtension + "'/></center>";
                        }



                    }
                    document.getElementById("AttachmentData").innerHTML = dt;
                    dt2 = dt2 + '<button class="w3-button w3-black w3-display-left" onclick="plusDivs(-1)">&#10094;</button>';
                    dt2 = dt2 + '   <button class="w3-button w3-black w3-display-right" onclick = "plusDivs(1)" >&#10095;</button>';
                    document.getElementById("Images").innerHTML = dt2;


                    //for (var i = 0; i < data.Row.length; i++) {

                    //    var icon1 = "";
                    //    if (data.Row[i].FileExtension == "pdf") {
                    //        icon1 = '<i class="fa fa-file-pdf-o" aria-hidden="true"></i>';
                    //    }
                    //    else
                    //        icon1 = '<i class="fa fa-picture-o" aria-hidden="true"></i>';
                    //    dt = dt + "<a onclick='FilterShowPopup();' id='" + data.Row[i].FileID + "'>" + icon1 + " " + data.Row[i].FileName + "." + data.Row[i].FileExtension + "</a>&nbsp;&nbsp;&nbsp;<a id='" + data.Row[i].FileID + "' href='#' Onclick='DeleteAttachments(this.id)' style='color:red'><i class='fa fa-times-circle'></i></a><br/> ";


                    //    //var AttachmentImage = document.getElementById("AttachmentImage");

                    //    //AttachmentImage.src = "../imgAttachments/" + data.Row[i].FileID + "." + data.Row[i].FileExtension + ""; 
                    //}

                    //document.getElementById("AttachmentData").innerHTML = dt;

                    $('#loader').hide();
                },
                error: function (error) {
                    $('#loader').hide();
                    console.log(error);
                }
            });

 

    }
}
function DeleteAttachments(a) {
    
        $('#loader').show();
        $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/DeleteAttachments',
            dataType: 'json',
            data: "{'FileID':'" + a + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {

                





                var str = "";
                var dt = "";
                var mvalue;
                var optg = "";
                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);
                dt = "";
                if (response.d == "0") {

                    //alert("Some Technical Issue");
                    $.alert({ title: 'Alert!:', content: 'Some Technical Issue', });
                }
                else {

                    //alert("Attachment Removed");
                    $.alert({ title: 'Alert!:', content: 'Attachment Removed', });


                    var TransID = sessionStorage.getItem("TransID", TransID);

                    if (TransID != "") {
                        LoadAttachmentsTransactionIDwise(TransID);
                    }
                }

                a = "'" + a + "',";
                //alert(a);

                FileID = FileID.replace(a, '');
                //alert(FileID);


                LoadAttachment(FileID);
                //alert(FileID);
                $('#loader').hide();
            },
            error: function (error) {
                $('#loader').hide();
                console.log(error);
            }
        });

  

}






//function LoadAttachmentsTransactionIDwise(TransID) {

//    $.getJSON('https://api.ipify.org/?format=json', function (data) {

//        var Information = (JSON.stringify(data, null, 2));
//        var PostData = "{'TransactionID':'" + TransID + "'}";
//    $.ajax({
//        type: 'POST',
//        url: 'Accounts.asmx/LoadAttachmentsTransactionIDwise',
//        dataType: 'json',
//        data: "{'TransactionID':'" + TransID + "'}",
//        contentType: 'application/json; charset=utf-8',

//        success: function (response) {

//            if (response.d.length === undefined) { var GetData = 0; }
//            else { var GetData = response.d.length; }

//            var MunshiLog = {
//                AjaxFunction: "Accounts.asmx/LoadAttachmentsTransactionIDwise",
//                POST: PostData.length,
//                GET: GetData,
//                InformationJSONString: Information,
//                Email: sessionStorage.getItem("email")
//            };

//            Log(MunshiLog);


//            var str = "";
//            var dt = "";
//            var mvalue;
//            var optg = "";
//            var txt = '{"Row": ' + response.d + '}';
//            var data = JSON.parse(txt);
//            dt = "";
//            for (var i = 0; i < data.Row.length; i++) {

//                var icon1 = "";
//                if (data.Row[i].FileExtension == "pdf") {
//                    icon1 = '<i class="fa fa-file-pdf-o" aria-hidden="true"></i>';
//                }
//                else
//                    icon1 = '<i class="fa fa-picture-o" aria-hidden="true"></i>';
//                dt = dt + "<a onclick='FilterShowPopup();' id='" + data.Row[i].FileID + "'>" + icon1 + " " + data.Row[i].FileName + "." + data.Row[i].FileExtension + "</a>&nbsp;&nbsp;&nbsp;<a id='" + data.Row[i].FileID + "' href='#' Onclick='DeleteAttachments(this.id)' style='color:red'><i class='fa fa-times-circle'></i></a><br/> ";


//                var AttachmentImage = document.getElementById("AttachmentImage");

//                AttachmentImage.src = "../imgAttachments/" + data.Row[i].FileID + "." + data.Row[i].FileExtension + ""; 



//            }

//            document.getElementById("AttachmentData").innerHTML = dt;

//        },
//        error: function (error) {

//            console.log(error);
//        }
//        });

//    });

//}




function LoadAttachmentsTransactionIDwise(TransID) {
    $('#loader').show();

    $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/LoadAttachmentsTransactionIDwise',
            dataType: 'json',
            data: "{'TransactionID':'" + TransID + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {

           
           


                var str = "";
                var dt = "";
                var mvalue;
                var optg = "";
                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);
                dt = "";
                var dt2 = "";
                for (var i = 0; i < data.Row.length; i++) {

                    var icon1 = "";
                    if (data.Row[i].FileExtension == "pdf") {
                        icon1 = '<i class="fa fa-file-pdf-o" aria-hidden="true"></i>';
                    }
                    else
                        icon1 = '<i class="fa fa-picture-o" aria-hidden="true"></i>';
                    dt = dt + "<a onclick='FilterShowPopup();' id='" + data.Row[i].FileID + "'>" + icon1 + " " + data.Row[i].FileName + "." + data.Row[i].FileExtension + "</a>&nbsp;&nbsp;&nbsp;<a id='" + data.Row[i].FileID + "' href='#' Onclick='DeleteAttachments(this.id)' style='color:red'><i class='fa fa-times-circle'></i></a><br/> ";

                    if (data.Row[i].FileExtension == "pdf") {
                        dt2 = dt2 + "<center><embed style='width:80%;' height='600px;' class='mySlides' id='" + data.Row[i].FileID + "' src='../imgAttachments/" + data.Row[i].FileID + "." + data.Row[i].FileExtension + "'/></center>";
                    }
                    else {
                        dt2 = dt2 + "<center><embed style='width:80%;' class='mySlides' id='" + data.Row[i].FileID + "' src='../imgAttachments/" + data.Row[i].FileID + "." + data.Row[i].FileExtension + "'/></center>";
                    }





                }
                document.getElementById("AttachmentData").innerHTML = dt;
                dt2 = dt2 + '<button class="w3-button w3-black w3-display-left" onclick="plusDivs(-1)">&#10094;</button>';
                dt2 = dt2 + '   <button class="w3-button w3-black w3-display-right" onclick = "plusDivs(1)" >&#10095;</button>';
                document.getElementById("Images").innerHTML = dt2;
                $('#loader').hide();
            },
            error: function (error) {
                $('#loader').hide();
                console.log(error);
            }
        });

     

}
