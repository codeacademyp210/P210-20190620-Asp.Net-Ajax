$(document).ready(function () {
    $("[name=CarMarkaID]").change(function () {
        console.log($(this).val());

        if ($(this).val() != "") {
            var xhttp = new XMLHttpRequest();

            xhttp.onreadystatechange = function () {
                if (this.readyState == 4 && this.status == 200) {
                    var res = JSON.parse(this.responseTexts);

                    var options = "";
                    for (var i = 0; i < res.length; i++) {
                        options += "<option value='" + res[i].Id + "'>" +
                            res[i].Name +
                            "</option>";
                    }
                    console.log(options);
                    $("[name=CarModelID]").html(options);
                }
            };

            xhttp.open("GET", "/home/getmodels/" + $(this).val(), true);
            xhttp.send();
        } else {
            $("[name=CarModelID]").html("");
        }




    });



    $("#form-marka").submit(function (e) {
        e.preventDefault();
        $(".loader-container").css({ "display" : "flex" });
        var form = $(this);
        var reqData = form.serialize();
        console.log(reqData);
        $.ajax({
            type: "POST",
            url: "/home/createmarka",
            data: reqData,
            success: function (result) {
                console.log(result);
                $(".loader-container").css({ "display": "none" });
                var liItem = "<li>" + result.marka.Name + "</li>";

                $("#model-list").append(liItem);
            },
            dataType: "json"
        });
        

    });

});