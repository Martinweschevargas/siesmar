using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class RegistroRINFODAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroRINFODTO> ObtenerLista(int? CargaId = null)
        {
            List<RegistroRINFODTO> lista = new List<RegistroRINFODTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroRINFOListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroRINFODTO()
                        {
                            RegistroRINFOId = Convert.ToInt32(dr["RegistroRINFOId"]),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            FechaReporte = (dr["FechaReporte"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            DescGrado = dr["DescGrado"].ToString(),
                            NombreInfractor = dr["NombreInfractor"].ToString(),
                            TipoInfraccion = dr["TipoInfraccion"].ToString(),
                            MotivoIncumplimiento = dr["MotivoIncumplimiento"].ToString(),
                            AplicacionSancion = dr["AplicacionSancion"].ToString(),
                            DisposicionEmitidaPrevencion = dr["DisposicionEmitidaPrevencion"].ToString(),
                            OtroInformacionAdicional = dr["OtroInformacionAdicional"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroRINFODTO registroRINFODTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroRINFORegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDependencia "].Value = registroRINFODTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaReporte", SqlDbType.Date);
                    cmd.Parameters["@FechaReporte"].Value = registroRINFODTO.FechaReporte;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar "].Value = registroRINFODTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@NombreInfractor", SqlDbType.VarChar, 260);
                    cmd.Parameters["@NombreInfractor"].Value = registroRINFODTO.NombreInfractor;

                    cmd.Parameters.Add("@TipoInfraccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoInfraccion"].Value = registroRINFODTO.TipoInfraccion;

                    cmd.Parameters.Add("@MotivoIncumplimiento", SqlDbType.VarChar, 1);
                    cmd.Parameters["@MotivoIncumplimiento"].Value = registroRINFODTO.MotivoIncumplimiento;

                    cmd.Parameters.Add("@AplicacionSancion", SqlDbType.VarChar, 1);
                    cmd.Parameters["@AplicacionSancion"].Value = registroRINFODTO.AplicacionSancion;

                    cmd.Parameters.Add("@DisposicionEmitidaPrevencion", SqlDbType.VarChar, 1);
                    cmd.Parameters["@DisposicionEmitidaPrevencion"].Value = registroRINFODTO.DisposicionEmitidaPrevencion;

                    cmd.Parameters.Add("@OtroInformacionAdicional", SqlDbType.VarChar, 100);
                    cmd.Parameters["@OtroInformacionAdicional"].Value = registroRINFODTO.OtroInformacionAdicional;

                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = registroRINFODTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroRINFODTO.UsuarioIngresoRegistro;

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

        public RegistroRINFODTO BuscarFormato(int Codigo)
        {
            RegistroRINFODTO registroRINFODTO = new RegistroRINFODTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroRINFOEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroRINFOId", SqlDbType.Int);
                    cmd.Parameters["@RegistroRINFOId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroRINFODTO.RegistroRINFOId = Convert.ToInt32(dr["RegistroRINFOId"]);
                        registroRINFODTO.CodigoDependencia = dr["CodigoDependencia"].ToString();
                        registroRINFODTO.FechaReporte = Convert.ToDateTime(dr["FechaReporte"]).ToString("yyy-MM-dd");
                        registroRINFODTO.CodigoGradoPersonalMilitar = dr["CodigoGradoPersonalMilitar"].ToString();
                        registroRINFODTO.NombreInfractor = dr["NombreInfractor"].ToString();
                        registroRINFODTO.TipoInfraccion = dr["TipoInfraccion"].ToString();
                        registroRINFODTO.MotivoIncumplimiento = dr["MotivoIncumplimiento"].ToString();
                        registroRINFODTO.AplicacionSancion = dr["AplicacionSancion"].ToString();
                        registroRINFODTO.DisposicionEmitidaPrevencion = dr["DisposicionEmitidaPrevencion"].ToString();
                        registroRINFODTO.OtroInformacionAdicional = dr["OtroInformacionAdicional"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroRINFODTO;
        }

        public string ActualizaFormato(RegistroRINFODTO registroRINFODTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroRINFOActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroRINFOId", SqlDbType.Int);
                    cmd.Parameters["@RegistroRINFOId"].Value = registroRINFODTO.RegistroRINFOId;

                    cmd.Parameters.Add("@CodigoDependencia ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoDependencia "].Value = registroRINFODTO.CodigoDependencia;

                    cmd.Parameters.Add("@FechaReporte", SqlDbType.Date);
                    cmd.Parameters["@FechaReporte"].Value = registroRINFODTO.FechaReporte;

                    cmd.Parameters.Add("@CodigoGradoPersonalMilitar ", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGradoPersonalMilitar "].Value = registroRINFODTO.CodigoGradoPersonalMilitar;

                    cmd.Parameters.Add("@NombreInfractor", SqlDbType.VarChar, 260);
                    cmd.Parameters["@NombreInfractor"].Value = registroRINFODTO.NombreInfractor;

                    cmd.Parameters.Add("@TipoInfraccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoInfraccion"].Value = registroRINFODTO.TipoInfraccion;

                    cmd.Parameters.Add("@MotivoIncumplimiento", SqlDbType.VarChar, 1);
                    cmd.Parameters["@MotivoIncumplimiento"].Value = registroRINFODTO.MotivoIncumplimiento;

                    cmd.Parameters.Add("@AplicacionSancion", SqlDbType.VarChar, 1);
                    cmd.Parameters["@AplicacionSancion"].Value = registroRINFODTO.AplicacionSancion;

                    cmd.Parameters.Add("@DisposicionEmitidaPrevencion", SqlDbType.VarChar, 1);
                    cmd.Parameters["@DisposicionEmitidaPrevencion"].Value = registroRINFODTO.DisposicionEmitidaPrevencion;

                    cmd.Parameters.Add("@OtroInformacionAdicional", SqlDbType.VarChar, 100);
                    cmd.Parameters["@OtroInformacionAdicional"].Value = registroRINFODTO.OtroInformacionAdicional;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroRINFODTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroRINFODTO registroRINFODTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroRINFOEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroRINFOId", SqlDbType.Int);
                    cmd.Parameters["@RegistroRINFOId"].Value = registroRINFODTO.RegistroRINFOId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroRINFODTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroRINFORegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroRINFO", SqlDbType.Structured);
                    cmd.Parameters["@RegistroRINFO"].TypeName = "Formato.RegistroRINFO";
                    cmd.Parameters["@RegistroRINFO"].Value = datos;

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
