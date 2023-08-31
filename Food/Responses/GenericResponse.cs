namespace Food.Responses;

public class GenericResponse<T>
{
    public string ResponseCode { get; set; }
    public string ResponseMsg { get; set; }
    public T Data { get; set; }
}