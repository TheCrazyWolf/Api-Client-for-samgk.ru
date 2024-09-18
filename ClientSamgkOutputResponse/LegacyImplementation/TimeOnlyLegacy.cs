namespace ClientSamgkOutputResponse.LegacyImplementation;

// LEGACY COMPABILITY
public class TimeOnlyLegacy
{
    public int Hour { get; set; }
    public int Minute { get; set; }

    public TimeOnlyLegacy(int hour, int minute)
    {
        Hour = hour;
        Minute = minute;
    }

    public TimeOnlyLegacy()
    {
        
    }
}