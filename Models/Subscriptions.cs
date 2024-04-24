using HotChocolate;
using HotChocolate.Types;

public class Subscriptions
{
    [Subscribe]
    public Book BookAdded([EventMessage] Book newBook) => newBook;
}