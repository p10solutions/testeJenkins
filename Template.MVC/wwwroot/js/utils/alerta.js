var Alerta = function () {
    var $alerta = $("#alerta_template");

    this.NotificarErro = function (titulo, msg) {

        titulo = titulo || "Erro:";

        notificar(titulo, msg);

        $alerta.addClass("alert-danger");
    };

    this.NotificarSucesso = function (titulo, msg, temporario) {

        titulo = titulo || "Sucesso:";

        notificar(titulo, msg, temporario);

        $alerta.addClass("alert-success");

    };

    this.NotificarSucessoTemporario = function (titulo, msg) {
        this.NotificarSucesso(titulo, msg, true);
    }

    this.NotificarSucessoERedirecionar = function (titulo, msg, url) {

        this.NotificarSucesso(titulo, msg);

        setTimeout(function () {
            window.location.href = url;
        }, 3000);
    }

    this.NotificarAviso = function (titulo, msg) {

        titulo = titulo || "Aviso:";

        notificar(titulo, msg);

        $alerta.addClass("alert-warning");
    };

    var notificar = function (titulo, msg, temporario) {

        $alerta.attr("class", "alert alert-dismissible fade show");

        $alerta.find("strong.alerta_titulo").text(titulo);

        $alerta.find("span.alerta_corpo").text(msg);

        $alerta.show();

        $alerta.alert();

        if (temporario)
            $alerta.fadeOut(3000)
    }
}

var alerta = new Alerta();