using System;
using NUnit.Framework;
using Should;
using controladores = Babel.Interfaz.WebApi.Controladores;

namespace Babel.Interfaz.WebApi.PruebasUnitarias
{
    [TestFixture]
    public class DiccionarioControladorTest
    {
        [Test]
        public void PruebaCreacionControladorEsCorrecta()
        { 
            //Arrange
            var controlador = new controladores.Diccionarios();
            //Act
            //Assert
            controlador.ShouldBeType<controladores.Diccionarios>();
        }
    }

}

