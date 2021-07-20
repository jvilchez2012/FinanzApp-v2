$(document).ready(function () {

    var $form = $('#login');

    $form.submit(function (e) {
        e.preventDefault();

        var url = $form.prop('action');
        var data = new FormData(this);

        $.ajax({
            url: url,
            method: 'POST',
            data: data,
            processData: false,
            contentType: false
        }).done(function (respuesta) {
            if (!respuesta.status) {
                $('#alertaMensaje').attr("hidden", false);
                $('#myAlert').text("Usuario o contraseña incorrecta");

                setTimeout(function () {
                    window.location.reload;
                }, 2000);
            } else {
                $('#alertaMensaje').attr("hidden", false);
                $('#myAlert').text("Bienvenido(a)");

                setTimeout(function () {
                    window.location.href = '/Home/Index';
                }, 2000);
            }
        })

    })

}); 