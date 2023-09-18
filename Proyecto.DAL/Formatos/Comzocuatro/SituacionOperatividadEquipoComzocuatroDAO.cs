using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Comzocuatro;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Comzocuatro
{
    public class SituacionOperatividadEquipoComzocuatroDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<SituacionOperatividadEquipoComzocuatroDTO> ObtenerLista(int? CargaId = null)
        {
            List<SituacionOperatividadEquipoComzocuatroDTO> lista = new List<SituacionOperatividadEquipoComzocuatroDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoComzocuatroListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                cmd.Parameters["@CargaId"].Value = CargaId;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new SituacionOperatividadEquipoComzocuatroDTO()
                        {
                            SituacionOperatividadEquipoId = Convert.ToInt32(dr["SituacionOperatividadEquipoId"]),
                            DescripcionMaterial = dr["DescripcionMaterial"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescCondicion = dr["DescCondicion"].ToString(),
                            Observacion = dr["Observacion"].ToString(),
 

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(SituacionOperatividadEquipoComzocuatroDTO situacionOperatividadEquipoComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoComzocuatroRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@CodigoDescripcionMaterial", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDescripcionMaterial"].Value = situacionOperatividadEquipoComzocuatroDTO.CodigoDescripcionMaterial;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = situacionOperatividadEquipoComzocuatroDTO.Cantidad;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = situacionOperatividadEquipoComzocuatroDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperatividadEquipoComzocuatroDTO.Ubicacion;


                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = situacionOperatividadEquipoComzocuatroDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoCondicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicion"].Value = situacionOperatividadEquipoComzocuatroDTO.CodigoCondicion;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = situacionOperatividadEquipoComzocuatroDTO.Observacion;


                    cmd.Parameters.Add("@CargaId", SqlDbType.Int);
                    cmd.Parameters["@CargaId"].Value = situacionOperatividadEquipoComzocuatroDTO.CargaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadEquipoComzocuatroDTO.UsuarioIngresoRegistro;

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

        public SituacionOperatividadEquipoComzocuatroDTO BuscarFormato(int Codigo)
        {
            SituacionOperatividadEquipoComzocuatroDTO situacionOperatividadEquipoComzocuatroDTO = new SituacionOperatividadEquipoComzocuatroDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoComzocuatroEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        situacionOperatividadEquipoComzocuatroDTO.SituacionOperatividadEquipoId = Convert.ToInt32(dr["SituacionOperatividadEquipoId"]);
                        situacionOperatividadEquipoComzocuatroDTO.CodigoDescripcionMaterial = dr["CodigoDescripcionMaterial"].ToString();
                        situacionOperatividadEquipoComzocuatroDTO.Cantidad = Convert.ToInt32(dr["Cantidad"]);
                        situacionOperatividadEquipoComzocuatroDTO.CodigoUnidadNaval = dr["CodigoUnidadNaval"].ToString();
                        situacionOperatividadEquipoComzocuatroDTO.Ubicacion = dr["Ubicacion"].ToString();
                        situacionOperatividadEquipoComzocuatroDTO.DistritoUbigeo = dr["DistritoUbigeo"].ToString();
                        situacionOperatividadEquipoComzocuatroDTO.CodigoCondicion = dr["CodigoCondicion"].ToString();
                        situacionOperatividadEquipoComzocuatroDTO.Observacion = dr["Observacion"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return situacionOperatividadEquipoComzocuatroDTO;
        }

        public string ActualizaFormato(SituacionOperatividadEquipoComzocuatroDTO situacionOperatividadEquipoComzocuatroDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoComzocuatroActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = situacionOperatividadEquipoComzocuatroDTO.SituacionOperatividadEquipoId;

                    cmd.Parameters.Add("@CodigoDescripcionMaterial", SqlDbType.VarChar,20);
                    cmd.Parameters["@CodigoDescripcionMaterial"].Value = situacionOperatividadEquipoComzocuatroDTO.CodigoDescripcionMaterial;

                    cmd.Parameters.Add("@Cantidad", SqlDbType.Int);
                    cmd.Parameters["@Cantidad"].Value = situacionOperatividadEquipoComzocuatroDTO.Cantidad;

                    cmd.Parameters.Add("@CodigoUnidadNaval", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoUnidadNaval"].Value = situacionOperatividadEquipoComzocuatroDTO.CodigoUnidadNaval;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar, 100);
                    cmd.Parameters["@Ubicacion"].Value = situacionOperatividadEquipoComzocuatroDTO.Ubicacion;

                    cmd.Parameters.Add("@DistritoUbigeo", SqlDbType.VarChar, 20);
                    cmd.Parameters["@DistritoUbigeo"].Value = situacionOperatividadEquipoComzocuatroDTO.DistritoUbigeo;

                    cmd.Parameters.Add("@CodigoCondicion", SqlDbType.VarChar, 20);
                    cmd.Parameters["@CodigoCondicion"].Value = situacionOperatividadEquipoComzocuatroDTO.CodigoCondicion;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = situacionOperatividadEquipoComzocuatroDTO.Observacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadEquipoComzocuatroDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(SituacionOperatividadEquipoComzocuatroDTO situacionOperatividadEquipoComzocuatroDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoComzocuatroEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadEquipoId", SqlDbType.Int);
                    cmd.Parameters["@SituacionOperatividadEquipoId"].Value = situacionOperatividadEquipoComzocuatroDTO.SituacionOperatividadEquipoId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = situacionOperatividadEquipoComzocuatroDTO.UsuarioIngresoRegistro;

                    cmd.Parameters.Add("@Ip", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Ip"].Value = UtilitariosGlobales.obtenerDireccionIp();

                    cmd.Parameters.Add("@Mac", SqlDbType.VarChar, 50);
                    cmd.Parameters["@Mac"].Value = UtilitariosGlobales.obtenerDireccionMac();

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
        public string InsertarDatos(DataTable datos)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    var cmd = new SqlCommand("Formato.usp_SituacionOperatividadEquipoComzocuatroRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@SituacionOperatividadEquipoComzocuatro", SqlDbType.Structured);
                    cmd.Parameters["@SituacionOperatividadEquipoComzocuatro"].TypeName = "Formato.SituacionOperatividadEquipoComzocuatro";
                    cmd.Parameters["@SituacionOperatividadEquipoComzocuatro"].Value = datos;

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
