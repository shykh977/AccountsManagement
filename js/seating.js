/*
    $(document).ready(function () {
        $(".home").hover(
            function () { $(this).attr("src", "img/seating/Setting_Language2.svg"); },
            function () {
                $(this).attr("src", "img/seating/Setting_Language1.svg");
            });
    });
   */
        function CallTimeSetting(a) {

            if (a == true) {
                $("#TimeSettings").html("13:00");
                SettingValues.timeformat = "24";
            }
            else { $("#TimeSettings").html("1:00 PM"); SettingValues.timeformat = "12"; }

        }
        function CallHelpSetting(a) {
            
            if (a == true) {
                SettingValues.Help = "1";
            }
            else {
                SettingValues.Help = "0";
            }
            if (SettingValues.Help == "0") {
                $("#HelpmeEanable").hide();
            }
            else {
                $("#HelpmeEanable").show();
            }
        }
        function callDateSettings(a) {
            
            var dateformatvalue = $("#" + a).attr('value');


            SettingValues.dateFormat1 = dateformatvalue;

            

}

function SelectLevel(a) {

     LevelVar = $("#" + a).attr('value');


    



}
        $('#CurrencyData').on('change', function () {
            SettingValues.BaseCountry = document.getElementById("CurrencyData").value;
            var result = searchinCountry(SettingValues.BaseCountry)
            //alert(JSON.stringify(result));
            SettingValues.CurrencyCode = result[0].currencies0code;
            SettingValues.CurrenyName = result[0].currencies0name;
            
            $("#CurrencyFlag").attr('src', '../lib/Flags100/' + result[0].alpha2Code + '.png');
            $("#CurrencyName").html(result[0].currencies0code + " (" + result[0].currencies0name + ")")
        });
        //function CallCurrency(CurrencyData) {
        //    SettingValues.BaseCountry = document.getElementById("CurrencyData").value;
        //    var result = searchinCountry(SettingValues.BaseCountry)
        //    //alert(JSON.stringify(result));

        //    $("#CurrencyFlag").attr('src', '../lib/Flags100/' + result[0].alpha2Code + '.png');
        //    $("#CurrencyName").html(result[0].currencies0code + " (" + result[0].currencies0name + ")")
           
        //}
        $('#LanguageData').on('change', function () {
            SettingValues.Language = document.getElementById("LanguageData").value;
            var result = searchinCountry(SettingValues.Language)
            //alert(JSON.stringify(result));
            SettingValues.alpha2Code = result[0].alpha2Code;
            $("#LanguageFlag").attr('src', '../lib/Flags100/' + result[0].alpha2Code + '.png');
            $("#LanguageName").html(result[0].alpha3Code + " (" + result[0].languages0name + ")")


});

$("#SelectLevel").val(sessionStorage.getItem("ChartLevel"));

        function SaveSettings(a) {

            //alert("payment");
            $('#loader').show();

            var userid = window.sessionStorage.getItem("UserID");



            //alert(JSON.stringify(SettingValues));
            $('#spandataloading').show();
            $('#iSave').attr('class', 'fa fa-refresh fa-spin');
            var type = "P";

 
            $.ajax({
                type: 'POST',
                url: 'Settings.asmx/SaveSettings',
                dataType: 'json',
                data: JSON.stringify(SettingValues),
                contentType: 'application/json; charset=utf-8',

                success: function (response) {
                   
                     
                   
                    //alert(response.d);

                    $.alert({ title: 'Information', content: "Settings are updated", });

                    $('#spandataloading').hide();

                    $('#loader').hide();

                    //$('#loadI').attr('class', 'fa fa-gear');


                },
                error: function (error) {
                    console.log(error);
                }
            });


          





        }

        var countryobj = [];

        loadCountry();

        function FillLanguage(Control) {
            var newArray = [];
            countryobj.forEach(function (k) {
                //alert(k.Narration);
                var data1 = (k.name).toUpperCase();
                //alert(data1);
                 if (data1.includes("UNITED STATES OF AMERICA".toUpperCase()) == true) {
                var values = {
                    CountryID: k.CountryID, alpha2Code: k.alpha2Code, name: k.alpha3Code + " (" + k.languages0name + ") "

                };
                newArray.push(values)
                };
            });
            FillCountryDropDown(newArray, Control)
            setLanguage(newArray);
        }

        function FillCountry(Control) {
            var newArray = [];
            countryobj.forEach(function (k) {
                //alert(k.Narration);

                var values = {
                    CountryID: k.CountryID, alpha2Code: k.alpha2Code, name: k.name

                };
                newArray.push(values)

            });
            FillCountryDropDown(newArray, Control)
        }

        function FillCurrency(Control) {
            var newArray = [];
            countryobj.forEach(function (k) {
                //alert(k.Narration);

                var values = {
                    CountryID: k.CountryID, alpha2Code: k.alpha2Code, name: k.currencies0name + " (" + k.currencies0code + ")"

                };
                newArray.push(values)

            });

            FillCountryDropDown(newArray, Control)
            setCurrency(newArray);
        }
        function FillCountryDropDown(Mdata, control) {
            var str = "";
            var dt = "";
            var mvalue;
            var optg = "";
            var Ccat
            var data = Mdata;
            for (var i = 0; i < data.length; i++) {



                dt = dt + "<option data-image='../lib/Flags100/" + data[i].alpha2Code + ".png' value=" + data[i].CountryID + ">" + data[i].name + "</option > ";



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
                //console.log(optimage)
                if (!optimage) {
                    return opt.text.toUpperCase();
                } else {
                    var $opt = $(
                        '<span style="font-size:14px;"><img src="' + optimage + '" width="20px" height="15px" /> <c> ' + opt.text.toUpperCase() + '</c></span>'
                    );
                    return $opt;
                }
            };
        }
        function loadCountry() {
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


                    for (var i = 0; i < data.Row.length; i++) {

                        var values = {
                            CountryID: data.Row[i].CountryID
                            , name: data.Row[i].name
                            , alpha2Code: data.Row[i].alpha2Code
                            , alpha3Code: data.Row[i].alpha3Code

                            , topLevelDomain0: data.Row[i].topLevelDomain0
                            , capital: data.Row[i].capital
                            , region: data.Row[i].region
                            , subregion: data.Row[i].subregion
                            , latlng0: data.Row[i].latlng0
                            , latlng1: data.Row[i].latlng1
                            , timezones0: data.Row[i].timezones0
                            , nativename: data.Row[i].nativename
                            , numericCode: data.Row[i].numericCode
                            , currencies0code: data.Row[i].currencies0code
                            , currencies0name: data.Row[i].currencies0name
                            , currencies0symbol: data.Row[i].currencies0symbol
                            , languages0iso639_1: data.Row[i].languages0iso639_1
                            , languages0iso639_2: data.Row[i].languages0iso639_2
                            , languages0name: data.Row[i].languages0name
                            , ForexID: data.Row[i].ForexID
                            , callingCodes0: data.Row[i].callingCodes0

                        }
                        //alert(values.Lid);
                        countryobj.push(values);



                    }
                    // FillCountryDropDown(countryobj, control);
                    // FillCountry("CountryData");
                    //loadUserSettings();
                    FillLanguage("LanguageData");
                    FillCurrency("CurrencyData");







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
        function compareValues(key, order = 'asc') {
            return function (a, b) {
                if (!a.hasOwnProperty(key) ||
                    !b.hasOwnProperty(key)) {
                    return 0;
                }

                const varA = (typeof a[key] === 'string') ?
                    a[key].toUpperCase() : a[key];
                const varB = (typeof b[key] === 'string') ?
                    b[key].toUpperCase() : b[key];

                let comparison = 0;
                if (varA > varB) {
                    comparison = 1;
                } else if (varA < varB) {
                    comparison = -1;
                }
                return (
                    (order == 'desc') ?
                        (comparison * -1) : comparison
                );
            };
        }


        function setLanguage(a) {
            $("#LanguageData").val(SettingValues.Language);
            $("#LanguageData").trigger('change');
            var result = searchinCountry(SettingValues.Language)
            //alert(JSON.stringify(result));
            $("#LanguageFlag").attr('src', '../lib/Flags100/' + result[0].alpha2Code + '.png');
            $("#LanguageName").html(result[0].alpha3Code + " (" + result[0].languages0name + ")")


        }
        setDateTime();
        function setDateTime() {


           // alert(JSON.stringify(SettingValues));
           $("#" + SettingValues.dateFormat1).trigger("click");
            //$("#" + SettingValues.dateFormat1).prop('checked',true)
            //alert((SettingValues.timeformat ))
            //$("input[name=Dateoptions][value=" + SettingValues.dateformat1 + "]").prop('checked', true);
           // $('input[name=Dateoptions]:checked').val(); 
            //alert(SettingValues.timeformat);
            


}
function setLevel() {
    $("#" + sessionStorage.getItem("ChartLevel")).prop('checked', true);
    $("#Level" + sessionStorage.getItem("ChartLevel")).trigger("click");
 
}
setLevel();
setTimeFormat();
function setTimeFormat() {
   // alert($("#timecheck").prop('checked'));
    if (SettingValues.timeformat == "12") {

        //$("#timecheck").attr('checked', '');
        CallTimeSetting(false)

        $("#timecheck").prop('checked', false);
        //$("#timecheck").trigger("click");
    } else {
        CallTimeSetting(true)
        $("#timecheck").prop('checked', true);
       // $("#timecheck").trigger("click");
    }
}
        setHelp();
        function setHelp() {



            

           
            if (SettingValues.Help == "1") {

                //$("#timecheck").attr('checked', '');
                CallHelpSetting(true)
               // $("#HelpAssistant").trigger("click");
                $("#HelpAssistant").prop('checked', true);
            } else {
                CallHelpSetting(false)
                $("#HelpAssistant").prop('checked', false);
                //$("#HelpAssistant").trigger("click");
            }


        }
        function setCurrency(a) {
            $("#CurrencyData").val(SettingValues.BaseCountry);
            $("#CurrencyData").trigger('change');
            var result = searchinCountry(SettingValues.BaseCountry)
            //alert(JSON.stringify(result));

            $("#CurrencyFlag").attr('src', '../lib/Flags100/' + result[0].alpha2Code + '.png');
            $("#CurrencyName").html(result[0].currencies0code + " (" + result[0].currencies0name + ")")
        }
        function searchinCountry(sv) {
            var newArray = [];
            countryobj.forEach(function (k) {
                //alert(k.Narration);
                var data1 = (k.CountryID).toUpperCase();
                if (data1.includes(sv.toUpperCase()) == true) {

                    newArray.push(k)
                };
            });
            return newArray;
        }
