using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIS_Semestralka_S1.Classes.JednotliveCesty
{
    internal class RajecDivinkaStrecno : VypocetNajkratsejTrasy
    {
        public RajecDivinkaStrecno()
        {
            aktualnaTrasa = trasy[2];
        }
        protected override void DoReplication()
        {
            foreach (var cesta in cestyZilinaRajTep)
            {
                cesta.GenerujRychlost();
            }
            double casZilinaRajTep = trasaZilinaRajTep.VypocitajCasPrejazdu(kurier);

            kurier.Pracuj(casZilinaRajTep);

            foreach (var cesta in cestyDivinkaRajTep)
            {
                cesta.GenerujRychlost();
            }
            double[] casyRajTepDivinka = new double[3];
            trasaDivinkaRajTep1.InvertujTrasu();
            casyRajTepDivinka[0] = trasaDivinkaRajTep1.VypocitajCasPrejazdu(kurier);
            trasaDivinkaRajTep1.InvertujTrasu();
            trasaDivinkaRajTep2.InvertujTrasu();
            casyRajTepDivinka[1] = trasaDivinkaRajTep2.VypocitajCasPrejazdu(kurier);
            trasaDivinkaRajTep2.InvertujTrasu();
            trasaDivinkaRajTep3.InvertujTrasu();
            casyRajTepDivinka[2] = trasaDivinkaRajTep3.VypocitajCasPrejazdu(kurier);
            trasaDivinkaRajTep3.InvertujTrasu();

            kurier.Pracuj(casyRajTepDivinka.Min());

            foreach (var cesta in cestyDivinkaStrecno)
            {
                cesta.GenerujRychlost();
            }
            double casDivinkaStrecno = trasaDivinkaStrecno.VypocitajCasPrejazdu(kurier);
            kurier.Pracuj(casDivinkaStrecno);

            foreach (var cesta in cestyZilinaStrecno)
            {
                cesta.GenerujRychlost();
            }
            double[] casyStrecnoZilina = new double[3];
            trasaZilinaStrecno1.InvertujTrasu();
            casyStrecnoZilina[0] = trasaZilinaStrecno1.VypocitajCasPrejazdu(kurier);
            trasaZilinaStrecno1.InvertujTrasu();
            trasaZilinaStrecno2.InvertujTrasu();
            casyStrecnoZilina[1] = trasaZilinaStrecno2.VypocitajCasPrejazdu(kurier);
            trasaZilinaStrecno2.InvertujTrasu();
            trasaZilinaStrecno3.InvertujTrasu();
            casyStrecnoZilina[2] = trasaZilinaStrecno3.VypocitajCasPrejazdu(kurier);
            trasaZilinaStrecno3.InvertujTrasu();

            kurier.Pracuj(casyStrecnoZilina.Min());
        }
    }
}
