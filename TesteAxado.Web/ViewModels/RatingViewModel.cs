using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TesteAxado.Web.ViewModels
{
    public class RatingViewModel
    {
        [Key]
        public long Id { get; set; }

        [DisplayName("Avaliação")]
        [Range(1, 5, ErrorMessage = "Aceita apenas valores de {1} a {2}")]
        [Required(ErrorMessage = "Preencha o campo valor")]
        public int Rate { get; set; }

        [DisplayName("Comentário")]
        public string Comment { get; set; }
        
        [ScaffoldColumn(false)]
        public long UserId { get; set; }
        public virtual UserViewModel User { get; set; }

        [ScaffoldColumn(false)]
        public long CarrierId { get; set; }
        public virtual CarrierViewModel Carrier { get; set; }
    }
}