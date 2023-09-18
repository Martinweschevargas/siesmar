using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AreaClubEsparcimientoDAO
    {

        SqlCommand cmd = new();

        public List<AreaClubEsparcimientoDTO> ObtenerAreaClubEsparcimientos()
        {
            List<AreaClubEsparcimientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AreaClubEsparcimientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AreaClubEsparcimientoDTO()
                        {
                            AreaClubEsparcimientoId = Convert.ToInt32(dr["AreaClubId"]),
                            DescAreaClubEsparcimiento = dr["DescAreaClub"].ToString(),
                            DescClubEsparcimiento = dr["DescClubEsparcimiento"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAreaClubEsparcimiento(AreaClubEsparcimientoDTO areaClubEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaClubEsparcimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescAreaClub", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescAreaClub"].Value = areaClubEsparcimientoDTO.DescAreaClubEsparcimiento;

                    cmd.Parameters.Add("@ClubEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@ClubEsparcimientoId"].Value = areaClubEsparcimientoDTO.ClubEsparcimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = areaClubEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public AreaClubEsparcimientoDTO BuscarAreaClubEsparcimientoID(int Codigo)
        {
            AreaClubEsparcimientoDTO areaClubEsparcimientoDTO = new AreaClubEsparcimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaClubEsparcimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaClubId", SqlDbType.Int);
                    cmd.Parameters["@AreaClubId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        areaClubEsparcimientoDTO.AreaClubEsparcimientoId = Convert.ToInt32(dr["AreaClubId"]);
                        areaClubEsparcimientoDTO.DescAreaClubEsparcimiento = dr["DescAreaClub"].ToString();
                        areaClubEsparcimientoDTO.ClubEsparcimientoId = Convert.ToInt32(dr["ClubEsparcimientoId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return areaClubEsparcimientoDTO;
        }

        public string ActualizarAreaClubEsparcimiento(AreaClubEsparcimientoDTO areaClubEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_AreaClubEsparcimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaClubId", SqlDbType.Int);
                    cmd.Parameters["@AreaClubId"].Value = areaClubEsparcimientoDTO.AreaClubEsparcimientoId;

                    cmd.Parameters.Add("@DescAreaClub", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescAreaClub"].Value = areaClubEsparcimientoDTO.DescAreaClubEsparcimiento;

                    cmd.Parameters.Add("@ClubEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@ClubEsparcimientoId"].Value = areaClubEsparcimientoDTO.ClubEsparcimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = areaClubEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public string EliminarAreaClubEsparcimiento(AreaClubEsparcimientoDTO areaClubEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaClubEsparcimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaClubId", SqlDbType.Int);
                    cmd.Parameters["@AreaClubId"].Value = areaClubEsparcimientoDTO.AreaClubEsparcimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = areaClubEsparcimientoDTO.UsuarioIngresoRegistro;

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
