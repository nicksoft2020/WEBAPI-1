using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApi.JWT
{
    public class ApplicationSettings
    {
        public string JWT_Secret { get; set; }
        public string Client_Url { get; set; }
    }
}
