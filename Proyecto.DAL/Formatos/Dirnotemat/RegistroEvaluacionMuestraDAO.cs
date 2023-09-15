using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Diali;
using Marina.Siesmar.Entidades.Formatos.Dirnotemat;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata;
using System.Security.Cryptography;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirnotemat
{
    public class RegistroEvaluacionMuestraDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroEvaluacionMuestraDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<RegistroEvaluacionMuestraDTO> lista = new List<RegistroEvaluacionMuestraDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroEvaluacionMuestraListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                cmd.Parameters.Add("@FechaInicio", SqlDbType.Date);
                cmd.Parameters["@FechaInicio"].Value = fechainicio;

                cmd.Parameters.Add("@FechaFin", SqlDbType.Date);
                cmd.Parameters["@FechaFin"].Value = fechafin;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroEvaluacionMuestraDTO()
                        {
                            RegistroEvaluacionMuestraId = Convert.ToInt32(dr["RegistroEvaluacionMuestraId"]),
                            DescProcesoEvaluacion = dr["DescProcesoEvaluacion"].ToString(),
                            NroProcesoEvaluacion = dr["NroProcesoEvaluacion"].ToString(),
                            NroMuestrasEvaluacion = Convert.ToInt32(dr["NroMuestrasEvaluacion"]),
                            MuestrasCumpleEvaluacion = Convert.ToInt32(dr["MuestrasCumpleEvaluacion"]),
                            MuestaNoCumpleEvaluacion = Convert.ToInt32(dr["MuestaNoCumpleEvaluacion"]),
                            FechaInicioEvaluacion = (dr["FechaInicioEvaluacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            FechaTerminoEvaluacion = (dr["FechaTerminoEvaluacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            LaboratorioEvaluacion = dr["LaboratorioEvaluacion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"])
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroEvaluacionMuestraDTO registroEvaluacionMuestraDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroEvaluacionMuestraRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescProcesoEvaluacion", SqlDbType.VarChar,70);
                    cmd.Parameters["@DescProcesoEvaluacion"].Value = registroEvaluacionMuestraDTO.DescProcesoEvaluacion;

                    cmd.Parameters.Add("@NroProcesoEvaluacion", SqlDbType.VarChar, 30);
                    cmd.Parameters["@NroProcesoEvaluacion"].Value = registroEvaluacionMuestraDTO.NroProcesoEvaluacion;

                    cmd.Parameters.Add("@NroMuestrasEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@NroMuestrasEvaluacion"].Value = registroEvaluacionMuestraDTO.NroMuestrasEvaluacion;

                    cmd.Parameters.Add("@MuestrasCumpleEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@MuestrasCumpleEvaluacion"].Value = registroEvaluacionMuestraDTO.MuestrasCumpleEvaluacion;

                    cmd.Parameters.Add("@MuestaNoCumpleEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@MuestaNoCumpleEvaluacion"].Value = registroEvaluacionMuestraDTO.MuestaNoCumpleEvaluacion;

                    cmd.Parameters.Add("@FechaInicioEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioEvaluacion"].Value = registroEvaluacionMuestraDTO.FechaInicioEvaluacion;

                    cmd.Parameters.Add("@FechaTerminoEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoEvaluacion"].Value = registroEvaluacionMuestraDTO.FechaTerminoEvaluacion;

                    cmd.Parameters.Add("@LaboratorioEvaluacion", SqlDbType.VarChar, 30);
                    cmd.Parameters["@LaboratorioEvaluacion"].Value = registroEvaluacionMuestraDTO.LaboratorioEvaluacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroEvaluacionMuestraDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEvaluacionMuestraDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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

        public RegistroEvaluacionMuestraDTO BuscarFormato(int Codigo)
        {
            RegistroEvaluacionMuestraDTO registroEvaluacionMuestraDTO = new RegistroEvaluacionMuestraDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEvaluacionMuestraEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEvaluacionMuestraId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEvaluacionMuestraId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        registroEvaluacionMuestraDTO.RegistroEvaluacionMuestraId = Convert.ToInt32(dr["RegistroEvaluacionMuestraId"]);
                        registroEvaluacionMuestraDTO.DescProcesoEvaluacion = dr["DescProcesoEvaluacion"].ToString();
                        registroEvaluacionMuestraDTO.NroProcesoEvaluacion = dr["NroProcesoEvaluacion"].ToString();
                        registroEvaluacionMuestraDTO.NroMuestrasEvaluacion = Convert.ToInt32(dr["NroMuestrasEvaluacion"]);
                        registroEvaluacionMuestraDTO.MuestrasCumpleEvaluacion = Convert.ToInt32(dr["MuestrasCumpleEvaluacion"]);
                        registroEvaluacionMuestraDTO.MuestaNoCumpleEvaluacion = Convert.ToInt32(dr["MuestaNoCumpleEvaluacion"]);
                        registroEvaluacionMuestraDTO.FechaInicioEvaluacion = Convert.ToDateTime(dr["FechaInicioEvaluacion"]).ToString("yyy-MM-dd");
                        registroEvaluacionMuestraDTO.FechaTerminoEvaluacion = Convert.ToDateTime(dr["FechaTerminoEvaluacion"]).ToString("yyy-MM-dd");
                        registroEvaluacionMuestraDTO.LaboratorioEvaluacion = dr["LaboratorioEvaluacion"].ToString();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroEvaluacionMuestraDTO;
        }

        public string ActualizaFormato(RegistroEvaluacionMuestraDTO registroEvaluacionMuestraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroEvaluacionMuestraActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEvaluacionMuestraId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEvaluacionMuestraId"].Value = registroEvaluacionMuestraDTO.RegistroEvaluacionMuestraId;

                    cmd.Parameters.Add("@DescProcesoEvaluacion", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescProcesoEvaluacion"].Value = registroEvaluacionMuestraDTO.DescProcesoEvaluacion;

                    cmd.Parameters.Add("@NroProcesoEvaluacion", SqlDbType.VarChar, 30);
                    cmd.Parameters["@NroProcesoEvaluacion"].Value = registroEvaluacionMuestraDTO.NroProcesoEvaluacion;

                    cmd.Parameters.Add("@NroMuestrasEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@NroMuestrasEvaluacion"].Value = registroEvaluacionMuestraDTO.NroMuestrasEvaluacion;

                    cmd.Parameters.Add("@MuestrasCumpleEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@MuestrasCumpleEvaluacion"].Value = registroEvaluacionMuestraDTO.MuestrasCumpleEvaluacion;

                    cmd.Parameters.Add("@MuestaNoCumpleEvaluacion", SqlDbType.Int);
                    cmd.Parameters["@MuestaNoCumpleEvaluacion"].Value = registroEvaluacionMuestraDTO.MuestaNoCumpleEvaluacion;

                    cmd.Parameters.Add("@FechaInicioEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaInicioEvaluacion"].Value = registroEvaluacionMuestraDTO.FechaInicioEvaluacion;

                    cmd.Parameters.Add("@FechaTerminoEvaluacion", SqlDbType.Date);
                    cmd.Parameters["@FechaTerminoEvaluacion"].Value = registroEvaluacionMuestraDTO.FechaTerminoEvaluacion;

                    cmd.Parameters.Add("@LaboratorioEvaluacion", SqlDbType.VarChar, 30);
                    cmd.Parameters["@LaboratorioEvaluacion"].Value = registroEvaluacionMuestraDTO.LaboratorioEvaluacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEvaluacionMuestraDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroEvaluacionMuestraDTO registroEvaluacionMuestraDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEvaluacionMuestraEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEvaluacionMuestraId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEvaluacionMuestraId"].Value= registroEvaluacionMuestraDTO.RegistroEvaluacionMuestraId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEvaluacionMuestraDTO.UsuarioIngresoRegistro;

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


        public bool EliminarCarga(RegistroEvaluacionMuestraDTO registroEvaluacionMuestraDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Seguridad.usp_CargaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@Formato", SqlDbType.NVarChar, 200);
                    cmd.Parameters["@Formato"].Value = "RegistroEvaluacionMuestra";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroEvaluacionMuestraDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEvaluacionMuestraDTO.UsuarioIngresoRegistro;

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

        public string InsertarDatos(DataTable datos, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_RegistroEvaluacionMuestraRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEvaluacionMuestra", SqlDbType.Structured);
                    cmd.Parameters["@RegistroEvaluacionMuestra"].TypeName = "Formato.RegistroEvaluacionMuestra";
                    cmd.Parameters["@RegistroEvaluacionMuestra"].Value = datos;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

                    cmd.Parameters.Add("@FechaCarga", SqlDbType.Date);
                    cmd.Parameters["@FechaCarga"].Value = fecha;

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
