using System.Collections;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerVerticalMovementTests
    {
        [Test]
        public void CalculateGravitationalEffectVectorShouldReturnExpectedVectorWhenGrounded()
        {
            var characterController = new GameObject().AddComponent<CharacterController>();
            var groundChecker = Substitute.ForPartsOf<GroundChecker>(characterController);
            groundChecker.IsGrounded().Returns(true);
            PlayerVerticalMovement playerVerticalMovement = new PlayerVerticalMovement(characterController, 12f);

            Vector3 expected = new Vector3(0f, 12f, 0f);

            Assert.AreEqual(expected, playerVerticalMovement.CalculateGravitationalEffectVector(1f));
        }

        [Test]
        public void CalculateGravitationalEffectVectorShouldReturnExpectedVectorWhenNotGrounded()
        {
            var characterController = new GameObject().AddComponent<CharacterController>();
            PlayerVerticalMovement playerVerticalMovement = new PlayerVerticalMovement(characterController, 12f);

            Vector3 expected = new Vector3(0f, 12f, 0f);

            Assert.AreEqual(expected, playerVerticalMovement.CalculateGravitationalEffectVector(1f));
        }
    }
}
