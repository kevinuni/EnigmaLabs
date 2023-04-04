using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Util
{
    public class AuthorizationManager
    {
        public enum eTipoLicencia { Profesional, Estudiante };
        public eTipoLicencia tipoLicencia = eTipoLicencia.Estudiante;


        public static eTipoLicencia ValidateLicense(out string message, byte[] serializedCredencial, string privatekey)
        {
            message = string.Empty;
            try
            {
                MemoryStream streamCredencial = new MemoryStream(serializedCredencial);
                Credencial credencial = (Credencial)BinarySerialize.DeserializeFromStream(streamCredencial);

                string decryptedToken = RSAManager.DecryptString(credencial.AuthToken, privatekey);


                Fingerprint fp = new Fingerprint();
                if (fp.Value() == decryptedToken && fp.Value() == credencial.Fingerprint)
                {
                    if (credencial.FechaVencimiento <= DateTime.Now)
                    {
                        message = "La licencia se encuentra vencida";
                        return eTipoLicencia.Estudiante;
                    }
                    else
                    {
                        message += "Licencia autorizada a:";
                        message += Environment.NewLine;
                        message += Environment.NewLine + credencial.Nombre;
                        message += Environment.NewLine + credencial.Empresa;
                        message += Environment.NewLine;
                        message += Environment.NewLine + "Fecha de Registro:" + credencial.FechaRegistro.ToShortDateString();
                        message += Environment.NewLine + "Fecha de Vencimiento:" + credencial.FechaVencimiento.ToShortDateString();

                        return eTipoLicencia.Profesional;
                    }
                }
                else
                {
                    message = "No se puede autenticar la licencia";
                    return eTipoLicencia.Estudiante;
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return eTipoLicencia.Estudiante;
            }
        }
    }
}
