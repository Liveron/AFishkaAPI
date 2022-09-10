namespace AFishkaAPI.Middleware
{
    public static class CustomExceptionHandlerMiddlewareExtenstions
    {
        public static IApplicationBuilder UseCustomExceptionHandler(this 
            IApplicationBuilder builder)
        {
            return builder.UseMiddleware<CustomExceptionHandlerMiddleware>();
        }
    }
}
