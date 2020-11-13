using System.Collections.Generic;
using System.Linq;
using NetworkAdmin.IpAddress.Ipv4;
using NetworkAdmin.IpAddress.Utils;
using NUnit.Framework;

namespace NetworkAdmin.Tests.DLLUnitTests.IpAddressTests
{
    [TestFixture]
    public class Ipv4AddressTests
    {
        [Test]
        public void Constructor_FromBoolArray()
        {
            // arrange
            var utils = new Ipv4AddressUtils();
            ushort firstOctet = 192;
            ushort secondOctet = 0;
            ushort thirdOctet = 255;
            ushort fourthOctet = 127;
            var input = new List<bool>(utils.GetSingleOctetBinaryFromDecimal(firstOctet));
            input.AddRange(utils.GetSingleOctetBinaryFromDecimal(secondOctet));
            input.AddRange(utils.GetSingleOctetBinaryFromDecimal(thirdOctet));
            input.AddRange(utils.GetSingleOctetBinaryFromDecimal(fourthOctet));
            
            // act
            Ipv4Address address = new Ipv4Address(input.ToArray());
            
            // assert
            Assert.NotNull(address);
            Assert.AreEqual(firstOctet, address.FirstOctet);
            Assert.AreEqual(secondOctet, address.SecondOctet);
            Assert.AreEqual(thirdOctet, address.ThirdOctet);
            Assert.AreEqual(fourthOctet, address.FourthOctet);
        }
        
        [Test]
        public void Constructor_FromDecimal()
        {
            // arrange
            ushort firstOctet = 192;
            ushort secondOctet = 0;
            ushort thirdOctet = 255;
            ushort fourthOctet = 127;
            
            // act
            var address = new Ipv4Address(firstOctet,secondOctet,thirdOctet,fourthOctet);
            
            // assert
            Assert.NotNull(address);
            Assert.AreEqual(firstOctet, address.FirstOctet);
            Assert.AreEqual(secondOctet, address.SecondOctet);
            Assert.AreEqual(thirdOctet, address.ThirdOctet);
            Assert.AreEqual(fourthOctet, address.FourthOctet);
        }
        
        [Test]
        public void Constructor_Copy()
        {
            // arrange
            ushort firstOctet = 192;
            ushort secondOctet = 0;
            ushort thirdOctet = 255;
            ushort fourthOctet = 127;
            var input = new Ipv4Address(firstOctet,secondOctet,thirdOctet,fourthOctet);
            
            // act
            var address = new Ipv4Address(input);
            
            // assert
            Assert.NotNull(address);
            Assert.AreEqual(firstOctet, address.FirstOctet);
            Assert.AreEqual(secondOctet, address.SecondOctet);
            Assert.AreEqual(thirdOctet, address.ThirdOctet);
            Assert.AreEqual(fourthOctet, address.FourthOctet);
        }
        
        [Test]
        public void ToBinary_Test()
        {
            // arrange
            var utils = new Ipv4AddressUtils();
            ushort firstOctet = 192;
            ushort secondOctet = 0;
            ushort thirdOctet = 255;
            ushort fourthOctet = 127;
            var expected = new List<bool>(utils.GetSingleOctetBinaryFromDecimal(firstOctet));
            expected.AddRange(utils.GetSingleOctetBinaryFromDecimal(secondOctet));
            expected.AddRange(utils.GetSingleOctetBinaryFromDecimal(thirdOctet));
            expected.AddRange(utils.GetSingleOctetBinaryFromDecimal(fourthOctet));
            var address = new Ipv4Address(192,0,255,127);
            
            // act
            var result = address.ToBinary();
            
            // assert
            Assert.NotNull(result);
            Assert.True(expected.SequenceEqual(result));
        }
        
        [Test]
        public void ToDecimal_Test()
        {
            // arrange
            var expected = new ushort[] { 192,0,255,127 };
            var address = new Ipv4Address(expected[0], expected[1], expected[2], expected[3]);
            
            // act
            var result = address.ToDecimal();

            // assert
            Assert.NotNull(result);
            Assert.True(expected.SequenceEqual(result));
        }
        
        [Test]
        public void OperatorLess_LeftLessThanRight()
        {
            // arrange
            var first = new Ipv4Address(192,168,1,1);
            var second = new Ipv4Address(192,168,1,2);
            
            // act
            var result = first < second;

            // assert
            Assert.True(result);
        }
        
        [Test]
        public void OperatorLess_LeftEqualRight()
        {
            // arrange
            var first = new Ipv4Address(192,168,1,1);
            var second = new Ipv4Address(192,168,1,1);
            
            // act
            var result = first < second;

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void OperatorLess_LeftGreaterThanRight()
        {
            // arrange
            var first = new Ipv4Address(192,168,1,2);
            var second = new Ipv4Address(192,168,1,1);
            
            // act
            var result = first < second;

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void OperatorLessEqual_LeftLessThanRight()
        {
            // arrange
            var first = new Ipv4Address(192,168,1,1);
            var second = new Ipv4Address(192,168,1,2);
            
            // act
            var result = first < second;

            // assert
            Assert.True(result);
        }
        
        [Test]
        public void OperatorLessEqual_LeftEqualRight()
        {
            // arrange
            var first = new Ipv4Address(192,168,1,1);
            var second = new Ipv4Address(192,168,1,1);
            
            // act
            var result = first <= second;

            // assert
            Assert.True(result);
        }
        
        [Test]
        public void OperatorLessEqual_LeftGreaterThanRight()
        {
            // arrange
            var first = new Ipv4Address(192,168,1,2);
            var second = new Ipv4Address(192,168,1,1);
            
            // act
            var result = first <= second;

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void OperatorEqual_Equal()
        {
            // arrange
            var first = new Ipv4Address(192,168,1,1);
            var second = new Ipv4Address(192,168,1,1);
            
            // act
            var result = first == second;

            // assert
            Assert.True(result);
        }
        
        [Test]
        public void OperatorEqual_NotEqual()
        {
            // arrange
            var first = new Ipv4Address(192,168,2,1);
            var second = new Ipv4Address(192,168,1,1);
            
            // act
            var result = first == second;

            // assert
            Assert.False(result);
        }
    }
}