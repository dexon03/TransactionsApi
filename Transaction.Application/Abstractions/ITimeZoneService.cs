namespace Transaction.Application.Abstractions;

public interface ITimeZoneService
{
    TimeZoneInfo GetTimeZoneInfo(string coordinates);
    TimeSpan GetTimeZoneOffsetFromCoordinates(string coordinates);
}