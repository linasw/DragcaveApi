using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using DragcaveEntities;

namespace DragcaveRepository
{
    public interface IRepository
    {
        Task<Dragon> GetDragonAsync(Guid Id);
    }
}
