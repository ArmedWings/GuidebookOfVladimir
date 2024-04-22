using Xamarin.Forms;

namespace AvraamProject
{
    public static class AccentManager
    {
        public static void ApplyAccentColors()
        {
            if ((string)Application.Current.Properties["Accent"] == "1")
            {
                AccentManager.MainAppAccent = "#35373D";
                AccentManager.SideAppAccent = "#2E3034";
                AccentManager.MainTextAccent = "#eff0f0";
                AccentManager.SideTextAccent = "#b4b9c2";
            }
            else if ((string)Application.Current.Properties["Accent"] == "2") 
            {
                AccentManager.MainAppAccent = "#000000";
                AccentManager.SideAppAccent = "#0F0F0F";
                AccentManager.MainTextAccent = "#FFFFFF";
                AccentManager.SideTextAccent = "#D9D9D9";
            }
            else if ((string)Application.Current.Properties["Accent"] == "3")
            {
                AccentManager.MainAppAccent = "#FFFFFF";
                AccentManager.SideAppAccent = "#D9D9D9";
                AccentManager.MainTextAccent = "#000000";
                AccentManager.SideTextAccent = "#7E7E7E";
            }
            else
            {
                // Установите значения по умолчанию, если "Accent" не равен "1"
                AccentManager.MainAppAccent = "#FFFFFF";
                AccentManager.SideAppAccent = "#FFFFFF";
                AccentManager.MainTextAccent = "#000000";
                AccentManager.SideTextAccent = "#000000";
            }
        }

        public static string MainAppAccent { get; private set; }
        public static string MainTextAccent { get; private set; }
        public static string SideTextAccent { get; private set; }
        public static string SideAppAccent { get; private set; }
    }
}