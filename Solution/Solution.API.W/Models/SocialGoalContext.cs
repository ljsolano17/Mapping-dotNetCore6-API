using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Solution.API.W.Models;

public partial class SocialGoalContext : DbContext
{
    public SocialGoalContext()
    {
    }

    public SocialGoalContext(DbContextOptions<SocialGoalContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AspNetRole> AspNetRoles { get; set; }

    public virtual DbSet<AspNetUser> AspNetUsers { get; set; }

    public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<CommentUser> CommentUsers { get; set; }

    public virtual DbSet<Focus> Foci { get; set; }

    public virtual DbSet<FollowRequest> FollowRequests { get; set; }

    public virtual DbSet<FollowUser> FollowUsers { get; set; }

    public virtual DbSet<Goal> Goals { get; set; }

    public virtual DbSet<GoalStatus> GoalStatuses { get; set; }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<GroupComment> GroupComments { get; set; }

    public virtual DbSet<GroupCommentUser> GroupCommentUsers { get; set; }

    public virtual DbSet<GroupGoal> GroupGoals { get; set; }

    public virtual DbSet<GroupInvitation> GroupInvitations { get; set; }

    public virtual DbSet<GroupRequest> GroupRequests { get; set; }

    public virtual DbSet<GroupUpdate> GroupUpdates { get; set; }

    public virtual DbSet<GroupUpdateSupport> GroupUpdateSupports { get; set; }

    public virtual DbSet<GroupUpdateUser> GroupUpdateUsers { get; set; }

    public virtual DbSet<GroupUser> GroupUsers { get; set; }

    public virtual DbSet<Metric> Metrics { get; set; }

    public virtual DbSet<MigrationHistory> MigrationHistories { get; set; }

    public virtual DbSet<RegistrationToken> RegistrationTokens { get; set; }

    public virtual DbSet<SecurityToken> SecurityTokens { get; set; }

    public virtual DbSet<Support> Supports { get; set; }

    public virtual DbSet<SupportInvitation> SupportInvitations { get; set; }

    public virtual DbSet<Update> Updates { get; set; }

    public virtual DbSet<UpdateSupport> UpdateSupports { get; set; }

    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=SocialGoal;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AspNetRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetRoles");

            entity.Property(e => e.Id).HasMaxLength(128);
        });

        modelBuilder.Entity<AspNetUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUsers");

            entity.Property(e => e.Id).HasMaxLength(128);
            entity.Property(e => e.DateCreated).HasColumnType("datetime");
            entity.Property(e => e.Discriminator).HasMaxLength(128);
            entity.Property(e => e.LastLoginTime).HasColumnType("datetime");

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "AspNetUserRole",
                    r => r.HasOne<AspNetRole>().WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId"),
                    l => l.HasOne<AspNetUser>().WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId").HasName("PK_dbo.AspNetUserRoles");
                        j.ToTable("AspNetUserRoles");
                        j.IndexerProperty<string>("UserId").HasMaxLength(128);
                        j.IndexerProperty<string>("RoleId").HasMaxLength(128);
                    });
        });

        modelBuilder.Entity<AspNetUserClaim>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_dbo.AspNetUserClaims");

            entity.Property(e => e.UserId)
                .HasMaxLength(128)
                .HasColumnName("User_Id");

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserClaims)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_User_Id");
        });

        modelBuilder.Entity<AspNetUserLogin>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.LoginProvider, e.ProviderKey }).HasName("PK_dbo.AspNetUserLogins");

            entity.Property(e => e.UserId).HasMaxLength(128);
            entity.Property(e => e.LoginProvider).HasMaxLength(128);
            entity.Property(e => e.ProviderKey).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.AspNetUserLogins)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK_dbo.Comments");

            entity.Property(e => e.CommentDate).HasColumnType("datetime");
            entity.Property(e => e.CommentText).HasMaxLength(250);
        });

        modelBuilder.Entity<CommentUser>(entity =>
        {
            entity.HasKey(e => e.CommentUserId).HasName("PK_dbo.CommentUsers");
        });

        modelBuilder.Entity<Focus>(entity =>
        {
            entity.HasKey(e => e.FocusId).HasName("PK_dbo.Foci");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.FocusName).HasMaxLength(50);

            entity.HasOne(d => d.Group).WithMany(p => p.Foci)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK_dbo.Foci_dbo.Groups_GroupId");
        });

        modelBuilder.Entity<FollowRequest>(entity =>
        {
            entity.HasKey(e => e.FollowRequestId).HasName("PK_dbo.FollowRequests");
        });

        modelBuilder.Entity<FollowUser>(entity =>
        {
            entity.HasKey(e => e.FollowUserId).HasName("PK_dbo.FollowUsers");

            entity.Property(e => e.AddedDate).HasColumnType("datetime");
            entity.Property(e => e.ApplicationUserId)
                .HasMaxLength(128)
                .HasColumnName("ApplicationUser_Id");
            entity.Property(e => e.ApplicationUserId1)
                .HasMaxLength(128)
                .HasColumnName("ApplicationUser_Id1");
            entity.Property(e => e.FromUserId).HasMaxLength(128);
            entity.Property(e => e.ToUserId).HasMaxLength(128);

            entity.HasOne(d => d.ApplicationUser).WithMany(p => p.FollowUserApplicationUsers)
                .HasForeignKey(d => d.ApplicationUserId)
                .HasConstraintName("FK_dbo.FollowUsers_dbo.AspNetUsers_ApplicationUser_Id");

            entity.HasOne(d => d.ApplicationUserId1Navigation).WithMany(p => p.FollowUserApplicationUserId1Navigations)
                .HasForeignKey(d => d.ApplicationUserId1)
                .HasConstraintName("FK_dbo.FollowUsers_dbo.AspNetUsers_ApplicationUser_Id1");

            entity.HasOne(d => d.FromUser).WithMany(p => p.FollowUserFromUsers)
                .HasForeignKey(d => d.FromUserId)
                .HasConstraintName("FK_dbo.FollowUsers_dbo.AspNetUsers_FromUserId");

            entity.HasOne(d => d.ToUser).WithMany(p => p.FollowUserToUsers)
                .HasForeignKey(d => d.ToUserId)
                .HasConstraintName("FK_dbo.FollowUsers_dbo.AspNetUsers_ToUserId");
        });

        modelBuilder.Entity<Goal>(entity =>
        {
            entity.HasKey(e => e.GoalId).HasName("PK_dbo.Goals");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.GoalName).HasMaxLength(55);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasMaxLength(128);

            entity.HasOne(d => d.User).WithMany(p => p.Goals)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.Goals_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<GoalStatus>(entity =>
        {
            entity.HasKey(e => e.GoalStatusId).HasName("PK_dbo.GoalStatus");

            entity.ToTable("GoalStatus");

            entity.Property(e => e.GoalStatusType).HasMaxLength(50);
        });

        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK_dbo.Groups");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.GroupName).HasMaxLength(50);
        });

        modelBuilder.Entity<GroupComment>(entity =>
        {
            entity.HasKey(e => e.GroupCommentId).HasName("PK_dbo.GroupComments");

            entity.Property(e => e.CommentDate).HasColumnType("datetime");

            entity.HasOne(d => d.GroupUpdate).WithMany(p => p.GroupComments)
                .HasForeignKey(d => d.GroupUpdateId)
                .HasConstraintName("FK_dbo.GroupComments_dbo.GroupUpdates_GroupUpdateId");
        });

        modelBuilder.Entity<GroupCommentUser>(entity =>
        {
            entity.HasKey(e => e.GroupCommentUserId).HasName("PK_dbo.GroupCommentUsers");
        });

        modelBuilder.Entity<GroupGoal>(entity =>
        {
            entity.HasKey(e => e.GroupGoalId).HasName("PK_dbo.GroupGoals");

            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(100);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.GoalName).HasMaxLength(50);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
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

            entity.HasOne(d => d.User).WithMany(p => p.GroupRequests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_dbo.GroupRequests_dbo.AspNetUsers_UserId");
        });

        modelBuilder.Entity<GroupUpdate>(entity =>
        {
            entity.HasKey(e => e.GroupUpdateId).HasName("PK_dbo.GroupUpdates");

            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<GroupUpdateSupport>(entity =>
        {
            entity.HasKey(e => e.GroupUpdateSupportId).HasName("PK_dbo.GroupUpdateSupports");

            entity.Property(e => e.UpdateSupportedDate).HasColumnType("datetime");

            entity.HasOne(d => d.GroupUpdate).WithMany(p => p.GroupUpdateSupports)
                .HasForeignKey(d => d.GroupUpdateId)
                .HasConstraintName("FK_dbo.GroupUpdateSupports_dbo.GroupUpdates_GroupUpdateId");
        });

        modelBuilder.Entity<GroupUpdateUser>(entity =>
        {
            entity.HasKey(e => e.GroupUpdateUserId).HasName("PK_dbo.GroupUpdateUsers");
        });

        modelBuilder.Entity<GroupUser>(entity =>
        {
            entity.HasKey(e => e.GroupUserId).HasName("PK_dbo.GroupUsers");

            entity.Property(e => e.AddedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Metric>(entity =>
        {
            entity.HasKey(e => e.MetricId).HasName("PK_dbo.Metrics");
        });

        modelBuilder.Entity<MigrationHistory>(entity =>
        {
            entity.HasKey(e => new { e.MigrationId, e.ContextKey }).HasName("PK_dbo.__MigrationHistory");

            entity.ToTable("__MigrationHistory");

            entity.Property(e => e.MigrationId).HasMaxLength(150);
            entity.Property(e => e.ContextKey).HasMaxLength(300);
            entity.Property(e => e.ProductVersion).HasMaxLength(32);
        });

        modelBuilder.Entity<RegistrationToken>(entity =>
        {
            entity.HasKey(e => e.RegistrationTokenId).HasName("PK_dbo.RegistrationTokens");

            entity.Property(e => e.Role).HasMaxLength(50);
        });

        modelBuilder.Entity<SecurityToken>(entity =>
        {
            entity.HasKey(e => e.SecurityTokenId).HasName("PK_dbo.SecurityTokens");

            entity.Property(e => e.ActualId).HasColumnName("ActualID");
        });

        modelBuilder.Entity<Support>(entity =>
        {
            entity.HasKey(e => e.SupportId).HasName("PK_dbo.Supports");

            entity.Property(e => e.SupportedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<SupportInvitation>(entity =>
        {
            entity.HasKey(e => e.SupportInvitationId).HasName("PK_dbo.SupportInvitations");

            entity.Property(e => e.SentDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Update>(entity =>
        {
            entity.HasKey(e => e.UpdateId).HasName("PK_dbo.Updates");

            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<UpdateSupport>(entity =>
        {
            entity.HasKey(e => e.UpdateSupportId).HasName("PK_dbo.UpdateSupports");

            entity.Property(e => e.UpdateSupportedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<UserProfile>(entity =>
        {
            entity.HasKey(e => e.UserProfileId).HasName("PK_dbo.UserProfiles");

            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(50);
            entity.Property(e => e.DateEdited).HasColumnType("datetime");
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.State).HasMaxLength(50);
            entity.Property(e => e.UserId).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    //Declaracion del metodo para poder inicializar las variables
    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
