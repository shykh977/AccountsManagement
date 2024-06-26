
ListofFriendsforSharing();
function imgerror(e) {
    e.src = "userpic/userError.png";

}
function Searchfn() {

    var userid = window.sessionStorage.getItem("UserID");
    var Search = document.getElementById("txtSearch").value;
    if (Search.length > 3) {

        //alert("{'Search':'" + Search + "','UserID':'" + userid + "'}");
        //$('#loadI').attr('class', 'fa fa-refresh fa-spin');
        //loading script

   

            $.ajax({
                type: 'POST',
                url: 'Users.asmx/loadSearchedUsers',
                dataType: 'json',
                data: "{'Search':'" + Search + "','UserID':'" + userid + "'}",
                contentType: 'application/json; charset=utf-8',

                success: function (response) {

                  


                    var txt = '{"Row": ' + response.d + '}';
                    var data = JSON.parse(txt);

                    //  alert(data.Row[0].District);
                    // yaha loop lage ga na
                    var str = "";
                    var dt = "";
                    dt = dt + '<div  class="d-flex flex-wrap justify-content-between MainSharing " style="flex-wrap: wrap;  justify-content: space-around;" >';
                    var LastUserID = '0';
                    var count1 = 0;
                    for (var i = 0; i < data.Row.length; i++) {

                        if (LastUserID == data.Row[i].UserID) {
                            LastUserID = data.Row[i].UserID;
                        }
                        else {
                            dt = dt + ' <div class="card bg-white  p-1 CardStyleSharing" style=" ">';
                            //dt = dt + ' <i  id="C"' + data.Row[i].CatId + '" class=" '+ data.Row[i].Icon +' " style="padding-bottom:10px; color: ' + data.Row[i].Color +' "></i> ';
                            dt = dt + '      <div class="card-body col-lg-12 col-md-12 col-sm-12 col-xs-12 pt-0 pb-0 " style="padding:13px;">';
                            dt = dt + '     <div class="row">';
                            dt = dt + '         <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 p-0">';
                            dt = dt + '             <img id="Rpic" class="user-image" src="/userpic/' + data.Row[i].UserID + '.jpg" onerror="imgerror(this)">';
                            dt = dt + '         </div>';
                            var data1 = data.Row[i].SearchData.split('-+-').join('<br/>');
                            //alert(data1 + "  1   " + data.Row[i].SearchData);
                            dt = dt + '         <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 p-0" style="font-size:12px; margin-top:8px;margin-bottom:8px;margin-left:15px !important;"> ' + data1 + '  ';
                            dt = dt + '             <input type="hidden" id="H' + data.Row[i].UserID + '"  value="' + data.Row[i].FullName + '"/>';
                            dt = dt + '         </div>';
                            dt = dt + '         <div class="col-lg-1 col-md-1 col-sm-1 col-xs-1 " style=" padding-top:7px;padding-right:10px;"> ';
                            dt = dt + '                 <div  > <a id="' + data.Row[i].UserID + '" name="' + data.Row[i].UserID + '" href="#" onclick="ShowAccountList(this)" class="" style="font-size:20px;"><i class="fa fa-plus-circle"></i></a></div> ';
                            //  dt = dt + '                 <div  > <a id="' + data.Row[i].UserID + '" name="' + data.Row[i].UserID + '" href="#" onclick="ShowAccountListRemove(this)" class="" style="font-size:20px; color:red"><i class="fa fa-trash"></i></a></div> ';
                            dt = dt + '         </div>';
                            dt = dt + '     </div>';
                            dt = dt + '   </div> ';
                            dt = dt + ' </div > ';

                            count1++;
                            str = str + dt;
                            dt = "";
                            LastUserID = data.Row[i].UserID;

                        }

                    }




                    str = str + dt;

                    str = str + '</div>';

                    document.getElementById("divData").innerHTML = str;
                    document.getElementById("SearchCount").innerText = count1;
                    document.getElementById("SearchResult").style.display = "block";
                    //  $('#loadI').removeAttr('class');// attr('class', 'fa fa-gear');
                    go();
                    $('#loadI').attr('class', 'fa fa-gear');


                },
                error: function (error) {
                    console.log(error);
                }
            });


       

    }
}
function ListofFriendsforSharing() {
    //alert("aa");
    var userid = window.sessionStorage.getItem("UserID");
    var Search = document.getElementById("txtSearch").value;
    //$('#loadI').attr('class', 'fa fa-refresh fa-spin');
    //loading script

   
        $.ajax({
            type: 'POST',
            url: 'Users.asmx/ListofFriendsforSharing',
            dataType: 'json',
            data: "{'UserID':'" + userid + "'}",
            contentType: 'application/json; charset=utf-8',

            success: function (response) {
            

                var txt = '{"Row": ' + response.d + '}';
                var data = JSON.parse(txt);

                //  alert(data.Row[0].District);
                // yaha loop lage ga na
                var str = "";
                var dt = "";
                dt = dt + '<div class="d-flex flex-wrap justify-content-between MainSharing " style="flex-wrap: wrap;  justify-content: space-around;" >';
                var LastUserID = '0';
                var count1 = 0;
                for (var i = 0; i < data.Row.length; i++) {

                    if (LastUserID == data.Row[i].UserID) {
                        LastUserID = data.Row[i].UserID;
                    }
                    else {
                        dt = dt + ' <div class="card bg-white  p-1 CardStyleSharing" style=" ">';
                        //dt = dt + ' <i  id="C"' + data.Row[i].CatId + '" class=" '+ data.Row[i].Icon +' " style="padding-bottom:10px; color: ' + data.Row[i].Color +' "></i> ';
                        dt = dt + '    <div class="card-body col-lg-12 col-md-12 col-sm-12 col-xs-12 pt-0 pb-0 " style="padding:13px;">';
                        dt = dt + '     <div class="row">';
                        dt = dt + '         <div class="col-lg-2 col-md-2 col-sm-2 col-xs-2 p-0">';
                        dt = dt + '             <img id="Rpic" class="user-image"  src="/userpic/' + data.Row[i].UserID + '.jpg" onerror="imgerror(this)">';
                        dt = dt + '         </div>';

                        dt = dt + '         <div class="col-lg-8 col-md-8 col-sm-8 col-xs-8 p-0" style="font-size:12px; margin-top:8px;margin-bottom:8px;margin-left:15px !important;"> ' + data.Row[i].FullName + ' <br/> ' + data.Row[i].CellNo + ' <br/> ' + data.Row[i].email + '  ';
                        dt = dt + '             <input type="hidden" id="H' + data.Row[i].UserID + '"  value="' + data.Row[i].FullName + '"/>';
                        dt = dt + '         </div>';
                        dt = dt + '         <div class="col-lg-1 col-md-1 col-sm-1 col-xs-1 " style=" padding-top:7px;padding-right:10px;"> ';
                        dt = dt + '                 <div  > <a id="' + data.Row[i].UserID + '" name="' + data.Row[i].UserID + '" href="#" onclick="ShowAccountList(this)" class="" style="font-size:20px;"><i class="fa fa-plus-circle"></i></a></div> ';
                        dt = dt + '                 <div  > <a id="' + data.Row[i].UserID + '" name="' + data.Row[i].UserID + '" href="#" onclick="ShowAccountListRemove(this)" class="" style="font-size:20px; color:red"><i class="fa fa-trash"></i></a></div> ';
                        dt = dt + '         </div>';
                        dt = dt + '     </div>';
                        dt = dt + '   </div> ';
                        dt = dt + ' </div > ';

                        count1++;
                        str = str + dt;
                        dt = "";
                        LastUserID = data.Row[i].UserID;


                    }

                }



                str = str + dt;

                str = str + '</div>';

                document.getElementById("FirendsList").innerHTML = str;
                document.getElementById("ResultCountF").innerText = count1;
                //document.getElementById("SearchResult").style.display = "block";
                //  $('#loadI').removeAttr('class');// attr('class', 'fa fa-gear');
                go();
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

//        function ShowAccountList(usr) {
//            var name1 = document.getElementById("H" + usr.id).value;

//            sessionStorage.setItem("SharingOption", "Share");

//            sessionStorage.setItem("UserIDShared", usr.id);
//            sessionStorage.setItem("UserNameShared", name1);
//            LoadFile("UserSharingCategory.html");


//        }
//        function ShowAccountListRemove(usr) {

//            var name1 = document.getElementById("H" + usr.id).value;
//            sessionStorage.setItem("SharingOption", "Delete");
//            sessionStorage.setItem("UserIDShared", usr.id);
//            sessionStorage.setItem("UserNameShared", name1);
//            LoadFile("UserSharingCategory.html");

//}

function ShowAccountList(usr) {
    var name1 = document.getElementById("H" + usr.id).value;


    var ChartLevel = window.sessionStorage.getItem("ChartLevel", ChartLevel);

    if (ChartLevel == '1') {

        sessionStorage.setItem("SharingOption", "Share");

        sessionStorage.setItem("UserIDShared", usr.id);
        sessionStorage.setItem("UserNameShared", name1);
        LoadFile("UserSharedAccounts.html");

    }
    else if (ChartLevel == '2') {

        sessionStorage.setItem("SharingOption", "Share");

        sessionStorage.setItem("UserIDShared", usr.id);
        sessionStorage.setItem("UserNameShared", name1);
        LoadFile("UserSharingCategory.html");

    }
    else if (ChartLevel == '3') {
        sessionStorage.setItem("SharingOption", "Share");

        sessionStorage.setItem("UserIDShared", usr.id);
        sessionStorage.setItem("UserNameShared", name1);
        LoadFile("UserSharingCategory.html");
    }



}
function ShowAccountListRemove(usr) {

    var name1 = document.getElementById("H" + usr.id).value;




    var ChartLevel = window.sessionStorage.getItem("ChartLevel", ChartLevel);

    if (ChartLevel == '1') {

        sessionStorage.setItem("SharingOption", "Delete");
        sessionStorage.setItem("UserIDShared", usr.id);
        sessionStorage.setItem("UserNameShared", name1);
        LoadFile("UserSharedAccounts.html");

    }
    else if (ChartLevel == '2') {

        sessionStorage.setItem("SharingOption", "Delete");
        sessionStorage.setItem("UserIDShared", usr.id);
        sessionStorage.setItem("UserNameShared", name1);
        LoadFile("UserSharingCategory.html");

    }
    else if (ChartLevel == '3') {
        sessionStorage.setItem("SharingOption", "Delete");
        sessionStorage.setItem("UserIDShared", usr.id);
        sessionStorage.setItem("UserNameShared", name1);
        LoadFile("UserSharingCategory.html");
    }

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
