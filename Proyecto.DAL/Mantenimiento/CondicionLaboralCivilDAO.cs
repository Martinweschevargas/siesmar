using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CondicionLaboralCivilDAO
    {

        SqlCommand cmd = new();

        public List<CondicionLaboralCivilDTO> ObtenerCondicionLaboralCivils()
        {
            List<CondicionLaboralCivilDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralCivilListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CondicionLaboralCivilDTO()
                        {
                            CondicionLaboralCivilId = Convert.ToInt32(dr["CondicionLaboralCivilId"]),
                            DescCondicionLaboralCivil = dr["DescCondicionLaboralCivil"].ToString(),
                            CodigoCondicionLaboralCivil = dr["CodigoCondicionLaboralCivil"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCondicionLaboralCivil(CondicionLaboralCivilDTO CondicionLaboralCivilDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralCivilRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCondicionLaboralCivil", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCondicionLaboralCivil"].Value = CondicionLaboralCivilDTO.DescCondicionLaboralCivil;    
                    
                    cmd.Parameters.Add("@CodigoCondicionLaboralCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralCivil"].Value = CondicionLaboralCivilDTO.CodigoCondicionLaboralCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CondicionLaboralCivilDTO.UsuarioIngresoRegistro;

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

        public CondicionLaboralCivilDTO BuscarCondicionLaboralCivilID(int Codigo)
        {
            CondicionLaboralCivilDTO CondicionLaboralCivilDTO = new CondicionLaboralCivilDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralCivilEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionLaboralCivilId", SqlDbType.Int);
                    cmd.Parameters["@CondicionLaboralCivilId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        CondicionLaboralCivilDTO.CondicionLaboralCivilId = Convert.ToInt32(dr["CondicionLaboralCivilId"]);
                        CondicionLaboralCivilDTO.DescCondicionLaboralCivil = dr["DescCondicionLaboralCivil"].ToString();
                        CondicionLaboralCivilDTO.CodigoCondicionLaboralCivil = dr["CodigoCondicionLaboralCivil"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return CondicionLaboralCivilDTO;
        }

        public string ActualizarCondicionLaboralCivil(CondicionLaboralCivilDTO CondicionLaboralCivilDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralCivilActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionLaboralCivilId", SqlDbType.Int);
                    cmd.Parameters["@CondicionLaboralCivilId"].Value = CondicionLaboralCivilDTO.CondicionLaboralCivilId;

                    cmd.Parameters.Add("@DescCondicionLaboralCivil", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCondicionLaboralCivil"].Value = CondicionLaboralCivilDTO.DescCondicionLaboralCivil;    
                    
                    cmd.Parameters.Add("@CodigoCondicionLaboralCivil", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicionLaboralCivil"].Value = CondicionLaboralCivilDTO.CodigoCondicionLaboralCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CondicionLaboralCivilDTO.UsuarioIngresoRegistro;

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

        public string EliminarCondicionLaboralCivil(CondicionLaboralCivilDTO CondicionLaboralCivilDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralCivilEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionLaboralCivilId", SqlDbType.Int);
                    cmd.Parameters["@CondicionLaboralCivilId"].Value = CondicionLaboralCivilDTO.CondicionLaboralCivilId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CondicionLaboralCivilDTO.UsuarioIngresoRegistro;

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
