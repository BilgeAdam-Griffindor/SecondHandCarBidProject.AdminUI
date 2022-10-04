using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecondHandCarBidProject.ApiService.Concrete
{
    internal class AdminAuthenticationServices
    {
        HttpClient client;
        public AdminAuthenticationServices(HttpClient client)
        {
            this.client = client;
        }

        public async Task LogIn()
        {
            //Deneme
        }
        public async Task LogOut()
        {

        }
        public async Task Register()
        {

        }
        public async Task ForgotPassword()
        {

        }
    }
}
