using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class RegistroEquipoPerifericoDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroEquipoPerifericoDTO> ObtenerLista()
        {
            List<RegistroEquipoPerifericoDTO> lista = new List<RegistroEquipoPerifericoDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroEquipoPerifericoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroEquipoPerifericoDTO()
                        {
                            RegistroEquipoPerifericoId = Convert.ToInt32(dr["RegistroEquipoPerifericoId"]),
                            CodigoIBPPeriferico = dr["CodigoIBPPeriferico"].ToString(),
                            DescModeloBienServicioSubcampo = dr["DescModeloBienServicioSubcampo"].ToString(),
                            DescModeloBienServicioDenominacion = dr["DescModeloBienServicioDenominacion"].ToString(),
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

        public string AgregarRegistro(RegistroEquipoPerifericoDTO registroEquipoPerifericoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoPerifericoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoIBPPeriferico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPPeriferico"].Value = registroEquipoPerifericoDTO.CodigoIBPPeriferico;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroEquipoPerifericoDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroEquipoPerifericoDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroEquipoPerifericoDTO.MarcaId;

                    cmd.Parameters.Add("@AnioAdquisicionServidor", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionServidor"].Value = registroEquipoPerifericoDTO.AnioAdquisicionServidor;

                    cmd.Parameters.Add("@EstadoOperatividadServidor", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadServidor"].Value = registroEquipoPerifericoDTO.EstadoOperatividadServidor;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroEquipoPerifericoDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroEquipoPerifericoDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoPerifericoDTO.UsuarioIngresoRegistro;

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

        public RegistroEquipoPerifericoDTO BuscarFormato(int Codigo)
        {
            RegistroEquipoPerifericoDTO registroEquipoPerifericoDTO = new RegistroEquipoPerifericoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoPerifericoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoPerifericoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoPerifericoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroEquipoPerifericoDTO.RegistroEquipoPerifericoId = Convert.ToInt32(dr["RegistroEquipoPerifericoId"]);
                        registroEquipoPerifericoDTO.CodigoIBPPeriferico = dr["CodigoIBPPeriferico"].ToString();
                        registroEquipoPerifericoDTO.ModeloBienServicioSubcampoId = Convert.ToInt32(dr["ModeloBienServicioSubcampoId"]);
                        registroEquipoPerifericoDTO.ModeloBienServicioDenominacionId = Convert.ToInt32(dr["ModeloBienServicioDenominacionId"]);
                        registroEquipoPerifericoDTO.MarcaId = Convert.ToInt32(dr["MarcaId"]);
                        registroEquipoPerifericoDTO.AnioAdquisicionServidor = Convert.ToDateTime(dr["AnioAdquisicionServidor"]).ToString("yyy-MM-dd");
                        registroEquipoPerifericoDTO.EstadoOperatividadServidor = dr["EstadoOperatividadServidor"].ToString();
                        registroEquipoPerifericoDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        registroEquipoPerifericoDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroEquipoPerifericoDTO;
        }

        public string ActualizaFormato(RegistroEquipoPerifericoDTO registroEquipoPerifericoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroEquipoPerifericoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroEquipoPerifericoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoPerifericoId"].Value = registroEquipoPerifericoDTO.RegistroEquipoPerifericoId;

                    cmd.Parameters.Add("@CodigoIBPPeriferico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPPeriferico"].Value = registroEquipoPerifericoDTO.CodigoIBPPeriferico;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroEquipoPerifericoDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroEquipoPerifericoDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroEquipoPerifericoDTO.MarcaId;

                    cmd.Parameters.Add("@AnioAdquisicionServidor", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionServidor"].Value = registroEquipoPerifericoDTO.AnioAdquisicionServidor;

                    cmd.Parameters.Add("@EstadoOperatividadServidor", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadServidor"].Value = registroEquipoPerifericoDTO.EstadoOperatividadServidor;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroEquipoPerifericoDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroEquipoPerifericoDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoPerifericoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroEquipoPerifericoDTO registroEquipoPerifericoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoPerifericoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoPerifericoId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoPerifericoId"].Value = registroEquipoPerifericoDTO.RegistroEquipoPerifericoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoPerifericoDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroEquipoPerifericoRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoPeriferico", SqlDbType.Structured);
                    cmd.Parameters["@RegistroEquipoPeriferico"].TypeName = "Formato.RegistroEquipoPeriferico";
                    cmd.Parameters["@RegistroEquipoPeriferico"].Value = datos;

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
