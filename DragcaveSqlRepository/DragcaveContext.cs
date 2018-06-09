using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DragcaveEntities;

namespace DragcaveSqlRepository
{
    public class DragcaveContext : IdentityDbContext<DragcaveAccount, DragcaveRole, string>
    {
        public DragcaveContext(DbContextOptions<DragcaveContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Dragon> Dragons { get; set; }
    }
}
