using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DenominacionLenguajeProgramacionDAO
    {

        SqlCommand cmd = new();

        public List<DenominacionLenguajeProgramacionDTO> ObtenerDenominacionLenguajeProgramacions()
        {
            List<DenominacionLenguajeProgramacionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DenominacionLenguajeProgramacionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DenominacionLenguajeProgramacionDTO()
                        {
                            DenominacionLenguajeProgramacionId = Convert.ToInt32(dr["DenominacionLenguajeProgramacionId"]),
                            DescDenominacionLenguajeProgramacion = dr["DescDenominacionLenguajeProgramacion"].ToString(),
                            CodigoDenominacionLenguajeProgramacion = dr["CodigoDenominacionLenguajeProgramacion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDenominacionLenguajeProgramacion(DenominacionLenguajeProgramacionDTO denominacionLenguajeProgramacionDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DenominacionLenguajeProgramacionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescDenominacionLenguajeProgramacion", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescDenominacionLenguajeProgramacion"].Value = denominacionLenguajeProgramacionDTO.DescDenominacionLenguajeProgramacion;

                    cmd.Parameters.Add("@CodigoDenominacionLenguajeProgramacion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoDenominacionLenguajeProgramacion"].Value = denominacionLenguajeProgramacionDTO.CodigoDenominacionLenguajeProgramacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = denominacionLenguajeProgramacionDTO.UsuarioIngresoRegistro;

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

        public DenominacionLenguajeProgramacionDTO BuscarDenominacionLenguajeProgramacionID(int Codigo)
        {
            DenominacionLenguajeProgramacionDTO denominacionLenguajeProgramacionDTO = new DenominacionLenguajeProgramacionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DenominacionLenguajeProgramacionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenominacionLenguajeProgramacionId", SqlDbType.Int);
                    cmd.Parameters["@DenominacionLenguajeProgramacionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        denominacionLenguajeProgramacionDTO.DenominacionLenguajeProgramacionId = Convert.ToInt32(dr["DenominacionLenguajeProgramacionId"]);
                        denominacionLenguajeProgramacionDTO.DescDenominacionLenguajeProgramacion = dr["DescDenominacionLenguajeProgramacion"].ToString();
                        denominacionLenguajeProgramacionDTO.CodigoDenominacionLenguajeProgramacion = dr["CodigoDenominacionLenguajeProgramacion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return denominacionLenguajeProgramacionDTO;
        }

        public string ActualizarDenominacionLenguajeProgramacion(DenominacionLenguajeProgramacionDTO denominacionLenguajeProgramacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DenominacionLenguajeProgramacionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenominacionLenguajeProgramacionId", SqlDbType.Int);
                    cmd.Parameters["@DenominacionLenguajeProgramacionId"].Value = denominacionLenguajeProgramacionDTO.DenominacionLenguajeProgramacionId;

                    cmd.Parameters.Add("@DescDenominacionLenguajeProgramacion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescDenominacionLenguajeProgramacion"].Value = denominacionLenguajeProgramacionDTO.DescDenominacionLenguajeProgramacion;

                    cmd.Parameters.Add("@CodigoDenominacionLenguajeProgramacion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDenominacionLenguajeProgramacion"].Value = denominacionLenguajeProgramacionDTO.CodigoDenominacionLenguajeProgramacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = denominacionLenguajeProgramacionDTO.UsuarioIngresoRegistro;

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

        public string EliminarDenominacionLenguajeProgramacion(DenominacionLenguajeProgramacionDTO denominacionLenguajeProgramacionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DenominacionLenguajeProgramacionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DenominacionLenguajeProgramacionId", SqlDbType.Int);
                    cmd.Parameters["@DenominacionLenguajeProgramacionId"].Value = denominacionLenguajeProgramacionDTO.DenominacionLenguajeProgramacionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = denominacionLenguajeProgramacionDTO.UsuarioIngresoRegistro;

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
