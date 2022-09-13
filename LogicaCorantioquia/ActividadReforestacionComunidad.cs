using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaCorantioquia
{
    public class ActividadReforestacionComunidad : ActividadReforestacion
    {
        private byte personas;

        public ActividadReforestacionComunidad() : base()
        {
            personas = 0;
        }

        public ActividadReforestacionComunidad(string municipio, 
                                               string tipo, 
                                               ushort arbolesSembrados, 
                                               float porcentaje,
                                               ushort arbolesSobrevivientes,
                                               byte personas) : base(municipio, tipo, arbolesSembrados, porcentaje, arbolesSobrevivientes)
        {
            this.personas = personas;

            EvaluaSobrevivencia();
        }

        public byte Personas
        {
            get { return personas; }
            set { personas = value; }
        }

        public override string ToString()
        {
            string resultado = base.ToString();

            resultado += $"Fueron asignadas {personas} personas\n";

            if (esExitoso)
                resultado += "Esta actividad fue exitosa";
            else
                resultado += "Esta actividad no fue exitosa";

            return resultado;
        }  
    }
}
