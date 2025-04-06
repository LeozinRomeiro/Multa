using MudBlazor;
using MudBlazor.Utilities;

namespace Multa.Web
{
    public static class Configuration
    {
        public const string HttpClientName = "multa";
        public static string BackendUrl { get; set; } = "http://localhost:5164";
        public static MudTheme Theme = new()
        {
            Typography = new Typography()
            {
                Default = new DefaultTypography()
                {
                    FontFamily = ["Ubuntu", "sans - serif"],
                }
            },
            //PaletteLight = new PaletteLight()
            //{
            //    //Primary = "FFD369",
            //    Primary = new MudColor("#fff100"),
            //    PrimaryContrastText = new MudColor("#000000"),
            //    Secondary = Colors.LightGreen.Darken3,
            //    Background = Colors.Gray.Lighten4,
            //    AppbarBackground = new MudColor("#fff100"),
            //    AppbarText = Colors.Shades.Black,
            //    TextPrimary = Colors.Shades.Black,
            //    DrawerText = Colors.Shades.Black,
            //    DrawerBackground = "#ecce44"
            //},
            PaletteDark = new PaletteDark()
            {
                Primary = "#FFF700",
                Secondary = "#FFFFE0",
                Tertiary = Colors.Shades.White,
                // Background = Colors.LightGreen.Darken4,
                AppbarBackground = new MudColor("#FFF700"),
                AppbarText = Colors.Shades.Black,
                PrimaryContrastText = new MudColor("#000000")
            },
            PaletteLight = new PaletteLight()
            { 
                Primary = new MudColor("#FFF700"),
                PrimaryContrastText = new MudColor("#000000"),
                Secondary = "#3B3B00",
                Tertiary = Colors.Shades.White,
                Background = "#FFFFE0",
                Surface = "#FFFACD",
                AppbarBackground = new MudColor("#FFF700"),
                AppbarText = Colors.Shades.Black,
                TextPrimary = Colors.Shades.Black,
                DrawerText = Colors.Shades.White,
                DrawerBackground = "#3B3B00"
            },
            //PaletteLight = new PaletteLight()
            //{
            //    Primary = new MudColor("#FFDD00"),
            //    PrimaryContrastText = new MudColor("#000000"),
            //    Secondary = Colors.LightGreen.Darken3,
            //    Background = "#EFF1F3",
            //    AppbarBackground = new MudColor("#FFDD00"),
            //    AppbarText = Colors.Shades.Black,
            //    TextPrimary = Colors.Shades.Black,
            //    TextSecondary = Colors.Shades.Black,
            //    DrawerText = Colors.Shades.Black,
            //    DrawerIcon = Colors.Shades.Black,
            //    DrawerBackground = "#0353A4",

            //},
            //PaletteDark = new PaletteDark
            //{
            //    Primary = "#ffff7c",
            //    Secondary = Colors.LightGreen.Darken3,
            //    // Background = Colors.LightGreen.Darken4,
            //    AppbarBackground = "#ffff7c",
            //    AppbarText = Colors.Shades.Black,
            //    PrimaryContrastText = new MudColor("#000000")
            //}
        };
    }
}
