using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Skeleton.Tests
{
    [TestFixture]
    public class AxeTests
    {
        private const int AxeAttack = 1;
        private const int AxeDurability = 1;
        private const int DummyHealth = 20;
        private const int DummyXP = 1;

        private Axe axe;
        private Dummy dummy;

        [SetUp]
        public void TestInit()
        {
            this.axe = new Axe(AxeAttack, AxeDurability);
            this.dummy = new Dummy(DummyHealth, DummyXP);
        }

        [Test]
        public void AxeLosesDurabilityAfterAtack()
        {
            axe.Attack(dummy);

            Assert.AreEqual(0, axe.DurabilityPoints, "Axe Durability doesn't change after attack");
        }

        [Test]
        public void AttackingWithBrokenAxe()
        {

            axe.Attack(dummy);

            Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
        }
    }
}