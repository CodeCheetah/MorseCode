using System;
using MorseCode.App.Registrations;
using MorseCode.Logic.Interfaces;
using StructureMap;

namespace MorseCode.App
{
    public class Program
    {
        private static IContainer _container;
        private static ITranslationService _translationService;

        public static void Main(string[] args)
        {
            var textToTranslate = "- .... .   .-- .. --.. .- .-. -..   --.- ..- .. -.-. -.- .-.. -.--   .--- .. -. -..- . -..   - .... .   --. -. --- -- . ...   -... . ..-. --- .-. .   - .... . -.--   ...- .- .--. --- .-. .. --.. . -..";
            var text = Run(true, textToTranslate);

            Console.WriteLine(text);
            Console.ReadLine();
        }

        public static string Run(bool morseToEnglish, string textToTranslate)
        {
            InitializeContainer();

            _translationService = _container.GetInstance<ITranslationService>();

            var translatedText = string.Empty;

            if (morseToEnglish)
            {
                translatedText = _translationService.TranslateMorseToEnglish(textToTranslate);
            } else
            {
                translatedText = _translationService.TranslateEnglishToMorse(textToTranslate);
            }
            return translatedText;
        }

        private static void InitializeContainer()
        {
            _container = new Container(x =>
            {
                x.AddRegistry(new Registration());
            });
        }
    }
}
