using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ApiGtt.Models;
using System.Security.Cryptography.X509Certificates;
using System.Security;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiGtt.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : Controller
    {
        private readonly AppDBContext _context;
        private SecureString contraseña;

        public CertificatesController(AppDBContext context)
        {
            this._context = context;

        }
        // GET: api/<controller>
        [HttpGet]
        public ActionResult<List<Certificates>> GetAll()
        {
            return this._context.Certificates.ToList();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public ActionResult<Certificates> Get(long id)
        {
            Certificates certificate = this._context.Certificates.Find(id);
            if (certificate == null)
            {
                return NotFound();
            }
            return certificate;
        }
    

        // POST api/<controller>
        [HttpPost]
        public ActionResult<Certificates> Post([FromBody] Certificates value)

        {
            try
            {
                // Obtenemos el string en base64 y se convierte a byte []

                byte[] arrayBytes = System.Convert.FromBase64String(value.content);

                // Lo cargamos en certificate

                X509Certificate2 certificate = new X509Certificate2(arrayBytes, this.contraseña);

                value.entity = certificate.Issuer;
                value.serialNum = certificate.SerialNumber;
                value.expireDate = certificate.NotAfter;
                value.subject = certificate.Subject;
                var monthsAdded = 1;
                var expireDateCert = value.expireDate.AddMonths(monthsAdded);
                var expireDateNow = DateTime.Now;
                if (expireDateCert >= expireDateNow)
                {
                    value.notice = true;
                }
                value.notice = false;
                value.ticketed = false;
                this._context.Certificates.Add(value);
                this._context.SaveChanges();
                //string token = certificate.ToString(true);               
                return Ok("Certificado agregado con éxito");
            }catch(Exception e)
            {
                return Conflict(e);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        public byte[] FileToByteArray(string fileName)
        {
            byte[] fileContent = null;
           
            System.IO.FileStream fs = new System.IO.FileStream(fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);
            System.IO.BinaryReader binaryReader = new System.IO.BinaryReader(fs);

            long byteLength = new System.IO.FileInfo(fileName).Length;
            fileContent = binaryReader.ReadBytes((Int32)byteLength);
            fs.Close();
            fs.Dispose();
            binaryReader.Close();
            return fileContent;
        }
    }
}
