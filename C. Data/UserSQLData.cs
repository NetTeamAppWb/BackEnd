namespace Data;

public class UserSQLData : IUserData
{
  

    public string GetByPayMethod(string payMethod)
    {
        //gestion con sql
        return "return" + payMethod.ToString() + "SQL";
    }

    public string[] GetALL()
    {
        throw new NotImplementedException();
    }
}