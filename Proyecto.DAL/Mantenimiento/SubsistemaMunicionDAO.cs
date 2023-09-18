using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SubsistemaMunicionDAO
    {

        SqlCommand cmd = new();

        public List<SubsistemaMunicionDTO> ObtenerSubsistemaMunicions()
        {
            List<SubsistemaMunicionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SubsistemaMunicionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SubsistemaMunicionDTO()
                        {
                            SubsistemaMunicionId = Convert.ToInt32(dr["SubsistemaMunicionId"]),
                            DescSubsistemaMunicion = dr["DescSubsistemaMunicion"].ToString(),
                            DescSistemaMunicion = dr["DescSistemaMunicion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSubsistemaMunicion(SubsistemaMunicionDTO SubsistemaMunicionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubsistemaMunicionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSubsistemaMunicion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSubsistemaMunicion"].Value = SubsistemaMunicionDTO.DescSubsistemaMunicion;

                    cmd.Parameters.Add("@SistemaMunicionId", SqlDbType.Int);
                    cmd.Parameters["@SistemaMunicionId"].Value = SubsistemaMunicionDTO.SistemaMunicionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SubsistemaMunicionDTO.UsuarioIngresoRegistro;

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

        public SubsistemaMunicionDTO BuscarSubsistemaMunicionID(int Codigo)
        {
            SubsistemaMunicionDTO SubsistemaMunicionDTO = new SubsistemaMunicionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubsistemaMunicionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubsistemaMunicionId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaMunicionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        SubsistemaMunicionDTO.SubsistemaMunicionId = Convert.ToInt32(dr["SubsistemaMunicionId"]);
                        SubsistemaMunicionDTO.DescSubsistemaMunicion = dr["DescSubsistemaMunicion"].ToString();
                        SubsistemaMunicionDTO.SistemaMunicionId = Convert.ToInt32(dr["SistemaMunicionId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return SubsistemaMunicionDTO;
        }

        public string ActualizarSubsistemaMunicion(SubsistemaMunicionDTO SubsistemaMunicionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_SubsistemaMunicionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubsistemaMunicionId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaMunicionId"].Value = SubsistemaMunicionDTO.SubsistemaMunicionId;

                    cmd.Parameters.Add("@DescSubsistemaMunicion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSubsistemaMunicion"].Value = SubsistemaMunicionDTO.DescSubsistemaMunicion;

                    cmd.Parameters.Add("@SistemaMunicionId", SqlDbType.Int);
                    cmd.Parameters["@SistemaMunicionId"].Value = SubsistemaMunicionDTO.SistemaMunicionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SubsistemaMunicionDTO.UsuarioIngresoRegistro;

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

        public string EliminarSubsistemaMunicion(SubsistemaMunicionDTO SubsistemaMunicionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubsistemaMunicionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubsistemaMunicionId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaMunicionId"].Value = SubsistemaMunicionDTO.SubsistemaMunicionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SubsistemaMunicionDTO.UsuarioIngresoRegistro;

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
