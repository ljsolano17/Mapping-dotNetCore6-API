using System;
using System.Collections.Generic;

namespace Solution.API.W.Models;

public partial class AspNetUserLogin
{
    public string UserId { get; set; } = null!;

    public string LoginProvider { get; set; } = null!;

    public string ProviderKey { get; set; } = null!;

    public virtual AspNetUser User { get; set; } = null!;
}
