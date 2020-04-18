using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
    public class TargetTests
    {
        [UnityTest]
        public IEnumerator TargetShouldLoseHealthEqualToDamageTaken()
        {
            GameObject dummy = new GameObject("Dummy");
            Target target = dummy.AddComponent<Target>();

            Assert.AreEqual(50f, target.health);
            target.TakeDamage(10f);
            yield return null;
            Assert.AreEqual(40f, target.health);
        }

        [UnityTest]
        public IEnumerator TargetShouldExistIfTakingLessDamageThanTotalHealth()
        {
            GameObject dummy = new GameObject("Dummy");
            Target target = dummy.AddComponent<Target>();

            target.TakeDamage(10f);
            yield return null;
            Assert.IsTrue(dummy);
        }

        [UnityTest]
        public IEnumerator TargetShouldNotExistIfTakingMoreDamageThanTotalHealth()
        {
            GameObject dummy = new GameObject("Dummy");
            Target target = dummy.AddComponent<Target>();

            target.TakeDamage(60f);
            yield return null;
            Assert.IsFalse(dummy);
        }
    }
}
