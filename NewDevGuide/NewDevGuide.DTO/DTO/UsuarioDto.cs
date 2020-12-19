using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace NewDevGuide.DTO.DTO
{
    public class UsuarioDto
    {
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Email { get; set; }
        public EnderecoDto Endereco { get; set; }
        public EnderecoDto EnderecoCobranca { get; set; }
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; set; }
    }
}
