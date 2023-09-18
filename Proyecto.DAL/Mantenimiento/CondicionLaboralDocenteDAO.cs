using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CondicionLaboralDocenteDAO
    {

        SqlCommand cmd = new();

        public List<CondicionLaboralDocenteDTO> ObtenerCondicionLaboralDocentes()
        {
            List<CondicionLaboralDocenteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralDocenteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CondicionLaboralDocenteDTO()
                        {
                            CondicionLaboralDocenteId = Convert.ToInt32(dr["CondicionLaboralDocenteId"]),
                            DescCondicionLaboralDocente = dr["DescCondicionLaboralDocente"].ToString(),
                            CodigoCondicionLaboralDocente = dr["CodigoCondicionLaboralDocente"].ToString()

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCondicionLaboralDocente(CondicionLaboralDocenteDTO condicionLaboralDocenteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralDocenteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCondicionLaboralDocente", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCondicionLaboralDocente"].Value = condicionLaboralDocenteDTO.DescCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCondicionLaboralDocente"].Value = condicionLaboralDocenteDTO.CodigoCondicionLaboralDocente;
                    
                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionLaboralDocenteDTO.UsuarioIngresoRegistro;
                    
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

        public CondicionLaboralDocenteDTO BuscarCondicionLaboralDocenteID(int Codigo)
        {
            CondicionLaboralDocenteDTO condicionLaboralDocenteDTO = new CondicionLaboralDocenteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralDocenteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionLaboralDocenteId", SqlDbType.Int);
                    cmd.Parameters["@CondicionLaboralDocenteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        condicionLaboralDocenteDTO.CondicionLaboralDocenteId = Convert.ToInt32(dr["CondicionLaboralDocenteId"]);
                        condicionLaboralDocenteDTO.DescCondicionLaboralDocente = dr["DescCondicionLaboralDocente"].ToString();
                        condicionLaboralDocenteDTO.CodigoCondicionLaboralDocente = dr["CodigoCondicionLaboralDocente"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return condicionLaboralDocenteDTO;
        }

        public string ActualizarCondicionLaboralDocente(CondicionLaboralDocenteDTO condicionLaboralDocenteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralDocenteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionLaboralDocenteId", SqlDbType.Int);
                    cmd.Parameters["@CondicionLaboralDocenteId"].Value = condicionLaboralDocenteDTO.CondicionLaboralDocenteId;

                    cmd.Parameters.Add("@DescCondicionLaboralDocente", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCondicionLaboralDocente"].Value = condicionLaboralDocenteDTO.DescCondicionLaboralDocente;

                    cmd.Parameters.Add("@CodigoCondicionLaboralDocente", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCondicionLaboralDocente"].Value = condicionLaboralDocenteDTO.CodigoCondicionLaboralDocente;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionLaboralDocenteDTO.UsuarioIngresoRegistro;

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

        public string EliminarCondicionLaboralDocente(CondicionLaboralDocenteDTO condicionLaboralDocenteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CondicionLaboralDocenteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CondicionLaboralDocenteId", SqlDbType.Int);
                    cmd.Parameters["@CondicionLaboralDocenteId"].Value = condicionLaboralDocenteDTO.CondicionLaboralDocenteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = condicionLaboralDocenteDTO.UsuarioIngresoRegistro;

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
