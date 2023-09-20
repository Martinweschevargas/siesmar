using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AlistamientoMaterialRequeridoComescuamaDAO
    {

        SqlCommand cmd = new();

        public List<AlistamientoMaterialRequeridoComescuamaDTO> ObtenerAlistamientoMaterialRequeridoComescuamas()
        {
            List<AlistamientoMaterialRequeridoComescuamaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequeridoComescuamaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AlistamientoMaterialRequeridoComescuamaDTO()
                        {
                            AlistamientoMaterialRequeridoComescuamaId = Convert.ToInt32(dr["AlistamientoMaterialRequeridoComescuamaId"]),
                            CodigoAlistamientoMaterialRequeridoComescuama = dr["CodigoAlistamientoMaterialRequeridoComescuama"].ToString(),
                            CodigoAlistamientoMaterialRequerido3N = dr["CodigoAlistamientoMaterialRequerido3N"].ToString(),
                            Subclasificacion = dr["SubClasificacion"].ToString(),
                            Requerido = dr["Requerido"].ToString(),
                            Operativo = dr["Operativo"].ToString(),
                            PorcentajeOperatividad = dr["PorcentajeOperatividad"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAlistamientoMaterialRequeridoComescuama(AlistamientoMaterialRequeridoComescuamaDTO alistamientoMaterialRequeridoComescuamaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequeridoComescuamaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequeridoComescuama", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequeridoComescuama"].Value = alistamientoMaterialRequeridoComescuamaDTO.CodigoAlistamientoMaterialRequeridoComescuama;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido3N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido3N"].Value = alistamientoMaterialRequeridoComescuamaDTO.CodigoAlistamientoMaterialRequerido3N;

                    cmd.Parameters.Add("@Requerido", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Requerido"].Value = alistamientoMaterialRequeridoComescuamaDTO.Requerido;

                    cmd.Parameters.Add("@Operativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Operativo"].Value = alistamientoMaterialRequeridoComescuamaDTO.Operativo;

                    cmd.Parameters.Add("@PorcentajeOperatividad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@PorcentajeOperatividad"].Value = alistamientoMaterialRequeridoComescuamaDTO.PorcentajeOperatividad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialRequeridoComescuamaDTO.UsuarioIngresoRegistro;

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

        public AlistamientoMaterialRequeridoComescuamaDTO BuscarAlistamientoMaterialRequeridoComescuamaID(int Codigo)
        {
            AlistamientoMaterialRequeridoComescuamaDTO alistamientoMaterialRequeridoComescuamaDTO = new AlistamientoMaterialRequeridoComescuamaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequeridoComescuamaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialRequeridoComescuamaId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequeridoComescuamaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        alistamientoMaterialRequeridoComescuamaDTO.AlistamientoMaterialRequeridoComescuamaId = Convert.ToInt32(dr["AlistamientoMaterialRequeridoComescuamaId"]);
                        alistamientoMaterialRequeridoComescuamaDTO.CodigoAlistamientoMaterialRequeridoComescuama = dr["CodigoAlistamientoMaterialRequeridoComescuama"].ToString();
                        alistamientoMaterialRequeridoComescuamaDTO.CodigoAlistamientoMaterialRequerido3N = dr["CodigoAlistamientoMaterialRequerido3N"].ToString();
                        alistamientoMaterialRequeridoComescuamaDTO.Requerido = dr["Requerido"].ToString();
                        alistamientoMaterialRequeridoComescuamaDTO.Operativo = dr["Operativo"].ToString();
                        alistamientoMaterialRequeridoComescuamaDTO.PorcentajeOperatividad = dr["PorcentajeOperatividad"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return alistamientoMaterialRequeridoComescuamaDTO;
        }

        public string ActualizarAlistamientoMaterialRequeridoComescuama(AlistamientoMaterialRequeridoComescuamaDTO alistamientoMaterialRequeridoComescuamaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequeridoComescuamaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialRequeridoComescuamaId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequeridoComescuamaId"].Value = alistamientoMaterialRequeridoComescuamaDTO.AlistamientoMaterialRequeridoComescuamaId;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequeridoComescuama", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequeridoComescuama"].Value = alistamientoMaterialRequeridoComescuamaDTO.CodigoAlistamientoMaterialRequeridoComescuama;

                    cmd.Parameters.Add("@CodigoAlistamientoMaterialRequerido3N", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoAlistamientoMaterialRequerido3N"].Value = alistamientoMaterialRequeridoComescuamaDTO.CodigoAlistamientoMaterialRequerido3N;

                    cmd.Parameters.Add("@Requerido", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Requerido"].Value = alistamientoMaterialRequeridoComescuamaDTO.Requerido;

                    cmd.Parameters.Add("@Operativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@Operativo"].Value = alistamientoMaterialRequeridoComescuamaDTO.Operativo;

                    cmd.Parameters.Add("@PorcentajeOperatividad", SqlDbType.VarChar, 20);
                    cmd.Parameters["@PorcentajeOperatividad"].Value = alistamientoMaterialRequeridoComescuamaDTO.PorcentajeOperatividad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialRequeridoComescuamaDTO.UsuarioIngresoRegistro;

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

        public string EliminarAlistamientoMaterialRequeridoComescuama(AlistamientoMaterialRequeridoComescuamaDTO alistamientoMaterialRequeridoComescuamaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AlistamientoMaterialRequeridoComescuamaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AlistamientoMaterialRequeridoComescuamaId", SqlDbType.Int);
                    cmd.Parameters["@AlistamientoMaterialRequeridoComescuamaId"].Value = alistamientoMaterialRequeridoComescuamaDTO.AlistamientoMaterialRequeridoComescuamaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = alistamientoMaterialRequeridoComescuamaDTO.UsuarioIngresoRegistro;

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
