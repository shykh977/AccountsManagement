
        function CalltableFill(a) {
            var so = document.getElementById(a).value.split(":");
            FillTableLedger2(ledgerobj.sort(compareValues(so[0], so[1])));
        }
        function callPage(td) {
            var val1 = td.id.split(":");
            sessionStorage.setItem("Accountid", val1[0]);
            sessionStorage.setItem("AccountTitle", td.innerHTML);
            sessionStorage.setItem("AccountOpening", val1[1]);
            // sessionStorage.setItem("AccountOpening", val1[1]);
            var myid = td.offsetParent;
            sessionStorage.setItem("BackFile", "Ledger.html");

            LoadFile("AccountLedger.html");
        }
        var ledgerobj = [];
        getLedger();
        function getLedger() {
            var userid = sessionStorage.getItem("UserID");
            $('#loader').show();
            var dt, str;
 
            $.ajax({
                type: 'POST',
                url: 'Accounts.asmx/getLedgerRev',
                dataType: 'json',
                data: "{'UserID':'" + userid + "'}",
                contentType: 'application/json; charset=utf-8',

                success: function (response) {
                    
                    var txt = '{"Row": ' + response.d + '}';
                    var data = JSON.parse(txt);

                    //alert(data.Row.length);
                    for (var i = 0; i < data.Row.length; i++) {
                        //data.Row[0][0]
                        //  alert(data.Row[i].Category);
                        var values = { Icon: data.Row[i].Icon, Color: data.Row[i].Color, AccId: data.Row[i].AccId, AccTitle: data.Row[i].AccTitle, PaymentAmt: data.Row[i].PaymentAmt, ReceiptAmt: data.Row[i].ReceiptAmt, Balance: data.Row[i].Balance, Sharing: data.Row[i].Sharing, Opening: data.Row[i].Opening, UserID: data.Row[i].UserID, Balance2: Math.abs(parseInt(data.Row[i].Balance2, 10)), SortDate: parseFloat(data.Row[i].SortDate), UserName: data.Row[i].UserName }

                        ledgerobj.push(values);
                        //alert(data.Row[i].AccTitle);
                    }

                    FillTableLedger2(ledgerobj.sort(compareValues('entrydate', 'desc')));


                },
                error: function (error) {
                    console.log(error);
                }
            });


            

        }


        //$("document").ready(function () {
        //    $(".tab-slider--body").hide();
        //    $(".tab-slider--body:first").show();
        //});

        $(".tab-slider--nav li").click(function () {
            $(".tab-slider--body").hide();
            var activeTab = $(this).attr("rel");
            $("#" + activeTab).fadeIn();
            // alert(activeTab);
            if ($(this).attr("rel") == "tab2") {
                $('.tab-slider--tabs').addClass('slide');
            } else {
                $('.tab-slider--tabs').removeClass('slide');
            }
            $(".tab-slider--nav li").removeClass("active");
            $(this).addClass("active");
        });
        //alert("ledgertop");
        var lid1 = sessionStorage.getItem("GroupActive");

        if (lid1 == "1") {
            $("document").ready(function () {
                $(".tab-slider--body").hide();
                $(".tab-slider--body:last").show();
            });


        }
        else {
            $("document").ready(function () {
                $(".tab-slider--body").hide();
                $(".tab-slider--body:first").show();
            });
        }



        function FillTableLedger(mydata) {
            var str = "";
            var strO = "";
            var dt = "";
            var dtO = "";
            var mvalue;
            var mRow = 0;
            var mRowO = 0;
            //var tpay;
            //var trec;
            var bal;
            var data = mydata;
            for (var i = 0; i < data.Row.length; i++) {
                //  alert(data.Row[i].Category);
                if (data.Row[i].UserID == userid) {
                    mRow = mRow + 1;
                    dt = dt + " <tr>";
                    dt = dt + "   <td>" + mRow + ".</td>";
                    dt = dt + "   <td id='" + data.Row[i].AccId + "' ><a id='" + data.Row[i].AccId + ":" + data.Row[i].Opening + "' style='color:#757472;'  href='#' onclick='callPage(this);'>  <i style='color:" + data.Row[i].Color + ";' class='" + data.Row[i].Icon + "' ></i>" + " " + data.Row[i].AccTitle + " " + (data.Row[i].Sharing == "0" ? "" : "  <i class='fa fa-users' > </i>") + "</a></td>";
                    dt = dt + "   <td class='myamount'>" + data.Row[i].Opening + "</td>";
                    dt = dt + "   <td class='myamount'>" + data.Row[i].ReceiptAmt + "</td>";

                    dt = dt + "   <td class='myamount'>" + data.Row[i].PaymentAmt + "</td>";


                    dt = dt + "   <td class='myamount'>" + data.Row[i].Balance + "</td>";
                    //dt = dt + "   <td>25,000</td>
                    //dt = dt + "   <td style="color:red;">(25,000)</td>
                    dt = dt + "   <td style='padding-left: 8px; padding - right: 5px; text - align: center;'><a href='#'><i class='fa fa-search'></i></a></td>";

                    dt = dt + "</tr>";

                    str = str + dt;
                    dt = ""; bal = 0; tpay = 0; trec = 0;
                }
                else {
                    mRowO = mRowO + 1;
                    dtO = dtO + " <tr>";
                    dtO = dtO + "   <td>" + mRowO + ".</td>";
                    dtO = dtO + "   <td id='" + data.Row[i].AccId + "' ><a id='" + data.Row[i].AccId + ":" + data.Row[i].Opening + "' style='color:#757472;'  href='#' onclick='callPage(this);'>  <i style='color:" + data.Row[i].Color + ";' class='" + data.Row[i].Icon + "' ></i>" + " " + data.Row[i].AccTitle + " (" + data.Row[i].UserName+ ") " + (data.Row[i].Sharing == "0" ? "" : "  <i class='fa fa-users' > </i>") + "</a></td>";
                    dtO = dtO + "   <td class='myamount'>" + data.Row[i].Opening + "</td>";
                    dtO = dtO + "   <td class='myamount'>" + data.Row[i].ReceiptAmt + "</td>";

                    dtO = dtO + "   <td class='myamount'>" + data.Row[i].PaymentAmt + "</td>";


                    dtO = dtO + "   <td class='myamount'>" + data.Row[i].Balance + "</td>";
                    //dt = dt + "   <td>25,000</td>
                    //dt = dt + "   <td style="color:red;">(25,000)</td>
                    dtO = dtO + "   <td class='text-c'><a href='#'><i class='fa fa-search'></i></a></td>";

                    dtO = dtO + "</tr>";

                    strO = strO + dtO;
                    dtO = ""; balO = 0; tpayO = 0; trecO = 0;
                }



            }

            document.getElementById("dtMyledger").innerHTML = str;
            document.getElementById("dtOthersledger").innerHTML = strO;

            $('#spandataloading').hide();
            $('#loader').hide();
            //$('#loadI').attr('class', 'fa fa-gear');
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

        function FillTableLedger2(mydata) {
            var w = window.innerWidth
                || document.documentElement.clientWidth
                || document.body.clientWidth;
            if (w < 768) {
                document.getElementById("MyDiv").style.display = "block";
                document.getElementById("MyDivO").style.display = "block";
                document.getElementById("MyTable").style.display = "none";
                document.getElementById("MyTableO").style.display = "none";

            }
            else {
                document.getElementById("MyDiv").style.display = "none";
                document.getElementById("MyDivO").style.display = "none";
                document.getElementById("MyTable").style.display = "table";
                document.getElementById("MyTableO").style.display = "table";
            }
            //alert(mydata);
            var str = "";
            var strO = "";
            var dt = "";
            var dt2 = ""
            var str2 = "";
            var dt2O = "";
            var str2O = "";
            var dtO = "";
            var mvalue;
            var mRow = 0;
            var mRowO = 0;
            //var tpay;
            //var trec;
            var bal;
            var data = mydata;
            for (var i = 0; i < data.length; i++) {

                if (data[i].UserID == userid) {
                    mRow = mRow + 1;

                    dt = dt + " <tr>";
                    dt = dt + "   <td>" + mRow + ".</td>";
                    dt = dt + "   <td id='" + data[i].AccId + "' ><a id='" + data[i].AccId + ":" + data[i].Opening + "' style='color:#757472;'  href='#' onclick='callPage(this);'>  <i style='color:" + data[i].Color + ";' class='" + data[i].Icon + "' ></i>" + " " + data[i].AccTitle + " " + (data[i].Sharing == "0" ? "" : "  <i class='fa fa-users' > </i>") + "</a></td>";
                    dt = dt + "   <td class='myamount'>" + data[i].Opening + "</td>";
                    dt = dt + "   <td class='myamount'>" + data[i].ReceiptAmt + "</td>";

                    dt = dt + "   <td class='myamount'>" + data[i].PaymentAmt + "</td>";


                    dt = dt + "   <td class='myamount'>" + data[i].Balance + "</td>";
                    //dt = dt + "   <td>25,000</td>
                    //dt = dt + "   <td style="color:red;">(25,000)</td>
                    dt = dt + "   <td style='padding-left: 8px; padding-right: 5px;     text-align: center;'><a id='" + data[i].AccId + ":" + data[i].Opening + "' onclick='callPage(this);' href='#'><i class='fa fa-search'></i></a></td>";

                    dt = dt + "</tr>";

                    dt2 = dt2 + '  <div class="group-ledger-my-aacount g-box col-lg-12 col-md-12">';
                    //2dt = 2dt + '      <div class="date-d">	<a href="#">Jan 13 2019</a>	</div>';
                    dt2 = dt2 + '          <div class="box-header">';
                    dt2 = dt2 + "              <a id='" + data[i].AccId + ": " + data[i].Opening + "' style='color: #757472; '  href='#' onclick='callPage(this);'> <h3 id='box-title' class='box-title'>" + data[i].AccTitle + '</h3></a>';
                    dt2 = dt2 + '';
                    // 2dt = 2dt + '              <div class="box-tools"> <a href="#" class="green"> Approved</a>              </div>';
                    dt2 = dt2 + '          </div>';
                    dt2 = dt2 + '      <div class="grocery-items">';
                    dt2 = dt2 + '';
                    dt2 = dt2 + '';

                    dt2 = dt2 + '';
                    dt2 = dt2 + '          <div class="box-body table-responsive">';
                    dt2 = dt2 + '              <table class="table table-hover">';
                    dt2 = dt2 + '                  <tbody><tr>';
                    dt2 = dt2 + '                  <td>Opening</td>';
                    dt2 = dt2 + '                          <td>' + data[i].Opening + '	</td>';
                    dt2 = dt2 + '                      <td>Balance</td>';
                    dt2 = dt2 + '                          <td>' + data[i].Balance + '</td>';
                    dt2 = dt2 + '                  </tr>';

                    dt2 = dt2 + '                      <tr>';
                    dt2 = dt2 + '                      <td>Receipt</td>';
                    dt2 = dt2 + '                          <td>' + data[i].ReceiptAmt + ' </td>';
                    dt2 = dt2 + '                      <td>Payment</td>';
                    dt2 = dt2 + '                          <td>' + data[i].PaymentAmt + ' </td>';
                    dt2 = dt2 + '';
                    dt2 = dt2 + '';
                    dt2 = dt2 + '';
                    dt2 = dt2 + '';
                    dt2 = dt2 + '                      </tr>';
                    dt2 = dt2 + '';
                    dt2 = dt2 + '';
                    dt2 = dt2 + '';
                    dt2 = dt2 + '                  </tbody></table>';
                    dt2 = dt2 + '          </div>';
                    dt2 = dt2 + '';
                    dt2 = dt2 + '      </div>';
                    dt2 = dt2 + '      <div style="    clear: both;"></div>';
                    dt2 = dt2 + '  </div>';



                    //alert(dt);
                    str = str + dt;
                    str2 = str2 + dt2;
                    dt2 = "";
                    dt = ""; bal = 0; tpay = 0; trec = 0;
                }
                else {
                    //alert(data[i].AccId);
                    mRowO = mRowO + 1;
                    dtO = dtO + " <tr>";
                    dtO = dtO + "   <td>" + mRowO + ".</td>";
                    dtO = dtO + "   <td id='" + data[i].AccId + "' ><a id='" + data[i].AccId + ":" + data[i].Opening + "' style='color:#757472;'  href='#' onclick='callPage(this);'>  <i style='color:" + data[i].Color + ";' class='" + data[i].Icon + "' ></i>" + " " + data[i].AccTitle + " (" + data[i].UserName + ") " + (data[i].Sharing == "0" ? "" : "  <i class='fa fa-users' > </i>") + "</a></td>";
                    dtO = dtO + "   <td class='myamount'>" + data[i].Opening + "</td>";
                    dtO = dtO + "   <td class='myamount'>" + data[i].ReceiptAmt + "</td>";

                    dtO = dtO + "   <td class='myamount'>" + data[i].PaymentAmt + "</td>";


                    dtO = dtO + "   <td class='myamount'>" + data[i].Balance + "</td>";
                    //dt = dt + "   <td>25,000</td>
                    //dt = dt + "   <td style="color:red;">(25,000)</td>
                    dtO = dtO + "   <td  class='text-c'><a href='#'><i class='fa fa-search'></i></a></td>";

                    dtO = dtO + "</tr>";

                    dt2O = dt2O + '  <div class="group-ledger-my-aacount g-box col-lg-12 col-md-12">';
                    //2Odt = 2Odt + '      <div class="date-d">	<a href="#">Jan 13 2019</a>	</div>';
                    dt2O = dt2O + '          <div class="box-header">';
                    dt2O = dt2O + "              <h3 id='box-title' class='box-title'><a id='" + data[i].AccId + ": " + data[i].Opening + "' style='color: #757472; '  href='#' onclick='callPage(this); '>  <i style='color: " + data[i].Color + "; ' class='" + data[i].Icon + "' ></i>" + " " + data[i].AccTitle + " " + (data[i].Sharing == "0" ? "" : "  <i class='fa fa - users' > </i>") + "</a></h3>";
                    dt2O = dt2O + '';
                    // O2dt = O2dt + '              <div class="box-tools"> <a href="#" class="green"> Approved</a>              </div>';
                    dt2O = dt2O + '          </div>';
                    dt2O = dt2O + '      <div class="grocery-items">';
                    dt2O = dt2O + '';
                    dt2O = dt2O + '';

                    dt2O = dt2O + '';
                    dt2O = dt2O + '          <div class="box-body table-responsive">';
                    dt2O = dt2O + '              <table class="table table-hover">';
                    dt2O = dt2O + '                  <tbody>';
                    dt2O = dt2O + '                  <tr> ';
                    dt2O = dt2O + '                      <td>Opening</td>';
                    dt2O = dt2O + '                      <td>' + data[i].Opening + '</td>';
                    dt2O = dt2O + '                      <td>Balance</td>';
                    dt2O = dt2O + '                      <td>' + data[i].Balance + '</td>';
                    dt2O = dt2O + '                  </tr>';
                    dt2O = dt2O + '                      <tr>';
                    dt2O = dt2O + '                      <td>Receipt</td>';
                    dt2O = dt2O + '                       <td>' + data[i].ReceiptAmt + ' </td>';
                    dt2O = dt2O + '                      <td>Payment</td>';
                    dt2O = dt2O + '                      <td>' + data[i].PaymentAmt + ' </td>';
                    dt2O = dt2O + '';
                    dt2O = dt2O + '';
                    dt2O = dt2O + '';
                    dt2O = dt2O + '';
                    dt2O = dt2O + '                      </tr>';
                    dt2O = dt2O + '';
                    dt2O = dt2O + '';
                    dt2O = dt2O + '';
                    dt2O = dt2O + '                  </tbody></table>';
                    dt2O = dt2O + '          </div>';
                    dt2O = dt2O + '';
                    dt2O = dt2O + '          <div class="box-header" style="margin-top:10px;margin-bottom:-10px;padding:0;">';
                    dt2O = dt2O + "              <h3 id='box-title' class='box-title' style='margin-top:5px;'><span  style='color: #757472;font-size:12px; '> Shared by: " + data[i].UserName + "</span></h3>";
                    dt2O = dt2O + '';
                    // O2dt = O2dt + '              <div class="box-tools"> <a href="#" class="green"> Approved</a>              </div>';
                    dt2O = dt2O + '          </div>';
                    dt2O = dt2O + '      </div>';
                    dt2O = dt2O + '      <div style="    clear: both;"></div>';
                    dt2O = dt2O + '  </div>';

                    strO = strO + dtO;
                    str2O = str2O + dt2O;
                    dt2O = "";
                    dtO = ""; balO = 0; tpayO = 0; trecO = 0;
                }



            }
            // alert(str2O);
            if (str == "") {
                str = "<tr><td colspan=7 > </td></tr>"
            }
            document.getElementById("dtMyledger").innerHTML = str;
            //alert(strO);
            document.getElementById("dtOthersledger").innerHTML = strO;
            document.getElementById("MyDiv").innerHTML = str2;
            document.getElementById("MyDivO").innerHTML = str2O;
            if (w < 768) {

            }

            $('#spandataloading').hide();
            $('#loader').hide();
            //$('#loadI').attr('class', 'fa fa-gear');
        }

