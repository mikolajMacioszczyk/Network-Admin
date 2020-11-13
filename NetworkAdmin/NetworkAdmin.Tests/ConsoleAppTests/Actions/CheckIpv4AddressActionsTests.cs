using Moq;
using NetworkAdmin.ConsoleApp.Actions;
using NUnit.Framework;

namespace NetworkAdmin.Tests.ConsoleAppTests.Actions
{
    public class CheckIpv4AddressActionsTests
    {
        [Test]
        public void GetClassAddress_ClassA()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.Setup(m => m.ReadString()).Returns("20.1.1.1");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Address belong to the class A";
            
            // act
            var result = actions.GetClassAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetClassAddress_Special()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.Setup(m => m.ReadString()).Returns("127.1.1.1");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "This is special address";
            
            // act
            var result = actions.GetClassAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetLastHostAddress_ClassC_NetworkPortion24()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("200.1.1.1").Returns("24");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Last host address = 200.1.1.254";
            
            // act
            var result = actions.GetLastHostAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetLastHostAddress_ClassC_NetworkPortion28()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("200.1.129.129").Returns("28");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Last host address = 200.1.129.142";
            
            // act
            var result = actions.GetLastHostAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetLastHostAddress_Special()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("127.1.1.1").Returns("24");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Last host address = 127.1.1.1";
            
            // act
            var result = actions.GetLastHostAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetFirstHostAddress_ClassB_NetworkPortion16()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("140.1.1.1").Returns("16");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "First host address = 140.1.0.1";
            
            // act
            var result = actions.GetFirstHostAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetFirstHostAddress_ClassB_NetworkPortion28()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("140.1.1.131").Returns("28");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "First host address = 140.1.1.129";
            
            // act
            var result = actions.GetFirstHostAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetFirstHostAddress_Special()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("127.1.1.1").Returns("24");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "First host address = 127.1.1.1";
            
            // act
            var result = actions.GetFirstHostAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetBroadcastAddress_ClassB_NetworkPortion16()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("140.1.1.1").Returns("16");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Broadcast address = 140.1.255.255";
            
            // act
            var result = actions.GetBroadcastAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetBroadcastAddress_ClassB_NetworkPortion28()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("140.1.1.131").Returns("28");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Broadcast address = 140.1.1.143";
            
            // act
            var result = actions.GetBroadcastAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetBroadcastHostAddress_Special()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("127.1.1.1").Returns("24");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Broadcast address = 127.1.1.1";
            
            // act
            var result = actions.GetBroadcastAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetNetworkAddress_ClassB_NetworkPortion16()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("140.1.1.1").Returns("16");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Network address = 140.1.0.0";
            
            // act
            var result = actions.GetNetworkAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetNetworkAddress_ClassB_NetworkPortion28()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("140.1.1.131").Returns("28");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Network address = 140.1.1.128";
            
            // act
            var result = actions.GetNetworkAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetNetworkAddress_Special()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("127.1.1.1").Returns("24");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Network address = 127.1.1.1";
            
            // act
            var result = actions.GetNetworkAddress();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ServeGetAddressType_Public()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("20.1.1.1");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Address type: Public";
            
            // act
            var result = actions.ServeGetAddressType();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ServeGetAddressType_Loopback()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("127.255.255.255");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Address type: Loopback";
            
            // act
            var result = actions.ServeGetAddressType();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ServeIsHostValid_FirstAddress()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("20.128.0.1").Returns("9");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Host address is correct.";
            
            // act
            var result = actions.ServeIsHostValid();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ServeIsHostValid_LastAddress()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("20.255.255.254").Returns("9");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Host address is correct.";
            
            // act
            var result = actions.ServeIsHostValid();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ServeIsHostValid_OrdinaryHostAddress()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("20.125.125.125").Returns("9");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Host address is correct.";
            
            // act
            var result = actions.ServeIsHostValid();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ServeIsHostValid_BroadcastAddress()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("20.255.255.255").Returns("9");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Host address is incorrect.";
            
            // act
            var result = actions.ServeIsHostValid();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ServeIsHostValid_NetworkAddress()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("20.0.0.0").Returns("9");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Host address is incorrect.";
            
            // act
            var result = actions.ServeIsHostValid();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ServeIsHostValid_ClassD()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("230.10.10.10").Returns("24");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Host address is incorrect.";
            
            // act
            var result = actions.ServeIsHostValid();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void ServeIsHostValid_Special()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("0.10.10.10").Returns("24");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Host address is incorrect.";
            
            // act
            var result = actions.ServeIsHostValid();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void SubnetNetworkBitCount_0()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("10.10.10.10").Returns("8");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Subnet network bit count = 0";
            
            // act
            var result = actions.SubnetNetworkBitCount();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void SubnetNetworkBitCount_SubnetOccur()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("10.10.10.10").Returns("10");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Subnet network bit count = 2";
            
            // act
            var result = actions.SubnetNetworkBitCount();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void HostBitCount_Max()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("10.10.10.10").Returns("8");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Host bit count = 24";
            
            // act
            var result = actions.GetHostBitCount();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void SubnetNetworkBitCount_Min()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("10.10.10.10").Returns("30");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Host bit count = 2";
            
            // act
            var result = actions.GetHostBitCount();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetPossibleSubnetsCount_0()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("10.10.10.10").Returns("8");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Possible subnets = 1";
            
            // act
            var result = actions.GetPossibleSubnetsCount();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetPossibleSubnetsCount_16()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("10.10.10.10").Returns("12");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Possible subnets = 16";
            
            // act
            var result = actions.GetPossibleSubnetsCount();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetPossibleHostCount_Max()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("199.10.10.10").Returns("24");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Possible hosts = 254";
            
            // act
            var result = actions.GetPossibleHostCount();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetPossibleHostCount_Middle()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("199.10.10.10").Returns("28");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Possible hosts = 14";
            
            // act
            var result = actions.GetPossibleHostCount();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetPossibleHostCount_0()
        {
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("199.10.10.10").Returns("31");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Possible hosts = 0";
            
            // act
            var result = actions.GetPossibleHostCount();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void DecimalFromBinary()
        {   
            // arrange
            var mockKeyboardInteraction = new Mock<MockKeyboardInteraction>();
            mockKeyboardInteraction.SetupSequence(m => m.ReadString()).Returns("1010101010.1010101010.1010101010.1010101010");
            var actions = new CheckIpv4AddressActions(mockKeyboardInteraction.Object);
            var expected = "Decimal Representation: 170.170.170.170";
            
            // act
            var result = actions.DecimalFromBinary();

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
    }
}