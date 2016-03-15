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
using System.Threading.Tasks;
using BeGlobal.Services;
using Microsoft.AspNet.Mvc;

namespace BeGlobal.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        private readonly IAdminNotifier adminNotifier;

        public HomeController(IAdminNotifier adminNotifier)
        {
            this.adminNotifier = adminNotifier;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            //await this.adminNotifier.NotifyAsync("Someone visited BeGlobal.me");
            return this.View();
        }
        
        [HttpGet("OpensourceAttributions")]
        public IActionResult OpensourceAttributions() => this.View();
    }
}