using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SectorExtraInstitucionalDAO
    {

        SqlCommand cmd = new();

        public List<SectorExtraInstitucionalDTO> ObtenerSectorExtraInstitucionals()
        {
            List<SectorExtraInstitucionalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SectorExtraInstitucionalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SectorExtraInstitucionalDTO()
                        {
                            SectorExtraInstitucionalId = Convert.ToInt32(dr["SectorExtraInstitucionalId"]),
                            DescSectorExtraInstitucional = dr["DescSectorExtraInstitucional"].ToString(),
                            CodigoSectorExtraInstitucional = dr["CodigoSectorExtraInstitucional"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSectorExtraInstitucional(SectorExtraInstitucionalDTO SectorExtraInstitucionalDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SectorExtraInstitucionalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSectorExtraInstitucional", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSectorExtraInstitucional"].Value = SectorExtraInstitucionalDTO.DescSectorExtraInstitucional;
                    
                    cmd.Parameters.Add("@CodigoSectorExtraInstitucional", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoSectorExtraInstitucional"].Value = SectorExtraInstitucionalDTO.CodigoSectorExtraInstitucional;
                    
                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SectorExtraInstitucionalDTO.UsuarioIngresoRegistro;

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

        public SectorExtraInstitucionalDTO BuscarSectorExtraInstitucionalID(int Codigo)
        {
            SectorExtraInstitucionalDTO SectorExtraInstitucionalDTO = new SectorExtraInstitucionalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SectorExtraInstitucionalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SectorExtraInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@SectorExtraInstitucionalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        SectorExtraInstitucionalDTO.SectorExtraInstitucionalId = Convert.ToInt32(dr["SectorExtraInstitucionalId"]);
                        SectorExtraInstitucionalDTO.DescSectorExtraInstitucional = dr["DescSectorExtraInstitucional"].ToString();
                        SectorExtraInstitucionalDTO.CodigoSectorExtraInstitucional = dr["CodigoSectorExtraInstitucional"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return SectorExtraInstitucionalDTO;
        }

        public string ActualizarSectorExtraInstitucional(SectorExtraInstitucionalDTO SectorExtraInstitucionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SectorExtraInstitucionalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SectorExtraInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@SectorExtraInstitucionalId"].Value = SectorExtraInstitucionalDTO.SectorExtraInstitucionalId;

                    cmd.Parameters.Add("@DescSectorExtraInstitucional", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSectorExtraInstitucional"].Value = SectorExtraInstitucionalDTO.DescSectorExtraInstitucional;
                    
                    cmd.Parameters.Add("@CodigoSectorExtraInstitucional", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoSectorExtraInstitucional"].Value = SectorExtraInstitucionalDTO.CodigoSectorExtraInstitucional;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SectorExtraInstitucionalDTO.UsuarioIngresoRegistro;

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

        public string EliminarSectorExtraInstitucional(SectorExtraInstitucionalDTO SectorExtraInstitucionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SectorExtraInstitucionalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SectorExtraInstitucionalId", SqlDbType.Int);
                    cmd.Parameters["@SectorExtraInstitucionalId"].Value = SectorExtraInstitucionalDTO.SectorExtraInstitucionalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SectorExtraInstitucionalDTO.UsuarioIngresoRegistro;

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
