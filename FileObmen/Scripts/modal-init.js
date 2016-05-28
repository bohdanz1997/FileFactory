$(document).ready(function () {
    $('.btn-download').html('<i class="fa fa-edit "></i>');
    $('.btn-edit').html('<i class="fa fa-download "></i>');

    $('[name=del-btn]').click(function (e) {
        var result = confirm("Вы уверены?");
        if (result) {
            $.ajax({
                type: 'POST',
                url: 'http://localhost:51917/File/DelFile',
                data: {
                    sha: this.id
                },
                dataType: 'json',
                success: function (data) {
                    $('tr[class=' + data.Sha + ']').remove();
                }
            });
        }
    });

    $('[name=del-user]').click(function (e) {
        var result = confirm("Вы уверены?");
        if (result) {
            $.ajax({
                type: 'POST',
                url: 'http://localhost:51917/Admin/DelUser',
                data: {
                    id: this.id
                },
                dataType: 'json',
                success: function (data) {
                    $('tr[class=' + data.Id + ']').remove();
                }
            });
        }
    });

    $('[name=demote-user]').click(demote);

    $('[name=promote-user]').click(promote);

    function promote() {
        var result = confirm("Вы уверены?");
        if (result) {
            $.ajax({
                type: 'POST',
                url: 'http://localhost:51917/Admin/PromoteUser',
                data: {
                    id: this.id
                },
                dataType: 'json',
                success: function (data) {
                    $("#" + data.Id + "-options").html(
                            '<button class="btn btn-primary" name="demote-user" id="' + data.Id + '" title="Понизить">' +
                                '<i class="fa fa-arrow-down"></i>' +
                            '</button>'
                            );
                    $('[name=demote-user]').unbind('click').click(demote);
                    $("#" + data.Id + "-role").html(data.Role.Name);
                }
            });
        }
    };

    function demote() {
        var result = confirm("Вы уверены?");
        if (result) {
            $.ajax({
                type: 'POST',
                url: 'http://localhost:51917/Admin/DemoteUser',
                data: {
                    id: this.id
                },
                dataType: 'json',
                success: function (data) {
                    $("#" + data.Id + "-options").html(
                            '<button class="btn btn-primary" name="promote-user" id="' + data.Id + '" title="Повысить">' +
                                '<i class="fa fa-arrow-up"></i>' +
                            '</button>'
                            );
                    $('[name=promote-user]').unbind('click').click(promote);
                    $("#" + data.Id + "-role").html(data.Role.Name);
                }
            });
        }
    };

    $.ajaxSetup({ cache: false });
    $(".compItem").click(function (e) {
        e.preventDefault();
        $.get(this.href, function (data) {
            $('#dialogContent').html(data);
            $('#modDialog').modal('show');
        });
    });
});