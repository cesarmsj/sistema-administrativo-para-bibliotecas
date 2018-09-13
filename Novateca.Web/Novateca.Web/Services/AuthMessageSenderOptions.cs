using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novateca.Web.Services
{
    public class AuthMessageSenderOptions
    {
        // referência: https://docs.microsoft.com/pt-br/aspnet/core/security/authentication/accconfirm?view=aspnetcore-2.1&tabs=visual-studio
        public string SendGridUser { get; set; }
        public string SendGridKey { get; set; }
    }
}
