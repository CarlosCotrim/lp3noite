using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace TodoWeb2.Models
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [Required]//= notnull
        [MaxLength(60)]//tamanho da variavel
        public string Nome { get; set; }

        [Required]
        public string Email{get; set; }

        [Required]
        public string Senha{get; set; }

        public virtual List<Categoria> Categorias { get; set; }//virtual: vai acessar somente em execução

        public virtual List<Tarefa> Tarefas { get; set; }
    }
}