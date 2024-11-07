using LoFiEffects.WPF.Effects;
using System.Windows;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class ScanlinesEffect_Tests
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
                ScanlinesEffect result = new();
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [TestMethod]
        public void GivenAdjustXSpacing_ThenNoException()
        {
            try
            {
                ScanlinesEffect effect = new()
                {
                    XSpacing = 1
                };
                Assert.AreEqual(1, effect.XSpacing);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [TestMethod]
        public void GivenAdjustYSpacing_ThenNoException()
        {
            try
            {
                ScanlinesEffect effect = new()
                {
                    YSpacing = 1
                };
                Assert.AreEqual(1, effect.YSpacing);
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
                ScanlinesEffect effect = new()
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
                ScanlinesEffect effect = new()
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
    }
}
