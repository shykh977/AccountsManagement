
        document.getElementById("CurrencyName").innerHTML = SettingValues.CurrencyCode;
        tableSize();
        function tableSize() {
            // inputDiv

            var idh = $("#inputDiv").height();
            //$("#Table1").height($("#maincontents").height() - (idh +  55));
            //alert($("#maincontents").height());
        }
        var pc = 0;
        var cc = 0;

        var userid = sessionStorage.getItem("UserID");
        //var edit1 = window.location.href.split("?id=");
        var InputOption = sessionStorage.getItem("InputOption");

        var edit1 = [];
        edit1[0] = "addIncome";
        edit1[1] = InputOption;

        getDate();
        //loadPAccounts();
        //loadCashBank();
        function loadPAccounts() {
            //alert(userid);
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


                        dt = dt + "<option value=" + data.Row[i].AccID + ">" + data.Row[i].Title + "</option > ";



                    }

                    document.getElementById("paymentsID").innerHTML = dt;
                    $('#spandataloading').hide();
                    pc = 1;
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
            //  alert(userid);
            $('#spandataloading').show();
            //var type = "I";
            var type = "source";
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
                    var balance;
                    dt = "<option> Select Source </option>";
                    for (var i = 0; i < data.Row.length; i++) {
                        //  alert(data.Row[i].Category);

                        balance = data.Row[i].Balance;
                        // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;

                        dt = dt + "<option value=" + data.Row[i].AccID + ">" + data.Row[i].Title + balance + "</option > "
                        balance = 0;


                    }

                    document.getElementById("cashID").innerHTML = dt;
                    $('#spandataloading').hide();

                    cc = 1;
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

        //function setValue(a) {
        //    mValTo = a.value;
        //    // alert(a.value);
        //}
        //function setValeCash(a) {
        //    mValFrom = a.value;
        //}
        function addPayment2() {

            //string Source, DateTime TrDate, string TrAccount, double Amount, string Narration, string Type


            //  var ID = document.getElementById("")
            //alert("Payment AccountID: " + mValTo);
            //alert("Source AccountID: " + mValFrom);
            $('#loader').show();
            var trAcc = mValTo;
            var source = mValFrom;

            var trdate = document.getElementById("txtDate").value;//  "2018-01-01";
            var amt = document.getElementById("txtAmount").value;//5000;
            var nar = document.getElementById("txtNarration").value;//"Paid for Testing";
            var type = "I";


            if (typeof trAcc == 'undefined' || typeof source == 'undefined' || amt == "") {
                $.alert({ title: 'Alert!', content: 'Invalid input. Transaction Failed', });
                //alert("Invalid input. Transaction Failed");
            }
            else {
                //alert(trdate);
                $('#spandataloading').show();
                $('#iSave').attr('class', 'fa fa-refresh fa-spin');
                $.ajax({
                    type: 'POST',
                    url: 'Accounts.asmx/addTransaction',
                    dataType: 'json',
                    data: "{'Source':'" + source + "','TrDate':'" + trdate + "','TrAccount':'" + trAcc + "','Amount':'" + amt + "','Narration':'" + nar + "','Type':'" + type + "'}",
                    contentType: 'application/json; charset=utf-8',

                    success: function (response) {

                        //alert(response.d);
                        $.alert({ title: 'Alert!', content: 'Transaction Saved.', });
                        //alert("Transaction Saved.");
                        $('#iSave').attr('class', 'fa fa-save');
                        //var txt = '{"Row": ' + response.d + '}';
                        //var data = JSON.parse(txt);

                        $('#loader').hide();
                        $('#spandataloading').hide();
                        clearAll();

                        //$('#loadI').attr('class', 'fa fa-gear');


                    },
                    error: function (error) {
                        console.log(error);
                    }
                });
            }

        }
        var forText, ForText;
        function setValue(a) {
            mValTo = a.value;
            var ttfor = $("#paymentsID option:selected").text();
            var ttfor1 = ttfor.split("[");
            ForText = ttfor1;


            // alert(a.value);
        }
        var srcText;
        function setValeCash(a) {
            mValFrom = a.value;
            var tt = $("#cashID option:selected").text();
            var tt1 = tt.split("[");
            srcText = tt1[0].substr(0, tt1[0].length - 3);


        }

        function addPayment() {


            //string Source, DateTime TrDate, string TrAccount, double Amount, string Narration, string Type


            //  var ID = document.getElementById("")
            //alert("Payment AccountID: " + mValTo);
            //alert("Source AccountID: " + mValFrom);
            var userid = window.sessionStorage.getItem("UserID");
            var trAcc = mValTo;
            var source = mValFrom;
            var fd = document.getElementById("txtDate").value.split("/");
            if (fd[0] == "dd") {
                $.alert({ title: 'Alert!', content: 'Please Enter Date', });
                return 0;
            }


            // var trdate = fd[2] + "-" + fd[1] + "-" + fd[0];//  "2018-01-01";
            var trdate = document.getElementById("txtDate").value;
            var amt = document.getElementById("txtAmount").value;//5000;
            var narS = document.getElementById("txtNarration").value + ' [To: <a id=' + source + ' href="#" onclick=loadpage(this)><u>' + srcText + '</u><a>]'; //"Paid for Testing';
            var narT = document.getElementById("txtNarration").value + ' [From: <a id=' + trAcc + ' href="#" onclick=loadpage(this)><u>' + ForText + '</u><a>]'; //"Paid for Testing';

            if (typeof trAcc == 'undefined' || typeof source == 'undefined' || amt == "") {
                $.alert({ title: 'Alert!', content: 'Invalid input. Transaction Failed', });
                $("#loader").hide();
                //alert("Invalid input. Transaction Failed");
            }
            else {
                //alert(trdate);
                $('#spandataloading').show();
                $('#iSave').attr('class', 'fa fa-refresh fa-spin');
                var type = "R";
                $.ajax({
                    type: 'POST',
                    url: 'Accounts.asmx/addTransaction',
                    dataType: 'json',
                    data: "{'Source':'" + source + "','TrDate':'" + trdate + "','TrAccount':'" + trAcc + "','Amount':'" + amt + "','NarrationS':'" + narS + "','NarrationT':'" + narT + "','Type':'" + type + "','TType':'" + TType + "','LID':'" + LID1 + "','UserID':'" + userid + "'}",
                    contentType: 'application/json; charset=utf-8',

                    success: function (response) {

                        //alert(response.d);
                        if (TType == "New") {
                            $.alert({ title: 'Alert!', content: 'Transaction Saved.', });
                            //alert("Transaction Saved.");
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
                        $('#spandataloading').hide();



                        //$('#loadI').attr('class', 'fa fa-gear');


                    },
                    error: function (error) {
                        console.log(error);
                    }
                });
            }

        }
        function getDate() {
            var date = new Date();

            var day = date.getDate();
            var month = date.getMonth() + 1;
            var year = date.getFullYear();

            if (month < 10) month = "0" + month;
            if (day < 10) day = "0" + day;

            var today = year + "-" + month + "-" + day;


            document.getElementById('txtDate').value = today;
        }
        function clearAll() {
            // document.getElementById('myform').reset();
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
            sessionStorage.setItem('InputOption', 'New');
            getDate();
            //   document.getElementById("spandataloading").style.display = "none";
            $('#spandataloading').hide();

            getDate();
        }
        //function getDate() {
        //    var date = new Date();

        //    var day = date.getDate();
        //    var month = date.getMonth() + 1;
        //    var year = date.getFullYear();

        //    if (month < 10) month = "0" + month;
        //    if (day < 10) day = "0" + day;

        //    var today = year + "-" + month + "-" + day;


        //    document.getElementById('txtDate').value = today;
        //}
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
                    data: "{'TransID':'" + TransID + "', 'TType':'R', 'UserID':'" + userid + "'}",
                    contentType: 'application/json; charset=utf-8',

                    success: function (response) {

                        var txt = '{"Row": ' + response.d + '}';
                        var data = JSON.parse(txt);
                        //alert(data.Row[0]);
                        //  alert(data.Row[0].District);
                        // yaha loop lage ga na
                        var str = "";
                        var dt = "";
                        var mvalue;
                        //dt = "<option> Select Account </option>";
                        //for (var i = 0; i < data.Row.length; i++) {
                        //    //  alert(data.Row[i].Category);
                        //    dt = dt + "<option value=" + data.Row[i].AccID + ">" + data.Row[i].Title + "</option > "
                        //}
                        //var payment1 = document.getElementById("paymentsID");
                        //var cash1 = document.getElementById("cashID");
                        //document.getElementById("paymentsID").value = data.Row[0].AccId_Payment;

                        //document.getElementById("cashID").value = data.Row[0].AccId_Cash;

                        //setValue(payment1);
                        //setValeCash(cash1);
                        // alert("*" + data.Row[0].AccId_Payment + "*  *" + data.Row[0].AccId_Cash + "*");
                        $("#paymentsID").val(data.Row[0].AccId_Cash);
                        $('#paymentsID').trigger('change');
                        //document.getElementById("cashID").value = data.Row[0].AccId_Cash;
                        $("#cashID").val(data.Row[0].AccId_Payment);
                        $('#cashID').trigger('change');
                        mValTo = data.Row[0].AccId_Payment;
                        mValFrom = data.Row[0].AccId_Cash;
                        //var tt = $("#cashID option:selected").text();
                        //var tt1 = tt.split("[");
                        srcText = data.Row[0].AccId_CashT;
                        //var ttfor = $("#paymentsID option:selected").text();
                        //var ttfor1 = ttfor.split("[");
                        ForText = data.Row[0].AccId_PaymentT;

                        document.getElementById("txtAmount").value = data.Row[0].Amount;
                        var nar = data.Row[0].Narration.split("[");
                        document.getElementById("txtNarration").value = nar[0];
                        document.getElementById("txtDate").value = data.Row[0].TDate;
                        // alert(data.Row[0]);
                        $('#spandataloading').hide();

                        //$('#loadI').attr('class', 'fa fa-gear');


                    },
                    error: function (error) {
                        //alert("err111");
                        console.log(error);
                    }
                });
            }
        }
        LoadTransaction_List();

        function LoadTransaction_List() {
            var edate = new Date();
            var sdate = new Date(edate.getFullYear(), edate.getMonth() - 2, edate.getDate());


            //accOpening = parseFloat(accop).toFixed(0).replace(/\d(?=(\d{3})+\.)/g, '$&,');
            //document.getElementById("AccOpening").innerHTML = "<strong style='color:darkblue;'> " + accOpening + "</strong>";
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
                data: "{'Type':'" + "R" + "','UserID':'" + userid + "','StartDate':'" + Sdate + "','EndDate':'" + Edate + "'}",
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
                        dt = dt + "   <td class=' mTD textar'>" + data.Row[i].TotalAmount + "</td>";
                        dt = dt + "   <td class='mTD textac'>" + data.Row[i].SharedRead + "</td>";
                        dt = dt + "   <td class='mTD textac'><a href='#'  onclick=loadpageEdit('" + data.Row[i].Lid + ":R" + "')><i class='fa fa-edit'></i></a></td>";
                        dt = dt + " <td class='mTD textac'><a href='#' style='color:red;' onclick=deleteIT('" + data.Row[i].Lid + "')><i class='fa fa-trash'></i></a></td>"


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
            //var ids = c.split(":");
            //sessionStorage.setItem("TransID", ids[0]);
            //sessionStorage.setItem("TransType", ids[1]);
            //if (ids[1] == "P") {
            //    document.location.href = "addExpense.html?id=Edit";
            //}
            //if (ids[1] == "R") {
            //    document.location.href = "addIncome.html?id=Edit";
            //}
            // alert(c);
            var ids = c.split(":");

            sessionStorage.setItem("TransID", ids[0]);
            sessionStorage.setItem("TransType", ids[1]);
            sessionStorage.setItem("InputOption", "Edit");
            edit1[0] = "addexpenses";
            edit1[1] = "Edit";
            if (ids[1].toUpperCase() == "R") {
                LoadTransaction();
            }
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

        }






        //DrawMyCalander("MyCal");
        //alert(edit1[1]);

  
    
       

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
        });
        function CallDtChange(a) {

            var dd1 = new Date(a);
            $('#datetimepicker12').data("DateTimePicker").date(dd1);
        }
        // $('#datetimepicker12').on('dp.change', function (e) { console.log(e.date); });
   
	
	
	
	
	/*<script>
        GetCategory();
        function GetCategory() {
            var userid = sessionStorage.getItem("UserID");
            var type = "source";
            $('#spandataloading').show();
            //  var type = "E";
            //$('#loadI').attr('class', 'fa fa-refresh fa-spin');

            $.ajax({
                type: 'POST',
                url: 'Accounts.asmx/loadCat',
                dataType: 'json',
                data: "{'Type':'ALL','UserID':'" + userid + "'}",
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
                    dt = "<option value='00000000-0000-0000-0000-000000001234'> Select </option>";
                    for (var i = 0; i < data.Row.length; i++) {
                        //  alert(data.Row[i].Category);


                        balance = data.Row[i].Balance;
                        // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;

                        dt = dt + "<option value=" + data.Row[i].CatId + ">" + data.Row[i].category + "(" + data.Row[i].Balance + ")" + "</option > ";



                    }

                    document.getElementById("Category").innerHTML = dt;
                    //document.getElementById("NCategory").innerHTML = dt;


                    //$('#loadI').attr('class', 'fa fa-gear');


                },
                error: function (error) {
                    console.log(error);
                }
            });
        }

        function GetSubCategory(catid, cbo) {
            var userid = sessionStorage.getItem("UserID");
            var type = "source";
            $('#spandataloading').show();
            //  var type = "E";
            //$('#loadI').attr('class', 'fa fa-refresh fa-spin');

            $.ajax({
                type: 'POST',
                url: 'Accounts.asmx/loadCatbyID',
                dataType: 'json',
                data: "{'CatID':'" + catid + "'}",
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
                    dt = "<option value='00000000-0000-0000-0000-000000001234'> Select </option>";
                    for (var i = 0; i < data.Row.length; i++) {
                        //  alert(data.Row[i].Category);


                        balance = data.Row[i].Balance;
                        // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;

                        dt = dt + "<option value=" + data.Row[i].CatId + ">" + data.Row[i].category + "(" + data.Row[i].Balance + ")" + "</option > ";



                    }

                    document.getElementById(cbo).innerHTML = dt;


                    //$('#loadI').attr('class', 'fa fa-gear');


                },
                error: function (error) {
                    console.log(error);
                }
            });
        }

        function getAccountbySubCatID(subcatID, cbo) {
            var userid = window.sessionStorage.getItem("UserID");



            $('#loadI').attr('class', 'fa fa-refresh fa-spin');
            //loading script
            $.ajax({
                type: 'POST',
                url: 'Accounts.asmx/loadAccountsbyID',
                dataType: 'json',
                data: "{'SubCatID':'" + subcatID + "'}",
                contentType: 'application/json; charset=utf-8',

                success: function (response) {

                    var txt = '{"Row": ' + response.d + '}';
                    var data = JSON.parse(txt);

                    //  alert(data.Row[0].District);
                    // yaha loop lage ga na
                    var dt = "";
                    var mvalue;
                    dt = "<option value='00000000-0000-0000-0000-000000001234'> Select </option>";
                    for (var i = 0; i < data.Row.length; i++) {
                        //  alert(data.Row[i].Category);


                        balance = data.Row[i].Balance;
                        // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;

                        dt = dt + "<option value=" + data.Row[i].AccountID + ">" + data.Row[i].AccountTitle + "(" + data.Row[i].Balance + ")" + "</option > ";



                    }

                    document.getElementById(cbo).innerHTML = dt;
                    //  $('#loadI').removeAttr('class');// attr('class', 'fa fa-gear');

                    $('#loadI').attr('class', 'fa fa-gear');


                },
                error: function (error) {
                    console.log(error);
                }
            });
        }

        var FormOption = "";
        function ShowPopup(a) {
            // alert(a);
            $("#ModelTitle").html('Select <span style="color:oranged;">' + a + '</span> Account');
            $("#myAddExpes").modal();
            FormOption = a;

        }
        $('#myAddExpes').on('hidden.bs.modal', function (e) {
            if (Opt == "Cancel") {
                //alert("Reminder");
                //SendInvite("Reminder");
                alert(FormOption + " Cancel");
            }
            else if (Opt == "Submit") {
                //alert("newInvitation");
                //SendInvite("newInvitation");
                var tt;
                if (FormOption == "To") {
                    tt = $("#AccountTitle option:selected").text();
                    document.getElementById("cashID").value = tt;
                    srcText = tt;
                    mValFrom = $("#AccountTitle").val();

                    alert(tt + ForText + mValFrom);
                }
                else {
                    // document.getElementById("cashID").value = document.getElementById("AccountTitle").value;
                    tt = $("#AccountTitle option:selected").text();
                    document.getElementById("paymentsID").value = tt;
                   ForText = tt;
                    mValTo = $("#AccountTitle").val();
                    alert(tt + srcText + mValTo);
                }
                //alert(FormOption + " Submit");
            }

            // this handler is detached after it has run once
        });
    </script>*/

   
        loadCashBankNewUI("All", "paymentsID");
        loadCashBankNewUI("Source", "cashID");
        function loadCashBankNewUI(t, control) {
            //alert("newUI");
            var userid = sessionStorage.getItem("UserID");
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
                    if (data.Row.length > 0) {
                        //alert(data.Row[0].CatName + " - " + data.Row[0].SubCatName);
                        dt = "<option></option><optgroup label='" + data.Row[0].CatName + " - " + data.Row[0].SubCatName + "' > ";
                        Ccat = data.Row[0].CatName + " - " + data.Row[0].SubCatName;
                    }
                    //dt = "<option> Select Source </option>";
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
                    str = str + dt;
                    document.getElementById(control).innerHTML = str;
                    //$.fn.select2.defaults.set("theme", "bootstrap");


                    $("#" + control).select2({
                        placeholder: "Select Account"
                        //allowClear: true
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
   