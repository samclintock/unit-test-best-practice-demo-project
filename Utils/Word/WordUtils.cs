using System;
using Microsoft.Extensions.Logging;

namespace Utils.Word
{
    public class WordUtils : IWordUtils
    {
        #region Properties

        private readonly ILogger _log;

        #endregion

        #region Constructors

        public WordUtils(ILogger log)
        {
            _log = log;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reverse a word (e.g. "mountain" to "niatnuom")
        /// </summary>
        /// <param name="word">The word to reverse.</param>
        /// <returns>The word in reverse.</returns>
        public string Reverse(string word)
        {
            if (string.IsNullOrEmpty(word))
                throw new ArgumentException("Please enter a word to reverse.");

            char[] charArray = word.ToCharArray();
            Array.Reverse(charArray);
            string reverseWord = new string(charArray);

            _log.LogInformation($"{word} was successfully reversed as {reverseWord}");

            return reverseWord;
        }

        #endregion
    }
}
