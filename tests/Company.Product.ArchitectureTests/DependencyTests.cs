using NetArchTest.Rules;

namespace Company.Product.ArchitectureTests;

public sealed class DependencyTests
{
    private const string DomainNamespace =
        "Company.Product.Domain";

    private const string ApplicationNamespace =
        "Company.Product.Application";

    private const string InfrastructureNamespace =
        "Company.Product.Infrastructure";

    private const string ApiNamespace =
        "Company.Product.Api";

    [Fact]
    public void Domain_Should_Not_Depend_On_Application()
    {
        var result = Types
            .InAssembly(typeof(Domain.AssemblyReference).Assembly)
            .ShouldNot()
            .HaveDependencyOn(ApplicationNamespace)
            .GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Domain_Should_Not_Depend_On_Infrastructure()
    {
        var result = Types
            .InAssembly(typeof(Domain.AssemblyReference).Assembly)
            .ShouldNot()
            .HaveDependencyOn(InfrastructureNamespace)
            .GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Domain_Should_Not_Depend_On_Api()
    {
        var result = Types
            .InAssembly(typeof(Domain.AssemblyReference).Assembly)
            .ShouldNot()
            .HaveDependencyOn(ApiNamespace)
            .GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Application_Should_Not_Depend_On_Infrastructure()
    {
        var result = Types
            .InAssembly(typeof(Application.AssemblyReference).Assembly)
            .ShouldNot()
            .HaveDependencyOn(InfrastructureNamespace)
            .GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Application_Should_Not_Depend_On_Api()
    {
        var result = Types
            .InAssembly(typeof(Application.AssemblyReference).Assembly)
            .ShouldNot()
            .HaveDependencyOn(ApiNamespace)
            .GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void Infrastructure_Should_Not_Depend_On_Api()
    {
        var result = Types
            .InAssembly(typeof(Infrastructure.AssemblyReference).Assembly)
            .ShouldNot()
            .HaveDependencyOn(ApiNamespace)
            .GetResult();

        Assert.True(result.IsSuccessful);
    }
}
