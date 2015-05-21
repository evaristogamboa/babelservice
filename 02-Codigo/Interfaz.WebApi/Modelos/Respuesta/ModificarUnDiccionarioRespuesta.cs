using Babel.Nucleo.Dominio.Entidades.Diccionario;
using CollectionJson;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using app = Babel.Nucleo.Aplicacion.Modelos;
using comunes = Babel.Interfaz.WebApi.Modelos.Comunes;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
    [JsonObject]
	public class ModificarUnDiccionarioRespuesta
    {

        #region Propiedades

        [JsonProperty("diccionario")]
        public comunes.Diccionario Diccionario { get; set; }
        
        [JsonProperty("relaciones")]
		public List<Link> Relaciones { get; set; }

        #endregion
       
        #region Constructores

        [JsonConstructor]
        private ModificarUnDiccionarioRespuesta()
        {
            //No implementa nada solo se coloca para que pueda ser serializada la clase con las propiedades de tipo json
        }

	    /// <summary>
	    /// 
	    /// </summary>
        private ModificarUnDiccionarioRespuesta(app.Respuesta.ModificarUnDiccionarioRespuesta respuestaApp)
	    {
	        Diccionario = new comunes.Diccionario();
            this.Diccionario = MapearRespuestaApp(respuestaApp.Diccionario);
            this.Diccionario.Ambiente = respuestaApp.Diccionario.Ambiente;
            this.Relaciones = new List<Link>();
	    }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ModificarUnDiccionarioRespuesta CrearNuevaRespuesta(app.Respuesta.ModificarUnDiccionarioRespuesta respuestaApp)
	    {
            return new ModificarUnDiccionarioRespuesta(respuestaApp);
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
