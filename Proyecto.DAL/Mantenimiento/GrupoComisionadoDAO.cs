using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GrupoComisionadoDAO
    {

        SqlCommand cmd = new();

        public List<GrupoComisionadoDTO> ObtenerGrupoComisionados()
        {
            List<GrupoComisionadoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GrupoComisionadoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new GrupoComisionadoDTO()
                        {
                            GrupoComisionadoId = Convert.ToInt32(dr["GrupoComisionadoId"]),
                            DescGrupoComisionado = dr["DescGrupoComisionado"].ToString(),
                            CodigoGrupoComisionado = dr["CodigoGrupoComisionado"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGrupoComisionado(GrupoComisionadoDTO grupoComisionadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoComisionadoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGrupoComisionado", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescGrupoComisionado"].Value = grupoComisionadoDTO.DescGrupoComisionado;

                    cmd.Parameters.Add("@CodigoGrupoComisionado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoComisionado"].Value = grupoComisionadoDTO.CodigoGrupoComisionado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoComisionadoDTO.UsuarioIngresoRegistro;

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

        public GrupoComisionadoDTO BuscarGrupoComisionadoID(int Codigo)
        {
            GrupoComisionadoDTO grupoComisionadoDTO = new GrupoComisionadoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoComisionadoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoComisionadoId", SqlDbType.Int);
                    cmd.Parameters["@GrupoComisionadoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        grupoComisionadoDTO.GrupoComisionadoId = Convert.ToInt32(dr["GrupoComisionadoId"]);
                        grupoComisionadoDTO.DescGrupoComisionado = dr["DescGrupoComisionado"].ToString();
                        grupoComisionadoDTO.CodigoGrupoComisionado = dr["CodigoGrupoComisionado"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return grupoComisionadoDTO;
        }

        public string ActualizarGrupoComisionado(GrupoComisionadoDTO grupoComisionadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoComisionadoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoComisionadoId", SqlDbType.Int);
                    cmd.Parameters["@GrupoComisionadoId"].Value = grupoComisionadoDTO.GrupoComisionadoId;

                    cmd.Parameters.Add("@DescGrupoComisionado", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescGrupoComisionado"].Value = grupoComisionadoDTO.DescGrupoComisionado;

                    cmd.Parameters.Add("@CodigoGrupoComisionado", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoGrupoComisionado"].Value = grupoComisionadoDTO.CodigoGrupoComisionado;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoComisionadoDTO.UsuarioIngresoRegistro;

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

        public string EliminarGrupoComisionado(GrupoComisionadoDTO grupoComisionadoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoComisionadoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoComisionadoId", SqlDbType.Int);
                    cmd.Parameters["@GrupoComisionadoId"].Value = grupoComisionadoDTO.GrupoComisionadoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoComisionadoDTO.UsuarioIngresoRegistro;

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
