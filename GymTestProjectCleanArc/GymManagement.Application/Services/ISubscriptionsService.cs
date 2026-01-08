namespace GymManagement.Application.Services;

public interface ISubscriptionsService
{
    Guid CrateSubscription(string subscriptionType, Guid admin);
}