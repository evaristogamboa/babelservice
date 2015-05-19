using System;
using System.Linq;
using System.Collections.Generic;
using Babel.Nucleo.Aplicacion.Modelos.Peticion;
using Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using Babel.Nucleo.Aplicacion.Fachada;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using Babel.Nucleo.Dominio.Entidades.Etiquetas;
using Babel.Nucleo.Dominio.Repositorios;

namespace Babel.Nucleo.Aplicacion.Servicios
{
    public class AplicacionServicio : IAplicacionMantenimientoDiccionario
    {
        private IDiccionarioRepositorio diccionarioRepositorio;
       

        public AplicacionServicio(IDiccionarioRepositorio repositorioDiccionario)
        {
            this.diccionarioRepositorio = repositorioDiccionario;
        }
        public ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta ConsultarEtiquetasDeDiccionarioPorIdioma(ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion)
        {
            var etiquetasDeDiccionarioPorIdiomaRespuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

            try
            {
                var diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
                List<Etiqueta> listaEtiquetas = new List<Etiqueta>();

                
                listaEtiquetas = diccionario.Etiquetas.Where(e => e.Textos.FirstOrDefault(t => t.Cultura.CodigoIso.Equals(peticion.Idioma)) != null).ToList<Etiqueta>();

                // TODO: Revisar y borrar
                //foreach (Etiqueta item in diccionario.Etiquetas)
                //{
                //    foreach (Traduccion tra in item.Textos)
                //    {
                //        if (tra.Cultura.CodigoIso == peticion.Idioma)
                //        {
                //            Etiqueta nueva = Etiqueta.CrearNuevaEtiqueta(item.Id);
                //            nueva.IdiomaPorDefecto = item.IdiomaPorDefecto;
                //            nueva.Nombre = item.Nombre;
                //            nueva.Textos.Add(tra);

                //            listaEtiquetas.Add(nueva);
                //        }
                //    }
                //}

                etiquetasDeDiccionarioPorIdiomaRespuesta.ListaDeEtiquetas = listaEtiquetas;
                etiquetasDeDiccionarioPorIdiomaRespuesta.Relaciones["diccionario"] = diccionario.Id;
                etiquetasDeDiccionarioPorIdiomaRespuesta.Respuesta = null;
            }
            catch (Exception ex)
            {

                //etiquetasDeDiccionarioPorIdiomaRespuesta.Respuesta = ex.Message;

            }

            return etiquetasDeDiccionarioPorIdiomaRespuesta;
        }

        public ConsultarDiccionariosRespuesta ConsultarDiccionarios()
        {
            var diccionariosRespuesta = ConsultarDiccionariosRespuesta.CrearNuevaInstancia();

            try
            {
                var diccionarios = this.diccionarioRepositorio.ObtenerDiccionarios();

                diccionariosRespuesta.ListaDeDiccionarios = diccionarios;
                diccionariosRespuesta.Respuesta = null;
            }
            catch (Exception ex)
            {
                //etiquetasDeDiccionarioPorIdiomaRespuesta.Respuesta = ex.Message;
            }

            return diccionariosRespuesta;
        }

        
        public ConsultarUnDiccionarioarioRespuesta ConsultarUnDiccionario(ConsultarUnDiccionarioPeticion peticion)
        {

            var unDiccionarioRespuesta = ConsultarUnDiccionarioarioRespuesta.CrearNuevaInstancia(String.Empty);

            try
            {
                var diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);

                unDiccionarioRespuesta.Diccionario = diccionario;
                unDiccionarioRespuesta.Relaciones["diccionario"] = diccionario.Id;
                unDiccionarioRespuesta.Respuesta = null;
            }
            catch (Exception ex)
            {
                //etiquetasDeDiccionarioPorIdiomaRespuesta.Respuesta = ex.Message;
            }

            return unDiccionarioRespuesta;

        }

        public ConsultarEtiquetasDeDiccionarioPorNombreRespuesta ConsultarEtiquetasDeDiccionarioPorNombre(ConsultarEtiquetasDeDiccionarioPorNombrePeticion peticion)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public ConsultarEtiquetasPorNombreRespuesta ConsultarEtiquetasPorNombre(ConsultarEtiquetasPorNombrePeticion peticion)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="peticion"></param>
        /// <returns></returns>
        public CrearUnDiccionarioRespuesta CrearUnDiccionario(CrearUnDiccionarioPeticion peticion)
        {
            //var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioNuevo.Id);


            //if (diccionario != null)
            //{
            //    throw new Exception("Ya existe un diccionario con ese ambiente");
            //}


            var guardaRepositario = diccionarioRepositorio.SalvarUnDiccionario(peticion.DiccionarioNuevo);

            return CrearUnDiccionarioRespuesta.CrearNuevaInstancia(guardaRepositario.Ambiente);
        }

        public ModificarUnDiccionarioRespuesta ModificarUnDiccionario(ModificarUnDiccionarioPeticion peticion)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public EliminarUnDiccionarioRespuesta EliminarUnDiccionario(EliminarUnDiccionarioPeticion peticion)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public AgregarEtiquetasAUnDiccionarioRespuesta AgregarEtiquetasAUnDiccionario(AgregarEtiquetasAUnDiccionarioPeticion peticion)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public ModificarEtiquetasAUnDiccionarioRespuesta ModificarEtiquetasAUnDiccionario(ModificarEtiquetasAUnDiccionarioPeticion peticion)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public EliminarEtiquetasAUnDiccionarioRespuesta EliminarEtiquetasAUnDiccionario(EliminarEtiquetasAUnDiccionarioPeticion peticion)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta AgregarTraduccionesAUnaEtiquetaDeUnDiccionario(AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion peticion)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta ModificarTraduccionesAUnaEtiquetaDeUnDiccionario(ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion peticion)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }

        public EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta EliminarTraduccionesAUnaEtiquetaDeUnDiccionario(EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion peticion)
        {
            // TODO: Implement this method
            throw new NotImplementedException();
        }
    }
}
