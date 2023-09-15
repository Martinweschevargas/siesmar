using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TrabajoHidrograficoDAO
    {

        SqlCommand cmd = new();

        public List<TrabajoHidrograficoDTO> ObtenerTrabajoHidrograficos()
        {
            List<TrabajoHidrograficoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TrabajoHidrograficoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TrabajoHidrograficoDTO()
                        {
                            TrabajoHidrograficoId = Convert.ToInt32(dr["TrabajoHidrograficoId"]),
                            DescTrabajoHidrografico = dr["DescTrabajoHidrografico"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTrabajoHidrografico(TrabajoHidrograficoDTO trabajoHidrograficoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajoHidrograficoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTrabajoHidrografico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTrabajoHidrografico"].Value = trabajoHidrograficoDTO.DescTrabajoHidrografico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoHidrograficoDTO.UsuarioIngresoRegistro;

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

        public TrabajoHidrograficoDTO BuscarTrabajoHidrograficoID(int Codigo)
        {
            TrabajoHidrograficoDTO trabajoHidrograficoDTO = new TrabajoHidrograficoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajoHidrograficoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoHidrograficoId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoHidrograficoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        trabajoHidrograficoDTO.TrabajoHidrograficoId = Convert.ToInt32(dr["TrabajoHidrograficoId"]);
                        trabajoHidrograficoDTO.DescTrabajoHidrografico = dr["DescTrabajoHidrografico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return trabajoHidrograficoDTO;
        }

        public string ActualizarTrabajoHidrografico(TrabajoHidrograficoDTO trabajoHidrograficoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajoHidrograficoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoHidrograficoId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoHidrograficoId"].Value = trabajoHidrograficoDTO.TrabajoHidrograficoId;

                    cmd.Parameters.Add("@DescTrabajoHidrografico", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescTrabajoHidrografico"].Value = trabajoHidrograficoDTO.DescTrabajoHidrografico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoHidrograficoDTO.UsuarioIngresoRegistro;

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

        public string EliminarTrabajoHidrografico(TrabajoHidrograficoDTO trabajoHidrograficoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TrabajoHidrograficoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TrabajoHidrograficoId", SqlDbType.Int);
                    cmd.Parameters["@TrabajoHidrograficoId"].Value = trabajoHidrograficoDTO.TrabajoHidrograficoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = trabajoHidrograficoDTO.UsuarioIngresoRegistro;

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
