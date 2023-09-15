using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class RegimenLaboralDAO
    {

        SqlCommand cmd = new();

        public List<RegimenLaboralDTO> ObtenerRegimenLaborals()
        {
            List<RegimenLaboralDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_RegimenLaboralListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new RegimenLaboralDTO()
                        {
                            RegimenLaboralId = Convert.ToInt32(dr["RegimenLaboralId"]),
                            DescRegimenLaboral = dr["DescRegimenLaboral"].ToString(),
                            CodigoRegimenLaboral = dr["CodigoRegimenLaboral"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegimenLaboral(RegimenLaboralDTO regimenLaboralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_RegimenLaboralRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescRegimenLaboral", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescRegimenLaboral"].Value = regimenLaboralDTO.DescRegimenLaboral;

                    cmd.Parameters.Add("@CodigoRegimenLaboral", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoRegimenLaboral"].Value = regimenLaboralDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = regimenLaboralDTO.UsuarioIngresoRegistro;

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

        public RegimenLaboralDTO BuscarRegimenLaboralID(int Codigo)
        {
            RegimenLaboralDTO regimenLaboralDTO = new RegimenLaboralDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_RegimenLaboralEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegimenLaboralId", SqlDbType.Int);
                    cmd.Parameters["@RegimenLaboralId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        regimenLaboralDTO.RegimenLaboralId = Convert.ToInt32(dr["RegimenLaboralId"]);
                        regimenLaboralDTO.DescRegimenLaboral = dr["DescRegimenLaboral"].ToString();
                        regimenLaboralDTO.CodigoRegimenLaboral = dr["CodigoRegimenLaboral"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return regimenLaboralDTO;
        }

        public string ActualizarRegimenLaboral(RegimenLaboralDTO regimenLaboralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_RegimenLaboralActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegimenLaboralId", SqlDbType.Int);
                    cmd.Parameters["@RegimenLaboralId"].Value = regimenLaboralDTO.RegimenLaboralId;

                    cmd.Parameters.Add("@DescRegimenLaboral", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescRegimenLaboral"].Value = regimenLaboralDTO.DescRegimenLaboral;

                    cmd.Parameters.Add("@CodigoRegimenLaboral", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoRegimenLaboral"].Value = regimenLaboralDTO.CodigoRegimenLaboral;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = regimenLaboralDTO.UsuarioIngresoRegistro;

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

        public string EliminarRegimenLaboral(RegimenLaboralDTO regimenLaboralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_RegimenLaboralEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@RegimenLaboralId", SqlDbType.Int);
                    cmd.Parameters["@RegimenLaboralId"].Value = regimenLaboralDTO.RegimenLaboralId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = regimenLaboralDTO.UsuarioIngresoRegistro;

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
