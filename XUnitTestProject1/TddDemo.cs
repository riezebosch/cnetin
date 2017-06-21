using Xunit;

namespace XUnitTestProject1
{
    public class TddDemo
    {
        [Fact]
        public void GeldigInputIsTrue()
        {
            string input = "525727752";
            bool resultaat = IsElevenProof(input);

            Assert.True(resultaat);
        }

        [Fact]
        public void KarakterGroterDan9IsFalse()
        {
            string input = "52572775=";
            bool resultaat = IsElevenProof(input);

            Assert.False(resultaat);
        }

        [Fact]
        public void KarakterKleinerDan0IsFalse()
        {
            string input = "52572775'";
            bool resultaat = IsElevenProof(input);

            Assert.False(resultaat);
        }

        [Fact]
        public void InputTeKortIsFalse()
        {
            string input = "52572775";
            bool resultaat = IsElevenProof(input);

            Assert.False(resultaat);
        }

        private static bool IsElevenProof(string input)
        {
            if (input.Length != 9)
            {
                return false;
            }

            int som = 0;
            for (int i = 0; i < 9; i++)
            {
                char c = input[i];
                if (!char.IsDigit(c))
                {
                    return false;
                }

                int g = c - '0';
                som = som + g * (9 - i);
            }

            int restwaarde = som % 11;
            bool resultaat = restwaarde == 0;
            return resultaat;
        }
    }
}
