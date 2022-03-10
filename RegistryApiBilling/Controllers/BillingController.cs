using Microsoft.AspNetCore.Mvc;
using Registry.Api.Billing.Dto.Requests;
using Registry.Api.Billing.Services.Interfaces;

namespace Registry.Api.Billing.Controllers
{
	[ApiController]
	[Route("billing")]
	public class BillingController : ControllerBase
	{
		private readonly IBillingService billingService;

		public BillingController(IBillingService billingService)
		{
			this.billingService = billingService;
		}

		[HttpPost]
		public async Task<ActionResult> Assign(AssignRequest request)
		{
			var result = await billingService.Assign(request);
			return Ok(result);
		}
	}
}
