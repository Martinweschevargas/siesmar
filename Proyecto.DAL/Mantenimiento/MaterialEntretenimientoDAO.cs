using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class MaterialEntretenimientoDAO
    {

        SqlCommand cmd = new();

        public List<MaterialEntretenimientoDTO> ObtenerMaterialEntretenimientos()
        {
            List<MaterialEntretenimientoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_MaterialEntretenimientoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MaterialEntretenimientoDTO()
                        {
                            MaterialEntretenimientoId = Convert.ToInt32(dr["MaterialEntretenimientoId"]),
                            DescMaterialEntretenimiento = dr["DescMaterialEntretenimiento"].ToString(),
                            CodigoMaterialEntretenimiento = dr["CodigoMaterialEntretenimiento"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarMaterialEntretenimiento(MaterialEntretenimientoDTO MaterialEntretenimientoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialEntretenimientoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescMaterialEntretenimiento", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescMaterialEntretenimiento"].Value = MaterialEntretenimientoDTO.DescMaterialEntretenimiento;

                    cmd.Parameters.Add("@CodigoMaterialEntretenimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialEntretenimiento"].Value = MaterialEntretenimientoDTO.CodigoMaterialEntretenimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MaterialEntretenimientoDTO.UsuarioIngresoRegistro;

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

        public MaterialEntretenimientoDTO BuscarMaterialEntretenimientoID(int Codigo)
        {
            MaterialEntretenimientoDTO MaterialEntretenimientoDTO = new MaterialEntretenimientoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialEntretenimientoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialEntretenimientoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialEntretenimientoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        MaterialEntretenimientoDTO.MaterialEntretenimientoId = Convert.ToInt32(dr["MaterialEntretenimientoId"]);
                        MaterialEntretenimientoDTO.DescMaterialEntretenimiento = dr["DescMaterialEntretenimiento"].ToString();
                        MaterialEntretenimientoDTO.CodigoMaterialEntretenimiento = dr["CodigoMaterialEntretenimiento"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return MaterialEntretenimientoDTO;
        }

        public string ActualizarMaterialEntretenimiento(MaterialEntretenimientoDTO MaterialEntretenimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialEntretenimientoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialEntretenimientoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialEntretenimientoId"].Value = MaterialEntretenimientoDTO.MaterialEntretenimientoId;

                    cmd.Parameters.Add("@DescMaterialEntretenimiento", SqlDbType.VarChar, 70);
                    cmd.Parameters["@DescMaterialEntretenimiento"].Value = MaterialEntretenimientoDTO.DescMaterialEntretenimiento;

                    cmd.Parameters.Add("@CodigoMaterialEntretenimiento", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoMaterialEntretenimiento"].Value = MaterialEntretenimientoDTO.CodigoMaterialEntretenimiento;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MaterialEntretenimientoDTO.UsuarioIngresoRegistro;

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

        public string EliminarMaterialEntretenimiento(MaterialEntretenimientoDTO MaterialEntretenimientoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_MaterialEntretenimientoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MaterialEntretenimientoId", SqlDbType.Int);
                    cmd.Parameters["@MaterialEntretenimientoId"].Value = MaterialEntretenimientoDTO.MaterialEntretenimientoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = MaterialEntretenimientoDTO.UsuarioIngresoRegistro;

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
