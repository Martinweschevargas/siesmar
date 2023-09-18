using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AreaSalonClubEsparcimientoDAO
    {

        SqlCommand cmd = new();

        public List<AreaSalonClubEsparcimientoDTO> ObtenerAreaSalonClubEsparcimientos()
        {
            List<AreaSalonClubEsparcimientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AreaSalonClubEsparcimientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AreaSalonClubEsparcimientoDTO()
                        {
                            AreaSalonClubEsparcimientoId = Convert.ToInt32(dr["AreaSalonClubEsparcimientoId"]),
                            DescAreaSalonClubEsparcimiento = dr["DescAreaSalonClubEsparcimiento"].ToString(),
                            CodigoAreaSalonClubEsparcimiento = dr["CodigoAreaSalonClubEsparcimiento"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAreaSalonClubEsparcimiento(AreaSalonClubEsparcimientoDTO AreaSalonClubEsparcimientoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaSalonClubEsparcimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescAreaSalonClubEsparcimiento", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescAreaSalonClubEsparcimiento"].Value = AreaSalonClubEsparcimientoDTO.DescAreaSalonClubEsparcimiento;

                    cmd.Parameters.Add("@CodigoAreaSalonClubEsparcimiento", SqlDbType.VarChar, 10);                    
                    cmd.Parameters["@CodigoAreaSalonClubEsparcimiento"].Value = AreaSalonClubEsparcimientoDTO.CodigoAreaSalonClubEsparcimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AreaSalonClubEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public AreaSalonClubEsparcimientoDTO BuscarAreaSalonClubEsparcimientoID(int Codigo)
        {
            AreaSalonClubEsparcimientoDTO AreaSalonClubEsparcimientoDTO = new AreaSalonClubEsparcimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaSalonClubEsparcimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaSalonClubEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@AreaSalonClubEsparcimientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        AreaSalonClubEsparcimientoDTO.AreaSalonClubEsparcimientoId = Convert.ToInt32(dr["AreaSalonClubEsparcimientoId"]);
                        AreaSalonClubEsparcimientoDTO.DescAreaSalonClubEsparcimiento = dr["DescAreaSalonClubEsparcimiento"].ToString();
                        AreaSalonClubEsparcimientoDTO.CodigoAreaSalonClubEsparcimiento = dr["CodigoAreaSalonClubEsparcimiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return AreaSalonClubEsparcimientoDTO;
        }

        public string ActualizarAreaSalonClubEsparcimiento(AreaSalonClubEsparcimientoDTO AreaSalonClubEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaSalonClubEsparcimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaSalonClubEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@AreaSalonClubEsparcimientoId"].Value = AreaSalonClubEsparcimientoDTO.AreaSalonClubEsparcimientoId;

                    cmd.Parameters.Add("@DescAreaSalonClubEsparcimiento", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescAreaSalonClubEsparcimiento"].Value = AreaSalonClubEsparcimientoDTO.DescAreaSalonClubEsparcimiento;

                    cmd.Parameters.Add("@CodigoAreaSalonClubEsparcimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAreaSalonClubEsparcimiento"].Value = AreaSalonClubEsparcimientoDTO.CodigoAreaSalonClubEsparcimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AreaSalonClubEsparcimientoDTO.UsuarioIngresoRegistro;

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

        public string EliminarAreaSalonClubEsparcimiento(AreaSalonClubEsparcimientoDTO AreaSalonClubEsparcimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AreaSalonClubEsparcimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AreaSalonClubEsparcimientoId", SqlDbType.Int);
                    cmd.Parameters["@AreaSalonClubEsparcimientoId"].Value = AreaSalonClubEsparcimientoDTO.AreaSalonClubEsparcimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AreaSalonClubEsparcimientoDTO.UsuarioIngresoRegistro;

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
