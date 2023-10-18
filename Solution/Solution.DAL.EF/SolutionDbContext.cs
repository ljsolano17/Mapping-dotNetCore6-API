using Microsoft.EntityFrameworkCore;
using Solution.DO.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.DAL.EF
{
    public partial class SolutionDbContext :DbContext
    {

        public SolutionDbContext(DbContextOptions<SolutionDbContext> options): base(options)
        {
        }

        public virtual DbSet<Focus> Foci { get; set; }

        public virtual DbSet<GroupInvitation> GroupInvitations { get; set; }

        public virtual DbSet<GroupRequest> GroupRequests { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            

            modelBuilder.Entity<Focus>(entity =>
            {
                entity.HasKey(e => e.FocusId)
                    .HasName("PK_dbo.Foci");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.FocusName).HasMaxLength(50);

                entity.HasOne(d => d.Group)
                    .WithMany(p => p.Foci)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.Foci_dbo.Groups_GroupId");
            });

           

            modelBuilder.Entity<Group>(entity =>
            {
                entity.HasKey(e => e.GroupId).HasName("PK_dbo.Groups");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            

            

            modelBuilder.Entity<GroupInvitation>(entity =>
            {
                entity.HasKey(e => e.GroupInvitationId).HasName("PK_dbo.GroupInvitations");

                entity.Property(e => e.SentDate).HasColumnType("datetime");

                entity.HasOne(d => d.Group).WithMany(p => p.GroupInvitations)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.GroupInvitations_dbo.Groups_GroupId");
            });

            modelBuilder.Entity<GroupRequest>(entity =>
            {
                entity.HasKey(e => e.GroupRequestId).HasName("PK_dbo.GroupRequests");

                entity.Property(e => e.UserId).HasMaxLength(128);

                entity.HasOne(d => d.Group).WithMany(p => p.GroupRequests)
                    .HasForeignKey(d => d.GroupId)
                    .HasConstraintName("FK_dbo.GroupRequests_dbo.Groups_GroupId");

                /*entity.HasOne(d => d.User).WithMany(p => p.GroupRequests)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_dbo.GroupRequests_dbo.AspNetUsers_UserId");*/
            });

           

            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }


}
