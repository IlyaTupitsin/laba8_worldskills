

public class GenericArray<T> 
{
    private T[] array;
    private int length;

    public GenericArray(int size)
    {
        array = new T[size];
        length = size;
    }
        public void Adding_data(int index, T element)
    {
        if (index >= 0 && index < length)
        {
            array[index] = element;
        }
        else
        {
            Console.WriteLine("Недопустимый индекс.");
        }
    }

    public void Remove_items(int index)
    {
        if (index >= 0 && index < length)
        {
            array[index] = default(T);
        }
        else
        {
            Console.WriteLine("Недопустимый индекс.");
        }
    }

    public T GetElement(int index)
    {
        if (index >= 0 && index < length)
        {
            return array[index];
        }
        Console.WriteLine("Недопустимый индекс.");
        return default(T);
    }

    public int GetLength()
    {
        return length;
    }
}
class PasswordArray: GenericArray<string>
{
    public PasswordArray(int size) : base(size) { }
}
class LoginArray : GenericArray<string>
{
    public LoginArray(int size) : base(size) { }
}
class User
{
    public string Login { get; set; }
    public string Password { get; set; }

    public User(string login, string password)
    {
        Login = login;
        Password = password;
    }
}
class Program
{
    static void Main()
    {
        LoginArray logins = new LoginArray(10);
        PasswordArray passwords = new PasswordArray(10);

        RegisterUser(logins, passwords, "user1", "pass1");
        RegisterUser(logins, passwords, "user2", "pass2");

         void RegisterUser(LoginArray logins, PasswordArray passwords, string login, string password)
        {
            int index = FindEmptyIndex(logins);
            if (index != -1)
            {
                logins.Adding_data(index, login);
                passwords.Adding_data(index, password);
                Console.WriteLine(login + " зарегистрирован.");
            }
            else
            {
                Console.WriteLine("НЕТ МЕСТА.");
            }
        }
         int FindEmptyIndex(GenericArray<string> array)
        {
            for (int i = 0; i < array.GetLength(); i++)
            {
                if (array.GetElement(i) == null)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}