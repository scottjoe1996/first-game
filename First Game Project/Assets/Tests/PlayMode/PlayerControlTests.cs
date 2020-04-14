using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class PlayerControlTests
    {
        [UnityTest]
        public IEnumerator UpdateShouldRotatePlayerAroundTheYAxisWhenMouseMovesAlongTheXAxis()
        {
            GameObject playerGameObject = new GameObject("Player");
            PlayerControl player = playerGameObject.AddComponent<PlayerControl>();
            CharacterController characterController = playerGameObject.AddComponent<CharacterController>();

            IUnityService unityService = Substitute.For<IUnityService>();
            unityService.GetAxis("Mouse X").Returns(1);
            unityService.GetDeltaTime().Returns(1);

            player._unityService = unityService;
            player.characterController = characterController;

            Assert.AreEqual(0, playerGameObject.transform.rotation.y);
            yield return null;
            Assert.AreEqual(0.8, playerGameObject.transform.rotation.y, 0.1f);
        }

        [UnityTest]
        public IEnumerator UpdateShouldMovePlayerAlongZForVerticalInput()
        {
            GameObject playerGameObject = new GameObject("Player");
            PlayerControl player = playerGameObject.AddComponent<PlayerControl>();
            CharacterController characterController = playerGameObject.AddComponent<CharacterController>();

            IUnityService unityService = Substitute.For<IUnityService>();
            unityService.GetAxis("Vertical").Returns(1);
            unityService.GetDeltaTime().Returns(1);

            player._unityService = unityService;
            player.characterController = characterController;

            Assert.AreEqual(0f, playerGameObject.transform.position.z);
            yield return null;
            Assert.AreEqual(12f, playerGameObject.transform.position.z);
        }

        [UnityTest]
        public IEnumerator UpdateShouldMovePlayerAlongXForHorizontalInput()
        {
            GameObject playerGameObject = new GameObject("Player");
            PlayerControl player = playerGameObject.AddComponent<PlayerControl>();
            CharacterController characterController = playerGameObject.AddComponent<CharacterController>();

            IUnityService unityService = Substitute.For<IUnityService>();
            unityService.GetAxis("Horizontal").Returns(1);
            unityService.GetDeltaTime().Returns(1);

            player._unityService = unityService;
            player.characterController = characterController;

            Assert.AreEqual(0, playerGameObject.transform.position.x);
            yield return null;
            Assert.AreEqual(12f, playerGameObject.transform.position.x);
        }

        [UnityTest]
        public IEnumerator UpdateShouldApplyGrowingGravitationForceVectorOnPlayerWhenFalling()
        {
            GameObject playerGameObject = new GameObject("Player");
            PlayerControl player = playerGameObject.AddComponent<PlayerControl>();
            CharacterController characterController = playerGameObject.AddComponent<CharacterController>();

            IUnityService unityService = Substitute.For<IUnityService>();
            unityService.GetDeltaTime().Returns(1);

            player._unityService = unityService;
            player.characterController = characterController;
            yield return null;
            Assert.AreEqual(-14f, playerGameObject.transform.position.y);
            yield return null;
            Assert.AreEqual(-42f, playerGameObject.transform.position.y);
        }
    }


}
