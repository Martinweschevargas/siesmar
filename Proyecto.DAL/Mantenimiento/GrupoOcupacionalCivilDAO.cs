using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class GrupoOcupacionalCivilDAO
    {

        SqlCommand cmd = new();

        public List<GrupoOcupacionalCivilDTO> ObtenerGrupoOcupacionalCivils()
        {
            List<GrupoOcupacionalCivilDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_GrupoOcupacionalCivilListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new GrupoOcupacionalCivilDTO()
                        {
                            GrupoOcupacionalCivilId = Convert.ToInt32(dr["GrupoOcupacionalCivilId"]),
                            DescGrupoOcupacionalCivil = dr["DescGrupoOcupacionalCivil"].ToString(),
                            CodigoGrupoOcupacionalCivil = dr["CodigoGrupoOcupacionalCivil"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarGrupoOcupacionalCivil(GrupoOcupacionalCivilDTO grupoOcupacionalCivilDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoOcupacionalCivilRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescGrupoOcupacionalCivil", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescGrupoOcupacionalCivil"].Value = grupoOcupacionalCivilDTO.DescGrupoOcupacionalCivil;

                    cmd.Parameters.Add("@CodigoGrupoOcupacionalCivil", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoGrupoOcupacionalCivil"].Value = grupoOcupacionalCivilDTO.CodigoGrupoOcupacionalCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoOcupacionalCivilDTO.UsuarioIngresoRegistro;

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

        public GrupoOcupacionalCivilDTO BuscarGrupoOcupacionalCivilID(int Codigo)
        {
            GrupoOcupacionalCivilDTO grupoOcupacionalCivilDTO = new GrupoOcupacionalCivilDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoOcupacionalCivilEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoOcupacionalCivilId", SqlDbType.Int);
                    cmd.Parameters["@GrupoOcupacionalCivilId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        grupoOcupacionalCivilDTO.GrupoOcupacionalCivilId = Convert.ToInt32(dr["GrupoOcupacionalCivilId"]);
                        grupoOcupacionalCivilDTO.DescGrupoOcupacionalCivil = dr["DescGrupoOcupacionalCivil"].ToString();
                        grupoOcupacionalCivilDTO.CodigoGrupoOcupacionalCivil = dr["CodigoGrupoOcupacionalCivil"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return grupoOcupacionalCivilDTO;
        }

        public string ActualizarGrupoOcupacionalCivil(GrupoOcupacionalCivilDTO grupoOcupacionalCivilDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_GrupoOcupacionalCivilActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoOcupacionalCivilId", SqlDbType.Int);
                    cmd.Parameters["@GrupoOcupacionalCivilId"].Value = grupoOcupacionalCivilDTO.GrupoOcupacionalCivilId;

                    cmd.Parameters.Add("@DescGrupoOcupacionalCivil", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescGrupoOcupacionalCivil"].Value = grupoOcupacionalCivilDTO.DescGrupoOcupacionalCivil;

                    cmd.Parameters.Add("@CodigoGrupoOcupacionalCivil", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoGrupoOcupacionalCivil"].Value = grupoOcupacionalCivilDTO.CodigoGrupoOcupacionalCivil;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoOcupacionalCivilDTO.UsuarioIngresoRegistro;

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


        public string EliminarGrupoOcupacionalCivil(GrupoOcupacionalCivilDTO grupoOcupacionalCivilDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_GrupoOcupacionalCivilEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@GrupoOcupacionalCivilId", SqlDbType.Int);
                    cmd.Parameters["@GrupoOcupacionalCivilId"].Value = grupoOcupacionalCivilDTO.GrupoOcupacionalCivilId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = grupoOcupacionalCivilDTO.UsuarioIngresoRegistro;

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
