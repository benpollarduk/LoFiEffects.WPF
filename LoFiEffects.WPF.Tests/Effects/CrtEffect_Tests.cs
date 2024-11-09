using LoFiEffects.WPF.Effects;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class CrtEffect_Tests
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
                CrtEffect result = new();
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
                CrtEffect effect = new()
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
                CrtEffect effect = new()
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
        public void GAdjustIncludeScanlines_ThenNoException()
        {
            try
            {
                CrtEffect effect = new()
                {
                    IncludeScanlines = true
                };
                Assert.IsTrue(effect.IncludeScanlines);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }
    }
}
