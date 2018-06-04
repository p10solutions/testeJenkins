using System;
using System.ComponentModel.DataAnnotations;

namespace Template.MVC.ViewModels
{
    public class TemplateViewModel
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(100, ErrorMessage = "Este campo só permite até 100 caracteres")]
        public string Nome { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Este campo é obrigatório")]
        [MaxLength(200, ErrorMessage = "Este campo só permite até 200 caracteres")]
        public string Descricao { get; set; }

        public DateTime? DataInclusao { get; set; }

        public int? IdUsuario { get; set; }

        public bool Ativo { get; set; }
    }
}
