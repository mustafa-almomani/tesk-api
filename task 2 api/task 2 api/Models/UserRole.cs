﻿using System;
using System.Collections.Generic;

namespace task_2_api.Models;

public partial class UserRole
{
    public int UserId { get; set; }

    public string Role { get; set; } = null!;

    public virtual User User { get; set; } = null!;
}
