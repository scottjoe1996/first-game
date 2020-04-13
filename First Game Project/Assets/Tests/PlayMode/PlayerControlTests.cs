﻿using System.Collections;
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
            PlayerControl player = new GameObject().AddComponent<PlayerControl>();
            CharacterController characterController = new GameObject().AddComponent<CharacterController>();

            IUnityService unityService = Substitute.For<IUnityService>();
            unityService.GetAxis("Mouse X").Returns(1);
            unityService.GetDeltaTime().Returns(1);

            player._unityService = unityService;
            player.characterController = characterController;

            Assert.AreEqual(0, player.transform.rotation.y);
            yield return null;
            Assert.AreEqual(0.8, player.transform.rotation.y, 0.1f);
        }

        [UnityTest]
        public IEnumerator UpdateShouldMovePlayerAlongZForVerticalInput()
        {
            PlayerControl player = new GameObject().AddComponent<PlayerControl>();
            CharacterController characterController = new GameObject().AddComponent<CharacterController>();

            IUnityService unityService = Substitute.For<IUnityService>();
            unityService.GetAxis("Vertical").Returns(1);
            unityService.GetDeltaTime().Returns(1);

            player._unityService = unityService;
            player.characterController = characterController;

            Assert.AreEqual(0f, characterController.transform.position.z);
            yield return null;
            Assert.AreEqual(12f, characterController.transform.position.z);
        }

        [UnityTest]
        public IEnumerator UpdateShouldMovePlayerAlongXForHorizontalInput()
        {
            PlayerControl player = new GameObject().AddComponent<PlayerControl>();
            CharacterController characterController = new GameObject().AddComponent<CharacterController>();

            IUnityService unityService = Substitute.For<IUnityService>();
            unityService.GetAxis("Horizontal").Returns(1);
            unityService.GetDeltaTime().Returns(1);

            player._unityService = unityService;
            player.characterController = characterController;

            Assert.AreEqual(0, characterController.transform.position.x);
            yield return null;
            Assert.AreEqual(12f, characterController.transform.position.x);
        }

        [UnityTest]
        public IEnumerator UpdateShouldApplyGrowingGravitationForceVectorOnPlayerWhenFalling()
        {
            PlayerControl player = new GameObject().AddComponent<PlayerControl>();
            CharacterController characterController = new GameObject().AddComponent<CharacterController>();

            IUnityService unityService = Substitute.For<IUnityService>();
            unityService.GetDeltaTime().Returns(1);

            player._unityService = unityService;
            player.characterController = characterController;
            yield return null;
            Assert.AreEqual(-14f, characterController.transform.position.y);
            yield return null;
            Assert.AreEqual(-42f, characterController.transform.position.y);
        }
    }
}
