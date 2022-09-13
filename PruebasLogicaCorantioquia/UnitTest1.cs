using System;
using LogicaCorantioquia;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PruebasLogicaCorantioquia
{
    [TestClass]
    public class UnitTest1
    {
        //NO SE PORQUE LAS PRUEBAS ALGUNAS VECES DAN Y OTRAS QUE NO
        [TestMethod]
        public void DebeIdentificarActividadComunidadExitosa()
        {
            ActividadReforestacion[] actividadesPrueba =
            {
                new ActividadReforestacionProveedor() {Municipio = "Barbosa", Tipo = "Proveedor", ArbolesSembrados = 740, Porcentaje = 80f, ArbolesSobrevivientes = 592, Galones = 5920},
                new ActividadReforestacionComunidad() {Municipio = "La estrella", Tipo = "Comunidad", ArbolesSembrados = 951, Porcentaje = 73f, ArbolesSobrevivientes = 694, Personas = 13},
                new ActividadReforestacionComunidad() {Municipio = "Envigado", Tipo = "Comunidad", ArbolesSembrados = 862, Porcentaje = 81f, ArbolesSobrevivientes = 698, Personas = 46},
                new ActividadReforestacionProveedor() {Municipio = "Sabaneta", Tipo = "Proveedor", ArbolesSembrados = 637, Porcentaje = 45f, ArbolesSobrevivientes = 286, Galones = 2860},
            };

            Corantioquia corantioquiaPrueba = new Corantioquia(actividadesPrueba);
            byte actividadesComunidadEsperadas = 0;

            for (byte i = 0; i < actividadesPrueba.Length; i++)
                if (actividadesPrueba[i].Tipo == "Comunidad" && actividadesPrueba[i].EsExitoso)
                    actividadesComunidadEsperadas++;

            byte actividadesComunidadObtenida = corantioquiaPrueba.ActividadesComunidadExitosas;

            Assert.AreEqual(actividadesComunidadEsperadas, actividadesComunidadObtenida);
        }

        [TestMethod]
        public void DebeIdentificarActividadesDeEnvigado()
        {
            ActividadReforestacion[] actividadesPrueba =
            {
                new ActividadReforestacionProveedor() {Municipio = "Barbosa", Tipo = "Proveedor", ArbolesSembrados = 740, Porcentaje = 80f, ArbolesSobrevivientes = 592, Galones = 5920},
                new ActividadReforestacionComunidad() {Municipio = "La estrella", Tipo = "Comunidad", ArbolesSembrados = 951, Porcentaje = 73f, ArbolesSobrevivientes = 694, Personas = 13},
                new ActividadReforestacionComunidad() {Municipio = "Envigado", Tipo = "Comunidad", ArbolesSembrados = 862, Porcentaje = 81f, ArbolesSobrevivientes = 698, Personas = 46},
                new ActividadReforestacionProveedor() {Municipio = "Sabaneta", Tipo = "Proveedor", ArbolesSembrados = 637, Porcentaje = 45f, ArbolesSobrevivientes = 286, Galones = 2860},
            };

            Corantioquia corantioquiaPrueba = new Corantioquia(actividadesPrueba);
            byte actividadesEnEnvigadoEsperadas = 0;

            for (byte i = 0; i < actividadesPrueba.Length; i++)
                if (actividadesPrueba[i].Municipio == "Envigado")
                    actividadesEnEnvigadoEsperadas++;

            byte actividadesEnEnvigadoObtenida = corantioquiaPrueba.ActividadesPorMunicipio[7];

            Assert.AreEqual(actividadesEnEnvigadoEsperadas, actividadesEnEnvigadoObtenida);
        }

        [TestMethod]
        public void DebeIdentificarArbolesSobrevivientesEnMedellin()
        {
            ActividadReforestacion[] actividadesPrueba =
            {
                new ActividadReforestacionProveedor() {Municipio = "Medellin", Tipo = "Proveedor", ArbolesSembrados = 740, Porcentaje = 80f, ArbolesSobrevivientes = 592, Galones = 5920},
                new ActividadReforestacionComunidad() {Municipio = "Medellin", Tipo = "Comunidad", ArbolesSembrados = 951, Porcentaje = 73f, ArbolesSobrevivientes = 694, Personas = 13},
                new ActividadReforestacionComunidad() {Municipio = "Medellin", Tipo = "Comunidad", ArbolesSembrados = 862, Porcentaje = 81f, ArbolesSobrevivientes = 698, Personas = 46},
                new ActividadReforestacionProveedor() {Municipio = "Medellin", Tipo = "Proveedor", ArbolesSembrados = 637, Porcentaje = 45f, ArbolesSobrevivientes = 286, Galones = 2860},
            };

            Corantioquia corantioquiaPrueba = new Corantioquia(actividadesPrueba);
            uint arbolesEnMedellinEsperadas = 0;

            for (byte i = 0; i < actividadesPrueba.Length; i++)
                if (actividadesPrueba[i].Municipio == "Medellin")
                    arbolesEnMedellinEsperadas += actividadesPrueba[i].ArbolesSobrevivientes;

            uint arbolesEnMedellinObtenida = corantioquiaPrueba.ArbolesSobrevivientesPorMunicipio[0];

            Assert.AreEqual(arbolesEnMedellinEsperadas, arbolesEnMedellinObtenida);
        }
    }
}
