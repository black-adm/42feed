using Common;
using Domain.Enums;
using Domain.Interfaces;

namespace Domain.Entities.Feedbacks;

public sealed class Feedback : Entity, IAggregateRoot
{
    public FeedbackTypes Type { get; private set; } = FeedbackTypes.PENDING;

    public string Context { get; private set; } = string.Empty;

    public string Behavior { get; private set; } = string.Empty;

    public string Consequence { get; private set; } = string.Empty;

    public string Considerations { get; private set; } = string.Empty;

    public string Combined { get; private set; } = string.Empty;

    public string Contribuition { get; private set; } = string.Empty;

    public string CompanyValue { get; private set; } = string.Empty;

    public string CompanyValueDescription { get; private set; } = string.Empty;
}
