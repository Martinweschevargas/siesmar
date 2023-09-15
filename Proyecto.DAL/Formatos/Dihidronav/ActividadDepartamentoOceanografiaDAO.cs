using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dihidronav;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dihidronav
{
    public class ActividadDepartamentoOceanografiaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<ActividadDepartamentoOceanografiaDTO> ObtenerLista(int? CargaId=null)
        {
            List<ActividadDepartamentoOceanografiaDTO> lista = new List<ActividadDepartamentoOceanografiaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_ActividadDepartamentoOceanografiaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ActividadDepartamentoOceanografiaDTO()
                        {
                            ActividadDepartamentoOceanografiaId = Convert.ToInt32(dr["ActividadDepartamentoOceanografiaId"]),
                            NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]),
                            DescTrabajoOceanografico = dr["DescTrabajoOceanografico"].ToString(),
                            DescripcionTrabajoEfectuado = dr["DescripcionTrabajoEfectuado"].ToString(),
                            DescZonaNautica = dr["DescZonaNautica"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            FechaInicio = (dr["FechaInicio"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTermino = (dr["FechaTermino"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            SituacionTrabajoEfectuado = dr["SituacionTrabajoEfectuado"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(ActividadDepartamentoOceanografiaDTO actividadDepartamentoOceanografiaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadDepartamentoOceanografiaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = actividadDepartamentoOceanografiaDTO.NumeroOrden;

                    cmd.Parameters.Add("@CodigoTrabajoOceanografico", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTrabajoOceanografico"].Value = actividadDepartamentoOceanografiaDTO.CodigoTrabajoOceanografico;

                    cmd.Parameters.Add("@DescripcionTrabajoEfectuado", SqlDbType.VarChar, 500);
                    cmd.Parameters["@DescripcionTrabajoEfectuado"].Value = actividadDepartamentoOceanografiaDTO.DescripcionTrabajoEfectuado;

                    cmd.Parameters.Add("@CodigoZonaNautica", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoZonaNautica"].Value = actividadDepartamentoOceanografiaDTO.CodigoZonaNautica;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 6);
                    cmd.Parameters["@DistritoUbigeo"].Value = actividadDepartamentoOceanografiaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = actividadDepartamentoOceanografiaDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = actividadDepartamentoOceanografiaDTO.FechaTermino;

                    cmd.Parameters.Add("@SituacionTrabajoEfectuado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@SituacionTrabajoEfectuado"].Value = actividadDepartamentoOceanografiaDTO.SituacionTrabajoEfectuado;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = actividadDepartamentoOceanografiaDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadDepartamentoOceanografiaDTO.UsuarioIngresoRegistro;

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

        public ActividadDepartamentoOceanografiaDTO BuscarFormato(int Codigo)
        {
            ActividadDepartamentoOceanografiaDTO actividadDepartamentoOceanografiaDTO = new ActividadDepartamentoOceanografiaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadDepartamentoOceanografiaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadDepartamentoOceanografiaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadDepartamentoOceanografiaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        actividadDepartamentoOceanografiaDTO.ActividadDepartamentoOceanografiaId = Convert.ToInt32(dr["ActividadDepartamentoOceanografiaId"]);
                        actividadDepartamentoOceanografiaDTO.NumeroOrden = Convert.ToInt32(dr["NumeroOrden"]);
                        actividadDepartamentoOceanografiaDTO.CodigoTrabajoOceanografico = dr["CodigoTrabajoOceanografico"].ToString();
                        actividadDepartamentoOceanografiaDTO.DescripcionTrabajoEfectuado = dr["DescripcionTrabajoEfectuado"].ToString();
                        actividadDepartamentoOceanografiaDTO.CodigoZonaNautica = dr["CodigoZonaNautica"].ToString();
                        actividadDepartamentoOceanografiaDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        actividadDepartamentoOceanografiaDTO.FechaInicio = Convert.ToDateTime(dr["FechaInicio"]).ToString("yyy-MM-dd");
                        actividadDepartamentoOceanografiaDTO.FechaTermino = Convert.ToDateTime(dr["FechaTermino"]).ToString("yyy-MM-dd");
                        actividadDepartamentoOceanografiaDTO.SituacionTrabajoEfectuado = dr["SituacionTrabajoEfectuado"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return actividadDepartamentoOceanografiaDTO;
        }

        public string ActualizaFormato(ActividadDepartamentoOceanografiaDTO actividadDepartamentoOceanografiaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_ActividadDepartamentoOceanografiaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ActividadDepartamentoOceanografiaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadDepartamentoOceanografiaId"].Value = actividadDepartamentoOceanografiaDTO.ActividadDepartamentoOceanografiaId;

                    cmd.Parameters.Add("@NumeroOrden", SqlDbType.Int);
                    cmd.Parameters["@NumeroOrden"].Value = actividadDepartamentoOceanografiaDTO.NumeroOrden;

                    cmd.Parameters.Add("@CodigoTrabajoOceanografico", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoTrabajoOceanografico"].Value = actividadDepartamentoOceanografiaDTO.CodigoTrabajoOceanografico;

                    cmd.Parameters.Add("@DescripcionTrabajoEfectuado", SqlDbType.VarChar,500);
                    cmd.Parameters["@DescripcionTrabajoEfectuado"].Value = actividadDepartamentoOceanografiaDTO.DescripcionTrabajoEfectuado;

                    cmd.Parameters.Add("@CodigoZonaNautica", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoZonaNautica"].Value = actividadDepartamentoOceanografiaDTO.CodigoZonaNautica;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar,6);
                    cmd.Parameters["@DistritoUbigeo"].Value = actividadDepartamentoOceanografiaDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                    cmd.Parameters["@FechaInicio"].Value = actividadDepartamentoOceanografiaDTO.FechaInicio;

                    cmd.Parameters.Add("@FechaTermino", SqlDbType.Date);
                    cmd.Parameters["@FechaTermino"].Value = actividadDepartamentoOceanografiaDTO.FechaTermino;

                    cmd.Parameters.Add("@SituacionTrabajoEfectuado", SqlDbType.VarChar,20);
                    cmd.Parameters["@SituacionTrabajoEfectuado"].Value = actividadDepartamentoOceanografiaDTO.SituacionTrabajoEfectuado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadDepartamentoOceanografiaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(ActividadDepartamentoOceanografiaDTO actividadDepartamentoOceanografiaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_ActividadDepartamentoOceanografiaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ActividadDepartamentoOceanografiaId", SqlDbType.Int);
                    cmd.Parameters["@ActividadDepartamentoOceanografiaId"].Value = actividadDepartamentoOceanografiaDTO.ActividadDepartamentoOceanografiaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = actividadDepartamentoOceanografiaDTO.UsuarioIngresoRegistro;

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
            //            string IND_OPERACION = "0";
            //            var cn = new ConfiguracionConexion();

            //            try
            //            {
            //                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            //                {
            //                    conexion.Open();
            //                    var cmd = new SqlCommand("Formato.usp_ActividadDepartamentoOceanografiaRegistrarMasivo", conexion);
            //                    cmd.CommandType = CommandType.StoredProcedure;

            //                    cmd.Parameters.Add("@ActividadDepartamentoOceanografia", SqlDbType.Structured);
            //                    cmd.Parameters["@ActividadDepartamentoOceanografia"].TypeName = "Formato.ActividadDepartamentoOceanografia";
            //                    cmd.Parameters["@ActividadDepartamentoOceanografia"].Value = datos;

            //                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
            //                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

            //                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
            //                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

            //                    using (SqlDataReader dr = cmd.ExecuteReader())
            //                    {
            //                        dr.Read();
            //                        if (dr.HasRows)
            //                        {
            //<<<<<<< HEAD
            //                            foreach (var item in actividadDepartamentoOceanografiaDTO)
            //                            {
            ////
            //                            }
            //                            transaction.Commit();
            //                            respuesta = "";
            //                        }
            //                        catch (SqlException)
            //                        {
            //                            transaction.Rollback();
            //                            throw;
            //                        }
            //                        finally
            //                        {
            //                            conexion.Close();
            //=======
            //                            IND_OPERACION = dr["IND_OPERACION"].ToString();
            //>>>>>>> 600a771ef60c41f44ad91ab336bb375f41134e15
            //                        }
            //                    }
            //                }
            //            }
            //            catch (Exception ex)
            //            {
            //                IND_OPERACION = ex.Message;
            //            }
            //            return IND_OPERACION;
            return "";
        }
    }
}
