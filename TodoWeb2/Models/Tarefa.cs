using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TodoWeb2.Models
{
    public class Tarefa
    {
        public int TarefaId { get; set; }
        public string Texto { get; set; }
        public bool Concluida { get; set; }

        #region chaves estrangeiras
        public int UsuarioId { get; set; }
        public int CategoriaId { get; set; }
        #endregion
    }
}