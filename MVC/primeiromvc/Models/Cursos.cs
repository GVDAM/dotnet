using System;
using System.Collections.Generic;

namespace primeiromvc.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            Alunos = new HashSet<Alunos>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }

        public virtual ICollection<Alunos> Alunos { get; set; }
    }
}
