using System.Runtime.CompilerServices;

namespace LoFiEffects.WPF.Tests
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
#pragma warning disable S101 // Types should be named in PascalCase
    public class STATestMethodAttribute([CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0) : TestMethodAttribute(callerFilePath, callerLineNumber)
#pragma warning restore S101 // Types should be named in PascalCase
    {
        public override async Task<TestResult[]> ExecuteAsync(ITestMethod testMethod)
        {
            var result = Array.Empty<TestResult>();

            var thread = new Thread(async () =>
            {
                result = await base.ExecuteAsync(testMethod);
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            return result;
        }
    }
}
