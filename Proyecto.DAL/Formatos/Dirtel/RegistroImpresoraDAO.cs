using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class RegistroImpresoraDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroImpresoraDTO> ObtenerLista()
        {
            List<RegistroImpresoraDTO> lista = new List<RegistroImpresoraDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroImpresoraListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroImpresoraDTO()
                        {
                            RegistroImpresoraId = Convert.ToInt32(dr["RegistroImpresoraId"]),
                            CodigoIBPImpresora = dr["CodigoIBPImpresora"].ToString(),
                            DescModeloBienServicioSubcampo = dr["DescModeloBienServicioSubcampo"].ToString(),
                            DescModeloBienServicioDenominacion = dr["DescModeloBienServicioDenominacion"].ToString(),
                            ColorImpresion = dr["ColorImpresion"].ToString(),
                            DescMarca = dr["DescMarca"].ToString(),
                            AnioAdquisicionServidor = (dr["AnioAdquisicionServidor"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            EstadoOperatividadServidor = dr["EstadoOperatividadServidor"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroImpresoraDTO registroImpresoraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroImpresoraRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoIBPImpresora", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPImpresora"].Value = registroImpresoraDTO.CodigoIBPImpresora;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroImpresoraDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroImpresoraDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@ColorImpresion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ColorImpresion"].Value = registroImpresoraDTO.ColorImpresion;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroImpresoraDTO.MarcaId;

                    cmd.Parameters.Add("@AnioAdquisicionServidor", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionServidor"].Value = registroImpresoraDTO.AnioAdquisicionServidor;

                    cmd.Parameters.Add("@EstadoOperatividadServidor", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadServidor"].Value = registroImpresoraDTO.EstadoOperatividadServidor;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroImpresoraDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroImpresoraDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroImpresoraDTO.UsuarioIngresoRegistro;

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

        public RegistroImpresoraDTO BuscarFormato(int Codigo)
        {
            RegistroImpresoraDTO registroImpresoraDTO = new RegistroImpresoraDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroImpresoraEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroImpresoraId", SqlDbType.Int);
                    cmd.Parameters["@RegistroImpresoraId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroImpresoraDTO.RegistroImpresoraId = Convert.ToInt32(dr["RegistroImpresoraId"]);
                        registroImpresoraDTO.CodigoIBPImpresora = dr["CodigoIBPImpresora"].ToString();
                        registroImpresoraDTO.ModeloBienServicioSubcampoId = Convert.ToInt32(dr["ModeloBienServicioSubcampoId"]);
                        registroImpresoraDTO.ModeloBienServicioDenominacionId = Convert.ToInt32(dr["ModeloBienServicioDenominacionId"]);
                        registroImpresoraDTO.ColorImpresion = dr["ColorImpresion"].ToString();
                        registroImpresoraDTO.MarcaId = Convert.ToInt32(dr["MarcaId"]);
                        registroImpresoraDTO.AnioAdquisicionServidor = Convert.ToDateTime(dr["AnioAdquisicionServidor"]).ToString("yyy-MM-dd");
                        registroImpresoraDTO.EstadoOperatividadServidor = dr["EstadoOperatividadServidor"].ToString();
                        registroImpresoraDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        registroImpresoraDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroImpresoraDTO;
        }

        public string ActualizaFormato(RegistroImpresoraDTO registroImpresoraDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroImpresoraActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroImpresoraId", SqlDbType.Int);
                    cmd.Parameters["@RegistroImpresoraId"].Value = registroImpresoraDTO.RegistroImpresoraId;

                    cmd.Parameters.Add("@CodigoIBPImpresora", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPImpresora"].Value = registroImpresoraDTO.CodigoIBPImpresora;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroImpresoraDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroImpresoraDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@ColorImpresion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ColorImpresion"].Value = registroImpresoraDTO.ColorImpresion;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroImpresoraDTO.MarcaId;

                    cmd.Parameters.Add("@AnioAdquisicionServidor", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionServidor"].Value = registroImpresoraDTO.AnioAdquisicionServidor;

                    cmd.Parameters.Add("@EstadoOperatividadServidor", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadServidor"].Value = registroImpresoraDTO.EstadoOperatividadServidor;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroImpresoraDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroImpresoraDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroImpresoraDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroImpresoraDTO registroImpresoraDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroImpresoraEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroImpresoraId", SqlDbType.Int);
                    cmd.Parameters["@RegistroImpresoraId"].Value = registroImpresoraDTO.RegistroImpresoraId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroImpresoraDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroImpresoraRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroImpresora", SqlDbType.Structured);
                    cmd.Parameters["@RegistroImpresora"].TypeName = "Formato.RegistroImpresora";
                    cmd.Parameters["@RegistroImpresora"].Value = datos;

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
