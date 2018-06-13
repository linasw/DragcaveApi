using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using DragcaveEntities;
using DragcaveRepository;
using System.Linq;

namespace DragcaveSqlRepository
{
    public class SqlRepository : IRepository
    {
        private readonly DragcaveContext _context;

        public SqlRepository(DragcaveContext context)
        {
            _context = context;
        }

        public Task<Dragon> GetDragonAsync(Guid id)
        {
            var dragon = _context.Dragons.FirstOrDefault(x => x.Id == id);

            if (dragon == null)
            {
                //throw Dragonnotfoundexception
            }

            return Task.FromResult(dragon);
        }
    }
}
