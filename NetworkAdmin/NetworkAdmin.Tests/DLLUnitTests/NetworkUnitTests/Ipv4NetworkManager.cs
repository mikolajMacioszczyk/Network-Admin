using System.Linq;
using NetworkAdmin.IpAddress.Ipv4;
using NetworkAdmin.Network;
using NUnit.Framework;

namespace NetworkAdmin.Tests.DLLUnitTests.NetworkUnitTests
{
    [TestFixture]
    public class Ipv4NetworkManager
    {
        private INetworkManager<Ipv4Address> _manager;
        
        [SetUp]
        public void SetUp()
        {
            _manager = new Network.Ipv4NetworkManager();
        }
        
        [Test]
        public void GetBroadcastAddress_HostAddress()
        {
            // arrange
            var inputAdr = new Ipv4Address(192,168,0,1);
            ushort networkPortion = 26;
            var expected = new Ipv4Address(192,168,0,63);
            
            // act
            var result = _manager.GetBroadcastAddress(inputAdr, networkPortion);

            // assert
            Assert.NotNull(result);
            Assert.True(expected.ToDecimal().SequenceEqual(result.ToDecimal()));
        }
        
        [Test]
        public void GetBroadcastAddress_NetworkAddress()
        {
            // arrange
            var inputAdr = new Ipv4Address(192,168,0,0);
            ushort networkPortion = 26;
            var expected = new Ipv4Address(192,168,0,63);
            
            // act
            var result = _manager.GetBroadcastAddress(inputAdr, networkPortion);

            // assert
            Assert.NotNull(result);
            Assert.True(expected.ToDecimal().SequenceEqual(result.ToDecimal()));
        }
        
        [Test]
        public void GetBroadcastAddress_BroadcastAddress()
        {
            // arrange
            var inputAdr = new Ipv4Address(192,168,0,63);
            ushort networkPortion = 26;
            var expected = new Ipv4Address(192,168,0,63);
            
            // act
            var result = _manager.GetBroadcastAddress(inputAdr, networkPortion);

            // assert
            Assert.NotNull(result);
            Assert.True(expected.ToDecimal().SequenceEqual(result.ToDecimal()));
        }
        
        [Test]
        public void GetNetworkAddress_HostAddress()
        {
            // arrange
            var inputAdr = new Ipv4Address(192,168,0,1);
            ushort networkPortion = 26;
            var expected = new Ipv4Address(192,168,0,0);
            
            // act
            var result = _manager.GetNetworkAddress(inputAdr, networkPortion);

            // assert
            Assert.NotNull(result);
            Assert.True(expected.ToDecimal().SequenceEqual(result.ToDecimal()));
        }
        
        [Test]
        public void GetNetworkAddress_NetworkAddress()
        {
            // arrange
            var inputAdr = new Ipv4Address(192,168,0,0);
            ushort networkPortion = 26;
            var expected = new Ipv4Address(192,168,0,0);
            
            // act
            var result = _manager.GetNetworkAddress(inputAdr, networkPortion);

            // assert
            Assert.NotNull(result);
            Assert.True(expected.ToDecimal().SequenceEqual(result.ToDecimal()));
        }
        
        [Test]
        public void GetNetworkAddress_BroadcastAddress()
        {
            // arrange
            var inputAdr = new Ipv4Address(192,168,0,63);
            ushort networkPortion = 26;
            var expected = new Ipv4Address(192,168,0,0);
            
            // act
            var result = _manager.GetNetworkAddress(inputAdr, networkPortion);

            // assert
            Assert.NotNull(result);
            Assert.True(expected.ToDecimal().SequenceEqual(result.ToDecimal()));
        }
        
        [Test]
        public void GetFirstHostAddress_HostAddress()
        {
            // arrange
            var inputAdr = new Ipv4Address(192,168,0,1);
            ushort networkPortion = 26;
            var expected = new Ipv4Address(192,168,0,1);
            
            // act
            var result = _manager.GetFirstHostAddress(inputAdr, networkPortion);

            // assert
            Assert.NotNull(result);
            Assert.True(expected.ToDecimal().SequenceEqual(result.ToDecimal()));
        }
        
        [Test]
        public void GetFirstHostAddress_NetworkAddress()
        {
            // arrange
            var inputAdr = new Ipv4Address(192,168,0,0);
            ushort networkPortion = 26;
            var expected = new Ipv4Address(192,168,0,1);
            
            // act
            var result = _manager.GetFirstHostAddress(inputAdr, networkPortion);

            // assert
            Assert.NotNull(result);
            Assert.True(expected.ToDecimal().SequenceEqual(result.ToDecimal()));
        }
        
        [Test]
        public void GetFirstHostAddress_BroadcastAddress()
        {
            // arrange
            var inputAdr = new Ipv4Address(192,168,0,63);
            ushort networkPortion = 26;
            var expected = new Ipv4Address(192,168,0,1);
            
            // act
            var result = _manager.GetFirstHostAddress(inputAdr, networkPortion);

            // assert
            Assert.NotNull(result);
            Assert.True(expected.ToDecimal().SequenceEqual(result.ToDecimal()));
        }
        
        [Test]
        public void GetLastHostAddress_HostAddress()
        {
            // arrange
            var inputAdr = new Ipv4Address(192,168,0,1);
            ushort networkPortion = 26;
            var expected = new Ipv4Address(192,168,0,62);
            
            // act
            var result = _manager.GetLastHostAddress(inputAdr, networkPortion);

            // assert
            Assert.NotNull(result);
            Assert.True(expected.ToDecimal().SequenceEqual(result.ToDecimal()));
        }
        
        [Test]
        public void GetLastHostAddress_NetworkAddress()
        {
            // arrange
            var inputAdr = new Ipv4Address(192,168,0,0);
            ushort networkPortion = 26;
            var expected = new Ipv4Address(192,168,0,62);
            
            // act
            var result = _manager.GetLastHostAddress(inputAdr, networkPortion);

            // assert
            Assert.NotNull(result);
            Assert.True(expected.ToDecimal().SequenceEqual(result.ToDecimal()));
        }
        
        [Test]
        public void GetLastHostAddress_BroadcastAddress()
        {
            // arrange
            var inputAdr = new Ipv4Address(192,168,0,63);
            ushort networkPortion = 26;
            var expected = new Ipv4Address(192,168,0,62);
            
            // act
            var result = _manager.GetLastHostAddress(inputAdr, networkPortion);

            // assert
            Assert.NotNull(result);
            Assert.True(expected.ToDecimal().SequenceEqual(result.ToDecimal()));
        }
    }
}