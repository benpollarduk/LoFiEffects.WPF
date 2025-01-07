using LoFiEffects.WPF.Effects;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class WatercolorEffect_Tests
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
                WatercolorEffect result = new();
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
                WatercolorEffect effect = new()
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

        [TestMethod]
        public void GivenAdjustTextureWidth_ThenNoException()
        {
            try
            {
                WatercolorEffect effect = new()
                {
                    TextureWidth = 1
                };
                Assert.AreEqual(1, effect.TextureWidth);
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
                WatercolorEffect effect = new()
                {
                    TextureHeight = 1
                };
                Assert.AreEqual(1, effect.TextureHeight);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }
    }
}
