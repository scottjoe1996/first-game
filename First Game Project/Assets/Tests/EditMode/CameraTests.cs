using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class CameraTests
    {
        [Test]
        public void CalculateXRotationShouldReturnExpectedRotation()
        {
            float mouseY = 1f;
            float deltaTime = 1f;
            Camera camera = new Camera(10f);
            Quaternion expected = Quaternion.Euler(-10f, 0, 0);

            Assert.AreEqual(expected, camera.CalculateXRotation(mouseY, deltaTime));
        }

        [Test]
        public void CalculateXRotationShouldNotReturnAEulerAngleXLessThan270()
        {
            float mouseY = 1f;
            float deltaTime = 9.1f;
            Camera camera = new Camera(10f);

            Assert.GreaterOrEqual(camera.CalculateXRotation(mouseY, deltaTime).eulerAngles.x, 270);
        }

        [Test]
        public void CalculateXRotationShouldNotReturnAEulerAngleXGreaterThan90()
        {
            float mouseY = 1f;
            float deltaTime = -9.1f;
            Camera camera = new Camera(10f);

            Assert.LessOrEqual(camera.CalculateXRotation(mouseY, deltaTime).eulerAngles.x, 90);
        }
    }
}
