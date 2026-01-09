using MediatR;
using ErrorOr;
using GymManagement.Application.Common.Interfaces;
using GymManagement.Domain.Subscriptions;

namespace GymManagement.Application.Commands.CreateSubscription;

public class CreateSubscriptionCommandHandler : IRequestHandler<CreateSubscriptionCommand, ErrorOr<Subscription>>
{
    private readonly ISubscriptionsRepository _subscriptionsRepository;

    public CreateSubscriptionCommandHandler(ISubscriptionsRepository subscriptionrepository)
    {
        _subscriptionsRepository = subscriptionrepository;
    }
    
    public async Task<ErrorOr<Subscription>> Handle(CreateSubscriptionCommand request, CancellationToken cancellationToken)
    {
        var subscription = new Subscription
        {
            Id = Guid.NewGuid()
        };

        _subscriptionsRepository.AddSubscription(subscription);
        return subscription;
    }
}