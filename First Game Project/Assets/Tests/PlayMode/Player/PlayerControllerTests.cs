using System.Collections;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerControllerTests
    {
        [UnityTest]
        public IEnumerator UpdateShouldRotatePlayerAroundTheYAxisWhenMouseMovesAlongTheXAxis()
        {
            GameObject playerGameObject = new GameObject("Player");
            PlayerController playerController = playerGameObject.AddComponent<PlayerController>();
            CharacterController characterController = playerGameObject.AddComponent<CharacterController>();

            IPlayerMovementInput playerMovementInput = Substitute.For<IPlayerMovementInput>();
            playerMovementInput.GetAxis("Mouse X").Returns(1);
            playerMovementInput.GetDeltaTime().Returns(1);

            playerController._playerMovementInput = playerMovementInput;
            playerController.characterController = characterController;

            Assert.AreEqual(0, playerGameObject.transform.rotation.y);
            yield return null;
            Assert.AreEqual(0.8, playerGameObject.transform.rotation.y, 0.1f);
        }

        [UnityTest]
        public IEnumerator UpdateShouldMovePlayerAlongZForVerticalInput()
        {
            GameObject playerGameObject = new GameObject("Player");
            PlayerController playerController = playerGameObject.AddComponent<PlayerController>();
            CharacterController characterController = playerGameObject.AddComponent<CharacterController>();

            IPlayerMovementInput playerMovementInput = Substitute.For<IPlayerMovementInput>();
            playerMovementInput.GetAxis("Vertical").Returns(1);
            playerMovementInput.GetDeltaTime().Returns(1);

            playerController._playerMovementInput = playerMovementInput;
            playerController.characterController = characterController;

            Assert.AreEqual(0f, playerGameObject.transform.position.z);
            yield return null;
            Assert.AreEqual(12f, playerGameObject.transform.position.z);
        }

        [UnityTest]
        public IEnumerator UpdateShouldMovePlayerAlongXForHorizontalInput()
        {
            GameObject playerGameObject = new GameObject("Player");
            PlayerController playerController = playerGameObject.AddComponent<PlayerController>();
            CharacterController characterController = playerGameObject.AddComponent<CharacterController>();

            IPlayerMovementInput playerMovementInput = Substitute.For<IPlayerMovementInput>();
            playerMovementInput.GetAxis("Horizontal").Returns(1);
            playerMovementInput.GetDeltaTime().Returns(1);

            playerController._playerMovementInput = playerMovementInput;
            playerController.characterController = characterController;

            Assert.AreEqual(0, playerGameObject.transform.position.x);
            yield return null;
            Assert.AreEqual(12f, playerGameObject.transform.position.x);
        }

        [UnityTest]
        public IEnumerator UpdateShouldApplyGrowingGravitationForceVectorOnPlayerWhenFalling()
        {
            GameObject playerGameObject = new GameObject("Player");
            PlayerController playerController = playerGameObject.AddComponent<PlayerController>();
            CharacterController characterController = playerGameObject.AddComponent<CharacterController>();

            IPlayerMovementInput playerMovementInput = Substitute.For<IPlayerMovementInput>();
            playerMovementInput.GetDeltaTime().Returns(1);

            playerController._playerMovementInput = playerMovementInput;
            playerController.characterController = characterController;
            yield return null;
            Assert.AreEqual(-14f, playerGameObject.transform.position.y);
            yield return null;
            Assert.AreEqual(-42f, playerGameObject.transform.position.y);
        }
    }


}
