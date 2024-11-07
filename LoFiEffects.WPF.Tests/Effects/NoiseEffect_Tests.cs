using LoFiEffects.WPF.Effects;
using System.Windows;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class NoiseEffect_Tests
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
    }
}
