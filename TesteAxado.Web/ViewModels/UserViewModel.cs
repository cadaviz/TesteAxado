using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TesteAxado.Web.ViewModels
{
    public class UserViewModel
    {
        [Key]
        public long Id { get; set; }

        [DisplayName("Nome de usuário")]
        [Required(ErrorMessage = "Preencha o campo nome de usuário")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(6, ErrorMessage = "Mínimo {1} caracteres")]
        public string UserName { get; set; }

        [DisplayName("Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Preencha o campo senha")]
        [MaxLength(50, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(6, ErrorMessage = "Mínimo {1} caracteres")]
        public string Password { get; set; }

        public virtual IEnumerable<RatingViewModel> Ratings { get; set; }
    }
}