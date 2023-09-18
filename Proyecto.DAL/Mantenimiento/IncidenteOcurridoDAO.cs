using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class IncidenteOcurridoDAO
    {

        SqlCommand cmd = new();

        public List<IncidenteOcurridoDTO> ObtenerIncidenteOcurridos()
        {
            List<IncidenteOcurridoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_IncidenteOcurridosListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new IncidenteOcurridoDTO()
                        {
                            IncidenteOcurridoId = Convert.ToInt32(dr["IncidenteOcurridoId"]),
                            DescIncidenteOcurrido = dr["DescIncidenteOcurrido"].ToString(),
                            AspectoEvaluarIncidenteOcurrido = dr["AspectoEvaluarIncidenteOcurrido"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarIncidenteOcurrido(IncidenteOcurridoDTO incidenteOcurridoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_IncidenteOcurridosRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescIncidenteOcurrido", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescIncidenteOcurrido"].Value = incidenteOcurridoDTO.DescIncidenteOcurrido;

                    cmd.Parameters.Add("@AspectoEvaluarIncidenteOcurrido", SqlDbType.VarChar, 80);
                    cmd.Parameters["@AspectoEvaluarIncidenteOcurrido"].Value = incidenteOcurridoDTO.AspectoEvaluarIncidenteOcurrido;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = incidenteOcurridoDTO.UsuarioIngresoRegistro;

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

        public IncidenteOcurridoDTO BuscarIncidenteOcurridoID(int Codigo)
        {
            IncidenteOcurridoDTO incidenteOcurridoDTO = new IncidenteOcurridoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_IncidenteOcurridosEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IncidenteOcurridoId", SqlDbType.Int);
                    cmd.Parameters["@IncidenteOcurridoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        incidenteOcurridoDTO.IncidenteOcurridoId = Convert.ToInt32(dr["IncidenteOcurridoId"]);
                        incidenteOcurridoDTO.DescIncidenteOcurrido = dr["DescIncidenteOcurrido"].ToString();
                        incidenteOcurridoDTO.AspectoEvaluarIncidenteOcurrido = dr["AspectoEvaluarIncidenteOcurrido"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return incidenteOcurridoDTO;
        }

        public string ActualizarIncidenteOcurrido(IncidenteOcurridoDTO incidenteOcurridoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_IncidenteOcurridosActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IncidenteOcurridoId", SqlDbType.Int);
                    cmd.Parameters["@IncidenteOcurridoId"].Value = incidenteOcurridoDTO.IncidenteOcurridoId;

                    cmd.Parameters.Add("@DescIncidenteOcurrido", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescIncidenteOcurrido"].Value = incidenteOcurridoDTO.DescIncidenteOcurrido;

                    cmd.Parameters.Add("@AspectoEvaluarIncidenteOcurrido", SqlDbType.VarChar, 10);
                    cmd.Parameters["@AspectoEvaluarIncidenteOcurrido"].Value = incidenteOcurridoDTO.AspectoEvaluarIncidenteOcurrido;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = incidenteOcurridoDTO.UsuarioIngresoRegistro;

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

        public string EliminarIncidenteOcurrido(IncidenteOcurridoDTO IncidenteOcurridoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_IncidenteOcurridosEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@IncidenteOcurridoId", SqlDbType.Int);
                    cmd.Parameters["@IncidenteOcurridoId"].Value = IncidenteOcurridoDTO.IncidenteOcurridoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = IncidenteOcurridoDTO.UsuarioIngresoRegistro;

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
