using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CondicionAlistamientoLogisticoDAO
    {

        SqlCommand cmd = new();

        public List<CondicionAlistamientoLogisticoDTO> ObtenerCondicionAlistamientoLogisticos()
        {
            List<CondicionAlistamientoLogisticoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CondicionAlistamientoLogisticoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CondicionAlistamientoLogisticoDTO()
                        {
                            CondicionAlistamientoLogisticoId = Convert.ToInt32(dr["CondicionAlistamientoLogisticoId"]),
                            DescCondicionAlistamientoLogistico = dr["DescCondicionAlistamientoLogistico"].ToString(),
                            CodigoCondicionAlistamientoLogistico = dr["CodigoCondicionAlistamientoLogistico"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCondicionAlistamientoLogistico(CondicionAlistamientoLogisticoDTO condicionAlistamientoLogisticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionAlistamientoLogisticoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCondicionAlistamientoLogistico", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescCondicionAlistamientoLogistico"].Value = condicionAlistamientoLogisticoDTO.DescCondicionAlistamientoLogistico;

                    cmd.Parameters.Add("@CodigoCondicionAlistamientoLogistico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCondicionAlistamientoLogistico"].Value = condicionAlistamientoLogisticoDTO.CodigoCondicionAlistamientoLogistico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionAlistamientoLogisticoDTO.UsuarioIngresoRegistro;

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

        public CondicionAlistamientoLogisticoDTO BuscarCondicionAlistamientoLogisticoID(int Codigo)
        {
            CondicionAlistamientoLogisticoDTO condicionAlistamientoLogisticoDTO = new CondicionAlistamientoLogisticoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionAlistamientoLogisticoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionAlistamientoLogisticoId", SqlDbType.Int);
                    cmd.Parameters["@CondicionAlistamientoLogisticoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        condicionAlistamientoLogisticoDTO.CondicionAlistamientoLogisticoId = Convert.ToInt32(dr["CondicionAlistamientoLogisticoId"]);
                        condicionAlistamientoLogisticoDTO.DescCondicionAlistamientoLogistico = dr["DescCondicionAlistamientoLogistico"].ToString();
                        condicionAlistamientoLogisticoDTO.CodigoCondicionAlistamientoLogistico = dr["CodigoCondicionAlistamientoLogistico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return condicionAlistamientoLogisticoDTO;
        }

        public string ActualizarCondicionAlistamientoLogistico(CondicionAlistamientoLogisticoDTO condicionAlistamientoLogisticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionAlistamientoLogisticoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionAlistamientoLogisticoId", SqlDbType.Int);
                    cmd.Parameters["@CondicionAlistamientoLogisticoId"].Value = condicionAlistamientoLogisticoDTO.CondicionAlistamientoLogisticoId;

                    cmd.Parameters.Add("@DescCondicionAlistamientoLogistico", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescCondicionAlistamientoLogistico"].Value = condicionAlistamientoLogisticoDTO.DescCondicionAlistamientoLogistico;

                    cmd.Parameters.Add("@CodigoCondicionAlistamientoLogistico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCondicionAlistamientoLogistico"].Value = condicionAlistamientoLogisticoDTO.CodigoCondicionAlistamientoLogistico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionAlistamientoLogisticoDTO.UsuarioIngresoRegistro;

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

        public string EliminarCondicionAlistamientoLogistico(CondicionAlistamientoLogisticoDTO condicionAlistamientoLogisticoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionAlistamientoLogisticoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionAlistamientoLogisticoId", SqlDbType.Int);
                    cmd.Parameters["@CondicionAlistamientoLogisticoId"].Value = condicionAlistamientoLogisticoDTO.CondicionAlistamientoLogisticoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionAlistamientoLogisticoDTO.UsuarioIngresoRegistro;

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
