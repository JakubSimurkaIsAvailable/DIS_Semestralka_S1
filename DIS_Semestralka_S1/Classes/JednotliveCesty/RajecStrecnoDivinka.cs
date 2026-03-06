using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S1.Classes.JednotliveCesty
{
    internal class RajecStrecnoDivinka : VypocetNajkratsejTrasy
    {
        public RajecStrecnoDivinka()
        {
            aktualnaTrasa = trasy[3];
        }
        protected override void DoReplication()
        {
            foreach (var cesta in cestyZilinaRajTep)
            {
                cesta.GenerujRychlost();
            }
            double casZilinaRajTep = trasaZilinaRajTep.VypocitajCasPrejazdu(kurier);
            kurier.Pracuj(casZilinaRajTep);
            foreach (var cesta in cestyRajTepStrecno)
            {
                cesta.GenerujRychlost();
            }
            double[] casyRajTepStrecno = new double[3];
            casyRajTepStrecno[0] = trasaRajTepStrecno1.VypocitajCasPrejazdu(kurier);
            casyRajTepStrecno[1] = trasaRajTepStrecno2.VypocitajCasPrejazdu(kurier);
            casyRajTepStrecno[2] = trasaRajTepStrecno3.VypocitajCasPrejazdu(kurier);

            kurier.Pracuj(casyRajTepStrecno.Min());

            foreach (var cesta in cestyDivinkaStrecno)
            {
                cesta.GenerujRychlost();
            }
            double casStrecnoDivinka = trasaDivinkaStrecno.VypocitajCasPrejazdu(kurier);
            kurier.Pracuj(casStrecnoDivinka);

            foreach(var cesta in cestyZilinaDivinka)
            {
                cesta.GenerujRychlost();
            }
            double[] casyDivinkaZilina = new double[3];
            trasaZilinaDivinka1.InvertujTrasu();
            casyDivinkaZilina[0] = trasaZilinaDivinka1.VypocitajCasPrejazdu(kurier);
            trasaZilinaDivinka1.InvertujTrasu();
            trasaZilinaDivinka2.InvertujTrasu();
            casyDivinkaZilina[1] = trasaZilinaDivinka2.VypocitajCasPrejazdu(kurier);
            trasaZilinaDivinka2.InvertujTrasu();
            trasaZilinaDivinka3.InvertujTrasu();
            casyDivinkaZilina[2] = trasaZilinaDivinka3.VypocitajCasPrejazdu(kurier);
            trasaZilinaDivinka3.InvertujTrasu();

            kurier.Pracuj(casyDivinkaZilina.Min());
        }

    }
}
