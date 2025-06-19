using Project2144.Debugging;

namespace Project2144;

public class Project2144Consts
{
    public const string LocalizationSourceName = "Project2144";

    public const string ConnectionStringName = "Default";

    public const bool MultiTenancyEnabled = true;


    /// <summary>
    /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
    /// </summary>
    public static readonly string DefaultPassPhrase =
        DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "bd89abb622c84b6790cf6881b532c0bc";
}
