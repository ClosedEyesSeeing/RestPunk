using Avalonia.Styling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestPunk
{
    public static class Extensions
    {
        public static ThemeVariant ParseThemeVariant(this string themeName)
        {
            switch(themeName)
            {
                case nameof(ThemeVariant.Light):
                    return ThemeVariant.Light;
                    break;
                case nameof(ThemeVariant.Dark):
                default:
                    return ThemeVariant.Dark;
                    break;
            }
        }

		public static string ParseThemeVariant(this ThemeVariant variant)
		{
			return variant == ThemeVariant.Light ? nameof(ThemeVariant.Light) : nameof(ThemeVariant.Dark);
		}
	}
}
