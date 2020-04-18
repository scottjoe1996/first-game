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
            var checkGround = Substitute.For<ICheckGround>();
            checkGround.SphereCast(default, default, default).ReturnsForAnyArgs(true);
            GroundChecker._checkGround = checkGround;

            Assert.IsTrue(GroundChecker.IsGrounded());
        }

        [Test]
        public void GroundCheckerShouldReturnFalseWhenNotGrounded()
        {
            var characterController = new GameObject().AddComponent<CharacterController>();
            GroundChecker GroundChecker = new GroundChecker(characterController);
            var checkGround = Substitute.For<ICheckGround>();
            checkGround.SphereCast(default, default, default).ReturnsForAnyArgs(false);
            GroundChecker._checkGround = checkGround;

            Assert.IsFalse(GroundChecker.IsGrounded());
        }
    }
}
