using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Internal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;
using System;
using Utils.Word;

namespace Utils.Tests.Word
{
    [TestClass]
    public class WordUtilsTests
    {
        #region Properties

        ILogger _log;
        IWordUtils _wordUtils;

        #endregion

        #region Initialize

        [TestInitialize]
        public void Initialize()
        {
            _log = Mock.Of<ILogger<WordUtils>>();
            _wordUtils = new WordUtils(_log);
        }

        #endregion

        #region Reverse

        [TestCategory("Reverse")]
        [TestMethod]
        public void Reverse_ShouldBeWordInReverse_IfWordIsValid()
        {
            string word = "mountain";

            string reverseWord = _wordUtils.Reverse(word);

            reverseWord.ShouldBe("niatnuom");
        }

        [TestCategory("Reverse")]
        [TestMethod]
        public void Reverse_ShouldThrowArgumentException_IfWordIsNull()
        {
            string word = null;

            Should.Throw<ArgumentException>(() => _wordUtils.Reverse(word))
                .Message.ShouldBe("Please enter a word to reverse.");
        }

        [TestCategory("Reverse")]
        [TestMethod]
        public void Reverse_ShouldThrowArgumentException_IfWordIsEmpty()
        {
            string word = string.Empty;

            Should.Throw<ArgumentException>(() => _wordUtils.Reverse(word))
                .Message.ShouldBe("Please enter a word to reverse.");
        }

        [TestCategory("Reverse")]
        [TestMethod]
        public void Reverse_ShouldInvokeOnce_LogInformationMethod()
        {
            string word = "mountain";

            string reverseWord = _wordUtils.Reverse(word);

            Mock.Get(_log).Verify(x => x.Log(
                LogLevel.Information, 
                It.IsAny<EventId>(), 
                It.IsAny<FormattedLogValues>(), 
                It.IsAny<Exception>(), 
                It.IsAny<Func<object, Exception, string>>()), 
                Times.Once);
        }

        #endregion
    }
}
