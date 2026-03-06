using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S1.Classes.JednotliveCesty
{
    internal class DivinkaStrecnoRajec : VypocetNajkratsejTrasy
    {
        public DivinkaStrecnoRajec()
        {
            aktualnaTrasa = trasy[1];
        }
        protected override void DoReplication()
        {
            foreach (var cesta in cestyZilinaDivinka)
            {
                cesta.GenerujRychlost();
            }
            double[] casyZilinaDivinka = new double[3];
            casyZilinaDivinka[0] = trasaZilinaDivinka1.VypocitajCasPrejazdu(kurier);
            casyZilinaDivinka[1] = trasaZilinaDivinka2.VypocitajCasPrejazdu(kurier);
            casyZilinaDivinka[2] = trasaZilinaDivinka3.VypocitajCasPrejazdu(kurier);

            kurier.Pracuj(casyZilinaDivinka.Min());

            foreach (var cesta in cestyDivinkaStrecno)
            {
                cesta.GenerujRychlost();
            }
            double casyDivinkaStrecno = trasaDivinkaStrecno.VypocitajCasPrejazdu(kurier);
            kurier.Pracuj(casyDivinkaStrecno);
            foreach (var cesta in cestyRajTepStrecno)
            {
                cesta.GenerujRychlost();
            }
            double[] casyRajTepStrecno = new double[3];
            trasaRajTepStrecno1.InvertujTrasu();
            casyRajTepStrecno[0] = trasaRajTepStrecno1.VypocitajCasPrejazdu(kurier);
            trasaRajTepStrecno1.InvertujTrasu();
            trasaRajTepStrecno2.InvertujTrasu();
            casyRajTepStrecno[1] = trasaRajTepStrecno2.VypocitajCasPrejazdu(kurier);
            trasaRajTepStrecno2.InvertujTrasu();
            trasaRajTepStrecno3.InvertujTrasu();
            casyRajTepStrecno[2] = trasaRajTepStrecno3.VypocitajCasPrejazdu(kurier);
            trasaRajTepStrecno3.InvertujTrasu();
            kurier.Pracuj(casyRajTepStrecno.Min());
            foreach (var cesta in cestyZilinaRajTep)
            {
                cesta.GenerujRychlost();
            }
            trasaZilinaRajTep.InvertujTrasu();
            double casyZilinaStrecno = trasaZilinaRajTep.VypocitajCasPrejazdu(kurier);
            trasaZilinaRajTep.InvertujTrasu();
            kurier.Pracuj(casyZilinaStrecno);
        }
    }
}
