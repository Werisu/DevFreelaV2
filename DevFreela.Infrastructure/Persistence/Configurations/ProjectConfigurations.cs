using DevFreela.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Configurations
{
    public class ProjectConfigurations : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            // definir as chaves primárias
            // definir as chaves estrangeiras
            builder
                .HasKey(p => p.Id);

            builder
                .HasOne(p => p.Freelancer) // um project tem um freelancer
                .WithMany(f => f.FreelanceProjects) // um freelancer tem vários projects
                .HasForeignKey(p => p.IdFreelancer) // chave estrangéira
                .OnDelete(DeleteBehavior.Restrict); // comportamento de delete

            builder
                .HasOne(p => p.Client)
                .WithMany(f => f.OwnedProjects)
                .HasForeignKey(p => p.IdClient)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
