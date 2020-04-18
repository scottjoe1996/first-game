using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class PlayerGroundMovementTests
    {
        [Test]
        public void CalculateShouldReturnExpectedVector3()
        {
            var player = new GameObject().AddComponent<PlayerController>();
            PlayerGroundMovement playerGroundMovement = new PlayerGroundMovement(player.transform, 12f);

            Vector3 expected = new Vector3(12f, 0f, 12f);

            Assert.AreEqual(expected, playerGroundMovement.Calculate(1f, 1f, 1f));
        }
    }
}
