using MediatR;
using PCPartsShop.Application.Abstract;
using PCPartsShop.Domain.Dtos;
using PCPartsShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PCPartsShop.Application.Commands.EmailCommands
{
    public class CreateEmailWithOrderCommandHandler : IRequestHandler<CreateEmailWithOrderCommand, BrevoAPIResponseDto>
    {
        private readonly IEmailProvider _emailProvider;
        public CreateEmailWithOrderCommandHandler(IEmailProvider emailProvider)
        {
            _emailProvider = emailProvider;
        }
        public async Task<BrevoAPIResponseDto> Handle(CreateEmailWithOrderCommand request, CancellationToken cancellationToken)
        {
            var emailContent = GetHtmlTemplate(request.Order);
            BrevoEmailProviderDto emailToSend = new BrevoEmailProviderDto
            {
                Sender = new SenderDto
                {
                    Email = "noreply@bit-smith.org",
                    Name = "BitSmith"
                },
                Subject = $"Your order confirmation. Order reference: #{request.Order.OrderId}",
                To = new List<ReceiverDto>
                {
                    new ReceiverDto
                    {
                        Email = request.Order.UserEmail,
                        Name = request.Order.UserFirstName + " " + request.Order.UserLastName,
                    }
                },
                HtmlContent = emailContent
            };
            var emailResponse = await _emailProvider.SendEmail(emailToSend);
            return await Task.FromResult(emailResponse); 
        }

        #region private methods
        private string GetHtmlTemplate(Order order)
        {
            var html = @"
            <!DOCTYPE html>
<html>
<head>
    <meta charset=""UTF-8"">
    <title>Order Confirmation</title>
</head>
<body>
    <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"">
        <tr>
            <td align=""center"" bgcolor=""#f9f9f9"" style=""padding: 40px 0;"">
                <h1>Order Confirmation</h1>
            </td>
        </tr>
        <tr>
            <td align=""center"" bgcolor=""#ffffff"" style=""padding: 40px 0;"">
                <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""600"">
                    <tr>
                        <td>
                            <h2>Thank you for your order!</h2>
                            <p>We're excited to let you know that your order has been successfully placed and is being processed.</p>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <h3>Order Details</h3>
                            <table cellpadding=""0"" cellspacing=""0"" border=""0"" width=""100%"">
                                <tr>
                                    <th align=""left"">Item</th>
                                    <th align=""left"">Component</th>
                                    <th align=""left"">Quantity</th>
                                    <th align=""right"">Price</th>
                                </tr>";

            foreach (var item in order.Items)
            {
                html += $@"<tr>
                            <td>{item.ComponentMake} {item.ComponentModel}</td>
                            <td>{item.ComponentType}</td>
                            <td>{item.OrderItemQuantity}</td>
                            <td align=""right"">${item.ComponentPrice}</td>
                          </tr>";
            }
            html += $@"<tr>
                        <td colspan=""4"" align=""right""><strong>Total: ${order.TotalPrice}</strong></td>
                       </tr>";
            html += $@"</table>
                        </td>
                        </tr>
                        </table>
                        </td>
                        </tr>
                        <tr>
            <td align=""center"" bgcolor=""#f9f9f9"" style=""padding: 40px 0;"">
                <p>If you have any questions about your order, please contact our customer support.</p>
                <p>Thank you for shopping with us!</p>
                <img align=""center"" bgcolor=""#f9f9f9"" style=""width: 200px; height: 184px"" src=""https://i.ibb.co/S03BMsX/Bit-Smith-Logo-Background-Removed.png""/>
                <p>All rights reserved.</p>
            </td>
        </tr>
    </table>
</body>
</html>";

            return html;
        }
        #endregion
    }
}
