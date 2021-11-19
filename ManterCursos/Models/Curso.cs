using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ManterCursos.Models
{
    public class Curso
    {
        [Key]        
        public int CursoId { get; set; }
        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Nome deve conter no mínimo 3 e no máximo 30 caracteres")]
        public string Nome { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Descrição deve conter no mínimo 3 e no máximo 30 caracteres")]
        public string Descricao { get; set; }
        [Required]
        public DateTime dtInicio { get; set; }
        [Required]
        public DateTime dtTermino { get; set; }
        [Required]
        public int QtdAluno { get; set; }
        public int CategoriaId { get; set; }
        [Required]
        public string UsuarioResponsavel { get; set; }
        public DateTime DtCriacao { get; set; }
    }
}
