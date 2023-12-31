﻿namespace Observer.Domain.Entities
{
    public class Warehouse : Entity
    {
        public Warehouse()
        {
            Aisles = new HashSet<Aisle>();
        }

        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Identifier { get; set; }
        public bool? Active { get; set; }
        public ICollection<Aisle> Aisles { get; set; }
    }
}
