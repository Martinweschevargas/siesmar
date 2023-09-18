using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class RegistroCentralTelefonicaDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroCentralTelefonicaDTO> ObtenerLista()
        {
            List<RegistroCentralTelefonicaDTO> lista = new List<RegistroCentralTelefonicaDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroCentralTelefonicaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroCentralTelefonicaDTO()
                        {
                            RegistroCentralTelefonicaId = Convert.ToInt32(dr["RegistroCentralTelefonicaId"]),
                            CodigoIBPCentralTelefonica = dr["CodigoIBPCentralTelefonica"].ToString(),
                            DescModeloBienServicioSubcampo = dr["DescModeloBienServicioSubcampo"].ToString(),
                            DescModeloBienServicioDenominacion = dr["DescModeloBienServicioDenominacion"].ToString(),
                            DescMarca = dr["DescMarca"].ToString(),
                            TipoProtocoloTelefonia = dr["TipoProtocoloTelefonia"].ToString(),
                            TerminalSoportada = dr["TerminalSoportada"].ToString(),
                            TerminalInstalada = dr["TerminalInstalada"].ToString(),
                            AnioAdquisicionTelefonia = (dr["AnioAdquisicionTelefonia"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            EstadoOperatividadTelefonia = dr["EstadoOperatividadTelefonia"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroCentralTelefonicaDTO registroCentralTelefonicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroCentralTelefonicaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoIBPCentralTelefonica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPCentralTelefonica"].Value = registroCentralTelefonicaDTO.CodigoIBPCentralTelefonica;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroCentralTelefonicaDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroCentralTelefonicaDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroCentralTelefonicaDTO.MarcaId;

                    cmd.Parameters.Add("@TipoProtocoloTelefonia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoProtocoloTelefonia"].Value = registroCentralTelefonicaDTO.TipoProtocoloTelefonia;

                    cmd.Parameters.Add("@TerminalSoportada", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TerminalSoportada"].Value = registroCentralTelefonicaDTO.TerminalSoportada;

                    cmd.Parameters.Add("@TerminalInstalada", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TerminalInstalada"].Value = registroCentralTelefonicaDTO.TerminalInstalada;

                    cmd.Parameters.Add("@AnioAdquisicionTelefonia", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionTelefonia"].Value = registroCentralTelefonicaDTO.AnioAdquisicionTelefonia;

                    cmd.Parameters.Add("@EstadoOperatividadTelefonia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadTelefonia"].Value = registroCentralTelefonicaDTO.EstadoOperatividadTelefonia;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroCentralTelefonicaDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroCentralTelefonicaDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroCentralTelefonicaDTO.UsuarioIngresoRegistro;

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

        public RegistroCentralTelefonicaDTO BuscarFormato(int Codigo)
        {
            RegistroCentralTelefonicaDTO registroCentralTelefonicaDTO = new RegistroCentralTelefonicaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroCentralTelefonicaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroCentralTelefonicaId", SqlDbType.Int);
                    cmd.Parameters["@RegistroCentralTelefonicaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroCentralTelefonicaDTO.RegistroCentralTelefonicaId = Convert.ToInt32(dr["RegistroCentralTelefonicaId"]);
                        registroCentralTelefonicaDTO.CodigoIBPCentralTelefonica = dr["CodigoIBPCentralTelefonica"].ToString();
                        registroCentralTelefonicaDTO.ModeloBienServicioSubcampoId = Convert.ToInt32(dr["ModeloBienServicioSubcampoId"]);
                        registroCentralTelefonicaDTO.ModeloBienServicioDenominacionId = Convert.ToInt32(dr["ModeloBienServicioDenominacionId"]);
                        registroCentralTelefonicaDTO.MarcaId = Convert.ToInt32(dr["MarcaId"]);
                        registroCentralTelefonicaDTO.TipoProtocoloTelefonia = dr["TipoProtocoloTelefonia"].ToString();
                        registroCentralTelefonicaDTO.TerminalSoportada = dr["TerminalSoportada"].ToString();
                        registroCentralTelefonicaDTO.TerminalInstalada = dr["TerminalInstalada"].ToString();
                        registroCentralTelefonicaDTO.AnioAdquisicionTelefonia = Convert.ToDateTime(dr["AnioAdquisicionTelefonia"]).ToString("yyy-MM-dd");
                        registroCentralTelefonicaDTO.EstadoOperatividadTelefonia = dr["EstadoOperatividadTelefonia"].ToString();
                        registroCentralTelefonicaDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        registroCentralTelefonicaDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroCentralTelefonicaDTO;
        }

        public string ActualizaFormato(RegistroCentralTelefonicaDTO registroCentralTelefonicaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroCentralTelefonicaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroCentralTelefonicaId", SqlDbType.Int);
                    cmd.Parameters["@RegistroCentralTelefonicaId"].Value = registroCentralTelefonicaDTO.RegistroCentralTelefonicaId;

                    cmd.Parameters.Add("@CodigoIBPCentralTelefonica", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPCentralTelefonica"].Value = registroCentralTelefonicaDTO.CodigoIBPCentralTelefonica;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroCentralTelefonicaDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroCentralTelefonicaDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroCentralTelefonicaDTO.MarcaId;

                    cmd.Parameters.Add("@TipoProtocoloTelefonia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TipoProtocoloTelefonia"].Value = registroCentralTelefonicaDTO.TipoProtocoloTelefonia;

                    cmd.Parameters.Add("@TerminalSoportada", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TerminalSoportada"].Value = registroCentralTelefonicaDTO.TerminalSoportada;

                    cmd.Parameters.Add("@TerminalInstalada", SqlDbType.VarChar, 50);
                    cmd.Parameters["@TerminalInstalada"].Value = registroCentralTelefonicaDTO.TerminalInstalada;

                    cmd.Parameters.Add("@AnioAdquisicionTelefonia", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionTelefonia"].Value = registroCentralTelefonicaDTO.AnioAdquisicionTelefonia;

                    cmd.Parameters.Add("@EstadoOperatividadTelefonia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadTelefonia"].Value = registroCentralTelefonicaDTO.EstadoOperatividadTelefonia;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroCentralTelefonicaDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroCentralTelefonicaDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroCentralTelefonicaDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroCentralTelefonicaDTO registroCentralTelefonicaDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroCentralTelefonicaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroCentralTelefonicaId", SqlDbType.Int);
                    cmd.Parameters["@RegistroCentralTelefonicaId"].Value = registroCentralTelefonicaDTO.RegistroCentralTelefonicaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroCentralTelefonicaDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroCentralTelefonicaRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroCentralTelefonica", SqlDbType.Structured);
                    cmd.Parameters["@RegistroCentralTelefonica"].TypeName = "Formato.RegistroCentralTelefonica";
                    cmd.Parameters["@RegistroCentralTelefonica"].Value = datos;

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
