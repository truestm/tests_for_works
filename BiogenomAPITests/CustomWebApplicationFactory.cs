using Microsoft.AspNetCore.Mvc.Testing;

namespace Tests
{
    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
    }
}
