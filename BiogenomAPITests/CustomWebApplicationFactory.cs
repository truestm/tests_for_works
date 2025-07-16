using Microsoft.AspNetCore.Mvc.Testing;

namespace BiogenomAPITests
{
    public class CustomWebApplicationFactory<TProgram>
        : WebApplicationFactory<TProgram> where TProgram : class
    {
    }
}
