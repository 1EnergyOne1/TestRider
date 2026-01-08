using GymManagement.Application.Services;
using GymManagement.Contracts.Subscriptions;
using Microsoft.AspNetCore.Mvc;

namespace GymManagement.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SubscriptionsController : ControllerBase
{
    private readonly ISubscriptionsService _subscriptionsService;

    public SubscriptionsController(ISubscriptionsService subscriptionsService)
    {
        _subscriptionsService = subscriptionsService;
    }
    
    [HttpPost]
    public IActionResult CreateSubscription(CreateSubscriptionRequest request)
    {
        var subscriptionId = _subscriptionsService.CrateSubscription(
            request.SubscriptionType.ToString(), request.Admin);
        var response = new SubscriptionResponse(subscriptionId, request.SubscriptionType);
        return Ok(response);
    }
}