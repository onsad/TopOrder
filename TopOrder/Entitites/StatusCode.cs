using System.ComponentModel;

namespace TopOrder.Entitites
{
    public enum StatusCode : byte
    {
        [Description("Processing")]
        Processing = 1,

        [Description("Shipped")]
        Shipped = 2,

        [Description("Canceled")]
        Canceled = 3
    }
}
