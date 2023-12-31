﻿using System;
using System.Collections.Generic;

namespace Solution.API.W.Models;

public partial class GroupComment
{
    public int GroupCommentId { get; set; }

    public string? CommentText { get; set; }

    public int GroupUpdateId { get; set; }

    public DateTime CommentDate { get; set; }

    public virtual GroupUpdate GroupUpdate { get; set; } = null!;
}
