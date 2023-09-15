using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ModalidadProgramaDAO
    {

        SqlCommand cmd = new();

        public List<ModalidadProgramaDTO> ObtenerModalidadProgramas()
        {
            List<ModalidadProgramaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ModalidadProgramaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ModalidadProgramaDTO()
                        {
                            ModalidadProgramaId = Convert.ToInt32(dr["ModalidadProgramaId"]),
                            DescModalidadPrograma = dr["DescModalidadPrograma"].ToString(),
                            CodigoModalidadPrograma = dr["CodigoModalidadPrograma"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarModalidadPrograma(ModalidadProgramaDTO modalidadProgramaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadProgramaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescModalidadPrograma", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescModalidadPrograma"].Value = modalidadProgramaDTO.DescModalidadPrograma;

                    cmd.Parameters.Add("@CodigoModalidadPrograma", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoModalidadPrograma"].Value = modalidadProgramaDTO.CodigoModalidadPrograma;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modalidadProgramaDTO.UsuarioIngresoRegistro;

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

        public ModalidadProgramaDTO BuscarModalidadProgramaID(int Codigo)
        {
            ModalidadProgramaDTO modalidadProgramaDTO = new ModalidadProgramaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadProgramaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadProgramaId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadProgramaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        modalidadProgramaDTO.ModalidadProgramaId = Convert.ToInt32(dr["ModalidadProgramaId"]);
                        modalidadProgramaDTO.DescModalidadPrograma = dr["DescModalidadPrograma"].ToString();
                        modalidadProgramaDTO.CodigoModalidadPrograma = dr["CodigoModalidadPrograma"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return modalidadProgramaDTO;
        }

        public string ActualizarModalidadPrograma(ModalidadProgramaDTO modalidadProgramaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadProgramaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadProgramaId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadProgramaId"].Value = modalidadProgramaDTO.ModalidadProgramaId;

                    cmd.Parameters.Add("@DescModalidadPrograma", SqlDbType.VarChar, 500);
                    cmd.Parameters["@DescModalidadPrograma"].Value = modalidadProgramaDTO.DescModalidadPrograma;

                    cmd.Parameters.Add("@CodigoModalidadPrograma", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoModalidadPrograma"].Value = modalidadProgramaDTO.CodigoModalidadPrograma;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modalidadProgramaDTO.UsuarioIngresoRegistro;

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

        public string EliminarModalidadPrograma(ModalidadProgramaDTO modalidadProgramaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadProgramaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadProgramaId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadProgramaId"].Value = modalidadProgramaDTO.ModalidadProgramaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modalidadProgramaDTO.UsuarioIngresoRegistro;

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
