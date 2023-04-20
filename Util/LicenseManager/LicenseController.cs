using Rhino.Licensing;
using System;
using System.IO;

namespace Enigma.Util.LicenseManager
{
    public class LicenseController
    {
        public const string LICENSE_FILENAME = "license.xml";

        private string AppDataDirectory { get; set; }

        private string PublicKey { get; set; }

        private string LicenseFileName { get; set; }

        public LicenseController(string pAppDataDirectory, string pPublicKey)
        {
            AppDataDirectory = pAppDataDirectory;
            PublicKey = pPublicKey;

            string APPDATA_PATH = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            string LICENSE_PATH = Path.Combine(APPDATA_PATH, AppDataDirectory);

            if (!Directory.Exists(LICENSE_PATH))
            {
                Directory.CreateDirectory(LICENSE_PATH);
            }

            LicenseFileName = Path.Combine(LICENSE_PATH, LICENSE_FILENAME);
        }

        public bool ValidateLicense(out string Name, out string UserId, out LicenseType LicType, out DateTime ExpirationDate, out string errMessage)
        {
            bool result = true;
            errMessage = string.Empty;
            UserId = string.Empty;
            LicType = LicenseType.None;
            Name = string.Empty;
            ExpirationDate = DateTime.MinValue;

            try
            {
                LicenseValidator lic = new LicenseValidator(PublicKey, LicenseFileName);
                lic.AssertValidLicense();

                ExpirationDate = lic.ExpirationDate;
                LicType = lic.LicenseType;
                Name = lic.Name;
                UserId = lic.UserId.ToString();
            }
            catch (LicenseNotFoundException)
            {
                result &= false;
                errMessage = "La licencia no es válida o se encuentra vencida";
            }
            catch (LicenseFileNotFoundException)
            {
                result &= false;
                errMessage = "No se encuentra el archivo de licencia";
            }
            catch (Exception ex)
            {
                result &= false;
                errMessage = ex.Message;
            }

            return result;
        }

        public void GuardaLicencia(string filename)
        {
            File.Copy(filename, LicenseFileName, true);
        }
    }
}