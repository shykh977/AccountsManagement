//var verifyCallback = function (response) {
//    //alert(response);
//    document.getElementById('btnSignin').disabled = false;
//};

//var onloadCallback = function () {
//    // Renders the HTML element with id 'example1' as a reCAPTCHA widget.
//    // The id of the reCAPTCHA widget is assigned to 'widgetId1'.

//    grecaptcha.render('MyreCaptach', {
//        'sitekey': '6LduoJcUAAAAAOAONSWDjTElgpZ2v-JTgp-hXZvH',
//        'callback': verifyCallback,
//        'theme': 'light'
//    });
//};
var input1 = document.getElementById("UserName");
var input2 = document.getElementById("Password");
input1.addEventListener("keyup", function (event) {
    // Cancel the default action, if needed
    event.preventDefault();
    // Number 13 is the "Enter" key on the keyboard
    if (event.keyCode === 13) {
        // Trigger the button element with a click
        document.getElementById("btnSignin").click();
    }
});
input2.addEventListener("keyup", function (event) {
    // Cancel the default action, if needed
    event.preventDefault();
    // Number 13 is the "Enter" key on the keyboard
    if (event.keyCode === 13) {
        // Trigger the button element with a click
        document.getElementById("btnSignin").click();
    }
});
function login() {


    logincheck(UserName.value, Password.value);
   // loginUser(UserName.value, Password.value);

    //if(logincheck())
    //    window.open("default.html");
    //else
    //    window.open("Users/user.html");
}



function loginUser(UserName, Password) {


    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "SubUsers.asmx/LoginSubUser",
        data: "{'UserName':'" + UserName + "', 'Password':'" + Password + "'}",
        success: function (Record) {           
            var txt = '{"Row": ' + Record.d + '}';
            var data = JSON.parse(txt);
            if (data.Row.Password == null) {
                logincheck(UserName, Password)
            }
            else {              
                sessionStorage.setItem("UserID", data.Row.UserId)
                GetUserInfo()
                loadUserSettings()

                window.sessionStorage.setItem("SubUserId", data.Row.SubUserId);

                window.sessionStorage.setItem("UserName", data.Row.SubUserName);
                window.sessionStorage.setItem("UserTitle", data.Row.SubUserName);
                window.sessionStorage.setItem("email", data.Row.Email);
                window.sessionStorage.setItem("CellNo", data.Row.Contact);
            }
        },
        Error: function (textMsg) {

            $('#Result').text("Error: " + Error);
        }
    });

}

function logincheck(UserName, Password) {

    var Messege = "";
  
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "Users.asmx/LoginValue",
        data: "{'UserName':'" + UserName + "', 'Password':'" + Password + "'}",
        success: function (Record) {


            //alert(Record.d);
            var txt = '{"Row": ' + Record.d + '}';
            var data = JSON.parse(txt);
            //alert("Login1");
            if (data.Row.Password == Password) {

                window.sessionStorage.setItem("UserID", data.Row.UserID);
                window.sessionStorage.setItem("UserName", data.Row.UserName);
                window.sessionStorage.setItem("UserTitle", data.Row.UserTitle);
                window.sessionStorage.setItem("email", data.Row.email);
                window.sessionStorage.setItem("CellNo", data.Row.CellNo);
                window.sessionStorage.setItem("DateofCreation", data.Row.DateofCreation);
                window.sessionStorage.setItem("ActiveStatus", data.Row.ActiveStatus);
                window.sessionStorage.setItem("ChartLevel", data.Row.ChartLevel);
                window.sessionStorage.setItem("WelcomeAlert", data.Row.WelcomeAlert);
                window.sessionStorage.setItem("Bandwidth", data.Row.Bandwidth);

                window.sessionStorage.setItem("SubUserId", "");
                GetLmsExpensesMainHead(data.Row.UserID)
                if (data.Row.ChartLevel == "3") {
                    window.sessionStorage.setItem("DashBoard", "DashboardParent.html");
                    window.sessionStorage.setItem("NetWorth", "NetWorth.html");

                } else if (data.Row.ChartLevel == "2") {
                    window.sessionStorage.setItem("DashBoard", "DashboardLevel2Login.html");
                    window.sessionStorage.setItem("NetWorth", "NetWorthLevel2.html");

                } else if (data.Row.ChartLevel == "1") {
                    window.sessionStorage.setItem("DashBoard", "DashboardLevel3Login.html");
                    window.sessionStorage.setItem("NetWorth", "NetWorthLevel3.html");

                }

                window.sessionStorage.setItem("DateParam", "ALL");



                var dateto = new Date();
                var datefrom = new Date();
                var val1 = 365;
                datefrom.setDate(dateto.getDate() - val1);

                var Sdate = (dateto.getDate() < 10 ? "0" + dateto.getDate() : dateto.getDate()) + "." + (dateto.getMonth() < 10 ? "0" + (dateto.getMonth() + 1) : (dateto.getMonth() + 1)) + "." + dateto.getFullYear(); //document.getElementById("txtDate1").value;
                var sd = Sdate.split(".");
                //alert(Sdate);
                var date2 = sd[2] + "." + sd[1] + "." + sd[0];
                var Edate = (datefrom.getDate() < 10 ? "0" + datefrom.getDate() : datefrom.getDate()) + "." + (datefrom.getMonth() < 10 ? "0" + (datefrom.getMonth() + 1) : (datefrom.getMonth() + 1)) + "." + datefrom.getFullYear(); //document.getElementById("txtDate1").value;
                sd = Edate.split(".");
                var date1 = sd[2] + "." + sd[1] + "." + sd[0];
                window.sessionStorage.setItem("StartDate", date1);
                window.sessionStorage.setItem("EndDate", date2);

                sessionStorage.removeItem("BackPage");
                if (sessionStorage.getItem("PageInput") == null || sessionStorage.getItem("PageInput") == "") {

                    sessionStorage.setItem("CurrentPage", sessionStorage.getItem("DashBoard"));
                }
                else {

                    sessionStorage.setItem("CurrentPage", sessionStorage.getItem("PageInput"));
                }

                //alert(window.sessionStorage.getItem("DateParam"))
                loadUserSettings();



                $('#Result').text("Your Record insert");
            }
            else {
                //alert("Login3");

                window.sessionStorage.setItem("UserID", "0");
                window.sessionStorage.setItem("UserName", "0");
                window.sessionStorage.setItem("email", "0");
                window.sessionStorage.setItem("CellNo", "0");
                window.sessionStorage.setItem("DateofCreation", "0");
                window.sessionStorage.setItem("ActiveStatus", "0");
                $.alert({ title: 'Alert!:', content: 'Invalid Username or Password; Try again', });
                //alert("Invalid Username or Password; Try again");
            }

        },
        Error: function (textMsg) {

            $('#Result').text("Error: " + Error);
        }
    });

 


}
var SettingValues;




function loadUserSettings() {

    var userid = sessionStorage.getItem("UserID");

    /* alert("{'UserID':'" + userid + "'}");*/
    $.ajax({
        type: 'POST',
        url: 'Settings.asmx/LoadUserSettings',
        dataType: 'json',

        contentType: 'application/json; charset=utf-8',
        data: "{'UserID':'" + userid + "'}",
        success: function (response) {

            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);

            for (var i = 0; i < data.Row.length; i++) {

                SettingValues = {

                    ActiveStatus: data.Row[i].ActiveStatus
                    , BaseCountry: data.Row[i].BaseCountry
                    , CallingCode: data.Row[i].CallingCode
                    , CountryName: data.Row[i].CountryName
                    , CurrencyCode: data.Row[i].CurrencyCode
                    , CurrencyFormat: data.Row[i].CurrencyFormat
                    , CurrencySymbol: data.Row[i].CurrencySymbol
                    , CurrenyName: data.Row[i].CurrenyName
                    , DateofCreation: data.Row[i].DateofCreation
                    , SettingID: data.Row[i].SettingID
                    , UserID: data.Row[i].UserID
                    , alpha2Code: data.Row[i].alpha2Code
                    , dateFormat1: data.Row[i].dateFormat1
                    , timeformat: data.Row[i].timeformat
                    , Language: data.Row[i].Language
                    , Help: data.Row[i].Help

                }

            }
            sessionStorage.setItem("SettingValues", JSON.stringify(SettingValues));
            savecookies();
            // alert(txt+ " -- "+JSON.stringify(SettingValues));



        },
        error: function (error) {
            console.log(error);
        }
    });

 




}



function Log(MunshiLog) {
    //alert(MunshiLog.AjaxFunction);
    //alert(MunshiLog.POST);
    //alert(MunshiLog.GET);
    //alert(MunshiLog.InformationJSONString);
    //alert(MunshiLog.Email);

    $.ajax({
        type: 'POST',
        url: 'Accounts.asmx/MunshiLog',
        dataType: 'json',

        data: "{'AjaxFunction':'" + MunshiLog.AjaxFunction + "','POST':'" + MunshiLog.POST + "','GET':'" + MunshiLog.GET + "','InformationJSONString':'" + MunshiLog.InformationJSONString + "','Email':'" + MunshiLog.Email + "'}",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {

        },
        error: function (error) {
            console.log(error);
        }
    });


}





var remember = $.cookie('remember');
//alert(remember);
if (remember == 'true' || remember == true) {
    var username = $.cookie('UserName');
    var password = $.cookie('Password');
    // autofill the fields
    //alert(username + "   " + password);
    $('#UserName').val(username);
    $('#Password').val(password);
    $('#remember').attr('checked', true);//#login-check checkbox id..
}


function savecookies() {
    //if ($('#remember').is(':checked')) {
    //    var username = $('#UserName').val();
    //    var password = $('#Password').val();
    //    //alert(username + "   " + password);
    //    // set cookies to expire in 14 days
    //    $.cookie('UserName', username, { expires: 14 });
    //    $.cookie('Password', password, { expires: 14 });
    //    $.cookie('remember', true, { expires: 14 });
    //}
    //else {
    //    // reset cookies
    //    //alert("save2");
    //    $.cookie('email', null);
    //    $.cookie('password', null);
    //    $.cookie('remember', null);
    //}


    var random = Math.random() * 1000;
    window.location.href = "Projects.html?" + random;

};




function GetUserInfo() {
    var UserID = sessionStorage.getItem("UserID");
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "Users.asmx/getUserInfo",
        data: "{'UserID':'" + UserID + "'}",
        success: function (Record) {
            var txt = '{"Row": ' + Record.d + '}';
            var data = JSON.parse(txt);

            window.sessionStorage.setItem("UserID", data.Row.UserID);
            
            window.sessionStorage.setItem("DateofCreation", data.Row.DateofCreation);
            window.sessionStorage.setItem("ActiveStatus", data.Row.ActiveStatus);
            window.sessionStorage.setItem("ChartLevel", data.Row.ChartLevel);
            window.sessionStorage.setItem("WelcomeAlert", data.Row.WelcomeAlert);
            window.sessionStorage.setItem("Bandwidth", data.Row.Bandwidth);

            if (data.Row.ChartLevel == "3") {
                window.sessionStorage.setItem("DashBoard", "DashboardParent.html");
                window.sessionStorage.setItem("NetWorth", "NetWorth.html");
            } else if (data.Row.ChartLevel == "2") {
                window.sessionStorage.setItem("DashBoard", "DashboardLevel2Login.html");
                window.sessionStorage.setItem("NetWorth", "NetWorthLevel2.html");
            } else if (data.Row.ChartLevel == "1") {
                window.sessionStorage.setItem("DashBoard", "DashboardLevel3Login.html");
                window.sessionStorage.setItem("NetWorth", "NetWorthLevel3.html");
            }
            window.sessionStorage.setItem("DateParam", "ALL");

            var dateto = new Date();
            var datefrom = new Date();
            var val1 = 365;
            datefrom.setDate(dateto.getDate() - val1);
            var Sdate = (dateto.getDate() < 10 ? "0" + dateto.getDate() : dateto.getDate()) + "." + (dateto.getMonth() < 10 ? "0" + (dateto.getMonth() + 1) : (dateto.getMonth() + 1)) + "." + dateto.getFullYear(); //document.getElementById("txtDate1").value;
            var sd = Sdate.split(".");
            //alert(Sdate);
            var date2 = sd[2] + "." + sd[1] + "." + sd[0];
            var Edate = (datefrom.getDate() < 10 ? "0" + datefrom.getDate() : datefrom.getDate()) + "." + (datefrom.getMonth() < 10 ? "0" + (datefrom.getMonth() + 1) : (datefrom.getMonth() + 1)) + "." + datefrom.getFullYear(); //document.getElementById("txtDate1").value;
            sd = Edate.split(".");
            var date1 = sd[2] + "." + sd[1] + "." + sd[0];
            window.sessionStorage.setItem("StartDate", date1);
            window.sessionStorage.setItem("EndDate", date2);
            sessionStorage.removeItem("BackPage");
            if (sessionStorage.getItem("PageInput") == null || sessionStorage.getItem("PageInput") == "") {
                sessionStorage.setItem("CurrentPage", sessionStorage.getItem("DashBoard"));
            }
            else {
                sessionStorage.setItem("CurrentPage", sessionStorage.getItem("PageInput"));
            }    
        },
        Error: function (textMsg) {
            $('#Result').text("Error: " + Error);
        }
    })
}



function GetLmsExpensesMainHead(Userid) {

   
    var UserID = sessionStorage.getItem("UserID");

    $.ajax({
        type: 'POST',
        url: 'LmsAccountHeadsService.asmx/GetLmsExpensesMainHead',
        dataType: 'json',
        data: "{'Userid':'" + Userid + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);

            sessionStorage.setItem("CatMainID",data.Row[0].CatMainID)
            GetLmsIncomeMainHead(Userid)
        },
        error: function (error) {
            console.log(error);
        }
    });
}


function GetLmsIncomeMainHead(Userid) {

    
    var UserID = sessionStorage.getItem("UserID");

    $.ajax({
        type: 'POST',
        url: 'LmsAccountHeadsService.asmx/GetLmsIncomeMainHead',
        dataType: 'json',
        data: "{'Userid':'" + Userid + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);

            sessionStorage.setItem("CatMainIDIncome",data.Row[0].CatMainID)
          
        },
        error: function (error) {
            console.log(error);
        }
    });
}
