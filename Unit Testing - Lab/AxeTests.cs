using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        [Test]
        public void AxeShouldReduceDurabilityAfterSingleAttack()
        {
            Axe axe = new Axe(5, 5);
            Dummy dummy = new Dummy(10, 10);

            axe.Attack(dummy);

            Assert.AreEqual(4, axe.DurabilityPoints);
        }


        [Testcase(5, 0)]
        [TestCase(10, -1)]
        public void AxeCannotFightWithLessThan0Points(int attack, int durability)
        {
            Axe axe = new Axe(attack, durability);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(new Dummy(15, 20)));

        }
    }
}