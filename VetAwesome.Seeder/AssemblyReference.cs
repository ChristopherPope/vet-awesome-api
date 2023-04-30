using System.Reflection;

namespace VetAwesome.Seeder;

public static class AssemblyReference
{
    public static readonly Assembly Assembly = typeof(AssemblyReference).Assembly;
}