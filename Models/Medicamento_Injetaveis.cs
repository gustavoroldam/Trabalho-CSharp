﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Trabalho.Models
{
    [Table("Medicamentos")]
    public class Medicamento_Injetaveis
    {
        [Key]
        public int codigo { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Campo 'Nome' é obrigatório.")]
        [StringLength(35)]
        public string nome { get; set; }

        [Display(Name = "Unidade")]
        [Required(ErrorMessage = "Campo 'Unidade' é obrigatório.")]
        [StringLength(5)]
        public string unidade { get; set; }

        [Display(Name = "Quantidade de Estoque")]
        [Required(ErrorMessage = "Campo 'Quantidade de Estoque' é obrigatório.")]
        public int Qtde_Estoque { get; set; }
    }
}
