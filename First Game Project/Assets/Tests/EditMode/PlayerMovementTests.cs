using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class PlayerMovementTests
    {
        [Test]
        public void PlayerMovementTestsSimplePasses()
        {
            var player = new GameObject().AddComponent<PlayerControl>();
            PlayerMovement playerMovement = new PlayerMovement(player.transform, 12f);

            Vector3 expected = new Vector3(12f, 0f, 12f);

            Assert.AreEqual(expected, playerMovement.Calculate(1f, 1f, 1f));
        }
    }
}
