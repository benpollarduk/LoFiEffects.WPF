using LoFiEffects.WPF.Effects;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class NegativeEffect_Tests
    {
        [TestMethod]
        public void GivenConstruct_ThenNoExceptionThrown()
        {
            try
            {
                NegativeEffect effect = new();
                Assert.IsNotNull(effect);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }
    }
}
