 using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Dirtel;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Dirtel
{
    public class RegistroEquipoComunicacionDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<RegistroEquipoComunicacionDTO> ObtenerLista()
        {
            List<RegistroEquipoComunicacionDTO> lista = new List<RegistroEquipoComunicacionDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_RegistroEquipoComunicacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegistroEquipoComunicacionDTO()
                        {
                            RegistroEquipoComunicacionId = Convert.ToInt32(dr["RegistroEquipoComunicacionId"]),
                            CodigoIBPEquipoComunicacion = dr["CodigoIBPEquipoComunicacion"].ToString(),
                            DescModeloBienServicioSubcampo = dr["DescModeloBienServicioSubcampo"].ToString(),
                            DescModeloBienServicioDenominacion = dr["DescModeloBienServicioDenominacion"].ToString(),
                            DescMarca = dr["DescMarca"].ToString(),
                            DescModeloEquipoComunicacion = dr["DescModeloEquipoComunicacion"].ToString(),
                            ModoComunicacion = dr["ModoComunicacion"].ToString(),
                            DescTipoComunicacionDirtel = dr["DescTipoComunicacionDirtel"].ToString(),
                            AnioAdquisicionComunicacion = (dr["AnioAdquisicionComunicacion"].ToString()).Split(" ", StringSplitOptions.None)[0],
                            EstadoOperatividadComunicacion = dr["EstadoOperatividadComunicacion"].ToString(),
                            DescDependencia = dr["DescDependencia"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            CargaId = Convert.ToInt32(dr["CargaId"]),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(RegistroEquipoComunicacionDTO registroEquipoComunicacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoComunicacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoIBPEquipoComunicacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPEquipoComunicacion"].Value = registroEquipoComunicacionDTO.CodigoIBPEquipoComunicacion;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroEquipoComunicacionDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroEquipoComunicacionDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroEquipoComunicacionDTO.MarcaId;

                    cmd.Parameters.Add("@ModeloEquipoComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloEquipoComunicacionId"].Value = registroEquipoComunicacionDTO.ModeloEquipoComunicacionId;

                    cmd.Parameters.Add("@ModoComunicacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ModoComunicacion"].Value = registroEquipoComunicacionDTO.ModoComunicacion;

                    cmd.Parameters.Add("@TipoComunicacionDirtelId", SqlDbType.Int);
                    cmd.Parameters["@TipoComunicacionDirtelId"].Value = registroEquipoComunicacionDTO.TipoComunicacionDirtelId;

                    cmd.Parameters.Add("@AnioAdquisicionComunicacion", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionComunicacion"].Value = registroEquipoComunicacionDTO.AnioAdquisicionComunicacion;

                    cmd.Parameters.Add("@EstadoOperatividadComunicacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadComunicacion"].Value = registroEquipoComunicacionDTO.EstadoOperatividadComunicacion;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroEquipoComunicacionDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroEquipoComunicacionDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoComunicacionDTO.UsuarioIngresoRegistro;

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

        public RegistroEquipoComunicacionDTO BuscarFormato(int Codigo)
        {
            RegistroEquipoComunicacionDTO registroEquipoComunicacionDTO = new RegistroEquipoComunicacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoComunicacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoComunicacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        registroEquipoComunicacionDTO.RegistroEquipoComunicacionId = Convert.ToInt32(dr["RegistroEquipoComunicacionId"]);
                        registroEquipoComunicacionDTO.CodigoIBPEquipoComunicacion = dr["CodigoIBPEquipoComunicacion"].ToString();
                        registroEquipoComunicacionDTO.ModeloBienServicioSubcampoId = Convert.ToInt32(dr["ModeloBienServicioSubcampoId"]);
                        registroEquipoComunicacionDTO.ModeloBienServicioDenominacionId = Convert.ToInt32(dr["ModeloBienServicioDenominacionId"]);
                        registroEquipoComunicacionDTO.MarcaId = Convert.ToInt32(dr["MarcaId"]);
                        registroEquipoComunicacionDTO.ModeloEquipoComunicacionId = Convert.ToInt32(dr["ModeloEquipoComunicacionId"]);
                        registroEquipoComunicacionDTO.ModoComunicacion = dr["ModoComunicacion"].ToString();
                        registroEquipoComunicacionDTO.TipoComunicacionDirtelId = Convert.ToInt32(dr["TipoComunicacionDirtelId"]);
                        registroEquipoComunicacionDTO.AnioAdquisicionComunicacion = Convert.ToDateTime(dr["AnioAdquisicionComunicacion"]).ToString("yyy-MM-dd");
                        registroEquipoComunicacionDTO.EstadoOperatividadComunicacion = dr["EstadoOperatividadComunicacion"].ToString();
                        registroEquipoComunicacionDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        registroEquipoComunicacionDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]); 


                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return registroEquipoComunicacionDTO;
        }

        public string ActualizaFormato(RegistroEquipoComunicacionDTO registroEquipoComunicacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_RegistroEquipoComunicacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@RegistroEquipoComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoComunicacionId"].Value = registroEquipoComunicacionDTO.RegistroEquipoComunicacionId;

                    cmd.Parameters.Add("@CodigoIBPEquipoComunicacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@CodigoIBPEquipoComunicacion"].Value = registroEquipoComunicacionDTO.CodigoIBPEquipoComunicacion;

                    cmd.Parameters.Add("@ModeloBienServicioSubcampoId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioSubcampoId"].Value = registroEquipoComunicacionDTO.ModeloBienServicioSubcampoId;

                    cmd.Parameters.Add("@ModeloBienServicioDenominacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloBienServicioDenominacionId"].Value = registroEquipoComunicacionDTO.ModeloBienServicioDenominacionId;

                    cmd.Parameters.Add("@MarcaId", SqlDbType.Int);
                    cmd.Parameters["@MarcaId"].Value = registroEquipoComunicacionDTO.MarcaId;

                    cmd.Parameters.Add("@ModeloEquipoComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@ModeloEquipoComunicacionId"].Value = registroEquipoComunicacionDTO.ModeloEquipoComunicacionId;

                    cmd.Parameters.Add("@ModoComunicacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@ModoComunicacion"].Value = registroEquipoComunicacionDTO.ModoComunicacion;

                    cmd.Parameters.Add("@TipoComunicacionDirtelId", SqlDbType.Int);
                    cmd.Parameters["@TipoComunicacionDirtelId"].Value = registroEquipoComunicacionDTO.TipoComunicacionDirtelId;

                    cmd.Parameters.Add("@AnioAdquisicionComunicacion", SqlDbType.Date);
                    cmd.Parameters["@AnioAdquisicionComunicacion"].Value = registroEquipoComunicacionDTO.AnioAdquisicionComunicacion;

                    cmd.Parameters.Add("@EstadoOperatividadComunicacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@EstadoOperatividadComunicacion"].Value = registroEquipoComunicacionDTO.EstadoOperatividadComunicacion;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = registroEquipoComunicacionDTO.DependenciaId;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = registroEquipoComunicacionDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoComunicacionDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(RegistroEquipoComunicacionDTO registroEquipoComunicacionDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_RegistroEquipoComunicacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoComunicacionId", SqlDbType.Int);
                    cmd.Parameters["@RegistroEquipoComunicacionId"].Value = registroEquipoComunicacionDTO.RegistroEquipoComunicacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = registroEquipoComunicacionDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_RegistroEquipoComunicacionRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegistroEquipoComunicacion", SqlDbType.Structured);
                    cmd.Parameters["@RegistroEquipoComunicacion"].TypeName = "Formato.RegistroEquipoComunicacion";
                    cmd.Parameters["@RegistroEquipoComunicacion"].Value = datos;

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
