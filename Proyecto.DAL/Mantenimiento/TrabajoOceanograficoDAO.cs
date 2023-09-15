using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TrabajoOceanograficoDAO
    {

        SqlCommand cmd = new();

        public List<TrabajoOceanograficoDTO> ObtenerTrabajoOceanograficos()
        {
            List<TrabajoOceanograficoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TrabajoOceanograficoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TrabajoOceanograficoDTO()
                        {
                            TrabajoOceanograficoId = Convert.ToInt32(dr["TrabajoOceanograficoId"]),
                            DescTrabajoOceanografico = dr["DescTrabajoOceanografico"].ToString(),
                            CodigoTrabajoOceanografico = dr["CodigoTrabajoOceanografico"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTrabajoOceanografico(TrabajoOceanograficoDTO trabajoOceanograficoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajoOceanograficoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTrabajoOceanografico", SqlDbType.VarChar, 50);                    
                    cmd.Parameters["@DescTrabajoOceanografico"].Value = trabajoOceanograficoDTO.DescTrabajoOceanografico;

                    cmd.Parameters.Add("@CodigoTrabajoOceanografico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTrabajoOceanografico"].Value = trabajoOceanograficoDTO.CodigoTrabajoOceanografico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoOceanograficoDTO.UsuarioIngresoRegistro;

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

        public TrabajoOceanograficoDTO BuscarTrabajoOceanograficoID(int Codigo)
        {
            TrabajoOceanograficoDTO trabajoOceanograficoDTO = new TrabajoOceanograficoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajoOceanograficoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoOceanograficoId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoOceanograficoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        trabajoOceanograficoDTO.TrabajoOceanograficoId = Convert.ToInt32(dr["TrabajoOceanograficoId"]);
                        trabajoOceanograficoDTO.DescTrabajoOceanografico = dr["DescTrabajoOceanografico"].ToString();
                        trabajoOceanograficoDTO.CodigoTrabajoOceanografico = dr["CodigoTrabajoOceanografico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return trabajoOceanograficoDTO;
        }

        public string ActualizarTrabajoOceanografico(TrabajoOceanograficoDTO trabajoOceanograficoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_TrabajoOceanograficoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoOceanograficoId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoOceanograficoId"].Value = trabajoOceanograficoDTO.TrabajoOceanograficoId;

                    cmd.Parameters.Add("@DescTrabajoOceanografico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTrabajoOceanografico"].Value = trabajoOceanograficoDTO.DescTrabajoOceanografico;

                    cmd.Parameters.Add("@CodigoTrabajoOceanografico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTrabajoOceanografico"].Value = trabajoOceanograficoDTO.CodigoTrabajoOceanografico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoOceanograficoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarTrabajoOceanografico(TrabajoOceanograficoDTO trabajoOceanograficoDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajoOceanograficoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoOceanograficoId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoOceanograficoId"].Value = trabajoOceanograficoDTO.TrabajoOceanograficoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoOceanograficoDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    cmd.ExecuteNonQuery();
                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }

    }
}
