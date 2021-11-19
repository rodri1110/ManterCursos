using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ManterCursos.Models
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        public string UsuarioResponsavel { get; set; }
        public DateTime DtCriacao { get; set; }
        public DateTime DtUltModificacao { get; set; }
        public int CursoId { get; set; }
    }
}
