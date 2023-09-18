using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class BlockVillaNavalDAO
    {

        SqlCommand cmd = new();

        public List<BlockVillaNavalDTO> ObtenerBlockVillaNavals()
        {
            List<BlockVillaNavalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_BlockVillaNavalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new BlockVillaNavalDTO()
                        {
                            BlockVillaNavalId = Convert.ToInt32(dr["BlockVillaNavalId"]),
                            CodigoBlockVillaNaval = dr["CodigoBlockVillaNaval"].ToString(),
                            DescBlockVillaNaval = dr["DescBlockVillaNaval"].ToString(),
                            DescVillaNaval = dr["DescVillaNaval"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarBlockVillaNaval(BlockVillaNavalDTO blockVillaNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_BlockVillaNavalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoBlockVillaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoBlockVillaNaval"].Value = blockVillaNavalDTO.CodigoBlockVillaNaval;

                    cmd.Parameters.Add("@DescBlockVillaNaval", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescBlockVillaNaval"].Value = blockVillaNavalDTO.DescBlockVillaNaval;

                    cmd.Parameters.Add("@CodigoVillaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVillaNaval"].Value = blockVillaNavalDTO.CodigoVillaNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = blockVillaNavalDTO.UsuarioIngresoRegistro;

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

        public BlockVillaNavalDTO BuscarBlockCodigoVillaNaval(int Codigo)
        {
            BlockVillaNavalDTO blockVillaNavalDTO = new BlockVillaNavalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_BlockVillaNavalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BlockVillaNavalId", SqlDbType.Int);
                    cmd.Parameters["@BlockVillaNavalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        blockVillaNavalDTO.BlockVillaNavalId = Convert.ToInt32(dr["BlockCodigoVillaNaval"]);
                        blockVillaNavalDTO.CodigoBlockVillaNaval = dr["CodigoBlockVillaNaval"].ToString();
                        blockVillaNavalDTO.DescBlockVillaNaval = dr["DescBlockVillaNaval"].ToString();
                        blockVillaNavalDTO.CodigoVillaNaval = dr["CodigoVillaNaval"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return blockVillaNavalDTO;
        }

        public string ActualizarBlockVillaNaval(BlockVillaNavalDTO blockVillaNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_BlockVillaNavalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BlockVillaNavalId", SqlDbType.Int);
                    cmd.Parameters["@BlockVillaNavalId"].Value = blockVillaNavalDTO.BlockVillaNavalId;

                    cmd.Parameters.Add("@CodigoBlockVillaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoBlockVillaNaval"].Value = blockVillaNavalDTO.CodigoBlockVillaNaval;

                    cmd.Parameters.Add("@DescBlockVillaNaval", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescBlockVillaNaval"].Value = blockVillaNavalDTO.DescBlockVillaNaval;

                    cmd.Parameters.Add("@CodigoVillaNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoVillaNaval"].Value = blockVillaNavalDTO.CodigoVillaNaval;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = blockVillaNavalDTO.UsuarioIngresoRegistro;

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

        public string EliminarBlockVillaNaval(BlockVillaNavalDTO blockVillaNavalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_BlockVillaNavalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@BlockVillaNavalId", SqlDbType.Int);
                    cmd.Parameters["@BlockVillaNavalId"].Value = blockVillaNavalDTO.BlockVillaNavalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = blockVillaNavalDTO.UsuarioIngresoRegistro;

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
