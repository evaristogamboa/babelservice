using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Should;
using Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.Entidades.Etiquetas;
using System.ComponentModel.DataAnnotations;

namespace Nubise.Hc.Utils.I18n.Babel.Nucleo.Dominio.PruebasUnitarias.Entidades
{
    [TestFixture]
    public class CulturaTest
    {
        private List<string> codigosISOCorrectos;
        private List<string> codigosISOErrados;

        public CulturaTest()
        {
            codigosISOCorrectos = new List<string>() { "es", "es-VE" };
            codigosISOErrados = new List<string>() { "esp", "es-ve", "es.VE", "ES-VE", "es-VE." };
        }

        [Category("Creación")]
        [Test]
        public void PruebaCreacionDeNuevaCulturaConCodigoISOCorrectos()
        {
            //Arrange
            //Act
            foreach (var item in codigosISOCorrectos)
            {
                Cultura cultura = Cultura.CrearNuevaCultura(item);

                //Assert
                cultura.CodigoISO.ShouldBeSameAs(item);
            }
        }

        [Category("Creación")]
        [Test]
        public void PruebaCreacionDeNuevaCulturaConCodigoISOErrados()
        {
            //Arrange
            //Act
            foreach (var item in codigosISOErrados)
            {
                //Assert
                Assert.Throws<ValidationException>(delegate
                {
                    Cultura.CrearNuevaCultura(item);
                });
            }
        }
    }
}
