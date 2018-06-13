using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DragcaveRepository
{
    public class DataSeeder
    {
        private readonly DummyDataGenerator _dataGenerator;

        public DataSeeder(DummyDataGenerator dataGenerator)
        {
            _dataGenerator = dataGenerator;
        }

        public async Task SeedAsync(IRepository repository)
        {
            if (!await repository.AnyDragonsAsync())
            {
                var dragons = _dataGenerator.GenerateDragons();

                await repository.AddDragonsAsync(dragons);
            }
        }
    }
}
