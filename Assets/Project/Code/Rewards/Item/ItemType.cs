using System.Diagnostics.CodeAnalysis;

namespace Rewards.Item
{
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    public enum ItemType
    {
        MenuMusic_Rock = 0,
        MenuMusic_Rap = 1,

        Skin_Rocker = 2,
        Skin_Rapper = 3,

        Weapon_AK = 4,
        Weapon_M4A4 = 5,

        HUD_Summer = 6,
        HUD_Autumn = 7,

        Voice_Angry = 8,
        Voice_Calm = 9,
    }
}