using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GrupoRemunerativoDAO
    {

        SqlCommand cmd = new();

        public List<GrupoRemunerativoDTO> ObtenerGrupoRemunerativos()
        {
            List<GrupoRemunerativoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GrupoRemunerativoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new GrupoRemunerativoDTO()
                        {
                            GrupoRemunerativoId = Convert.ToInt32(dr["GrupoRemunerativoId"]),
                            DescGrupoRemunerativo = dr["DescGrupoRemunerativo"].ToString(),
                            CodigoGrupoRemunerativo = dr["CodigoGrupoRemunerativo"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGrupoRemunerativo(GrupoRemunerativoDTO grupoRemunerativoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoRemunerativoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGrupoRemunerativo", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescGrupoRemunerativo"].Value = grupoRemunerativoDTO.DescGrupoRemunerativo;

                    cmd.Parameters.Add("@CodigoGrupoRemunerativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoRemunerativo"].Value = grupoRemunerativoDTO.CodigoGrupoRemunerativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoRemunerativoDTO.UsuarioIngresoRegistro;

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

        public GrupoRemunerativoDTO BuscarGrupoRemunerativoID(int Codigo)
        {
            GrupoRemunerativoDTO grupoRemunerativoDTO = new GrupoRemunerativoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoRemunerativoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoRemunerativoId", SqlDbType.Int);
                    cmd.Parameters["@GrupoRemunerativoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        grupoRemunerativoDTO.GrupoRemunerativoId = Convert.ToInt32(dr["GrupoRemunerativoId"]);
                        grupoRemunerativoDTO.DescGrupoRemunerativo = dr["DescGrupoRemunerativo"].ToString();
                        grupoRemunerativoDTO.CodigoGrupoRemunerativo = dr["CodigoGrupoRemunerativo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return grupoRemunerativoDTO;
        }

        public string ActualizarGrupoRemunerativo(GrupoRemunerativoDTO grupoRemunerativoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoRemunerativoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoRemunerativoId", SqlDbType.Int);
                    cmd.Parameters["@GrupoRemunerativoId"].Value = grupoRemunerativoDTO.GrupoRemunerativoId;

                    cmd.Parameters.Add("@DescGrupoRemunerativo", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGrupoRemunerativo"].Value = grupoRemunerativoDTO.DescGrupoRemunerativo;


                    cmd.Parameters.Add("@CodigoGrupoRemunerativo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoRemunerativo"].Value = grupoRemunerativoDTO.CodigoGrupoRemunerativo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoRemunerativoDTO.UsuarioIngresoRegistro;

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

        public string EliminarGrupoRemunerativo(GrupoRemunerativoDTO grupoRemunerativoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoRemunerativoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoRemunerativoId", SqlDbType.Int);
                    cmd.Parameters["@GrupoRemunerativoId"].Value = grupoRemunerativoDTO.GrupoRemunerativoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoRemunerativoDTO.UsuarioIngresoRegistro;

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
