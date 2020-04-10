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
            var player = new GameObject().AddComponent<PlayerControl>();
            var unityService = Substitute.For<IUnityService>();
            unityService.GetAxis("Mouse X").Returns(1);
            unityService.GetDeltaTime().Returns(1);

            player._unityService = unityService;
            yield return null;

            Assert.AreEqual(0.8, player.transform.rotation.y, 0.1f);
        }
    }
}
