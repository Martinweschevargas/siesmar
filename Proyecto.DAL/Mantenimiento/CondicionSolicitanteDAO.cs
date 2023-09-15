using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CondicionSolicitanteDAO
    {

        SqlCommand cmd = new();

        public List<CondicionSolicitanteDTO> ObtenerCondicionSolicitantes()
        {
            List<CondicionSolicitanteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CondicionSolicitanteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CondicionSolicitanteDTO()
                        {
                            CondicionSolicitanteId = Convert.ToInt32(dr["CondicionSolicitanteId"]),
                            DescCondicionSolicitante = dr["DescCondicionSolicitante"].ToString(),
                            CodigoCondicionSolicitante = dr["CodigoCondicionSolicitante"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCondicionSolicitante(CondicionSolicitanteDTO CondicionSolicitanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionSolicitanteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCondicionSolicitante", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescCondicionSolicitante"].Value = CondicionSolicitanteDTO.DescCondicionSolicitante;

                    cmd.Parameters.Add("@CodigoCondicionSolicitante", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCondicionSolicitante"].Value = CondicionSolicitanteDTO.CodigoCondicionSolicitante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CondicionSolicitanteDTO.UsuarioIngresoRegistro;

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

        public CondicionSolicitanteDTO BuscarCondicionSolicitanteID(int Codigo)
        {
            CondicionSolicitanteDTO CondicionSolicitanteDTO = new CondicionSolicitanteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionSolicitanteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionSolicitanteId", SqlDbType.Int);
                    cmd.Parameters["@CondicionSolicitanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        CondicionSolicitanteDTO.CondicionSolicitanteId = Convert.ToInt32(dr["CondicionSolicitanteId"]);
                        CondicionSolicitanteDTO.DescCondicionSolicitante = dr["DescCondicionSolicitante"].ToString();
                        CondicionSolicitanteDTO.CodigoCondicionSolicitante = dr["CodigoCondicionSolicitante"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return CondicionSolicitanteDTO;
        }

        public string ActualizarCondicionSolicitante(CondicionSolicitanteDTO CondicionSolicitanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionSolicitanteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionSolicitanteId", SqlDbType.Int);
                    cmd.Parameters["@CondicionSolicitanteId"].Value = CondicionSolicitanteDTO.CondicionSolicitanteId;

                    cmd.Parameters.Add("@DescCondicionSolicitante", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescCondicionSolicitante"].Value = CondicionSolicitanteDTO.DescCondicionSolicitante;

                    cmd.Parameters.Add("@CodigoCondicionSolicitante", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCondicionSolicitante"].Value = CondicionSolicitanteDTO.CodigoCondicionSolicitante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CondicionSolicitanteDTO.UsuarioIngresoRegistro;

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

        public string EliminarCondicionSolicitante(CondicionSolicitanteDTO CondicionSolicitanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionSolicitanteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionSolicitanteId", SqlDbType.Int);
                    cmd.Parameters["@CondicionSolicitanteId"].Value = CondicionSolicitanteDTO.CondicionSolicitanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CondicionSolicitanteDTO.UsuarioIngresoRegistro;

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
