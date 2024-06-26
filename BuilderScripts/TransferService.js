function GetAgentsListFrom() {
    var ProjectId = sessionStorage.getItem("ProjectId");
    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/GetAgents',
        dataType: 'json',
        //data: "{'ProjectId':'" + ProjectId + "'}",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var str = "";
            var dt = "";
            var option = "";
            option = option + "<option value=''>Select Agent </option>"
            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {

                option = option + "   <option value='" + data.Row[i].InvestorsAndAgentsId + "'> " + data.Row[i].InvestorAndAgentName + "</option>";

            }
            document.getElementById("TransferFromName").innerHTML = option;

        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetInvestorsListFrom() {
    var ProjectId = sessionStorage.getItem("ProjectId");
    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/GetInvestors',
        dataType: 'json',
        //data: "{'ProjectId':'" + ProjectId + "'}",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var str = "";
            var dt = "";
            var option = "";
            option = option + "<option value=''>Select Agent </option>"
            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {

                option = option + "   <option value='" + data.Row[i].InvestorsAndAgentsId + "'> " + data.Row[i].InvestorAndAgentName + "</option>";

            }
            document.getElementById("TransferFromName").innerHTML = option;


        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetProjectCustomersFrom() {
    var ProjectId = sessionStorage.getItem("ProjectId")
    $.ajax({
        type: 'POST',
        url: 'ProjectCustomers.asmx/GetProjectCustomers',
        dataType: 'json',
        data: "{'ProjectId':'" + ProjectId + "'}",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var option = "";
            var mRow = 0;

            option = option + "<option value=''>Select Customer </option>"
            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {

                option = option + "   <option value='" + data.Row[i].CustomerId + "'> " + data.Row[i].Firstname + "      " + data.Row[i].Lastname + "</option>";

            }
            document.getElementById("TransferFromName").innerHTML = option;



        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetAgentsListTo() {
    var ProjectId = sessionStorage.getItem("ProjectId");
    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/GetAgents',
        dataType: 'json',
        //data: "{'ProjectId':'" + ProjectId + "'}",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var str = "";
            var dt = "";
            var option = "";
            option = option + "<option value=''>Select Agent </option>"
            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {

                option = option + "   <option value='" + data.Row[i].InvestorsAndAgentsId + "'> " + data.Row[i].InvestorAndAgentName + "</option>";

            }
            document.getElementById("TransferToName").innerHTML = option;

        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetInvestorsListTo() {
    var ProjectId = sessionStorage.getItem("ProjectId");
    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/GetInvestors',
        dataType: 'json',
        //data: "{'ProjectId':'" + ProjectId + "'}",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var str = "";
            var dt = "";
            var option = "";
            option = option + "<option value=''>Select Agent </option>"
            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {

                option = option + "   <option value='" + data.Row[i].InvestorsAndAgentsId + "'> " + data.Row[i].InvestorAndAgentName + "</option>";

            }
            document.getElementById("TransferToName").innerHTML = option;


        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetProjectCustomersTo() {
    var ProjectId = sessionStorage.getItem("ProjectId")
    $.ajax({
        type: 'POST',
        url: 'ProjectCustomers.asmx/GetProjectCustomers',
        dataType: 'json',
        data: "{'ProjectId':'" + ProjectId + "'}",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var option = "";
            var mRow = 0;

            option = option + "<option value=''>Select Customer </option>"
            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {

                option = option + "   <option value='" + data.Row[i].CustomerId + "'> " + data.Row[i].Firstname + "      " + data.Row[i].Lastname + "</option>";

            }
            document.getElementById("TransferToName").innerHTML = option;
        },
        error: function (error) {
            console.log(error);
        }
    });
}


function CreateInventoryTransfer() {

    var TransferFrom = sessionStorage.getItem("TransferFrom")  
    var TransferTo = document.getElementById("TransferToName").value
    var TransferFee = document.getElementById("TransferFee").value
    var Deduction = document.getElementById("Deduction").value
    var UserID = sessionStorage.getItem("UserID")

    var  ProjectInventoryDetailId  = sessionStorage.getItem("ProjectInventoryDetailId")


    $.ajax({
        type: 'POST',
        url: 'SalesService.asmx/CreateInventoryTransfer',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','TransferFrom':'" + TransferFrom + "','TransferTo':'" + TransferTo + "','InventoryDetailId':'" + ProjectInventoryDetailId + "','TransferFee':'" + TransferFee + "','Deduction':'" + Deduction + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {

            alert("File Has Been Trasnfered")
            
        },
        error: function (error) {
            console.log(error);
        }
    });
}


