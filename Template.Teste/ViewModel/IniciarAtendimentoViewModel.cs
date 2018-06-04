using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Amil.SisMed.API.ViewModels
{
    public class IniciarAtendimentoViewModel
    {
        [Required(ErrorMessage = "O campo hash é obrigatório")]
        public string Hash { get; set; }

        [Required(ErrorMessage = "O campo carteirinha é obrigatório")]
        public string Carteirinha { get; set; }

        [Required(ErrorMessage = "O campo centroMedico é obrigatório")]
        public string CM { get; set; }

        [Required(ErrorMessage = "O campo idLocal é obrigatório")]
        public int Id_Local { get; set; }

        [Required(ErrorMessage = "O campo idOperadora é obrigatório")]
        public string Id_Operadora { get; set; }
    }
}
