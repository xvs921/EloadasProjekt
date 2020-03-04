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
        public void EloadasNincsTeli()
        {
            for (int i = 0; i < 25; i++)
            {
                eloadas.Lefoglal();
            }
            Assert.IsTrue(eloadas.Teli(), "Teli előadás mégsincs teli");
        }
        [TestCase]
        public void EloadasTeli()
        {
            Assert.IsFalse(eloadas.Teli(), "Üres előadás teli van");
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
            var eloadas2 = new Eloadas(-2, -1);
        }

        [TestCase]
        public void AHelyekSzamaNemLehetNegativ()
        {
            Assert.Throws<ArgumentException>(NegativHellyelLetrehozas);
            Assert.Throws<ArgumentException>(() => {
                var eloadas2 = new Eloadas(-2, -1);
            });
        }
        [TestCase]
        public void FoglaltHibasAdat()
        {
            Assert.Throws<ArgumentException>(() => {
                eloadas.Foglalt(-1,2);
            });
        }
        [TestCase]
        public void FoglaltNagyobbAdat()
        {
            Assert.Throws<ArgumentException>(() => {
                eloadas.Foglalt(20,4);
            });
        }

        [TestCase]
        public void Megtelt()
        {
            eloadas = new Eloadas(2, 2);
            for (int i = 0; i < 4; i++)
            {
                eloadas.Lefoglal();
            }
            Assert.IsFalse(eloadas.Teli(), "Az előadás megtelt!");
        }
        [TestCase]
        public void hibakezelesMegtelt()
        {
            Assert.Throws<ArgumentException>(Megtelt);
            Assert.Throws<ArgumentException>(() => {
                eloadas.Foglalt(-3, 44);
            });
        }
        [TestCase]
        public void sikeresFoglalas()
        {
            eloadas = new Eloadas(25, 41);
            eloadas.Lefoglal();
            Assert.AreEqual(true, eloadas.Foglalt(1, 4), "Sikeres foglalás!");
        }
        [TestCase]
        public void HibakezelesSikeresFoglalas()
        {
            Assert.Throws<ArgumentException>(sikeresFoglalas);
            Assert.Throws<ArgumentException>(() => {
                eloadas.Foglalt(2, 7);
            });
        }
    }
}
