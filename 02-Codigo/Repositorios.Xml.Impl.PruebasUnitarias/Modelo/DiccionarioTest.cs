using NUnit.Framework;
using System.IO;
using System.Xml.Serialization;
using Babel.Repositorio.Xml.Impl.Modelo;
using Should;
using System;
using System.Collections.Generic;
using EntidadRepo = Babel.Repositorio.Xml.Impl.Modelo;
using EntidadDom = Babel.Nucleo.Dominio.Entidades;
using AutoMapper;

namespace Babel.Repositorio.Xml.Impl.PruebasUnitarias.Modelo
{
    [TestFixture]
    public class DiccionarioTest
    {


        private const string ambienteTestPrueba = "Prueba";
        private const string ambienteTestDesarrollo = "Desarrollo";
        
        public Diccionarios Diccionarios { get; set; }

        public Diccionario DiccionarioEs { get; set; }


        public Diccionario DiccionarioEn { get; set; }

        public Etiquetas Etiquetas { get; set; }

        public Etiqueta Etiqueta { get; set; }

        public EntidadDom.Etiquetas.Etiqueta EtiquetaDom { get; set; }

        public EntidadDom.Etiquetas.Traduccion TraduccionDom { get; set; }


        private EntidadRepo.Diccionarios DiccionariosRepositorio { get; set; }


        private EntidadDom.Diccionario.Diccionario DiccionarioDominio { get; set; }

        private EntidadDom.Diccionario.Diccionario DiccionarioDominio2 { get; set; }

        private readonly Babel.Nucleo.Dominio.Entidades.Etiquetas.Cultura cultura;
        private readonly string texto;

        private Babel.Nucleo.Dominio.Entidades.Etiquetas.Etiqueta Etiq { get; set; }
             
        


        public Traducciones Traducciones { get; set; }

        //private string Directory = Environment.GetFolderPath (Environment.SpecialFolder.MyDocuments) + @"\Xml.xml";
        private readonly string directory = "DatosPrueba\\diccionario_ok.xml";

        

        //public DiccionarioTest()
        //{

        //    var traduccion1 = new Traduccion ("es-VE", "aceptar2", "aceptar2");
        //    var traduccion2 = new Traduccion ("es", "aceptar2", "aceptar2");
        //    var Traducciones1 = new Traducciones ();
        //    Traducciones1.Traducciones1.Add (traduccion1);
        //    Traducciones1.Traducciones1.Add (traduccion2);
        //    Etiqueta = new Etiqueta ();
        //    Etiqueta.Nombre = "app.common.aceptar2";
        //    Etiqueta.Descripcion = "johans";
        //    Etiqueta.Traducciones = Traducciones1;
        //    Etiqueta.NombreEtiqueta = Etiqueta.Nombre;
        //    Etiquetas = new Etiquetas (Etiqueta);
        //    Diccionario = new Diccionario("dev");
        //    Diccionario.Etiquetas = Etiquetas;

        //    this.Diccionarios = new Diccionarios(Diccionario);
            


        //}       


    }
}

