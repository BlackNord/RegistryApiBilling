namespace Registry.Api.Billing.Tools
{
	public static class BooleanGenerator
	{
		public static bool NextBoolean()
		{
			Random rnd = new Random();
			return rnd.Next(0, 2) == 1;
		}
	}
}
