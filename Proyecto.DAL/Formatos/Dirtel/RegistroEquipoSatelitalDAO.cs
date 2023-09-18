using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class RegistroEquipoSatelitalDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroEquipoSatelitalDTO> ObtenerLista()
        {
            List<RegistroEquipoSatelitalDTO> lista = new List<RegistroEquipoSatelitalDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroEquipoSatelitalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroEquipoSatelitalDTO()
                        {
                            RegistroEquipoSatelitalId = Convert.ToInt32(dr["RegistroEquipoSatelitalId"]),
                            CodigoIBPEquipoSatelital = dr["CodigoIBPEquipoSatelital"].ToString(),
                            DescModeloBienServicioSubcampo = dr["DescModeloBienServicioSubcampo"].ToString(),
                            DescModeloBienServicioDenominacion = dr["DescModeloBienServicioDenominacion"].ToString(),
                            DescMarca = dr["DescMarca"].ToString(),
                            DescModeloEquipoSatelital = dr["DescModeloEquipoSatelital"].ToString(),
                            AnioAdquisicionSatelital = (dr["AnioAdquisicionSatelital"].ToString()).Split(" ", StringSplitOptions.None)[0],
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

        public string AgregarRegistro(RegistroEquipoSatelitalDTO registroEquipoSatelitalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoSatelitalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoIBPEquipoSatelital", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPEquipoSatelital"].Value = registroEquipoSatelitalDTO.CodigoIBPEquipoSatelital;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroEquipoSatelitalDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroEquipoSatelitalDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroEquipoSatelitalDTO.MarcaId;

                    cmd.Parameters.Add("@ModeloEquipoSatelitalId", SqlDbType.Int);
                    cmd.Parameters["@ModeloEquipoSatelitalId"].Value = registroEquipoSatelitalDTO.ModeloEquipoSatelitalId;

                    cmd.Parameters.Add("@AnioAdquisicionSatelital", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionSatelital"].Value = registroEquipoSatelitalDTO.AnioAdquisicionSatelital;

                    cmd.Parameters.Add("@EstadoOperatividadTelefonia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadTelefonia"].Value = registroEquipoSatelitalDTO.EstadoOperatividadTelefonia;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroEquipoSatelitalDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroEquipoSatelitalDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoSatelitalDTO.UsuarioIngresoRegistro;

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

        public RegistroEquipoSatelitalDTO BuscarFormato(int Codigo)
        {
            RegistroEquipoSatelitalDTO registroEquipoSatelitalDTO = new RegistroEquipoSatelitalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoSatelitalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoSatelitalId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoSatelitalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroEquipoSatelitalDTO.RegistroEquipoSatelitalId = Convert.ToInt32(dr["RegistroEquipoSatelitalId"]);
                        registroEquipoSatelitalDTO.CodigoIBPEquipoSatelital = dr["CodigoIBPEquipoSatelital"].ToString();
                        registroEquipoSatelitalDTO.ModeloBienServicioSubcampoId = Convert.ToInt32(dr["ModeloBienServicioSubcampoId"]);
                        registroEquipoSatelitalDTO.ModeloBienServicioDenominacionId = Convert.ToInt32(dr["ModeloBienServicioDenominacionId"]);
                        registroEquipoSatelitalDTO.MarcaId = Convert.ToInt32(dr["MarcaId"]);
                        registroEquipoSatelitalDTO.ModeloEquipoSatelitalId = Convert.ToInt32(dr["ModeloEquipoSatelitalId"]);
                        registroEquipoSatelitalDTO.AnioAdquisicionSatelital = Convert.ToDateTime(dr["AnioAdquisicionSatelital"]).ToString("yyy-MM-dd");
                        registroEquipoSatelitalDTO.EstadoOperatividadTelefonia = dr["EstadoOperatividadTelefonia"].ToString();
                        registroEquipoSatelitalDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        registroEquipoSatelitalDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]); 
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroEquipoSatelitalDTO;
        }

        public string ActualizaFormato(RegistroEquipoSatelitalDTO registroEquipoSatelitalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroEquipoSatelitalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroEquipoSatelitalId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoSatelitalId"].Value = registroEquipoSatelitalDTO.RegistroEquipoSatelitalId;

                    cmd.Parameters.Add("@CodigoIBPEquipoSatelital", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPEquipoSatelital"].Value = registroEquipoSatelitalDTO.CodigoIBPEquipoSatelital;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroEquipoSatelitalDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroEquipoSatelitalDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroEquipoSatelitalDTO.MarcaId;

                    cmd.Parameters.Add("@ModeloEquipoSatelitalId", SqlDbType.Int);
                    cmd.Parameters["@ModeloEquipoSatelitalId"].Value = registroEquipoSatelitalDTO.ModeloEquipoSatelitalId;

                    cmd.Parameters.Add("@AnioAdquisicionSatelital", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionSatelital"].Value = registroEquipoSatelitalDTO.AnioAdquisicionSatelital;

                    cmd.Parameters.Add("@EstadoOperatividadTelefonia", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadTelefonia"].Value = registroEquipoSatelitalDTO.EstadoOperatividadTelefonia;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroEquipoSatelitalDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroEquipoSatelitalDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoSatelitalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroEquipoSatelitalDTO registroEquipoSatelitalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoSatelitalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoSatelitalId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoSatelitalId"].Value = registroEquipoSatelitalDTO.RegistroEquipoSatelitalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoSatelitalDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroEquipoSatelitalRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoSatelital", SqlDbType.Structured);
                    cmd.Parameters["@RegistroEquipoSatelital"].TypeName = "Formato.RegistroEquipoSatelital";
                    cmd.Parameters["@RegistroEquipoSatelital"].Value = datos;

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
