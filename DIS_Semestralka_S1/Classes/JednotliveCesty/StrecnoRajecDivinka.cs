using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S1.Classes.JednotliveCesty
{
    internal class StrecnoRajecDivinka : VypocetNajkratsejTrasy
    {
        public StrecnoRajecDivinka()
        {
            aktualnaTrasa = trasy[5];
        }
        protected override void DoReplication()
        {
            foreach (var cesta in cestyZilinaStrecno)
            {
                cesta.GenerujRychlost();
            }
            double[] casyZilinaStrecno = new double[3];
            casyZilinaStrecno[0] = trasaZilinaStrecno1.VypocitajCasPrejazdu(kurier);
            casyZilinaStrecno[1] = trasaZilinaStrecno2.VypocitajCasPrejazdu(kurier);
            casyZilinaStrecno[2] = trasaZilinaStrecno3.VypocitajCasPrejazdu(kurier);

            kurier.Pracuj(casyZilinaStrecno.Min());

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

            foreach(var cesta in cestyDivinkaRajTep)
            {
                cesta.GenerujRychlost();
            }
            double[] casyDivinkaRajTep = new double[3];
            trasaDivinkaRajTep1.InvertujTrasu();
            casyDivinkaRajTep[0] = trasaDivinkaRajTep1.VypocitajCasPrejazdu(kurier);
            trasaDivinkaRajTep1.InvertujTrasu();
            trasaDivinkaRajTep2.InvertujTrasu();
            casyDivinkaRajTep[1] = trasaDivinkaRajTep2.VypocitajCasPrejazdu(kurier);
            trasaDivinkaRajTep2.InvertujTrasu();
            trasaDivinkaRajTep3.InvertujTrasu();
            casyDivinkaRajTep[2] = trasaDivinkaRajTep3.VypocitajCasPrejazdu(kurier);
            trasaDivinkaRajTep3.InvertujTrasu();

            kurier.Pracuj(casyDivinkaRajTep.Min());

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
