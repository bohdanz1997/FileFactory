$(function () {
    var uploadObject = {
        uploadMore: $("#uploadMore"),
        cancelUpload: $("#cancelUpload"),
        pluploadBtns: $("#pluploadBtns"),
        dropContainer: $("#dropContainer"),
        fileList: $("#fileList"),
        progressBarContainer: $("#progressBarContainer"),
        fileLinksBlock: $("#fileLinksBlock")
    };

    var uploader = new plupload.Uploader({
        runtimes: "html5,flash,silverlight,html4",
        browse_button: "pickfiles", // you can pass an id...
        container: document.getElementById("container"), // ... or DOM Element itself
        url: "http://localhost:51917/File/Upload",
        flash_swf_url: "~/Scripts/plupload/jquery.ui.plupload/Moxie.swf",
        silverlight_xap_url: "~/Scripts/plupload/jquery.ui.plupload/Moxie.xap",
        dragdrop: true,
        drop_element: "dropContainer",
        max_file_count: 10,
        urlstream_upload: true,

        filters: {
            max_file_size: "2000mb"
        },

        init: {
            PostInit: function() {
                uploadObject.fileList.html("");

                document.getElementById("uploadfiles").onclick = function() {
                    uploader.start();
                    return false;
                };
            },

            FilesAdded: function (up, files) {
                uploadObject.fileLinksBlock.addClass("no-display");
                addFilesThumbs(files);
                updateData(up);

                uploadObject.dropContainer.removeClass("hover");

                var deleteHandle = function (uploaderObject, fileObject) {
                    return function (event) {
                        event.preventDefault();
                        uploaderObject.removeFile(fileObject);
                        $("#" + fileObject.id).fadeOut(300, function () {
                            $(this).remove();
                        });
                    };
                };

                for (var i in files) {
                    $("#deleteFile" + files[i].id).click(deleteHandle(up, files[i]));
                }
            },

            FilesRemoved: function (up, files) {
                updateData(up);
            },

            QueueChanged: function (up) {
                var files = up.files;
                if (files.length === 0) {
                    $(".upload-title").html("Файлы не выбраны");
                    return;
                }
                var totalSize = 0;
                for (var i = 0; i < files.length; i++) {
                    totalSize += files[i].size;
                }
                $(".upload-title")
                    .html("Выбрано " + files.length + " файлов размером " + plupload.formatSize(totalSize));

                $(".files-notify").addClass("no-display");
            },

            BeforeUpload: function(up, file) {
                $(".upload-title").html("Идет загрузка");
                uploadObject.fileLinksBlock.removeClass("no-display");
                uploadObject.progressBarContainer.removeClass("no-display");
                uploadObject.cancelUpload.removeClass("no-display");
                uploadObject.pluploadBtns.addClass("no-display");
                uploadObject.dropContainer.addClass("no-display");
            },

            UploadProgress: function(up, file) {
                var filesCount = up.files.length;
                var speed = up.total.bytesPerSec;
                var bytelefttoupload = up.total.size - up.total.loaded;
                var eta = secondeenminute(Math.round(bytelefttoupload / speed));
                var loaded = plupload.formatSize(uploader.total.loaded);
                var totalSize = plupload.formatSize(uploader.total.size);

                $("#uploadInfo").html("Загружено " + up.total.percent + "% ( " + loaded + " из " + totalSize + " ) " + eta + " до конца");
                $("#uploadFileName").html("Загружается " + file.name + " ( " + (up.total.uploaded) + " из " + filesCount + " )");
                $("#progresss-file").css("width", up.total.percent + "%");
            },

            FileUploaded: function(up, file) {
                $("#progresss-queue").css("width", (up.total.uploaded) * (100 / up.files.length) + "%");
            },

            UploadComplete: function (up, files) {
                resetUploader();
                $(".upload-title").html("Загрузка завершена");
            }
        }
    });

    uploader.init();

    function secondeenminute(sec) {
        if ((sec / 60) < 1) {
            return sec + " сек.";
        } else if ((sec / 60) > 1 && (sec / 3600) < 1) {
            var min = sec / 60;
            sec = sec % 60;
            return Math.floor(min) + " мин. " + Math.floor(sec) + " сек.";
        } else {
            var hou = sec / 3600;
            var rmin = sec % 3600;
            var min = rmin / 60;
            sec = rmin % 60;
            return Math.floor(hou) + " год. " + Math.floor(min) + " мин. " + Math.floor(sec) + " сек.";
        }
    };

    function updateData(up) {
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

    function resetUploader() {
        $("#uploader").addClass("no-display");
        $(".files-notify").removeClass("no-display");
        uploadObject.uploadMore.removeClass("no-display");
        uploadObject.progressBarContainer.addClass("no-display");
        uploadObject.cancelUpload.addClass("no-display");
        uploadObject.fileList.empty();

        $("#progresss-file").css("width", 0);
        $("#progresss-queue").css("width", 0);

        uploader.stop();
        uploader.splice();
        uploader.refresh();
    };

    function addFilesThumbs(files) {
        plupload.each(files, function (file) {
            document.getElementById("fileList").innerHTML +=
                '<li class="plupload_file ui-state-default plupload_delete" id="' + file.id + '">' +
                    '<div class="plupload_file_thumb" style="width:128px;height:96px;">' +
                        '<div class="plupload_file_dummy ui-widget-content" style="line-height:96px;">' +
                            '<span class="ui-state-disabled">' + file.name.split(".").pop() + "</span>" +
                        "</div>" +
                    "</div>" +
                    '<div class="plupload_file_action">' +
                        '<div id="deleteFile' + file.id +
                        '" class="plupload_action_icon ui-icon ui-icon-circle-minus plupload_delete_icon">' + "</div>" +
                    "</div>" +
                    '<div class="plupload_file_name" title="' + file.name + '">' + file.name + "</div>" +
                    '<div class="plupload_file_size">' + plupload.formatSize(file.size) + "</div>" +
                "</li>";
        });
    };

    uploadObject.uploadMore.click(function () {
        $("#uploader").removeClass("no-display");
        uploadObject.pluploadBtns.removeClass("no-display");
        uploadObject.dropContainer.removeClass("no-display");
        uploadObject.fileLinksBlock.addClass("no-display");
        $(this).addClass("no-display");
    });

    uploadObject.cancelUpload.click(function () {
        if (confirm("Вы уверены что хотите остановить загрузку?")) {
            resetUploader();
            uploadObject.uploadMore.click();
        }
        return false;
    });

    $("#dropContainer").bind({
        dragover: function() {
            $(this).addClass("hover");
        },
        dragleave: function() {
            $(this).removeClass("hover");
        }
    });
});