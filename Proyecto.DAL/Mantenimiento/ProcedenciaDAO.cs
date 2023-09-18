using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ProcedenciaDAO
    {

        SqlCommand cmd = new();

        public List<ProcedenciaDTO> ObtenerProcedencias()
        {
            List<ProcedenciaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ProcedenciaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ProcedenciaDTO()
                        {
                            ProcedenciaId = Convert.ToInt32(dr["ProcedenciaId"]),
                            CodigoProcedencia = dr["CodigoProcedencia"].ToString(),
                            DescProcedencia = dr["DescProcedencia"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarProcedencia(ProcedenciaDTO procedenciaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedenciaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@CodigoProcedencia", SqlDbType.VarChar, 20);                    
                    cmd.Parameters["@CodigoProcedencia"].Value = procedenciaDTO.CodigoProcedencia;

                    cmd.Parameters.Add("@DescProcedencia", SqlDbType.VarChar,200);
                    cmd.Parameters["@DescProcedencia"].Value = procedenciaDTO.DescProcedencia;


                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedenciaDTO.UsuarioIngresoRegistro;

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

        public ProcedenciaDTO BuscarProcedenciaID(int Codigo)
        {
            ProcedenciaDTO procedenciaDTO = new ProcedenciaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedenciaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedenciaId", SqlDbType.Int);
                    cmd.Parameters["@ProcedenciaId"].Value = Codigo;



                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        procedenciaDTO.ProcedenciaId = Convert.ToInt32(dr["ProcedenciaId"]);
                        procedenciaDTO.DescProcedencia = dr["DescProcedencia"].ToString();
                        procedenciaDTO.DescProcedencia = dr["CodigoProcedencia"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return procedenciaDTO;
        }

        public string ActualizarProcedencia(ProcedenciaDTO procedenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedenciaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@ProcedenciaId", SqlDbType.Int);
                    cmd.Parameters["@ProcedenciaId"].Value = procedenciaDTO.ProcedenciaId;

                    cmd.Parameters.Add("@CodigoProcedencia", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoProcedencia"].Value = procedenciaDTO.CodigoProcedencia;

                    cmd.Parameters.Add("@DescProcedencia", SqlDbType.VarChar, 200);
                    cmd.Parameters["@DescProcedencia"].Value = procedenciaDTO.DescProcedencia;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedenciaDTO.UsuarioIngresoRegistro;

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

        public string EliminarProcedencia(ProcedenciaDTO procedenciaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedenciaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedenciaId", SqlDbType.Int);
                    cmd.Parameters["@ProcedenciaId"].Value = procedenciaDTO.ProcedenciaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = procedenciaDTO.UsuarioIngresoRegistro;

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
