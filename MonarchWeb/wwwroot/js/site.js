// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ConfirmDelete(id) {
    $("#comfModal").on("show.bs.modal",
        function () {
            $('#comf-primary').text('Are you sure you want to delete this bug?');
            $('#comf-secondary').text('If you cancel now, your changes will not be saved.');
            $('#comfSubmit').on('click', function () { SubmitDelete(id); });
        }
    );
    $("#comfModal").on("hidden.bs.modal",
        function () {
            if (deleteResult) {
                alert('Delete was successful');
            }
            else {
                alert('Delete failed');
            }
        }
    );
    $("#comfModal").modal('show');
}

var deleteResult = false;
//TODO: Add final confirmation
function SubmitDelete(id) {
    console.log('Id:', id);
    
    $.ajax('/BugService/Delete/' + id,
        { type: 'POST' })
        .done(function (data,status) {
            console.log('result:', data, status)
            if (status == 'success') {
                deleteResult = true;
            }
            else {
                deleteResult = false;
            }
            $("#comfModal").modal('hide');
        })
        .fail(function (jqxhr, status) {
            console.log('fail:', jqxhr, status)
        });
}