/// <summary>
/// event progress bar untuk UI
/// </summary>

public class Worker
{
    public event EventHandler<int>? ProgressChanged;

    public event Action<string>? ProgressChangedAction;

    protected virtual void OnProgressChanged(int percent)
    {
        ProgressChanged?.Invoke(this, percent);
    }
    protected virtual void OnProgressChangedAction(string percent)
    {
        ProgressChangedAction?.Invoke(percent);
    }

    public void DoWork()
    {
        for (int i = 0; i <= 100; i += 20)
        {
            System.Threading.Thread.Sleep(200);
            OnProgressChanged(i);
        }

        for (int i = 0; i <= 100; i += 20)
        {
            System.Threading.Thread.Sleep(200);
            OnProgressChangedAction(i.ToString() + "HUAHAHA");
        }
    }

    public static void Worker_ProgressChanged(object sender, int percent)
    {
        Console.WriteLine($"Progress: {percent}%");
    }

    public static void Worker_ProgressChanged_Action(string percent)
    {
        Console.WriteLine($"Progress (Action): {percent} %");
    }
}