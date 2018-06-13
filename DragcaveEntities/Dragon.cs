using DragcaveEntities.Enums;
using System;

namespace DragcaveEntities
{
    public class Dragon
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int UniqueViews { get; set; }
        public int Views { get; set; }
        public int Clicks { get; set; }
        public string Breed { get; set; }
        public DragonState State { get; set; }

        public string AccoutId;
        public DragcaveAccount DragcaveAccount;
    }
}
