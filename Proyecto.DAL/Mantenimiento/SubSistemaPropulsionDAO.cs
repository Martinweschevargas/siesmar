using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class SubSistemaPropulsionDAO
    {

        SqlCommand cmd = new();

        public List<SubSistemaPropulsionDTO> ObtenerSubSistemaPropulsions()
        {
            List<SubSistemaPropulsionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_SubSistemaPropulsionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SubSistemaPropulsionDTO()
                        {
                            SubSistemaPropulsionId = Convert.ToInt32(dr["SubSistemaPropulsionId"]),
                            CodigoSubSistemaPropulsion = dr["CodigoSubSistemaPropulsion"].ToString(),
                            DescSubSistemaPropulsion = dr["DescSubSistemaPropulsion"].ToString(),
                            DescSistemaPropulsion = dr["DescSistemaPropulsion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarSubSistemaPropulsion(SubSistemaPropulsionDTO subSistemaPropulsionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubSistemaPropulsionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoSubSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubSistemaPropulsion"].Value = subSistemaPropulsionDTO.CodigoSubSistemaPropulsion;

                    cmd.Parameters.Add("@DescSubSistemaPropulsion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSubSistemaPropulsion"].Value = subSistemaPropulsionDTO.DescSubSistemaPropulsion;

                    cmd.Parameters.Add("@CodigoSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaPropulsion"].Value = subSistemaPropulsionDTO.CodigoSistemaPropulsion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = subSistemaPropulsionDTO.UsuarioIngresoRegistro;

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

        public SubSistemaPropulsionDTO BuscarSubSistemaPropulsionID(int Codigo)
        {
            SubSistemaPropulsionDTO subSistemaPropulsionDTO = new SubSistemaPropulsionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubSistemaPropulsionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubSistemaPropulsionId", SqlDbType.Int);
                    cmd.Parameters["@SubSistemaPropulsionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        subSistemaPropulsionDTO.SubSistemaPropulsionId = Convert.ToInt32(dr["SubSistemaPropulsionId"]);
                        subSistemaPropulsionDTO.CodigoSubSistemaPropulsion = dr["CodigoSubSistemaPropulsion"].ToString();
                        subSistemaPropulsionDTO.DescSubSistemaPropulsion = dr["DescSubSistemaPropulsion"].ToString();
                        subSistemaPropulsionDTO.CodigoSistemaPropulsion = dr["CodigoSistemaPropulsion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return subSistemaPropulsionDTO;
        }

        public string ActualizarSubSistemaPropulsion(SubSistemaPropulsionDTO subSistemaPropulsionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_SubSistemaPropulsionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubSistemaPropulsionId", SqlDbType.Int);
                    cmd.Parameters["@SubSistemaPropulsionId"].Value = subSistemaPropulsionDTO.SubSistemaPropulsionId;

                    cmd.Parameters.Add("@CodigoSubSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubSistemaPropulsion"].Value = subSistemaPropulsionDTO.CodigoSubSistemaPropulsion;

                    cmd.Parameters.Add("@DescSubSistemaPropulsion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescSubSistemaPropulsion"].Value = subSistemaPropulsionDTO.DescSubSistemaPropulsion;

                    cmd.Parameters.Add("@CodigoSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSistemaPropulsion"].Value = subSistemaPropulsionDTO.CodigoSistemaPropulsion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = subSistemaPropulsionDTO.UsuarioIngresoRegistro;

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

        public string EliminarSubSistemaPropulsion(SubSistemaPropulsionDTO subSistemaPropulsionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_SubSistemaPropulsionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SubSistemaPropulsionId", SqlDbType.Int);
                    cmd.Parameters["@SubSistemaPropulsionId"].Value = subSistemaPropulsionDTO.SubSistemaPropulsionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = subSistemaPropulsionDTO.UsuarioIngresoRegistro;

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
