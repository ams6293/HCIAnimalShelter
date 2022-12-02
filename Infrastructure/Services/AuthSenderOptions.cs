using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AuthSenderOptions
    {
        //Name to show up in From on the email
        private readonly string user = "Animal Rescue Demo";

        private readonly string key = "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";

        public string SendGridUser { get { return user; } }
        public string SendGridKey { get { return key; } }
    }
}
