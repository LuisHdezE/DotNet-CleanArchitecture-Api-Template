using NetArchTest.Rules;

namespace ClinicLab.ArchitectureTests;

public sealed class DependencyTests
{
    private const string DomainNamespace =
        "ClinicLab.Domain";

    private const string ApplicationNamespace =
        "ClinicLab.Application";

    private const string InfrastructureNamespace =
        "ClinicLab.Infrastructure";

    private const string ApiNamespace =
        "ClinicLab.Api";

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