using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class AdquisicionTerrenoDAO
    {

        SqlCommand cmd = new();

        public List<AdquisicionTerrenoDTO> ObtenerAdquisicionTerrenos()
        {
            List<AdquisicionTerrenoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_AdquisicionTerrenoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new AdquisicionTerrenoDTO()
                        {
                            AdquisicionTerrenoId = Convert.ToInt32(dr["AdquisicionTerrenoId"]),
                            DescAdquisicionTerreno = dr["DescAdquisicionTerreno"].ToString(),
                            CodigoAdquisicionTerreno = dr["CodigoAdquisicionTerreno"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarAdquisicionTerreno(AdquisicionTerrenoDTO AdquisicionTerrenoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AdquisicionTerrenoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescAdquisicionTerreno", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescAdquisicionTerreno"].Value = AdquisicionTerrenoDTO.DescAdquisicionTerreno;

                    cmd.Parameters.Add("@CodigoAdquisicionTerreno", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAdquisicionTerreno"].Value = AdquisicionTerrenoDTO.CodigoAdquisicionTerreno;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AdquisicionTerrenoDTO.UsuarioIngresoRegistro;

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

        public AdquisicionTerrenoDTO BuscarAdquisicionTerrenoID(int Codigo)
        {
            AdquisicionTerrenoDTO AdquisicionTerrenoDTO = new AdquisicionTerrenoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AdquisicionTerrenoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AdquisicionTerrenoId", SqlDbType.Int);
                    cmd.Parameters["@AdquisicionTerrenoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        AdquisicionTerrenoDTO.AdquisicionTerrenoId = Convert.ToInt32(dr["AdquisicionTerrenoId"]);
                        AdquisicionTerrenoDTO.DescAdquisicionTerreno = dr["DescAdquisicionTerreno"].ToString();
                        AdquisicionTerrenoDTO.CodigoAdquisicionTerreno = dr["CodigoAdquisicionTerreno"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return AdquisicionTerrenoDTO;
        }

        public string ActualizarAdquisicionTerreno(AdquisicionTerrenoDTO AdquisicionTerrenoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AdquisicionTerrenoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AdquisicionTerrenoId", SqlDbType.Int);
                    cmd.Parameters["@AdquisicionTerrenoId"].Value = AdquisicionTerrenoDTO.AdquisicionTerrenoId;

                    cmd.Parameters.Add("@DescAdquisicionTerreno", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescAdquisicionTerreno"].Value = AdquisicionTerrenoDTO.DescAdquisicionTerreno;

                    cmd.Parameters.Add("@CodigoAdquisicionTerreno", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoAdquisicionTerreno"].Value = AdquisicionTerrenoDTO.CodigoAdquisicionTerreno;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AdquisicionTerrenoDTO.UsuarioIngresoRegistro;

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

        public string EliminarAdquisicionTerreno(AdquisicionTerrenoDTO AdquisicionTerrenoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_AdquisicionTerrenoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@AdquisicionTerrenoId", SqlDbType.Int);
                    cmd.Parameters["@AdquisicionTerrenoId"].Value = AdquisicionTerrenoDTO.AdquisicionTerrenoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = AdquisicionTerrenoDTO.UsuarioIngresoRegistro;

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
