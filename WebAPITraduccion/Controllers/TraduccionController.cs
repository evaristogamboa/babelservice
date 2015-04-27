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
using WebApEtiqueta.Utils.EtiquetaController;
using WebAPEtiqueta.Models;
using Negocio.Entidades;

namespace WebAPEtiqueta.Controllers
{

	public class EtiquetaController : ApiController
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
			//List<Entidades.Etiqueta> listaEtiquetaes = new List<Entidades.Etiqueta>();
			//DataTable dtEtiquetaes = new DataTable();
			//SqlConnection cnn = new SqlConnection(this.ConnectionString);
			//SqlCommand cmd = new SqlCommand("ListaDeEtiquetaesIdiomas", cnn);
			//SqlDataAdapter adapter = new SqlDataAdapter(cmd);
			//DataTable dataObject = new DataTable();
			//SqlParameterFactory sqlparameterFactory = new SqlParameterFactory();
			//Conexion basedatos = new Conexion(cnn, cmd, adapter, dataObject, sqlparameterFactory);
			//Hashtable parametros = new Hashtable();
			//EtiquetaFactory EtiquetaFactory = new EtiquetaFactory();
			//this.response=new ObtenerTodosLosIdiomasResponse(listaEtiquetaes);
			//this.tra = Etiquetaes.CrearNuevaEtiquetaConParametrosBD(dtEtiquetaes, basedatos, parametros);
			//this.util = new ObtenerTodosLosIdiomas(EtiquetaFactory,response);

		}
	}
}
