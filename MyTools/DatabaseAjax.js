/*eslint eqeqeq: ["error", "smart"]*/
function SaveUsers(UserName, Password, CellNo, email, DateofCreation, ActiveStatus)
{  
          
          
    var Messege = "";

    $.ajax({
            type: "POST",
            dataType: "json",
            contentType: "application/json; charset=utf-8",
        url: "../Users.asmx/SaveUsers",
        data: "{'UserName':'" + UserName + "', 'Password':'" + Password + "', 'CellNo':'" + CellNo + "', 'email':'" + email + "', 'DateofCreation':'" + DateofCreation + "',  'ActiveStatus':'" + ActiveStatus + "'}",
        success: function (Record) {
                alert(Record.d);
                SendEmailNewUser(UserName, CellNo, email);
                //if (Record.d == true) {

                //    $('#Result').text("Your Record insert");
                //}
                //else {
                //    $('#Result').text("Your Record Not Insert");
                //}

            },
            Error: function (textMsg) {

                $('#Result').text("Error: " + Error);
            }
        });
   

}
function SendInvitation(UserName, CellNo, email, Descrption,InvitationStatus,FromUser) {

    alert("sendinvt");
    var Messege = "";

    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "Users.asmx/FirstSendInvitation",
        data: "{'UserName':'" + UserName + "', 'CellNo':'" + CellNo + "', 'email':'" + email + "', 'Descrption':'" + Descrption + "',  'InvitationStatus':'" + InvitationStatus + "',  'FromUser':'" + FromUser + "'}",
        success: function (Record) {
            alert(Record.d);
            
            //alert("aa");
            if (Record.d == true) {
              
              // $('#Result').text("Your Record insert");
            }
            else {
               // $('#Result').text("Your Record Not Insert");
            }

        },
        Error: function (textMsg) {

           // $('#Result').text("Error: " + Error);
        }
    });


}
function SendEmailNewUser(UserName, CellNo, email) {
    // var mCat, mCol, mIcon;
    var Subj = "WellCome to munshibaba Financial & Management Assistant";
    var Body1 = "Dear Mr. " + UserName + ", <br/>";
    Body1 = Body1 + " You are welcome to munshi<span style='color:#f49f21;'>baba</span>.com Financial & Management Assistant";
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "Users.asmx/SendEmail",
        data: "{'UserName':'" + UserName + "','CellNo':'" + CellNo + "','Email':'" + email + "','subject':'" + Subj + "','message':'" + Body1 +   "'}",
        success: function (response) {
            
            alert(response.d);
            //  alert(response.d);

        },
        error: function (error) {
            alert(Password);
            console.log(error);
        }
    });
}

function SendEmailInvitation(UserName, CellNo, email) {
    // var mCat, mCol, mIcon;
    var Subj = "WelCome to Munshi Financial Assistant";
    var Body1 = "Dear Mr. " + UserName + ", <br/>";
    Body1 = Body1 + " You are welcome you at Munshi Financial Assistant";
    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "Users.asmx/SendEmail",
        data: "{'UserName':'" + UserName + "','CellNo':'" + CellNo + "','Email':'" + email + "','subject':'" + Subj + "','message':'" + Body1 + "'}",
        success: function (response) {

            alert(response.d);
            //  alert(response.d);

        },
        error: function (error) {
            alert(Password);
            console.log(error);
        }
    });
}

function SendEmailShareAccount(UserName, CellNo, email,AccountID,AccountName,Permission,EmailOption,URL1,SenderName) {
    // var mCat, mCol, mIcon;
    //alert("a9");
    //var Subj = "WelCome to Munshi Financial Assistant";

    //var Body1 = "Dear Mr. " + UserName + ", <br/>";

    //if (EmailOption == "Reminder") {
    //    Body1 = "Reminder From:" + sessionStorage.getItem("UserName") + "<br/> Waiting for your Response <br/>" + Body1;
    //}
    //Body1 = Body1 + " You are welcome you at Munshi Financial Assistant";
    //Body1 = Body1 + "<div > <a href='User.html?id1'>Accept</a>   ";
    //Body1 = Body1 + "<div > <a href='Reject.html?id2'>Reject</a> ";
    //Body1 = Body1 + "</div>";

    $.ajax({
        type: "POST",
        dataType: "json",
        contentType: "application/json; charset=utf-8",
        url: "Users.asmx/SendEmailShareAccount",
        data: "{'UserName':'" + UserName + "','CellNo':'" + CellNo + "','Email':'" + email + "','AccountID':'" + AccountID + "','AccountName':'" + AccountName + "','Permission':'" + Permission + "','EmailOption':'" + EmailOption + "','URL':'" + URL1 + "','SenderName':'" + SenderName + "'}",
        success: function (response) {

            alert(response.d);
            //  alert(response.d);

        },
        error: function (error) {
            alert(error);
            console.log(error);
        }
    });
}

