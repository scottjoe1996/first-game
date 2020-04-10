using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class CameraControlTests
    {
        [UnityTest]
        public IEnumerator UpdateShouldRotateCameraAroundTheXAxisWhenMouseMovesAlongTheYAxis()
        {
            var camera = new GameObject().AddComponent<CameraControl>();
            var unityService = Substitute.For<IUnityService>();
            unityService.GetAxis("Mouse Y").Returns(1);
            unityService.GetDeltaTime().Returns(1);

            camera._unityService = unityService;
            yield return null;

            Assert.AreEqual(-0.7, camera.transform.rotation.x, 0.1f);
        }
    }
}
