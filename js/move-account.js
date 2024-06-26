







MoveAccountCat();
function MoveAccountCat() {

    var ChartLevel = window.sessionStorage.getItem("ChartLevel", ChartLevel);

   
    if (ChartLevel == '2') {
        document.getElementById("CatL3").style.display = "none";
        document.getElementById("NCatL3").style.display = "none";
        document.getElementById("SubNameL2").innerHTML = "Category";
        document.getElementById("NSubNameL2").innerHTML = "Category";
        GetSubCategoryLevel2();
    }
    else if (ChartLevel == '3') {
        document.getElementById("CatL3").style.display = "block";
        document.getElementById("NCatL3").style.display = "block";
        document.getElementById("SubNameL2").innerHTML = "Sub-Category";
        document.getElementById("NSubNameL2").innerHTML = "Sub-Category";
        GetCategory();
    }


}










var SelAccount = "";
function setValeAccount(a) {
    SelAccount = a.value;
    //alert(SelAccount);
    var tt = $("#AccountTitle option:selected").text();
    //var tt1 = tt.split("[");
    //SelAccount = tt;// tt1[0].substr(0, tt1[0].length - 3);


}
var SelSubCat = "";
function setsubcat(a) {
    SelSubCat = a.value;
    //alert(SelSubCat);
    var tt = $("#NSubCategory option:selected").text();
    //var tt1 = tt.split("[");
    // SelSubCat = tt;// tt1[0].substr(0, tt1[0].length - 3);


}







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
                document.getElementById("NCategory").innerHTML = dt;


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





function GetSubCategoryLevel2() {
    var userid = sessionStorage.getItem("UserID");
    var type = "source";
    $('#spandataloading').show();
    //  var type = "E";
    //$('#loadI').attr('class', 'fa fa-refresh fa-spin');



 

        $.ajax({
            type: 'POST',
            url: 'Accounts.asmx/loadSubCat',
            dataType: 'json',
            data: "{'UserID':'" + userid + "'}",
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

                document.getElementById("SubCategory").innerHTML = dt;
                document.getElementById("NSubCategory").innerHTML = dt;

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


//UpdateAccountSubCat(string AccountID, string SubCatID)
function UpdateAccount() {

    var SelAccount = document.getElementById("AccountTitle").value;
    var SelSubCat = document.getElementById("NSubCategory").value;

    if (SelAccount == "" || SelSubCat == "") {
        // alert("Please select account and subcategory to move")
        $.alert({ title: 'Alert!:', content: 'Please select account and subcategory to move', });
    }
    else {

      

            $.ajax({
                type: 'POST',
                url: 'Accounts.asmx/UpdateAccountSubCat',
                dataType: 'json',
                data: "{'AccountID':'" + SelAccount + "','SubCatID':'" + SelSubCat + "'}",
                contentType: 'application/json; charset=utf-8',

                success: function (response) {
                    

                    if (response.d == "1") {
                        //alert("Successfully Moved");
                        $.alert({ title: 'Alert!:', content: 'Successfully Moved', });
                    }



                    $('#loadI').attr('class', 'fa fa-gear');


                },
                error: function (error) {
                    console.log(error);
                }
            });

       

        LoadFile("MoveAccount.html");

    }
}


