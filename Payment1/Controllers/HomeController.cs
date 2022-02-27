using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Parbad;
using Parbad.AspNetCore;
using Payment1.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Payment1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IOnlinePayment _onlinePayment;

        public HomeController(ILogger<HomeController> logger, IOnlinePayment onlinePayment)
        {
            _logger = logger;
            _onlinePayment = onlinePayment;
        }

        public async Task<IActionResult> Pay()
        {
            var result = await _onlinePayment.RequestAsync(Parbad.Gateway.ParbadVirtual.ParbadVirtualGateway.Name, 123, 25000, Url.Action("verify", "Home", null, Request.Scheme));

            if (result.IsSucceed)
            {
                // Save the TrackingNumber inside your database.

                // It will redirect the client to the gateway.
                return result.GatewayTransporter.TransportToGateway();
            }
            else
            {
                // The request was not successful. You can see the Message property for more information.
                return null;

            }
        }
        public async Task<IActionResult> Verify()
        {
            var invoice = await _onlinePayment.FetchAsync();

            if (invoice.Status != PaymentFetchResultStatus.ReadyForVerifying)
            {
                // Check if the invoice is new or it's already processed before.
                var isAlreadyVerified = invoice.IsAlreadyVerified;
                return Content("The payment was not successful.");
            }

            // An example of checking the invoice in your website.
            if (!Is_There_Still_Product_In_Shop(invoice.TrackingNumber))
            {
                var cancelResult = await _onlinePayment.CancelAsync(invoice, cancellationReason: "Sorry, We have no more products to sell.");

                return View("CancelResult", cancelResult);
            }

            var verifyResult = await _onlinePayment.VerifyAsync(invoice);
            if (verifyResult.IsSucceed)
            {

            }

            return View(verifyResult);
        }
        private static bool Is_There_Still_Product_In_Shop(long TrackingNumber)
        {
            return true;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
