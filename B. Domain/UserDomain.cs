using Data;

namespace Domain;

public class UserDomain : IUserDomain
{
   

    public bool create(string email)
    {
        if (email == "jorgito@gmail")
        {
            return true;
        }
        else
        {
            return false;
        }

        ;
    }

    public bool update(string password, string email)
    {
        throw new NotImplementedException();
    }

    public bool delete(string password)
    {
        throw new NotImplementedException();
    }
}