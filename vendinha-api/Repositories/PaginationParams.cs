namespace Api.Repositories;

public class PaginationParams
{
    private int _maxLinesPerPage = 10;
    private int linesPerPage;
    
    public int page { get; set; } = 1;

    public int ItemsPerPage
    {
        get => linesPerPage;
        set => linesPerPage = value > _maxLinesPerPage ? _maxLinesPerPage: value;
    }
}