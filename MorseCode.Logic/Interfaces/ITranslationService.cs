﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MorseCode.Logic.Interfaces
{
    public interface ITranslationService
    {
        string TranslateMorseToEnglish(string text);
        string TranslateEnglishToMorse(string text);
    }
}