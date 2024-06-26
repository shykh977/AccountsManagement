function CreateServicesProvide() {

    var UserID = sessionStorage.getItem("UserID");
    var ServiceName =           document.getElementById("ServiceName").value;
    var ServiceCharge =         document.getElementById("ServiceCharge").value;
    var ServiceDescription =    document.getElementById("ServiceDescription").value;
  
    $.ajax({
        type: 'POST',
        url: 'PurchaseService.asmx/CreateServicesProvide',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','ServiceName':'" + ServiceName + "','ServiceCharge':'" + ServiceCharge + "','ServiceDescription':'" + ServiceDescription + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert("Service Has Been Added")
            document.getElementById("ServiceName").value ='';
            document.getElementById("ServiceCharge").value = ''; 
            document.getElementById("ServiceDescription").value = ''
            GetServicesProvide()
        },
        error: function (error) {
            console.log(error);
        }
    });
}


function GetServicesProvide() {
    $.ajax({
        type: 'POST',
        url: 'PurchaseService.asmx/GetServicesProvide',
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
                dt = dt + "   <td> " + data.Row[i].ServiceName + "</td>";
                dt = dt + "   <td> " + data.Row[i].ServiceCharge + "</td>";
                dt = dt + "   <td> " + data.Row[i].ServiceDescription + "</td>";


                dt = dt + " <td><a href='#'  data-toggle='modal' data-target='#ServiceDetail' onclick=GetServiceProvideId('" + data.Row[i].ServiceProvideId + "');><i class='fa fa-plus'></i> &nbsp;</a></td>";
                dt = dt + " <td><a href='#'  onclick=EditProjectLocation('" + data.Row[i].ServiceProvideId + "');><i class='fa fa-edit'></i> &nbsp;</a></td>";
                dt = dt + " <td><a href='#'  onclick=DeleteProjectLocation('" + data.Row[i].ServiceProvideId + "');>  <i class='fa fa-trash' style='color:red'></i> &nbsp;</a></td>";

                dt = dt + "</tr>";
                str = str + dt;
                dt = "";
            }
            document.getElementById("ServiceList").innerHTML = str;

        },
        error: function (error) {
            console.log(error);
        }
    });
}

var ServicesProvideID = '';
function GetServiceProvideId(id){
    ServicesProvideID = id
}

function CreateServicesProvideDetail() {

   var  ServiceName     = document.getElementsByClassName("ServiceName")   
   var  Qty             = document.getElementsByClassName("Qty")
   var  Charges         = document.getElementsByClassName("Charges")
   var  ShippingCharges = document.getElementsByClassName("ShippingCharges")
   var  Total           = document.getElementsByClassName("Total")
   var  Discount        = document.getElementsByClassName("Discount")
   var GrandTotal = document.getElementsByClassName("GrandTotal")


    for (var i = 0; i < ServiceName.length; i++) {

        $.ajax({
            type: 'POST',
            url: 'PurchaseService.asmx/CreateServicesProvideDetail',
            dataType: 'json',
            data: "{'ServicesProvideId':'" + ServicesProvideID + "','ServiceName':'" + ServiceName[i].value + "','Qty':'" + Qty[i].value + "','Charges':'" + Charges[i].value + "','ShippingCharges':'" + ShippingCharges[i].value + "','Total':'" + Total[i].value + "','Discount':'" + Discount[i].value + "','GrandTotal':'" + GrandTotal[i].value + "'}",
            contentType: 'application/json; charset=utf-8',
            success: function (response) {
                
                //document.getElementById("ServiceName").value = '';
                //document.getElementById("ServiceCharge").value = '';
                //document.getElementById("ServiceDescription").value = ''
                //GetServicesProvide()
            },
            error: function (error) {
                console.log(error);
            }
        });

    }
    alert("Service Detail Has Been Added")
}


function GetTotal() {

    var ServiceName = document.getElementsByClassName("ServiceName")
    var Qty = document.getElementsByClassName("Qty")
    var Charges = document.getElementsByClassName("Charges")
    var ShippingCharges = document.getElementsByClassName("ShippingCharges")
    var Total = document.getElementsByClassName("Total")
    var Discount = document.getElementsByClassName("Discount")
    var GrandTotal = document.getElementsByClassName("GrandTotal")
    for (var i = 0; i < ServiceName.length; i++) {

        Total[i].value =  parseFloat(Qty[i].value * Charges[i].value) + parseFloat( ShippingCharges[i].value)
    }

}


function GetDiscount() {
    var Total = document.getElementsByClassName("Total")
    var Discount = document.getElementsByClassName("Discount")
    var GrandTotal = document.getElementsByClassName("GrandTotal")


    for (var i = 0; i < Total.length; i++) {

        //GrandTotal[i].value = parseFloat(Total[i].value * Discount[i].value) / 100

        GrandTotal[i].value = parseFloat(Total[i].value * Discount[i].value) / 100
    }
}



//// Agent ///CreateInvestorsAndAgents

function CreateSuplier() {

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
        url: 'PurchaseService.asmx/CreateSuplier',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','InvestorAndAgentName':'" + InvestorAndAgentName + "','CNIC':'" + CNIC + "','ContactPerson':'" + ContactPerson + "','PhoneNo':'" + PhoneNo + "','Country':'" + Country + "','State':'" + State + "','City':'" + City + "','Area':'" + Area + "','OfficeLocation':'" + OfficeLocation + "','Remarks':'  '}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert("Supplier Has Been Added")

            document.getElementById("AgencyName").value = '';
            document.getElementById("cnic").value = '';
            document.getElementById("ContactPerson").value = '';
            document.getElementById("phonenum").value = '';
            document.getElementById("Country").value = '';
            document.getElementById("State").value = '';
            document.getElementById("txtcity").value = '';
            document.getElementById("txtarea").value = '';
            document.getElementById("officelocation").value = '';

            GetSuplier()

        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetSuplier() {
    var ProjectId = sessionStorage.getItem("ProjectId");
    $.ajax({
        type: 'POST',
        url: 'PurchaseService.asmx/GetSuplier',
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












