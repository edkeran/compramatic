using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;

namespace Utilitarios
{
    [Serializable]
    [Table("acceso", Schema = "audit")]
    public class EAcceso
    {
        private int id = -1;

        private Int64 idUsuario = -1;

        private string ip = "";

        private string mac = "";

        private string fechaInicio = "";

        private string fechaFin = "";

        private string ultimaActividad = "";

        public EAcceso()
        {

        }

        public static EAcceso fromDataRow(DataRow dataRow)
        {
            EAcceso eAcceso = new EAcceso();

            eAcceso.Id = int.Parse(dataRow["id"].ToString());
            eAcceso.IdUsuario = int.Parse(dataRow["id_usuario"].ToString());
            eAcceso.Ip = dataRow["ip"].ToString();
            eAcceso.Mac = dataRow["mac"].ToString();
            eAcceso.FechaInicio = dataRow["fecha_inicio"].ToString();
            eAcceso.FechaFin = dataRow["fecha_fin"].ToString();
            eAcceso.UltimaActividad = dataRow["ultima_actividad"].ToString();

            return eAcceso;
        }

        public static string obtenerIP()
        {
            string IP4Address = String.Empty;

            foreach (IPAddress IPA in Dns.GetHostAddresses(Dns.GetHostName()))
            {
                if (IPA.AddressFamily == AddressFamily.InterNetwork)
                {
                    IP4Address = IPA.ToString();
                    break;
                }
            }

            return IP4Address;
        }

        public static string obtenerMAC()
        {
            NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();

            String sMacAddress = string.Empty;

            foreach (NetworkInterface adapter in nics)
            {
                if (sMacAddress == String.Empty)
                {
                    IPInterfaceProperties properties = adapter.GetIPProperties();
                    sMacAddress = adapter.GetPhysicalAddress().ToString();
                }
            }
            return sMacAddress;
        }

        [Key]
        [Column("id")]
        public int Id { get => id; set => id = value; }

        [Column("id_usuario")]
        public Int64 IdUsuario { get => idUsuario; set => idUsuario = value; }

        [Column("ip")]
        public string Ip { get => ip; set => ip = value; }

        [Column("mac")]
        public string Mac { get => mac; set => mac = value; }

        [Column("fecha_inicio")]
        public string FechaInicio { get => fechaInicio; set => fechaInicio = value; }

        [Column("fecha_fin")]
        public string FechaFin { get => fechaFin; set => fechaFin = value; }

        [Column("ultima_actividad")]
        public string UltimaActividad { get => ultimaActividad; set => ultimaActividad = value; }
    }
}