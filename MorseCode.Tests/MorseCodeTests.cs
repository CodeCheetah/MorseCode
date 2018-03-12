using MorseCode.Logic.Interfaces;
using MorseCode.Logic.Services;
using NUnit.Framework;
using FluentAssertions;
using StructureMap;

namespace MorseCode.Tests
{
    [TestFixture]
    public class MorseCodeTests
    {
        private static IContainer _container;
        private static ITranslationService _translationService;

        [OneTimeSetUp]
        public void SetUp()
        {
            _container = new Container(x =>
            {
                x.For<ITranslationService>().Use<TranslationService>();
            });

            _translationService = _container.GetInstance<ITranslationService>();
        }

        [Test]
        public void Test_Morse_Code_To_English()
        {
            var textToTranslate = "- .... .   .-- .. --.. .- .-. -..   --.- ..- .. -.-. -.- .-.. -.--   .--- .. -. -..- . -..   - .... .   --. -. --- -- . ...   -... . ..-. --- .-. .   - .... . -.--   ...- .- .--. --- .-. .. --.. . -..";

            var result = _translationService.TranslateMorseToEnglish(textToTranslate);

            result.Should().Be("the wizard quickly jinxed the gnomes before they vaporized");
        }

        [Test]
        public void Test_English_To_Morse_Code()
        {
            var textToTranslate = "the wizard quickly jinxed the gnomes before they vaporized";

            var result = _translationService.TranslateEnglishToMorse(textToTranslate);

            result.Should().Be("- .... .   .-- .. --.. .- .-. -..   --.- ..- .. -.-. -.- .-.. -.--   .--- .. -. -..- . -..   - .... .   --. -. --- -- . ...   -... . ..-. --- .-. .   - .... . -.--   ...- .- .--. --- .-. .. --.. . -..");
        }
    }
}
