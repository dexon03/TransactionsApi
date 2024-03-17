namespace Transaction.Application.Abstractions;

public interface ITimeZoneService
{
    string GetTimeZoneId(string coordinates);
    TimeSpan GetTimeZoneOffsetFromCoordinates(string coordinates);
}