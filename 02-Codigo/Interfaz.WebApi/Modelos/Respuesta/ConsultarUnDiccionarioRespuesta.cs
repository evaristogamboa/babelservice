using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using Newtonsoft.Json;
using comunes = Babel.Interfaz.WebApi.Modelos.Comunes;
using CollectionJson;
using app = Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using Babel.Interfaz.WebApi.Modelos.Comunes;
using dominio = Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
	public class ConsultarUnDiccionarioRespuesta
	{
        [JsonProperty(PropertyName = "diccionario")]
		public comunes.Diccionario Diccionario { get; set; }
        
        [JsonProperty(PropertyName = "relaciones")]
		public List<Link> Relaciones { get; set; }

		#region constructores

        private ConsultarUnDiccionarioRespuesta(app.ConsultarUnDiccionarioarioRespuesta respuestaApp)
        {
            this.Diccionario = new comunes.Diccionario();
            this.Diccionario.Ambiente = respuestaApp.Diccionario.Ambiente;
            this.Diccionario = MapearRespuestaApp(respuestaApp.Diccionario);
            this.Relaciones = new List<Link>();
        }

        private comunes.Diccionario MapearRespuestaApp(dominio.Diccionario diccionarioDom)
        {
            var dicctionarioRepo = new comunes.Diccionario() { Id = diccionarioDom.Id };

            dicctionarioRepo.Etiquetas = new comunes.Etiquetas();

            foreach (var etiqueta in diccionarioDom.Etiquetas)
            {

                var etiquetaMapper = new comunes.Etiqueta()
                {

                    Activo = etiqueta.Activo,
                    Descripcion = etiqueta.Descripcion,
                    Id = etiqueta.Id,
                    IdiomaPorDefecto = etiqueta.IdiomaPorDefecto,
                    Nombre = etiqueta.Nombre,
                    NombreEtiqueta = etiqueta.Nombre,
                    Traducciones = new comunes.Traducciones()

                };


                foreach (var texto in etiqueta.Textos)
                {

                    var textoMapper = new comunes.Traduccion()
                    {
                        Cultura = texto.Cultura.CodigoIso.ToString(),
                        Tooltip = texto.ToolTip,
                        Value = texto.Texto
                    };

                    etiquetaMapper.Traducciones.Traducciones1.Add(textoMapper);
                }

                dicctionarioRepo.Etiquetas.ListaEtiquetas.Add(etiquetaMapper);

            }

            return dicctionarioRepo;
        }
        public CrearUnDiccionarioRespuesta() 
        { 
        }

        public static CrearUnDiccionarioRespuesta CrearNuevaRespuesta(app.CrearUnDiccionarioRespuesta respuestaApp)
		{
			return new CrearUnDiccionarioRespuesta(respuestaApp);
		}

		#endregion

        public static ConsultarUnDiccionarioRespuesta CrearNuevaRespuestaConRespuestaDeAplicacion(Nucleo.Aplicacion.Modelos.Respuesta.ConsultarUnDiccionarioarioRespuesta respuestaApp)
        {
            throw new NotImplementedException();
        }
    }
}
