namespace Data;

public interface IUserData
{
    public string GetByPayMethod(string payMethod);
    public string[] GetALL();
}