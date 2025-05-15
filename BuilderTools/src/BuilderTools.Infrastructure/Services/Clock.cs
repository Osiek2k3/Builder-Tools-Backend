using BuilderTools.Core.Services;

namespace BuilderTools.Infrastructure.Services
{
    public class Clock : IClock
    {
        public DateTime Current() => DateTime.UtcNow;
    }
}
