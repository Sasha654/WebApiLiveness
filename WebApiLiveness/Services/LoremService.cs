using LoremNET;
using System;

namespace WebApiLiveness.Services
{
    public class LoremService
    {
        private int _wordCountMin = 7;
        private int _wordCountMax = 12;
        private int _numRequestBeforeError = 5;
        private int _requestCounter = 0;

        public LoremService()
        {
            IsOk = true;
        }

        public bool IsOk { get; private set; }

        public string GetSentence()
        {
            if (_requestCounter < _numRequestBeforeError)
            {
                _requestCounter++;
                var sentence = Lorem.Sentence(
                    _wordCountMin, _wordCountMax);
                return sentence;
            }
            else
            {
                IsOk = false;
                throw new InvalidOperationException(
                    $"{nameof(LoremService)} not available");
            }
        }
    }
}
