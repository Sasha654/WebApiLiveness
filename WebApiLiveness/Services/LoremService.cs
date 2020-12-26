using LoremNET;

namespace WebApiLiveness.Services
{
    public class LoremService
    {
        private int _wordCountMin = 7;
        private int _wordCountMax = 12;

        public string GetSentence()
        {
            var sentence = Lorem.Sentence(_wordCountMin, _wordCountMax);
            return sentence;
        }
    }
}
