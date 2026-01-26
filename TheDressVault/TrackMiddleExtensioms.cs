namespace TheDressVault
{
    public static class TrackMiddleExtensioms
    {
        public static IApplicationBuilder UseShabbat(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ShabbtMiddlware>();
        }
    }
}
