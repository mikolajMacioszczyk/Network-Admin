using System.Linq;
using NetworkAdmin.IpAddress.Ipv4;
using NetworkAdmin.IpAddress.Range.IPv4;
using NetworkAdmin.IpAddress.Utils;
using NUnit.Framework;

namespace NetworkAdmin.Tests.DLLUnitTests.IpAddressTests
{
    [TestFixture]
    public class Ipv4AddressUtilsTests
    {
        private IPAddressUtils<Ipv4Address> _utils;
        
        [SetUp]
        public void SetUp()
        {
            _utils = new Ipv4AddressUtils();
        }
        
        [Test]
        public void IsLegalHostAddress_LegalA()
        {
            // arrange
            var input = new Ipv4Address(20,168,0,0);
            ushort inputNetPortion = 8;
            
            // act
            var result = _utils.IsLegalHostAddress(input, inputNetPortion);

            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsLegalHostAddress_LegalC()
        {
            // arrange
            var input = new Ipv4Address(192,168,1,1);
            ushort inputNetPortion = 24;
            
            // act
            var result = _utils.IsLegalHostAddress(input, inputNetPortion);

            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsLegalHostAddress_Illegal_Broadcast()
        {
            // arrange
            var input = new Ipv4Address(192,168,1,127);
            ushort inputNetPortion = 25;
            
            // act
            var result = _utils.IsLegalHostAddress(input, inputNetPortion);

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsLegalHostAddress_Illegal_Network()
        {
            // arrange
            var input = new Ipv4Address(192,168,1,128);
            ushort inputNetPortion = 26;
            
            // act
            var result = _utils.IsLegalHostAddress(input, inputNetPortion);

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsLegalHostAddress_Illegal_ClassD()
        {
            // arrange
            var input = new Ipv4Address(225,168,1,128);
            ushort inputNetPortion = 24;
            
            // act
            var result = _utils.IsLegalHostAddress(input, inputNetPortion);

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsLegalHostAddress_Illegal_ClassE()
        {
            // arrange
            var input = new Ipv4Address(241,168,1,128);
            ushort inputNetPortion = 24;
            
            // act
            var result = _utils.IsLegalHostAddress(input, inputNetPortion);

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsLegalHostAddress_Illegal_Loopback()
        {
            // arrange
            var input = new Ipv4Address(127,168,1,128);
            ushort inputNetPortion = 24;
            
            // act
            var result = _utils.IsLegalHostAddress(input, inputNetPortion);

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsLegalHostAddress_Illegal_Software()
        {
            // arrange
            var input = new Ipv4Address(0,168,1,128);
            ushort inputNetPortion = 24;
            
            // act
            var result = _utils.IsLegalHostAddress(input, inputNetPortion);

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsLegalHostAddress_Illegal_NetworkPortionTooLow()
        {
            // arrange
            var input = new Ipv4Address(125,168,1,128);
            ushort inputNetPortion = 2;
            
            // act
            var result = _utils.IsLegalHostAddress(input, inputNetPortion);

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsLegalHostAddress_Illegal_NetworkPortionTooHigh()
        {
            // arrange
            var input = new Ipv4Address(125,168,1,128);
            ushort inputNetPortion = 40;
            
            // act
            var result = _utils.IsLegalHostAddress(input, inputNetPortion);

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsValidNetworkPortion_ClassA_Valid()
        {
            // arrange
            var inputAddr = new Ipv4Address(20,1,1,1);
            var inputNetworkPortion = 8;
            
            // act
            var result = _utils.IsValidNetworkPortion(inputAddr, inputNetworkPortion);
            
            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsValidNetworkPortion_ClassA_Valid2()
        {
            // arrange
            var inputAddr = new Ipv4Address(20,1,1,1);
            var inputNetworkPortion = 28;
            
            // act
            var result = _utils.IsValidNetworkPortion(inputAddr, inputNetworkPortion);
            
            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsValidNetworkPortion_ClassA_InValid_TooLow()
        {
            // arrange
            var inputAddr = new Ipv4Address(20,1,1,1);
            var inputNetworkPortion = 7;
            
            // act
            var result = _utils.IsValidNetworkPortion(inputAddr, inputNetworkPortion);
            
            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsValidNetworkPortion_ClassA_InValid_TooHigh()
        {
            // arrange
            var inputAddr = new Ipv4Address(20,1,1,1);
            var inputNetworkPortion = 32;
            
            // act
            var result = _utils.IsValidNetworkPortion(inputAddr, inputNetworkPortion);
            
            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsValidNetworkPortion_ClassB_Valid()
        {
            // arrange
            var inputAddr = new Ipv4Address(130,1,1,1);
            var inputNetworkPortion = 18;
            
            // act
            var result = _utils.IsValidNetworkPortion(inputAddr, inputNetworkPortion);
            
            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsValidNetworkPortion_ClassB_Valid2()
        {
            // arrange
            var inputAddr = new Ipv4Address(130,1,1,1);
            var inputNetworkPortion = 28;
            
            // act
            var result = _utils.IsValidNetworkPortion(inputAddr, inputNetworkPortion);
            
            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsValidNetworkPortion_ClassV_InValid_TooLow()
        {
            // arrange
            var inputAddr = new Ipv4Address(130,1,1,1);
            var inputNetworkPortion = 15;
            
            // act
            var result = _utils.IsValidNetworkPortion(inputAddr, inputNetworkPortion);
            
            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsValidNetworkPortion_ClassB_InValid_TooHigh()
        {
            // arrange
            var inputAddr = new Ipv4Address(130,1,1,1);
            var inputNetworkPortion = 32;
            
            // act
            var result = _utils.IsValidNetworkPortion(inputAddr, inputNetworkPortion);
            
            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsValidNetworkPortion_ClassC_Valid()
        {
            // arrange
            var inputAddr = new Ipv4Address(200,1,1,1);
            var inputNetworkPortion = 24;
            
            // act
            var result = _utils.IsValidNetworkPortion(inputAddr, inputNetworkPortion);
            
            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsValidNetworkPortion_ClassC_Valid2()
        {
            // arrange
            var inputAddr = new Ipv4Address(200,1,1,1);
            var inputNetworkPortion = 28;
            
            // act
            var result = _utils.IsValidNetworkPortion(inputAddr, inputNetworkPortion);
            
            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsValidNetworkPortion_ClassC_InValid_TooLow()
        {
            // arrange
            var inputAddr = new Ipv4Address(200,1,1,1);
            var inputNetworkPortion = 23;
            
            // act
            var result = _utils.IsValidNetworkPortion(inputAddr, inputNetworkPortion);
            
            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsValidNetworkPortion_ClassC_InValid_TooHigh()
        {
            // arrange
            var inputAddr = new Ipv4Address(200,1,1,1);
            var inputNetworkPortion = 32;
            
            // act
            var result = _utils.IsValidNetworkPortion(inputAddr, inputNetworkPortion);
            
            // assert
            Assert.False(result);
        }
        
        [Test]
        public void GetAddressRange_SoftwareAddressMin()
        {
            // arrange
            var input = new Ipv4Address(0,0,0,0);
            var expected = new SoftwareIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_SoftwareAddressMax()
        {
            // arrange
            var input = new Ipv4Address(0,255,255,255);
            var expected = new SoftwareIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMin_FirstRange()
        {
            // arrange
            var input = new Ipv4Address(1,0,0,0);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMax_FirstRange()
        {
            // arrange
            var input = new Ipv4Address(9,255,255,255);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PrivateAddressMin_FirstRange()
        {
            // arrange
            var input = new Ipv4Address(10,0,0,0);
            var expected = new PrivateIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PrivateAddressMax_FirstRange()
        {
            // arrange
            var input = new Ipv4Address(10,255,255,255);
            var expected = new PrivateIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMin_2Range()
        {
            // arrange
            var input = new Ipv4Address(11,0,0,0);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMax_2Range()
        {
            // arrange
            var input = new Ipv4Address(100,63,255,255);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PrivateAddressMin_2Range()
        {
            // arrange
            var input = new Ipv4Address(100,64,0,0);
            var expected = new PrivateIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PrivateAddressMax_2Range()
        {
            // arrange
            var input = new Ipv4Address(100,127,255,255);
            var expected = new PrivateIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMin_3Range()
        {
            // arrange
            var input = new Ipv4Address(100,128,0,0);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMax_3Range()
        {
            // arrange
            var input = new Ipv4Address(126,255,255,255);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_LoopbackMin()
        {
            // arrange
            var input = new Ipv4Address(127,0,0,0);
            var expected = new LoopbackIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_LoopbackMax()
        {
            // arrange
            var input = new Ipv4Address(127,255,255,255);
            var expected = new LoopbackIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMin_4Range()
        {
            // arrange
            var input = new Ipv4Address(128,0,0,0);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMax_4Range()
        {
            // arrange
            var input = new Ipv4Address(169,253,255,255);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_LinkLocalMin_4Range()
        {
            // arrange
            var input = new Ipv4Address(169,254,0,0);
            var expected = new LinkLocalIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_LinkLocalMax_4Range()
        {
            // arrange
            var input = new Ipv4Address(169,254,255,255);
            var expected = new LinkLocalIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMin_5Range()
        {
            // arrange
            var input = new Ipv4Address(169,255,0,0);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMax_5Range()
        {
            // arrange
            var input = new Ipv4Address(191,255,255,255);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PrivateAddressMin_3Range()
        {
            // arrange
            var input = new Ipv4Address(192,0,0,0);
            var expected = new PrivateIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PrivateAddressMax_3Range()
        {
            // arrange
            var input = new Ipv4Address(192,0,0,255);
            var expected = new PrivateIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMin_6Range()
        {
            // arrange
            var input = new Ipv4Address(192,0,1,0);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMax_6Range()
        {
            // arrange
            var input = new Ipv4Address(192,0,1,255);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_DocumentationAddressMin_1Range()
        {
            // arrange
            var input = new Ipv4Address(192,0,2,0);
            var expected = new DocumentationIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_DocumentationAddressMax_1Range()
        {
            // arrange
            var input = new Ipv4Address(192,0,2,255);
            var expected = new DocumentationIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMin_7Range()
        {
            // arrange
            var input = new Ipv4Address(192,0,3,0);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMax_7Range()
        {
            // arrange
            var input = new Ipv4Address(192,88,98,255);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_Ipv6RelayAddressMin()
        {
            // arrange
            var input = new Ipv4Address(192,88,99,0);
            var expected = new Ipv6Relay();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_Ipv6RelayAddressMax()
        {
            // arrange
            var input = new Ipv4Address(192,88,99,255);
            var expected = new Ipv6Relay();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMin_8Range()
        {
            // arrange
            var input = new Ipv4Address(192,89,0,0);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMax_8Range()
        {
            // arrange
            var input = new Ipv4Address(192,167,255,255);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PrivateAddressMin_4Range()
        {
            // arrange
            var input = new Ipv4Address(192,168,0,0);
            var expected = new PrivateIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PrivateAddressMax_4Range()
        {
            // arrange
            var input = new Ipv4Address(192,168,255,255);
            var expected = new PrivateIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMin_9Range()
        {
            // arrange
            var input = new Ipv4Address(192,169,0,0);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMax_9Range()
        {
            // arrange
            var input = new Ipv4Address(198,17,255,255);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PrivateAddressMin_5Range()
        {
            // arrange
            var input = new Ipv4Address(198,18,0,0);
            var expected = new PrivateIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PrivateAddressMax_5Range()
        {
            // arrange
            var input = new Ipv4Address(198, 19, 255, 255);
            var expected = new PrivateIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMin_10Range()
        {
            // arrange
            var input = new Ipv4Address(198,20,0,0);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMax_10Range()
        {
            // arrange
            var input = new Ipv4Address(198,51,99,255);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_DocumentationAddressMin_2Range()
        {
            // arrange
            var input = new Ipv4Address(198,51,100,0);
            var expected = new DocumentationIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_DocumentationAddressMax_2Range()
        {
            // arrange
            var input = new Ipv4Address(198,51,100,255);
            var expected = new DocumentationIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMin_11Range()
        {
            // arrange
            var input = new Ipv4Address(198,51,101,0);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMax_11Range()
        {
            // arrange
            var input = new Ipv4Address(198,51,101,0);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_DocumentationAddressMin_3Range()
        {
            // arrange
            var input = new Ipv4Address(203,0,113,0);
            var expected = new DocumentationIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_DocumentationAddressMax_3Range()
        {
            // arrange
            var input = new Ipv4Address(203,0,113,255);
            var expected = new DocumentationIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMin_12Range()
        {
            // arrange
            var input = new Ipv4Address(203,0,114,0);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_PublicAddressMax_12Range()
        {
            // arrange
            var input = new Ipv4Address(223,255,255,255);
            var expected = new PublicIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_MulticastAddressMin()
        {
            // arrange
            var input = new Ipv4Address(224,0,0,0);
            var expected = new MulticastIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_MulticastAddressMax()
        {
            // arrange
            var input = new Ipv4Address(239,255,255,255);
            var expected = new MulticastIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_FutureAddressMin()
        {
            // arrange
            var input = new Ipv4Address(240,0,0,0);
            var expected = new FutureIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_FutureAddressMax()
        {
            // arrange
            var input = new Ipv4Address(255,255,255,254);
            var expected = new FutureIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetAddressRange_LimitedBroadCastAddress()
        {
            // arrange
            var input = new Ipv4Address(255,255,255,255);
            var expected = new LimitedBroadcastIpv4Range();

            // act
            var result = _utils.GetAddressRange(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetSingleOctetDecimalFromBinary_all0()
        {        
            // arrange
            var input = new bool[8]{false,false,false,false,false,false,false,false};
            var expected = 0;
            
            // act
            var result = _utils.GetSingleOctetDecimalFromBinary(input);
            
            // assert
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetSingleOctetDecimalFromBinary_all1()
        {        
            // arrange
            var input = new bool[8]{true,true,true,true,true,true,true,true};
            var expected = 255;
            
            // act
            var result = _utils.GetSingleOctetDecimalFromBinary(input);
            
            // assert
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetSingleOctetDecimalFromBinary_69()
        {        
            // arrange
            var input = new bool[8]{false,true,false,false,false,true,false,true};
            var expected = 69;
            
            // act
            var result = _utils.GetSingleOctetDecimalFromBinary(input);
            
            // assert
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetSingleOctetBinaryFromDecimal_all0()
        {        
            // arrange
            var expected = new bool[8]{false,false,false,false,false,false,false,false};
            ushort input = 0;
            
            // act
            var result = _utils.GetSingleOctetBinaryFromDecimal(input);
            
            // assert
            Assert.NotNull(result);
            Assert.True(expected.SequenceEqual(result));
        }
        
        [Test]
        public void GetSingleOctetBinaryFromDecimal_all1()
        {        
            // arrange
            var expected = new bool[8]{true,true,true,true,true,true,true,true};
            ushort input = 255;
            
            // act
            var result = _utils.GetSingleOctetBinaryFromDecimal(input);
            
            // assert
            Assert.NotNull(result);
            Assert.True(expected.SequenceEqual(result));
        }
        
        [Test]
        public void GetSingleOctetBinaryFromDecimal_69()
        {
            // arrange
            var expected = new bool[8]{false,true,false,false,false,true,false,true};
            ushort input = 69;
            
            // act
            var result = _utils.GetSingleOctetBinaryFromDecimal(input);
            
            // assert
            Assert.NotNull(result);
            Assert.True(expected.SequenceEqual(result));
        }
        
        [Test]
        public void BinaryIpToString_all0()
        {        
            // arrange
            var input = new bool[32]{false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false,false};
            string expected = "00000000.00000000.00000000.00000000";
            
            // act
            var result = _utils.BinaryIpToString(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected,result);
        }
        
        [Test]
        public void BinaryIpToString_all1()
        {        
            // arrange
            var input = new bool[32]{true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true,true};
            string expected = "11111111.11111111.11111111.11111111";
            
            // act
            var result = _utils.BinaryIpToString(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected,result);
        }
        
        [Test]
        public void BinaryIpToString_69()
        {
            // arrange
            var input = new bool[32]{false,true,false,false,false,true,false,true,false,true,false,false,false,true,false,true,false,true,false,false,false,true,false,true,false,true,false,false,false,true,false,true};
            string expected = "01000101.01000101.01000101.01000101";
            
            // act
            var result = _utils.BinaryIpToString(input);
            
            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected,result);
        }
    }
}