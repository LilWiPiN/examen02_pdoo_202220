using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicaCorantioquia
{
    public class Corantioquia
    {
        private ActividadReforestacion[] actividades;
        private byte[] actividadesPorMunicipio;
        private uint[] arbolesSobrevivientesPorMunicipio;
        private byte actividadesComunidadExitosas, actividadesProveedorExitosas;
        private uint[] aguaUtilizadaPorMunicipio;

        public Corantioquia()
        {
            actividades = new ActividadReforestacion[100];
            actividadesPorMunicipio = new byte[10];
            arbolesSobrevivientesPorMunicipio = new uint[10];
            actividadesComunidadExitosas = 0;
            actividadesProveedorExitosas = 0;
            aguaUtilizadaPorMunicipio = new uint[10];

            InicializaActividad();
        }

        public Corantioquia(ActividadReforestacion[] actividades)
        {
            this.actividades = actividades;

            actividadesPorMunicipio = new byte[10];
            arbolesSobrevivientesPorMunicipio = new uint[10];
            actividadesComunidadExitosas = 0;
            actividadesProveedorExitosas = 0;
            aguaUtilizadaPorMunicipio = new uint[10];

            InicializaActividad();
        }

        public byte[] ActividadesPorMunicipio
        {
            get { return actividadesPorMunicipio; }
        }

        public uint[] ArbolesSobrevivientesPorMunicipio
        {
            get { return arbolesSobrevivientesPorMunicipio; }
        }

        public byte ActividadesComunidadExitosas
        {
            get { return actividadesComunidadExitosas; }
        }

        public byte ActividadesProveedorExitosas
        {
            get { return actividadesProveedorExitosas; }
        }

        public uint[] AguaUtilizadaPorMunicipio
        {
            get { return aguaUtilizadaPorMunicipio; }
        }

        public void InicializaActividad()
        {
            Random random = new Random();

            string[] municipios = { "Medellin", "Barbosa", "Girardota", "Copacabana", "Bello", "Itagui", "Sabaneta", "Envigado", "La estrella", "Caldas"};
            string elMunicipio;

            float porcentaje;
            ushort arboles;
            ushort arbolesSobrevivientes;

            byte defineActividad;
            //0: ActividadComunidad
            //1: ActividadProveedor
            for (byte i = 0; i < actividades.Length; i++)
            {
                defineActividad = (byte)random.Next(2);

                elMunicipio = municipios[random.Next(municipios.Length)];
                porcentaje = random.Next(101);
                arboles = (ushort)random.Next(1001);
                arbolesSobrevivientes = (ushort)(arboles * porcentaje / 100);

                switch (defineActividad)
                {
                    //ActividadComunicador
                    case 0:
                        actividades[i] = new ActividadReforestacionComunidad()
                        {
                            Municipio = elMunicipio,
                            Tipo = "Comunidad",
                            ArbolesSembrados = arboles,
                            Porcentaje = porcentaje,
                            ArbolesSobrevivientes = arbolesSobrevivientes,
                            Personas = (byte)random.Next(51)
                        };
                        break;

                    //ActividadProveedor
                    case 1:
                        actividades[i] = new ActividadReforestacionProveedor()
                        {
                            Municipio = elMunicipio,
                            Tipo = "Proveedor",
                            ArbolesSembrados = arboles,
                            Porcentaje = porcentaje,
                            ArbolesSobrevivientes = arbolesSobrevivientes,
                            Galones = (ushort)(arbolesSobrevivientes * 10)
                        };
                        break;
                }
                actividades[i].EvaluaSobrevivencia();
            }
        }

        public void TotalActividadesPorMunicipio()
        {
            for (byte i = 0; i < actividades.Length; i++)
            {
                //Medellin
                if (actividades[i].Municipio == "Medellin")
                    actividadesPorMunicipio[0]++;

                //Barbosa 
                if (actividades[i].Municipio == "Barbosa")
                    actividadesPorMunicipio[1]++;

                //Girardota 
                if (actividades[i].Municipio == "Girardota")
                    actividadesPorMunicipio[2]++;

                //Copacabana 
                if (actividades[i].Municipio == "Copacabana")
                    actividadesPorMunicipio[3]++;

                //Bello 
                if (actividades[i].Municipio == "Bello")
                    actividadesPorMunicipio[4]++;

                //Itagui 
                if (actividades[i].Municipio == "Itagui")
                    actividadesPorMunicipio[5]++;

                //Sabaneta 
                if (actividades[i].Municipio == "Sabaneta")
                    actividadesPorMunicipio[6]++;

                //Envigado 
                if (actividades[i].Municipio == "Envigado")
                    actividadesPorMunicipio[7]++;

                //La estrella 
                if (actividades[i].Municipio == "La estrella")
                    actividadesPorMunicipio[8]++;

                //Caldas
                if (actividades[i].Municipio == "Caldas")
                    actividadesPorMunicipio[9]++;
            }
        }

        public void TotalArbolesSobrevivientesPorMunicipios()
        {
            for (byte i = 0; i < actividades.Length; i++)
            {
                //Medellin
                if (actividades[i].Municipio == "Medellin")
                    arbolesSobrevivientesPorMunicipio[0] += actividades[i].ArbolesSobrevivientes;

                //Barbosa
                if (actividades[i].Municipio == "Barbosa")
                    arbolesSobrevivientesPorMunicipio[1] += actividades[i].ArbolesSobrevivientes;

                //Girardota
                if (actividades[i].Municipio == "Girardota")
                    arbolesSobrevivientesPorMunicipio[2] += actividades[i].ArbolesSobrevivientes;

                //Copacabana 
                if (actividades[i].Municipio == "Copacabana")
                    arbolesSobrevivientesPorMunicipio[3] += actividades[i].ArbolesSobrevivientes;

                //Bello
                if (actividades[i].Municipio == "Bello")
                    arbolesSobrevivientesPorMunicipio[4] += actividades[i].ArbolesSobrevivientes;

                //Itagui
                if (actividades[i].Municipio == "Itagui")
                    arbolesSobrevivientesPorMunicipio[5] += actividades[i].ArbolesSobrevivientes;

                //Sabaneta
                if (actividades[i].Municipio == "Sabaneta")
                    arbolesSobrevivientesPorMunicipio[6] += actividades[i].ArbolesSobrevivientes;

                //Envigado
                if (actividades[i].Municipio == "Envigado")
                    arbolesSobrevivientesPorMunicipio[7] += actividades[i].ArbolesSobrevivientes;

                //La estrella 
                if (actividades[i].Municipio == "La estrella")
                    arbolesSobrevivientesPorMunicipio[8] += actividades[i].ArbolesSobrevivientes;

                //Caldas
                if (actividades[i].Municipio == "Caldas")
                    arbolesSobrevivientesPorMunicipio[9] += actividades[i].ArbolesSobrevivientes;
            }
        }

        public void TotalActividadTipoExitoso()
        {
            for (byte i = 0; i < actividades.Length; i++)
            {
                //ActividadComunidad
                if (actividades[i].Tipo == "Comunidad" && actividades[i].EsExitoso)
                    actividadesComunidadExitosas++;

                //ActividadProveedor
                if (actividades[i].Tipo == "Proveedor" && actividades[i].EsExitoso)
                    actividadesProveedorExitosas++;
            }
        }

        public void TotalAguaUtilizadaPorMunicipio()
        {
            //NO SUPE COMO SACAR EL .Galones, me toco usar (uint)(actividades[i].ArbolesSobrevivientes * 10)
            for (byte i = 0; i < actividades.Length; i++)
            {
                if (actividades[i].Tipo == "Proveedor")
                {
                    //Medellin
                    if (actividades[i].Municipio == "Medellin")
                        aguaUtilizadaPorMunicipio[0] += (uint)(actividades[i].ArbolesSobrevivientes * 10);

                    //Barbosa
                    if (actividades[i].Municipio == "Barbosa")
                        aguaUtilizadaPorMunicipio[1] += (uint)(actividades[i].ArbolesSobrevivientes * 10);

                    //Girardota
                    if (actividades[i].Municipio == "Girardota")
                        aguaUtilizadaPorMunicipio[2] += (uint)(actividades[i].ArbolesSobrevivientes * 10);

                    //Copacabana
                    if (actividades[i].Municipio == "Copacabana")
                        aguaUtilizadaPorMunicipio[3] += (uint)(actividades[i].ArbolesSobrevivientes * 10);

                    //Bello
                    if (actividades[i].Municipio == "Bello")
                        aguaUtilizadaPorMunicipio[4] += (uint)(actividades[i].ArbolesSobrevivientes * 10);

                    //Itagui
                    if (actividades[i].Municipio == "Itagui")
                        aguaUtilizadaPorMunicipio[5] += (uint)(actividades[i].ArbolesSobrevivientes * 10);

                    //Sabaneta
                    if (actividades[i].Municipio == "Sabaneta")
                        aguaUtilizadaPorMunicipio[6] += (uint)(actividades[i].ArbolesSobrevivientes * 10);

                    //Envigado
                    if (actividades[i].Municipio == "Envigado")
                        aguaUtilizadaPorMunicipio[7] += (uint)(actividades[i].ArbolesSobrevivientes * 10);

                    //La estrella 
                    if (actividades[i].Municipio == "La estrella")
                        aguaUtilizadaPorMunicipio[8] += (uint)(actividades[i].ArbolesSobrevivientes * 10);

                    //Caldas
                    if (actividades[i].Municipio == "Caldas")
                        aguaUtilizadaPorMunicipio[9] += (uint)(actividades[i].ArbolesSobrevivientes * 10);
                }
            }
        }  

        public string ObtieneInfo()
        {
            StringBuilder info = new StringBuilder();
            for (byte i = 0; i < actividades.Length; i++)
                    info.Append($"\nActividad No. {(i + 1)} \n{actividades[i].ToString()}\n");

            return info.ToString();
        }

        public override string ToString()
        {
            string informacion = "\n *** Totales *** \n" +
                                $"Actividades por municipio: \n" +
                                $"Medellin: {actividadesPorMunicipio[0]}\n" +
                                $"Barbosa: {actividadesPorMunicipio[1]}\n" +
                                $"Girardota: {actividadesPorMunicipio[2]}\n" +
                                $"Copacabana: {actividadesPorMunicipio[3]}\n" +
                                $"Bello: {actividadesPorMunicipio[4]}\n" +
                                $"Itagüí: {actividadesPorMunicipio[5]}\n" +
                                $"Sabaneta: {actividadesPorMunicipio[6]}\n" +
                                $"Envigado: {actividadesPorMunicipio[7]}\n" +
                                $"La Estrella: {actividadesPorMunicipio[8]}\n" +
                                $"Caldas: {actividadesPorMunicipio[9]}\n" +
                                $"\nArboles sobrevivientes por municipio: \n" +
                                $"Medellin: {arbolesSobrevivientesPorMunicipio[0]}\n" +
                                $"Barbosa: {arbolesSobrevivientesPorMunicipio[1]}\n" +
                                $"Girardota: {arbolesSobrevivientesPorMunicipio[2]}\n" +
                                $"Copacabana: {arbolesSobrevivientesPorMunicipio[3]}\n" +
                                $"Bello: {arbolesSobrevivientesPorMunicipio[4]}\n" +
                                $"Itagüí: {arbolesSobrevivientesPorMunicipio[5]}\n" +
                                $"Sabaneta: {arbolesSobrevivientesPorMunicipio[6]}\n" +
                                $"Envigado: {arbolesSobrevivientesPorMunicipio[7]}\n" +
                                $"La Estrella: {arbolesSobrevivientesPorMunicipio[8]}\n" +
                                $"Caldas: {arbolesSobrevivientesPorMunicipio[9]}\n" +
                                $"\nActividades por la comunidad exitosas: {actividadesComunidadExitosas}\n" +
                                $"\nActividades por proveedor exitosas: {actividadesProveedorExitosas}\n" +
                                $"\nAgua utilizada por municipio: \n" +
                                $"Medellin: {aguaUtilizadaPorMunicipio[0]}\n" +
                                $"Barbosa: {aguaUtilizadaPorMunicipio[1]}\n" +
                                $"Girardota: {aguaUtilizadaPorMunicipio[2]}\n" +
                                $"Copacabana: {aguaUtilizadaPorMunicipio[3]}\n" +
                                $"Bello: {aguaUtilizadaPorMunicipio[4]}\n" +
                                $"Itagüí: {aguaUtilizadaPorMunicipio[5]}\n" +
                                $"Sabaneta: {aguaUtilizadaPorMunicipio[6]}\n" +
                                $"Envigado: {aguaUtilizadaPorMunicipio[7]}\n" +
                                $"La Estrella: {aguaUtilizadaPorMunicipio[8]}\n" +
                                $"Caldas: {aguaUtilizadaPorMunicipio[9]}\n";

            return informacion;
        }
    }
}