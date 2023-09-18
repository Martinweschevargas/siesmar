using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class TemaAcademicoDAO
    {

        SqlCommand cmd = new();

        public List<TemaAcademicoDTO> ObtenerTemaAcademicos()
        {
            List<TemaAcademicoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_TemaAcademicoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new TemaAcademicoDTO()
                        {
                            TemaAcademicoId = Convert.ToInt32(dr["TemaAcademicoId"]),
                            DescTemaAcademico = dr["DescTemaAcademico"].ToString(),
                            CodigoTemaAcademico = dr["CodigoTemaAcademico"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarTemaAcademico(TemaAcademicoDTO temaAcademicoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TemaAcademicoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescTemaAcademico", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescTemaAcademico"].Value = temaAcademicoDTO.DescTemaAcademico;

                    cmd.Parameters.Add("@CodigoTemaAcademico", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoTemaAcademico"].Value = temaAcademicoDTO.CodigoTemaAcademico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = temaAcademicoDTO.UsuarioIngresoRegistro;

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

        public TemaAcademicoDTO BuscarTemaAcademicoID(int Codigo)
        {
            TemaAcademicoDTO temaAcademicoDTO = new TemaAcademicoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TemaAcademicoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TemaAcademicoId", SqlDbType.Int);
                    cmd.Parameters["@TemaAcademicoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        temaAcademicoDTO.TemaAcademicoId = Convert.ToInt32(dr["TemaAcademicoId"]);
                        temaAcademicoDTO.DescTemaAcademico = dr["DescTemaAcademico"].ToString();
                        temaAcademicoDTO.CodigoTemaAcademico = dr["CodigoTemaAcademico"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return temaAcademicoDTO;
        }

        public string ActualizarTemaAcademico(TemaAcademicoDTO temaAcademicoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TemaAcademicoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TemaAcademicoId", SqlDbType.Int);
                    cmd.Parameters["@TemaAcademicoId"].Value = temaAcademicoDTO.TemaAcademicoId;

                    cmd.Parameters.Add("@DescTemaAcademico", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescTemaAcademico"].Value = temaAcademicoDTO.DescTemaAcademico;

                    cmd.Parameters.Add("@CodigoTemaAcademico", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoTemaAcademico"].Value = temaAcademicoDTO.CodigoTemaAcademico;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = temaAcademicoDTO.UsuarioIngresoRegistro;

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

        public string EliminarTemaAcademico(TemaAcademicoDTO temaAcademicoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_TemaAcademicoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@TemaAcademicoId", SqlDbType.Int);
                    cmd.Parameters["@TemaAcademicoId"].Value = temaAcademicoDTO.TemaAcademicoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = temaAcademicoDTO.UsuarioIngresoRegistro;

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
