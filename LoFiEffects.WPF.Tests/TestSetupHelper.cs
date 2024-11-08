using System.Windows;

namespace LoFiEffects.WPF.Tests
{
    internal static class TestSetupHelper
    {
        private static Application? application;

        internal static void PrepareTestToUsePackUri()
        {
            // application needs to be created in order for pack Uri's to be able to resolve
            if (Application.Current == null && application == null)
                application = new Application();
        }
    }
}
