using LoFiEffects.WPF.Effects;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class PosterizeMultiChannelEffect_Tests
    {
        [TestMethod]
        public void GivenConstruct_ThenNoExceptionThrown()
        {
            try
            {
                PosterizeMultiChannelEffect effect = new();
                Assert.IsNotNull(effect);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }
    }
}
