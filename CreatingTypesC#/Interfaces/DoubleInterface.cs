public interface IMovable
{
    void Move();
}

public interface IAttackable
{
    void Attack();
}

// Class bisa implement lebih dari satu interface
public class Robot : IMovable, IAttackable
{
    public void Move() => Console.WriteLine("Robot moving...");
    public void Attack() => Console.WriteLine("Robot attacking!");
}