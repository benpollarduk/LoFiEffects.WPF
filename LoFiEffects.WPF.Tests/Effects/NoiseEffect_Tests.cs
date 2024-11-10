using LoFiEffects.WPF.Effects;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class NoiseEffect_Tests
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
                NoiseEffect result = new();
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [TestMethod]
        public void GivenAdjustDensity_ThenNoException()
        {
            try
            {
                NoiseEffect effect = new()
                {
                    Density = 1
                };
                Assert.AreEqual(1, effect.Density);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [TestMethod]
        public void GivenAdjustOffset_ThenNoException()
        {
            try
            {
                NoiseEffect effect = new()
                {
                    Offset = 1
                };
                Assert.AreEqual(1, effect.Offset);
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
                NoiseEffect effect = new()
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
        public void GivenAdjustRenderOverTransparent_ThenNoException()
        {
            try
            {
                NoiseEffect effect = new()
                {
                    RenderOverTransparent = true
                };
                Assert.IsTrue(effect.RenderOverTransparent);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }
    }
}
