using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ClasificacionSancionDisciplinariaDAO
    {

        SqlCommand cmd = new();

        public List<ClasificacionSancionDisciplinariaDTO> ObtenerClasificacionSancionDisciplinarias()
        {
            List<ClasificacionSancionDisciplinariaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ClasificacionSancionDisciplinariaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ClasificacionSancionDisciplinariaDTO()
                        {
                            ClasificacionSancionDisciplinariaId = Convert.ToInt32(dr["ClasificacionSancionDisciplinariaId"]),
                            DescClasificacionSancionDisciplinaria = dr["DescClasificacionSancionDisciplinaria"].ToString(),
                            CodigoClasificacionSancionDisciplinaria = dr["CodigoClasificacionSancionDisciplinaria"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarClasificacionSancionDisciplinaria(ClasificacionSancionDisciplinariaDTO ClasificacionSancionDisciplinariaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionSancionDisciplinariaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescClasificacionSancionDisciplinaria", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClasificacionSancionDisciplinaria"].Value = ClasificacionSancionDisciplinariaDTO.DescClasificacionSancionDisciplinaria;

                    cmd.Parameters.Add("@CodigoClasificacionSancionDisciplinaria", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClasificacionSancionDisciplinaria"].Value = ClasificacionSancionDisciplinariaDTO.CodigoClasificacionSancionDisciplinaria;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClasificacionSancionDisciplinariaDTO.UsuarioIngresoRegistro;

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

        public ClasificacionSancionDisciplinariaDTO BuscarClasificacionSancionDisciplinariaID(int Codigo)
        {
            ClasificacionSancionDisciplinariaDTO ClasificacionSancionDisciplinariaDTO = new ClasificacionSancionDisciplinariaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionSancionDisciplinariaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionSancionDisciplinariaId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionSancionDisciplinariaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        ClasificacionSancionDisciplinariaDTO.ClasificacionSancionDisciplinariaId = Convert.ToInt32(dr["ClasificacionSancionDisciplinariaId"]);
                        ClasificacionSancionDisciplinariaDTO.DescClasificacionSancionDisciplinaria = dr["DescClasificacionSancionDisciplinaria"].ToString();
                        ClasificacionSancionDisciplinariaDTO.CodigoClasificacionSancionDisciplinaria = dr["CodigoClasificacionSancionDisciplinaria"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return ClasificacionSancionDisciplinariaDTO;
        }

        public string ActualizarClasificacionSancionDisciplinaria(ClasificacionSancionDisciplinariaDTO ClasificacionSancionDisciplinariaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionSancionDisciplinariaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionSancionDisciplinariaId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionSancionDisciplinariaId"].Value = ClasificacionSancionDisciplinariaDTO.ClasificacionSancionDisciplinariaId;

                    cmd.Parameters.Add("@DescClasificacionSancionDisciplinaria", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescClasificacionSancionDisciplinaria"].Value = ClasificacionSancionDisciplinariaDTO.DescClasificacionSancionDisciplinaria;

                    cmd.Parameters.Add("@CodigoClasificacionSancionDisciplinaria", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoClasificacionSancionDisciplinaria"].Value = ClasificacionSancionDisciplinariaDTO.CodigoClasificacionSancionDisciplinaria;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClasificacionSancionDisciplinariaDTO.UsuarioIngresoRegistro;

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

        public string EliminarClasificacionSancionDisciplinaria(ClasificacionSancionDisciplinariaDTO ClasificacionSancionDisciplinariaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ClasificacionSancionDisciplinariaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ClasificacionSancionDisciplinariaId", SqlDbType.Int);
                    cmd.Parameters["@ClasificacionSancionDisciplinariaId"].Value = ClasificacionSancionDisciplinariaDTO.ClasificacionSancionDisciplinariaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = ClasificacionSancionDisciplinariaDTO.UsuarioIngresoRegistro;

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
