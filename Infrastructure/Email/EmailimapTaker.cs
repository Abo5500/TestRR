using Application.Interfaces;
using MailKit.Net.Imap;
using MailKit.Search;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Email
{
    public class EmailImapTaker : IEmailTaker
    {
        private readonly EmailOptions _emailOptions;

        public EmailImapTaker(IOptions<EmailOptions> emailOptions)
        {
            _emailOptions = emailOptions.Value;
        }

        //TODO: сделать возврат потока, а не строки
        public async Task LoadFileAsync(string senderEmail, string path)
        {
            using var client = new ImapClient();
            await client.ConnectAsync(_emailOptions.Host, 993, MailKit.Security.SecureSocketOptions.SslOnConnect);
            await client.AuthenticateAsync(_emailOptions.Email, _emailOptions.AppPassword);

            await client.Inbox.OpenAsync(MailKit.FolderAccess.ReadOnly);
            var uids = await client.Inbox.SearchAsync(SearchQuery.FromContains(senderEmail));
            for(int i = uids.Count-1; i > 0; i--)
            {
                var message = await client.Inbox.GetMessageAsync(uids[i]);
                var attachment = message.Attachments.FirstOrDefault(a => a.ContentDisposition.FileName.EndsWith(".csv"));
                if(attachment is not null)
                {
                    using var output = File.Create(path);
                    
                    await ((MimePart)attachment).Content.DecodeToAsync(output);
                }
            }
        }
    }
}
