using NUnit.Framework;
using UnityEngine;

namespace Tests
{
    public class CameraRotationTests
    {
        [Test]
        public void CalculateXRotationShouldReturnExpectedRotation()
        {
            float mouseY = 1f;
            float deltaTime = 1f;
            CameraRotation CameraRotation = new CameraRotation(10f);
            Quaternion expected = Quaternion.Euler(-10f, 0, 0);

            Assert.AreEqual(expected, CameraRotation.CalculateXRotation(mouseY, deltaTime));
        }

        [Test]
        public void CalculateXRotationShouldNotReturnAEulerAngleXLessThan270()
        {
            float mouseY = 1f;
            float deltaTime = 9.1f;
            CameraRotation CameraRotation = new CameraRotation(10f);

            Assert.GreaterOrEqual(CameraRotation.CalculateXRotation(mouseY, deltaTime).eulerAngles.x, 270);
        }

        [Test]
        public void CalculateXRotationShouldNotReturnAEulerAngleXGreaterThan90()
        {
            float mouseY = 1f;
            float deltaTime = -9.1f;
            CameraRotation CameraRotation = new CameraRotation(10f);

            Assert.LessOrEqual(CameraRotation.CalculateXRotation(mouseY, deltaTime).eulerAngles.x, 90);
        }
    }
}
