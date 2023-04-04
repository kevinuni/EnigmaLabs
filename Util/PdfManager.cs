using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using PdfSharp.Pdf.Security;
using System.IO;

namespace Util
{
    public class PdfManager
    {
        public static byte[] SecurePdf(Stream data, string userpassword, string ownerpassword)
        {
            // Open an existing document. Providing an unrequired password is ignored.
            PdfDocument document = PdfReader.Open(data);

            PdfSecuritySettings securitySettings = document.SecuritySettings;

            // Setting one of the passwords automatically sets the security level to
            // PdfDocumentSecurityLevel.Encrypted128Bit.
            securitySettings.UserPassword = userpassword.Trim();
            securitySettings.OwnerPassword = ownerpassword.Trim();

            // Don't use 40 bit encryption unless needed for compatibility
            //securitySettings.DocumentSecurityLevel = PdfDocumentSecurityLevel.Encrypted40Bit;

            // Restrict some rights.
            securitySettings.PermitAccessibilityExtractContent = false;
            securitySettings.PermitAnnotations = false;
            securitySettings.PermitAssembleDocument = false;
            securitySettings.PermitExtractContent = false;
            securitySettings.PermitFormsFill = true;
            securitySettings.PermitFullQualityPrint = false;
            securitySettings.PermitModifyDocument = false;
            securitySettings.PermitPrint = true;

            // Save the document...
            MemoryStream dataEncrypted = new MemoryStream();
            document.Save(dataEncrypted, true);
            byte[] bytes = dataEncrypted.ToArray();

            data.Close();
            dataEncrypted.Close();

            return bytes;
        }
    }
}