using NUnit.Framework;
using tdd_oop_interface_dependency_injection.CSharp.Main;

namespace tdd_oop_interface_dependency_injection.CSharp.Test
{

        [TestFixture]
        public class ScrabbleTest {
        [Test]
        public void shouldGive0ForEmptyWords() {
            Scrabble scrabble = new Scrabble();
            Assert.AreEqual(0, scrabble.score(""));
        }

        [Test]
        public void shouldGive0ForWhiteSpace() {
            Scrabble scrabble = new Scrabble();
            Assert.AreEqual(0, scrabble.score("\n\r\t\b\f"));
        }

        [Test]
        public void shouldScore1ForA() {
            Scrabble scrabble = new Scrabble();
            Assert.AreEqual(1, scrabble.score("a"));
        }

        [Test]
        public void shouldScore4ForF() {
            Scrabble scrabble = new Scrabble();
            Assert.AreEqual(4, scrabble.score("f"));
        }

        [Test]
        public void shouldScore6ForStreet() {
            Scrabble scrabble = new Scrabble();
            Assert.AreEqual(6, scrabble.score("street"));
        }

        [Test]
        public void shouldScore22ForQuirky() {
            Scrabble scrabble = new Scrabble();
            Assert.AreEqual(22, scrabble.score("quirky"));
        }

        [Test]
        public void shouldScoreRussianLetters() {
            Scrabble scrabble = new Scrabble();
            Assert.AreEqual(18, scrabble.score("дврфъ"));
        }

        [Test]
        public void shouldScoreGreekLetters() {
            Scrabble scrabble = new Scrabble();
            Assert.AreEqual(20, scrabble.score("φεψωλ"));
        }
    }
}