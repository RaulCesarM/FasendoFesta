using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PartiuFesta.Models {
    public class Participante : Entity {



        [DisplayName("Dono da Festa")]
        public Guid FestaId { get; set; }




        [DisplayName("Nome Completo")]
        [Required(ErrorMessage = "O campo Nome é obrigatorio")]
        [StringLength(200, ErrorMessage =" O campo prescisa ter entre 4 e 200 caracter", MinimumLength =4)]
        public string Nome_Do_Participante { get; set; }


        [DisplayName("Oque vou levar")]
        [Required(ErrorMessage = "O campo Oque Vai Levar é Obrigatorio")]
        [StringLength(300, ErrorMessage = " O campo prescisa ter entre 4 e 200 caracter", MinimumLength = 4)]
        public string OqueVaiLevar { get; set; }


      
        [Required(ErrorMessage = "O campo Idade é Obrigatorio")]
        public int Idade { get; set; }

        
        [DisplayName("Levar Acompanhante")]
        public bool Acompanhante { get; set; }

       
        public string Imagem { get; set; }










        [DisplayName("Corfirmar Presença ?")]
        public bool Confirmado { get; set; }



        public Festa Festa { get; set; }











    }
}
