using LoFiEffects.WPF.Effects;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class DitheringEffect_Tests
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
                DitheringEffect result = new();
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [TestMethod]
        public void GivenAdjustTextureWidth_ThenNoException()
        {
            try
            {
                DitheringEffect effect = new()
                {
                    TextureWidth = 100
                };
                Assert.AreEqual(100, effect.TextureWidth);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [TestMethod]
        public void GivenAdjustTextureHeight_ThenNoException()
        {
            try
            {
                DitheringEffect effect = new()
                {
                    TextureHeight = 100
                };
                Assert.AreEqual(100, effect.TextureHeight);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [TestMethod]
        public void GAdjustIntensity_ThenNoException()
        {
            try
            {
                DitheringEffect effect = new()
                {
                    Intensity = 0.5
                };
                Assert.AreEqual(0.5, effect.Intensity);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }
    }
}