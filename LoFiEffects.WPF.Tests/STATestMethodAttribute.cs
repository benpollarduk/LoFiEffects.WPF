namespace LoFiEffects.WPF.Tests
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
#pragma warning disable S101 // Types should be named in PascalCase
    public class STATestMethodAttribute : TestMethodAttribute
#pragma warning restore S101 // Types should be named in PascalCase
    {
        public override TestResult[] Execute(ITestMethod testMethod)
        {
            var result = Array.Empty<TestResult>();

            var thread = new Thread(() =>
            {
                result = base.Execute(testMethod);
            });

            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();

            return result;
        }
    }
}
