using Common;
using Domain.Entities.Feedbacks;
using Domain.Interfaces;

namespace Domain.Entities.Boards;

public sealed class Board : Entity, IAggregateRoot
{
    private readonly List<string> _documentsUrl = [];

    private readonly List<string> _comments = [];

    private readonly List<int> _likes = [];

    public Guid UserId { get; private set; }

    public Guid FeedbackId { get; private set; }

    public string Content { get; private set; } = string.Empty;

    public bool IsTrending { get; private set; } = false;

    public bool IsVisibleForAll { get; private set; } = false;

    public IReadOnlyCollection<string> Documents => _documentsUrl;

    public IReadOnlyCollection<string> Comments => _comments;

    public IReadOnlyCollection<int> Likes => _likes;

    public User User { get; private set; } = null!;

    public Feedback Feedback { get; private set; } = null!;

    private Board()
    {
    }

    private Board(Guid userId, Guid feedbackId, string content)
    {
        UserId = userId;
        FeedbackId = feedbackId;
        Content = content;
    }

    public static Board Create(Guid userId, Guid feedbackId, string content)
    {
        return new Board(userId, feedbackId, content);
    }

    public void Update(Guid boardId, Guid userId, string content)
    {
        if (Id != boardId || UserId != userId)
        {
            return;
        }

        Content = content;
    }

    public void AddDocuments(Guid boardId, Guid userId, string documentUrl)
    {
        if (Id != boardId || UserId != userId)
        {
            return;
        }

        _documentsUrl.Add(documentUrl);
    }

    public void AddComments(Guid boardId, Guid userId, string comment)
    {
        if (Id != boardId || UserId != userId)
        {
            return;
        }

        _comments.Add(comment);
    }

    public void AddLikes(Guid boardId, Guid userId, int like)
    {
        if (Id != boardId || UserId == userId || _likes.Contains(userId.GetHashCode()))
        {
            return;
        }

        var totalLikes = _likes.Count + like;
        _likes.AddRange(totalLikes);
    }

    public void SetIsTrending() => IsTrending = true;

    public void SetVisibleForAll() => IsVisibleForAll = true;

    public void SetAsDisable(Guid boardId) => Deactivate(boardId);
}
