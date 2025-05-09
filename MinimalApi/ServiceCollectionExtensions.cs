using System.Reflection;
using Carter;

namespace MinimalApi;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Registers all CarterModules and registers the domain services.
    /// </summary>
    /// <param name="services"></param>
    public static void AddModules(this IServiceCollection services)
    {
        services.AddCarter();
        
        services.RegisterDomainModules();
    }
    
    /// <summary>
    /// Discovers all classes in the Assemblies that end with <c>Module</c>
    /// classname and contains a public static Register() method to invoke.
    /// </summary>
    /// <param name="services"></param>
    private static void RegisterDomainModules(this IServiceCollection services)
    {
        // Find all types that end with "Module", are classes, and are not abstract
        var moduleTypes = AppDomain.CurrentDomain.GetAssemblies()
            .SelectMany(a => a.GetTypes())
            .Where(t => t is { IsClass: true, IsAbstract: false } && t.Name.EndsWith("Module"));

        foreach (var moduleType in moduleTypes)
        {
            // Find a static Add method
            var addMethod = moduleType.GetMethod("Register", BindingFlags.Static | BindingFlags.Public);
            if (addMethod != null)
            {
                // Invoke the Add method, passing the IServiceCollection instance
                addMethod.Invoke(null, [services]);
            }
        }
    }
}