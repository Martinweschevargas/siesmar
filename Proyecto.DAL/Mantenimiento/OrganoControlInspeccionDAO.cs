using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class OrganoControlInspeccionDAO
    {

        SqlCommand cmd = new();

        public List<OrganoControlInspeccionDTO> ObtenerOrganoControlInspeccions()
        {
            List<OrganoControlInspeccionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_OrganoControlInspeccionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new OrganoControlInspeccionDTO()
                        {
                            OrganoControlInspeccionId = Convert.ToInt32(dr["OrganoControlInspeccionId"]),
                            DescOrganoControlInspeccion = dr["DescOrganoControlInspeccion"].ToString(),
                            CodigoOrganoControlInspeccion = dr["CodigoOrganoControlInspeccion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarOrganoControlInspeccion(OrganoControlInspeccionDTO organoControlInspeccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OrganoControlInspeccionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescOrganoControlInspeccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescOrganoControlInspeccion"].Value = organoControlInspeccionDTO.DescOrganoControlInspeccion;

                    cmd.Parameters.Add("@CodigoOrganoControlInspeccion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoOrganoControlInspeccion"].Value = organoControlInspeccionDTO.CodigoOrganoControlInspeccion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = organoControlInspeccionDTO.UsuarioIngresoRegistro;

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

        public OrganoControlInspeccionDTO BuscarOrganoControlInspeccionID(int Codigo)
        {
            OrganoControlInspeccionDTO organoControlInspeccionDTO = new OrganoControlInspeccionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OrganoControlInspeccionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OrganoControlInspeccionId", SqlDbType.Int);
                    cmd.Parameters["@OrganoControlInspeccionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        organoControlInspeccionDTO.OrganoControlInspeccionId = Convert.ToInt32(dr["OrganoControlInspeccionId"]);
                        organoControlInspeccionDTO.DescOrganoControlInspeccion = dr["DescOrganoControlInspeccion"].ToString();
                        organoControlInspeccionDTO.CodigoOrganoControlInspeccion = dr["CodigoOrganoControlInspeccion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return organoControlInspeccionDTO;
        }

        public string ActualizarOrganoControlInspeccion(OrganoControlInspeccionDTO organoControlInspeccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OrganoControlInspeccionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OrganoControlInspeccionId", SqlDbType.Int);
                    cmd.Parameters["@OrganoControlInspeccionId"].Value = organoControlInspeccionDTO.OrganoControlInspeccionId;

                    cmd.Parameters.Add("@DescOrganoControlInspeccion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescOrganoControlInspeccion"].Value = organoControlInspeccionDTO.DescOrganoControlInspeccion;

                    cmd.Parameters.Add("@CodigoOrganoControlInspeccion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoOrganoControlInspeccion"].Value = organoControlInspeccionDTO.CodigoOrganoControlInspeccion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = organoControlInspeccionDTO.UsuarioIngresoRegistro;

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

        public string EliminarOrganoControlInspeccion(OrganoControlInspeccionDTO organoControlInspeccionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_OrganoControlInspeccionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@OrganoControlInspeccionId", SqlDbType.Int);
                    cmd.Parameters["@OrganoControlInspeccionId"].Value = organoControlInspeccionDTO.OrganoControlInspeccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = organoControlInspeccionDTO.UsuarioIngresoRegistro;

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
