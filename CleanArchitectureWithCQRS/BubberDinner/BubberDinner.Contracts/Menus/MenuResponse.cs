namespace BubberDinner.Contracts.Menus
{
    public record MenuResponse(
        string Id,
        string Name,
        string Description,
        float? AverageRating,
        string HostId,
        List<MenuSectionResponse> MenuSections,
        List<string> DinnerIds,
        List<string> MenuReviewIds,
        DateTime CreatedDatetTime,
        DateTime UpdatedDatetTime
        );

    public record MenuSectionResponse(
        string Id,
        string Name,
        string Description,
        List<MenuItemResponse> Items
        );

    public record MenuItemResponse(
       string Id,
       string Name,
       string Description);
}
