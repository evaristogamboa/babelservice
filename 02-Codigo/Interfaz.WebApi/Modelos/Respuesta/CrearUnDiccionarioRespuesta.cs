using System;
using System.Collections.Generic;
using System.Linq;
using app=Babel.Nucleo.Aplicacion.Modelos.Respuesta;
using Babel.Nucleo.Dominio.Entidades.Diccionario;
using CollectionJson;
using Newtonsoft.Json;
using comunes=Babel.Interfaz.WebApi.Modelos.Comunes;


namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
	public class CrearUnDiccionarioRespuesta
	{
        [JsonProperty(PropertyName = "diccionario")]
		public comunes.Diccionario DiccionarioNuevo { get; set; }
        
        [JsonProperty(PropertyName = "relaciones")]
		public List<Link> Relaciones { get; set; }

		#region constructores

        CrearUnDiccionarioRespuesta(app.CrearUnDiccionarioRespuesta respuestaApp)
        {
            this.DiccionarioNuevo = new comunes.Diccionario();
            this.DiccionarioNuevo.Ambiente = respuestaApp.DiccionarioNuevo.Ambiente;
            this.DiccionarioNuevo = MapearRespuestaApp(respuestaApp.DiccionarioNuevo);
            this.Relaciones = new List<Link>();
        }

        public CrearUnDiccionarioRespuesta() 
        { 
        }

        public static CrearUnDiccionarioRespuesta CrearNuevaRespuesta(app.CrearUnDiccionarioRespuesta respuestaApp)
		{
			return new CrearUnDiccionarioRespuesta(respuestaApp);
		}

		#endregion

        private comunes.Diccionario MapearRespuestaApp(Diccionario diccionarioDom)
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

	}
}