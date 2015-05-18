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
		public AplicacionServicio(IDiccionarioRepositorio repositorioDiccionario) {
			this.diccionarioRepositorio = repositorioDiccionario;
		}
		public ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta ConsultarEtiquetasDeDiccionarioPorIdioma(ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion)
		{
			var diccionario=this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
			var etiquetasDeDiccionarioPorIdiomaRespuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();
		
			List<Etiqueta> listaEtiquetas = new List<Etiqueta>();

			foreach (Etiqueta item in diccionario.Etiquetas)
			{	
				foreach (Traduccion tra in item.Textos)
				{
					if (tra.Cultura.CodigoIso == peticion.Idioma)
					{
						Etiqueta nueva = Etiqueta.CrearNuevaEtiqueta(item.Id);
						nueva.IdiomaPorDefecto = item.IdiomaPorDefecto;
						nueva.Nombre = item.Nombre;
						nueva.Textos.Add(tra);

						listaEtiquetas.Add(nueva);	
					}
				}
			}

			etiquetasDeDiccionarioPorIdiomaRespuesta.ListaDeEtiquetas = listaEtiquetas;
			etiquetasDeDiccionarioPorIdiomaRespuesta.Relaciones["diccionario"] = diccionario.Id;
			etiquetasDeDiccionarioPorIdiomaRespuesta.Respuesta = null;

			return etiquetasDeDiccionarioPorIdiomaRespuesta;

		}

		public ConsultarDiccionariosRespuesta ConsultarDiccionarios()
		{
			// TODO: Implement this method
			throw new NotImplementedException();
		}

		public ConsultarUnDiccionarioarioRespuesta ConsultarUnDiccionario(ConsultarUnDiccionarioPeticion peticion)
		{
			// TODO: Implement this method
			throw new NotImplementedException();
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

		public CrearUnDiccionarioRespuesta CrearUnDiccionario(CrearUnDiccionarioPeticion peticion)
		{
			// TODO: Implement this method
			throw new NotImplementedException();
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
