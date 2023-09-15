using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class CategoriaNovedadDAO
    {

        SqlCommand cmd = new();

        public List<CategoriaNovedadDTO> ObtenerCategoriaNovedads()
        {
            List<CategoriaNovedadDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_CategoriaNovedadListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new CategoriaNovedadDTO()
                        {
                            CategoriaNovedadId = Convert.ToInt32(dr["CategoriaNovedadId"]),
                            DescCategoriaNovedad = dr["DescCategoriaNovedad"].ToString(),
                            CodigoCategoriaNovedad = dr["CodigoCategoriaNovedad"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarCategoriaNovedad(CategoriaNovedadDTO CategoriaNovedadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaNovedadRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescCategoriaNovedad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCategoriaNovedad"].Value = CategoriaNovedadDTO.DescCategoriaNovedad;

                    cmd.Parameters.Add("@CodigoCategoriaNovedad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCategoriaNovedad"].Value = CategoriaNovedadDTO.CodigoCategoriaNovedad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CategoriaNovedadDTO.UsuarioIngresoRegistro;

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

        public CategoriaNovedadDTO BuscarCategoriaNovedadID(int Codigo)
        {
            CategoriaNovedadDTO CategoriaNovedadDTO = new CategoriaNovedadDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaNovedadEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CategoriaNovedadId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaNovedadId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        CategoriaNovedadDTO.CategoriaNovedadId = Convert.ToInt32(dr["CategoriaNovedadId"]);
                        CategoriaNovedadDTO.DescCategoriaNovedad = dr["DescCategoriaNovedad"].ToString();
                        CategoriaNovedadDTO.CodigoCategoriaNovedad = dr["CodigoCategoriaNovedad"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return CategoriaNovedadDTO;
        }

        public string ActualizarCategoriaNovedad(CategoriaNovedadDTO CategoriaNovedadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaNovedadActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CategoriaNovedadId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaNovedadId"].Value = CategoriaNovedadDTO.CategoriaNovedadId;

                    cmd.Parameters.Add("@DescCategoriaNovedad", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescCategoriaNovedad"].Value = CategoriaNovedadDTO.DescCategoriaNovedad;

                    cmd.Parameters.Add("@CodigoCategoriaNovedad", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoCategoriaNovedad"].Value = CategoriaNovedadDTO.CodigoCategoriaNovedad;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CategoriaNovedadDTO.UsuarioIngresoRegistro;

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

        public string EliminarCategoriaNovedad(CategoriaNovedadDTO CategoriaNovedadDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_CategoriaNovedadEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CategoriaNovedadId", SqlDbType.Int);
                    cmd.Parameters["@CategoriaNovedadId"].Value = CategoriaNovedadDTO.CategoriaNovedadId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = CategoriaNovedadDTO.UsuarioIngresoRegistro;

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
