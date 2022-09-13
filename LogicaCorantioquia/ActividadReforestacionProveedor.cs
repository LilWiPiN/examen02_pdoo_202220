using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaCorantioquia
{
    public class ActividadReforestacionProveedor : ActividadReforestacion
    {
        public ushort galones;

        public ActividadReforestacionProveedor() : base()
        {
            galones = 0;
        }

        public ActividadReforestacionProveedor(string municipio,
                                               string tipo,
                                               ushort arbolesSembrados,
                                               float porcentaje,
                                               ushort arbolesSobrevivientes,
                                               ushort galones) : base(municipio, tipo, arbolesSembrados, porcentaje, arbolesSobrevivientes)
        {
            this.galones = galones;

            EvaluaSobrevivencia();
        }

        public ushort Galones
        {
            get { return galones; }
            set { galones = value; }
        }

        public override string ToString()
        {
            string resultado = base.ToString();

            resultado += $"Fueron asignados {galones} galones de agua\n";

            if (esExitoso)
                resultado += "Esta actividad fue exitosa";
            else
                resultado += "Esta actividad no fue exitosa";

            return resultado;
        }
    }
}
