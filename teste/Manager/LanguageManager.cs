using System.Globalization;
using System.Threading;

public static class LanguageManager
{
    public static string CurrentLanguage { get; private set; } = "fr";

    public static void SetLanguage(string lang)
    {
        CurrentLanguage = lang;
    }
}
