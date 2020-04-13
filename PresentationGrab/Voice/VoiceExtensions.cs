using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Speech.V1;

namespace PresentationGrab.Voice
{
    internal static class VoiceExtensions
    {
        internal static string FixWordException(this string word)
        {
            if (word == "cm.")
                return "cm";
            return word;
        }
            

        internal static bool EndsWithPunctuation(this string word)
        {
            word = word.Trim();
            var lastchar = word.Last();
            // return char.IsPunctuation(lastchar);
            switch (lastchar)
            {
                case ',':
                    return true;
                case '.':
                    return true;
                default:
                    return false;
            }
        }

   
    }
}
