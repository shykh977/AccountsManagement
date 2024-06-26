var table = "<table class='table '><tbody><tr><td><div id='MonthLeft' onclick='drawClander(0, -1);' class='LeftRight'><span><i class='fa fa-chevron-left'></i></span></div></td>";
table = table + " <td colspan='2' class='YearMonth'><span id='Month' style='padding:2px;'>September </span></td> <td>";
table = table + " <div id='MonthRight' onclick='drawClander(0, 1);' style='text-align:right;' class='LeftRight'>"
table = table + " <span><i class='fa fa-chevron-right'></i></span> </div>  <td><div id='YearLeft' class='LeftRight' onclick='drawClander(-1, 0);'><span><i class='fa fa-chevron-left'></i></span></div>  </td>";
table = table + " <td colspan='1' class='YearMonth'><span id='Year' style='padding:2px;'>2018</span></td> <td>";
table = table + " <div id='YearRight' onclick='drawClander(1, 0);' class='LeftRight' style='text-align:right; '>   <span><i class='fa fa-chevron-right'></i></span>";
table = table + "  </div>  </td>  </tr>   <tr>";
table = table + " <th class='MydateHead'>Mon</th> <th class='MydateHead'>Tue</th>  <th class='MydateHead'>Wed</th> <th class='MydateHead'>Thu</th>"
table = table + " <th class='MydateHead'>Fri</th> <th class='MydateHead'>Sat</th> <th class='MydateHead'>Sun</th>  </tr>";
table = table + " <tr class='' id='Row1'></tr>  </tbody> </table>";

var collection = [
	{ SetDate: "2018-09-07", Status: "Payment" },
	{ SetDate: "2018-09-08", Status: "Payment Receipt" },
	{ SetDate: "2018-09-10", Status: "Receipt" },
	{ SetDate: "2018-09-13", Status: "Payment Receipt" },

	{ SetDate: "2018-09-02", Status: "Payment" },

];

var lastday = function (y, m) {
	return new Date(y, m + 1, 0).getDate();
};
var firstday = function (y, m) {
	return new Date(y, m, 1).getDate();
};
function DrawMyCalander(a) {
	//var mainDiv = document.getElementsByClassName("MyCalander99");
	document.getElementById(a).outerHTML = table;
	//mainDiv.innerHTML = table;
	drawClander(0, 0);
}

var SelectedDate = new Date();
var CurrentMonth = SelectedDate.getMonth();
var CurrentYear = SelectedDate.getFullYear();

var PreviousRow = 0;
var SelectedElement;
function drawClander(year1, month11) {

	var d = new Date(CurrentYear + year1, CurrentMonth + month11, 1);

	CurrentMonth = d.getMonth();
	CurrentYear = d.getFullYear();

	var monthN = new Array();
	monthN[0] = "January";
	monthN[1] = "February";
	monthN[2] = "March";
	monthN[3] = "April";
	monthN[4] = "May";
	monthN[5] = "June";
	monthN[6] = "July";
	monthN[7] = "August";
	monthN[8] = "September";
	monthN[9] = "October";
	monthN[10] = "November";
	monthN[11] = "December";
	var M = monthN[d.getMonth()];
	var n = d.getDay();
	//alert(d);
	var lastDay1 = lastday(d.getFullYear(), d.getMonth()); //new Date(d.getFullYear(), d.getMonth() + 1, 0);

	var row1 = "";
	var id1 = "D" + d.getFullYear() + "-" + ("00" + (d.getMonth() + 1)).slice(-2) + "-" + ("00" + 1).slice(-2);
	if (n == 1) {
		row1 = "<td class='Mydate' id=" + id1 + ">1</td>";
	}
	if (n == 2) {
		row1 = "<td class='Mydate'></td><td class='Mydate'>1</td>";
	}
	if (n == 3) {
		row1 = "<td class='Mydate'></td><td class='Mydate'></td><td class='Mydate' id=" + id1 + ">1</td>";
	}
	if (n == 4) {
		row1 = "<td class='Mydate'></td><td class='Mydate'></td><td class='Mydate'></td><td class='Mydate' id=" + id1 + ">1</td>";
	}
	if (n == 5) {
		row1 = "<td class='Mydate'></td><td class='Mydate'></td><td class='Mydate'></td><td class='Mydate'></td><td class='Mydate' id=" + id1 + ">1</td>";
	}
	if (n == 6) {
		row1 = "<td class='Mydate'></td><td class='Mydate'></td><td class='Mydate'></td><td class='Mydate'></td><td class='Mydate'></td><td class='Mydate' id=" + id1 + ">1</td>";
	}
	if (n == 0) {
		row1 = "<td class='Mydate'></td><td class='Mydate'></td><td class='Mydate'></td><td class='Mydate'></td><td class='Mydate'></td><td class='Mydate'></td><td class='Mydate' id=" + id1 + ">1</td>";
	}

	d1 = (new Date()).getDate();
	d1 = (SelectedDate).getDate();

	if (d1 == 1) {
		row1 = row1.replace("<td class='Mydate' id=" + id1 + ">1", "<td class='MydateSelected' id=" + id1 + ">1");
	}
	var location = n;
	var locadata = row1;
	// alert(lastDay1);
	var data = "";
	var r = 0;
	/*for (var i = 2;*/
}