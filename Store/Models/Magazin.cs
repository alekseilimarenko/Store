using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class Magazin
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int dayofweek { get; set; }

        public DateTime workfrom { get; set; }

        public DateTime workto { get; set; }

        public DateTime intervalfrom { get; set; }

        public DateTime intervalto { get; set; }
    }
}



//$(function() {
//    $('#campId').on("change",
//        function() {
//            //console.log("campid change called");

//            //получение значения аттрибута value элемента seasonInstances
//            var seasonInstanceId = instances.options[instances.selectedIndex].getAttribute('value');

//            var route = '/admin/DocOrder/_PartChangeLapDocPriceItems?campId=' + camp.value + '&seasonInstanceId=' + seasonInstanceId;
//            //console.log(route);

//            $('#priceDocIds').load(route,
//                function( /*response, status, xhr*/) {
//                    $('#priceDocIds').change();
//                });
//        }
//    );
//    //console.log("campid change done");
//});

//$(function() {
//    $('#priceDocIds').on("change",
//        function() {
//            //console.log("doc change called");
//            var priceDocId = $(this).val();
//            $('#priceDocIds').change = reloadPricePosDropDown(priceDocId);
//            //console.log("doc change done");
//        }
//    );
//});

//function reloadPricePosDropDown(docId) {
//    //console.log("reloadPricePosDropDown called docId=" + docId);
//    var route = '/admin/DocOrder/_PartChangeLapDocPricePosItems?docCampSeasonPriceId=' + docId;
//    //console.log(route);
//    $('#docCampSeasonPricePosId').load(route);
//    //console.log("reloadPricePosDropDown done");
//}

//$(document).ready(function () {
//    //console.log("document");

//    $('form').on('submit', function (e) {
//        e.preventDefault();
//        console.log("submit");

//        var pricePosId = $('#docCampSeasonPricePosId').val();
//        var order = document.getElementById('orderId');

//        var route = '/admin/DocOrder/ChangeLapConfirmed?' +
//            '&pricePosId=' + pricePosId +
//            '&id=' + order.value;

//        console.log(route);

//        document.location = route;
//    });
//});
