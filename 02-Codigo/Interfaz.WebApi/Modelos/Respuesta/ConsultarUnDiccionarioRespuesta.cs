using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using app = Babel.Nucleo.Aplicacion.Modelos;
using comunes = Babel.Interfaz.WebApi.Modelos.Comunes;
using CollectionJson;
using Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
    public class ConsultarUnDiccionarioRespuesta : IEquatable<ConsultarUnDiccionarioRespuesta>
    {
        [JsonProperty("diccionario")]
        public comunes.Diccionario Diccionario { get; set; }

        [JsonProperty("relaciones")]
        public Dictionary<string, Guid> Relaciones { get; set; }

        //[JsonProperty("relaciones")]
		//public List<Link> Relaciones2 { get; set; }

        [JsonProperty("respuesta")]
        public app.ModeloRespuesta Respuesta { get; set; }

        #region constructores

        [JsonConstructor]
        private ConsultarUnDiccionarioRespuesta()
        {
            //No implementada ninguna funcionalidad solo como constructor base para el tipo de dato del deserializador de Json
        }

        private ConsultarUnDiccionarioRespuesta(app.Respuesta.ConsultarUnDiccionarioarioRespuesta respuestaApp)
        {
            this.Diccionario = new comunes.Diccionario();
            this.Relaciones = respuestaApp.Relaciones;
            this.Diccionario = MapearRespuestaApp(respuestaApp.Diccionario);
            //this.Relaciones2 = new List<Link>();

            this.Respuesta = respuestaApp.Respuesta;
        }

        public static ConsultarUnDiccionarioRespuesta CrearNuevaRespuestaConRespuestaDeAplicacion(app.Respuesta.ConsultarUnDiccionarioarioRespuesta respuestaApp)
        {
            return new ConsultarUnDiccionarioRespuesta(respuestaApp);
        }

        public static ConsultarUnDiccionarioRespuesta CrearNuevaRespuestaVacia()
        {
            return new ConsultarUnDiccionarioRespuesta();
        }
        #endregion
        #region igualdad
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + ((Diccionario != null) ? this.Diccionario.GetHashCode() : 0);
                result = result * 23 + ((Respuesta != null) ? this.Respuesta.GetHashCode() : 0);
                return result;
            }
        }

        public bool Equals(ConsultarUnDiccionarioRespuesta other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(this.Diccionario, other.Diccionario) &&
                   Equals(this.Respuesta, other.Respuesta);
        }

        public override bool Equals(object obj)
        {
            ConsultarUnDiccionarioRespuesta temp = obj as ConsultarUnDiccionarioRespuesta;
            if (temp == null)
                return false;
            return this.Equals(temp);
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