using System.Collections;
using NUnit.Framework;
using NSubstitute;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class WeaponControllerTests
    {
        /*[UnityTest]
        public IEnumerator ShouldCallWeaponAttackWhenFire1ButtonIsPressed()
        {
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.AddComponent<Target>();

            GameObject playerGameObject = new GameObject("Player");
            playerGameObject.transform.position = new Vector3(0f, 0f, -10f);
            WeaponController weaponController = playerGameObject.AddComponent<WeaponController>();
            Camera camera = playerGameObject.AddComponent<Camera>();

            IPlayerAttackInput playerAttackInput = Substitute.For<IPlayerAttackInput>();
            playerAttackInput.GetButtonDown("Fire1").Returns(true);

            weaponController._playerAttackInput = playerAttackInput;
            weaponController.Camera = camera;
            weaponController.weaponDamage = 10f;
            weaponController.weaponRange = 100f;

            Assert.AreEqual(cube.GetComponent<Target>().health, 50f);
            yield return null;
            Assert.AreEqual(cube.GetComponent<Target>().health, 40f);
        }*/
    }
}
