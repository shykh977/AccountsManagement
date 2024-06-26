//// Agent ///CreateInvestorsAndAgents

function CreateInvestorsAndAgents() {

    var UserID = sessionStorage.getItem("UserID");
    var InvestorAndAgentName =  document.getElementById("AgencyName").value;
    var CNIC =                  document.getElementById("cnic").value;
    var ContactPerson =         document.getElementById("ContactPerson").value;
    var PhoneNo =               document.getElementById("phonenum").value;
    var Country =               document.getElementById("Country").value;
    var State =                 document.getElementById("State").value;
    var City =                  document.getElementById("txtcity").value;
    var Area =                  document.getElementById("txtarea").value;
    var OfficeLocation =        document.getElementById("officelocation").value;
  
    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/CreateAgents',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','InvestorAndAgentName':'" + InvestorAndAgentName + "','CNIC':'" + CNIC + "','ContactPerson':'" + ContactPerson + "','PhoneNo':'" + PhoneNo + "','Country':'" + Country + "','State':'" + State + "','City':'" + City + "','Area':'" + Area + "','OfficeLocation':'" + OfficeLocation + "','Remarks':'  '}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert("Agent Has Been Added")

            document.getElementById("AgencyName").value ='';
            document.getElementById("cnic").value = '';
            document.getElementById("ContactPerson").value = '';
            document.getElementById("phonenum").value = '';
            document.getElementById("Country").value = '';
            document.getElementById("State").value = '';
            document.getElementById("txtcity").value = '';
            document.getElementById("txtarea").value = '';
            document.getElementById("officelocation").value = '';

            GetAgents()

        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetAgents() {
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
            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {
                mRow = mRow + 1;
                dt = dt + " <tr>";
                dt = dt + "   <td>" + mRow + ".</td>";
                dt = dt + "   <td> " + data.Row[i].InvestorAndAgentName + "</td>";
                dt = dt + "   <td> " + data.Row[i].ContactPerson + "</td>";
                dt = dt + "   <td> " + data.Row[i].PhoneNo + "</td>";
                dt = dt + "   <td> " + data.Row[i].Country + "</td>";
                dt = dt + "   <td> " + data.Row[i].State + "</td>";
                dt = dt + "   <td> " + data.Row[i].City + "</td>";
                dt = dt + "   <td> " + data.Row[i].Area + "</td>";
                dt = dt + "   <td> " + data.Row[i].OfficeLocation + "</td>";

                dt = dt + " <td><a href='#'  onclick=EditProjectLocation('" + data.Row[i].ProjectLocationId + "');><i class='fa fa-edit'></i> &nbsp;</a></td>";
                dt = dt + " <td><a href='#'  onclick=DeleteProjectLocation('" + data.Row[i].ProjectLocationId + "');>  <i class='fa fa-trash' style='color:red'></i> &nbsp;</a></td>";

                dt = dt + "</tr>";
                str = str + dt;
                dt = "";
            }
            document.getElementById("AgentList").innerHTML = str;

        },
        error: function (error) {
            console.log(error);
        }
    });
}

////// Investor


function CreateInvestors() {

    var UserID = sessionStorage.getItem("UserID");
    var InvestorAndAgentName = document.getElementById("AgencyName").value;
    var CNIC = document.getElementById("cnic").value;
    var ContactPerson = document.getElementById("ContactPerson").value;
    var PhoneNo = document.getElementById("phonenum").value;
    var Country = document.getElementById("Country").value;
    var State = document.getElementById("State").value;
    var City = document.getElementById("txtcity").value;
    var Area = document.getElementById("txtarea").value;
    var OfficeLocation = document.getElementById("officelocation").value;

    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/CreateInvestorsAndAgents',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','InvestorAndAgentName':'" + InvestorAndAgentName + "','CNIC':'" + CNIC + "','ContactPerson':'" + ContactPerson + "','PhoneNo':'" + PhoneNo + "','Country':'" + Country + "','State':'" + State + "','City':'" + City + "','Area':'" + Area + "','OfficeLocation':'" + OfficeLocation + "','Remarks':'  '}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert("Agent Has Been Added")

            document.getElementById("AgencyName").value = '';
            document.getElementById("cnic").value = '';
            document.getElementById("ContactPerson").value = '';
            document.getElementById("phonenum").value = '';
            document.getElementById("Country").value = '';
            document.getElementById("State").value = '';
            document.getElementById("txtcity").value = '';
            document.getElementById("txtarea").value = '';
            document.getElementById("officelocation").value = '';
            GetInvestors()


        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetInvestors() {
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
            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {
                mRow = mRow + 1;
                dt = dt + " <tr>";
                dt = dt + "   <td>" + mRow + ".</td>";
                dt = dt + "   <td> " + data.Row[i].InvestorAndAgentName + "</td>";
                dt = dt + "   <td> " + data.Row[i].ContactPerson + "</td>";
                dt = dt + "   <td> " + data.Row[i].PhoneNo + "</td>";
                dt = dt + "   <td> " + data.Row[i].Country + "</td>";
                dt = dt + "   <td> " + data.Row[i].State + "</td>";
                dt = dt + "   <td> " + data.Row[i].City + "</td>";
                dt = dt + "   <td> " + data.Row[i].Area + "</td>";
                dt = dt + "   <td> " + data.Row[i].OfficeLocation + "</td>";

                dt = dt + " <td><a href='#'  onclick=EditProjectLocation('" + data.Row[i].ProjectLocationId + "');><i class='fa fa-edit'></i> &nbsp;</a></td>";
                dt = dt + " <td><a href='#'  onclick=DeleteProjectLocation('" + data.Row[i].ProjectLocationId + "');>  <i class='fa fa-trash' style='color:red'></i> &nbsp;</a></td>";

                dt = dt + "</tr>";
                str = str + dt;
                dt = "";
            }
            document.getElementById("InvestorList").innerHTML = str;

        },
        error: function (error) {
            console.log(error);
        }
    });
}
