using System;
using System.Collections.Generic;

namespace Solution.API.W.Models;

public partial class Group
{
    public int GroupId { get; set; }

    public string? GroupName { get; set; }

    public string? Description { get; set; }

    public DateTime CreatedDate { get; set; }

    public virtual ICollection<Focus> Foci { get; set; } = new List<Focus>();

    public virtual ICollection<GroupInvitation> GroupInvitations { get; set; } = new List<GroupInvitation>();

    public virtual ICollection<GroupRequest> GroupRequests { get; set; } = new List<GroupRequest>();
}
