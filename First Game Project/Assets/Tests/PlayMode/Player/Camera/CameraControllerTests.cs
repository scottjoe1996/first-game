using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CameraControllerTests
    {
        [UnityTest]
        public IEnumerator UpdateShouldRotateCameraAroundTheXAxisWhenMouseMovesAlongTheYAxis()
        {
            GameObject cameraGameObject = new GameObject("Camera");
            CameraController cameraController = cameraGameObject.AddComponent<CameraController>();

            IPlayerMovementInput playerInput = Substitute.For<IPlayerMovementInput>();
            playerInput.GetAxis("Mouse Y").Returns(1);
            playerInput.GetDeltaTime().Returns(1);

            cameraController._playerInput = playerInput;

            Assert.AreEqual(0, cameraController.transform.rotation.x, 0.1f);
            yield return null;
            Assert.AreEqual(-0.7, cameraController.transform.rotation.x, 0.1f);
        }
    }
}
