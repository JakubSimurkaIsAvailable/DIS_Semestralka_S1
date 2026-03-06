using DIS_Semestralka_S1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S1.Classes.JednotliveCesty
{
    internal class DivinkaRajecStrecno : VypocetNajkratsejTrasy
    {
        public DivinkaRajecStrecno()
        {
            
            aktualnaTrasa = trasy[0];
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
            foreach (var cesta in cestyDivinkaRajTep)
            {
                cesta.GenerujRychlost();
            }
            double[] casyDivinkaRajTep = new double[3];
            casyDivinkaRajTep[0] = trasaDivinkaRajTep1.VypocitajCasPrejazdu(kurier);
            casyDivinkaRajTep[1] = trasaDivinkaRajTep2.VypocitajCasPrejazdu(kurier);
            casyDivinkaRajTep[2] = trasaDivinkaRajTep3.VypocitajCasPrejazdu(kurier);

            kurier.Pracuj(casyDivinkaRajTep.Min());
            foreach (var cesta in cestyRajTepStrecno)
            {
                cesta.GenerujRychlost();
            }
            double[] casyRajTepStrecno = new double[3];
            casyRajTepStrecno[0] = trasaRajTepStrecno1.VypocitajCasPrejazdu(kurier);
            casyRajTepStrecno[1] = trasaRajTepStrecno2.VypocitajCasPrejazdu(kurier);
            casyRajTepStrecno[2] = trasaRajTepStrecno3.VypocitajCasPrejazdu(kurier);

            kurier.Pracuj(casyRajTepStrecno.Min());
            foreach (var cesta in cestyZilinaStrecno)
            {
                cesta.GenerujRychlost();
            }
            double[] casyZilinaStrecno = new double[3];
            casyZilinaStrecno[0] = trasaZilinaStrecno1.VypocitajCasPrejazdu(kurier);
            casyZilinaStrecno[1] = trasaZilinaStrecno2.VypocitajCasPrejazdu(kurier);
            casyZilinaStrecno[2] = trasaZilinaStrecno3.VypocitajCasPrejazdu(kurier);

            kurier.Pracuj(casyZilinaStrecno.Min());
        }
    }
}
