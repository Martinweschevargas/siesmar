using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GrupoOcupacionalDAO
    {

        SqlCommand cmd = new();

        public List<GrupoOcupacionalDTO> ObtenerGrupoOcupacionals()
        {
            List<GrupoOcupacionalDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GrupoOcupacionalListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new GrupoOcupacionalDTO()
                        {
                            GrupoOcupacionalId = Convert.ToInt32(dr["GrupoOcupacionalId"]),
                            DescGrupoOcupacional = dr["DescGrupoOcupacional"].ToString(),
                            CodigoGrupoOcupacional = dr["CodigoGrupoOcupacional"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGrupoOcupacional(GrupoOcupacionalDTO grupoOcupacionalDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoOcupacionalRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGrupoOcupacional", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescGrupoOcupacional"].Value = grupoOcupacionalDTO.DescGrupoOcupacional;

                    cmd.Parameters.Add("@CodigoGrupoOcupacional", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoGrupoOcupacional"].Value = grupoOcupacionalDTO.CodigoGrupoOcupacional;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoOcupacionalDTO.UsuarioIngresoRegistro;

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

        public GrupoOcupacionalDTO BuscarGrupoOcupacionalID(int Codigo)
        {
            GrupoOcupacionalDTO grupoOcupacionalDTO = new GrupoOcupacionalDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoOcupacionalEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoOcupacionalId", SqlDbType.Int);
                    cmd.Parameters["@GrupoOcupacionalId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        grupoOcupacionalDTO.GrupoOcupacionalId = Convert.ToInt32(dr["GrupoOcupacionalId"]);
                        grupoOcupacionalDTO.DescGrupoOcupacional = dr["DescGrupoOcupacional"].ToString();
                        grupoOcupacionalDTO.CodigoGrupoOcupacional = dr["CodigoGrupoOcupacional"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return grupoOcupacionalDTO;
        }

        public string ActualizarGrupoOcupacional(GrupoOcupacionalDTO grupoOcupacionalDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_GrupoOcupacionalActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoOcupacionalId", SqlDbType.Int);
                    cmd.Parameters["@GrupoOcupacionalId"].Value = grupoOcupacionalDTO.GrupoOcupacionalId;

                    cmd.Parameters.Add("@DescGrupoOcupacional", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGrupoOcupacional"].Value = grupoOcupacionalDTO.DescGrupoOcupacional;

                    cmd.Parameters.Add("@CodigoGrupoOcupacional", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoGrupoOcupacional"].Value = grupoOcupacionalDTO.CodigoGrupoOcupacional;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoOcupacionalDTO.UsuarioIngresoRegistro;

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

        public bool EliminarGrupoOcupacional(GrupoOcupacionalDTO grupoOcupacionalDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoOcupacionalEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoOcupacionalId", SqlDbType.Int);
                    cmd.Parameters["@GrupoOcupacionalId"].Value = grupoOcupacionalDTO.GrupoOcupacionalId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoOcupacionalDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();
                    cmd.ExecuteNonQuery();
                    eliminado = true;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return eliminado;
        }

    }
}
