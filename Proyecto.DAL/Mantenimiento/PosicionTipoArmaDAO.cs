using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class PosicionTipoArmaDAO
    {

        SqlCommand cmd = new();

        public List<PosicionTipoArmaDTO> ObtenerPosicionTipoArmas()
        {
            List<PosicionTipoArmaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_PosicionTipoArmaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new PosicionTipoArmaDTO()
                        {
                            PosicionTipoArmaId = Convert.ToInt32(dr["PosicionTipoArmaId"]),
                            DescPosicionTipoArma = dr["DescPosicionTipoArma"].ToString(),
                            CodigoPosicionTipoArma = dr["CodigoPosicionTipoArma"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarPosicionTipoArma(PosicionTipoArmaDTO posicionTipoArmaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PosicionTipoArmaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescPosicionTipoArma", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescPosicionTipoArma"].Value = posicionTipoArmaDTO.DescPosicionTipoArma;

                    cmd.Parameters.Add("@CodigoPosicionTipoArma", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPosicionTipoArma"].Value = posicionTipoArmaDTO.CodigoPosicionTipoArma;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = posicionTipoArmaDTO.UsuarioIngresoRegistro;

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

        public PosicionTipoArmaDTO BuscarPosicionTipoArmaID(int Codigo)
        {
            PosicionTipoArmaDTO posicionTipoArmaDTO = new PosicionTipoArmaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PosicionTipoArmaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PosicionTipoArmaId", SqlDbType.Int);
                    cmd.Parameters["@PosicionTipoArmaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        posicionTipoArmaDTO.PosicionTipoArmaId = Convert.ToInt32(dr["PosicionTipoArmaId"]);
                        posicionTipoArmaDTO.DescPosicionTipoArma = dr["DescPosicionTipoArma"].ToString();
                        posicionTipoArmaDTO.CodigoPosicionTipoArma = dr["CodigoPosicionTipoArma"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return posicionTipoArmaDTO;
        }

        public string ActualizarPosicionTipoArma(PosicionTipoArmaDTO posicionTipoArmaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PosicionTipoArmaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PosicionTipoArmaId", SqlDbType.Int);
                    cmd.Parameters["@PosicionTipoArmaId"].Value = posicionTipoArmaDTO.PosicionTipoArmaId;

                    cmd.Parameters.Add("@DescPosicionTipoArma", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescPosicionTipoArma"].Value = posicionTipoArmaDTO.DescPosicionTipoArma;

                    cmd.Parameters.Add("@CodigoPosicionTipoArma", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoPosicionTipoArma"].Value = posicionTipoArmaDTO.CodigoPosicionTipoArma;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = posicionTipoArmaDTO.UsuarioIngresoRegistro;

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

        public string EliminarPosicionTipoArma(PosicionTipoArmaDTO posicionTipoArmaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_PosicionTipoArmaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@PosicionTipoArmaId", SqlDbType.Int);
                    cmd.Parameters["@PosicionTipoArmaId"].Value = posicionTipoArmaDTO.PosicionTipoArmaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = posicionTipoArmaDTO.UsuarioIngresoRegistro;

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
