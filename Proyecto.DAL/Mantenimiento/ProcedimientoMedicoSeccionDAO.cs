using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ProcedimientoMedicoSeccionDAO
    {

        SqlCommand cmd = new();

        public List<ProcedimientoMedicoSeccionDTO> ObtenerProcedimientoMedicoSeccions()
        {
            List<ProcedimientoMedicoSeccionDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoSeccionListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ProcedimientoMedicoSeccionDTO()
                        {
                            ProcedimientoMedicoSeccionId = Convert.ToInt32(dr["ProcedimientoMedicoSeccionId"]),
                            DescProcedimientoMedicoSeccion = dr["DescProcedimientoMedicoSeccion"].ToString(),
                            CodigoProcedimientoMedicoSeccion = dr["CodigoProcedimientoMedicoSeccion"].ToString(),
                            DescProcedimientoMedicoGrupo = dr["DescProcedimientoMedicoGrupo"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarProcedimientoMedicoSeccion(ProcedimientoMedicoSeccionDTO puertoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoSeccionRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescProcedimientoMedicoSeccion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescProcedimientoMedicoSeccion"].Value = puertoDTO.DescProcedimientoMedicoSeccion;

                    cmd.Parameters.Add("@CodigoProcedimientoMedicoSeccion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProcedimientoMedicoSeccion"].Value = puertoDTO.CodigoProcedimientoMedicoSeccion;

                    cmd.Parameters.Add("@ProcedimientoMedicoGrupoId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoGrupoId"].Value = puertoDTO.ProcedimientoMedicoGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puertoDTO.UsuarioIngresoRegistro;

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

        public ProcedimientoMedicoSeccionDTO BuscarProcedimientoMedicoSeccionID(int Codigo)
        {
            ProcedimientoMedicoSeccionDTO puertoDTO = new ProcedimientoMedicoSeccionDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoSeccionEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoMedicoSeccionId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoSeccionId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        puertoDTO.ProcedimientoMedicoSeccionId = Convert.ToInt32(dr["ProcedimientoMedicoSeccionId"]);
                        puertoDTO.DescProcedimientoMedicoSeccion = dr["DescProcedimientoMedicoSeccion"].ToString();
                        puertoDTO.CodigoProcedimientoMedicoSeccion = dr["CodigoProcedimientoMedicoSeccion"].ToString();
                        puertoDTO.ProcedimientoMedicoGrupoId = Convert.ToInt32(dr["ProcedimientoMedicoGrupoId"]);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return puertoDTO;
        }

        public string ActualizarProcedimientoMedicoSeccion(ProcedimientoMedicoSeccionDTO puertoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoSeccionActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoMedicoSeccionId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoSeccionId"].Value = puertoDTO.ProcedimientoMedicoSeccionId;

                    cmd.Parameters.Add("@DescProcedimientoMedicoSeccion", SqlDbType.VarChar, 80);
                    cmd.Parameters["@DescProcedimientoMedicoSeccion"].Value = puertoDTO.DescProcedimientoMedicoSeccion;

                    cmd.Parameters.Add("@CodigoProcedimientoMedicoSeccion", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoProcedimientoMedicoSeccion"].Value = puertoDTO.CodigoProcedimientoMedicoSeccion;

                    cmd.Parameters.Add("@ProcedimientoMedicoGrupoId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoGrupoId"].Value = puertoDTO.ProcedimientoMedicoGrupoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puertoDTO.UsuarioIngresoRegistro;

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

        public string EliminarProcedimientoMedicoSeccion(ProcedimientoMedicoSeccionDTO puertoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ProcedimientoMedicoSeccionEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ProcedimientoMedicoSeccionId", SqlDbType.Int);
                    cmd.Parameters["@ProcedimientoMedicoSeccionId"].Value = puertoDTO.ProcedimientoMedicoSeccionId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = puertoDTO.UsuarioIngresoRegistro;

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
