using System;

namespace HangFireLegacy.Helpers
{
    public static class DateExtensions
    {
        public static DateTimeOffset ToDateTimeOffset(this DateTime dt)
        => DateTime.SpecifyKind(dt, DateTimeKind.Local);
    }
}
