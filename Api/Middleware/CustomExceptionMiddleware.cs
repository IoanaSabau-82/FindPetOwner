using Domain.Exceptions;
using System.Net;

namespace Api.CustomExceptionMiddleware
{
	public class CustomExceptionMiddleware
	{
		private readonly RequestDelegate _next;

		public CustomExceptionMiddleware(RequestDelegate next)
		{
			_next = next;
		}

		public async Task Invoke(HttpContext httpContext)
		{
			try
			{
				await _next(httpContext);
			}
			catch (EntityNotFoundException ex)
			{
				httpContext.Response.StatusCode = 404;
				httpContext.Response.Headers.Add("exception", ex.Value.ToString());
				await httpContext.Response.WriteAsync(ex.Message);
			}

		} 
	}

	public static class MiddlewareExtensions
	{
		public static IApplicationBuilder MyExceptionMiddleware(this IApplicationBuilder builder)
		{
			return builder.UseMiddleware<CustomExceptionMiddleware>();
		}
	}
}
