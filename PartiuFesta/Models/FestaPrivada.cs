using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartiuFesta.Models {
    public class FestaPrivada : Entity {







        [DisplayName("Convite")]
        [Required(ErrorMessage = "O campo convite para a festa é Obrigatorio")]
        [StringLength(200, ErrorMessage = " O campo prescisa ter entre 1 e 200 caracter", MinimumLength = 1)]
        public string Convite { get; set; }



        [DisplayName("Nome da festa")]
        [Required(ErrorMessage = "O campo Nome da festa é Obrigatorio")]
        [StringLength(200, ErrorMessage = " O campo prescisa ter entre 1 e 200 caracter", MinimumLength = 1)]
        public string Nome_Da_Festa { get; set; }



        [DisplayName("Nome do anfitrião")]
        [Required(ErrorMessage = "O campo Nome do anfitrião é Obrigatorio")]
        [StringLength(200, ErrorMessage = " O campo prescisa ter entre 1 e 200 caracter", MinimumLength = 1)]
        public string Anfitriao { get; set; }



        [DisplayName("Tipo da Festa")]
        public TipoFesta TipoFesta { get; set; }


        [Required(ErrorMessage = "O campo Cidade é Obrigatorio")]
        [StringLength(200, ErrorMessage = " O campo prescisa ter entre 1 e 200 caracter", MinimumLength = 1)]
        public string Cidade { get; set; }



        [Required(ErrorMessage = "O campo Bairro é Obrigatorio")]
        [StringLength(200, ErrorMessage = " O campo prescisa ter entre 1 e 200 caracter", MinimumLength = 1)]
        public string Bairro { get; set; }





        [Required(ErrorMessage = "O campo Rua é Obrigatorio")]
        [StringLength(200, ErrorMessage = " O campo prescisa ter entre 1 e 200 caracter", MinimumLength = 1)]
        public string Rua { get; set; }





        [Required(ErrorMessage = "O campo Numero é Obrigatorio")]
        [StringLength(5, ErrorMessage = " O campo prescisa ter entre 1 e 5 caracter", MinimumLength = 1)]
        public string Numero { get; set; }


        [DisplayName("Data da Festa")]
        public DateTime DataDaFesta { get; set; }

        [DisplayName("Link do Google Mapas")]
        public string Link_Do_Google_Maps { get; set; }


        /*EF RELACAO*/

        public IEnumerable<ParticipantePrivado> ParticipantesPrivados { get; set; }



    }
}
