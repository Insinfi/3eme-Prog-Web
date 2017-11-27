using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Org.BouncyCastle.Asn1.X509;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Generators;
using Org.BouncyCastle.Math;
using Org.BouncyCastle.Pkcs;
using Org.BouncyCastle.Security;
using Org.BouncyCastle.X509;
using Org.BouncyCastle.Asn1.Pkcs;

namespace Crypto.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private string PublicKey;
        public ActionResult Index()
        {
            Session["keyPair"] = GenerateKey();
            ViewBag.publicKey = PublicKey;
            return View();
        }
        
        public AsymmetricCipherKeyPair GenerateKey()
        {
            RsaKeyPairGenerator kpGenerator = new RsaKeyPairGenerator();
            kpGenerator.Init(new KeyGenerationParameters(new SecureRandom(), 512));
            var keyPair = kpGenerator.GenerateKeyPair();
            //PrivateKeyInfo pkInfo = PrivateKeyInfoFactory.CreatePrivateKeyInfo(keyPair.Private);
            //PrivateKey = Convert.ToBase64String(pkInfo.GetDerEncoded());
            SubjectPublicKeyInfo info = SubjectPublicKeyInfoFactory.CreateSubjectPublicKeyInfo(keyPair.Public);
            PublicKey = Convert.ToBase64String(info.GetDerEncoded());
            return keyPair;
        }

        public void Decode(string id)
        {
            if (Session["KeyPair"] != null)
            {
                AsymmetricCipherKeyPair keyPair = (AsymmetricCipherKeyPair)Session["keyPair"];
                IBufferedCipher cipher = CipherUtilities.GetCipher("RSA/NONE/PKCSPadding");
                cipher.Init(false, keyPair.Private);
                byte[] secretBytes = Convert.FromBase64String(id);
                byte[] decrypted = cipher.DoFinal(secretBytes);
                var data = System.Text.Encoding.UTF8.GetString(decrypted);
            }
        }
    }
}