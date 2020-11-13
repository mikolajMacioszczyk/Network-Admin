using NetworkAdmin.IpAddress.Ipv4;
using NetworkAdmin.Ipv4Class;
using NetworkAdmin.Ipv4Class.Ipv4;
using NUnit.Framework;

namespace NetworkAdmin.Tests.DLLUnitTests.Ipv4ClassTests
{
    [TestFixture]
    public class Ipv4ClassNetworkManager
    {
        private IClassNetworkManager<Ipv4Address> _manager;
        
        [SetUp]
        public void SetUp()
        {
            _manager = new Ipv4Class.Ipv4ClassNetworkManager();
        }
        
        [Test]
        public void GetClass_Special1_MinBoundary()
        {
            // arrange
            var input = new Ipv4Address(0,0,0,0);
            var expected = new ClassSpecial();
            // act
            var result = _manager.GetClass(input);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetClass_Special1_Mid()
        {
            // arrange
            var input = new Ipv4Address(0,255,0,0);
            var expected = new ClassSpecial();
            // act
            var result = _manager.GetClass(input);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetClass_Special1_MaxBoundary()
        {
            // arrange
            var input = new Ipv4Address(0,255,255,255);
            var expected = new ClassSpecial();
            // act
            var result = _manager.GetClass(input);

            // assert
            Assert.NotNull(expected);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetClass_ClassA_MinBoundary()
        {
            // arrange
            var input = new Ipv4Address(1,0,0,0);
            var expected = new ClassA();
            // act
            var result = _manager.GetClass(input);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetClass_ClassA_Mid()
        {
            // arrange
            var input = new Ipv4Address(10,2,10,2);
            var expected = new ClassA();
            // act
            var result = _manager.GetClass(input);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void GetClass_ClassA_MaxBoundary()
        {
            // arrange
            var input = new Ipv4Address(126,0,0,0);
            var expected = new ClassA();
            // act
            var result = _manager.GetClass(input);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void SubnetBitCount_ValidData_ClassA()
        {
            // arrange
            var inputAddr = new ClassA();
            ushort inputLength = 15;
            var expected = 7;
            // act
            var result = _manager.SubnetBitCount(inputAddr, inputLength);

            // assert
            Assert.NotNull(result);
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void SubnetBitCount_InvalidData_ToLow_ClassA()
        {
            // arrange
            var inputClass = new ClassA();
            ushort inputLength = 5;
            var expected = 0;
            // act
            var result = _manager.SubnetBitCount(inputClass, inputLength);

            // assert
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void SubnetBitCount_InvalidData_ToHigh_ClassA()
        {
            // arrange
            var inputClass = new ClassA();
            ushort inputLength = 55;
            var expected = 0;
            // act
            var result = _manager.SubnetBitCount(inputClass, inputLength);

            // assert
            Assert.AreEqual(expected, result);
        }
        
        [Test]
        public void IsNetworkPortionValid_Valid_ClassA()
        {
            // arrange
            var inputClass = new ClassA();
            ushort inputLength = 8;
            // act
            var result = _manager.IsNetworkPortionValid(inputClass, inputLength);

            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsNetworkPortionValid_Valid2_ClassA()
        {
            // arrange
            var inputClass = new ClassA();
            ushort inputLength = 30;
            // act
            var result = _manager.IsNetworkPortionValid(inputClass, inputLength);

            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsNetworkPortionValid_InValid_ClassA_TooLow()
        {
            // arrange
            var inputClass = new ClassA();
            ushort inputLength = 7;
            // act
            var result = _manager.IsNetworkPortionValid(inputClass, inputLength);

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsNetworkPortionValid_InValid_ClassA_TooHigh()
        {
            // arrange
            var inputClass = new ClassA();
            ushort inputLength = 32;
            // act
            var result = _manager.IsNetworkPortionValid(inputClass, inputLength);

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsNetworkPortionValid_Valid_ClassB()
        {
            // arrange
            var networkClass = new ClassB();
            ushort inputLength = 16;
            // act
            var result = _manager.IsNetworkPortionValid(networkClass, inputLength);

            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsNetworkPortionValid_Valid2_ClassB()
        {
            // arrange
            var networkClass = new ClassB();
            ushort inputLength = 26;
            // act
            var result = _manager.IsNetworkPortionValid(networkClass, inputLength);

            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsNetworkPortionValid_InValid_ClassB_TooLow()
        {
            // arrange
            var networkClass = new ClassB();
            ushort inputLength = 15;
            // act
            var result = _manager.IsNetworkPortionValid(networkClass, inputLength);

            // assert
            Assert.False(result);
        }
        
        [Test]
        public void IsNetworkPortionValid_Valid_ClassC()
        {
            // arrange
            var networkClass = new ClassC();
            ushort inputLength = 24;
            // act
            var result = _manager.IsNetworkPortionValid(networkClass, inputLength);

            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsNetworkPortionValid_Valid2_ClassC()
        {
            // arrange
            var networkClass = new ClassC();
            ushort inputLength = 26;
            // act
            var result = _manager.IsNetworkPortionValid(networkClass, inputLength);

            // assert
            Assert.True(result);
        }
        
        [Test]
        public void IsNetworkPortionValid_InValid_ClassC_TooLow()
        {
            // arrange
            var networkClass = new ClassC();
            ushort inputLength = 23;
            // act
            var result = _manager.IsNetworkPortionValid(networkClass, inputLength);

            // assert
            Assert.False(result);
        }
    }
}