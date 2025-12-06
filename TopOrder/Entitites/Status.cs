using System.ComponentModel.DataAnnotations;

namespace TopOrder.Entitites
{
    public class Status
    {
        [Key]
        public int Id { get; set; }

        public required StatusCode Code { get; set; }

        public required string Name { get; set; }
    }
}
