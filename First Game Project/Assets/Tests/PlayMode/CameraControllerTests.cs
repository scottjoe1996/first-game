﻿using System.Collections;
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

            IUnityService unityService = Substitute.For<IUnityService>();
            unityService.GetAxis("Mouse Y").Returns(1);
            unityService.GetDeltaTime().Returns(1);

            cameraController._unityService = unityService;

            Assert.AreEqual(0, cameraController.transform.rotation.x, 0.1f);
            yield return null;
            Assert.AreEqual(-0.7, cameraController.transform.rotation.x, 0.1f);
        }
    }
}
