// <copyright company="Oswald MASKENS" file="HomeController.cs">
// Copyright 2014-2016 Oswald MASKENS
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with the License. You may obtain a copy of the License at
// 
//  http://www.apache.org/licenses/LICENSE-2.0
//  
// Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the specific language governing permissions and limitations under the License.
// </copyright>

using System;
using System.Net.Mail;
using System.Threading.Tasks;
using BeGlobal.Configuration;
using Microsoft.AspNet.Mvc;
using Microsoft.Extensions.OptionsModel;
using SendGrid;

namespace BeGlobal.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<SendGridConfiguration> sendGridConfiguration;

        public HomeController(IOptions<SendGridConfiguration> sendGridConfiguration)
        {
            this.sendGridConfiguration = sendGridConfiguration;
        }

        // GET: /
        public async Task<IActionResult> Index()
        {
            var email = new SendGridMessage
            {
                From = new MailAddress("no-reply@beglobal.me", "BeGlobal.me No-Reply"),
                To = new[] {new MailAddress("oswald.maskens@outlook.com")},
                Subject = "Someone visited BeGlobal.me",
                Html = "<html><body>Someone visited BeGlobal.me at " + DateTime.Now.ToLongTimeString() + "<body><html>"
            };

            var transportWeb = new Web(this.sendGridConfiguration.Value.Key);
            await transportWeb.DeliverAsync(email);

            return this.View();
        }

        // GET: /Home/Error
        public IActionResult Error() => this.View();
    }
}