using LoFiEffects.WPF.Effects;
using System.Windows;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class PosterizeMultiChannelEffect_Tests
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
                PosterizeMultiChannelEffect result = new();
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [TestMethod]
        public void GivenAdjustSteps_ThenNoException()
        {
            try
            {
                PosterizeEffect effect = new()
                {
                    Steps = 1
                };
                Assert.AreEqual(1, effect.Steps);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }
    }
}
