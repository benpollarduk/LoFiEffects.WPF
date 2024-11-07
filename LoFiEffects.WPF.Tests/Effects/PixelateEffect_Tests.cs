using LoFiEffects.WPF.Effects;
using System.Windows;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class PixelateEffect_Tests
    {
        [TestInitialize]
        public void Setup()
        {
            // application needs to be created in order for pack Uri's to be able to resolve
            if (Application.Current == null)
                new Application();
        }

        [TestMethod]
        public void GivenConstruct_ThenNoException()
        {
            try
            {
                PixelateEffect result = new();
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [TestMethod]
        public void GivenAdjustIntensity_ThenNoException()
        {
            try
            {
                PixelateEffect effect = new()
                {
                    Intensity = 1
                };
                Assert.AreEqual(1, effect.Intensity);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }
    }
}
