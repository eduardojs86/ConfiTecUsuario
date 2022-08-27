using System;

namespace Confitec.Usuario.ApplicationCore.Domain.Model
{
    public class CreateUsuarioModel
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public int EscolaridadeId{ get; set; }
        public int HistoricoEscolarId { get; set; }
    }
}
