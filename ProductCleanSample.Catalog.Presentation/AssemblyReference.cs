using System.Reflection;

namespace ProductCleanSample.Catalog.Presentation
{
    public static class AssemblyReference
    {
        public static Assembly Assembly => typeof(AssemblyReference).Assembly;
    }
}
