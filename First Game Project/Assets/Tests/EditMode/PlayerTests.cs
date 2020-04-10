using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class PlayerTests
    {
        [Test]
        public void CalculateYRotationShouldReturnExpectedRotation()
        {
            float mouseX = 10f;
            float deltaTime = 10f;
            Player player = new Player(10f);
            Vector3 expected = new Vector3(0.0f, 1000f, 0.0f);

            Assert.AreEqual(expected, player.CalculateYRotation(mouseX, deltaTime));
        }
    }
}
