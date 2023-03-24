using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TarefasBackEnd.Models
{
    public class Tarefa
    {
        public Guid Id { get; set; }

        public Guid UsuarioId { get; set; }
        [Required]
        public string Nome { get; set; }

        public bool Concluida { get; set; }

    }
}