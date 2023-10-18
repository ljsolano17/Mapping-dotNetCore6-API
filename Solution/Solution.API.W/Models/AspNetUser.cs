using System;
using System.Collections.Generic;

namespace Solution.API.W.Models;

public partial class AspNetUser
{
    public string Id { get; set; } = null!;

    public string? UserName { get; set; }

    public string? PasswordHash { get; set; }

    public string? SecurityStamp { get; set; }

    public string? Email { get; set; }

    public string? FirstName { get; set; }

    public string? LastName { get; set; }

    public string? ProfilePicUrl { get; set; }

    public DateTime? DateCreated { get; set; }

    public DateTime? LastLoginTime { get; set; }

    public bool? Activated { get; set; }

    public int? RoleId { get; set; }

    public string Discriminator { get; set; } = null!;

    public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; } = new List<AspNetUserClaim>();

    public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; } = new List<AspNetUserLogin>();

    public virtual ICollection<FollowUser> FollowUserApplicationUserId1Navigations { get; set; } = new List<FollowUser>();

    public virtual ICollection<FollowUser> FollowUserApplicationUsers { get; set; } = new List<FollowUser>();

    public virtual ICollection<FollowUser> FollowUserFromUsers { get; set; } = new List<FollowUser>();

    public virtual ICollection<FollowUser> FollowUserToUsers { get; set; } = new List<FollowUser>();

    public virtual ICollection<Goal> Goals { get; set; } = new List<Goal>();

    public virtual ICollection<GroupRequest> GroupRequests { get; set; } = new List<GroupRequest>();

    public virtual ICollection<AspNetRole> Roles { get; set; } = new List<AspNetRole>();
}
