using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SubsistemaCombustibleLubricanteDAO
    {

        SqlCommand cmd = new();

        public List<SubsistemaCombustibleLubricanteDTO> ObtenerSubsistemaCombustibleLubricantes()
        {
            List<SubsistemaCombustibleLubricanteDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SubsistemaCombustibleLubricanteListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SubsistemaCombustibleLubricanteDTO()
                        {
                            SubsistemaCombustibleLubricanteId = Convert.ToInt32(dr["SubsistemaCombustibleLubricanteId"]),
                            CodigoSubsistemaCombustibleLubricante = dr["CodigoSubsistemaCombustibleLubricante"].ToString(),
                            DescSubsistemaCombustibleLubricante = dr["DescSubsistemaCombustibleLubricante"].ToString(),
                            DescSistemaCombustibleLubricante = dr["DescSistemaCombustibleLubricante"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSubsistemaCombustibleLubricante(SubsistemaCombustibleLubricanteDTO SubsistemaCombustibleLubricanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubsistemaCombustibleLubricanteRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescSubsistemaCombustibleLubricante", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSubsistemaCombustibleLubricante"].Value = SubsistemaCombustibleLubricanteDTO.DescSubsistemaCombustibleLubricante;

                    cmd.Parameters.Add("@CodigoSubsistemaCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubsistemaCombustibleLubricante"].Value = SubsistemaCombustibleLubricanteDTO.CodigoSubsistemaCombustibleLubricante;

                    cmd.Parameters.Add("@CodigoSistemaCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaCombustibleLubricante"].Value = SubsistemaCombustibleLubricanteDTO.CodigoSistemaCombustibleLubricante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SubsistemaCombustibleLubricanteDTO.UsuarioIngresoRegistro;

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

        public SubsistemaCombustibleLubricanteDTO BuscarSubsistemaCombustibleLubricanteID(int Codigo)
        {
            SubsistemaCombustibleLubricanteDTO SubsistemaCombustibleLubricanteDTO = new SubsistemaCombustibleLubricanteDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubsistemaCombustibleLubricanteEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubsistemaCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaCombustibleLubricanteId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        SubsistemaCombustibleLubricanteDTO.SubsistemaCombustibleLubricanteId = Convert.ToInt32(dr["SubsistemaCombustibleLubricanteId"]);
                        SubsistemaCombustibleLubricanteDTO.CodigoSubsistemaCombustibleLubricante = dr["CodigoSubsistemaCombustibleLubricante"].ToString();
                        SubsistemaCombustibleLubricanteDTO.DescSubsistemaCombustibleLubricante = dr["DescSubsistemaCombustibleLubricante"].ToString();
                        SubsistemaCombustibleLubricanteDTO.CodigoSistemaCombustibleLubricante = dr["CodigoSistemaCombustibleLubricante"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return SubsistemaCombustibleLubricanteDTO;
        }

        public string ActualizarSubsistemaCombustibleLubricante(SubsistemaCombustibleLubricanteDTO SubsistemaCombustibleLubricanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_SubsistemaCombustibleLubricanteActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubsistemaCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaCombustibleLubricanteId"].Value = SubsistemaCombustibleLubricanteDTO.SubsistemaCombustibleLubricanteId;

                    cmd.Parameters.Add("@DescSubsistemaCombustibleLubricante", SqlDbType.VarChar, 100);
                    cmd.Parameters["@DescSubsistemaCombustibleLubricante"].Value = SubsistemaCombustibleLubricanteDTO.DescSubsistemaCombustibleLubricante;

                    cmd.Parameters.Add("@CodigoSubsistemaCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubsistemaCombustibleLubricante"].Value = SubsistemaCombustibleLubricanteDTO.CodigoSubsistemaCombustibleLubricante;

                    cmd.Parameters.Add("@CodigoSistemaCombustibleLubricante", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaCombustibleLubricante"].Value = SubsistemaCombustibleLubricanteDTO.CodigoSistemaCombustibleLubricante;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SubsistemaCombustibleLubricanteDTO.UsuarioIngresoRegistro;

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

        public string EliminarSubsistemaCombustibleLubricante(SubsistemaCombustibleLubricanteDTO SubsistemaCombustibleLubricanteDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubsistemaCombustibleLubricanteEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubsistemaCombustibleLubricanteId", SqlDbType.Int);
                    cmd.Parameters["@SubsistemaCombustibleLubricanteId"].Value = SubsistemaCombustibleLubricanteDTO.SubsistemaCombustibleLubricanteId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = SubsistemaCombustibleLubricanteDTO.UsuarioIngresoRegistro;

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
