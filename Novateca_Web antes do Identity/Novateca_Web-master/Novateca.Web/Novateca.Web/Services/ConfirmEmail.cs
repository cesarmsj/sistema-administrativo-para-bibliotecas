using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Threading.Tasks;

namespace Novateca.Web.Services
{
    public class ConfirmEmail
    {

        //aqui explica como implementar este serviço: http://www.macoratti.net/15/10/mvc_cnfrec1.htm
/*
        private static void Main()
        {
            Execute().Wait();
        }
*/
        static async Task Execute()
        {
            var apiKey = Environment.GetEnvironmentVariable("SENDGRID_API_KEY");
            var client = new SendGridClient(apiKey);
            var msg = new SendGridMessage()
            {
                From = new EmailAddress("cesarsj@unipam.edu.br", "novateca2018"),
                Subject = "Seja bem-vindo ao Novateca ;D",
                PlainTextContent = "Hello, Email!",
                HtmlContent = "<strong>Hello, Email!</strong>"
            };
          //  msg.AddTo(new EmailAddress("elmer.thomas@sendgrid.com", "Test User"));
          //  byte[] excelArray = System.IO.File.ReadAllBytes(@"/Users/ethomas/Downloads/Book 2.xlsx");
          //  string base64ExcelRepresentation = Convert.ToBase64String(excelArray);
          //  msg.AddAttachment("Sheet.xlsx", base64ExcelRepresentation, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            var response = await client.SendEmailAsync(msg);
        }
    }
}
