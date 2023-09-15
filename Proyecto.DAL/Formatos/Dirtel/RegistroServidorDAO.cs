using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class RegistroServidorDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroServidorDTO> ObtenerLista()
        {
            List<RegistroServidorDTO> lista = new List<RegistroServidorDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroServidorListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroServidorDTO()
                        {
                            RegistroServidorId = Convert.ToInt32(dr["RegistroServidorId"]),
                            CodigoIBPServidor = dr["CodigoIBPServidor"].ToString(),
                            DescModeloBienServicioSubcampo = dr["DescModeloBienServicioSubcampo"].ToString(),
                            DescModeloBienServicioDenominacion = dr["DescModeloBienServicioDenominacion"].ToString(),
                            DescMarca = dr["DescMarca"].ToString(),
                            CapacidadMemoriaRam = dr["CapacidadMemoriaRam"].ToString(),
                            CapacidadDiscoDuro = dr["CapacidadDiscoDuro"].ToString(),
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

        public string AgregarRegistro(RegistroServidorDTO registroServidorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroServidorRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoIBPServidor", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPServidor"].Value = registroServidorDTO.CodigoIBPServidor;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroServidorDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroServidorDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroServidorDTO.MarcaId;

                    cmd.Parameters.Add("@CapacidadMemoriaRam", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CapacidadMemoriaRam"].Value = registroServidorDTO.CapacidadMemoriaRam;

                    cmd.Parameters.Add("@CapacidadDiscoDuro", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CapacidadDiscoDuro"].Value = registroServidorDTO.CapacidadDiscoDuro;

                    cmd.Parameters.Add("@AnioAdquisicionServidor", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionServidor"].Value = registroServidorDTO.AnioAdquisicionServidor;

                    cmd.Parameters.Add("@EstadoOperatividadServidor", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadServidor"].Value = registroServidorDTO.EstadoOperatividadServidor;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroServidorDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroServidorDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroServidorDTO.UsuarioIngresoRegistro;

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

        public RegistroServidorDTO BuscarFormato(int Codigo)
        {
            RegistroServidorDTO registroServidorDTO = new RegistroServidorDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroServidorEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroServidorId", SqlDbType.Int);
                    cmd.Parameters["@RegistroServidorId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroServidorDTO.RegistroServidorId = Convert.ToInt32(dr["RegistroServidorId"]);
                        registroServidorDTO.CodigoIBPServidor = dr["CodigoIBPServidor"].ToString();
                        registroServidorDTO.ModeloBienServicioSubcampoId = Convert.ToInt32(dr["ModeloBienServicioSubcampoId"]);
                        registroServidorDTO.ModeloBienServicioDenominacionId = Convert.ToInt32(dr["ModeloBienServicioDenominacionId"]);
                        registroServidorDTO.MarcaId = Convert.ToInt32(dr["MarcaId"]);
                        registroServidorDTO.CapacidadMemoriaRam = dr["CapacidadMemoriaRam"].ToString();
                        registroServidorDTO.CapacidadDiscoDuro = dr["CapacidadDiscoDuro"].ToString();
                        registroServidorDTO.AnioAdquisicionServidor = Convert.ToDateTime(dr["AnioAdquisicionServidor"]).ToString("yyy-MM-dd");
                        registroServidorDTO.EstadoOperatividadServidor = dr["EstadoOperatividadServidor"].ToString();
                        registroServidorDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        registroServidorDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]); 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroServidorDTO;
        }

        public string ActualizaFormato(RegistroServidorDTO registroServidorDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroServidorActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroServidorId", SqlDbType.Int);
                    cmd.Parameters["@RegistroServidorId"].Value = registroServidorDTO.RegistroServidorId;

                    cmd.Parameters.Add("@CodigoIBPServidor", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPServidor"].Value = registroServidorDTO.CodigoIBPServidor;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroServidorDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroServidorDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroServidorDTO.MarcaId;

                    cmd.Parameters.Add("@CapacidadMemoriaRam", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CapacidadMemoriaRam"].Value = registroServidorDTO.CapacidadMemoriaRam;

                    cmd.Parameters.Add("@CapacidadDiscoDuro", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CapacidadDiscoDuro"].Value = registroServidorDTO.CapacidadDiscoDuro;

                    cmd.Parameters.Add("@AnioAdquisicionServidor", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionServidor"].Value = registroServidorDTO.AnioAdquisicionServidor;

                    cmd.Parameters.Add("@EstadoOperatividadServidor", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadServidor"].Value = registroServidorDTO.EstadoOperatividadServidor;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroServidorDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroServidorDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroServidorDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroServidorDTO registroServidorDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroServidorEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroServidorId", SqlDbType.Int);
                    cmd.Parameters["@RegistroServidorId"].Value = registroServidorDTO.RegistroServidorId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroServidorDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroServidorRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroServidor", SqlDbType.Structured);
                    cmd.Parameters["@RegistroServidor"].TypeName = "Formato.RegistroServidor";
                    cmd.Parameters["@RegistroServidor"].Value = datos;

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
