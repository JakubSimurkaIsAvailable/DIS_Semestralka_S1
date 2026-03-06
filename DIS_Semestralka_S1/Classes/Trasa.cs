using DIS_Semestralka_S1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S1.Classes
{
    internal class Trasa : ITrasa
    {
        private ICesta[] cesty;
        private string mestoOdjazdu;
        private string mestoDojazdu;
        public ICesta[] Cesty => cesty;

        public Trasa(ICesta[] cesty, string mestoOdjazdu, string mestoDojazdu)
        {
            this.cesty = cesty;
            this.mestoOdjazdu = mestoOdjazdu;
            this.mestoDojazdu = mestoDojazdu;
        }
        public double VypocitajCasPrejazdu(Kurier kurier)
        {
            double casKuriera = kurier.AkutalnyCas;
            double casPrejazdu = 0;
            bool predchadzajucaK = false;
            foreach (var cesta in this.cesty)
            {
                if (predchadzajucaK && cesta.K && casKuriera > 385)//6:25
                {
                    cesta.Kvychod = true;
                }
                double casPrejazduCesty = cesta.DajCasPrejazdu();
                casPrejazdu += casPrejazduCesty;
                casKuriera += casPrejazduCesty;
                cesta.Kvychod = false;
                if (cesta.K && !predchadzajucaK)
                {
                    predchadzajucaK = true;
                }
                else
                {
                    predchadzajucaK = false;
                }
            }
            return casPrejazdu;
        }
        public void InvertujTrasu()
        {
            Array.Reverse(cesty);
        }
    }
}
