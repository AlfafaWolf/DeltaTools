using DeltaTools.Extensions;
using NUnit.Framework;
using UnityEngine;

namespace DeltaTools.Tests.Extensions
{
    public class Vector3ExtensionsTests
    {
        [Test]
        [TestCase(10f)]
        [TestCase(-10f)]
        [TestCase(10.324f)]
        [TestCase(0.0001f)]
        public void Vector3ZeroWithX(float x)
        {
            var vectorZero = new Vector3(0, 0, 0);

            var result = vectorZero.With(x: x);
            
            Assert.AreEqual(new Vector3(x, 0, 0), result);
        }
        
        [Test]
        [TestCase(10f)]
        [TestCase(-10f)]
        [TestCase(10.324f)]
        [TestCase(0.0001f)]
        public void Vector3ZeroWithY(float y)
        {
            var vectorZero = new Vector3(0, 0, 0);

            var result = vectorZero.With(y: y);
            
            Assert.AreEqual(new Vector3(0, y, 0), result);
        }
        
        [Test]
        [TestCase(10f)]
        [TestCase(-10f)]
        [TestCase(10.324f)]
        [TestCase(0.0001f)]
        public void Vector3ZeroWithZ(float z)
        {
            var vectorZero = new Vector3(0, 0, 0);

            var result = vectorZero.With(z: z);
            
            Assert.AreEqual(new Vector3(0, 0, z), result);
        }
        
        [Test]
        [TestCase(10f, 5f, 87f)]
        [TestCase(-10f, -200f, -1f)]
        [TestCase(10.324f, 65.82f, -58.56f)]
        [TestCase(0.0001f, 32.48911f, 0.178546f)]
        public void Vector3ZeroWithXYZ(float x, float y, float z)
        {
            var vectorZero = new Vector3(0, 0, 0);

            var result = vectorZero.With(x, y, z);
            
            Assert.AreEqual(new Vector3(x, y, z), result);
        }
    }
}