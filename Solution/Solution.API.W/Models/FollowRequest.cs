using System;
using System.Collections.Generic;

namespace Solution.API.W.Models;

public partial class FollowRequest
{
    public int FollowRequestId { get; set; }

    public string FromUserId { get; set; } = null!;

    public string ToUserId { get; set; } = null!;

    public bool Accepted { get; set; }
}
