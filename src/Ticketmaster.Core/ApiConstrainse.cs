namespace Ticketmaster.Core
{
    public static class ApiConstraints
    {
        public const int RequiredRequestDelay = 1000;
        public const int MaxPagingDepth = 1000;
        public const int MaxPageSize = 200;
        public const int MinPageSize = 1;
        public const string DateTimeFormat = "yyyy-MM-ddTHH:mm:ssZ";
    }
}
