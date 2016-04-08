using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TesteAxado.Web.ViewModels
{
    public class CarrierViewModel
    {
        [Key]
        public long Id { get; set; }

        [DisplayName("Nome")]
        [Required(ErrorMessage = "Preencha o campo nome")]
        [MaxLength(150, ErrorMessage = "Máximo {1} caracteres")]
        [MinLength(2, ErrorMessage = "Mínimo {1} caracteres")]
        public string Name { get; set; }

        public virtual IEnumerable<RatingViewModel> Ratings { get; set; }
    }
}