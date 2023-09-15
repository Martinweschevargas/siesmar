using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dihidronav
{
    public class EvaluacionExpedienteTecnicoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<EvaluacionExpedienteTecnicoDTO> ObtenerLista(int? CargaId=null)
        {
            List<EvaluacionExpedienteTecnicoDTO> lista = new List<EvaluacionExpedienteTecnicoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_EvaluacionExpedienteTecnicoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EvaluacionExpedienteTecnicoDTO()
                        {
                            EvaluacionExpedienteTecnicoId = Convert.ToInt32(dr["EvaluacionExpedienteTecnicoId"]),
                            NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]),
                            DescTipoEstudio = dr["DescTipoEstudio"].ToString(),
                            DescripcionEstudio = dr["DescripcionEstudio"].ToString(),
                            DocumentoRespuesta = dr["DocumentoRespuesta"].ToString(),
                            FechaTerminoEvaluacion = (dr["FechaTerminoEvaluacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            EmpresaPersonaSolicitante = dr["EmpresaPersonaSolicitante"].ToString(),
                            EmpresaRealizaTrabajo = dr["EmpresaRealizaTrabajo"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            CondicionEvaluacion = dr["CondicionEvaluacion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(EvaluacionExpedienteTecnicoDTO evaluacionExpedienteTecnicoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionExpedienteTecnicoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = evaluacionExpedienteTecnicoDTO.NumeroOrden;

                    cmd.Parameters.Add("@CodigoTipoEstudio", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoEstudio"].Value = evaluacionExpedienteTecnicoDTO.CodigoTipoEstudio;

                    cmd.Parameters.Add("@DescripcionEstudio", SqlDbType.VarChar,200);
                    cmd.Parameters["@DescripcionEstudio"].Value = evaluacionExpedienteTecnicoDTO.DescripcionEstudio;

                    cmd.Parameters.Add("@DocumentoRespuesta", SqlDbType.VarChar,20);
                    cmd.Parameters["@DocumentoRespuesta"].Value = evaluacionExpedienteTecnicoDTO.DocumentoRespuesta;

                    cmd.Parameters.Add("@FechaTerminoEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoEvaluacion"].Value = evaluacionExpedienteTecnicoDTO.FechaTerminoEvaluacion;

                    cmd.Parameters.Add("@EmpresaPersonaSolicitante", SqlDbType.VarChar,200);
                    cmd.Parameters["@EmpresaPersonaSolicitante"].Value = evaluacionExpedienteTecnicoDTO.EmpresaPersonaSolicitante;

                    cmd.Parameters.Add("@EmpresaRealizaTrabajo", SqlDbType.VarChar,200);
                    cmd.Parameters["@EmpresaRealizaTrabajo"].Value = evaluacionExpedienteTecnicoDTO.EmpresaRealizaTrabajo;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = evaluacionExpedienteTecnicoDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CondicionEvaluacion", SqlDbType.VarChar,15);
                    cmd.Parameters["@CondicionEvaluacion"].Value = evaluacionExpedienteTecnicoDTO.CondicionEvaluacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = evaluacionExpedienteTecnicoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionExpedienteTecnicoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();



                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    IND_OPERACION = ex.Message;
                }
            }
            return IND_OPERACION;
        }

        public EvaluacionExpedienteTecnicoDTO BuscarFormato(int Codigo)
        {
            EvaluacionExpedienteTecnicoDTO evaluacionExpedienteTecnicoDTO = new EvaluacionExpedienteTecnicoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionExpedienteTecnicoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionExpedienteTecnicoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionExpedienteTecnicoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        evaluacionExpedienteTecnicoDTO.EvaluacionExpedienteTecnicoId = Convert.ToInt32(dr["EvaluacionExpedienteTecnicoId"]);
                        evaluacionExpedienteTecnicoDTO.NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]);
                        evaluacionExpedienteTecnicoDTO.CodigoTipoEstudio = dr["CodigoTipoEstudio"].ToString();
                        evaluacionExpedienteTecnicoDTO.DescripcionEstudio = dr["DescripcionEstudio"].ToString();
                        evaluacionExpedienteTecnicoDTO.DocumentoRespuesta = dr["DocumentoRespuesta"].ToString();
                        evaluacionExpedienteTecnicoDTO.FechaTerminoEvaluacion = Convert.ToDateTime(dr["FechaTerminoEvaluacion"]).ToString("yyy-MM-dd");
                        evaluacionExpedienteTecnicoDTO.EmpresaPersonaSolicitante = dr["EmpresaPersonaSolicitante"].ToString();
                        evaluacionExpedienteTecnicoDTO.EmpresaRealizaTrabajo = dr["EmpresaRealizaTrabajo"].ToString();
                        evaluacionExpedienteTecnicoDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        evaluacionExpedienteTecnicoDTO.CondicionEvaluacion = dr["CondicionEvaluacion"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return evaluacionExpedienteTecnicoDTO;
        }

        public string ActualizaFormato(EvaluacionExpedienteTecnicoDTO evaluacionExpedienteTecnicoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_EvaluacionExpedienteTecnicoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@EvaluacionExpedienteTecnicoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionExpedienteTecnicoId"].Value = evaluacionExpedienteTecnicoDTO.EvaluacionExpedienteTecnicoId;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = evaluacionExpedienteTecnicoDTO.NumeroOrden;

                    cmd.Parameters.Add("@CodigoTipoEstudio", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTipoEstudio"].Value = evaluacionExpedienteTecnicoDTO.CodigoTipoEstudio;

                    cmd.Parameters.Add("@DescripcionEstudio", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescripcionEstudio"].Value = evaluacionExpedienteTecnicoDTO.DescripcionEstudio;

                    cmd.Parameters.Add("@DocumentoRespuesta", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DocumentoRespuesta"].Value = evaluacionExpedienteTecnicoDTO.DocumentoRespuesta;

                    cmd.Parameters.Add("@FechaTerminoEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoEvaluacion"].Value = evaluacionExpedienteTecnicoDTO.FechaTerminoEvaluacion;

                    cmd.Parameters.Add("@EmpresaPersonaSolicitante", SqlDbType.VarChar, 200);
                    cmd.Parameters["@EmpresaPersonaSolicitante"].Value = evaluacionExpedienteTecnicoDTO.EmpresaPersonaSolicitante;

                    cmd.Parameters.Add("@EmpresaRealizaTrabajo", SqlDbType.VarChar, 200);
                    cmd.Parameters["@EmpresaRealizaTrabajo"].Value = evaluacionExpedienteTecnicoDTO.EmpresaRealizaTrabajo;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar,20);
                    cmd.Parameters["@DistritoUbigeo"].Value = evaluacionExpedienteTecnicoDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CondicionEvaluacion", SqlDbType.VarChar, 15);
                    cmd.Parameters["@CondicionEvaluacion"].Value = evaluacionExpedienteTecnicoDTO.CondicionEvaluacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionExpedienteTecnicoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }

        public bool EliminarFormato(EvaluacionExpedienteTecnicoDTO evaluacionExpedienteTecnicoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_EvaluacionExpedienteTecnicoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionExpedienteTecnicoId", SqlDbType.Int);
                    cmd.Parameters["@EvaluacionExpedienteTecnicoId"].Value = evaluacionExpedienteTecnicoDTO.EvaluacionExpedienteTecnicoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = evaluacionExpedienteTecnicoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.ExecuteNonQuery();

                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }


        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_EvaluacionExpedienteTecnicoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EvaluacionExpedienteTecnico", SqlDbType.Structured);
                    cmd.Parameters["@EvaluacionExpedienteTecnico"].TypeName = "Formato.EvaluacionExpedienteTecnico";
                    cmd.Parameters["@EvaluacionExpedienteTecnico"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        dr.Read();
                        if (dr.HasRows)
                        {
                            IND_OPERACION = dr["IND_OPERACION"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                IND_OPERACION = ex.Message;
            }
            return IND_OPERACION;
        }
    }
}
