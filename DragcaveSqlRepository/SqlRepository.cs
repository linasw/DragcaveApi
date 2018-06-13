using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DragcaveEntities;
using DragcaveRepository;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace DragcaveSqlRepository
{
    public class SqlRepository : IRepository
    {
        private readonly DragcaveContext _context;

        public SqlRepository(DragcaveContext context)
        {
            _context = context;
        }

        public Task<Dragon> GetDragonAsync(int id)
        {
            var dragon = _context.Dragons.FirstOrDefault(x => x.Id == id);

            if (dragon == null)
            {
                //throw Dragonnotfoundexception
            }

            return Task.FromResult(dragon);
        }

        public async Task<bool> AnyDragonsAsync()
        {
            return await _context.Dragons.AnyAsync();
        }

        public async Task AddDragonsAsync(Dragon[] dragons)
        {
            await _context.Dragons.AddRangeAsync(dragons);
            await _context.SaveChangesAsync();
        }
    }
}
