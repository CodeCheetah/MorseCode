using StructureMap;
using MorseCode.Logic.Interfaces;
using MorseCode.Logic.Services;

namespace MorseCode.App.Registrations
{
    public class Registration : Registry
    {
        public Registration()
        {
            For<ITranslationService>().Use<TranslationService>();
        }
    }
}
