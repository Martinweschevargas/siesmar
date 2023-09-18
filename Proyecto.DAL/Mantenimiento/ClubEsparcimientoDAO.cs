using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClubEsparcimientoDAO
    {

        SqlCommand cmd = new();

        public List<ClubEsparcimientoDTO> ObtenerClubEsparcimientos()
        {
            List<ClubEsparcimientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClubEsparcimientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClubEsparcimientoDTO()
                        {
                            ClubEsparcimientoId = Convert.ToInt32(dr["ClubEsparcimientoId"]),
                            DescClubEsparcimiento = dr["DescClubEsparcimiento"].ToString(),
                            CodigoClubEsparcimiento = dr["CodigoClubEsparcimiento"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClubEsparcimiento(ClubEsparcimientoDTO ClubEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClubEsparcimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoClubEsparcimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClubEsparcimiento"].Value = ClubEsparcimientoDTO.CodigoClubEsparcimiento;

                    cmd.Parameters.Add("@DescClubEsparcimiento", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClubEsparcimiento"].Value = ClubEsparcimientoDTO.DescClubEsparcimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClubEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public ClubEsparcimientoDTO BuscarClubEsparcimientoID(int Codigo)
        {
            ClubEsparcimientoDTO ClubEsparcimientoDTO = new ClubEsparcimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClubEsparcimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClubEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@ClubEsparcimientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ClubEsparcimientoDTO.ClubEsparcimientoId = Convert.ToInt32(dr["ClubEsparcimientoId"]);
                        ClubEsparcimientoDTO.DescClubEsparcimiento = dr["DescClubEsparcimiento"].ToString();
                        ClubEsparcimientoDTO.CodigoClubEsparcimiento = dr["CodigoClubEsparcimiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ClubEsparcimientoDTO;
        }

        public string ActualizarClubEsparcimiento(ClubEsparcimientoDTO ClubEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClubEsparcimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClubEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@ClubEsparcimientoId"].Value = ClubEsparcimientoDTO.ClubEsparcimientoId;

                    cmd.Parameters.Add("@DescClubEsparcimiento", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClubEsparcimiento"].Value = ClubEsparcimientoDTO.DescClubEsparcimiento;

                    cmd.Parameters.Add("@CodigoClubEsparcimiento", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoClubEsparcimiento"].Value = ClubEsparcimientoDTO.CodigoClubEsparcimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClubEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public string EliminarClubEsparcimiento(ClubEsparcimientoDTO ClubEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClubEsparcimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClubEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@ClubEsparcimientoId"].Value = ClubEsparcimientoDTO.ClubEsparcimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClubEsparcimientoDTO.UsuarioIngresoRegistro;

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
