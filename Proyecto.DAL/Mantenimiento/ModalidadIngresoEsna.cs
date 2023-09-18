using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ModalidadIngresoEsnaDAO
    {

        SqlCommand cmd = new();

        public List<ModalidadIngresoEsnaDTO> ObtenerModalidadIngresoEsnas()
        {
            List<ModalidadIngresoEsnaDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ModalidadIngresoEsnaListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ModalidadIngresoEsnaDTO()
                        {
                            ModalidadIngresoEsnaId = Convert.ToInt32(dr["ModalidadIngresoEsnaId"]),
                            DescModalidadIngresoEsna = dr["DescModalidadIngresoEsna"].ToString(),
                            CodigoModalidadIngresoEsna = dr["CodigoModalidadIngresoEsna"].ToString()
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarModalidadIngresoEsna(ModalidadIngresoEsnaDTO modalidadIngresoEsnaDTO)
        {
            string IND_OPERACION="0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {        
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadIngresoEsnaRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescModalidadIngresoEsna", SqlDbType.VarChar, 80);                    
                    cmd.Parameters["@DescModalidadIngresoEsna"].Value = modalidadIngresoEsnaDTO.DescModalidadIngresoEsna;

                    cmd.Parameters.Add("@CodigoModalidadIngresoEsna", SqlDbType.VarChar, 80);
                    cmd.Parameters["@CodigoModalidadIngresoEsna"].Value = modalidadIngresoEsnaDTO.CodigoModalidadIngresoEsna;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modalidadIngresoEsnaDTO.UsuarioIngresoRegistro;

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

        public ModalidadIngresoEsnaDTO BuscarModalidadIngresoEsnaID(int Codigo)
        {
            ModalidadIngresoEsnaDTO modalidadIngresoEsnaDTO = new ModalidadIngresoEsnaDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadIngresoEsnaEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadIngresoEsnaId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadIngresoEsnaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        modalidadIngresoEsnaDTO.ModalidadIngresoEsnaId = Convert.ToInt32(dr["ModalidadIngresoEsnaId"]);
                        modalidadIngresoEsnaDTO.DescModalidadIngresoEsna = dr["DescModalidadIngresoEsna"].ToString();
                        modalidadIngresoEsnaDTO.CodigoModalidadIngresoEsna = dr["CodigoModalidadIngresoEsna"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return modalidadIngresoEsnaDTO;
        }

        public string ActualizarModalidadIngresoEsna(ModalidadIngresoEsnaDTO modalidadIngresoEsnaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadIngresoEsnaActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadIngresoEsnaId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadIngresoEsnaId"].Value = modalidadIngresoEsnaDTO.ModalidadIngresoEsnaId;

                    cmd.Parameters.Add("@DescModalidadIngresoEsna", SqlDbType.VarChar, 50);
                    cmd.Parameters["@DescModalidadIngresoEsna"].Value = modalidadIngresoEsnaDTO.DescModalidadIngresoEsna;

                    cmd.Parameters.Add("@CodigoModalidadIngresoEsna", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoModalidadIngresoEsna"].Value = modalidadIngresoEsnaDTO.CodigoModalidadIngresoEsna;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modalidadIngresoEsnaDTO.UsuarioIngresoRegistro;

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

        public string EliminarModalidadIngresoEsna(ModalidadIngresoEsnaDTO modalidadIngresoEsnaDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadIngresoEsnaEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadIngresoEsnaId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadIngresoEsnaId"].Value = modalidadIngresoEsnaDTO.ModalidadIngresoEsnaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modalidadIngresoEsnaDTO.UsuarioIngresoRegistro;

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
