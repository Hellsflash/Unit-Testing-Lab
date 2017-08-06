using System;
using NUnit.Framework;

namespace Skeleton.Tests
{
    [TestFixture]
    public class DummyTests
    {
        private const int AxeAttack = 1;
        private const int AxeDurability = 1;
        private const int DummyHealth = 1;
        private const int SecondDummyHealth = 1;
        private const int DummyXP = 1;

        private Axe axe;
        private Dummy dummy;
        private Hero hero;
        private Dummy secondDummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyXP);
            this.hero = new Hero("Mario");
            this.secondDummy = new Dummy(SecondDummyHealth, DummyXP);
        }

        [Test]
        public void DummyLosesHealthIfAttacked()
        {
            axe.Attack(dummy);

            Assert.AreEqual(0, dummy.Health, "Dummy dosen't lose hp");
        }

        [Test]
        public void CanAttackDeadDummy()
        {
            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }

        [Test]
        public void DeadDummyCanGiveXP()
        {
            hero.Attack(dummy);

            Assert.AreEqual(1, hero.Experience, "Dead Dummy doesn't give XP");
        }

        [Test]
        public void AliveDummyCantGivesXP()
        {
            hero.Attack(secondDummy);

            Assert.Throws<InvalidOperationException>(() => hero.Attack(secondDummy));
        }
    }
}