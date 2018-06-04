var View = function () {

    this.TratarRetornoSucesso = function (retorno, urlRedirecionar) {
        if (retorno.sucesso) {
            if (urlRedirecionar)
                alerta.NotificarSucessoERedirecionar(null, retorno.mensagem, urlRedirecionar);
            else
                alerta.NotificarSucesso(null, retorno.mensagem);
        }
        else
            alerta.NotificarErro(null, retorno.mensagem);
    }

    this.TratarRetornoErro = function () {
        alerta.NotificarErro(null, "Ocorreu um erro ao tentar processar a requisição");
    }
}

var view = new View();