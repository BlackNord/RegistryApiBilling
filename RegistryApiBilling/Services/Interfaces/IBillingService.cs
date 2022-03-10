using Registry.Api.Billing.Dto.Requests;
using Registry.Api.Billing.Dto.Responses;

namespace Registry.Api.Billing.Services.Interfaces
{
	public interface IBillingService
	{
		Task<AssignResponse> Assign(AssignRequest request);
	}
}
