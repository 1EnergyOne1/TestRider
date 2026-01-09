using MediatR;
using ErrorOr;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Commands.CreateSubscription;

public record CreateSubscriptionCommand(
    string SubscriptionType, Guid AdminId) : IRequest<ErrorOr<Subscription>>;