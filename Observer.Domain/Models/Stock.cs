﻿namespace Observer.Domain.Models
{
    public class Stock : Entity
    {
        public Stock()
        {
            StockAlerts = new HashSet<StockAlert>();
        }

        public Guid? CompanyId { get; set; }
        public Guid? ArrivalId { get; set; }
        public Arrival? Arrival { get; set; }
        public Guid? ItemId { get; set; }
        public Guid? PositionId { get; set; }
        public Position Position { get; set; }
        public decimal? Quantity { get; set; }
        public DateTime? LastDiscount { get; set; }
        public int? TimesDiscounted { get; set; }
        public int? DiscountedItemsPerUpdate { get; set; }
        public ICollection<StockAlert> StockAlerts { get; set; }
    }
}