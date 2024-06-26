
/////// Project Location

function CreateProjectLocation() {

    var UserID = sessionStorage.getItem("UserID");
    var ProjectLocation = document.getElementById("ProjectLocation").value;
    var ProjectId = sessionStorage.getItem("ProjectId")

    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/CreateProjectLocation',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','ProjectLocation':'" + ProjectLocation + "','ProjectId':'" + ProjectId + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert("Project Location Has Been Added")
            document.getElementById("ProjectLocation").value = '';
            GetProjectLocation()
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetProjectLocation() {
    var ProjectId = sessionStorage.getItem("ProjectId");
    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/GetProjectLocationByProjectId',
        dataType: 'json',
        data: "{'ProjectId':'" + ProjectId + "'}",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var str = "";
            var dt = "";
            var option = "";
            option = option + "   <option value=''> Select Project Location</option>";
            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {
                mRow = mRow + 1;
                dt = dt + " <tr>";
                dt = dt + "   <td>" + mRow + ".</td>";
                dt = dt + "   <td> " + data.Row[i].ProjectLocation + "</td>";

                option = option + "   <option value=" + data.Row[i].ProjectLocationId +"> " + data.Row[i].ProjectLocation + "</option>";
                
               
                dt = dt + " <td><a href='#'  onclick=EditProjectLocation('" + data.Row[i].ProjectLocationId + "');><i class='fa fa-edit'></i> &nbsp;</a></td>";
                dt = dt + " <td><a href='#'  onclick=DeleteProjectLocation('" + data.Row[i].ProjectLocationId + "');>  <i class='fa fa-trash' style='color:red'></i> &nbsp;</a></td>";



                dt = dt + "</tr>";
                str = str + dt;
                dt = "";
            }
            document.getElementById("projectlocation").innerHTML = option;
            document.getElementById("TblProjectLocation").innerHTML = str;

        },
        error: function (error) {
            console.log(error);
        }
    });
}

//////// Project Phase


function CreateProjectPhases() {

    var UserID = sessionStorage.getItem("UserID");
    var PhaseName = document.getElementById("phasename").value;
    var ProjectId = sessionStorage.getItem("ProjectId")

    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/CreateProjectPhases',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','PhaseName':'" + PhaseName + "','ProjectId':'" + ProjectId + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert("Project Phase Has Been Added")
            document.getElementById("phasename").value = '';
            GetProjectPhase()
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetProjectPhase() {
    var ProjectId = sessionStorage.getItem("ProjectId");
    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/GetProjectPhasesByProject',
        dataType: 'json',
        data: "{'ProjectId':'" + ProjectId + "'}",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var str = "";
            var dt = "";
            var option = "";
            option = option + "   <option value=''> Select Project Phase</option>";
            var mRow = 0;

            for (var i = 0; i < data.Row.length; i++) {
                mRow = mRow + 1;
                dt = dt + " <tr>";
                dt = dt + "   <td>" + mRow + ".</td>";
                dt = dt + "   <td> " + data.Row[i].PhaseName + "</td>";

                option = option + "   <option value='" + data.Row[i].ProjectPhasesId + "'> " + data.Row[i].PhaseName + "</option>";


                dt = dt + " <td><a href='#'  onclick=EditProjectLocation('" + data.Row[i].ProjectPhasesId + "');><i class='fa fa-edit'></i> &nbsp;</a></td>";
                dt = dt + " <td><a href='#'  onclick=DeleteProjectLocation('" + data.Row[i].ProjectPhasesId + "');>  <i class='fa fa-trash' style='color:red'></i> &nbsp;</a></td>";



                dt = dt + "</tr>";
                str = str + dt;
                dt = "";
            }
          
            document.getElementById("projectphase").innerHTML = option;
            document.getElementById("TblProjectPhase").innerHTML = str;

        },
        error: function (error) {
            console.log(error);
        }
    });
}


//////// Project Phase Block


function CreatePhaseBlocks() {

    var UserID = sessionStorage.getItem("UserID");
    var BlockName = document.getElementById("BlockName").value;
    var ProjectPhase = document.getElementById("projectphase").value

    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/CreatePhaseBlocks',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','ProjectPhasesId':'" + ProjectPhase + "','Blocks':'" + BlockName + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert("Block Has Been Added")
            document.getElementById("BlockName").value = '';
            GetPhaseBlocksByPhases()
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetPhaseBlocksByPhases() {


    var ProjectPhasesId = document.getElementById("projectphase").value


    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/GetPhaseBlocksByPhases',
        dataType: 'json',
        data: "{'ProjectPhasesId':'" + ProjectPhasesId + "'}",
        contentType: 'application/json; charset=utf-8',

        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var str = "";
            var dt = "";
            var option = "";
            option = option + "   <option value=''> Select  Block</option>";
            var mRow = 0;

            for (var i = 0; i < data.Row.length; i++) {
                mRow = mRow + 1;
                dt = dt + " <tr>";
                dt = dt + "   <td>" + mRow + ".</td>";
                dt = dt + "   <td> " + data.Row[i].Blocks + "</td>";

                option = option + "   <option value='" + data.Row[i].PhaseBlocksId + "'> " + data.Row[i].Blocks + "</option>";


                dt = dt + " <td><a href='#'  onclick=EditProjectLocation('" + data.Row[i].PhaseBlocksId + "');><i class='fa fa-edit'></i> &nbsp;</a></td>";
                dt = dt + " <td><a href='#'  onclick=DeleteProjectLocation('" + data.Row[i].PhaseBlocksId + "');>  <i class='fa fa-trash' style='color:red'></i> &nbsp;</a></td>";



                dt = dt + "</tr>";
                str = str + dt;
                dt = "";
            }

            document.getElementById("phaseblock").innerHTML = option;
            document.getElementById("TblBlockName").innerHTML = str;

        },
        error: function (error) {
            console.log(error);
        }
    });
}

//////// Project Phase Block

function CreatePhaseBlockType() {

    var UserID = sessionStorage.getItem("UserID");
    var txtBlockType = document.getElementById("txtBlockType").value;
    var phaseblock = document.getElementById("phaseblock").value

    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/CreatePhaseBlockType',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','BlockId':'" + phaseblock + "','BlockTypeName':'" + txtBlockType + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert("Block Type Has Been Added")
            document.getElementById("txtBlockType").value = '';
            GetPhaseBlockTypeByBlock()
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetPhaseBlockTypeByBlock() {


    var BlockId = document.getElementById("phaseblock").value

    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/GetPhaseBlockTypeByBlock',
        dataType: 'json',
        data: "{'BlockId':'" + BlockId + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var str = "";
            var dt = "";
            var option = "";
            option = option + "   <option value=''> Select  Block Type</option>";
            var mRow = 0;

            for (var i = 0; i < data.Row.length; i++) {
                mRow = mRow + 1;
                dt = dt + " <tr>";
                dt = dt + "   <td>" + mRow + ".</td>";
                dt = dt + "   <td> " + data.Row[i].BlockTypeName + "</td>";

                option = option + "   <option value='" + data.Row[i].BlockTypeId + "'> " + data.Row[i].BlockTypeName + "</option>";


                dt = dt + " <td><a href='#'  onclick=EditProjectLocation('" + data.Row[i].BlockTypeId + "');><i class='fa fa-edit'></i> &nbsp;</a></td>";
                dt = dt + " <td><a href='#'  onclick=DeleteProjectLocation('" + data.Row[i].BlockTypeId + "');>  <i class='fa fa-trash' style='color:red'></i> &nbsp;</a></td>";



                dt = dt + "</tr>";
                str = str + dt;
                dt = "";
            }

            document.getElementById("Blocktype").innerHTML = option;
            document.getElementById("TblBlockTypeName").innerHTML = str;

        },
        error: function (error) {
            console.log(error);
        }
    });
}


//////// Project Block Category

function CreateBlockTypeCategory() {

    var UserID = sessionStorage.getItem("UserID");
    var txtBlockCategory = document.getElementById("txtBlockCategory").value;
    var Blocktype = document.getElementById("Blocktype").value

    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/CreateBlockTypeCategory',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','BlockTypeId':'" + Blocktype + "','BlockTypeName':'" + txtBlockCategory + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert("Block Category Has Been Added")
            document.getElementById("txtBlockCategory").value = '';
            GetBlockTypeCategoryByBlockType()
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetBlockTypeCategoryByBlockType() {


    var Blocktype = document.getElementById("Blocktype").value

    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/GetBlockTypeCategoryByBlockType',
        dataType: 'json',
        data: "{'BlockTypeId':'" + Blocktype + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var str = "";
            var dt = "";
            var option = "";
            option = option + "   <option value=''> Select  Block Type</option>";
            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {
                mRow = mRow + 1;
                dt = dt + " <tr>";
                dt = dt + "   <td>" + mRow + ".</td>";
                dt = dt + "   <td> " + data.Row[i].BlockTypeCategory + "</td>";

                option = option + "   <option value='" + data.Row[i].BlockTypeCategoryId + "'> " + data.Row[i].BlockTypeCategory + "</option>";

                dt = dt + " <td><a href='#'  onclick=EditProjectLocation('" + data.Row[i].BlockTypeCategoryId + "');><i class='fa fa-edit'></i> &nbsp;</a></td>";
                dt = dt + " <td><a href='#'  onclick=DeleteProjectLocation('" + data.Row[i].BlockTypeCategoryId + "');>  <i class='fa fa-trash' style='color:red'></i> &nbsp;</a></td>";

                dt = dt + "</tr>";
                str = str + dt;
                dt = "";
            }

            document.getElementById("BlockCategory").innerHTML = option;
            document.getElementById("TblBlockCategory").innerHTML = str;

        },
        error: function (error) {
            console.log(error);
        }
    });
}


//////// Project Category Size

function CreateBlockTypeCategorySize() {

    var UserID = sessionStorage.getItem("UserID");
    var txtCategorySize = document.getElementById("txtCategorySize").value;
    var BlockCategory = document.getElementById("BlockCategory").value

    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/CreateBlockTypeCategorySize',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','BlockTypeCategoryId':'" + BlockCategory + "','CategorySizeDescription':'" + txtCategorySize + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert("Category Size Has Been Added")
            document.getElementById("txtBlockCategory").value = '';
            //GetBlockTypeCategoryByBlockType()
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetCategorySizeByCategory() {


    var BlockTypeCategoryId = document.getElementById("BlockCategory").value


  

    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/GetBlockTypeCategorySizeByTypeCategory',
        dataType: 'json',
        data: "{'BlockTypeCategoryId':'" + BlockTypeCategoryId + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var str = "";
            var dt = "";
            var option = "";
            option = option + "   <option value=''> Select  Category Size</option>";
            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {
                mRow = mRow + 1;
                dt = dt + " <tr>";
                dt = dt + "   <td>" + mRow + ".</td>";
                dt = dt + "   <td> " + data.Row[i].CategorySizeDescription + "</td>";

                option = option + "   <option value='" + data.Row[i].CategorySizeId + "'> " + data.Row[i].CategorySizeDescription + "</option>";

                dt = dt + " <td><a href='#'  onclick=EditProjectLocation('" + data.Row[i].CategorySizeId + "');><i class='fa fa-edit'></i> &nbsp;</a></td>";
                dt = dt + " <td><a href='#'  onclick=DeleteProjectLocation('" + data.Row[i].CategorySizeId + "');>  <i class='fa fa-trash' style='color:red'></i> &nbsp;</a></td>";

                dt = dt + "</tr>";
                str = str + dt;
                dt = "";
            }

            document.getElementById("CategorySize").innerHTML = option;
            document.getElementById("TblCategorySize").innerHTML = str;

        },
        error: function (error) {
            console.log(error);
        }
    });
}

//////// Inventory Main Form Entry


function CreateProjectInventory() {

    var UserID = sessionStorage.getItem("UserID");

    var ProjectId = sessionStorage.getItem("ProjectId")
    var projectlocation =       document.getElementById("projectlocation").value
    var projectphase =          document.getElementById("projectphase").value
    var phaseblock =            document.getElementById("phaseblock").value
    var Blocktype =             document.getElementById("Blocktype").value
    var BlockCategory =         document.getElementById("BlockCategory").value
    var CategorySize =          document.getElementById("CategorySize").value
    var saleprice =             document.getElementById("saleprice").value
    var inventoryname =         document.getElementById("inventoryname").value
    var inventorycount =        document.getElementById("inventorycount").value
    var noteno =                document.getElementById("noteno").value
    var character =             document.getElementById("character").value
    var inventorydetail =       document.getElementById("inventorydetail").value




    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/CreateProjectInventory',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','OfficeLocationId':'" + projectlocation + "','ProjectId':'" + ProjectId + "','ProjectPhasesId':'" + projectphase + "','PhaseBlocksId':'" + phaseblock + "','BlockTypeId':'" + Blocktype + "','BlockTypeCategoryId':'" + BlockCategory + "','CategorySizeId':'" + CategorySize + "','SalePrice':'" + saleprice + "','InventoryName':'" + inventoryname + "','InventoryCount':'" + inventorycount + "','NoteNo':'" + noteno + "','Characters':'" + character + "','InventoryDetails':'" + inventorydetail + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert("Inventory Has Been Added")
            GetProjectInventory()
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetProjectInventory() {


    var ProjectId       = sessionStorage.getItem("ProjectId")
    var projectlocation = document.getElementById("projectlocation").value
    var projectphase    = document.getElementById("projectphase").value
    var phaseblock      = document.getElementById("phaseblock").value
    var Blocktype       = document.getElementById("Blocktype").value
    var BlockCategory   = document.getElementById("BlockCategory").value
    var CategorySize    = document.getElementById("CategorySize").value

    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/GetProjectInventory',
        dataType: 'json',
        data: "{'ProjectId':'" + ProjectId + "','OfficeLocationId':'" + projectlocation + "','ProjectPhasesId':'" + projectphase + "','PhaseBlocksId':'" + phaseblock + "','BlockTypeId':'" + Blocktype + "','BlockTypeCategoryId':'" + BlockCategory + "','CategorySizeId':'" + CategorySize + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var str = "";
            var dt = "";
          
            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {
                mRow = mRow + 1;
                dt = dt + " <tr>";
                dt = dt + "   <td>" + mRow + ".</td>";
                dt = dt + "   <td> " + data.Row[i].SalePrice + "</td>";
                dt = dt + "   <td> " + data.Row[i].InventoryName + "</td>";
                dt = dt + "   <td> " + data.Row[i].InventoryCount + "</td>";
                dt = dt + "   <td> " + data.Row[i].NoteNo + "</td>";
                dt = dt + "   <td> " + data.Row[i].Characters + "</td>";
                dt = dt + "   <td> " + data.Row[i].InventoryDetails + "</td>";

                dt = dt + " <td><a href='#'  onclick=OpenInventoryDetail('" + data.Row[i].ProjectInventoryId + "')><i class='fa fa-plus' style='font-size:25px;'></i> &nbsp;</a></td>";

                dt = dt + " <td><a href='#'  onclick=EditProjectLocation('" + data.Row[i].ProjectInventoryId + "');><i class='fa fa-edit'></i> &nbsp;</a></td>";
                dt = dt + " <td><a href='#'  onclick=DeleteProjectLocation('" + data.Row[i].ProjectInventoryId + "');>  <i class='fa fa-trash' style='color:red'></i> &nbsp;</a></td>";

                dt = dt + "</tr>";
                str = str + dt;
                dt = "";
            }

            
            document.getElementById("InventoryList").innerHTML = str;

        },
        error: function (error) {
            console.log(error);
        }
    });


}


function OpenInventoryDetail(ProjectInventoryId) {


    sessionStorage.setItem("ProjectInventoryId", ProjectInventoryId)
    LoadFile('AddProjectInventorydetail.html');
}


///////////////////Inventory Detail


function CreateInventoryDetail() {

    var UserID = sessionStorage.getItem("UserID");
    var fileno = document.getElementById("fileno").value
    var FileStatus = document.getElementById("FileStatus").value
    var Noteno = document.getElementById("Noteno").value
    var Printed = document.getElementById("Printed").value
    var Type = document.getElementById("Type").value

    var ProjectInventoryId = sessionStorage.getItem("ProjectInventoryId")

    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/CreateInventoryDetail',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','FileNo':'" + fileno + "','Status':'" + FileStatus + "','NoteNo':'" + Noteno + "','Printed':'" + Printed + "','Type':'" + Type + "','ProjectInventoryId':'" + ProjectInventoryId + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert("Inventory Has Been Added")
            GetProjectInventoryDetail()
        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetProjectInventoryDetail() {


    var ProjectInventoryId = sessionStorage.getItem("ProjectInventoryId")


    $.ajax({
        type: 'POST',
        url: 'InventoryService.asmx/GetProjectInventoryDetail',
        dataType: 'json',
        data: "{'ProjectInventoryId':'" + ProjectInventoryId + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var str = "";
            var dt = "";

            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {
                mRow = mRow + 1;
                dt = dt + " <tr>";
                dt = dt + "   <td>" + mRow + ".</td>";
                dt = dt + "   <td> " + data.Row[i].FileNo + "</td>";
                dt = dt + "   <td> " + data.Row[i].Status + "</td>";
                dt = dt + "   <td> " + data.Row[i].NoteNo + "</td>";
                dt = dt + "   <td> " + data.Row[i].Printed + "</td>";
                dt = dt + "   <td> " + data.Row[i].Type + "</td>";

                if (data.Row[i].IsAllocated == 1) {
                    dt = dt + " <td><a href='#' style=font-size:20px; data-toggle='modal' data-target='#StFileTransferModal' onclick=GetInventoryAllocationDetil('" + data.Row[i].ProjectInventoryDetailId + "')>  <i class='fa fa-lock' style='color:#FFD700'></i> &nbsp;</a></td>";

                }
                else {
                    dt = dt + " <td><a href='#' data-toggle='modal' data-target='#StFileAllocateModal' onclick=AssignFile('" + data.Row[i].ProjectInventoryDetailId + "');><i class='fa fa-plus'></i> &nbsp;</a></td>";

                }
               
                dt = dt + " <td><a href='#'  onclick=EditProjectLocation('" + data.Row[i].ProjectInventoryDetailId + "');><i class='fa fa-edit'></i> &nbsp;</a></td>";
                dt = dt + " <td><a href='#'  onclick=DeleteProjectLocation('" + data.Row[i].ProjectInventoryDetailId + "');>  <i class='fa fa-trash' style='color:red'></i> &nbsp;</a></td>";

                dt = dt + "</tr>";
                str = str + dt;
                dt = "";
            }


            document.getElementById("InventoryDetail").innerHTML = str;

        },
        error: function (error) {
            console.log(error);
        }
    });


}


//// Allocation


var ProjectInventoryDetailID = "";
function AssignFile(ProjectInventoryDetailId) {

    ProjectInventoryDetailID = ProjectInventoryDetailId;
}


function GetAgentsList() {
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
            document.getElementById("AllocatedToName").innerHTML = option;

        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetInvestorsList() {
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
            document.getElementById("AllocatedToName").innerHTML = option;


        },
        error: function (error) {
            console.log(error);
        }
    });
}

function GetProjectCustomers() {
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
            document.getElementById("AllocatedToName").innerHTML = option;



        },
        error: function (error) {
            console.log(error);
        }
    });
}


function CreateInventoryAllocation() {

    var UserID = sessionStorage.getItem("UserID");

    var AllocatedTo = document.getElementById("AllocatedTo").value
    var AllocatedToName = document.getElementById("AllocatedToName").value
    var AllocationDate = document.getElementById("AllocationDate").value
    var TotalAmount = document.getElementById("TotalAmount").value
    var PaidAmount = document.getElementById("PaidAmount").value

    var ProjectInventoryId = sessionStorage.getItem("ProjectInventoryId")

    $.ajax({
        type: 'POST',
        url: 'SalesService.asmx/CreateInventoryAllocation',
        dataType: 'json',
        data: "{'UserID':'" + UserID + "','ProjectInventoryDetailId':'" + ProjectInventoryDetailID + "','AllocatedTo':'" + AllocatedToName + "','AllocatedToType':'" + AllocatedTo + "','AllocationDate':'" + AllocationDate + "','TotalPrice':'" + TotalAmount + "','PaidAmount':'" + PaidAmount + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            alert("File Has Been Allocated")
           // GetProjectInventory()
        },
        error: function (error) {
            console.log(error);
        }
    });
}



//// Transfer

function GetInventoryAllocationDetil(ProjectInventoryDetailId) {

    sessionStorage.setItem("ProjectInventoryDetailId", ProjectInventoryDetailId)


    $.ajax({
        type: 'POST',
        url: 'SalesService.asmx/GetInventoryAllocationDetil',
        dataType: 'json',
        data: "{'ProjectInventoryDetailId':'" + ProjectInventoryDetailId + "'}",
        contentType: 'application/json; charset=utf-8',
        success: function (response) {
            var txt = '{"Row": ' + response.d + '}';
            var data = JSON.parse(txt);
            var str = "";
            var dt = "";

            var mRow = 0;
            for (var i = 0; i < data.Row.length; i++) {
                mRow = mRow + 1;

                dt = dt + "<tr>";
                dt = dt + "   <td>" + mRow + ".</td>";

                dt = dt + "   <td> " + data.Row[i].AllocatedToType + "</td>";


                if (data.Row[i].CustomerName == '') {
                    dt = dt + "   <td> " + data.Row[i].InvestorAndAgentName + "</td>";
                }
                else {
                    dt = dt + "   <td> " + data.Row[i].CustomerName + "</td>";

                }

                if (data.Row[i].FromCustomer == '') {
                    sessionStorage.setItem("TransferFrom", data.Row[0].FromInvestorsAndAgents)  
                }
                else {
                    sessionStorage.setItem("TransferFrom", data.Row[0].FromCustomer)  
                }

                dt = dt + "   <td> " + data.Row[i].AllocationDate + "</td>";
                dt = dt + "   <td> " + data.Row[i].TotalPrice + "</td>";
                dt = dt + "   <td> " + data.Row[i].PaidAmount + "</td>";               

                

                dt = dt + "</tr>";
                str = str + dt; 
                dt = "";
            }
            document.getElementById("InventoryAllocation").innerHTML = str;
            
        },
        error: function (error) {
            console.log(error);
        }
    });


}
