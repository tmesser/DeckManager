using DeckManager.Extensions;

namespace DeckManager.Components.Enums
{
    public enum ComponentType
    {
        Unknown,
        [StringValue("Raiders")]
        Raider,
        [StringValue("HeavyRaiders")]
        HeavyRaider,
        [StringValue("Vipers")]
        Viper,
        [StringValue("Civilians")]
        Civilian,
        Basestar
    }
}
