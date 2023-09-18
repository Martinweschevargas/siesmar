using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ObservacionProcesoDAO
    {

        SqlCommand cmd = new();

        public List<ObservacionProcesoDTO> ObtenerObservacionProcesos()
        {
            List<ObservacionProcesoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ObservacionProcesoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ObservacionProcesoDTO()
                        {
                            ObservacionProcesoId = Convert.ToInt32(dr["ObservacionProcesoId"]),
                            DescObservacionProceso = dr["DescObservacionProceso"].ToString(),
                            CodigoObservacionProceso = dr["CodigoObservacionProceso"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarObservacionProceso(ObservacionProcesoDTO observacionProcesoDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ObservacionProcesoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescObservacionProceso", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescObservacionProceso"].Value = observacionProcesoDTO.DescObservacionProceso;

                    cmd.Parameters.Add("@CodigoObservacionProceso", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoObservacionProceso"].Value = observacionProcesoDTO.CodigoObservacionProceso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = observacionProcesoDTO.UsuarioIngresoRegistro;

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

        public ObservacionProcesoDTO BuscarObservacionProcesoID(int Codigo)
        {
            ObservacionProcesoDTO observacionProcesoDTO = new ObservacionProcesoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ObservacionProcesoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ObservacionProcesoId", SqlDbType.Int);
                    cmd.Parameters["@ObservacionProcesoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        observacionProcesoDTO.ObservacionProcesoId = Convert.ToInt32(dr["ObservacionProcesoId"]);
                        observacionProcesoDTO.DescObservacionProceso = dr["DescObservacionProceso"].ToString();
                        observacionProcesoDTO.CodigoObservacionProceso = dr["CodigoObservacionProceso"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return observacionProcesoDTO;
        }

        public string ActualizarObservacionProceso(ObservacionProcesoDTO observacionProcesoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Mantenimiento.usp_ObservacionProcesoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ObservacionProcesoId", SqlDbType.Int);
                    cmd.Parameters["@ObservacionProcesoId"].Value = observacionProcesoDTO.ObservacionProcesoId;

                    cmd.Parameters.Add("@DescObservacionProceso", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescObservacionProceso"].Value = observacionProcesoDTO.DescObservacionProceso;

                    cmd.Parameters.Add("@CodigoObservacionProceso", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoObservacionProceso"].Value = observacionProcesoDTO.CodigoObservacionProceso;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = observacionProcesoDTO.UsuarioIngresoRegistro;

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

        public bool EliminarObservacionProceso(int Codigo)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ObservacionProcesoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ObservacionProcesoId", SqlDbType.Int);
                    cmd.Parameters["@ObservacionProcesoId"].Value = Codigo;
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
