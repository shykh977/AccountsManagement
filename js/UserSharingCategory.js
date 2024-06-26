


MoveAccountCat();
function MoveAccountCat() {

    var ChartLevel = window.sessionStorage.getItem("ChartLevel", ChartLevel);

    
    if (ChartLevel == '2') {
        
        document.getElementById("ShareCatLevel").style.display = "none";
        document.getElementById("ShareCatLevel2").style.display = "block";
        document.getElementById("HeadingForLevel3").style.display = "none";
        document.getElementById("HeadingForLevel2").style.display = "block";
        if (sessionStorage.getItem("SharingOption") == "Delete") {

            LoadSubLevel2Delete();
        }
        else {
            LoadSubLevel2();
        }
    }
    else if (ChartLevel == '3') {
        document.getElementById("ShareCatLevel").style.display = "block";
        document.getElementById("ShareCatLevel2").style.display = "block";
        document.getElementById("HeadingForLevel3").style.display = "block";
        document.getElementById("HeadingForLevel2").style.display = "none";
        //document.getElementById("SCName").innerHTML = "Sub-Category";
        LoadCat();
    }


}













var Cat_Procedure = "";
var proc_Prameters = "";
var CatSub_Procedure = "";
var CatSub_Prameters = "";
var userid = window.sessionStorage.getItem("UserID");
var shareduserid = sessionStorage.getItem("UserIDShared");
if (sessionStorage.getItem("SharingOption") == "Delete") {
    //$("#clientAreaSharing")
    document.getElementById("textTitle").innerHTML = "DISABLE SHARING OF ACCOUNT WITH ";
    Cat_Procedure = "LoadCatforSharing";
    proc_Prameters = "{'owneruserid':'" + userid + "','Shareduserid':'" + shareduserid + "'}";
    CatSub_Procedure = "LoadSubCatforSharing";
    CatSub_Prameters = "{'owneruserid':'" + userid + "','Shareduserid':'" + shareduserid + "',";
    //var elem = $("#clientAreaSharing");
    //elem[0].style.removeProperty('background-color');
    //elem[0].style.setProperty('background-color', '#FF4500', 'important');
    //var elem3 = $("#maincontents");
    //elem3[0].style.removeProperty('background-color');
    //elem3[0].style.setProperty('background-color', '#FF4500', 'important');
    //var elem4 = $("#divData");
    //elem4[0].style.removeProperty('background-color');
    //elem4[0].style.setProperty('background-color', '#FF4500', 'important');
    //var elem5 = $("#FirendsList");
    //elem5[0].style.removeProperty('background-color');
    //elem5[0].style.setProperty('background-color', '#FF4500', 'important');
}
else {
    Cat_Procedure = "LoadCat";
    var type = 'I';

    proc_Prameters = "{'Type':'" + type + "','UserID':'" + userid + "'}";
    CatSub_Procedure = "loadCatbyID";
    CatSub_Prameters = "{";

    // $("#clientAreaSharing").css({ "backgroung-color": "#E5E4E7" });
    document.getElementById("textTitle").innerHTML = "CHOOSE ACCOUNT FOR SHARING WITH ";
    var elem1 = $("#clientAreaSharing");
    elem1[0].style.removeProperty('background-color');
    elem1[0].style.setProperty('background-color', '#E5E4E7', 'important');
    var elem2 = $("#maincontents");
    elem2[0].style.removeProperty('background-color');
    elem2[0].style.setProperty('background-color', '#E5E4E7', 'important');
    var elem6 = $("#divDataShared");
    elem6[0].style.removeProperty('background-color');
    elem6[0].style.setProperty('background-color', '#E5E4E7', 'important');
    var elem7 = $("#FirendsList");
    elem7[0].style.removeProperty('background-color');
    elem7[0].style.setProperty('background-color', '#E5E4E7', 'important');
}

$("#SharedUserName").html(sessionStorage.getItem("UserNameShared"));
document.getElementById("Rpic1").src = "/userpic/" + sessionStorage.getItem("UserIDShared") + ".jpg";
function imgerror(e) {
    e.src = "userpic/userError.png";

}
function LoadCat() {

    var userid = window.sessionStorage.getItem("UserID");
    var Search = "";// document.getElementById("txtSearch").value;
    //$('#loadI').attr('class', 'fa fa-refresh fa-spin');
    //loading script

    var type = 'I';


  

        $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/' + Cat_Procedure,
            dataType: 'json',
            data: proc_Prameters,
            contentType: 'application/json; charset=utf-8',

            success: function (response) {
                

                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);


                var str = "";
                var dt = "";

                dt = dt + '';
                for (var i = 0; i < data.Row.length; i++) {

                    var bal = 0;
                    if (data.Row[i].Balance == "") {
                        bal = "0.00";

                    }

                    else if (parseFloat(data.Row[i].Balance) < 0) {
                        bal = data.Row[i].Balance.toString() + " <span style=';font-weight:bold;'>[CR]</span>";
                        bal = bal.replace("-", "");
                    }
                    else {
                        bal = data.Row[i].Balance;
                    }
                    if (sessionStorage.getItem("SharingOption") == "Delete") {
                        bal = data.Row[i].Source + "/" + data.Row[i].ACount;
                    }

                    dt = dt + ' <div  id="' + data.Row[i].CatId + ':' + data.Row[i].category + '" class="flip-cardb" >  ';
                    dt = dt + '   <div id = "3" class=" text-white css-Cell  flip-cardb-inner"> ';
                    dt = dt + '        <div class="flip-card-front align-self-center">';
                    dt = dt + '            <div id="' + data.Row[i].CatId + ':' + data.Row[i].category + '" onclick="LoadSub(this.id);" class="w-100 text-center share_image" style=" background-color:' + data.Row[i].Color + ' "> <i   id = "C' + data.Row[i].CatId + '" class="share_icon ' + data.Row[i].Icon + ' " ></i> </div>';
                    dt = dt + '            <div class="share_amount w-100 text-center "><strong>' + data.Row[i].category + '</strong> <span>' + bal + '</span></div>';
                    dt = dt + '        </div>';
                    //dt = dt + '        <div class="flip-card-back align-self-center  pt-2">';
                    //dt = dt + '            <div class="w-100 text-center  " style="overflow-wrap: break-word;">  <strong>' + data.Row[i].category + '</strong></div>';
                    //dt = dt + '            <div class="w-100 text-center pt-1 " style="overflow-wrap: break-word;"> <a id="' + data.Row[i].CatId + ':' + data.Row[i].category + '" name="' + data.Row[i].category + '" href="#" onclick="LoadSub(this.id);" class=" flip-card-back-a " style=" margin-right:10px;"><i class="fa fa-search"></i></a>  <a id="' + data.Row[i].CatId + ":" + data.Row[i].Icon + ":" + data.Row[i].Color + ":" + data.Row[i].ACount + '" name="' + data.Row[i].category + '" href="#" onclick="editCat(this)" class="flip-card-back-a" style=" margin-left:10px;"><i class="fa fa-edit"></i></a></div>';
                    //dt = dt + '        </div>';
                    dt = dt + '    </div>';
                    dt = dt + ' </div>';



                    str = str + dt;
                    dt = "";



                }




                str = str + dt;

                str = str + '';

                document.getElementById("divDataShared").innerHTML = str;
                $('#loadI').removeAttr('class');// attr('class', 'fa fa-gear');



                $('#loadI').attr('class', 'fa fa-gear');


            },
            error: function (error) {
                console.log(error);
            }
        });


     

}
function LoadSub(a) {
    //alert(a);
    var ss = a.split(":");
    var userid = window.sessionStorage.getItem("UserID");
    sessionStorage.setItem("CatID", ss[0]);
    sessionStorage.setItem("CatTitle", ss[1]);
    var C_Prameters = CatSub_Prameters + "'CatID':'*catid*'}";
    var Search = ss[0];// document.getElementById("txtSearch").value;
    document.getElementById("SubTitle").innerHTML = " of " + ss[1];
    //$('#loadI').attr('class', 'fa fa-refresh fa-spin');
    //loading script
    C_Prameters = C_Prameters.replace("*catid*", Search)
    //alert(CatSub_Prameters+"set1");
 

        $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/' + CatSub_Procedure,
            dataType: 'json',
            data: C_Prameters,
            contentType: 'application/json; charset=utf-8',

            success: function (response) {

            

                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);
                //alert("1");
                var str = "";
                var dt = "";

                dt = dt + '';
                for (var i = 0; i < data.Row.length; i++) {

                    var bal = 0;
                    if (data.Row[i].Balance == "") {
                        bal = "0.00";

                    }

                    else if (parseFloat(data.Row[i].Balance) < 0) {
                        bal = data.Row[i].Balance.toString() + " <span style=';font-weight:bold;'>[CR]</span>";
                        bal = bal.replace("-", "");
                    }
                    else {
                        bal = data.Row[i].Balance;
                    }
                    if (sessionStorage.getItem("SharingOption") == "Delete") {
                        bal = data.Row[i].Source + "/" + data.Row[i].ACount;
                    }

                    dt = dt + ' <div id="' + data.Row[i].CatId + ':' + data.Row[i].category + '" class=" flip-cardb" > ';
                    dt = dt + ' <div id = "3" class=" text-white css-Cell  flip-cardb-inner"> ';
                    dt = dt + '        <div class="flip-card-front align-self-center">';
                    dt = dt + '            <div id="' + data.Row[i].CatId + ':' + data.Row[i].category + '" onclick="LoadAccounts(this.id);" class="w-100 text-center share_image" style=" background-color:' + data.Row[i].Color + ' "> <i   id = "C' + data.Row[i].CatId + '" class="share_icon ' + data.Row[i].Icon + ' " ></i> </div>';
                    dt = dt + '            <div class="share_amount w-100 text-center "><strong>' + data.Row[i].category + '</strong> <span>' + bal + '</span> </div>';
                    dt = dt + '        </div>';
                    //dt = dt + '        <div class="flip-card-back align-self-center  pt-2">';
                    //dt = dt + '            <div class="w-100 text-center  " style="overflow-wrap: break-word;">  <strong>' + data.Row[i].category + '</strong></div>';
                    //dt = dt + '            <div class="w-100 text-center pt-1 " style="overflow-wrap: break-word;"> <a id="' + data.Row[i].CatId + ':' + data.Row[i].category + '" name="' + data.Row[i].category + '" href="#" onclick="LoadAccounts(this.id);" class=" flip-card-back-a " style=" margin-right:10px;"><i class="fa fa-search"></i></a>  <a id="' + data.Row[i].CatId + ":" + data.Row[i].Icon + ":" + data.Row[i].Color + ":" + data.Row[i].ACount + '" name="' + data.Row[i].category + '" href="#" onclick="editCat(this)" class="flip-card-back-a" style=" margin-left:10px;"><i class="fa fa-edit"></i></a></div>';
                    //dt = dt + '        </div>';
                    dt = dt + '    </div>';
                    dt = dt + ' </div>';



                    str = str + dt;
                    dt = "";



                }

                //alert("2");


                str = str + dt;

                str = str + '';

                document.getElementById("FirendsList").innerHTML = str;
                $('#loadI').removeAttr('class');// attr('class', 'fa fa-gear');
                //alert(str);


                //adjustTextColor();
                $('#loadI').attr('class', 'fa fa-gear');


            },
            error: function (error) {
                console.log(error);
            }
        });


  
}

function LoadSubLevel2Delete() {
    //alert(a);
    //var ss = a.split(":");
    var userid = window.sessionStorage.getItem("UserID");
    //sessionStorage.setItem("CatID", ss[0]);
    //sessionStorage.setItem("CatTitle", ss[1]);
    //var C_Prameters = CatSub_Prameters + "'CatID':'*catid*'}";
    //var Search = ss[0];// document.getElementById("txtSearch").value;
    // document.getElementById("SubTitle").innerHTML = " of " + ss[1];
    //$('#loadI').attr('class', 'fa fa-refresh fa-spin');
    //loading script
    //C_Prameters = C_Prameters.replace("*catid*", Search)
    //alert(CatSub_Prameters+"set1");

  

        $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/LoadSubCatforSharingForLevel2',
            dataType: 'json',
            data: "{'owneruserid':'" + userid + "','Shareduserid':'" + shareduserid + "','UserID':'" + userid + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {

                

                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);
                //alert("1");
                var str = "";
                var dt = "";

                dt = dt + '';
                for (var i = 0; i < data.Row.length; i++) {

                    var bal = 0;
                    if (data.Row[i].Balance == "") {
                        bal = "0.00";

                    }

                    else if (parseFloat(data.Row[i].Balance) < 0) {
                        bal = data.Row[i].Balance.toString() + " <span style=';font-weight:bold;'>[CR]</span>";
                        bal = bal.replace("-", "");
                    }
                    else {
                        bal = data.Row[i].Balance;
                    }
                    if (sessionStorage.getItem("SharingOption") == "Delete") {
                        bal = data.Row[i].Source + "/" + data.Row[i].ACount;
                    }

                    dt = dt + ' <div id="' + data.Row[i].CatId + ':' + data.Row[i].category + '" class=" flip-cardb" > ';
                    dt = dt + ' <div id = "3" class=" text-white css-Cell  flip-cardb-inner"> ';
                    dt = dt + '        <div class="flip-card-front align-self-center">';
                    dt = dt + '            <div id="' + data.Row[i].CatId + ':' + data.Row[i].category + '" onclick="LoadAccounts(this.id);" class="w-100 text-center share_image" style=" background-color:' + data.Row[i].Color + ' "> <i   id = "C' + data.Row[i].CatId + '" class="share_icon ' + data.Row[i].Icon + ' " ></i> </div>';
                    dt = dt + '            <div class="share_amount w-100 text-center "><strong>' + data.Row[i].category + '</strong> <span>' + bal + '</span> </div>';
                    dt = dt + '        </div>';
                    //dt = dt + '        <div class="flip-card-back align-self-center  pt-2">';
                    //dt = dt + '            <div class="w-100 text-center  " style="overflow-wrap: break-word;">  <strong>' + data.Row[i].category + '</strong></div>';
                    //dt = dt + '            <div class="w-100 text-center pt-1 " style="overflow-wrap: break-word;"> <a id="' + data.Row[i].CatId + ':' + data.Row[i].category + '" name="' + data.Row[i].category + '" href="#" onclick="LoadAccounts(this.id);" class=" flip-card-back-a " style=" margin-right:10px;"><i class="fa fa-search"></i></a>  <a id="' + data.Row[i].CatId + ":" + data.Row[i].Icon + ":" + data.Row[i].Color + ":" + data.Row[i].ACount + '" name="' + data.Row[i].category + '" href="#" onclick="editCat(this)" class="flip-card-back-a" style=" margin-left:10px;"><i class="fa fa-edit"></i></a></div>';
                    //dt = dt + '        </div>';
                    dt = dt + '    </div>';
                    dt = dt + ' </div>';



                    str = str + dt;
                    dt = "";



                }

                //alert("2");


                str = str + dt;

                str = str + '';

                document.getElementById("FirendsList").innerHTML = str;
                $('#loadI').removeAttr('class');// attr('class', 'fa fa-gear');
                //alert(str);


                //adjustTextColor();
                $('#loadI').attr('class', 'fa fa-gear');


            },
            error: function (error) {
                console.log(error);
            }
        });


     
}



function LoadSubLevel2() {
    //alert(a);
    //var ss = a.split(":");
    var userid = window.sessionStorage.getItem("UserID");
    //sessionStorage.setItem("CatID", ss[0]);
    //sessionStorage.setItem("CatTitle", ss[1]);
    //var C_Prameters = CatSub_Prameters + "'CatID':'*catid*'}";
    //var Search = ss[0];// document.getElementById("txtSearch").value;
    // document.getElementById("SubTitle").innerHTML = " of " + ss[1];
    //$('#loadI').attr('class', 'fa fa-refresh fa-spin');
    //loading script
    //C_Prameters = C_Prameters.replace("*catid*", Search)
    //alert(CatSub_Prameters+"set1");

 

        $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/loadSubCatbyUserID',
            dataType: 'json',
            data: "{'UserID':'" + userid + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {

               

                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);
                //alert("1");
                var str = "";
                var dt = "";

                dt = dt + '';
                for (var i = 0; i < data.Row.length; i++) {

                    var bal = 0;
                    if (data.Row[i].Balance == "") {
                        bal = "0.00";

                    }

                    else if (parseFloat(data.Row[i].Balance) < 0) {
                        bal = data.Row[i].Balance.toString() + " <span style=';font-weight:bold;'>[CR]</span>";
                        bal = bal.replace("-", "");
                    }
                    else {
                        bal = data.Row[i].Balance;
                    }
                    if (sessionStorage.getItem("SharingOption") == "Delete") {
                        bal = data.Row[i].Source + "/" + data.Row[i].ACount;
                    }

                    dt = dt + ' <div id="' + data.Row[i].CatId + ':' + data.Row[i].category + '" class=" flip-cardb" > ';
                    dt = dt + ' <div id = "3" class=" text-white css-Cell  flip-cardb-inner"> ';
                    dt = dt + '        <div class="flip-card-front align-self-center">';
                    dt = dt + '            <div id="' + data.Row[i].CatId + ':' + data.Row[i].category + '" onclick="LoadAccounts(this.id);" class="w-100 text-center share_image" style=" background-color:' + data.Row[i].Color + ' "> <i   id = "C' + data.Row[i].CatId + '" class="share_icon ' + data.Row[i].Icon + ' " ></i> </div>';
                    dt = dt + '            <div class="share_amount w-100 text-center "><strong>' + data.Row[i].category + '</strong> <span>' + bal + '</span> </div>';
                    dt = dt + '        </div>';
                    //dt = dt + '        <div class="flip-card-back align-self-center  pt-2">';
                    //dt = dt + '            <div class="w-100 text-center  " style="overflow-wrap: break-word;">  <strong>' + data.Row[i].category + '</strong></div>';
                    //dt = dt + '            <div class="w-100 text-center pt-1 " style="overflow-wrap: break-word;"> <a id="' + data.Row[i].CatId + ':' + data.Row[i].category + '" name="' + data.Row[i].category + '" href="#" onclick="LoadAccounts(this.id);" class=" flip-card-back-a " style=" margin-right:10px;"><i class="fa fa-search"></i></a>  <a id="' + data.Row[i].CatId + ":" + data.Row[i].Icon + ":" + data.Row[i].Color + ":" + data.Row[i].ACount + '" name="' + data.Row[i].category + '" href="#" onclick="editCat(this)" class="flip-card-back-a" style=" margin-left:10px;"><i class="fa fa-edit"></i></a></div>';
                    //dt = dt + '        </div>';
                    dt = dt + '    </div>';
                    dt = dt + ' </div>';



                    str = str + dt;
                    dt = "";



                }

                //alert("2");


                str = str + dt;

                str = str + '';

                document.getElementById("FirendsList").innerHTML = str;
                $('#loadI').removeAttr('class');// attr('class', 'fa fa-gear');
                //alert(str);


                //adjustTextColor();
                $('#loadI').attr('class', 'fa fa-gear');


            },
            error: function (error) {
                console.log(error);
            }
        });


    
}




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
$("#txtSearch").keyup(function (event) {
    if (event.keyCode === 13) {
        Searchfn();
    }
});
function loadsubCat(aa) {
    sessionStorage.setItem("CatId", aa.id);
    sessionStorage.setItem("CatName", aa.name);
    location.href = "subCategory.html";
}
function LoadAccounts(a) {
    var ss = a.split(":");

    var userid = window.sessionStorage.getItem("UserID");
    sessionStorage.setItem("subCatID", ss[0]);// document.getElementById("txtSearch").value;
    sessionStorage.setItem("subCatTitle", ss[1]);
    //document.getElementById("SubTitle").innerHTML = " of " + ss[1];
    // alert(a);
    LoadFile("UserSharedAccounts.html");

}

function ShowAccountList(usr) {
    var name1 = document.getElementById("H" + usr.id).value;
    sessionStorage.setItem("UserIDShared", usr.id);
    sessionStorage.setItem("UserNameShared", name1);

    document.location.href = "SharedAccountlist.html";

}
function ShowAccountListRemove(usr) {

    var name1 = document.getElementById("H" + usr.id).value;
    sessionStorage.setItem("UserIDShared", usr.id);
    sessionStorage.setItem("UserNameShared", name1);
    document.location.href = "SharedAccountlistRemove.html";

}
function Callinvitation(usr) {
    var name1 = document.getElementById("H" + usr.id).value;
    sessionStorage.setItem("UserIDShared", usr.id);
    sessionStorage.setItem("UserNameShared", name1);
    document.location.href = "userinvitation.html";
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
    var hr = h - 160;

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
