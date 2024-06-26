

    function checkStrength() {

    }
    loadCountry("CountryData");
    function loadCountry(control) {
        //alert("newUI");
        var userid = sessionStorage.getItem("UserID");
        //var type = t;
        //$('#spandataloading').show();
        //  var type = "E";
        //$('#loadI').attr('class', 'fa fa-refresh fa-spin');
        //AccountID, AccountTitle.SubCatID, SubCatName, CatID, CatName

        $.getJSON('https://api.ipify.org/?format=json', function (data) {

            var Information = (JSON.stringify(data, null, 2));
            var PostData = "";



        $.ajax({
            type: 'POST',
            url: 'Settings.asmx/LoadCountry',
            dataType: 'json',
            // data: "{'UserID':'" + userid + "','type':'" + type + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {

                if (response.d.length === undefined) { var GetData = 0; }
                else { var GetData = response.d.length; }

                var MunshiLog = {
                    AjaxFunction: "Settings.asmx/LoadCountry",
                    POST: PostData.length,
                    GET: GetData,
                    InformationJSONString: Information,
                    Email: sessionStorage.getItem("email")
                };

                Log(MunshiLog);


                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);
                //$('#spandataloading').hide()
                //  alert(data.Row[0].District);
                // yaha loop lage ga na
                var str = "";
                var dt = "";
                var mvalue;
                var optg = "";
                var Ccat

                for (var i = 0; i < data.Row.length; i++) {


                    // dt = dt + '<li data-value="' + data.Row[i].CountryID + '"><img sizes="12" src="../lib/Flags100/' + data.Row[i].alpha2Code +'.png"><span class="country-code-name">'+data.Row[i].name + ' (' + data.Row[i].callingCodes0 + ')'+' </span></li>';
                    // balance = data.Row[i].Balance;
                    // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;
                    dt = dt + "<option data-image='../lib/Flags100/" + data.Row[i].alpha2Code + ".png' value=" + data.Row[i].CountryID + ">" + data.Row[i].name + " (" + data.Row[i].callingCodes0 + ")" + "</option > ";



                }

                str = str + dt;
                document.getElementById(control).innerHTML = str;


                $("#" + control).select2({
                    placeholder: "Select Country",
                    templateResult: formatState,
                    templateSelection: formatState
                });

                function formatState(opt) {
                    if (!opt.id) {
                        return opt.text.toUpperCase();
                    }

                    var optimage = $(opt.element).attr('data-image');
                    console.log(optimage)
                    if (!optimage) {
                        return opt.text.toUpperCase();
                    } else {
                        var $opt = $(
                            '<span><img src="' + optimage + '" width="18px" /> <c> ' + opt.text.toUpperCase() + '</c></span>'
                        );
                        return $opt;
                    }
                };
                //$("#" + control).select2({
                //    placeholder: "Select Country",
                //    allowClear: true
                //});


            },
            error: function (error) {
                console.log(error);
            }
        });




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
    function SendInvite(Param1) {

        // document.getElementById("form1").style.display = "none";
        // document.getElementById("result").style.display = "block";
        var d = document;
        var vartxtUse = d.getElementById("txtUser").value;
        var vartxtemail = d.getElementById("txtemail").value;
        var vartxtCell = d.getElementById("txtCell").value;
        var CountryID = document.getElementById("CountryData").value;
        //var varPermission = d.getElementById("selPermissionInvt").value;


        var retv = checkforExisitingUser(vartxtUse, vartxtCell, vartxtemail, "Readonly", Param1);

        //}


    }


    function checkforExisitingUser(usr, cell, email, permission, Param1) {
        // UserName, string CellNo, string Email
        var usrID = sessionStorage.getItem("UserID");


        $.getJSON('https://api.ipify.org/?format=json', function (data) {

            var Information = (JSON.stringify(data, null, 2));
            var PostData = "{'SenderUserID':'" + usrID + "','CellNo':'" + cell + "','Email':'" + email + "','Permission':'" + permission + "'}";




        $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
            url: "Users.asmx/sp_SearchExisitingSharedUser",
            data: "{'SenderUserID':'" + usrID + "','CellNo':'" + cell + "','Email':'" + email + "','Permission':'" + permission + "'}",
            success: function (Record) {

                if (response.d.length === undefined) { var GetData = 0; }
                else { var GetData = response.d.length; }

                var MunshiLog = {
                    AjaxFunction: "Users.asmx/sp_SearchExisitingSharedUser",
                    POST: PostData.length,
                    GET: GetData,
                    InformationJSONString: Information,
                    Email: sessionStorage.getItem("email")
                };

                Log(MunshiLog);

                //alert(Record.d);
                var txt = '{"Row": ' + Record.d + '}';
                // var data = JSON.parse(txt);

                if (Record.d == "Not Found") {

                    EmailInvite(Param1, Record.d);
                    return "not Found";
                }
                else {
                    EmailInvite(Param1, Record.d);
                    return Record.d;
                }


            },
            Error: function (textMsg) {

                Messege = "Error";
                return "error";

                // $('#Result').text("Error: " + Error);

            }


            });





        });


    }
    function EmailInvite(Param1, msg) {
        var d = document;
        var vartxtUse = d.getElementById("txtUser").value;
        var vartxtemail = d.getElementById("txtemail").value;
        var vartxtCell = d.getElementById("txtCell").value;
        var CountryID = document.getElementById("CountryData").value;
        //var varPermission = d.getElementById("selPermissionInvt").value;
        var retv = msg;
        // alert(Param1);
        if (retv == "error") {
            //alert("Technical issue while sending invitation. Please try again");

            $.alert({ title: 'Alert!:', content: 'Technical issue while sending invitation. Please try again', });
        }
        if (retv == "Not Found") {
            if (Param1 == "Reminder") {
                vartxtUse = DataAvail.UserName;
                vartxtemail = DataAvail.Email;
                vartxtCell = DataAvail.CellNo;
                //varPermission = $("#selPermission :selected").text();
                VarNaration = "Please check this application it is usefull for daily basis financial";

                varStatus = "1";
                VarSendBy = window.sessionStorage.getItem("UserID");
            }
            else {
                vartxtUse = txtUser.value;
                vartxtemail = txtemail.value;
                vartxtCell = txtCell.value;
               CountryID = document.getElementById("CountryData").value;
                //VarNaration = txtNarration.value;
                //varPermission = $("#selPermissionInvt :selected").text();
                varStatus = "1";
                VarSendBy = window.sessionStorage.getItem("UserID");
                //alert("reminder");
            }


            //if ($("#form1").checkValidity()) {
            //alert("going");
            //var UR = window.location.href.split("UserInvitation.html");
            var UR = "www.munshibaba.com/";
            var SenderName = sessionStorage.getItem("UserTitle");
            SendEmailShareAccount(vartxtUse, vartxtCell, vartxtemail, '10000000-1000-0000-0000-000000000000', '--', "Readonly", Param1, UR, SenderName, CountryID);
        }
        else {
            if (msg.includes("Already Invite")) {
                var ar = confirm(msg + " Invite Again");
                if (ar) {
                    vartxtUse = txtUser.value;
                    vartxtemail = txtemail.value;
                    vartxtCell = txtCell.value;
                   CountryID = document.getElementById("CountryData").value;
                    //VarNaration = txtNarration.value;
                    varPermission = $("#selPermissionInvt :selected").text();
                    varStatus = "1";
                    VarSendBy = window.sessionStorage.getItem("UserID");
                    var UR2 = "www.munshibaba.com/";
                    var SenderName2 = sessionStorage.getItem("UserTitle");
                    SendEmailShareAccount(vartxtUse, vartxtCell, vartxtemail, '10000000-1000-0000-0000-000000000000', '--', varPermission, "Reminder", UR2, SenderName2, CountryID);

                }
            }
            else {
                //alert("This email is already registered as user. Please search in settings ---> Share Account");
                $.alert({ title: 'Alert!:', content: 'This email is already registered as user. Please search in settings ---> Share Account', });
            }
        }
    }


