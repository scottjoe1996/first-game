using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerTests
    {
        // A Test behaves as an ordinary method
        [Test]
        public void shouldReturnExpectedRotation()
        {
            float mouseX = 10f;
            float deltaTime = 10f;
            Player player = new Player(10f);
            Vector3 expected = new Vector3(0.0f, 1000f, 0.0f);

            Assert.AreEqual(expected, player.CalculateYRotation(mouseX, deltaTime));
        }
    }
}
