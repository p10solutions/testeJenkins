using System;
using System.Collections.Generic;

namespace Amil.SisMed.API.ViewModels
{
    public class AtendimentoViewModel
    {
        public SubSubObject ListaAgendas { get; set; }
        public string Agd_Andar { get; set; }
        public DateTime Agd_Data { get; set; }
        public string Agd_Especialidade { get; set; }
        public string Agd_Hora { get; set; }
        public int Agd_Id_Agenda { get; set; }
        public string Agd_Id_Especialidade { get; set; }
        public string Agd_Medico { get; set; }
        public int Agd_Qtde { get; set; }
        public string Agd_Sala { get; set; }
        public int Agd_Id_Profissional_Solic { get; set; }
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public string EhCarteirinhaNova { get; set; }
        public int Id_Pessoa_Operadora { get; set; }
		public int Id_Produto_Operadora { get; set; }
		public int Id_Segmento { get; set; }
		public bool Medico_Indisponivel { get; set; }
		public string Mensagem { get; set; }
		public string Nome { get; set; }
		public string PossuiCarencia { get; set; }
		public string Produto_Franqueado { get; set; }
		public string Resumo { get; set; }
		public string Sexo { get; set; }
		public string SistemaOrigem { get; set; }
		public string Tipo_Especialidade { get; set; }
		public string WsIndisponivel { get; set; }
		public string TipoAtend { get; set; }
		public int Idade { get; set; }
        public bool Preferencial { get; set; }
        public int Id_Pessoa { get; set; }
		public string Operadora { get; set; }
		
		public bool fl_next { get; set; }
		public bool fl_habilitado_portal { get; set; }
		public bool fl_autorizado_atendimento { get; set; }
		
		public int id_evento_next { get; set; }
		public string senha_autorizacao_next { get; set; }
		public bool obriga_responsavel { get; set; }

    }
}
