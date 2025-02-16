namespace ManagementSystem.Common.Exceptions;

public class NotFoundException:Exception
{
    public NotFoundException(Type type , int id ) : base($"{type.Name} not found {id} ")
    {

    }
}
