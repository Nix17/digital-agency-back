namespace Application.DTO.GraphData;

public class GraphDate
{
    public DateTime Date { get; set; }
}

public class GraphDataDTO
{
    public List<int> Offers { get; set; } = new List<int>();
    public List<int> Orders { get; set; } = new List<int>();
}
