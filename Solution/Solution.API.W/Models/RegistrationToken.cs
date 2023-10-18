using System;
using System.Collections.Generic;

namespace Solution.API.W.Models;

public partial class RegistrationToken
{
    public int RegistrationTokenId { get; set; }

    public Guid Token { get; set; }

    public string? Role { get; set; }
}
