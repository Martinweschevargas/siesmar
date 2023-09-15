using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dihidronav
{
    public class ActividadDepartamentoHidrografiaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ActividadDepartamentoHidrografiaDTO> ObtenerLista(int? CargaId=null)
        {
            List<ActividadDepartamentoHidrografiaDTO> lista = new List<ActividadDepartamentoHidrografiaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ActividadDepartamentoHidrografiaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ActividadDepartamentoHidrografiaDTO()
                        {
                            ActividadDepartamentoHidrografiaId = Convert.ToInt32(dr["ActividadDepartamentoHidrografiaId"]),
                            NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]),
                            TrabajoEfectuado = dr["TrabajoEfectuado"].ToString(),
                            DescTrabajoHidrografico = dr["DescTrabajoHidrografico"].ToString(),
                            DescZonaNautica = dr["DescZonaNautica"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescProductoResultadoObtenido = dr["DescProductoResultadoObtenido"].ToString(),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            ResponsableActividad = dr["ResponsableActividad"].ToString(),
                            DescGrado = dr["DescGrado"].ToString(),
                            SituacionTrabajoEfectuado = dr["SituacionTrabajoEfectuado"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ActividadDepartamentoHidrografiaDTO actividadDepartamentoHidrografiaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadDepartamentoHidrografiaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = actividadDepartamentoHidrografiaDTO.NumeroOrden;

                    cmd.Parameters.Add("@TrabajoEfectuado", SqlDbType.VarChar,200);
                    cmd.Parameters["@TrabajoEfectuado"].Value = actividadDepartamentoHidrografiaDTO.TrabajoEfectuado;

                    cmd.Parameters.Add("@CodigoTrabajoHidrografico", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTrabajoHidrografico"].Value = actividadDepartamentoHidrografiaDTO.CodigoTrabajoHidrografico;

                    cmd.Parameters.Add("@CodigoZonaNautica", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNautica"].Value = actividadDepartamentoHidrografiaDTO.CodigoZonaNautica;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = actividadDepartamentoHidrografiaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoProductoResultadoObtenido", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProductoResultadoObtenido"].Value = actividadDepartamentoHidrografiaDTO.CodigoProductoResultadoObtenido;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = actividadDepartamentoHidrografiaDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = actividadDepartamentoHidrografiaDTO.FechaTermino;

                    cmd.Parameters.Add("@ResponsableActividad", SqlDbType.VarChar,200);
                    cmd.Parameters["@ResponsableActividad"].Value = actividadDepartamentoHidrografiaDTO.ResponsableActividad;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = actividadDepartamentoHidrografiaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SituacionTrabajoEfectuado", SqlDbType.VarChar,20);
                    cmd.Parameters["@SituacionTrabajoEfectuado"].Value = actividadDepartamentoHidrografiaDTO.SituacionTrabajoEfectuado;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = actividadDepartamentoHidrografiaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadDepartamentoHidrografiaDTO.UsuarioIngresoRegistro;

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

        public ActividadDepartamentoHidrografiaDTO BuscarFormato(int Codigo)
        {
            ActividadDepartamentoHidrografiaDTO actividadDepartamentoHidrografiaDTO = new ActividadDepartamentoHidrografiaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadDepartamentoHidrografiaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadDepartamentoHidrografiaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadDepartamentoHidrografiaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        actividadDepartamentoHidrografiaDTO.ActividadDepartamentoHidrografiaId = Convert.ToInt32(dr["ActividadDepartamentoHidrografiaId"]);
                        actividadDepartamentoHidrografiaDTO.NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]);
                        actividadDepartamentoHidrografiaDTO.TrabajoEfectuado = dr["TrabajoEfectuado"].ToString();
                        actividadDepartamentoHidrografiaDTO.CodigoTrabajoHidrografico = dr["CodigoTrabajoHidrografico"].ToString();
                        actividadDepartamentoHidrografiaDTO.CodigoZonaNautica = dr["CodigoZonaNautica"].ToString();
                        actividadDepartamentoHidrografiaDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        actividadDepartamentoHidrografiaDTO.CodigoProductoResultadoObtenido = dr["CodigoProductoResultadoObtenido"].ToString();
                        actividadDepartamentoHidrografiaDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        actividadDepartamentoHidrografiaDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        actividadDepartamentoHidrografiaDTO.ResponsableActividad = dr["ResponsableActividad"].ToString();
                        actividadDepartamentoHidrografiaDTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        actividadDepartamentoHidrografiaDTO.SituacionTrabajoEfectuado = dr["SituacionTrabajoEfectuado"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return actividadDepartamentoHidrografiaDTO;
        }

        public string ActualizaFormato(ActividadDepartamentoHidrografiaDTO actividadDepartamentoHidrografiaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ActividadDepartamentoHidrografiaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ActividadDepartamentoHidrografiaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadDepartamentoHidrografiaId"].Value = actividadDepartamentoHidrografiaDTO.ActividadDepartamentoHidrografiaId;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = actividadDepartamentoHidrografiaDTO.NumeroOrden;

                    cmd.Parameters.Add("@TrabajoEfectuado", SqlDbType.VarChar, 200);
                    cmd.Parameters["@TrabajoEfectuado"].Value = actividadDepartamentoHidrografiaDTO.TrabajoEfectuado;

                    cmd.Parameters.Add("@CodigoTrabajoHidrografico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTrabajoHidrografico"].Value = actividadDepartamentoHidrografiaDTO.CodigoTrabajoHidrografico;

                    cmd.Parameters.Add("@CodigoZonaNautica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNautica"].Value = actividadDepartamentoHidrografiaDTO.CodigoZonaNautica;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = actividadDepartamentoHidrografiaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoProductoResultadoObtenido", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProductoResultadoObtenido"].Value = actividadDepartamentoHidrografiaDTO.CodigoProductoResultadoObtenido;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = actividadDepartamentoHidrografiaDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = actividadDepartamentoHidrografiaDTO.FechaTermino;

                    cmd.Parameters.Add("@ResponsableActividad", SqlDbType.VarChar, 200);
                    cmd.Parameters["@ResponsableActividad"].Value = actividadDepartamentoHidrografiaDTO.ResponsableActividad;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar", SqlDbType.Int);
                    cmd.Parameters["@CodigoGradoPersonalMilitar"].Value = actividadDepartamentoHidrografiaDTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@SituacionTrabajoEfectuado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SituacionTrabajoEfectuado"].Value = actividadDepartamentoHidrografiaDTO.SituacionTrabajoEfectuado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadDepartamentoHidrografiaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ActividadDepartamentoHidrografiaDTO actividadDepartamentoHidrografiaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadDepartamentoHidrografiaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadDepartamentoHidrografiaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadDepartamentoHidrografiaId"].Value = actividadDepartamentoHidrografiaDTO.ActividadDepartamentoHidrografiaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadDepartamentoHidrografiaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_ActividadDepartamentoHidrografiaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadDepartamentoHidrografia", SqlDbType.Structured);
                    cmd.Parameters["@ActividadDepartamentoHidrografia"].TypeName = "Formato.ActividadDepartamentoHidrografia";
                    cmd.Parameters["@ActividadDepartamentoHidrografia"].Value = datos;

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
