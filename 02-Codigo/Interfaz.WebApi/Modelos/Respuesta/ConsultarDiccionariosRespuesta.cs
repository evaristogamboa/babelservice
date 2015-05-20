using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using app = Babel.Nucleo.Aplicacion.Modelos;
using dominio = Babel.Nucleo.Dominio.Entidades.Diccionario;

namespace Babel.Interfaz.WebApi.Modelos.Respuesta
{
    
    public class ConsultarDiccionariosRespuesta : IEquatable<ConsultarDiccionariosRespuesta>
    {
        [JsonProperty(PropertyName = "diccionarios")]
        public List<dominio.Diccionario> ListaDeDiccionarios { get; set; }

        [JsonProperty(PropertyName = "respuesta")]
		public app.ModeloRespuesta Respuesta { get; set; }

		#region constructores

		private ConsultarDiccionariosRespuesta()
		{
		}
        private ConsultarDiccionariosRespuesta(app.Respuesta.ConsultarDiccionariosRespuesta respuestaApp)
        {
            this.ListaDeDiccionarios = respuestaApp.ListaDeDiccionarios;
            this.Respuesta = respuestaApp.Respuesta;
        }

        public static ConsultarDiccionariosRespuesta CrearNuevaRespuestaConRespuestaDeAplicacion(app.Respuesta.ConsultarDiccionariosRespuesta respuestaApp)
        {
            return new ConsultarDiccionariosRespuesta(respuestaApp);
        }

        public static ConsultarDiccionariosRespuesta CrearNuevaRespuestaVacia()
        {
			return new ConsultarDiccionariosRespuesta();
		}
		#endregion

        #region igualdad
        public override int GetHashCode()
        {
            unchecked
            {
                int result = 17;
                result = result * 23 + ((ListaDeDiccionarios != null) ? this.ListaDeDiccionarios.GetHashCode() : 0);
                result = result * 23 + ((Respuesta != null) ? this.Respuesta.GetHashCode() : 0);
                return result;
            }
        }

        public bool Equals(ConsultarDiccionariosRespuesta other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }
            if (ReferenceEquals(this, other))
            {
                return true;
            }
            return Equals(this.ListaDeDiccionarios, other.ListaDeDiccionarios) &&
                   Equals(this.Respuesta, other.Respuesta);
        }

        public override bool Equals(object obj)
        {
            ConsultarDiccionariosRespuesta temp = obj as ConsultarDiccionariosRespuesta;
            if (temp == null)
                return false;
            return this.Equals(temp);
        }
        #endregion
    }
}
