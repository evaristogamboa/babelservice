﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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

               // listaEtiquetas = diccionario.Etiquetas.Where(e => e.Textos.FirstOrDefault(t => t.Cultura.CodigoIso.Equals(peticion.Idioma)) != null).ToList<Etiqueta>();

                // TODO: Revisar y borrar
				foreach (Etiqueta itemEtiqueta in diccionario.Etiquetas)
				{
					foreach (Traduccion itemTraduccion in itemEtiqueta.Textos)
					{
						if (itemTraduccion.Cultura.CodigoIso == peticion.Idioma)
						{
							Etiqueta nuevaEtiqueta = Etiqueta.CrearNuevaEtiqueta(itemEtiqueta.Id);
							nuevaEtiqueta.IdiomaPorDefecto = itemEtiqueta.IdiomaPorDefecto;
							nuevaEtiqueta.Nombre = itemEtiqueta.Nombre;
							nuevaEtiqueta.AgregarTraduccion(itemTraduccion);

							listaEtiquetas.Add(nuevaEtiqueta);
						}
					}
				}

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
           var etiquetasDeDiccionarioPorNombreRespuesta = ConsultarEtiquetasDeDiccionarioPorNombreRespuesta.CrearNuevaInstancia();

            try
            {
                var diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
                List<Etiqueta> listaEtiquetas = new List<Etiqueta>();

               listaEtiquetas = diccionario.Etiquetas.Where(e => e.Nombre.Contains(peticion.Nombre)).ToList<Etiqueta>();

                etiquetasDeDiccionarioPorNombreRespuesta.ListaDeEtiquetas = listaEtiquetas;
                etiquetasDeDiccionarioPorNombreRespuesta.Relaciones["diccionario"] = diccionario.Id;
                etiquetasDeDiccionarioPorNombreRespuesta.Respuesta = null;
			}
			catch (Exception ex)
			{

				//etiquetasDeDiccionarioPorIdiomaRespuesta.Respuesta = ex.Message;

			}

			return etiquetasDeDiccionarioPorNombreRespuesta;
        }

        public ConsultarEtiquetasPorNombreRespuesta ConsultarEtiquetasPorNombre(ConsultarEtiquetasPorNombrePeticion peticion)
        {
			var etiquetasDeDiccionariosPorNombre = ConsultarEtiquetasPorNombreRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionarios = this.diccionarioRepositorio.ObtenerDiccionarios();

				List<Diccionario> listaDeDiccionarios = new List<Diccionario>();

				foreach (Diccionario itemDiccionario in diccionarios)
				{
					Diccionario diccionario = Diccionario.CrearNuevoDiccionario(itemDiccionario.Id, itemDiccionario.Ambiente);

					List<Etiqueta> listaDeEtiquetas = new List<Etiqueta>();

					listaDeEtiquetas = itemDiccionario.Etiquetas.Where(e => e.Nombre.Contains(peticion.Nombre)).ToList<Etiqueta>();

					diccionario.AgregarEtiquetas(listaDeEtiquetas);

					listaDeDiccionarios.Add(diccionario);

				}

				etiquetasDeDiccionariosPorNombre.ListaDeDiccionarios = listaDeDiccionarios;
				etiquetasDeDiccionariosPorNombre.Respuesta = null;
			}
			catch (Exception ex)
			{
				//etiquetasDeDiccionarioPorIdiomaRespuesta.Respuesta = ex.Message;
			}

			return etiquetasDeDiccionariosPorNombre;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="peticion"></param>
        /// <returns></returns>
        public CrearUnDiccionarioRespuesta CrearUnDiccionario(CrearUnDiccionarioPeticion peticion)
        {

            var diccionarioNuevo = Diccionario.CrearNuevoDiccionario(peticion.Ambiente);

            var guardaRepositario = diccionarioRepositorio.SalvarUnDiccionario(diccionarioNuevo);

            CrearUnDiccionarioRespuesta respuesta =
                CrearUnDiccionarioRespuesta.CrearNuevaInstancia(guardaRepositario.Ambiente);

            respuesta.DiccionarioNuevo = guardaRepositario;
            respuesta.Relaciones["diccionario"] = guardaRepositario.Id;
            respuesta.Respuesta = null;

            return respuesta;
        }

        /// <summary>
        /// YCM
        /// </summary>
        /// <param name="peticion"></param>
        /// <returns></returns>
        public ModificarUnDiccionarioRespuesta ModificarUnDiccionario(ModificarUnDiccionarioPeticion peticion)
        {
            var unDiccionarioRespuesta = ModificarUnDiccionarioRespuesta.CrearNuevaInstancia();

            try
            {
                var guardarRepositorio = diccionarioRepositorio.SalvarUnDiccionario(peticion.Diccionario);

                unDiccionarioRespuesta.Diccionario = guardarRepositorio;
                unDiccionarioRespuesta.Relaciones["diccionario"] = guardarRepositorio.Id;
                unDiccionarioRespuesta.Respuesta = null;
            }
            catch(Exception)
            {
                //etiquetasDeDiccionarioPorIdiomaRespuesta.Respuesta = ex.Message;
            }

            return unDiccionarioRespuesta;

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
			var eliminarTraduccionesAUnaEtiquetaDeUnDiccionario = EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);

				var etiqueta = diccionario.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault();

				foreach (Traduccion itemTraduccion in peticion.ListaDeTraducciones)
				{
					etiqueta = etiqueta.EliminarTraduccion(itemTraduccion);
				}

				List<Etiqueta> listaDeEtiquetas = new List<Etiqueta>();

				listaDeEtiquetas.Add(etiqueta);

				diccionario = diccionario.ModificarEtiquetas(listaDeEtiquetas);

				var diccionarioModificado = this.diccionarioRepositorio.SalvarUnDiccionario(diccionario);

				eliminarTraduccionesAUnaEtiquetaDeUnDiccionario.ListaDeTraducciones = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Textos.ToList();
				eliminarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["diccionario"] = diccionarioModificado.Id;
				eliminarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["etiqueta"] = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Id;
				eliminarTraduccionesAUnaEtiquetaDeUnDiccionario.Respuesta = null;
			}
			catch (Exception ex)
			{
				string mensaje = ex.Message;
				//etiquetasDeDiccionarioPorIdiomaRespuesta.Respuesta = ex.Message;
			}

			return eliminarTraduccionesAUnaEtiquetaDeUnDiccionario;
        }
    }
}
