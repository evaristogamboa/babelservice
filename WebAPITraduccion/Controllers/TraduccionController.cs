using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AccesoDatos;
using System.Collections;
using System.Configuration;
using System.Data.SqlClient;
using WebApiTraduccion.Utils.TraduccionController;
using WebAPITraduccion.Models;
using Negocio.Entidades;

namespace WebAPITraduccion.Controllers
{

	public class TraduccionController : ApiController
	{
		private Diccionario tra;
		private ObtenerTodosLosIdiomas util;
		private ObtenerTodosLosIdiomasResponse response;
		private String ConnectionString = ConfigurationSettings.AppSettings["ConnectionString"];

		[Route("api/idiomas")]

		[HttpGet]
		public HttpResponseMessage ObtenerTodosLosIdiomas()
		{
			GetDependecyObjects();
			DataTable dtresponse=null;			
			HttpResponseMessage response1 = Request.CreateResponse(HttpStatusCode.OK,this.util.GenerarRespuesta(dtresponse) );
			
			return response1;
		}
		private void GetDependecyObjects() {
			//List<Entidades.Traduccion> listaTraducciones = new List<Entidades.Traduccion>();
			//DataTable dtTraducciones = new DataTable();
			//SqlConnection cnn = new SqlConnection(this.ConnectionString);
			//SqlCommand cmd = new SqlCommand("ListaDeTraduccionesIdiomas", cnn);
			//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			//DataTable dataObject = new DataTable();
			//SqlParameterFactory sqlparameterFactory = new SqlParameterFactory();
			//Conexion basedatos = new Conexion(cnn, cmd, adapter, dataObject, sqlparameterFactory);
			//Hashtable parametros = new Hashtable();
			//TraduccionFactory traduccionFactory = new TraduccionFactory();
			//this.response=new ObtenerTodosLosIdiomasResponse(listaTraducciones);
			//this.tra = Traducciones.CrearNuevaTraduccionConParametrosBD(dtTraducciones, basedatos, parametros);
			//this.util = new ObtenerTodosLosIdiomas(traduccionFactory,response);

		}
	}
}
