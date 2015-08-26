using System.ComponentModel;

namespace FantasyHockey.Data.Enums
{
    public enum Position
    {
        Center = 0,
        [Description("Left Wing")]
        LeftWing,
        [Description("Right Wing")]
        RightWing,
        [Description("Left Defense")]
        LeftDefense,
        [Description("Right Defense")]
        RightDefense,
        Goalie
    }
}