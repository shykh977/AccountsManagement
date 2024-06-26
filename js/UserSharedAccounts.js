

MoveAccountCat();
function MoveAccountCat() {

    var ChartLevel = window.sessionStorage.getItem("ChartLevel", ChartLevel);

    if (ChartLevel == '1') {

        LoadCatLevel1();

    }
    else if (ChartLevel == '2') {

        LoadCat();
      
    }
    else if (ChartLevel == '3') {
        LoadCat();
    }


}
















    
    $("#SharedUserName").html(sessionStorage.getItem("UserNameShared"));
    document.getElementById("Rpic1").src = "/userpic/" + sessionStorage.getItem("UserIDShared") + ".jpg";
    function imgerror(e) {
        e.src = "userpic/userError.png";

    }
    function LoadCat() {

        document.getElementById("SharedUserName").innerHTML = sessionStorage.getItem("UserNameShared");

        document.getElementById("Heading1").innerHTML = sessionStorage.getItem("CatTitle") + " -> " + sessionStorage.getItem("subCatTitle");
        var URL = window.location.href.split("SharedAccountlist");
        var UserIDShared = sessionStorage.getItem("UserIDShared");
        var subCatID = sessionStorage.getItem("subCatID");
        var UserID = sessionStorage.getItem("UserID");
        //document.getElementById("Accordin").innerHTML = "";

        //$('#loadI').attr('class', 'fa fa-refresh fa-spin');
        //loading script
        var type = 'I';


 
        $.ajax({
            type: 'POST',
            url: 'Users.asmx/ShowAllAccountbySubCatID',
            dataType: 'json',
            data: "{'UserID':'" + UserID + "','UserIDShared':'" + UserIDShared + "','SubCatID':'" + subCatID + "'}",
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
                //document.getElementById("num1").innerText = data.Row.length;

                var CurrentCat = "";
                if (data.Row.length > 0) {
                    CurrentCat = data.Row[0].SubCatID;
                    var catCount = 0;
                    var chkCount = 0;
                    for (var i = 0; i < data.Row.length; i++) {
                        //  alert(data.Row[i].Category);
                        if (CurrentCat != data.Row[i].SubCatID) {

                            // document.getElementById("Accordin").innerHTML = document.getElementById("Accordin").innerHTML + dt;
                            //str = str + dt;
                            //document.getElementById("R" + CurrentCat).innerHTML = chkCount + "/" + catCount;
                            catCount = 0;
                            chkCount = 0;
                            CurrentCat = data.Row[i].SubCatID;

                        }
                        else {
                            var chk = "";
                            var chk2 = "";

                            if (sessionStorage.getItem("SharingOption") == "Delete") {
                                if (data.Row[i].Isshared == "1") {
                                    chk = "checked"
                                    if (data.Row[i].Transferable == "1") {
                                        chk2 = " checked ";
                                        //chkCount = chkCount + 1;
                                    }
                                    //var chk = data.Row[i].Isshared == "1" ? "checked Disabled":"";
                                    dt = dt + '<div class="row col-12 p-0 m-0" style="font-size:12px; border-bottom: solid 1px #757472; padding-bottom:5px !important; padding-top:5px !important;" >';
                                    dt = dt + '<div class="col-lg-6 col-xl-6 col-sm-12">' + data.Row[i].Title + '</div>';
                                    dt = dt + '<div class="col-lg-6 col-xl-6 col-sm-12 text-sm-left text-lg-right text-xl-right text-right text-md-left ">';
                                    dt = dt + '   <input type = "checkbox" class="chk1" id = "' + data.Row[i].AccID + '" ' + chk + ' value = "0" > Share ';
                                    dt = dt + '  &nbsp;&nbsp;  <select style="border-radius:5px" class="cbo1" id = "sel' + data.Row[i].AccID + '" class="small "  style="">';
                                    if (data.Row[i].Permission == "Readonly") {
                                        dt = dt + '        <option value="Readonly" selected>Read only</option>';
                                        dt = dt + '        <option value="Read & Write">Read & Write</option>';
                                    }
                                    else {
                                        dt = dt + '        <option value="Readonly" >Read only</option>';
                                        dt = dt + '        <option value="Read & Write" selected >Read & Write</option>';
                                    }
                                    dt = dt + '    </select >';
                                    dt = dt + '  &nbsp;&nbsp; <input type="checkbox" class="chk2" id="T' + data.Row[i].AccID + '" ' + chk2 + ' value="0" > Transfer Enable ';
                                    dt = dt + '</div>';
                                    dt = dt + '</div>';
                                   // alert(dt);
                                    str = str + dt;
                                    dt = "";
                                }
                            }
                            else {
                                if (data.Row[i].Isshared == "1") {


                                    chk = "checked Disabled";
                                    chk2 = " Disabled";
                                    chkCount = chkCount + 1;
                                    if (data.Row[i].Transferable == "1") {
                                        chk2 = chk2 + " checked ";
                                        //chkCount = chkCount + 1;
                                    }


                                }
                                else {
                                    chk = "";
                                }
                                //var chk = data.Row[i].Isshared == "1" ? "checked Disabled":"";
                                dt = dt + '<div class="row col-12 p-0 m-0" style="font-size:12px; border-bottom: solid 1px #757472; padding-bottom:5px !important; padding-top:5px !important;" >';
                                dt = dt + '<div class="col-lg-6 col-xl-6 col-sm-12">' + data.Row[i].Title + '</div>';
                                dt = dt + '<div class="col-lg-6 col-xl-6 col-sm-12 text-sm-left text-lg-right text-xl-right text-right text-md-left ">';
                                dt = dt + '   <input type = "checkbox" class="chk1" id = "' + data.Row[i].AccID + '" ' + chk + ' value = "0" > Share ';
                                dt = dt + '  &nbsp;&nbsp;  <select style="border-radius:5px" class="cbo1" id = "sel' + data.Row[i].AccID + '" class="small "  style="">';
                                if (data.Row[i].Permission == "Readonly") {
                                    dt = dt + '        <option value="Readonly" selected>Read only</option>';
                                    dt = dt + '        <option value="Read & Write">Read & Write</option>';
                                }
                                else {
                                    dt = dt + '        <option value="Readonly" >Read only</option>';
                                    dt = dt + '        <option value="Read & Write" selected >Read & Write</option>';
                                }
                                dt = dt + '    </select >';
                                dt = dt + '  &nbsp;&nbsp; <input type="checkbox" class="chk2" id="T' + data.Row[i].AccID + '" ' + chk2 + ' value="0" > Transfer Enable ';
                                dt = dt + '</div>';
                                dt = dt + '</div>';

                                str = str + dt;
                                dt = "";
                            }
                            CurrentCat = data.Row[i].SubCatID;
                            catCount = catCount + 1;
                        }
                        //dt = dt + '<section id="' + data.Row[i].CatID + '" class="mt-2">';
                        //dt = dt + '<a class="btn btn-block bg-info text-white p-0" href="#' + data.Row[i].CatID + '" ><h6>' + data.Row[i].Cat + '</h6></a><p>';
                    }

                    //str = str + dt;
                }
                //str = str + "<tr><td colspan='3' style='font-weight:bold;text-align:center'>Total:</td><td colspan='5' style=font-weight:bold;text-aligh:left;'>" + mTotal + "</td> </tr>";
                document.getElementById("divDataShared").innerHTML = str;
                mTotal = 0;
                // document.getElementById("ledger").innerHTML = str;

                $('#spandataloading').hide();
                $('#loader').hide();
                //$('#loadI').attr('class', 'fa fa-gear');


            },
            error: function (error) {
                console.log(error);
            }
        });

 

    }

function LoadCatLevel1() {

    document.getElementById("SharedUserName").innerHTML = sessionStorage.getItem("UserNameShared");

    document.getElementById("Heading1").innerHTML = "Accounts";
     
    var UserIDShared = sessionStorage.getItem("UserIDShared");
 
    var UserID = sessionStorage.getItem("UserID");
 

 
        $.ajax({
            type: 'POST',
            url: 'Users.asmx/ShowAccountsByUserID_Sharing_OrderByAccountTitle',
            dataType: 'json',
            data: "{'UserID':'" + UserID + "','UserIDShared':'" + UserIDShared + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {
              

                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);


                var str = "";
                var dt = "";
               

                var CurrentCat = "";
                if (data.Row.length > 0) {
                    CurrentCat = data.Row[0].SubCatID;
                    var catCount = 0;
                    var chkCount = 0;
                    for (var i = 0; i < data.Row.length; i++) {
                        
                        
                            var chk = "";
                            var chk2 = "";

                            if (sessionStorage.getItem("SharingOption") == "Delete") {
                                if (data.Row[i].Isshared == "1") {
                                    chk = "checked"
                                    if (data.Row[i].Transferable == "1") {
                                        chk2 = " checked ";
                                        //chkCount = chkCount + 1;
                                    }
                                    //var chk = data.Row[i].Isshared == "1" ? "checked Disabled":"";
                                    dt = dt + '<div class="row col-12 p-0 m-0" style="font-size:12px; border-bottom: solid 1px #757472; padding-bottom:5px !important; padding-top:5px !important;" >';
                                    dt = dt + '<div class="col-lg-6 col-xl-6 col-sm-12">' + data.Row[i].Title + '</div>';
                                    dt = dt + '<div class="col-lg-6 col-xl-6 col-sm-12 text-sm-left text-lg-right text-xl-right text-right text-md-left ">';
                                    dt = dt + '   <input type = "checkbox" class="chk1" id = "' + data.Row[i].AccID + '" ' + chk + ' value = "0" > Share ';
                                    dt = dt + '  &nbsp;&nbsp;  <select style="border-radius:5px" class="cbo1" id = "sel' + data.Row[i].AccID + '" class="small "  style="">';
                                    if (data.Row[i].Permission == "Readonly") {
                                        dt = dt + '        <option value="Readonly" selected>Read only</option>';
                                        dt = dt + '        <option value="Read & Write">Read & Write</option>';
                                    }
                                    else {
                                        dt = dt + '        <option value="Readonly" >Read only</option>';
                                        dt = dt + '        <option value="Read & Write" selected >Read & Write</option>';
                                    }
                                    dt = dt + '    </select >';
                                    dt = dt + '  &nbsp;&nbsp; <input type="checkbox" class="chk2" id="T' + data.Row[i].AccID + '" ' + chk2 + ' value="0" > Transfer Enable ';
                                    dt = dt + '</div>';
                                    dt = dt + '</div>';
                                    // alert(dt);
                                    str = str + dt;
                                    dt = "";
                                }
                            }
                            else {
                                if (data.Row[i].Isshared == "1") {


                                    chk = "checked Disabled";
                                    chk2 = " Disabled";
                                    chkCount = chkCount + 1;
                                    if (data.Row[i].Transferable == "1") {
                                        chk2 = chk2 + " checked ";
                                        //chkCount = chkCount + 1;
                                    }


                                }
                                else {
                                    chk = "";
                                }
                                //var chk = data.Row[i].Isshared == "1" ? "checked Disabled":"";
                                dt = dt + '<div class="row col-12 p-0 m-0" style="font-size:12px; border-bottom: solid 1px #757472; padding-bottom:5px !important; padding-top:5px !important;" >';
                                dt = dt + '<div class="col-lg-6 col-xl-6 col-sm-12">' + data.Row[i].Title + '</div>';
                                dt = dt + '<div class="col-lg-6 col-xl-6 col-sm-12 text-sm-left text-lg-right text-xl-right text-right text-md-left ">';
                                dt = dt + '   <input type = "checkbox" class="chk1" id = "' + data.Row[i].AccID + '" ' + chk + ' value = "0" > Share ';
                                dt = dt + '  &nbsp;&nbsp;  <select style="border-radius:5px" class="cbo1" id = "sel' + data.Row[i].AccID + '" class="small "  style="">';
                                if (data.Row[i].Permission == "Readonly") {
                                    dt = dt + '        <option value="Readonly" selected>Read only</option>';
                                    dt = dt + '        <option value="Read & Write">Read & Write</option>';
                                }
                                else {
                                    dt = dt + '        <option value="Readonly" >Read only</option>';
                                    dt = dt + '        <option value="Read & Write" selected >Read & Write</option>';
                                }
                                dt = dt + '    </select >';
                                dt = dt + '  &nbsp;&nbsp; <input type="checkbox" class="chk2" id="T' + data.Row[i].AccID + '" ' + chk2 + ' value="0" > Transfer Enable ';
                                dt = dt + '</div>';
                                dt = dt + '</div>';

                                str = str + dt;
                                dt = "";
                            }
                       
                        //dt = dt + '<section id="' + data.Row[i].CatID + '" class="mt-2">';
                        //dt = dt + '<a class="btn btn-block bg-info text-white p-0" href="#' + data.Row[i].CatID + '" ><h6>' + data.Row[i].Cat + '</h6></a><p>';
                    }

                    //str = str + dt;
                }
                //str = str + "<tr><td colspan='3' style='font-weight:bold;text-align:center'>Total:</td><td colspan='5' style=font-weight:bold;text-aligh:left;'>" + mTotal + "</td> </tr>";
                document.getElementById("divDataShared").innerHTML = str;
                mTotal = 0;
                // document.getElementById("ledger").innerHTML = str;

                $('#spandataloading').hide();
                $('#loader').hide();
                //$('#loadI').attr('class', 'fa fa-gear');


            },
            error: function (error) {
                console.log(error);
            }
        });
 

}


    go();
    window.addEventListener('resize', go);

    function go() {
        // alert("abc");
        var cardContainerW = $("#clientAreaSharing").width();
        var cardContainerH = $("#clientAreaSharing").height();
        var w = window.innerWidth
            || document.documentElement.clientWidth
            || document.body.clientWidth;
        var h = window.innerHeight
            || document.documentElement.clientHeight
            || document.body.clientHeight;
        var hr = h - 138;

        if (cardContainerW > 1160) {
            $(".CardStyleSharing").css({ "min-width": "350px", "width": "33%", "margin-bottom": "10px" });
        }
        else if (cardContainerW > 710) {
            $(".CardStyleSharing").css({ "min-width": "350px", "width": "49%", "margin-bottom": "10px" });
        }
        else {
            $(".CardStyleSharing").css({ "min-width": "350px", "width": "100%", "margin-bottom": "10px" });
        }
        $("#clientAreaSharing").height(hr);
    }
    function callSave() {
        if (sessionStorage.getItem("SharingOption") == "Delete") {
            Delete();
        }
        else {
            Save();
        }

    }
    function Save() {
        //var check2 = document.getElementsByClassName("chk1");
        var URL = window.location.href.split("SharedAccountlist");
        var check2 = document.querySelectorAll('input[class=chk1]');
        var cbo2 = document.getElementsByClassName('cbo1');
        var check3 = document.querySelectorAll('input[class=chk2]');
        var ids = "";
        for (i = 0; i < check2.length; i++) {
            // ids = ids+ check2[i].checked == true ?"'"+ check2[i].id+ "',":"";
            if (check2[i].disabled == false)
                if (check2[i].checked == true) {
                    var dd = check3[i].checked == true ? "1" : "0";
                    ids = ids + check2[i].id + ":" + cbo2[i].value + ":" + dd + ",";
                }
        }
        
        var UserIDShared = sessionStorage.getItem("UserIDShared");
        var UserTitle = sessionStorage.getItem("UserTitle");
        var UserID = sessionStorage.getItem("UserID");


       

        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: "Users.asmx/SendEmailShareAccountMulti",
            data: "{'UserID':'" + UserID + "','UserIDShared':'" + UserIDShared + "','ids':'" + ids + "','URL':'" + URL[0] + "','SenderName':'" + UserTitle +"'}",
            success: function (response) {

 


                $.alert({ title: 'Alert!', content: 'Account sharing message sent successfully to ' + response.d + '', columnClass: 'col-md-6 col-sm-10' });
                //alert(response.d);
                PageBackward();
                ShowAccountList();
                //  alert(response.d);

            },
            error: function (error) {
                alert(error);
                console.log(error);
            }
        });


      

    }
    function Delete() {
        //var check2 = document.getElementsByClassName("chk1");
        var URL = window.location.href.split("SharedAccountlist");
        var check2 = document.querySelectorAll('input[class=chk1]');
        //alert(check2);
        var ids = "";
        for (i = 0; i < check2.length; i++) {
            // ids = ids+ check2[i].checked == true ?"'"+ check2[i].id+ "',":"";
            if (check2[i].checked == false)
                ids = ids + check2[i].id + ",";
        }
        //alert(ids);
        var UserIDShared = sessionStorage.getItem("UserIDShared");
        var UserID = sessionStorage.getItem("UserID");

     
        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: "Users.asmx/SendEmailShareAccountMulti_Remove",
            data: "{'UserID':'" + UserID + "','UserIDShared':'" + UserIDShared + "','ids':'" + ids + "','URL':'" + URL[0] + "','SenderName':'" + UserTitle +"'}",
            success: function (response) {
               
                $.alert({ title: 'Alert!', content: 'Account sharing deleted  ', });
                // alert(response.d);
                PageBackward();
                ShowAccountList();
                //  alert(response.d);

            },
            error: function (error) {
                alert(error);
                console.log(error);
            }
        });

        


    }
    function cancel() {
        document.location.href = "usersharing.html";
    }
