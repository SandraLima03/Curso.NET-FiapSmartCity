﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FiapSmartCity.Models
{
    public class Pessoa
    {
        public int IdPessoa { get; set; }

        [Required(ErrorMessage = "Campo Nome obrigatório!")]
        [StringLength(50, ErrorMessage = "A descrição deve ter, no máximo, 50 caracteres")]
        [Display(Name = "Nome:")]
        public String NomePessoa { get; set; }

        [Required(ErrorMessage = "Campo Endereço obrigatório!")]
        [StringLength(50, ErrorMessage = "A descrição deve ter, no máximo, 50 caracteres")]
        [Display(Name = "Endereço:")]
        public String EnderecoPessoa { get; set; }
    }
}
