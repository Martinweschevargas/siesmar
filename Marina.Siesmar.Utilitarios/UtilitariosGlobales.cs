using System;
using System.Collections;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Claims;
using System.Security.Principal;

namespace Marina.Siesmar.Utilitarios
{
    public static class UtilitariosGlobales
    {
        public static string obtenerDireccionMac()
        {

            ArrayList direccionesMac = new ArrayList();
            NetworkInterface[] adaptadorRed = null;
            adaptadorRed = NetworkInterface.GetAllNetworkInterfaces();

            if (adaptadorRed != null && adaptadorRed.Length > 0)
            {
                foreach (NetworkInterface interfaces in adaptadorRed)
                {
                    var direccion = interfaces.GetPhysicalAddress();
                    byte[] bytes = direccion.GetAddressBytes();

                    string mac = string.Empty;
                    for (int i = 0; i < bytes.Length; i++)
                    {
                        mac = mac + bytes[i].ToString("x2");
                        if (i != bytes.Length - 1)
                        {
                            mac = mac + "-";
                        }
                    }
                    direccionesMac.Add(mac);
                }
            }
            return direccionesMac[0].ToString();
        }

        public static string obtenerDireccionIp()
        {
            string HosName = Dns.GetHostName();
            IPHostEntry ipEntry = new IPHostEntry();
            ipEntry = Dns.GetHostEntry(HosName);
            string ip = Convert.ToString(ipEntry.AddressList[ipEntry.AddressList.Length - 1]);
            string host = Convert.ToString(ipEntry.HostName);
            return ip;
        }

        public static string obtenerUsuario(this IPrincipal user)
        {
            var Name = ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.Name);
            return Name == null ? null : Name.Value;
        }

        public static int obtenerUsuarioId(this IPrincipal user)
        {
            var Id = ((ClaimsIdentity)user.Identity).FindFirst("IdUsuario");
            return Convert.ToInt32(Id.Value);
        }

        public static int obtenerRolId(this IPrincipal user)
        {
            var Id = ((ClaimsIdentity)user.Identity).FindFirst(ClaimTypes.Role);
            return Convert.ToInt32(Id.Value);
        }

        public static string obtenerFecha(string fecha)
        {
            DateTime dateTime10 = Convert.ToDateTime(fecha);
            var fecha2 = dateTime10.ToString("yyyy-MM-dd");

            return fecha2;
        }

        public static string obtenerFechaHora(string fecha)
        {
            DateTime dateTime10 = Convert.ToDateTime(fecha);
            var fecha2 = dateTime10.ToString("yyyy-MM-dd HH:mm");

            return fecha2;
        }

        public static DateTime obtenerDatetime(string fecha)
        {
            DateTime dateTime10 = Convert.ToDateTime(fecha);
            return dateTime10;
        }

    }
}
