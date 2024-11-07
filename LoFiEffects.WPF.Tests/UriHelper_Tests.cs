namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class UriHelper_Tests
    {
        [TestMethod]
        public void GivenSimpleString_WhenFromResource_ThenReturnCorrectlyFormattedPackUri()
        {
            var resource = "resource.png";

            var result = UriHelper.FromResource(resource);

            Assert.AreEqual(@"pack://application:,,,/LoFiEffects.WPF;component/resource.png", result.ToString());
        }
    }
}
