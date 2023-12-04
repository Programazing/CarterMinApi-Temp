using Carter;

namespace WebApplication1;

public class UserController : ICarterModule
{
	private static readonly List<User> Users = new();

	public void AddRoutes(IEndpointRouteBuilder app)
	{
		app.MapGet("/users", (HttpContext ctx) => 
		{
			return ctx.Response.WriteAsJsonAsync(Users);
		});

		app.MapGet("/users/{id:int}", async (HttpContext ctx, int id) =>
		{
			var user = Users.Find(u => u.Id == id);
			if (user != null)
			{
				await ctx.Response.WriteAsJsonAsync(user);
			}
			else
			{
				ctx.Response.StatusCode = 404;
			}
		});

		app.MapPost("/users", async (HttpContext ctx) =>
		{
			var newUser = await ctx.Request.ReadFromJsonAsync<User>();
			if (newUser != null)
			{
				Users.Add(newUser);
				ctx.Response.StatusCode = 201;
				await ctx.Response.WriteAsJsonAsync(newUser);
			}
			else
			{
				ctx.Response.StatusCode = 400;
			}
		});
	}

	public record User(int Id, string Name);
}