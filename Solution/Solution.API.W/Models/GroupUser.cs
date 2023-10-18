using System;
using System.Collections.Generic;

namespace Solution.API.W.Models;

public partial class GroupUser
{
    public int GroupUserId { get; set; }

    public int GroupId { get; set; }

    public string UserId { get; set; } = null!;

    public bool Admin { get; set; }

    public DateTime AddedDate { get; set; }
}
