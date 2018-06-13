using System;
using System.Collections.Generic;
using System.Text;
using DragcaveEntities;

namespace DragcaveRepository
{
    public class DummyDataGenerator
    {
        public Dragon[] GenerateDragons()
        {
            var dragons = new List<Dragon>();

            for (int i = 0; i <= 50; i++)
            {
                dragons.Add(new Dragon
                {
                    Id = i,
                    Name = $"Name{i}",
                    Description = $"Description{i}",
                    UniqueViews = i,
                    Views = i + 1,
                    Clicks = i - 1,
                    Breed = $"Breed{i}",
                    State = 0
                });
            }

            return dragons.ToArray();
        }
    }
}
