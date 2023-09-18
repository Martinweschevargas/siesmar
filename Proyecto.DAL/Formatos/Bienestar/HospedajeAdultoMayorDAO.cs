using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Bienestar;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Bienestar
{
    public class HospedajeAdultoMayorDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<HospedajeAdultoMayorDTO> ObtenerLista(int? CargaId = null, string? fechainicio = null, string? fechafin = null)
        {
            List<HospedajeAdultoMayorDTO> lista = new List<HospedajeAdultoMayorDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_HospedajeAdultoMayorListar", conexion);
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
                        lista.Add(new HospedajeAdultoMayorDTO()
                        {
                            HospedajeAdultoMayorId = Convert.ToInt32(dr["HospedajeAdultoMayorId"]),
                            DescPersonalSolicitante = dr["DescPersonalSolicitante"].ToString(),
                            DNIHospedado = dr["DNIHospedado"].ToString(),
                            DescCondicionSolicitante = dr["DescCondicionSolicitante"].ToString(),
                            DescPersonalBeneficiado = dr["DescPersonalBeneficiado"].ToString(),
                            CondicionHospedado = dr["CondicionHospedado"].ToString(),
                            TipoPermanencia = dr["TipoPermanencia"].ToString(),
                            ResultadoSolicitud = dr["ResultadoSolicitud"].ToString(),
                            FechaIngreso = (dr["FechaIngreso"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public List<HospedajeAdultoMayorDTO> BienestarVisualizacionHospedajeAdultoMayor(int CargaId)
        {
            List<HospedajeAdultoMayorDTO> lista = new List<HospedajeAdultoMayorDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Reporte.usp_BienestarVisualizacionHospedajeAdultoMayor", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;


                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new HospedajeAdultoMayorDTO()
                        {
                            DescPersonalSolicitante = dr["DescPersonalSolicitante"].ToString(),
                            DNIHospedado = dr["DNIHospedado"].ToString(),
                            DescCondicionSolicitante = dr["DescCondicionSolicitante"].ToString(),
                            DescPersonalBeneficiado = dr["DescPersonalBeneficiado"].ToString(),
                            CondicionHospedado = dr["CondicionHospedado"].ToString(),
                            TipoPermanencia = dr["TipoPermanencia"].ToString(),
                            ResultadoSolicitud = dr["ResultadoSolicitud"].ToString(),
                            FechaIngreso = dr["FechaIngreso"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(HospedajeAdultoMayorDTO hospedajeAdultoMayorDTO, string fecha)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_HospedajeAdultoMayorRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoPersonalSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalSolicitante"].Value = hospedajeAdultoMayorDTO.CodigoPersonalSolicitante;

                    cmd.Parameters.Add("@DNIHospedado", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIHospedado"].Value = hospedajeAdultoMayorDTO.DNIHospedado;

                    cmd.Parameters.Add("@CodigoCondicionSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionSolicitante"].Value = hospedajeAdultoMayorDTO.CodigoCondicionSolicitante;

                    cmd.Parameters.Add("@CodigoPersonalBeneficiado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalBeneficiado"].Value = hospedajeAdultoMayorDTO.CodigoPersonalBeneficiado;

                    cmd.Parameters.Add("@CondicionHospedado", SqlDbType.VarChar,50);
                    cmd.Parameters["@CondicionHospedado"].Value = hospedajeAdultoMayorDTO.CondicionHospedado;

                    cmd.Parameters.Add("@TipoPermanencia", SqlDbType.VarChar,50);
                    cmd.Parameters["@TipoPermanencia"].Value = hospedajeAdultoMayorDTO.TipoPermanencia;

                    cmd.Parameters.Add("@ResultadoSolicitud", SqlDbType.VarChar,20);
                    cmd.Parameters["@ResultadoSolicitud"].Value = hospedajeAdultoMayorDTO.ResultadoSolicitud;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = hospedajeAdultoMayorDTO.FechaIngreso;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = hospedajeAdultoMayorDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = hospedajeAdultoMayorDTO.UsuarioIngresoRegistro;

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

        public HospedajeAdultoMayorDTO BuscarFormato(int Codigo)
        {
            HospedajeAdultoMayorDTO hospedajeAdultoMayorDTO = new HospedajeAdultoMayorDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_HospedajeAdultoMayorEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@HospedajeAdultoMayorId", SqlDbType.Int);
                    cmd.Parameters["@HospedajeAdultoMayorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        hospedajeAdultoMayorDTO.HospedajeAdultoMayorId = Convert.ToInt32(dr["HospedajeAdultoMayorId"]);
                        hospedajeAdultoMayorDTO.CodigoPersonalSolicitante = dr["CodigoPersonalSolicitante"].ToString();
                        hospedajeAdultoMayorDTO.DNIHospedado = dr["DNIHospedado"].ToString();
                        hospedajeAdultoMayorDTO.CodigoCondicionSolicitante = dr["CodigoCondicionSolicitante"].ToString();
                        hospedajeAdultoMayorDTO.CodigoPersonalBeneficiado = dr["CodigoPersonalBeneficiado"].ToString();
                        hospedajeAdultoMayorDTO.CondicionHospedado = dr["CondicionHospedado"].ToString();
                        hospedajeAdultoMayorDTO.TipoPermanencia = dr["TipoPermanencia"].ToString();
                        hospedajeAdultoMayorDTO.ResultadoSolicitud = dr["ResultadoSolicitud"].ToString();
                        hospedajeAdultoMayorDTO.FechaIngreso = Convert.ToDateTime(dr["FechaIngreso"]).ToString("yyy-MM-dd"); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return hospedajeAdultoMayorDTO;
        }

        public string ActualizaFormato(HospedajeAdultoMayorDTO hospedajeAdultoMayorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_HospedajeAdultoMayorActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@HospedajeAdultoMayorId", SqlDbType.Int);
                    cmd.Parameters["@HospedajeAdultoMayorId"].Value = hospedajeAdultoMayorDTO.HospedajeAdultoMayorId;

                    cmd.Parameters.Add("@CodigoPersonalSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalSolicitante"].Value = hospedajeAdultoMayorDTO.CodigoPersonalSolicitante;

                    cmd.Parameters.Add("@DNIHospedado", SqlDbType.VarChar, 8);
                    cmd.Parameters["@DNIHospedado"].Value = hospedajeAdultoMayorDTO.DNIHospedado;

                    cmd.Parameters.Add("@CodigoCondicionSolicitante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionSolicitante"].Value = hospedajeAdultoMayorDTO.CodigoCondicionSolicitante;

                    cmd.Parameters.Add("@CodigoPersonalBeneficiado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPersonalBeneficiado"].Value = hospedajeAdultoMayorDTO.CodigoPersonalBeneficiado;

                    cmd.Parameters.Add("@CondicionHospedado", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CondicionHospedado"].Value = hospedajeAdultoMayorDTO.CondicionHospedado;

                    cmd.Parameters.Add("@TipoPermanencia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoPermanencia"].Value = hospedajeAdultoMayorDTO.TipoPermanencia;

                    cmd.Parameters.Add("@ResultadoSolicitud", SqlDbType.VarChar, 20);
                    cmd.Parameters["@ResultadoSolicitud"].Value = hospedajeAdultoMayorDTO.ResultadoSolicitud;

                    cmd.Parameters.Add("@FechaIngreso", SqlDbType.Date);
                    cmd.Parameters["@FechaIngreso"].Value = hospedajeAdultoMayorDTO.FechaIngreso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = hospedajeAdultoMayorDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(HospedajeAdultoMayorDTO hospedajeAdultoMayorDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_HospedajeAdultoMayorEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@HospedajeAdultoMayorId", SqlDbType.Int);
                    cmd.Parameters["@HospedajeAdultoMayorId"].Value = hospedajeAdultoMayorDTO.HospedajeAdultoMayorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = hospedajeAdultoMayorDTO.UsuarioIngresoRegistro;

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

        public bool EliminarCarga(HospedajeAdultoMayorDTO hospedajeAdultoMayorDTO)
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
                    cmd.Parameters["@Formato"].Value = "HospedajeAdultoMayor";

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = hospedajeAdultoMayorDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Usuario"].Value = hospedajeAdultoMayorDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_HospedajeAdultoMayorRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@HospedajeAdultoMayor", SqlDbType.Structured);
                    cmd.Parameters["@HospedajeAdultoMayor"].TypeName = "Formato.HospedajeAdultoMayor";
                    cmd.Parameters["@HospedajeAdultoMayor"].Value = datos;

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
