using NUnit.Framework;
using System;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        [Test]
        public void DummyReducingHPWhenAttacked()
        {
            Dummy dummy = new Dummy(5, 10);

            dummy.TakeAttack(1);
            
            Assert.AreEqual(4, dummy.Health);
        }

        [Test]
        public void DummyShouldThrowExceptionIfDeadAndGetsAttacked()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(10);

            Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(0));
        }

        [Test]
        public void DeadDummyShouldGiveEXPWhenIsDead()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(10);
            Assert.AreEqual(true, dummy.IsDead());
            Assert.That(() => dummy.GiveExperience(), Is.EqualTo(10));
        }
        [Test]
        public void AliveDummyShouldNotGiveEXP()
        {
            Dummy dummy = new Dummy(10, 10);
            dummy.TakeAttack(9);
            Assert.AreEqual(false, dummy.IsDead());
            Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
        }
    }
}