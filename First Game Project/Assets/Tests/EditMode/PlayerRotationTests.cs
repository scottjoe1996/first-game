using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class PlayerRotationTests
    {
        [Test]
        public void CalculateYRotationShouldReturnExpectedRotation()
        {
            float mouseX = 10f;
            float deltaTime = 10f;
            PlayerRotation player = new PlayerRotation(10f);
            Vector3 expected = new Vector3(0.0f, 1000f, 0.0f);

            Assert.AreEqual(expected, player.CalculateYRotation(mouseX, deltaTime));
        }
    }
}
