namespace GymManagement.Application.Services;

public class SubscriptionsService: ISubscriptionsService
{
    public Guid CrateSubscription(string subscriptionType, Guid admin)
    {
        return Guid.NewGuid();
    }
}