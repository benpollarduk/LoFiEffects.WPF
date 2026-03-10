using LoFiEffects.WPF.Effects;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class DataCorruptorEffect_Tests
    {
        [TestInitialize]
        public void Setup()
        {
            TestSetupHelper.PrepareTestToUsePackUri();
        }

        [TestMethod]
        public void GivenConstruct_ThenNoException()
        {
            try
            {
                DataCorruptorEffect result = new();
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }
    }
}