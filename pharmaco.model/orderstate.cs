using System.ComponentModel;

namespace pharmaco.model
{
    public enum orderstate
    {
        all = -1,
        [Description("Nová objednávka")]
        created = 1,
        [Description("Videná")]
        seen = 2,
        [Description("Spracúva sa")]
        processed = 3,
        [Description("Predaná")]
        sold = 4,
        [Description("Zrušená objednávka")]
        cancelled = 5
    }
}
