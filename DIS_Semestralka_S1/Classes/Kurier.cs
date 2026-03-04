using DIS_Semestralka_S1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S1.Classes
{
    internal class Kurier : IKurier
    {
        private double Odjazd = 6*60;
        public double CasPrace;
        public double AkutalnyCas { get => Odjazd + CasPrace;}
        public Kurier()
        {
            CasPrace = 0;
        }
        public void Pracuj(double casPrace)
        {
            CasPrace += casPrace;
        }
        public void Vynuluj()
        {
            CasPrace = 0;
        }
    }
}
