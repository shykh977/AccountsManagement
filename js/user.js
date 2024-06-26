//$(function () {
//    $('#txtDOB').datetimepicker({ format: 'DD/MM/YYYY' , ignoreReadonly: true,
//        allowInputToggle: true
//    });
//});

$('#fileupload').hide();
$(".uploadme").click(function () {
    $('#imgfile').click();
});
//$('#cal2').click(function () {
//    $(document).ready(function () {
//        $("#txtDOB").datetimepicker().focus();
//    });
//});


//---------------------------- date picker end ----------------------------

function validateEmail(email) {
    var re = /^(([^<>()\[\]\\.,;:\s@"]+(\.[^<>()\[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
}

//---------------------- Email Validation
$('#spandataloading').hide();
$('#loader').hide();

var StatusValue = "";
var file2 = "";
var emailchk = 0;
function callemailout() {

    var a = document.getElementById("UserNameChoise");
    var aa = document.getElementById("txtemail");
    var chk = document.getElementById("chkEmail");
    //chkEmail
    if (validateEmail(aa.value)) {
        chk.innerHTML = '<i  class="fa fa-check"></i>';
        chk.style.color = "white";
        emailchk = 1;
        //ChangeChoise(a);
       
    }
    else {
        chk.innerHTML = '<i class="fa fa-times"></i>';
        chk.style.color = "white";
        emailchk = 0;
        //aa.focus();
    }
    //alert("1");
    $('#CountryData').select2('open');
   // $('#CountryData').select2({}).focus(function () { $(this).select2('focus'); });

}
function callcellout() {
    var a = document.getElementById("UserNameChoise");
    //ChangeChoise(a);
}
//function ChangeChoise(a) {
//    if (a.value == "0") {
//        document.getElementById("txtUser").disabled = false;

//    }
//    if (a.value == "email") {
//        txtUser.value = txtemail.value;
//        document.getElementById("txtUser").disabled = true;
//    }
//    if (a.value == "cell") {
//        txtUser.value = txtCell.value;
//        document.getElementById("txtUser").disabled = true;
//    }


//}
function MyFile() {
    var elm = document.getElementById("imgfile").files[0];
    getBase64(elm);
}


function getBase64(file) {
    var reader = new FileReader();
    reader.readAsDataURL(file);
    reader.onload = function () {
        file2 = reader.result;
        document.getElementById("Rpic").src = file2;
        return "";
    };
    reader.onerror = function (error) {
        return "";
    };
}

function CallSaveUser() {
    if ((emailchk == 0 && txtCell.value == "") || (txtCell.value.length < 10 && emailchk == 0) || (emailchk == 0 && txtemail.value.length > 0)) {
        $.alert({ title: 'Alert!:', content: 'Please enter valid email or cell number with atleast 10 digits', });
    }
    else
        if (txtpassword2.value != txtpassword.value || txtpassword2.value == "" || txtpassword.length > 5) {
            $.alert({
                title: 'Information:', content: 'Please enter password comprising at least 6 (six) characters.',
            })
        }
        else
            if (txtpassword.checkValidity() && (txtemail.checkValidity() || txtCell.checkValidity()) && txtFullName.checkValidity()) {
                var d = document;
                //var varFullName = txtFullName.value;

                var vartxtUse = txtemail.value// txtUser.value;
                var vartxtpassword = txtpassword.value;
                var vartxtemail = txtemail.value;
                var vartxtCell = txtCell.value;
                var varLevel = sessionStorage.getItem('Level');//document.getElementById("txtLevel").value;
                // var vartxtDOB = txtDOB.value;
                var varFullName = txtFullName.value;
                var CountryID = document.getElementById("CountryData").value;
                if (StatusValue == 2)
                    vartxtActive = "2";
                else
                    var vartxtActive = txtActive.value;

                var formData = new FormData();
                var totalFiles = document.getElementById("imgfile").files.length;
                //alert("99");
                // alert(totalFiles);

                var file1 = file2;
                formData.append("imgfile", file1);

                // alert(formData.get("imgfile"));

                formData.append("FullName", varFullName);
                formData.append("UserName", vartxtUse);
                formData.append("Password", vartxtpassword);
                formData.append("email", vartxtemail);
                formData.append("Cell", vartxtCell);
                //formData.append("DOB", vartxtDOB);
                formData.append("Active", vartxtActive);
                formData.append("CountryID", CountryID);
                //'fullname':'"+ vartxtUse +"', 'username':'"+ vartxtUse +"', 'password':'" + vartxtpassword +"', 'cell':'"+ vartxtCell +"', 'email':'"+ vartxtemail +"', 'dob':'"+ vartxtDOB +"', 'active':'"+ vartxtActive +"', 'img':'"+ file1 +"'
                //if ($("#form1").checkValidity()) {
                //alert(formData);
                //var id = SaveUsers(vartxtUse, vartxtpassword, vartxtCell, vartxtemail, vartxtDOB, vartxtActive);
                //}
                //$.ajax({
                //    type: 'post',
                //    url: 'Users.asmx/SaveUsers2',
                //    data: formData,
                //    dataType: 'json',
                //    contentType: false,
                //    processData: false,
                //    success: function (response) {
                //        //alert("a1");
                //        alert("User Registered");
                //    },
                //    error: function (error) {


                //        document.getElementById("txtUser").value = "";
                //        document.getElementById("txtpassword").value = "";
                //        document.getElementById("txtemail").value = "";
                //        document.getElementById("txtCell").value = "";
                //        document.getElementById("txtDOB").value = "";
                //    }
                //});

 

                $.ajax({
                    type: "POST",
                    dataType: "json",
                    contentType: "application/json; charset=utf-8",
                    url: "Users.asmx/SaveUsers2",
                    data: "{'fullname':'" + varFullName + "', 'username':'" + vartxtUse + "', 'password':'" + vartxtpassword + "', 'cell':'" + vartxtCell + "', 'email':'" + vartxtemail + "', 'dob':'2019-02-28', 'active':'" + vartxtActive + "', 'img':'" + file1 + "','CountryID':'" + CountryID + "','Level':'" + varLevel + "'}",
                    success: function (response) {
                        


                        if (response.d.length == 36) {
                            SendEmailNewUser(varFullName, vartxtCell, vartxtemail);
                            //$.alert({
                            //    title: 'Information:', content: 'You are Registred', confirm: function () {
                            //        window.location.href = "/"; // shorthand.
                            //    }
                                
                            //});
                             
                            //window.location.href = "#box-1";

                            $('#conform').modal();
                        }
                        else {
                            $.alert({ title: 'Information:', content: response.d, });
                        }
                        //  alert(response.d);

                    },
                    error: function (error) {
                        $.alert({ title: 'Alert!', content: 'Issues while registration', });
                        //alert("error");
                        console.log(error);
                    }
                });

               



            }
            else {
                // document.getElementById("txtUser").style.borderColor = txtUser.checkValidity ? document.getElementById("txtUser").style.borderColor : "red";
                document.getElementById("txtpassword").style.borderColor = txtpassword.checkValidity ? document.getElementById("txtpassword").style.borderColor : "white";
                document.getElementById("txtemail").style.borderColor = txtemail.checkValidity ? document.getElementById("txtemail").style.borderColor : "white";
                document.getElementById("txtCell").style.borderColor = txtCell.checkValidity ? document.getElementById("txtCell").style.borderColor = txtCell.checkValidity : "white";
                // document.getElementById("txtDOB").style.borderColor = txtDOB.checkValidity ? document.getElementById("txtDOB").style.borderColor = txtDOB.checkValidity : "red";
                //alert("a2");
            }
}
////for server sider only
////Request.Form["guid"];
////Request.Files["FileUpload"];

function upload() {
    var formData = new FormData();

    var totalFiles = document.getElementById("FileUpload").files.length;

    for (var i = 0; i < totalFiles; i++) {
        var file = document.getElementById("FileUpload").files[i];

        formData.append("FileUpload", file);
        formData.append("guid", theGuid);
    }

   


    $.ajax({
        type: 'post',
        url: '/myController/Upload',
        data: formData,
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (response) {

         

            // alert('succes!!');
        },
        error: function (error) {
            // alert("errror");
        }
    });


   

}



////////////////////////////function CheckSharedAccount(SharedID) {

////////////////////////////    //var AccountID = accid;
////////////////////////////    //if (AccountID.length == 36) {
////////////////////////////    //    $('#spandataloading').show();


////////////////////////////    $.getJSON('https://api.ipify.org/?format=json', function (data) {

////////////////////////////        var Information = (JSON.stringify(data, null, 2));
////////////////////////////        var PostData = "{'ShareID':'" + SharedID + "' }";



////////////////////////////    $.ajax({
////////////////////////////        type: "POST",
////////////////////////////        dataType: "json",
////////////////////////////        contentType: "application/json; charset=utf-8",
////////////////////////////        url: "Users.asmx/GetSharedAccountDetail",
////////////////////////////        data: "{'ShareID':'" + SharedID + "' }",
////////////////////////////        success: function (Record) {

////////////////////////////            if (response.d.length === undefined) { var GetData = 0; }
////////////////////////////            else { var GetData = response.d.length; }

////////////////////////////            var MunshiLog = {
////////////////////////////                AjaxFunction: "Users.asmx/GetSharedAccountDetail",
////////////////////////////                POST: PostData.length,
////////////////////////////                GET: GetData,
////////////////////////////                InformationJSONString: Information,
////////////////////////////                Email: sessionStorage.getItem("email")
////////////////////////////            };

////////////////////////////            Log(MunshiLog);


////////////////////////////            var txt = '{"Row": ' + Record.d + '}';
////////////////////////////            var data = JSON.parse(txt);
////////////////////////////            //alert(Record.d);
////////////////////////////            if (data.Row[0].AccountID == "Not Found") {
////////////////////////////                //document.getElementById("secondChoice").style.display = "block";
////////////////////////////                //// document.getElementById("firstChoice").style.display = "none";
////////////////////////////                //document.getElementById('Already').style.display = 'none';
////////////////////////////                //document.getElementById('InvDiv').style.display = 'block';
////////////////////////////                //$("#myShared").modal();
////////////////////////////                window.location.href = "login.html";
////////////////////////////            }
////////////////////////////            else if (data.Row[0].AccountID == "Updated") {
////////////////////////////                //alert("Accounts Updated");
////////////////////////////                $.alert({ title: 'Alert!:', content: 'Accounts Updated', });
////////////////////////////                $('#spandataloading').hide();
////////////////////////////                $('#loader').hide();
////////////////////////////            }
////////////////////////////            else {
////////////////////////////                //$('#spandataloading').hide();
////////////////////////////                //document.getElementById('InvDiv').style.display = 'block';
////////////////////////////                //document.getElementById('Already').style.display = 'block';
////////////////////////////                //DataAvail = data;
////////////////////////////                //ShowDialog(data);
////////////////////////////                if (data.Row[0].Status == "No Response") {
////////////////////////////                    var str = '<input id="txtAccept" class="form-control bg-success" type="text" inputmode="numeric" readonly value="Accepted by you" />'
////////////////////////////                    document.getElementById('txtActive').outerHTML = str;
////////////////////////////                    document.getElementById('txtUser').value = data.Row[0].UserName;
////////////////////////////                    document.getElementById('txtemail').value = data.Row[0].Email;
////////////////////////////                    document.getElementById('txtCell').value = data.Row[0].CellNo;
////////////////////////////                    document.getElementById('txtpassword').value = "";

////////////////////////////                    //document.getElementById('txtActive').value = data.Row[0].UserName;
////////////////////////////                    StatusValue = 2;
////////////////////////////                    $('#spandataloading').hide();
////////////////////////////                    $('#loader').hide();

////////////////////////////                }
////////////////////////////                else if (data.Row[0].Status == "Active") {
////////////////////////////                    //alert("You are already registred; Please Login");

////////////////////////////                    $.alert({ title: 'Alert!:', content: 'You are already registred; Please Login', });
////////////////////////////                    window.location.href = "login.html";
////////////////////////////                }

////////////////////////////                $('#spandataloading').hide();
////////////////////////////                $('#loader').hide();

////////////////////////////            }

////////////////////////////            //$("#myShared").modal('show');
////////////////////////////            //if (Record.d == "[]") {
////////////////////////////            //    Message = "NotDataFound1";

////////////////////////////            //}
////////////////////////////            //else {
////////////////////////////            //    Message = "DataFound";
////////////////////////////            //    //var txt = '{"Row": ' + Record.d + '}';
////////////////////////////            //    //var data = JSON.parse(txt);
////////////////////////////            //    for (var i = 0; i < data.Row.length; i++) {
////////////////////////////            //        //  alert(data.Row[i].Category);
////////////////////////////            //        //balance = data.Row[i].Balance;
////////////////////////////            //        // var strbalance = " &#xf0a4; "+"[" + balance + "]" ;
////////////////////////////            //        //dt = dt + "<option value=" + data.Row[i].AccID + ">" + data.Row[i].Title + balance + "</option > ";

////////////////////////////            //    }
////////////////////////////            //}
////////////////////////////        },
////////////////////////////        Error: function (textMsg) {

////////////////////////////            Messege = "Error";
////////////////////////////            // $('#Result').text("Error: " + Error);

////////////////////////////        }


////////////////////////////    });



////////////////////////////    });




////////////////////////////}

////////////////////////////var ur1 = window.location.href;
////////////////////////////if (ur1.indexOf("id=X") > 0) {
////////////////////////////    // $('#loader').show();
////////////////////////////    var id1 = ur1.split("id=X");
////////////////////////////    CheckSharedAccount(id1[1]);
////////////////////////////}
////////////////////////////else {
////////////////////////////    $('#spandataloading').hide();
////////////////////////////    $('#loader').hide();
////////////////////////////}

function checkStrength(txtpass, strenghtMsg, errorMsg) {
    var SthChk = new Array();
    SthChk[0] = "Very Weak";
    SthChk[1] = "Weak";
    SthChk[2] = "Better";
    SthChk[3] = "Medium";
    SthChk[4] = "Strong";
    SthChk[5] = "Strongest";
    var STColor = new Array();
    STColor[0] = "#ffffff";
    STColor[1] = "#ffffff";
    STColor[2] = "#ffffff";
    STColor[3] = "#ffffff";
    STColor[4] = "#ffffff";
    STColor[5] = "#ffffff";

    errorMsg.innerHTML = '';
    var score = 0;

    //if txtpass bigger than 6 give 1 point
    if (txtpass.length >= 6) score++;

    //if txtpass has both lower and uppercase characters give 1 point
    if ((txtpass.match(/[a-z]/)) && (txtpass.match(/[A-Z]/))) score++;

    //if txtpass has at least one number give 1 point
    if (txtpass.match(/\d+/)) score++;

    //if txtpass has at least one special caracther give 1 point
    if (txtpass.match(/.[!,@,#,$,%,^,&,*,?,_,~,-,(,)]/)) score++;

    //if txtpass bigger than 12 give another 1 point
    if (txtpass.length > 12) score++;

    strenghtMsg.innerHTML = SthChk[score];
    strenghtMsg.style.color = STColor[score];

    if (txtpass.length < 6) {
        errorMsg.innerHTML = "Invalid";
        errorMsg.style.color = "white";
    }


}

function Passmatch(pass) {
    var pass1 = document.getElementById("txtpassword").value;
    var pass2 = document.getElementById("txtpassword2").value;
    var stc = document.getElementById("STCpassord");
    if (pass1 == pass2) {
        //stc.style
        stc.style.color = "white";
        stc.innerHTML = '<i class="fa fa-check"></i>'

    }
    else {
        stc.style.color = "white";
        stc.innerHTML = '<i class="fa fa-times"></i>';
    }
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

  

    $.ajax({
        type: 'POST',
        url: 'Settings.asmx/LoadCountry',
        dataType: 'json',
        // data: "{'UserID':'" + userid + "','type':'" + type + "'}",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            

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

