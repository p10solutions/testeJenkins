using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amil.SisMed.API.ViewModels
{
    public class AgendaViewModel
    {
        public string Agd_Andar { get; set; }
		public DateTime Agd_Data { get; set; }
        public string Agd_Especialidade { get; set; }
        public string Agd_Hora { get; set; }
        public int Agd_Id_Agenda { get; set; }
        public int Agd_Id_Agenda_Origem { get; set; }
        public string Agd_Id_Especialidade { get; set; }
        public string Agd_Medico { get; set; }
        public string Agd_Sala { get; set; }
        public int Agd_Id_Profissional_Solic { get; set; }
        public string Agd_Tipo_Especialidade { get; set; }
        public string Agd_SN_ExameAutorizado { get; set; }
        public string Agd_Profissional_CRM { get; set; }
        public string Agd_Altera_CRM { get; set; }

        public bool Agd_Selecionada { get; set; }
        public bool Agd_Imprime { get; set; }
        public string Agd_Mensagem { get; set; }
        public int Agd_Index { get; set; }
        public string Agd_Data_Hora_Proc { get; set; }
        public int Agd_PreAtiva { get; set; }
    }
}
