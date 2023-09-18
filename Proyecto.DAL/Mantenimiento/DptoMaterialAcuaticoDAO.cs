using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DptoMaterialAcuaticoDAO
    {

        SqlCommand cmd = new();

        public List<DptoMaterialAcuaticoDTO> ObtenerDptoMaterialAcuaticos()
        {
            List<DptoMaterialAcuaticoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DptoMaterialAcuaticoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DptoMaterialAcuaticoDTO()
                        {
                            DptoMaterialAcuaticoId = Convert.ToInt32(dr["DptoMaterialAcuaticoId"]),
                            DescDptoMaterialAcuatico = dr["DescDptoMaterialAcuatico"].ToString(),
                            CodigoDptoMaterialAcuatico = dr["CodigoDptoMaterialAcuatico"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDptoMaterialAcuatico(DptoMaterialAcuaticoDTO DptoMaterialAcuaticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoMaterialAcuaticoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescDptoMaterialAcuatico", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescDptoMaterialAcuatico"].Value = DptoMaterialAcuaticoDTO.DescDptoMaterialAcuatico;

                    cmd.Parameters.Add("@CodigoDptoMaterialAcuatico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDptoMaterialAcuatico"].Value = DptoMaterialAcuaticoDTO.CodigoDptoMaterialAcuatico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DptoMaterialAcuaticoDTO.UsuarioIngresoRegistro;

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

        public DptoMaterialAcuaticoDTO BuscarDptoMaterialAcuaticoID(int Codigo)
        {
            DptoMaterialAcuaticoDTO DptoMaterialAcuaticoDTO = new DptoMaterialAcuaticoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoMaterialAcuaticoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoMaterialAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@DptoMaterialAcuaticoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        DptoMaterialAcuaticoDTO.DptoMaterialAcuaticoId = Convert.ToInt32(dr["DptoMaterialAcuaticoId"]);
                        DptoMaterialAcuaticoDTO.DescDptoMaterialAcuatico = dr["DescDptoMaterialAcuatico"].ToString();
                        DptoMaterialAcuaticoDTO.CodigoDptoMaterialAcuatico = dr["CodigoDptoMaterialAcuatico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return DptoMaterialAcuaticoDTO;
        }

        public string ActualizarDptoMaterialAcuatico(DptoMaterialAcuaticoDTO DptoMaterialAcuaticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoMaterialAcuaticoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoMaterialAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@DptoMaterialAcuaticoId"].Value = DptoMaterialAcuaticoDTO.DptoMaterialAcuaticoId;

                    cmd.Parameters.Add("@DescDptoMaterialAcuatico", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescDptoMaterialAcuatico"].Value = DptoMaterialAcuaticoDTO.DescDptoMaterialAcuatico;

                    cmd.Parameters.Add("@CodigoDptoMaterialAcuatico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDptoMaterialAcuatico"].Value = DptoMaterialAcuaticoDTO.CodigoDptoMaterialAcuatico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DptoMaterialAcuaticoDTO.UsuarioIngresoRegistro;

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

        public string EliminarDptoMaterialAcuatico(DptoMaterialAcuaticoDTO DptoMaterialAcuaticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DptoMaterialAcuaticoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DptoMaterialAcuaticoId", SqlDbType.Int);
                    cmd.Parameters["@DptoMaterialAcuaticoId"].Value = DptoMaterialAcuaticoDTO.DptoMaterialAcuaticoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DptoMaterialAcuaticoDTO.UsuarioIngresoRegistro;

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
