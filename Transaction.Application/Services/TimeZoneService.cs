using GeoTimeZone;
using TimeZoneConverter;
using Transaction.Application.Abstractions;

namespace Transaction.Application.Services;

public class TimeZoneService : ITimeZoneService
{
    /// <summary>
    /// Returns the time zone id for a given set of coordinates
    /// </summary>
    /// <param name="coordinates"></param>
    /// <returns></returns>
    public string GetTimeZoneId(string coordinates)
    {
        var timeZone = GetTimeZone(coordinates);
        return timeZone;
    }
    
    
    /// <summary>
    /// Returns the time zone offset for a given set of coordinates
    /// </summary>
    /// <param name="coordinates"></param>
    /// <returns></returns>
    public TimeSpan GetTimeZoneOffsetFromCoordinates(string coordinates)
    {
        var timeZone = GetTimeZone(coordinates);
        var offset = TZConvert.GetTimeZoneInfo(timeZone).BaseUtcOffset;
        return offset;
    }

    private string GetTimeZone(string coordinates)
    {
        var splitedCoordinates = coordinates.Split(',');
        var latitude = double.TryParse(splitedCoordinates[0], out double parsedLatitude) ? parsedLatitude : throw new Exception("Invalid latitude");
        var longitude = double.TryParse(splitedCoordinates[1], out double parsedLongitude) ? parsedLongitude : throw new Exception("Invalid longitude");
        var timeZone = TimeZoneLookup.GetTimeZone(latitude, longitude).Result;
        return timeZone;
    }
}