using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S1.Classes.JednotliveCesty
{
    internal class StrecnoDivinkaRajec : VypocetNajkratsejTrasy
    {
        public StrecnoDivinkaRajec()
        {
            aktualnaTrasa = trasy[4];
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

            foreach (var cesta in cestyDivinkaStrecno)
            {
                cesta.GenerujRychlost();
            }
            trasaDivinkaStrecno.InvertujTrasu();
            double casDivinkaStrecno = trasaDivinkaStrecno.VypocitajCasPrejazdu(kurier);
            trasaDivinkaStrecno.InvertujTrasu();

            kurier.Pracuj(casDivinkaStrecno);

            foreach (var cesta in cestyDivinkaRajTep)
            {
                cesta.GenerujRychlost();
            }
            double[] casyDivinkaRajTep = new double[3];
            casyDivinkaRajTep[0] = trasaDivinkaRajTep1.VypocitajCasPrejazdu(kurier);
            casyDivinkaRajTep[1] = trasaDivinkaRajTep2.VypocitajCasPrejazdu(kurier);
            casyDivinkaRajTep[2] = trasaDivinkaRajTep3.VypocitajCasPrejazdu(kurier);

            kurier.Pracuj(casyDivinkaRajTep.Min());

            foreach (var cesta in cestyZilinaRajTep)
            {
                cesta.GenerujRychlost();
            }
            trasaZilinaRajTep.InvertujTrasu();
            double casZilinaRajTep = trasaZilinaRajTep.VypocitajCasPrejazdu(kurier);
            trasaZilinaRajTep.InvertujTrasu();
            kurier.Pracuj(casZilinaRajTep);
            
        }
    }
}
