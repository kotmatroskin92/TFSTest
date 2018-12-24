using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestFramework.Utilities
{
    public class SoftAssertions
    {
        private readonly List<SingleAssert> _verifications = new List<SingleAssert>();

        public void IsEquals(string expected, string actual, string message)
        {
            _verifications.Add(new SingleAssert(message, expected, actual));
        }

        public void IsEquals(bool expected, bool actual, string message)
        {
            IsEquals(expected.ToString(), actual.ToString(), message);
        }

        public void IsEquals(int expected, int actual, string message)
        {
            IsEquals(expected.ToString(), actual.ToString(), message);
        }

        public void IsTrue(bool actual, string message)
        {
            _verifications.Add(new SingleAssert(true.ToString(), actual.ToString(), message));
        }

        public void AssertAll()
        {
            var failed = _verifications.Where(v => v.Failed).ToList();

            if (failed.Count > 0)
            {
                var message = string.Empty;
                failed.ForEach(singleAssert => message += singleAssert.ToString());
                throw new AssertFailedException($"SoftAssert failed. {message}");
            }
            _verifications.Clear();
        }

        private class SingleAssert
        {
            private readonly string _message;
            private readonly string _expected;
            private readonly string _actual;

            public bool Failed { get; }

            public SingleAssert(string expected, string actual, string message)
            {
                _message = message;
                _expected = expected;
                _actual = actual;
                Failed = _expected != _actual;

                if (!Failed)
                {
                    return;
                }

                // TODO Add additional message
                var additionalMessage = string.Empty;
                _message += $".{additionalMessage}";
            }

            public override string ToString()
            {
                return $"'{_message}' assert was expected to be " +
                       $"'{_expected}' but was '{_actual}'\n";
            }
        }
    }
}
