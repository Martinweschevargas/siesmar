using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Mantenimiento;
using Marina.Siesmar.Utilitarios;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Mantenimiento
{
    public class ModalidadPrestamoDAO
    {

        SqlCommand cmd = new();

        public List<ModalidadPrestamoDTO> ObtenerModalidadPrestamos()
        {
            List<ModalidadPrestamoDTO> lista = new();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Mantenimiento.usp_ModalidadPrestamoListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new ModalidadPrestamoDTO()
                        {
                            ModalidadPrestamoId = Convert.ToInt32(dr["ModalidadPrestamoId"]),
                            DescModalidadPrestamo = dr["DescModalidadPrestamo"].ToString(),
                            CodigoModalidadPrestamo = dr["CodigoModalidadPrestamo"].ToString(),
                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarModalidadPrestamo(ModalidadPrestamoDTO modalidadPrestamoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadPrestamoRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@DescModalidadPrestamo", SqlDbType.VarChar, 250);
                    cmd.Parameters["@DescModalidadPrestamo"].Value = modalidadPrestamoDTO.DescModalidadPrestamo;

                    cmd.Parameters.Add("@CodigoModalidadPrestamo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoModalidadPrestamo"].Value = modalidadPrestamoDTO.CodigoModalidadPrestamo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modalidadPrestamoDTO.UsuarioIngresoRegistro;

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

        public ModalidadPrestamoDTO BuscarModalidadPrestamoID(int Codigo)
        {
            ModalidadPrestamoDTO modalidadPrestamoDTO = new ModalidadPrestamoDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadPrestamoEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadPrestamoId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadPrestamoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {
                        modalidadPrestamoDTO.ModalidadPrestamoId = Convert.ToInt32(dr["ModalidadPrestamoId"]);
                        modalidadPrestamoDTO.DescModalidadPrestamo = dr["DescModalidadPrestamo"].ToString();
                        modalidadPrestamoDTO.CodigoModalidadPrestamo = dr["CodigoModalidadPrestamo"].ToString();
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return modalidadPrestamoDTO;
        }

        public string ActualizarModalidadPrestamo(ModalidadPrestamoDTO modalidadPrestamoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadPrestamoActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadPrestamoId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadPrestamoId"].Value = modalidadPrestamoDTO.ModalidadPrestamoId;

                    cmd.Parameters.Add("@DescModalidadPrestamo", SqlDbType.VarChar, 250);
                    cmd.Parameters["@DescModalidadPrestamo"].Value = modalidadPrestamoDTO.DescModalidadPrestamo;

                    cmd.Parameters.Add("@CodigoModalidadPrestamo", SqlDbType.VarChar, 10);
                    cmd.Parameters["@CodigoModalidadPrestamo"].Value = modalidadPrestamoDTO.CodigoModalidadPrestamo;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modalidadPrestamoDTO.UsuarioIngresoRegistro;

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

        public string EliminarModalidadPrestamo(ModalidadPrestamoDTO modalidadPrestamoDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Mantenimiento.usp_ModalidadPrestamoEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@ModalidadPrestamoId", SqlDbType.Int);
                    cmd.Parameters["@ModalidadPrestamoId"].Value = modalidadPrestamoDTO.ModalidadPrestamoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = modalidadPrestamoDTO.UsuarioIngresoRegistro;

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
