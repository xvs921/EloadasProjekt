using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EloadasProjekt
{
    public class Eloadas
    {
        private bool[,] foglalasok;
        int sorokSzama;
        int helyekSzama;
        int szabadHelyekSzama=0;
        int ferohelyek = 0;
        
        int foglalt = 0;

        public Eloadas(int sorokSzama,int helyekSzama)
        {
            if(sorokSzama<=0 || helyekSzama<=0)
            {
                throw new ArgumentException("Pozitív érték kell legyen");             
            }
            this.sorokSzama = sorokSzama;
            this.helyekSzama = helyekSzama;
            this.foglalasok = new bool[sorokSzama, helyekSzama];
            for (int i = 0; i < sorokSzama; i++)
            {
                for (int j = 0; j < helyekSzama; j++)
                {
                    foglalasok[i, j] = false;
                    ferohelyek++;
                }       
            }
        }
        public bool Lefoglal()
        {
            for (int i = 0; i < sorokSzama; i++)
            {
                for (int j = 0; j < helyekSzama; j++)
                {
                    if(foglalasok[i, j] == false)
                    {
                        foglalasok[i, j] = true;
                        foglalt++;
                        return true;
                    }
                }
            }
            return false;
        }
        public int SzabadHelyek
        {
            get
            {
                for (int i = 0; i < sorokSzama; i++)
                {
                    for (int j = 0; j < helyekSzama; j++)
                    {
                        if (foglalasok[i, j] == false)
                        {
                            szabadHelyekSzama++;
                        }
                    }
                }
                return szabadHelyekSzama;
            }
        }
        public bool Teli()
        {
            if(ferohelyek==foglalt)
            {
                return true;
            }
            return false;
        }
        public bool Foglalt(int sorSzam, int helySzam)
        {
            if (sorSzam>0 && helySzam>0)
            {
                return foglalasok[sorSzam - 1, helySzam - 1];
            }
            else
            {
                throw new ArgumentException("Érvénytelen paraméter");
            }
        }
    }
}
