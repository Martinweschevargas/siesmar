using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class RegistroEquipoComputoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroEquipoComputoDTO> ObtenerLista()
        {
            List<RegistroEquipoComputoDTO> lista = new List<RegistroEquipoComputoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroEquipoComputoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroEquipoComputoDTO()
                        {
                            RegistroEquipoComputoId = Convert.ToInt32(dr["RegistroEquiposComputoId"]),
                            CodigoIBPComputo = dr["CodigoIBPComputo"].ToString(),
                            DescTipoComputadora = dr["EstadoOperatividadComputo"].ToString(),
                            DescMarca = dr["EstadoOperatividadComputo"].ToString(),
                            DescModeloBienServicioSubcampo = dr["DescModeloBienServicioSubcampo"].ToString(),
                            DescModeloBienServicioDenominacion = dr["DescModeloBienServicioDenominacion"].ToString(),
                            AnioAdquisicionComputo = (dr["AnioAdquisicionComputo"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            EstadoOperatividadComputo = dr["EstadoOperatividadComputo"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroEquipoComputoDTO registroEquipoComputoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoComputoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoIBPComputo", SqlDbType.VarChar,50);
                    cmd.Parameters["@CodigoIBPComputo"].Value = registroEquipoComputoDTO.CodigoIBPComputo;

                    cmd.Parameters.Add("@TipoComputadoraId", SqlDbType.Int);
                    cmd.Parameters["@TipoComputadoraId"].Value = registroEquipoComputoDTO.TipoComputadoraId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroEquipoComputoDTO.MarcaId;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroEquipoComputoDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroEquipoComputoDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@AnioAdquisicionComputo", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionComputo"].Value = registroEquipoComputoDTO.AnioAdquisicionComputo;

                    cmd.Parameters.Add("@EstadoOperatividadComputo", SqlDbType.VarChar,50);
                    cmd.Parameters["@EstadoOperatividadComputo"].Value = registroEquipoComputoDTO.EstadoOperatividadComputo;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroEquipoComputoDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroEquipoComputoDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoComputoDTO.UsuarioIngresoRegistro;

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

        public RegistroEquipoComputoDTO BuscarFormato(int Codigo)
        {
            RegistroEquipoComputoDTO registroEquipoComputoDTO = new RegistroEquipoComputoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoComputoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoComputoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoComputoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroEquipoComputoDTO.RegistroEquipoComputoId = Convert.ToInt32(dr["RegistroEquipoComputoId"]);
                        registroEquipoComputoDTO.CodigoIBPComputo = dr["CodigoIBPComputo"].ToString();
                        registroEquipoComputoDTO.TipoComputadoraId = Convert.ToInt32(dr["TipoComputadoraId"]);
                        registroEquipoComputoDTO.MarcaId = Convert.ToInt32(dr["MarcaId"]);
                        registroEquipoComputoDTO.ModeloBienServicioSubcampoId = Convert.ToInt32(dr["ModeloBienServicioSubcampoId"]);
                        registroEquipoComputoDTO.ModeloBienServicioDenominacionId = Convert.ToInt32(dr["ModeloBienServicioDenominacionId"]);
                        registroEquipoComputoDTO.AnioAdquisicionComputo = Convert.ToDateTime(dr["AnioAdquisicionComputo"]).ToString("yyy-MM-dd");
                        registroEquipoComputoDTO.EstadoOperatividadComputo = dr["EstadoOperatividadComputo"].ToString();
                        registroEquipoComputoDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        registroEquipoComputoDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroEquipoComputoDTO;
        }

        public string ActualizaFormato(RegistroEquipoComputoDTO registroEquipoComputoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroEquipoComputoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroEquipoComputoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoComputoId"].Value = registroEquipoComputoDTO.RegistroEquipoComputoId;

                    cmd.Parameters.Add("@CodigoIBPComputo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPComputo"].Value = registroEquipoComputoDTO.CodigoIBPComputo;

                    cmd.Parameters.Add("@TipoComputadoraId", SqlDbType.Int);
                    cmd.Parameters["@TipoComputadoraId"].Value = registroEquipoComputoDTO.TipoComputadoraId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroEquipoComputoDTO.MarcaId;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroEquipoComputoDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroEquipoComputoDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@AnioAdquisicionComputo", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionComputo"].Value = registroEquipoComputoDTO.AnioAdquisicionComputo;

                    cmd.Parameters.Add("@EstadoOperatividadComputo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadComputo"].Value = registroEquipoComputoDTO.EstadoOperatividadComputo;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroEquipoComputoDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroEquipoComputoDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoComputoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroEquipoComputoDTO registroEquipoComputoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoComputoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoComputoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoComputoId"].Value = registroEquipoComputoDTO.RegistroEquipoComputoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoComputoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroEquipoComputoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoComputo", SqlDbType.Structured);
                    cmd.Parameters["@RegistroEquipoComputo"].TypeName = "Formato.RegistroEquipoComputo";
                    cmd.Parameters["@RegistroEquipoComputo"].Value = datos;

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
