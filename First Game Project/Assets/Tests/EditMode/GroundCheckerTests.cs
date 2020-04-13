using NUnit.Framework;
using NSubstitute;
using UnityEngine;

namespace Tests
{
    public class GroundCheckerTests
    {
        [Test]
        public void GroundCheckerShouldReturnTrueWhenGrounded()
        {
            var characterController = new GameObject().AddComponent<CharacterController>();
            GroundChecker GroundChecker = new GroundChecker(characterController);
            var physicsSerice = Substitute.For<IPhysicsService>();
            physicsSerice.SphereCast(default, default, default).ReturnsForAnyArgs(true);
            GroundChecker._physicsService = physicsSerice;

            Assert.IsTrue(GroundChecker.IsGrounded());
        }

        [Test]
        public void GroundCheckerShouldReturnFalseWhenNotGrounded()
        {
            var characterController = new GameObject().AddComponent<CharacterController>();
            GroundChecker GroundChecker = new GroundChecker(characterController);
            var physicsSerice = Substitute.For<IPhysicsService>();
            physicsSerice.SphereCast(default, default, default).ReturnsForAnyArgs(false);
            GroundChecker._physicsService = physicsSerice;

            Assert.IsFalse(GroundChecker.IsGrounded());
        }
    }
}
