using System;
using System.IO;
using PagarMe;

namespace PagarMeAspNet
{
    public partial class ValidateRequest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PagarMeService.DefaultApiKey = "ak_test_qtDOZfF5K0VDn17k04NxnQPIZ3r5wV";

            var postback_body = "" + Request.Form.ToString();
            var signature = "" + Request.Headers["X-Hub-Signature"];
            var fileName = Directory.GetCurrentDirectory() + "\\Log.txt";
            var file = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, 4096, true);
            var Log = new StreamWriter(file);

            Log.WriteLine("***********************************************");
            if (Utils.ValidateRequestSignature(postback_body, signature))
            {
                var current_status = Request.Form["current_status"];
                var transaction_id = Request.Form["transaction[id]"];
                var boleto_url = Request.Form["transaction[boleto_url]"];

                Log.WriteLine(String.Format("Valid Signature ({0})", signature));
                Log.WriteLine(String.Format("Transaction ID: {0}", transaction_id));
                Log.WriteLine(String.Format("Current Status: {0}", current_status));
                Log.WriteLine(String.Format("    Boleto URL: {0}", boleto_url));
            }
            else
                Log.WriteLine(String.Format("Invalid Signature ({0})", signature));
            Log.WriteLine("***********************************************");

            Log.Close();
        }
    }
}