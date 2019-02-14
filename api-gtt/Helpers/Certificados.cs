//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Linq;
//using System.Reflection;
///* INIPETI2017-19666-01 KALONSO ** 12/02/2018 ** Consulta acceso SIT tarjeta criptografica */
//using System.Security.Cryptography;
///* FINPETI2017-19666-01 KALONSO ** 12/02/2018 ** Consulta acceso SIT tarjeta criptografica */
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading;
//using System.Windows.Forms;
///* INIPETI2016-04375-01 JAOSUNA ** 29/02/2016 ** Ayto.Santander: Incidencia escaneado por componentesSIT */
//using log4net;
///* FINPETI2016-04375-01 JAOSUNA ** 29/02/2016 ** Ayto.Santander: Incidencia escaneado por componentesSIT */

//namespace GttApp
//{
//    public class EntradaCert : Entrada
//    {
//        public string ObjEntrada;
//    }
//    [Serializable]
//    public class Certificados
//    {
//        private AppDomain oDomain;
        
//        /* INIPETI2016-04375-01 JAOSUNA ** 29/02/2016 ** Ayto.Santander: Incidencia escaneado por componentesSIT */
//        private static readonly ILog log =
//            LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
//        /* FINPETI2016-04375-01 JAOSUNA ** 29/02/2016 ** Ayto.Santander: Incidencia escaneado por componentesSIT */

//        public bool ValidarCertificado(string thumbprint)
//        {
//            bool result = false;

//            try
//            {
//                X509Store store = new X509Store("My", StoreLocation.CurrentUser);
//                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
//                X509Certificate2Collection collection = store.Certificates;
//                X509Certificate2Collection foundCollection = collection.Find(X509FindType.FindByThumbprint, thumbprint, true);
//                string cadena = "hola";
//                if (foundCollection.Count > 0)
//                {
//                    X509Certificate2 objCert = new X509Certificate2(foundCollection[0]);
//                    RSACryptoServiceProvider csp = new RSACryptoServiceProvider();
//                    csp = (RSACryptoServiceProvider)objCert.PrivateKey;
//                    SHA1Managed sha1 = new SHA1Managed();
//                    UnicodeEncoding encoding = new UnicodeEncoding();
//                    byte[] datos = encoding.GetBytes(cadena);
//                    byte[] hash = sha1.ComputeHash(datos);

//                    csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
//                    result =  true;
//                }
//                else
//                {
//                    result =  false;
//                }
//            }
//            catch (Exception ex)
//            {
//                log.Error(new StringBuilder().Append("Error al validar el certificado: ").Append(ex.Message).Append("-").Append(ex.StackTrace));
//                result =  false;
//            }

//            return result;
//        }

//        public List<Object> ObtenerCertificados()
//        {
//            /* INIPETI2016-04375-01 JAOSUNA ** 29/02/2016 ** Ayto.Santander: Incidencia escaneado por componentesSIT */
//            log.Debug("Obteniendo certificados del S.O");
//            /* FINPETI2016-04375-01 JAOSUNA ** 29/02/2016 ** Ayto.Santander: Incidencia escaneado por componentesSIT */
//            string json = "[";
//            List<Object> certs = new List<Object>();
//            try
//            {
//                X509Store store = new X509Store("My", StoreLocation.CurrentUser);
//                store.Open(OpenFlags.ReadOnly | OpenFlags.OpenExistingOnly);
//                X509Certificate2Collection collection = (X509Certificate2Collection)store.Certificates;
                

//                foreach (X509Certificate2 x509 in collection)
//                {
//                    string subject = x509.Subject;
//                    string thumbprint = x509.Thumbprint;
//                    string issuer = x509.Issuer;
//                    string notBefore = x509.NotBefore.ToShortDateString();
//                    string notAfter = x509.NotAfter.ToShortDateString();

//                    certs.Add(new { Subject = subject, Thumbprint = thumbprint, Issuer = issuer, NotBefore = notBefore, NotAfter = notAfter });

//                    //json += "{Subject:'" + subject + "', Thumbprint : '" + thumbprint + "', Issuer : '" + issuer + "',";
//                    //json += "NotBefore:'" + notBefore + "', NotAfter : '" + notAfter + "'},";
//                }



//            }
//            /* INIPETI2016-04375-01 JAOSUNA ** 29/02/2016 ** Ayto.Santander: Incidencia escaneado por componentesSIT */
//            //                      catch
//            //            {
//            //    return new List<Object>(); 
//            //}
//            catch (Exception ex)
//            {
//                log.Error(new StringBuilder().Append("Error en el método ObtenerCertificados: ").Append(ex.Message).Append("-").Append(ex.StackTrace));
//                return new List<Object>();
//            }
//            /* FINPETI2016-04375-01 JAOSUNA ** 29/02/2016 ** Ayto.Santander: Incidencia escaneado por componentesSIT */
//            json += "]";
//            //return json;
//            return certs;
//        }
//    }
//}
