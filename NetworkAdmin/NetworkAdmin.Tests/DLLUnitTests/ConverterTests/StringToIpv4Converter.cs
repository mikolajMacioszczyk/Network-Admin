using NetworkAdmin.Converters.StringToIpv4;
using NetworkAdmin.Exceptions;
using NUnit.Framework;

namespace NetworkAdmin.Tests.ConverterTests
{
    [TestFixture]
    public class StringToIpv4Converter
    {
        private IStringToIpv4Converter _converter;
        
        [SetUp]
        public void SetUp()
        {
            _converter = new Converters.StringToIpv4.StringToIpv4Converter();
        }
        
        [Test]
        public void ConvertFromDecimal_ValidIp()
        {
            // arrange
            var input = "192.168.1.1";
            ushort firstOctet = 192;
            ushort secondOctet = 168;
            ushort thirdOctet = 1;
            ushort fourthOctet = 1;
            // act
            var result = _converter.ConvertFromDecimal(input);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(firstOctet, result.FirstOctet);
            Assert.AreEqual(secondOctet, result.SecondOctet);
            Assert.AreEqual(thirdOctet, result.ThirdOctet);
            Assert.AreEqual(fourthOctet, result.FourthOctet);
        }
        
        [Test]
        public void ConvertFromDecimal_ValidIp2_ExtremeValues()
        {
            // arrange
            var input = "192.168.0.255";
            ushort firstOctet = 192;
            ushort secondOctet = 168;
            ushort thirdOctet = 0;
            ushort fourthOctet = 255;
            // act
            var result = _converter.ConvertFromDecimal(input);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(firstOctet, result.FirstOctet);
            Assert.AreEqual(secondOctet, result.SecondOctet);
            Assert.AreEqual(thirdOctet, result.ThirdOctet);
            Assert.AreEqual(fourthOctet, result.FourthOctet);
        }
        
        [Test]
        public void ConvertFromDecimal_InvalidNumberOfOctets_ToMuch()
        {
            // arrange
            var input = "192.168.1.1.2";
            // act
            Assert.Throws<IncorrectIpv4AddressException>(() => _converter.ConvertFromDecimal(input));
        }
        
        [Test]
        public void ConvertFromDecimal_InvalidNumberOfOctets_ToLow()
        {
            // arrange
            var input = "192.168.1";
            // act
            Assert.Throws<IncorrectIpv4AddressException>(() => _converter.ConvertFromDecimal(input));
        }
        
        [Test]
        public void ConvertFromDecimal_InvalidInput_Null()
        {
            // arrange
            string input = null;
            // act
            Assert.Throws<IncorrectIpv4AddressException>(() => _converter.ConvertFromDecimal(input));
        }
        
        [Test]
        public void ConvertFromDecimal_OctetNumberOutOfRange_Negative()
        {
            // arrange
            string input = "192.168.-2.1";
            // act
            Assert.Throws<IncorrectIpv4AddressException>(() => _converter.ConvertFromDecimal(input));
        }
        
        [Test]
        public void ConvertFromDecimal_OctetNumberOutOfRange_ToHigh()
        {
            // arrange
            string input = "192.168.256.1";
            // act
            Assert.Throws<IncorrectIpv4AddressException>(() => _converter.ConvertFromDecimal(input));
        }

        [Test]
        public void ConvertFromBinary_ValidInput()
        {
            // arrange
            string input = "10101010.10101010.10101010.10101010";
            var firstOctet = 170;
            var secondOctet = 170;
            var thirdOctet = 170;
            var fourthOctet = 170;
            
            // act
            var result = _converter.ConvertFromBinary(input);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(firstOctet, result.FirstOctet);
            Assert.AreEqual(secondOctet, result.SecondOctet);
            Assert.AreEqual(thirdOctet, result.ThirdOctet);
            Assert.AreEqual(fourthOctet, result.FourthOctet);
        }
        
        [Test]
        public void ConvertFromBinary_InvalidNumberOfOctets_ToMuch()
        {
            // arrange
            var input = "10101010.10101010.10101010.10101010.10101010";
            // act
            Assert.Throws<IncorrectIpv4AddressException>(() => _converter.ConvertFromBinary(input));
        }
        
        [Test]
        public void ConvertFromBinary_InvalidNumberOfOctets_ToLow()
        {
            // arrange
            var input = "10101010.10101010.10101010";
            // act
            Assert.Throws<IncorrectIpv4AddressException>(() => _converter.ConvertFromBinary(input));
        }
        
        [Test]
        public void ConvertFromBinary_InvalidInput_Null()
        {
            // arrange
            string input = null;
            // act
            Assert.Throws<IncorrectIpv4AddressException>(() => _converter.ConvertFromBinary(input));
        }
        
        [Test]
        public void ConvertFromBinary_NotAllowedCharacter()
        {
            // arrange
            string input = "10101010.10101012.10101010.10101010";
            // act
            Assert.Throws<IncorrectIpv4AddressException>(() => _converter.ConvertFromBinary(input));
        }
    }
}