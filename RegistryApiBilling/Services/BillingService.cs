using Microsoft.Extensions.Options;
using Registry.Api.Billing.Dto.Requests;
using Registry.Api.Billing.Dto.Responses;
using Registry.Api.Billing.Integratiion;
using Registry.Api.Billing.Tools;

using Google.Cloud.PubSub.V1;
using Newtonsoft.Json;

namespace Registry.Api.Billing.Services.Interfaces
{
	public class BillingService : IBillingService
	{
		private readonly GCSettings settings;

		public BillingService(IOptions<GCSettings> settings)
		{
			this.settings = settings.Value;
		}

		public async Task<AssignResponse> Assign(AssignRequest request)
		{
			var result = new AssignResponse
			{
				IsAllowed = BooleanGenerator.NextBoolean(),
				RejectReason = "Reject reason"
			};

			var topic = TopicName.FromProjectTopic(settings.ProjectId, settings.PublishId);
			var publisher = await PublisherClient.CreateAsync(topic);

			var message = JsonConvert.SerializeObject(result);
			await publisher.PublishAsync(message);

			return result;
		}
	}
}
