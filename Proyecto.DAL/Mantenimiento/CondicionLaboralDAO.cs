using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CondicionLaboralDAO
    {

        SqlCommand cmd = new();

        public List<CondicionLaboralDTO> ObtenerCondicionLaborals()
        {
            List<CondicionLaboralDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CondicionLaboralDTO()
                        {
                            CondicionLaboralId = Convert.ToInt32(dr["CondicionLaboralId"]),
                            DescCondicionLaboral = dr["DescCondicionLaboral"].ToString(),
                            CodigoCondicionLaboral = dr["CodigoCondicionLaboral"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCondicionLaboral(CondicionLaboralDTO condicionLaboralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCondicionLaboral", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescCondicionLaboral"].Value = condicionLaboralDTO.DescCondicionLaboral;

                    cmd.Parameters.Add("@CodigoCondicionLaboral", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCondicionLaboral"].Value = condicionLaboralDTO.CodigoCondicionLaboral;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionLaboralDTO.UsuarioIngresoRegistro;

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

        public CondicionLaboralDTO BuscarCondicionLaboralID(int Codigo)
        {
            CondicionLaboralDTO condicionLaboralDTO = new CondicionLaboralDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionLaboralId", SqlDbType.Int);
                    cmd.Parameters["@CondicionLaboralId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        condicionLaboralDTO.CondicionLaboralId = Convert.ToInt32(dr["CondicionLaboralId"]);
                        condicionLaboralDTO.DescCondicionLaboral = dr["DescCondicionLaboral"].ToString();
                        condicionLaboralDTO.CodigoCondicionLaboral = dr["CodigoCondicionLaboral"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return condicionLaboralDTO;
        }

        public string ActualizarCondicionLaboral(CondicionLaboralDTO condicionLaboralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionLaboralId", SqlDbType.Int);
                    cmd.Parameters["@CondicionLaboralId"].Value = condicionLaboralDTO.CondicionLaboralId;

                    cmd.Parameters.Add("@DescCondicionLaboral", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescCondicionLaboral"].Value = condicionLaboralDTO.DescCondicionLaboral;

                    cmd.Parameters.Add("@CodigoCondicionLaboral", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCondicionLaboral"].Value = condicionLaboralDTO.CodigoCondicionLaboral;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionLaboralDTO.UsuarioIngresoRegistro;

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

        public string EliminarCondicionLaboral(CondicionLaboralDTO condicionLaboralDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionLaboralId", SqlDbType.Int);
                    cmd.Parameters["@CondicionLaboralId"].Value = condicionLaboralDTO.CondicionLaboralId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionLaboralDTO.UsuarioIngresoRegistro;

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
