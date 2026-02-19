using Common;
using Domain.Entities.Companies;
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

    public Company Company { get; private set; } = null!;

    public User User { get; private set; } = null!;

    private Feedback()
    {
    }

    private Feedback(
        FeedbackTypes type,
        string context,
        string behavior,
        string consequence,
        string considerations,
        string combined,
        string contribuition,
        string companyValue,
        string companyValueDescription,
        Company company,
        User user)
    {
        Type = type;
        Context = context;
        Behavior = behavior;
        Consequence = consequence;
        Considerations = considerations;
        Combined = combined;
        Contribuition = contribuition;
        CompanyValue = companyValue;
        CompanyValueDescription = companyValueDescription;
        Company = company;
        User = user;
    }

    public static Feedback Create(
        FeedbackTypes type,
        string context,
        string behavior,
        string consequence,
        string considerations,
        string combined,
        string contribuition,
        string companyValue,
        string companyValueDescription,
        Company company,
        User user)
    {
        return new Feedback(
            type,
            context,
            behavior,
            consequence,
            considerations,
            combined,
            contribuition,
            companyValue,
            companyValueDescription,
            company,
            user);
    }

    public void Update(
        Guid companyId,
        Guid userId,
        FeedbackTypes type,
        string context,
        string behavior,
        string consequence,
        string considerations,
        string combined,
        string contribuition,
        string companyValue,
        string companyValueDescription)
    {
        Type = type;
        Context = context;
        Behavior = behavior;
        Consequence = consequence;
        Considerations = considerations;
        Combined = combined;
        Contribuition = contribuition;
        CompanyValue = companyValue;
        CompanyValueDescription = companyValueDescription;
    }

    public void SetAsDisable(Guid feedbackId) => Deactivate(feedbackId);
}
