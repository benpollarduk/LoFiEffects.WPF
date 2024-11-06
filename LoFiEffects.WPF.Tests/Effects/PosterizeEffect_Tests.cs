using LoFiEffects.WPF.Effects;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class PosterizeEffect_Tests
    {
        [TestMethod]
        public void GivenConstruct_ThenNoExceptionThrown()
        {
            try
            {
                PosterizeEffect effect = new();
                Assert.IsNotNull(effect);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }
    }
}
