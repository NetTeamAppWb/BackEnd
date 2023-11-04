namespace Domain;

public interface IUserDomain
{
    bool create(string email);
    bool update(string password, string email);
    bool delete(string password);
}