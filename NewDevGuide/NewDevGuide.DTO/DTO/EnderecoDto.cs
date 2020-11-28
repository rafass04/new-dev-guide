using System;
using System.Collections.Generic;
using System.Text;

namespace NewDevGuide.DTO.DTO
{
    public class EnderecoDto
    {
        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public int? Numero { get; set; }
        public bool SemNumero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public int CodCidade { get; set; }
        public string Estado { get; set; }
        public string Complemento { get; set; }



    }
}
