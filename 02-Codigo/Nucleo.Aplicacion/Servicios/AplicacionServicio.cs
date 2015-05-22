using System;
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

        public ConsultarDiccionariosRespuesta ConsultarDiccionarios()
        {
            var diccionariosRespuesta = ConsultarDiccionariosRespuesta.CrearNuevaInstancia();

            try
            {
                var diccionarios = this.diccionarioRepositorio.ObtenerDiccionarios();

				if (diccionarios != null)
				{
					if (diccionarios.Count() == 0 )
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
        
        public ConsultarUnDiccionarioarioRespuesta ConsultarUnDiccionario(ConsultarUnDiccionarioPeticion peticion)
        {
            var unDiccionarioRespuesta = ConsultarUnDiccionarioarioRespuesta.CrearNuevaInstancia(String.Empty);

            try
            {
                var diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);

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

		public ConsultarEtiquetasPorNombreRespuesta ConsultarEtiquetasPorNombre(ConsultarEtiquetasPorNombrePeticion peticion)
		{
			var etiquetasDeDiccionariosPorNombre = ConsultarEtiquetasPorNombreRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionarios = this.diccionarioRepositorio.ObtenerDiccionarios();
				List<Diccionario> listaDeDiccionarios = new List<Diccionario>();

				if (diccionarios != null)
				{
					if (diccionarios.Count() != 0)
					{
						foreach (Diccionario itemDiccionario in diccionarios)
						{
							Diccionario diccionario = Diccionario.CrearNuevoDiccionario(itemDiccionario.Id, itemDiccionario.Ambiente);

							List<Etiqueta> listaDeEtiquetas = new List<Etiqueta>();

							listaDeEtiquetas = itemDiccionario.Etiquetas.Where(e => e.Nombre.Contains(peticion.Nombre)).ToList<Etiqueta>();

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

		public ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta ConsultarEtiquetasDeDiccionarioPorIdioma(ConsultarEtiquetasDeDiccionarioPorIdiomaPeticion peticion)
		{
			var etiquetasDeDiccionarioPorIdiomaRespuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
				List<Etiqueta> listaEtiquetas = new List<Etiqueta>();

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
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

        public ConsultarEtiquetasDeDiccionarioPorNombreRespuesta ConsultarEtiquetasDeDiccionarioPorNombre(ConsultarEtiquetasDeDiccionarioPorNombrePeticion peticion)
        {
           var etiquetasDeDiccionarioPorNombreRespuesta = ConsultarEtiquetasDeDiccionarioPorNombreRespuesta.CrearNuevaInstancia();

            try
            {
                var diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
                List<Etiqueta> listaEtiquetas = new List<Etiqueta>();

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						listaEtiquetas = diccionario.Etiquetas.Where(e => e.Nombre.Contains(peticion.Nombre)).ToList<Etiqueta>();
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

		public ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta ConsultarEtiquetasDeDiccionarioPorDescripcion(ConsultarEtiquetasDeDiccionarioPorDescripcionPeticion peticion)
		{
			var etiquetasDeDiccionarioPorDescripcionRespuesta = ConsultarEtiquetasDeDiccionarioPorDescripcionRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
				List<Etiqueta> listaEtiquetas = new List<Etiqueta>();

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						listaEtiquetas = diccionario.Etiquetas.Where(e => e.Descripcion.Contains(peticion.Descripcion)).ToList<Etiqueta>();
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

		public ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta ConsultarEtiquetasDeDiccionarioPorEstatus(ConsultarEtiquetasDeDiccionarioPorEstatusPeticion peticion)
		{
			var etiquetasDeDiccionarioPorEstatusRespuesta = ConsultarEtiquetasDeDiccionarioPorEstatusRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
				List<Etiqueta> listaEtiquetas = new List<Etiqueta>();

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						listaEtiquetas = diccionario.Etiquetas.Where(e => e.Activo.Equals(peticion.Estatus)).ToList<Etiqueta>();
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

		public ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefecto(ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoPeticion peticion)
		{
			var etiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta = ConsultarEtiquetasDeDiccionarioPorIdiomaPorDefectoRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);
				List<Etiqueta> listaEtiquetas = new List<Etiqueta>();

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						listaEtiquetas = diccionario.Etiquetas.Where(e => e.IdiomaPorDefecto.Contains(peticion.IdiomaPorDefecto)).ToList<Etiqueta>();
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

        public CrearUnDiccionarioRespuesta CrearUnDiccionario(CrearUnDiccionarioPeticion peticion)
        {
			CrearUnDiccionarioRespuesta respuesta = CrearUnDiccionarioRespuesta.CrearNuevaInstancia(string.Empty); 

			try
			{
				var diccionarioNuevo = Diccionario.CrearNuevoDiccionario(peticion.Ambiente);
				
				var diccionarioNuevoCreado = diccionarioRepositorio.SalvarUnDiccionario(diccionarioNuevo);

				respuesta.DiccionarioNuevo = diccionarioNuevoCreado;
				respuesta.Relaciones["diccionario"] = diccionarioNuevoCreado.Id;
				respuesta.Respuesta = null;
			}
            catch (Exception ex)
			{
				throw ex;
			}

            return respuesta;
        }

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

						unDiccionarioRespuesta.Diccionario = diccionarioModificado;
						unDiccionarioRespuesta.Relaciones["diccionario"] = diccionarioModificado.Id;
						unDiccionarioRespuesta.Respuesta = null;
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

        public EliminarUnDiccionarioRespuesta EliminarUnDiccionario(EliminarUnDiccionarioPeticion peticion)
        {
            var eliminarDiccionario = EliminarUnDiccionarioRespuesta.CrearNuevaInstancia();

            try
            {
                var diccionarioEliminado = diccionarioRepositorio.EliminarUnDiccionario(peticion.DiccionarioId);
                eliminarDiccionario.ListaDeDiccionarios = diccionarioEliminado;
                eliminarDiccionario.Respuesta = null;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return eliminarDiccionario;
        }

        public AgregarEtiquetasAUnDiccionarioRespuesta AgregarEtiquetasAUnDiccionario(AgregarEtiquetasAUnDiccionarioPeticion peticion)
        {
			var agregarEtiquetasAUnDiccionario = AgregarEtiquetasAUnDiccionarioRespuesta.CrearNuevaInstancia();

			try 
			{
				var diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						diccionario = diccionario.AgregarEtiquetas(peticion.ListaDeEtiquetas);

						var diccionarioModificado = this.diccionarioRepositorio.SalvarUnDiccionario(diccionario);

						agregarEtiquetasAUnDiccionario.ListaDeEtiquetas = diccionarioModificado.Etiquetas.ToList();
						agregarEtiquetasAUnDiccionario.Relaciones["diccionario"] = diccionarioModificado.Id;
						agregarEtiquetasAUnDiccionario.Respuesta = null;
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

						unDiccionarioRespuesta.ListaDeEtiquetas = diccionarioModificado.Etiquetas.ToList();
						unDiccionarioRespuesta.Relaciones["diccionario"] = diccionarioModificado.Id;
						unDiccionarioRespuesta.Respuesta = null;
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

						eliminarEtiquetasDiccionario.ListaDeEtiquetas = diccionarioModificado.Etiquetas.ToList();
						eliminarEtiquetasDiccionario.Relaciones["diccionario"] = diccionarioModificado.Id;
						eliminarEtiquetasDiccionario.Respuesta = null;
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

        public AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta AgregarTraduccionesAUnaEtiquetaDeUnDiccionario(AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion peticion)
        {
			var agregarTraduccionesAUnaEtiquetaDeUnDiccionario = AgregarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						var etiqueta = diccionario.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault();

						if (etiqueta != null)
						{
							etiqueta.AgregarTraducciones(peticion.ListaDeTraducciones);

							diccionario = diccionario.ModificarEtiquetas(new List<Etiqueta> { etiqueta });

							var diccionarioModificado = this.diccionarioRepositorio.SalvarUnDiccionario(diccionario);

							agregarTraduccionesAUnaEtiquetaDeUnDiccionario.ListaDeTraducciones = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Textos.ToList();
							agregarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["diccionario"] = diccionarioModificado.Id;
							agregarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["etiqueta"] = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Id;
							agregarTraduccionesAUnaEtiquetaDeUnDiccionario.Respuesta = null;
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

							modificarTraduccionesAUnaEtiquetaDeUnDiccionario.ListaDeTraducciones = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Textos.ToList();
							modificarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["diccionario"] = diccionarioModificado.Id;
							modificarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["etiqueta"] = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Id;
							modificarTraduccionesAUnaEtiquetaDeUnDiccionario.Respuesta = null;
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

        public EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta EliminarTraduccionesAUnaEtiquetaDeUnDiccionario(EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioPeticion peticion)
        {
			var eliminarTraduccionesAUnaEtiquetaDeUnDiccionario = EliminarTraduccionesAUnaEtiquetaDeUnDiccionarioRespuesta.CrearNuevaInstancia();

			try
			{
				var diccionario = this.diccionarioRepositorio.ObtenerUnDiccionario(peticion.DiccionarioId);

				if (diccionario != null)
				{
					if ((diccionario.Id.ToString() != Guid.Empty.ToString()) && (diccionario.Id.ToString() == peticion.DiccionarioId.ToString()))
					{
						var etiqueta = diccionario.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault();

						if (etiqueta != null)
						{
							etiqueta.EliminarTraducciones(peticion.ListaDeTraducciones);

							diccionario = diccionario.ModificarEtiquetas(new List<Etiqueta> { etiqueta });

							var diccionarioModificado = this.diccionarioRepositorio.SalvarUnDiccionario(diccionario);

							eliminarTraduccionesAUnaEtiquetaDeUnDiccionario.ListaDeTraducciones = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Textos.ToList();
							eliminarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["diccionario"] = diccionarioModificado.Id;
							eliminarTraduccionesAUnaEtiquetaDeUnDiccionario.Relaciones["etiqueta"] = diccionarioModificado.Etiquetas.Where(e => e.Id == peticion.EtiquetaId).ToList().FirstOrDefault().Id;
							eliminarTraduccionesAUnaEtiquetaDeUnDiccionario.Respuesta = null;
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