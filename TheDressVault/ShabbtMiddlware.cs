namespace TheDressVault
{
    public class ShabbtMiddlware
    {

        private readonly RequestDelegate _next;

        public ShabbtMiddlware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            if (DateTime.Now.DayOfWeek == DayOfWeek.Monday)
            {
                context.Response.StatusCode = 400;
                Console.WriteLine("השבת היא ה ❤️ של העם היהודי");
                return;
            }
            await _next(context);
        }
    }
}
