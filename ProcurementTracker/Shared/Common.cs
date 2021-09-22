using System.Diagnostics.CodeAnalysis;

namespace ProcurementTracker.Shared
{
    public static class Common
    {
        public static bool IsNotNull([NotNullWhen(true)] object? obj) => obj != null;
    }
}