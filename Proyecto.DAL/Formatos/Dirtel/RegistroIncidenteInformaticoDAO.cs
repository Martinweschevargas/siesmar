using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class RegistroIncidenteInformaticoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroIncidenteInformaticoDTO> ObtenerLista(int? CargaId = null)
        {
            List<RegistroIncidenteInformaticoDTO> lista = new List<RegistroIncidenteInformaticoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroIncidenteInformaticoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroIncidenteInformaticoDTO()
                        {
                            RegistroIncidenteInformaticoId = Convert.ToInt32(dr["RegistroIncidenteInformaticoId"]),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            FechaHoraIncidente = (dr["FechaHoraIncidente"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            NombreQuienReporta = dr["NombreQuienReporta"].ToString(),
                            DescripcionIncidente = dr["DescripcionIncidente"].ToString(),
                            DescTipoIncidenteSGSI = dr["DescTipoIncidenteSGSI"].ToString(),
                            NivelPrioridad = dr["NivelPrioridad"].ToString(),
                            EstrategiaErradicacion = dr["EstrategiaErradicacion"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),

                        });
                    }
                }
            }
            return lista;
        }

       public string AgregarRegistro(RegistroIncidenteInformaticoDTO registroIncidenteInformaticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroIncidenteInformaticoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = registroIncidenteInformaticoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaHoraIncidente", SqlDbType.Date);
                    cmd.Parameters["@FechaHoraIncidente"].Value = registroIncidenteInformaticoDTO.FechaHoraIncidente;

                    cmd.Parameters.Add("@NombreQuienReporta", SqlDbType.VarChar, 260);
                    cmd.Parameters["@NombreQuienReporta"].Value = registroIncidenteInformaticoDTO.NombreQuienReporta;

                    cmd.Parameters.Add("@DescripcionIncidente", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescripcionIncidente"].Value = registroIncidenteInformaticoDTO.DescripcionIncidente;

                    cmd.Parameters.Add("@CodigoTipoIncidenteSGS", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoIncidenteSGS"].Value = registroIncidenteInformaticoDTO.CodigoTipoIncidenteSGS;

                    cmd.Parameters.Add("@NivelPrioridad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NivelPrioridad"].Value = registroIncidenteInformaticoDTO.NivelPrioridad;

                    cmd.Parameters.Add("@EstrategiaErradicacion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@EstrategiaErradicacion"].Value = registroIncidenteInformaticoDTO.EstrategiaErradicacion;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroIncidenteInformaticoDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroIncidenteInformaticoDTO.UsuarioIngresoRegistro;

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

        public RegistroIncidenteInformaticoDTO BuscarFormato(int Codigo)
        {
            RegistroIncidenteInformaticoDTO registroIncidenteInformaticoDTO = new RegistroIncidenteInformaticoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroIncidenteInformaticoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroIncidenteInformaticoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroIncidenteInformaticoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroIncidenteInformaticoDTO.RegistroIncidenteInformaticoId = Convert.ToInt32(dr["RegistroIncidenteInformaticoId"]);
                        registroIncidenteInformaticoDTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        registroIncidenteInformaticoDTO.FechaHoraIncidente = Convert.ToDateTime(dr["FechaHoraIncidente"]).ToString("yyy-MM-dd");
                        registroIncidenteInformaticoDTO.NombreQuienReporta = dr["NombreQuienReporta"].ToString();
                        registroIncidenteInformaticoDTO.DescripcionIncidente = dr["DescripcionIncidente"].ToString();
                        registroIncidenteInformaticoDTO.CodigoTipoIncidenteSGS = dr["CodigoTipoIncidenteSGS"].ToString();
                        registroIncidenteInformaticoDTO.NivelPrioridad = dr["NivelPrioridad"].ToString();
                        registroIncidenteInformaticoDTO.EstrategiaErradicacion = dr["EstrategiaErradicacion"].ToString(); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroIncidenteInformaticoDTO;
        }

        public string ActualizaFormato(RegistroIncidenteInformaticoDTO registroIncidenteInformaticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroIncidenteInformaticoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroIncidenteInformaticoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroIncidenteInformaticoId"].Value = registroIncidenteInformaticoDTO.RegistroIncidenteInformaticoId;

                    cmd.Parameters.Add("@CodigoDependencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia"].Value = registroIncidenteInformaticoDTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaHoraIncidente", SqlDbType.Date);
                    cmd.Parameters["@FechaHoraIncidente"].Value = registroIncidenteInformaticoDTO.FechaHoraIncidente;

                    cmd.Parameters.Add("@NombreQuienReporta", SqlDbType.VarChar, 260);
                    cmd.Parameters["@NombreQuienReporta"].Value = registroIncidenteInformaticoDTO.NombreQuienReporta;

                    cmd.Parameters.Add("@DescripcionIncidente", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescripcionIncidente"].Value = registroIncidenteInformaticoDTO.DescripcionIncidente;

                    cmd.Parameters.Add("@CodigoTipoIncidenteSGS", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoTipoIncidenteSGS"].Value = registroIncidenteInformaticoDTO.CodigoTipoIncidenteSGS;

                    cmd.Parameters.Add("@NivelPrioridad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@NivelPrioridad"].Value = registroIncidenteInformaticoDTO.NivelPrioridad;

                    cmd.Parameters.Add("@EstrategiaErradicacion", SqlDbType.VarChar, 260);
                    cmd.Parameters["@EstrategiaErradicacion"].Value = registroIncidenteInformaticoDTO.EstrategiaErradicacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroIncidenteInformaticoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroIncidenteInformaticoDTO registroIncidenteInformaticoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroIncidenteInformaticoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroIncidenteInformaticoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroIncidenteInformaticoId"].Value = registroIncidenteInformaticoDTO.RegistroIncidenteInformaticoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroIncidenteInformaticoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroIncidenteInformaticoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroIncidenteInformatico", SqlDbType.Structured);
                    cmd.Parameters["@RegistroIncidenteInformatico"].TypeName = "Formato.RegistroIncidenteInformatico";
                    cmd.Parameters["@RegistroIncidenteInformatico"].Value = datos;

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
