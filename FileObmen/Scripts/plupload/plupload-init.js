$(function () {
    var updateData;
    $("#uploader").plupload({
        runtimes: "html5,flash,silverlight,html4",
        url: "http://localhost:51917/File/Upload",
        max_file_count: 10,
        resize: {
            width: 200,
            height: 200,
            quality: 90,
            crop: true
        },
        filters: {
            max_file_size: "2000mb"
        },
        dragdrop: true,
        views: {
            list: true,
            thumbs: true,
            active: "thumbs"
        },
        flash_swf_url: "~/Scripts/plupload/jquery.ui.plupload/Moxie.swf",
        silverlight_xap_url: "~/Scripts/plupload/jquery.ui.plupload/Moxie.xap",
        
        init: {
            BeforeUpload: function(up, file) {
                $("#fileLinks-block").removeClass("no-display");
                $("#complete").addClass("no-display");
            },

            FilesAdded: function (up) {
                $("#fileLinks-block").addClass("no-display");
                updateData(up);
            },

            FilesRemoved: function(up) {
                updateData(up);
            },

            UploadComplete: function (up, files) {
                $("#uploader").addClass("no-display");
                $("#complete").removeClass("no-display");
                $("#upload-more").removeClass("no-display");
                up.splice();
                up.refresh();
            }
        }
    });

    updateData = function (up) {
        var i;
        var text = "<input type='hidden' id='length' value='" + up.files.length + "'>";
        for (i = 0; i < up.files.length; i++) {
            text += "<input type='hidden' id='file" + i + "' value='" + up.files[i].name + "'>";
        }
        $("#fileNames").html(text);

        $.ajax({
            type: "POST",
            url: "http://localhost:51917/File/GetFileLink",
            data: {
                fileNames: function () {
                    var length = $("#length").val();
                    var data = [];
                    for (var j = 0; j < length; j++) {
                        data[j] = $("#file" + j).val();
                    }
                    return data;
                }
            },
            dataType: "json",
            success: function (data) {
                if (data == null) return;
                var html = "";
                var guidData = "";
                for (i = 0; i < data.length; i++) {
                    guidData += data[i].Name + "*" + data[i].Guid + ",";
                    html +=
                        "<div class='filelink-wrap'>" +
                        "<span class='filelink'>" +
                        "<a class ='download-link' target='_blank' id='fileLink" + i + "' " +
                        "href='http://" + data[i].Url + "/Files/" + data[i].Guid + "' title='" +
                        data[i].Name + "'>" + data[i].Url + "/Files/" + data[i].Guid +
                        "</a>" +
                        "</span>" +
                        "</div>" +
                        "<div>" +
                        "<div class='btn-group action-btns'>" +
                        "<button class = 'btn btn-default' data-clipboard-target = '#fileLink" + i + "' id ='copy-button'>Скопировать ссылку</button>" +
                        "<a class='btn btn-default compItem' target='_blank' href='http://" + data[i].Url + "/Share/" + data[i].Guid + "'>" +
                        "Поделится" +
                        "</a>" +
                        "</div>" +
                        "</div>";
                }
                $("#fileLinks").html(html);
                $("#guidData").val(guidData);
                up.settings.multipart_params =
                {
                    "guidData": $("#guidData").val()
                };
            }
        });
    };
    $("#upload-more").click(function () {
        $("#uploader").removeClass("no-display");
        $("#fileLinks-block").addClass("no-display");
        $(this).addClass("no-display");
    });

    // Handle the case when form was submitted before uploading has finished
    $("#form").submit(function (e) {
        // Files in queue upload them first
        if ($("#uploader").plupload("getFiles").length > 0) {

            // When all files are uploaded submit form
            $("#uploader").on("complete", function () {
                $("#form")[0].submit();
            });

            $("#uploader").plupload("start");
        } else {
            alert("You must have at least one file in the queue.");
        }
        return false; // Keep the form from submitting
    });
});