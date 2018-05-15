function jqueryAjaxPost(form)
{

    $.validator.unobtrusive.parse(form);
    if ($(form).valid())
    {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            contentType: false,
            processData: false,
            success: function (response) {

                $("#firsttab").html(response);
                refreshAddnewtab($(form).attr('data-reseturl'), true);
                $.notify(response.message, "success");

            },

            error: function (request,error) {
                $.notify(response.message, "error");

            }
        };
      
        $.ajax(ajaxConfig);
    }
    return false;
}
function refreshAddnewtab(reseturl, showviewtab) {
    $.ajax({

        type: 'GET',
        url: reseturl,
        success: function (response) {
            $("#secondtab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Add New');
            if (showviewtab)
            {
                $('ul.nav.nav-tabs a:eq(0)').tab('show');
            }
        }

    });


}
function Edit(url)
{
    $.ajax({

        type: 'GET',
        url: url,
        success: function (response) {
            $("#secondtab").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Edit');
            
                $('ul.nav.nav-tabs a:eq(1)').tab('show');
            
        }

    });

}
function Delete(url)
{
    if (confirm('Are you sure to delete track') == true)
    {
        $.ajax({

            type: 'POST',
            url: url,
            success: function (response) {
                if (response.success) {
                    $('#firsttab').html(response.html);
                    $.notify(response.message, "warn");

                }
                else {
                    $.notify(response.message, "error");
                }
            }

        });

    }


}