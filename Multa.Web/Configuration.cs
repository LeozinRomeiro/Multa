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
                //Primary = "FFD369",
                Primary = new MudColor("#fff100"),
                PrimaryContrastText = new MudColor("#000000"),
                Secondary = Colors.LightGreen.Darken3,
                Background = Colors.Gray.Lighten4,
                AppbarBackground = new MudColor("#fff100"),
                AppbarText = Colors.Shades.Black,
                TextPrimary = Colors.Shades.Black,
                DrawerText = Colors.Shades.Black,
                DrawerBackground = "#ecce44"
            },
            //PaletteLight = new PaletteLight()
            //{
            //    //Primary = "FFD369",
            //    Primary = new MudColor("#FFDD00"),
            //    PrimaryContrastText = new MudColor("#000000"),
            //    Secondary = Colors.LightGreen.Darken3,
            //    Background = Colors.Gray.Lighten4,
            //    AppbarBackground = new MudColor("#FFDD00"),
            //    AppbarText = Colors.Shades.Black,
            //    TextPrimary = Colors.Shades.Black,
            //    DrawerText = Colors.Shades.Black,
            //    DrawerBackground = "#36827F"
            //},
            PaletteDark = new PaletteDark
            {
                Primary = "#ffff7c",
                Secondary = Colors.LightGreen.Darken3,
                // Background = Colors.LightGreen.Darken4,
                AppbarBackground = "#ffff7c",
                AppbarText = Colors.Shades.Black,
                PrimaryContrastText = new MudColor("#000000")
            }
        };
    }
}
