// <copyright company="Oswald MASKENS" file="EmailAdminNotifier.cs">
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
using BeGlobal.Config;
using Microsoft.Extensions.OptionsModel;
using SendGrid;

namespace BeGlobal.Services
{
    /// <summary>
    ///     A service to notify the admin by email
    /// </summary>
    public class EmailAdminNotifier : IAdminNotifier
    {
        private readonly AdminContactInfo adminContactInfo;
        private readonly SendGridConfig sendGridSettings;
        private readonly Web sendGridApi;

        public EmailAdminNotifier(IOptions<SendGridConfig> sendGridConfiguration,
            IOptions<AdminContactInfo> adminContactInfo)
        {
            this.adminContactInfo = adminContactInfo.Value;
            this.sendGridSettings = sendGridConfiguration.Value;
            this.sendGridApi = new Web(sendGridConfiguration.Value.Key);
        }

        public async Task NotifyAsync(string message)
        {
            var email = new SendGridMessage
            {
                From = this.sendGridSettings.NoReply,
                To = new[] {this.adminContactInfo.MailAddress},
                Subject = "[BeGlobal.me] Admin Notification",
                Html = "<html><body>Someone visited BeGlobal.me at " + DateTime.Now.ToLongTimeString() + "<body><html>"
            };

            await this.sendGridApi.DeliverAsync(email);
        }
    }
}