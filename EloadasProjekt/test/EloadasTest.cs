using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace EloadasProjekt.test
{
    [TestFixture]
    class EloadasTest
    {
        Eloadas eloadas;
        [SetUp]
        public void SetUp()
        {
            eloadas = new Eloadas(5, 5);
        }

        [TestCase]
        public void UjEloadasonMindenHelySzabad()
        {
            Assert.AreEqual(25, eloadas.SzabadHelyek, "A férőhelyek száma hibás!");
        }
        [TestCase]
        public void HelyfoglalasUtanAHelyekSzamaCsokken()
        {
            eloadas.Lefoglal();
            Assert.AreEqual(24, eloadas.SzabadHelyek, "Hibás számítás a maradék férőhelyeknél!");
        }
        [TestCase]
        public void EloadasTeli()
        {
            Assert.IsFalse(eloadas.Teli(), "Üres előadás teli van");
            for (int i = 0; i < 32; i++)
            {
                eloadas.Lefoglal();
            }
            Assert.IsTrue(eloadas.Teli(), "Teli eloadas megsincs tele");
        }
        [TestCase]
        public void teliEloadasraNeLehessenHelyetFoglalni()
        {
            for (int i = 0; i < 25; i++)
            {
                eloadas.Lefoglal();
            }

            bool sikerult = eloadas.Lefoglal();
            Assert.AreEqual(0, eloadas.SzabadHelyek);
            Assert.IsTrue(eloadas.Teli());
            Assert.IsFalse(sikerult);
        }

        void NegativHellyelLetrehozas()
        {
            var eloadas2 = new Eloadas(-2,-1);
        }

        [TestCase]
        public void AHelyekSzamaNemLehetNegativ()
        {
            Assert.Throws<ArgumentException>(NegativHellyelLetrehozas);
            Assert.Throws<ArgumentException>(() => {
                var eloadas2 = new Eloadas(-2, -1);
            });
        }
    }
}
