using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class FaseInversionDAO
    {

        SqlCommand cmd = new();

        public List<FaseInversionDTO> ObtenerFaseInversions()
        {
            List<FaseInversionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_FaseInversionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new FaseInversionDTO()
                        {
                            FaseInversionId = Convert.ToInt32(dr["FaseInversionId"]),
                            DescFaseInversion = dr["DescFaseInversion"].ToString(),
                            CodigoFaseInversion = dr["CodigoFaseInversion"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarFaseInversion(FaseInversionDTO faseInversionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FaseInversionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescFaseInversion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescFaseInversion"].Value = faseInversionDTO.DescFaseInversion;

                    cmd.Parameters.Add("@CodigoFaseInversion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFaseInversion"].Value = faseInversionDTO.CodigoFaseInversion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = faseInversionDTO.UsuarioIngresoRegistro;

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

        public FaseInversionDTO BuscarFaseInversionID(int Codigo)
        {
            FaseInversionDTO faseInversionDTO = new FaseInversionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FaseInversionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FaseInversionId", SqlDbType.Int);
                    cmd.Parameters["@FaseInversionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        faseInversionDTO.FaseInversionId = Convert.ToInt32(dr["FaseInversionId"]);
                        faseInversionDTO.DescFaseInversion = dr["DescFaseInversion"].ToString();
                        faseInversionDTO.CodigoFaseInversion = dr["CodigoFaseInversion"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return faseInversionDTO;
        }

        public string ActualizarFaseInversion(FaseInversionDTO faseInversionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FaseInversionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FaseInversionId", SqlDbType.Int);
                    cmd.Parameters["@FaseInversionId"].Value = faseInversionDTO.FaseInversionId;

                    cmd.Parameters.Add("@DescFaseInversion", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescFaseInversion"].Value = faseInversionDTO.DescFaseInversion;

                    cmd.Parameters.Add("@CodigoFaseInversion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoFaseInversion"].Value = faseInversionDTO.CodigoFaseInversion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = faseInversionDTO.UsuarioIngresoRegistro;

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

        public string EliminarFaseInversion(FaseInversionDTO faseInversionDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_FaseInversionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@FaseInversionId", SqlDbType.Int);
                    cmd.Parameters["@FaseInversionId"].Value = faseInversionDTO.FaseInversionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = faseInversionDTO.UsuarioIngresoRegistro;

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
