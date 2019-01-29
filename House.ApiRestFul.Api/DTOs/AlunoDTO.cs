﻿using System.ComponentModel.DataAnnotations;

namespace House.ApiRestFul.Api.DTOs
{
    public class AlunoDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome do Aluno é Obrigatório")]
        [StringLength(maximumLength: 20, MinimumLength = 2, ErrorMessage = "O Nome do aluno deve conter entre 2 e 20 caracteres")]
        public string Nome { get; set; }

        [MaxLength(100, ErrorMessage = "O Endereço deve conter até 100 caracteres")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "A Mensalidade do aluno é obrigatória")]
        [Range(0.01, 9999.99, ErrorMessage = "A Mensalidade deve estar entre R$ 0,01 e R$ 9999,99")]
        public decimal Mensalidade { get; set; }
    }
}