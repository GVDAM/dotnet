using System;
using System.Collections.Generic;

namespace primeiromvc.Models
{
    public partial class Alunos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Turma { get; set; }
        public int? FkCurso { get; set; }

        public virtual Cursos FkCursoNavigation { get; set; }
    }
}
