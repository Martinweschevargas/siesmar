using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class UbicacionCIRDDAO
    {

        SqlCommand cmd = new();

        public List<UbicacionCIRDDTO> ObtenerUbicacionCIRDs()
        {
            List<UbicacionCIRDDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_UbicacionCIRDListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new UbicacionCIRDDTO()
                        {
                            UbicacionCIRDId = Convert.ToInt32(dr["UbicacionCIRDId"]),
                            DescUbicacionCIRD = dr["DescUbicacionCIRD"].ToString(),
                            CodigoUbicacionCIRD = dr["CodigoUbicacionCIRD"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarUbicacionCIRD(UbicacionCIRDDTO ubicacionCIRDDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UbicacionCIRDRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescUbicacionCIRD", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescUbicacionCIRD"].Value = ubicacionCIRDDTO.DescUbicacionCIRD;

                    cmd.Parameters.Add("@CodigoUbicacionCIRD", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUbicacionCIRD"].Value = ubicacionCIRDDTO.CodigoUbicacionCIRD;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ubicacionCIRDDTO.UsuarioIngresoRegistro;

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

        public UbicacionCIRDDTO BuscarUbicacionCIRDID(int Codigo)
        {
            UbicacionCIRDDTO ubicacionCIRDDTO = new UbicacionCIRDDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UbicacionCIRDEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UbicacionCIRDId", SqlDbType.Int);
                    cmd.Parameters["@UbicacionCIRDId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ubicacionCIRDDTO.UbicacionCIRDId = Convert.ToInt32(dr["UbicacionCIRDId"]);
                        ubicacionCIRDDTO.DescUbicacionCIRD = dr["DescUbicacionCIRD"].ToString();
                        ubicacionCIRDDTO.CodigoUbicacionCIRD = dr["CodigoUbicacionCIRD"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ubicacionCIRDDTO;
        }

        public string ActualizarUbicacionCIRD(UbicacionCIRDDTO ubicacionCIRDDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UbicacionCIRDActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UbicacionCIRDId", SqlDbType.Int);
                    cmd.Parameters["@UbicacionCIRDId"].Value = ubicacionCIRDDTO.UbicacionCIRDId;

                    cmd.Parameters.Add("@DescUbicacionCIRD", SqlDbType.VarChar, 260);
                    cmd.Parameters["@DescUbicacionCIRD"].Value = ubicacionCIRDDTO.DescUbicacionCIRD;

                    cmd.Parameters.Add("@CodigoUbicacionCIRD", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUbicacionCIRD"].Value = ubicacionCIRDDTO.CodigoUbicacionCIRD;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ubicacionCIRDDTO.UsuarioIngresoRegistro;

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

        public string EliminarUbicacionCIRD(UbicacionCIRDDTO ubicacionCIRDDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_UbicacionCIRDEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UbicacionCIRDId", SqlDbType.Int);
                    cmd.Parameters["@UbicacionCIRDId"].Value = ubicacionCIRDDTO.UbicacionCIRDId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ubicacionCIRDDTO.UsuarioIngresoRegistro;

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
