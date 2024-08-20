using System;

namespace Scribble
{
    public enum SaberHand {
        Right,
        Left
    }

    public static class EnumExtensions
    {
        public static TEnum GetEnumValue<TEnum>(this string name)
        {
            return (TEnum) Enum.Parse(typeof(TEnum), name);
        }
    }
}
