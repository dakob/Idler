using Shared;

namespace Idler.Model
{
    public class IdleTask
    {
        public virtual string Name { get; set; }

        public int StartYear { get; set; }

        public int StartDay { get; set; }

        public int StartMonth { get; set; }

        public int StartHour { get; set; }

        public int StartMinutes { get; set; }

        public int EndDay { get; set; }

        public int EndHour { get; set; }

        public int EndMinutes { get; set; }

        public Enums.Status Status { get; set; }

        public string StatusText { get; set; }
    }
}
