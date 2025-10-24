using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siciliano_zoo
{
    class Animale
    {
        public string Nome { get; set; }

        public string Specie { get; set; }
        public int Età { get; set; }
        public int Peso { get; set; }
        public string StatoDiSalute { get; set; }
        public DateOnly DataArrivo { get; set; }
        public int AnniAlloZoo
        {
            get
            {
                return DateTime.Now.Year - DataArrivo.Year;
            }
        }

        private double _pesoIniziale;
        private int _numeroControlliVeterinari;

        private double CalcolaVariazionePesoPercentuale()
        {
            return ((Peso - _pesoIniziale) / _pesoIniziale) * 100;
        }
        private void DeterminaStatoSaluteAutomatico()
        {
            double variazionePeso = CalcolaVariazionePesoPercentuale();

            int FattoriNegativi = 0;

            if (Math.Abs(variazionePeso) > 10)
                FattoriNegativi++;

            if (Età > 15)
                FattoriNegativi++;

            if (_numeroControlliVeterinari >= 5)
                FattoriNegativi++;

            if (FattoriNegativi == 0)
                StatoDiSalute = "Ottimo";
            else if (FattoriNegativi == 1)
                StatoDiSalute = "Buono";
            else if (FattoriNegativi == 2)
                StatoDiSalute = "Discreto";
            else
                StatoDiSalute = "Critico";
        }

        public virtual double CalcolaCiboDiarioKg()
        {
            return Peso / 20.0;
        }
        
    }
}
