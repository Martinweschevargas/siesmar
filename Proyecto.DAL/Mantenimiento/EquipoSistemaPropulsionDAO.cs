using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class EquipoSistemaPropulsionDAO
    {

        SqlCommand cmd = new();

        public List<EquipoSistemaPropulsionDTO> ObtenerEquipoSistemaPropulsions()
        {
            List<EquipoSistemaPropulsionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_EquipoSistemaPropulsionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new EquipoSistemaPropulsionDTO()
                        {
                            EquipoSistemaPropulsionId = Convert.ToInt32(dr["EquipoSistemaPropulsionId"]),
                            CodigoEquipoSistemaPropulsion = dr["CodigoEquipoSistemaPropulsion"].ToString(),
                            DescEquipoSistemaPropulsion = dr["DescEquipoSistemaPropulsion"].ToString(),
                            DescSubSistemaPropulsion = dr["DescSubSistemaPropulsion"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarEquipoSistemaPropulsion(EquipoSistemaPropulsionDTO equipoSistemaPropulsionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EquipoSistemaPropulsionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoEquipoSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEquipoSistemaPropulsion"].Value = equipoSistemaPropulsionDTO.CodigoEquipoSistemaPropulsion;

                    cmd.Parameters.Add("@DescEquipoSistemaPropulsion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEquipoSistemaPropulsion"].Value = equipoSistemaPropulsionDTO.DescEquipoSistemaPropulsion;

                    cmd.Parameters.Add("@CodigoSubSistemaPropulsion", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoSubSistemaPropulsion"].Value = equipoSistemaPropulsionDTO.CodigoSubSistemaPropulsion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = equipoSistemaPropulsionDTO.UsuarioIngresoRegistro;

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

        public EquipoSistemaPropulsionDTO BuscarEquipoSistemaPropulsionID(int Codigo)
        {
            EquipoSistemaPropulsionDTO equipoSistemaPropulsionDTO = new EquipoSistemaPropulsionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EquipoSistemaPropulsionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EquipoSistemaPropulsionId", SqlDbType.Int);
                    cmd.Parameters["@EquipoSistemaPropulsionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        equipoSistemaPropulsionDTO.EquipoSistemaPropulsionId = Convert.ToInt32(dr["EquipoSistemaPropulsionId"]);
                        equipoSistemaPropulsionDTO.DescEquipoSistemaPropulsion = dr["DescEquipoSistemaPropulsion"].ToString();
                        equipoSistemaPropulsionDTO.CodigoSubSistemaPropulsion = dr["CodigoSubSistemaPropulsion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return equipoSistemaPropulsionDTO;
        }

        public string ActualizarEquipoSistemaPropulsion(EquipoSistemaPropulsionDTO equipoSistemaPropulsionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_EquipoSistemaPropulsionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EquipoSistemaPropulsionId", SqlDbType.Int);
                    cmd.Parameters["@EquipoSistemaPropulsionId"].Value = equipoSistemaPropulsionDTO.EquipoSistemaPropulsionId;

                    cmd.Parameters.Add("@CodigoEquipoSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoEquipoSistemaPropulsion"].Value = equipoSistemaPropulsionDTO.CodigoEquipoSistemaPropulsion;

                    cmd.Parameters.Add("@DescEquipoSistemaPropulsion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescEquipoSistemaPropulsion"].Value = equipoSistemaPropulsionDTO.DescEquipoSistemaPropulsion;

                    cmd.Parameters.Add("@CodigoSubSistemaPropulsion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoSubSistemaPropulsion"].Value = equipoSistemaPropulsionDTO.CodigoSubSistemaPropulsion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = equipoSistemaPropulsionDTO.UsuarioIngresoRegistro;

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

        public string EliminarEquipoSistemaPropulsion(EquipoSistemaPropulsionDTO equipoSistemaPropulsionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_EquipoSistemaPropulsionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@EquipoSistemaPropulsionId", SqlDbType.Int);
                    cmd.Parameters["@EquipoSistemaPropulsionId"].Value = equipoSistemaPropulsionDTO.EquipoSistemaPropulsionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = equipoSistemaPropulsionDTO.UsuarioIngresoRegistro;

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
