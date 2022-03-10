namespace Registry.Api.Billing.Dto.Responses
{
	public class AssignResponse
	{
		public bool IsAllowed { get; set; }

		public string? RejectReason { get; set; }
	}
}
