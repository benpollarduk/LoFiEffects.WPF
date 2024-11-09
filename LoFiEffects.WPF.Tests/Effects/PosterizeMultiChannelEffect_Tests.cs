using LoFiEffects.WPF.Effects;

namespace LoFiEffects.WPF.Tests
{
    [TestClass]
    public class PosteriseEffect_Tests
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
                PosterizeEffect result = new();
                Assert.IsNotNull(result);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [TestMethod]
        public void GivenAdjustStepsR_ThenNoException()
        {
            try
            {
                PosterizeMultiChannelEffect effect = new()
                {
                    StepsR = 1
                };
                Assert.AreEqual(1, effect.StepsR);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [TestMethod]
        public void GivenAdjustStepsG_ThenNoException()
        {
            try
            {
                PosterizeMultiChannelEffect effect = new()
                {
                    StepsG = 1
                };
                Assert.AreEqual(1, effect.StepsG);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }

        [TestMethod]
        public void GivenAdjustStepsB_ThenNoException()
        {
            try
            {
                PosterizeMultiChannelEffect effect = new()
                {
                    StepsB = 1
                };
                Assert.AreEqual(1, effect.StepsB);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Exception occurred: {ex.Message}");
            }
        }
    }
}
