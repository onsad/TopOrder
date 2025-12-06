using System.ComponentModel.DataAnnotations;

namespace TopOrder.Entitites
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public required string CustomerName { get; set; }
        public Status Status { get; set; }
        public required int StatusId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
    }
}
