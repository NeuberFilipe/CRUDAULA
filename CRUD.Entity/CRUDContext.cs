using CRUD.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD
{
    public class CRUDContext : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var mapAluno = modelBuilder.Entity<AlunoModel>();
            mapAluno.HasKey(x => x.idMatric);
            mapAluno.Property(x => x.idMatric)
            .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            mapAluno.Property(x => x.Nome)
             .IsRequired()
             .HasMaxLength(25);
            mapAluno.Property(x => x.SobreNome)
             .IsOptional()
             .HasMaxLength(25);
            mapAluno.ToTable("TBALUNOS");
        }

        public System.Data.Entity.DbSet<CRUD.Model.AlunoModel> AlunoModels { get; set; }
    }
}
