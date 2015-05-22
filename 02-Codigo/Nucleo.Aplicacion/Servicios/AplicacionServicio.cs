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
	/// <summary>
	/// Fecha creación:	Mayo, 2015.
	/// Descripción:	Capa encargada de manejar todas las consultas, modificaciones, eliminaciones y creaciones que se 
	///					realizan sobre un diccionario, una etiqueta y/o una traducción.
	/// </summary>
    public class AplicacionServicio : IAplicacionMantenimientoDiccionario
    {
        private IDiccionarioRepositorio diccionarioRepositorio;

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Constructor de la clase con la inyección del repositorio.
		/// </summary>
		/// <param name="repositorioDiccionario">Interfaz de acceso al reposiotrio.</param>
		public AplicacionServicio(IDiccionarioRepositorio repositorioDiccionario)
		{
			diccionarioRepositorio = repositorioDiccionario;
		}

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que realiza la consulta de todos los diccionarios que existen en el repositorio.
		/// </summary>
		/// <returns>Retorna un objeto de tipo ConsultarDiccionariosRespuesta que contiene el resultado de la consulta.</returns>
        public ConsultarDiccionariosRespuesta ConsultarDiccionarios()
        {
            var diccionariosRespuesta = ConsultarDiccionariosRespuesta.CrearNuevaInstancia();

            try
            {
                var diccionarios = diccionarioRepositorio.ObtenerDiccionarios();

				if (diccionarios != null)
				{
					if (!diccionarios.Any())
					{
						throw new Exception("No se encontró ningún diccionario.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando los diccionarios.");
				}

                diccionariosRespuesta.ListaDeDiccionarios = diccionarios;
                diccionariosRespuesta.Respuesta = null;
            }
            catch (Exception ex)
            {
				throw ex;
            }

            return diccionariosRespuesta;
        }
        
		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que realiza la consulta de un diccionario, según su identificador, en el repositorio.	
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo ConsultarUnDiccionarioPeticion que contiene el identificador del diccionario que se desea consultar.</param>
		/// <returns>Retorna un objeto de tipo ConsultarUnDiccionarioarioRespuesta que contiene el resultado de la consulta.</returns>
        public ConsultarUnDiccionarioarioRespuesta ConsultarUnDiccionario(ConsultarUnDiccionarioPeticion peticion)
        {
            var unDiccionarioRespuesta = ConsultarUnDiccionarioarioRespuesta.CrearNuevaInstancia(String.Empty);

            try
            {
                var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() == Guid.Empty.ToString()) || (diccionario.Id.ToString() != peticion.DiccionarioId.ToString()))
					{
						throw new Exception("La consulta no retornó el diccionario solicitado.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando el diccionario.");
				}

                unDiccionarioRespuesta.Diccionario = diccionario;
                unDiccionarioRespuesta.Relaciones["diccionario"] = diccionario.Id;
                unDiccionarioRespuesta.Respuesta = null;
            }
            catch (Exception ex)
            {
				throw ex;
            }

            return unDiccionarioRespuesta;
        }

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que realiza la consulta de las etiquetas que contengan el nombre indicado por el usuario, en todos los diccionarios que existen en el repositorio.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo ConsultarEtiquetasPorNombrePeticion que contiene el nombre de las etiquetas que se desean consultar en todos los diccionarios.</param>
		/// <returns>Retorna un objeto de tipo ConsultarEtiquetasPorNombreRespuesta que contiene el resultado de la consulta.</returns>
		public ConsultarEtiquetasPorNombreRespuesta ConsultarEtiquetasPorNombre(ConsultarEtiquetasPorNombrePeticion peticion)
		{
			var etiquetasDeDiccionariosPorNombre = ConsultarEtiquetasPorNombreRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionarios = diccionarioRepositorio.ObtenerDiccionarios();
				var listaDeDiccionarios = new List<Diccionario>();

				if (diccionarios != null)
				{
					if (diccionarios.Count() != 0)
					{
						foreach (var itemDiccionario in diccionarios)
						{
							var diccionario = Diccionario.CrearNuevoDiccionario(itemDiccionario.Id, itemDiccionario.Ambiente);

						    var listaDeEtiquetas = itemDiccionario.Etiquetas.Where(e => e.Nombre.Contains(peticion.Nombre)).ToList();

							diccionario.AgregarEtiquetas(listaDeEtiquetas);

							listaDeDiccionarios.Add(diccionario);
						}
					}
					else
					{
						throw new Exception("No se encontró ningún diccionario.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando los diccionarios.");
				}

				etiquetasDeDiccionariosPorNombre.ListaDeDiccionarios = listaDeDiccionarios;
				etiquetasDeDiccionariosPorNombre.Respuesta = null;
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return etiquetasDeDiccionariosPorNombre;
		}

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que realiza la consulta de las etiquetas que contengan una traducción con el idioma indicado por el usuario, en un diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion que contiene el idioma de la traducción de las etiquetas que se desea consultar en un diccionario.</param>
		/// <returns>Retorna un objeto de tipo ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta que contiene el resultado de la consulta.</returns>
		public ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta ConsultarEtiquetasDeDiccionarioPorIdioma(ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion)
		{
			var etiquetasDeDiccionarioPorIdiomaRespuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
				var listaEtiquetas = new List<Etiqueta>();

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						foreach (var itemEtiqueta in diccionario.Etiquetas)
						{
							foreach (var itemTraduccion in itemEtiqueta.Textos)
							{
							    if (itemTraduccion.Cultura.CodigoIso != peticion.Idioma) continue;
							    var nuevaEtiqueta = Etiqueta.CrearNuevaEtiqueta(itemEtiqueta.Id);
							    nuevaEtiqueta.IdiomaPorDefecto = itemEtiqueta.IdiomaPorDefecto;
							    nuevaEtiqueta.Nombre = itemEtiqueta.Nombre;
							    nuevaEtiqueta.AgregarTraduccion(itemTraduccion);

							    listaEtiquetas.Add(nuevaEtiqueta);
							}
						}
					}
					else
					{
						throw new Exception("La consulta no retornó el diccionario solicitado.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando el diccionario.");
				}

				etiquetasDeDiccionarioPorIdiomaRespuesta.ListaDeEtiquetas = listaEtiquetas;
				etiquetasDeDiccionarioPorIdiomaRespuesta.Relaciones["diccionario"] = diccionario.Id;
				etiquetasDeDiccionarioPorIdiomaRespuesta.Respuesta = null;
			}
			catch (Exception ex)
			{

				throw ex;

			}

			return etiquetasDeDiccionarioPorIdiomaRespuesta;
		}

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que realiza la consulta de las etiquetas que contengan el nombre indicado por el usuario, en un diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo ConsultarEtiquetasDeDiccionarioPorNombrePeticion que contiene el nombre de las etiquetas que se desea consultar en un diccionario.</param>
		/// <returns>Retorna un objeto de tipo ConsultarEtiquetasDeDiccionarioPorNombreRespuesta que contiene el resultado de la consulta.</returns>
        public ConsultarEtiquetasDeDiccionarioPorNombreRespuesta ConsultarEtiquetasDeDiccionarioPorNombre(ConsultarEtiquetasDeDiccionarioPorNombrePeticion peticion)
        {
           var etiquetasDeDiccionarioPorNombreRespuesta = ConsultarEtiquetasDeDiccionarioPorNombreRespuesta.CrearNuevaInstancia();

            try
            {
                var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
                List<Etiqueta> listaEtiquetas;

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						listaEtiquetas = diccionario.Etiquetas.Where(e => e.Nombre.Contains(peticion.Nombre)).ToList();
					}
					else
					{
						throw new Exception("La consulta no retornó el diccionario solicitado.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando el diccionario.");
				}

                etiquetasDeDiccionarioPorNombreRespuesta.ListaDeEtiquetas = listaEtiquetas;
                etiquetasDeDiccionarioPorNombreRespuesta.Relaciones["diccionario"] = diccionario.Id;
                etiquetasDeDiccionarioPorNombreRespuesta.Respuesta = null;
			}
			catch (Exception ex)
			{

				throw ex;

			}

			return etiquetasDeDiccionarioPorNombreRespuesta;
        }

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que realiza la consulta de las etiquetas que contengan la descripción indicada por el usuario, en un diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo ConsultarEtiquetasDeDiccionarioPorDescripcionPeticion que contiene la descripción de las etiquetas que se desea consultar en un diccionario.</param>
		/// <returns>Retorna un objeto de tipo ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta que contiene el resultado de la consulta.</returns>
		public ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta ConsultarEtiquetasDeDiccionarioPorDescripcion(ConsultarEtiquetasDeDiccionarioPorDescripcionPeticion peticion)
		{
			var etiquetasDeDiccionarioPorDescripcionRespuesta = ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
				List<Etiqueta> listaEtiquetas;

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						listaEtiquetas = diccionario.Etiquetas.Where(e => e.Descripcion.Contains(peticion.Descripcion)).ToList();
					}
					else
					{
						throw new Exception("La consulta no retornó el diccionario solicitado.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando el diccionario.");
				}

				etiquetasDeDiccionarioPorDescripcionRespuesta.ListaDeEtiquetas = listaEtiquetas;
				etiquetasDeDiccionarioPorDescripcionRespuesta.Relaciones["diccionario"] = diccionario.Id;
				etiquetasDeDiccionarioPorDescripcionRespuesta.Respuesta = null;
			}
			catch (Exception ex)
			{

				throw ex;

			}

			return etiquetasDeDiccionarioPorDescripcionRespuesta;
		}

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que realiza la consulta de las etiquetas que contengan el estatus indicado por el usuario, en un diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo ConsultarEtiquetasDeDiccionarioPorEstatusPeticion que contiene el estatus de las etiquetas que se desea consultar en un diccionario.</param>
		/// <returns>Retorna un objeto de tipo ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta que contiene el resultado de la consulta.</returns>
		public ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta ConsultarEtiquetasDeDiccionarioPorEstatus(ConsultarEtiquetasDeDiccionarioPorEstatusPeticion peticion)
		{
			var etiquetasDeDiccionarioPorEstatusRespuesta = ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
				List<Etiqueta> listaEtiquetas;

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						listaEtiquetas = diccionario.Etiquetas.Where(e => e.Activo.Equals(peticion.Estatus)).ToList();
					}
					else
					{
						throw new Exception("La consulta no retornó el diccionario solicitado.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando el diccionario.");
				}

				etiquetasDeDiccionarioPorEstatusRespuesta.ListaDeEtiquetas = listaEtiquetas;
				etiquetasDeDiccionarioPorEstatusRespuesta.Relaciones["diccionario"] = diccionario.Id;
				etiquetasDeDiccionarioPorEstatusRespuesta.Respuesta = null;
			}
			catch (Exception ex)
			{

				throw ex;

			}

			return etiquetasDeDiccionarioPorEstatusRespuesta;
		}

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que realiza la consulta de las etiquetas que contengan el idioma por defecto indicado por el usuario, en un diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion que contiene el idioma por defecto de las etiquetas que se desea consultar en un diccionario.</param>
		/// <returns>Retorna un objeto de tipo ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta que contiene el resultado de la consulta.</returns>
		public ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto(ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion peticion)
		{
			var etiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
				List<Etiqueta> listaEtiquetas;

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						listaEtiquetas = diccionario.Etiquetas.Where(e => e.IdiomaPorDefecto.Contains(peticion.IdiomaPorDefecto)).ToList();
					}
					else
					{
						throw new Exception("La consulta no retornó el diccionario solicitado.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando el diccionario.");
				}

				etiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta.ListaDeEtiquetas = listaEtiquetas;
				etiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta.Relaciones["diccionario"] = diccionario.Id;
				etiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta.Respuesta = null;
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return etiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta;
		}

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que crea un nuevo diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo CrearUnDiccionarioPeticion que contiene los datos del diccionario a crear.</param>
		/// <returns>Retorna un objeto de tipo CrearUnDiccionarioRespuesta que contiene el diccionario creado.</returns>
        public CrearUnDiccionarioRespuesta CrearUnDiccionario(CrearUnDiccionarioPeticion peticion)
        {
			var respuesta = CrearUnDiccionarioRespuesta.CrearNuevaInstancia(string.Empty); 

			try
			{
				var diccionarioNuevo = Diccionario.CrearNuevoDiccionario(peticion.Ambiente);
				
				var diccionarioNuevoCreado = diccionarioRepositorio.SalvarUnDiccionario(diccionarioNuevo);

				if (diccionarioNuevoCreado != null)
				{
					respuesta.DiccionarioNuevo = diccionarioNuevoCreado;
					respuesta.Relaciones["diccionario"] = diccionarioNuevoCreado.Id;
					respuesta.Respuesta = null;
				}
				else
				{
					throw new Exception("Ocurrió un error guardando los cambios en el diccionario.");
				}
			}
            catch (Exception ex)
			{
				throw ex;
			}

            return respuesta;
        }

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que modifica los datos de un diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo ModificarUnDiccionarioPeticion que contiene los datos a modificar de un diccionario.</param>
		/// <returns>Retorna un objeto de tipo ModificarUnDiccionarioRespuesta que contiene el diccionario modificado.</returns>
        public ModificarUnDiccionarioRespuesta ModificarUnDiccionario(ModificarUnDiccionarioPeticion peticion)
        {
            var unDiccionarioRespuesta = ModificarUnDiccionarioRespuesta.CrearNuevaInstancia();

            try
            {
                var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.Diccionario.Id);

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.Diccionario.Id.ToString()))
					{
						diccionario.Ambiente = peticion.Diccionario.Ambiente;
						var diccionarioModificado = diccionarioRepositorio.SalvarUnDiccionario(diccionario);

						if (diccionarioModificado != null)
						{
							unDiccionarioRespuesta.Diccionario = diccionarioModificado;
							unDiccionarioRespuesta.Relaciones["diccionario"] = diccionarioModificado.Id;
							unDiccionarioRespuesta.Respuesta = null;
						}
						else
						{
							throw new Exception("Ocurrió un error guardando los cambios en el diccionario.");
						}
					}
					else
					{
						throw new Exception("La consulta no retornó el diccionario solicitado.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando los diccionarios.");
				}
            }
            catch (Exception ex)
            {
				throw ex;
            }

            return unDiccionarioRespuesta;
        }

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que elimina un diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo EliminarUnDiccionarioPeticion que contiene el identificador del diccionario a eliminar.</param>
		/// <returns>Retorna un objeto de tipo EliminarUnDiccionarioRespuesta que contiene la lista de los diccionarios restantes, es decir, los que no se eliminaron.</returns>
        public EliminarUnDiccionarioRespuesta EliminarUnDiccionario(EliminarUnDiccionarioPeticion peticion)
        {
            var eliminarDiccionario = EliminarUnDiccionarioRespuesta.CrearNuevaInstancia();

            try
            {
                var diccionariosRestantes = diccionarioRepositorio.EliminarUnDiccionario(peticion.DiccionarioId);

				var diccionarioModificado = diccionarioRepositorio.SalvarDiccionarios(diccionariosRestantes);

				if (diccionarioModificado != null)
				{
					eliminarDiccionario.ListaDeDiccionarios = diccionarioModificado.ToList();
					eliminarDiccionario.Respuesta = null;
				}
				else
				{
					throw new Exception("Ocurrió un error guardando los cambios en el diccionario.");
				}
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return eliminarDiccionario;
        }

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que agrega una o más etiquetas de un diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo AgregarEtiquetasAUnDiccionarioPeticion que contiene la lista de etiquetas a agregar de un diccionario.</param>
		/// <returns>Retorna un objeto de tipo AgregarEtiquetasAUnDiccionarioRespuesta que contiene la lista de etiquetas que contiene el diccionario.</returns>
        public AgregarEtiquetasAUnDiccionarioRespuesta AgregarEtiquetasAUnDiccionario(AgregarEtiquetasAUnDiccionarioPeticion peticion)
        {
			var agregarEtiquetasAUnDiccionario = AgregarEtiquetasAUnDiccionarioRespuesta.CrearNuevaInstancia();

			try 
			{
				var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						diccionario = diccionario.AgregarEtiquetas(peticion.ListaDeEtiquetas);

						var diccionarioModificado = diccionarioRepositorio.SalvarUnDiccionario(diccionario);

						if (diccionarioModificado != null)
						{
							agregarEtiquetasAUnDiccionario.ListaDeEtiquetas = diccionarioModificado.Etiquetas.ToList();
							agregarEtiquetasAUnDiccionario.Relaciones["diccionario"] = diccionarioModificado.Id;
							agregarEtiquetasAUnDiccionario.Respuesta = null;
						}
						else
						{
							throw new Exception("Ocurrió un error guardando los cambios en el diccionario.");
						}
					}
					else
					{
						throw new Exception("La consulta no retornó el diccionario solicitado.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando los diccionarios.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return agregarEtiquetasAUnDiccionario;
        }

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que modifica una o más etiquetas de un diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo ModificarEtiquetasAUnDiccionarioPeticion que contiene la lista de etiquetas a modificar de un diccionario.</param>
		/// <returns>Retorna un objeto de tipo ModificarEtiquetasAUnDiccionarioRespuesta que contiene la lista de etiquetas que contiene el diccionario.</returns>
        public ModificarEtiquetasAUnDiccionarioRespuesta ModificarEtiquetasAUnDiccionario(ModificarEtiquetasAUnDiccionarioPeticion peticion)
        {
            var unDiccionarioRespuesta = ModificarEtiquetasAUnDiccionarioRespuesta.CrearNuevaInstancia();

            try
            {
                var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
                
				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						diccionario = diccionario.ModificarEtiquetas(peticion.ListaDeEtiquetas);

						var diccionarioModificado = diccionarioRepositorio.SalvarUnDiccionario(diccionario);

						if (diccionarioModificado != null)
						{
							unDiccionarioRespuesta.ListaDeEtiquetas = diccionarioModificado.Etiquetas.ToList();
							unDiccionarioRespuesta.Relaciones["diccionario"] = diccionarioModificado.Id;
							unDiccionarioRespuesta.Respuesta = null;
						}
						else
						{
							throw new Exception("Ocurrió un error guardando los cambios en el diccionario.");
						}
					}
					else
					{
						throw new Exception("La consulta no retornó el diccionario solicitado.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando los diccionarios.");
				}
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return unDiccionarioRespuesta;
        }

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que elimina una o más etiquetas de un diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo EliminarEtiquetasAUnDiccionarioPeticion que contiene la lista de etiquetas a eliminar de un diccionario.</param>
		/// <returns>Retorna un objeto de tipo EliminarEtiquetasAUnDiccionarioRespuesta que contiene la lista de etiquetas que contiene el diccionario.</returns>
        public EliminarEtiquetasAUnDiccionarioRespuesta EliminarEtiquetasAUnDiccionario(EliminarEtiquetasAUnDiccionarioPeticion peticion)
        {
            var eliminarEtiquetasDiccionario = EliminarEtiquetasAUnDiccionarioRespuesta.CrearNuevaInstancia();

            try
            {
                var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						var etiquetasDiccionario = peticion.ListaDeEtiquetas;

						diccionario = etiquetasDiccionario.Aggregate(diccionario, (current, etiquetaDiccionario) => current.EliminarEtiqueta(etiquetaDiccionario));

						var diccionarioModificado = diccionarioRepositorio.SalvarUnDiccionario(diccionario);

						if (diccionarioModificado != null)
						{
							eliminarEtiquetasDiccionario.ListaDeEtiquetas = diccionarioModificado.Etiquetas.ToList();
							eliminarEtiquetasDiccionario.Relaciones["diccionario"] = diccionarioModificado.Id;
							eliminarEtiquetasDiccionario.Respuesta = null;
						}
						else
						{
							throw new Exception("Ocurrió un error guardando los cambios en el diccionario.");
						}
					}
					else
					{
						throw new Exception("La consulta no retornó el diccionario solicitado.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando los diccionarios.");
				}
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return eliminarEtiquetasDiccionario;
        }

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que agrega una o más traducciones de una etiqueta de un diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion que contiene la lista de traducciones a agregar de una etiqueta de un diccionario.</param>
		/// <returns>Retorna un objeto de tipo AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta que contiene la lista de traducciones de una etiqueta de un diccionario.</returns>
        public AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta AgregarTraduccionesAUnaEtiquetaDeUnDiccionario(AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion peticion)
        {
			var agregarTraduccionesAUnaEtiquetaDeUnDiccionario = AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						var etiqueta = diccionario.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault();

						if (etiqueta != null)
						{
							etiqueta.AgregarTraducciones(peticion.ListaDeTraducciones);

							diccionario = diccionario.ModificarEtiquetas(new List<Etiqueta> { etiqueta });

							var diccionarioModificado = diccionarioRepositorio.SalvarUnDiccionario(diccionario);

							if (diccionarioModificado != null)
							{
								agregarTraduccionesAUnaEtiquetaDeUnDiccionario.ListaDeTraducciones = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Textos.ToList();
								agregarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["diccionario"] = diccionarioModificado.Id;
								agregarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["etiqueta"] = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Id;
								agregarTraduccionesAUnaEtiquetaDeUnDiccionario.Respuesta = null;
							}
							else
							{
								throw new Exception("Ocurrió un error guardando los cambios en el diccionario.");
							}
						}
						else
						{
							throw new Exception("La consulta no retornó la etiqueta solicitada.");
						}
					}
					else
					{
						throw new Exception("La consulta no retornó el diccionario solicitado.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando los diccionarios.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

            return agregarTraduccionesAUnaEtiquetaDeUnDiccionario;
        }

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que modifica una o más traducciones de una etiqueta de un diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion que contiene la lista de traducciones a modificar de una etiqueta de un diccionario.</param>
		/// <returns>Retorna un objeto de tipo ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta que contiene la lista de traducciones de una etiqueta de un diccionario.</returns>
        public ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta ModificarTraduccionesAUnaEtiquetaDeUnDiccionario(ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion peticion)
        {
			var modificarTraduccionesAUnaEtiquetaDeUnDiccionario = ModificarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						var etiqueta = diccionario.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault();

						if (etiqueta != null)
						{
							etiqueta.ModificarTraducciones(peticion.ListaDeTraducciones);

							diccionario = diccionario.ModificarEtiquetas(new List<Etiqueta> { etiqueta });

							var diccionarioModificado = diccionarioRepositorio.SalvarUnDiccionario(diccionario);

							if (diccionarioModificado != null)
							{
								modificarTraduccionesAUnaEtiquetaDeUnDiccionario.ListaDeTraducciones = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Textos.ToList();
								modificarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["diccionario"] = diccionarioModificado.Id;
								modificarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["etiqueta"] = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Id;
								modificarTraduccionesAUnaEtiquetaDeUnDiccionario.Respuesta = null;
							}
							else
							{
								throw new Exception("Ocurrió un error guardando los cambios en el diccionario.");
							}
						}
						else
						{
							throw new Exception("La consulta no retornó la etiqueta solicitada.");
						}
					}
					else
					{
						throw new Exception("La consulta no retornó el diccionario solicitado.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando los diccionarios.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return modificarTraduccionesAUnaEtiquetaDeUnDiccionario;
        }

		/// <summary>
		/// Fecha creación:	Mayo, 2015.
		/// Descripción:	Método que elimina una o más traducciones de una etiqueta de un diccionario.
		/// </summary>
		/// <param name="peticion">Se recibe un objeto de tipo EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion que contiene la lista de traducciones a eliminar de una etiqueta de un diccionario.</param>
		/// <returns>Retorna un objeto de tipo EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta que contiene la lista de traducciones de una etiqueta de un diccionario.</returns>
        public EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta EliminarTraduccionesAUnaEtiquetaDeUnDiccionario(EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion peticion)
        {
			var eliminarTraduccionesAUnaEtiquetaDeUnDiccionario = EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						var etiqueta = diccionario.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault();

						if (etiqueta != null)
						{
							etiqueta.EliminarTraducciones(peticion.ListaDeTraducciones);

							diccionario = diccionario.ModificarEtiquetas(new List<Etiqueta> { etiqueta });

							var diccionarioModificado = diccionarioRepositorio.SalvarUnDiccionario(diccionario);

							if (diccionarioModificado != null)
							{
								eliminarTraduccionesAUnaEtiquetaDeUnDiccionario.ListaDeTraducciones = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Textos.ToList();
								eliminarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["diccionario"] = diccionarioModificado.Id;
								eliminarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["etiqueta"] = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Id;
								eliminarTraduccionesAUnaEtiquetaDeUnDiccionario.Respuesta = null;
								
							}
							else
							{
								throw new Exception("Ocurrió un error guardando los cambios en el diccionario.");
							}
						}
						else
						{
							throw new Exception("La consulta no retornó la etiqueta solicitada.");
						}
					}
					else
					{
						throw new Exception("La consulta no retornó el diccionario solicitado.");
					}
				}
				else
				{
					throw new Exception("Ocurrió un error consultando los diccionarios.");
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return eliminarTraduccionesAUnaEtiquetaDeUnDiccionario;
        }
    }
}