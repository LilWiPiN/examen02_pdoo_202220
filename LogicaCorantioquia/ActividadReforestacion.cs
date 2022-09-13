using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaCorantioquia
{
    public abstract class ActividadReforestacion
    {
        protected string municipio, tipo;
        protected ushort arbolesSembrados;
        protected float porcentaje;
        protected ushort arbolesSobrevivientes;
        protected bool esExitoso;

        public ActividadReforestacion()
        {
            municipio = "";
            tipo = "";
            arbolesSembrados = 0;
            porcentaje = 0f;
            arbolesSobrevivientes = 0;
            esExitoso = false;
        }

        public ActividadReforestacion(string municipio, 
                                      string tipo, 
                                      ushort arbolesSembrados, 
                                      float porcentaje, 
                                      ushort arbolesSobrevivientes)
        {
            this.municipio = municipio;
            this.tipo = tipo;
            this.arbolesSembrados = arbolesSembrados;
            this.porcentaje = porcentaje;
            this.arbolesSobrevivientes = arbolesSobrevivientes;

            EvaluaSobrevivencia();
        }

        public string Municipio
        {
            get { return municipio; }
            set { municipio = value; }
        }

        public string Tipo
        {
            get { return tipo; }
            set { tipo = value; }
        }

        public ushort ArbolesSembrados
        {
            get { return arbolesSembrados; }
            set { arbolesSembrados = value; }
        }

        public float Porcentaje
        {
            get { return porcentaje; }
            set { porcentaje = value; }
        }

        public ushort ArbolesSobrevivientes
        {
            get { return arbolesSobrevivientes; }
            set { arbolesSobrevivientes = value; }
        }

        public bool EsExitoso
        {
            get { return esExitoso; }
        }

        public virtual void EvaluaSobrevivencia()
        {
            if (porcentaje >= 70f)
                esExitoso = true;
            else
                esExitoso = false;
        }

        public override string ToString()
        {
            string informacion = $"Esta actividad se realizo en el municipio de {municipio}\n" +
                                 $"Esta actividad fue realizada por {tipo}\n" +
                                 $"En esta actividad se plantaron {arbolesSembrados} arboles\n" +
                                 $"Las condiciones climaticas permiten que sobrevivan {porcentaje}% de arboles\n" +
                                 $"Sobreviviran {arbolesSobrevivientes} arboles\n";

            return informacion;
        }
    }
}
