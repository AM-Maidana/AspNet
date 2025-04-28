using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SistemaEscolarApi.Models;

namespace SistemaEscolarApi.DB
{
    public class AppDbContext : DbContext
    {
 
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Disciplina> Disciplinas { get; set; }
        public DbSet<DisciplinaAlunoCurso> DisciplinasAlunosCursos { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DisciplinasAlunosCurso>()
                .HasKey(dc => new {dc.AlunoId, dc.DisciplinaId, dc.CursoId});            

        }
    }
}