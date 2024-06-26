
    var dt1 = new Date();
    dt1.setMonth(dt1.getMonth() + 1, 0);
    document.getElementById("txtDate2").value = dt1.getDate() + "/" + (dt1.getMonth() + 1) + "/" + dt1.getFullYear();
    document.getElementById("txtDate1").value = "01/" + (dt1.getMonth() + 1) + "/" + dt1.getFullYear();

    var EndtDate = dt1.getFullYear() + "/" + (dt1.getMonth() + 1) + "/" + dt1.getDate();
    var StartDate = dt1.getFullYear() + "/" + (dt1.getMonth() + 1) + "/" + "01";

    var myid = window.location.href.split("=");
    //var accTitle = sessionStorage.getItem("AccountTitle");
    // document.getElementById("AccTitle").innerHTML = "<strong style='color:darkblue;'> " + accTitle + "</strong>";
    sessionStorage.setItem("BackPage", "")
    function CallTest1() {
        var pages = ['none'];
        var backpage = sessionStorage.getItem("BackPage");
        if (backpage != 'null') { pages = JSON.parse(backpage); }

        pages.push(sessionStorage.getItem("CurrentPage"));

        sessionStorage.setItem("BackPage", JSON.stringify(pages))
        sessionStorage.setItem("LastPage", sessionStorage.getItem("CurrentPage"));
        sessionStorage.setItem("CurrentPage", a);
    }
    function getAccountOpening() {
        $('#loader').show();

     
        $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/getOpeningAccountsbyID',
            dataType: 'json',
            data: "{'AccountID':'" + accid + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {

               


                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);


                var str = "";
                var dt = "";
                var mvalue;
                var mRow
                //var tpay;
                //var trec;
                var bal;
                var mTotal;
                accop = data.Row[0].Balance;

                // getLedger();


                $('#spandataloading').hide();
                $('#loader').hide();
                //$('#loadI').attr('class', 'fa fa-gear');


            },
            error: function (error) {
                console.log(error);
            }
        });



      
    }
    // getLedger();

    function CalltableFill(a) {
        var so = document.getElementById(a).value.split(":");
        FillTable(ledgerobj.sort(compareValues(so[0], so[1])));
    }
    function compareValues(key, order = 'asc') {
        return function (a, b) {
            if (!a.hasOwnProperty(key) ||
                !b.hasOwnProperty(key)) {
                return 0;
            }

            const varA = (typeof a[key] === 'string') ?
                a[key].toUpperCase() : a[key];
            const varB = (typeof b[key] === 'string') ?
                b[key].toUpperCase() : b[key];

            let comparison = 0;
            if (varA > varB) {
                comparison = 1;
            } else if (varA < varB) {
                comparison = -1;
            }
            return (
                (order == 'desc') ?
                    (comparison * -1) : comparison
            );
        };
    }
    var ledgerobj = [];
    function SearchValue() {

        var sv = document.getElementById("SearchString2").value.toUpperCase();
        //alert(sv);
        if (sv == "" || sv == 'NaN') {
            FillTable(ledgerobj);
        }
        else {
            var newArray = [];
            ledgerobj.forEach(function (k) {
                //alert(k.Narration);
                var data1 = (k.Narration + " - " + k.TotalAmount + " - " + k.TransType + " - " + k.TDate + " - " + k.Status1 + " - " + k.UserName).toUpperCase();
               // var data1 = (" " + k.Dashprpority + " ");

                if (data1.includes(sv) == true) {
                    //alert(JSON.stringify(k) + "----" + data1);
                    newArray.push(k)
                };
            });

            FillTable(newArray);
        }
    }
    function FillTable(mydata) {
        var str = "";
        var dt = "";
        var mvalue;
        var mRow
        //var tpay;
        //var trec;
        var bal;
        var mTotal;
        var STat = new Array();
        STat[1] = "<span style='color:blue'>Pending</span>";
        STat[2] = "<span style='color:darkblue'>Seen</span>";
        STat[3] = "<span style='color:oranged'>Reject</span>";
        STat[4] = "<span style='color:darkgreen'>Approved</span>";
        var data = mydata;
        document.getElementById("AccOpening").innerHTML = "<strong style='color:darkblue;'> " + data.length + "</strong>";

        for (var i = 0; i < data.length; i++) {


            var st = 0;
            if (data[i].SharedRead == "") {
                st = 0;
            }
            else
                st = parseInt(data[i].SharedRead);


            mRow = i + 1;

            dt = dt + " <tr>";
            dt = dt + "   <td style='text-align:center;'>" + mRow + ".</td>";
            dt = dt + "   <td> " + data[i].TDate + "</td>";//<a href='#' onclick='callPage(this);'><i style='color:" + data[i].Color + ";' class='" + data[i].Icon + "' ></i>" + " " + data[i].AccTitle + "</a></td>";
            dt = dt + "   <td class='narration-des'>" + (data[i].Narration.replace("<a ", "<a disabled class='disabled' ")).replace("onclick=loadpage(this)", "") + "(" + data[i].UserName + ")" + "</td>";
            dt = dt + "   <td style='text-align:right;' >" + data[i].TotalAmount + "</td>";
            dt = dt + "   <td class='text-c'>" + data[i].TransType + "</td>";
            if (data[i].Status1 == "Deleted") {
                dt = dt + "  <td  style='text-align:center;'>" + "<span style='color:red'>Deleted</span>" + " </td>";
            }
            else {
                dt = dt + "  <td  style='text-align:center;'>" + STat[st + 1] + " </td>";
            }
            dt = dt + "  <td  id = " + data[i].Lid + ":" + data[i].Vtype + " onclick='loadpageEdit(this)'  style='text-align:center;'> <a href='#'><i class= 'fa fa-search'></i></a> </td>";
            // dt = dt + "  <td   id = " + data[i].Lid + " onclick='deleteIT(this)' style='text-align:center;'> <a href='#'><i class= '" + mDel + "'></i></a> </td>";
            dt = dt + "</tr>";

            mTotal = data[i].Total;
            str = str + dt;

            dt = "";
        }
        dt = ""; bal = 0; tpay = 0; trec = 0;




        var op = parseFloat(accop);
        var bal2 = 0;

        if (op == 0)
            bal2 = mTotal;
        else {
            var bal3 = parseFloat(mTotal.replace(new RegExp(",", 'g'), ""));
            bal2 = op + bal3;
        }

        str = str + "<tr><td class='text-r' colspan='3' style='font-weight:bold;'>Total:</td><td class='text-r' colspan='1' style='font-weight:bold;'>" + mTotal + "</td> <td colspan='4' style='font-weight:bold;text-aligh:right;' class='text-right'></td> </tr>";
        mTotal = 0;
        document.getElementById("ledger").innerHTML = str;

    }
    function getLedger() {
        // accOpening = parseFloat(accop).toFixed(0).replace(/\d(?=(\d{3})+\.)/g, '$&,');
        // document.getElementById("AccOpening").innerHTML = "<strong style='color:darkblue;'> " + accOpening + "</strong>";
        var accTitle = sessionStorage.getItem("AccountTitle");
        var userid = sessionStorage.getItem("UserID");
        var Sdate = document.getElementById("txtDate1").value;
        var Edate = document.getElementById("txtDate2").value;
        
        var SD = Sdate.split("/");
        var ED = Edate.split("/");
        Sdate = SD[2] + "/" + SD[1] + "/" + SD[0];
        Edate = ED[2] + "/" + ED[1] + "/" + ED[0];
        //alert("{'Status':'" + stat + "','UserID':'" + userid + "','StartDate':'" + Sdate + "','EndDate':'" + Edate + "'}");
        var stat = "ALL";
        var STat = new Array();
        STat[0] = "Deleted"
        STat[1] = "Pending";
        STat[2] = "Seen";
        STat[3] = "Reject";
        STat[4] = "Approved";
        $('#loader').show();

     
        $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/GetsharedEntries',
            dataType: 'json',
            data: "{'Status':'" + stat + "','UserID':'" + userid + "','StartDate':'" + Sdate + "','EndDate':'" + Edate + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {

                


                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);


                for (var i = 0; i < data.Row.length; i++) {
                    var datevalue = data.Row[i].TDate.split(".");
                    var SharedReadStatus = data.Row[i].ActiveStatus == 0 || data.Row[i].DetailActiveStatus ==0 ? "Deleted" : STat[parseInt(data.Row[i].SharedRead)];
                    var ddArray = { "DD": datevalue[2], "MM": datevalue[1], "YYYY": datevalue[0], "YY": (datevalue[0]).toString().substring(2, 4) };
                    //console.log(SettingValues.dateformat1);
                    //console.log(SettingValues.dateformat1);
                    var dformat = SettingValues.dateFormat1.split("-");
                    var Tdate = ddArray[dformat[0]] + "-" + ddArray[dformat[1]] + "-" + ddArray[dformat[2]];



                    var nar = data.Row[i].Narration.split("[");
                    var nar2 = nar[1].split("<u>");
                    var nar3 = nar[0] + "[" + nar2[1].replace("</u>", "") + "]";

                    var values = { TDate: Tdate, Narration: nar3, TotalAmount: data.Row[i].TotalAmount, UserName: data.Row[i].UserName, TransType: data.Row[i].TransType, Lid: data.Row[i].Lid, Vtype: data.Row[i].Vtype, Total: data.Row[i].Total, SharedRead: data.Row[i].SharedRead, Balance2: Math.abs(parseFloat(data.Row[i].Balance2)), SortDate: parseFloat(data.Row[i].SortDate), Status1: SharedReadStatus }

                    ledgerobj.push(values);
                }

                FillTable(ledgerobj);

                $('#spandataloading').hide();
                $('#loader').hide();
                //$('#loadI').attr('class', 'fa fa-gear');


            },
            error: function (error) {
                console.log(error);
            }
        });



        
    }
    function loadpage(b) {
        //alert(b.id);
        sessionStorage.setItem("AccountTitle", b.innerText.replace("]", ""));
        sessionStorage.setItem("Accountid", b.id);
        LoadFile("AccountLedger.html");
    }
    function loadpageEdit(c) {
        var ids = c.id.split(":");
        sessionStorage.setItem("TransID", ids[0]);
        sessionStorage.setItem("TransType", ids[1]);

        LoadFile("viewTransaction.html");

        //alert(c.id);
    }
    function deleteIT(dd) {
        var lid = dd.id;



      

        $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/deleteLedgerbyID',
            dataType: 'json',
            data: "{'Lid':'" + lid + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {
                
               // alert("Transaction  Deleted");
                $.alert({ title: 'Alert!:', content: 'Transaction  Deleted', });
                location.reload();
            },
            error: function (error) {
                console.log(error);
            }
        });

      

    }
    getLedger();
	
	
	
	
	
	
	

            $('#LedgerFromDate').prop("disabled", true);
            $('#LedgerToDate').prop("disabled", true);
            function CallFilterCheck(a) {
                if (a.id == "LedgerFilter1" && a.checked) {
                    $('#LedgerFilterList').prop("disabled", false);
                    $('#LedgerFromDate').prop("disabled", true);
                    $('#LedgerToDate').prop("disabled", true);

                } else
                    if (a.id == "LedgerFilter2" && a.checked) {
                        $('#LedgerFilterList').prop("disabled", true);
                        $('#LedgerFromDate').prop("disabled", false);
                        $('#LedgerToDate').prop("disabled", false);

                    }
            }

            var LedgerOptFilter = "";
            var LedgerFormOptionOptFilter = "";
            function LedgerFilterShowPopup(a) {
                //alert(LedgerOptFilter);
                $("#LedgerFilterTitle").html('<span style="color:oranged;">' + a + '</span>');
                $("#LedgerFilter99").modal();
                FormOptionOptFilter = a;

            }

            $('#LedgerFilter99').on('hidden.bs.modal', function (e) {
                // alert(LedgerOptFilter);
                if (LedgerOptFilter == "Cancel") {
                    //alert("Reminder");
                    //SendInvite("Reminder");
                    //alert(LedgerFormOptionOptFilter + " Cancel");
                }
                else if (LedgerOptFilter == "Apply") {

                    if ($('#LedgerFilterList').prop("disabled") == false) {

                        var val1 = parseInt(document.getElementById("LedgerFilterList").value);
                        var dateto = new Date();
                        var datefrom = new Date();
                        datefrom.setDate(dateto.getDate() - val1);

                        var Sdate = (dateto.getDate() < 10 ? "0" + dateto.getDate() : dateto.getDate()) + "/" + (dateto.getMonth() < 10 ? "0" + (dateto.getMonth() + 1) : (dateto.getMonth() + 1)) + "/" + dateto.getFullYear(); //document.getElementById("txtDate1").value;
                        document.getElementById("txtDate2").value = Sdate;
                        var Edate = (datefrom.getDate() < 10 ? "0" + datefrom.getDate() : datefrom.getDate()) + "/" + (datefrom.getMonth() < 10 ? "0" + (datefrom.getMonth() + 1) : (datefrom.getMonth() + 1)) + "/" + datefrom.getFullYear(); //document.getElementById("txtDate1").value;
                        document.getElementById("txtDate1").value = Edate;
                        getLedger();


                    } else {

                        var Sd1 = document.getElementById("LedgerFromDate").value;
                        var Ed1 = document.getElementById("LedgerToDate").value;
                        var SD2 = Sd1.split("-");
                        document.getElementById("txtDate1").value = SD2[2] + "/" + SD2[1] + "/" + SD2[0];

                        var ED2 = Ed1.split("-");
                        document.getElementById("txtDate2").value = ED2[2] + "/" + ED2[1] + "/" + ED2[0];


                        getLedger()
                    }
                    //alert("newInvitation");
                    //SendInvite("newInvitation");

                    var tt;
                    if (LedgerFormOptionOptFilter == "To") {
                        //tt = $("#AccountTitle option:selected").text();
                        //document.getElementById("cashID").value = tt;
                        //srcText = tt;
                        //mValFrom = $("#AccountTitle").val();

                        //alert(tt + ForText);
                    }
                    else {
                        // document.getElementById("cashID").value = document.getElementById("AccountTitle").value;
                        //tt = $("#AccountTitle option:selected").text();
                        //document.getElementById("paymentsID").value = tt;
                        //ForText = tt;
                        //mValTo = $("#AccountTitle").val();
                        //alert(tt + srcText);
                    }
                    //alert(FormOption + " Submit");
                }

                // this handler is detached after it has run once
            });
  
	
	
	
	
	
	
	
	
	
	
	
	
	
	
	
