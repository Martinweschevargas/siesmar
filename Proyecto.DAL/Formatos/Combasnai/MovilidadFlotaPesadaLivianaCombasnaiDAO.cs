using Marina.Siesmar.AccesoDatos.Configuracion;
using Marina.Siesmar.Entidades.Formatos.Combasnai;
using Marina.Siesmar.Utilitarios;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Marina.Siesmar.AccesoDatos.Formatos.Combasnai
{
    public class MovilidadFlotaPesadaLivianaCombasnaiDAO
    {

        SqlCommand cmd = new SqlCommand();

        public List<MovilidadFlotaPesadaLivianaCombasnaiDTO> ObtenerLista()
        {
            List<MovilidadFlotaPesadaLivianaCombasnaiDTO> lista = new List<MovilidadFlotaPesadaLivianaCombasnaiDTO>();

            var cn = new ConfiguracionConexion();

            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                conexion.Open();
                cmd = new SqlCommand("Formato.usp_MovilidadFlotaPesadaLivianaCombasnaiListar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (SqlDataReader dr = cmd.ExecuteReader())
                {

                    while (dr.Read())
                    {
                        lista.Add(new MovilidadFlotaPesadaLivianaCombasnaiDTO()
                        {
                            MovilidadFlotaPesadaLivianaId = Convert.ToInt32(dr["MovilidadFlotaPesadaLivianaId"]),
                            DescUnidadNaval = dr["DescUnidadNaval"].ToString(),
                            DescClaseFlota = dr["DescClaseFlota"].ToString(),
                            NombreDependencia = dr["NombreDependencia"].ToString(),
                            Ubicacion = dr["Ubicacion"].ToString(),
                            DescDepartamento = dr["DescDepartamento"].ToString(),
                            DescProvincia = dr["DescProvincia"].ToString(),
                            DescDistrito = dr["DescDistrito"].ToString(),
                            DescCapacidadOperativaRequerida = dr["DescCapacidadOperativaRequerida"].ToString(),
                            DescCondicion = dr["DescCondicion"].ToString(),
                            Observacion = dr["Observacion"].ToString(),

                        });
                    }
                }
            }
            return lista;
        }

        public string AgregarRegistro(MovilidadFlotaPesadaLivianaCombasnaiDTO movilidadFlotaPesadaLivianaCombasnaiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();
            using (var conexion = new SqlConnection(cn.getCadenaSQL()))
            {
                try
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MovilidadFlotaPesadaLivianaCombasnaiRegistrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.UnidadNavalId;

                    cmd.Parameters.Add("@ClaseFlotaId", SqlDbType.Int);
                    cmd.Parameters["@ClaseFlotaId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.ClaseFlotaId;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.DependenciaId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Ubicacion"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CapacidadOperativaRequeridaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaRequeridaId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.CapacidadOperativaRequeridaId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.CondicionId;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.Observacion;

                    cmd.Parameters.Add("@CodigoCargo", SqlDbType.Int);
                    cmd.Parameters["@CodigoCargo"].Value = "1";

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.UsuarioIngresoRegistro;

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

        public MovilidadFlotaPesadaLivianaCombasnaiDTO BuscarFormato(int Codigo)
        {
            MovilidadFlotaPesadaLivianaCombasnaiDTO movilidadFlotaPesadaLivianaCombasnaiDTO = new MovilidadFlotaPesadaLivianaCombasnaiDTO();
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MovilidadFlotaPesadaLivianaCombasnaiEncontrar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MovilidadFlotaPesadaLivianaId", SqlDbType.Int);
                    cmd.Parameters["@MovilidadFlotaPesadaLivianaId"].Value = Codigo;

                    SqlDataReader dr = cmd.ExecuteReader();
                    dr.Read();

                    if (dr.HasRows)
                    {

                        movilidadFlotaPesadaLivianaCombasnaiDTO.MovilidadFlotaPesadaLivianaId = Convert.ToInt32(dr["MovilidadFlotaPesadaLivianaId"]);
                        movilidadFlotaPesadaLivianaCombasnaiDTO.UnidadNavalId = Convert.ToInt32(dr["UnidadNavalId"]);
                        movilidadFlotaPesadaLivianaCombasnaiDTO.ClaseFlotaId = Convert.ToInt32(dr["ClaseFlotaId"]);
                        movilidadFlotaPesadaLivianaCombasnaiDTO.DependenciaId = Convert.ToInt32(dr["DependenciaId"]);
                        movilidadFlotaPesadaLivianaCombasnaiDTO.Ubicacion = dr["Ubicacion"].ToString();
                        movilidadFlotaPesadaLivianaCombasnaiDTO.DepartamentoUbigeoId = Convert.ToInt32(dr["DepartamentoUbigeoId"]);
                        movilidadFlotaPesadaLivianaCombasnaiDTO.ProvinciaUbigeoId = Convert.ToInt32(dr["ProvinciaUbigeoId"]);
                        movilidadFlotaPesadaLivianaCombasnaiDTO.DistritoUbigeoId = Convert.ToInt32(dr["DistritoUbigeoId"]);
                        movilidadFlotaPesadaLivianaCombasnaiDTO.CapacidadOperativaRequeridaId = Convert.ToInt32(dr["CapacidadOperativaRequeridaId"]);
                        movilidadFlotaPesadaLivianaCombasnaiDTO.CondicionId = Convert.ToInt32(dr["CondicionId"]);
                        movilidadFlotaPesadaLivianaCombasnaiDTO.Observacion = dr["Observacion"].ToString(); 
 

                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
            return movilidadFlotaPesadaLivianaCombasnaiDTO;
        }

        public string ActualizaFormato(MovilidadFlotaPesadaLivianaCombasnaiDTO movilidadFlotaPesadaLivianaCombasnaiDTO)
        {
            string IND_OPERACION = "0";
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();

                    cmd = new SqlCommand("Formato.usp_MovilidadFlotaPesadaLivianaCombasnaiActualizar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;


                    cmd.Parameters.Add("@MovilidadFlotaPesadaLivianaId", SqlDbType.Int);
                    cmd.Parameters["@MovilidadFlotaPesadaLivianaId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.MovilidadFlotaPesadaLivianaId;

                    cmd.Parameters.Add("@UnidadNavalId", SqlDbType.Int);
                    cmd.Parameters["@UnidadNavalId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.UnidadNavalId;

                    cmd.Parameters.Add("@ClaseFlotaId", SqlDbType.Int);
                    cmd.Parameters["@ClaseFlotaId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.ClaseFlotaId;

                    cmd.Parameters.Add("@DependenciaId", SqlDbType.Int);
                    cmd.Parameters["@DependenciaId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.DependenciaId;

                    cmd.Parameters.Add("@Ubicacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Ubicacion"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.Ubicacion;

                    cmd.Parameters.Add("@DepartamentoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DepartamentoUbigeoId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.DepartamentoUbigeoId;

                    cmd.Parameters.Add("@ProvinciaUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@ProvinciaUbigeoId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.ProvinciaUbigeoId;

                    cmd.Parameters.Add("@DistritoUbigeoId", SqlDbType.Int);
                    cmd.Parameters["@DistritoUbigeoId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.DistritoUbigeoId;

                    cmd.Parameters.Add("@CapacidadOperativaRequeridaId", SqlDbType.Int);
                    cmd.Parameters["@CapacidadOperativaRequeridaId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.CapacidadOperativaRequeridaId;

                    cmd.Parameters.Add("@CondicionId", SqlDbType.Int);
                    cmd.Parameters["@CondicionId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.CondicionId;

                    cmd.Parameters.Add("@Observacion", SqlDbType.VarChar,200);
                    cmd.Parameters["@Observacion"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.Observacion;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.UsuarioIngresoRegistro;

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

        public bool EliminarFormato(MovilidadFlotaPesadaLivianaCombasnaiDTO movilidadFlotaPesadaLivianaCombasnaiDTO)
        {
            bool eliminado = false;
            var cn = new ConfiguracionConexion();

            try
            {
                using (var conexion = new SqlConnection(cn.getCadenaSQL()))
                {
                    conexion.Open();
                    cmd = new SqlCommand("Formato.usp_MovilidadFlotaPesadaLivianaCombasnaiEliminar", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MovilidadFlotaPesadaLivianaId", SqlDbType.Int);
                    cmd.Parameters["@MovilidadFlotaPesadaLivianaId"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.MovilidadFlotaPesadaLivianaId;

                    cmd.Parameters.Add("@Usuario", SqlDbType.NVarChar, 100);
                    cmd.Parameters["@Usuario"].Value = movilidadFlotaPesadaLivianaCombasnaiDTO.UsuarioIngresoRegistro;

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
                    var cmd = new SqlCommand("Formato.usp_MovilidadFlotaPesadaLivianaCombasnaiRegistrarMasivo", conexion);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.Add("@MovilidadFlotaPesadaLivianaCombasnaiRegistrar", SqlDbType.Structured);
                    cmd.Parameters["@MovilidadFlotaPesadaLivianaCombasnaiRegistrar"].TypeName = "Formato.MovilidadFlotaPesadaLivianaCombasnaiRegistrar";
                    cmd.Parameters["@MovilidadFlotaPesadaLivianaCombasnaiRegistrar"].Value = datos;

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

