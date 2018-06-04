var route;

route = {
    DiretorioVirtual: "",
    ControllerAtual: "",
    AreaAtual: ""
};

route.TrataDiretorioVirtual = function () {

    this.DiretorioVirtual = this.DiretorioVirtual === "/" ?
                                this.DiretorioVirtual :
                                "/" + this.DiretorioVirtual + "/";

    this.DiretorioVirtual = this.DiretorioVirtual.replace("//", "/");

}

route.TrataControllerAtual = function () {

    this.ControllerAtual = this.ControllerAtual
                                    .replace("/", "")
                                    .replace("/", "");

}

route.TrataAreaAtual = function () {

    this.AreaAtual = this.AreaAtual.trim() ?
                     this.AreaAtual + "/" : "";
}

route.TrataParametrosNavegacao = function () {
    this.TrataControllerAtual();
    this.TrataAreaAtual();
    this.TrataDiretorioVirtual();
}

route.PegaDadosNavegacaoAtual = function () {
    this.DiretorioVirtual = $("#routes-diretorio-virtual").val();
    this.ControllerAtual = $("#routes-controller").val();
    this.AreaAtual = $("#routes-area").val();
}

route.ObterUrl = function (actionName, controllerName, param, area) {
    var url = "{controller}/{action}/{param}"; 
    
    area = area ? area + "/" : area;

    url = this.DiretorioVirtual + (area != undefined && area != null ? area+url : this.AreaAtual + url);
    //adiciona a action na url
    url = url.replace("{action}", actionName);
    //adiciona o controller na url
    url = controllerName ? url.replace("{controller}", controllerName) : url.replace("{controller}", this.ControllerAtual);
    //adiciona o parameter na url
    url = param ? url.replace("{param}", param) : url.replace("{param}", "");

    return url;
}

route.GeraUrlAbsoluta = function (urlAplicacao) {
    var url = this.DiretorioVirtual + urlAplicacao;

    if (url[0] != "/")
        url = "/" + url;

    return url;
}

$(function () {
  route.PegaDadosNavegacaoAtual();
  route.TrataParametrosNavegacao();
});
