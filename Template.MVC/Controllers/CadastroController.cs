using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Template.Framework;
using Template.Framework.Api;
using Template.MVC.Configuracoes;
using Template.MVC.ViewModels;

namespace Template.MVC.Controllers
{
    public class CadastroController : Base.BaseController
    {
        GatewayRestAPI<TemplateViewModel> gatewayAPI;
        AppConfiguracoes _appConfiguracoes;
        IMapper _mapper;

        public CadastroController(AppConfiguracoes appConfiguracoes, IMapper mapper)
        {
            _appConfiguracoes = appConfiguracoes;
            gatewayAPI = new GatewayRestAPI<TemplateViewModel>(appConfiguracoes.ApiTemplate, appConfiguracoes.PathCadastro);
            _mapper = mapper;
        }

        public IActionResult Teste()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> CarregarDataTableTemplate(Paginacao paginacao)
        {
            paginacao.MapeiaRequisicaoDataTable(Request);

            try
            {
                var retornoTemplates = await GatewayAPI.Post<TemplatePaginadoViewModel>(gatewayAPI.Url, $"{gatewayAPI.Path}/Templates", paginacao);

                return Ok(DataTablesResponse.Reposta(retornoTemplates.Paginacao, retornoTemplates.Templates));
            }
            catch(Exception ex)
            {
                return StatusCode(500, RetornoViewModel.RetornoViewModelFactory.Erro("Ocorreu um erro ao tentar Carregar os dados"));
            }
        }

        [HttpGet]
        public IActionResult Inclusao()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Inclusao(TemplateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return Ok(RetornoViewModel.RetornoViewModelFactory.Erro(ObterErroModel(ModelState, viewModel)));

            try
            {
                var retorno = gatewayAPI.Post(viewModel);

                return Ok(new RetornoViewModel { mensagem = "Template incluído com sucesso", sucesso = true });
            }
            catch (Exception ex)
            {
                return StatusCode(500, RetornoViewModel.RetornoViewModelFactory.Erro("Ocorreu um erro ao tentar incluir o template"));
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edicao(int id)
        {
            var templateViewModel = await gatewayAPI.Get(id.ToString());

            return View(templateViewModel);
        }

        [HttpPost]
        public IActionResult Edicao(TemplateViewModel viewModel)
        {
            if (!ModelState.IsValid)
                return Ok(RetornoViewModel.RetornoViewModelFactory.Erro(ObterErroModel(ModelState, viewModel)));

            try
            {
                var retorno = gatewayAPI.Put(viewModel, viewModel.Id.ToString());

                return Ok(RetornoViewModel.RetornoViewModelFactory.Sucesso("Template alterado com sucesso"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, RetornoViewModel.RetornoViewModelFactory.Erro("Ocorreu um erro ao tentar Alterar o template"));
            }
        }

        [HttpPost]
        public IActionResult Remocao(string id)
        {
            if (string.IsNullOrEmpty(id))
                return Ok(RetornoViewModel.RetornoViewModelFactory.Erro("Por favor forneça o valor do Id"));

            try
            {
                var retorno = gatewayAPI.Delete(id);

                return Ok(RetornoViewModel.RetornoViewModelFactory.Sucesso("Template removido com sucesso"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, RetornoViewModel.RetornoViewModelFactory.Erro("Ocorreu um erro ao tentar remover o template"));
            }
        }
    }
}