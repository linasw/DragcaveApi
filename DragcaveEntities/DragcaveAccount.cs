﻿using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity;

namespace DragcaveEntities
{
    public class DragcaveAccount : IdentityUser
    {
        public ICollection<Dragon> Dragons = new List<Dragon>();
    }
}
