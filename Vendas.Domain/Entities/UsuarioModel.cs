﻿namespace Vendas.Domain.Entities
{
    public class UsuarioModel
    {
        public int IdUsuario { get; set; }
        public string NomeUsuario { get; set; }
        public string Senha { get; set; }
        public int EhAdm {  get; set; }
        public string Login {  get; set; }
    }
}
