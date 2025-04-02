using MudBlazor;
using MudBlazor.Utilities;

namespace Multa.Web
{
    public static class Configuration
    {
        public static MudTheme Theme = new()
        {
            Typography = new Typography()
            {
                Default = new DefaultTypography()
                {
                    FontFamily = ["Ubuntu", "sans - serif"],
                }
            },
            PaletteLight = new PaletteLight()
            {
                Primary = "FFD369",
                Secondary = Colors.Red.Accent4,
                Background = Colors.Gray.Lighten4,
                AppbarBackground = new MudColor("#1EFA2D"),
                AppbarText = Colors.Shades.Black,
                TextPrimary = Colors.Shades.Black,
                DrawerText = Colors.Shades.White,
                DrawerBackground = Colors.Green.Darken4
            },
            PaletteDark = new PaletteDark
            {
                Primary = Colors.LightGreen.Accent3,
                Secondary = Colors.LightGreen.Darken3,
                // Background = Colors.LightGreen.Darken4,
                AppbarBackground = Colors.LightGreen.Accent3,
                AppbarText = Colors.Shades.Black,
                PrimaryContrastText = new MudColor("#000000")
            }
        };
    }
}
