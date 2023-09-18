using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class DocenteCategoriaDAO
    {

        SqlCommand cmd = new();

        public List<DocenteCategoriaDTO> ObtenerDocenteCategorias()
        {
            List<DocenteCategoriaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_DocenteCategoriaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new DocenteCategoriaDTO()
                        {
                            DocenteCategoriaId = Convert.ToInt32(dr["DocenteCategoriaId"]),
                            DescDocenteCategoria = dr["DescDocenteCategoria"].ToString(),
                            CodigoDocenteCategoria = dr["CodigoDocenteCategoria"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarDocenteCategoria(DocenteCategoriaDTO DocenteCategoriaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DocenteCategoriaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescDocenteCategoria", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescDocenteCategoria"].Value = DocenteCategoriaDTO.DescDocenteCategoria;

                    cmd.Parameters.Add("@CodigoDocenteCategoria", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDocenteCategoria"].Value = DocenteCategoriaDTO.CodigoDocenteCategoria;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DocenteCategoriaDTO.UsuarioIngresoRegistro;

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

        public DocenteCategoriaDTO BuscarDocenteCategoriaID(int Codigo)
        {
            DocenteCategoriaDTO DocenteCategoriaDTO = new DocenteCategoriaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DocenteCategoriaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteCategoriaId", SqlDbType.Int);
                    cmd.Parameters["@DocenteCategoriaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        DocenteCategoriaDTO.DocenteCategoriaId = Convert.ToInt32(dr["DocenteCategoriaId"]);
                        DocenteCategoriaDTO.DescDocenteCategoria = dr["DescDocenteCategoria"].ToString();
                        DocenteCategoriaDTO.CodigoDocenteCategoria = dr["CodigoDocenteCategoria"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return DocenteCategoriaDTO;
        }

        public string ActualizarDocenteCategoria(DocenteCategoriaDTO DocenteCategoriaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DocenteCategoriaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteCategoriaId", SqlDbType.Int);
                    cmd.Parameters["@DocenteCategoriaId"].Value = DocenteCategoriaDTO.DocenteCategoriaId;

                    cmd.Parameters.Add("@DescDocenteCategoria", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescDocenteCategoria"].Value = DocenteCategoriaDTO.DescDocenteCategoria;

                    cmd.Parameters.Add("@CodigoDocenteCategoria", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoDocenteCategoria"].Value = DocenteCategoriaDTO.CodigoDocenteCategoria;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DocenteCategoriaDTO.UsuarioIngresoRegistro;

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

        public string EliminarDocenteCategoria(DocenteCategoriaDTO DocenteCategoriaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_DocenteCategoriaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DocenteCategoriaId", SqlDbType.Int);
                    cmd.Parameters["@DocenteCategoriaId"].Value = DocenteCategoriaDTO.DocenteCategoriaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = DocenteCategoriaDTO.UsuarioIngresoRegistro;

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
