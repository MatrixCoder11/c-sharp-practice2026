
public interface IHealthObserver
{
    void OnHealthChanged(int currentHp, int damage);
}

public class Player
{
    private readonly List<IHealthObserver> _observers = new();
    private int _hp;
    public int Hp => _hp;

    public Player(int startHp)
    {
        _hp = startHp;
        Console.WriteLine($"[Player] створено з {_hp} HP\n");
    }

    public void Subscribe(IHealthObserver observer) => _observers.Add(observer);
    public void Unsubscribe(IHealthObserver observer) => _observers.Remove(observer);

    public void TakeDamage(int damage)
    {
        if (_hp <= 0) return;

        int actualDamage = Math.Min(damage, _hp);
        _hp -= actualDamage;

        Console.WriteLine($"── Player отримав {actualDamage} урону → HP: {_hp} ──");
        Notify(actualDamage);
        Console.WriteLine();
    }

    private void Notify(int damage)
    {
        foreach (var observer in _observers)
            observer.OnHealthChanged(_hp, damage);
    }
}

public class UIHealthBar : IHealthObserver
{
    public void OnHealthChanged(int currentHp, int damage)
    {
        int barMax = 100;
        int filled = Math.Max(currentHp, 0);
        string bar = $"[{" ".PadRight(filled / 5, ' ').PadRight(barMax / 5, ' ')}]";
        Console.WriteLine($"  [UIHealthBar] HP: {bar} {currentHp}/100");
    }
}

public class SoundSystem : IHealthObserver
{
    public void OnHealthChanged(int currentHp, int damage)
    {
        Console.WriteLine("  [SoundSystem]  Відтворюється: hurt.wav");

        if (currentHp <= 20)
            Console.WriteLine("  [SoundSystem]  Відтворюється: critical_warning.wav");
    }
}

public class AchievementSystem : IHealthObserver
{
    private bool _halfHealthUnlocked;
    private bool _firstDeathUnlocked;

    public void OnHealthChanged(int currentHp, int damage)
    {
        if (currentHp <= 50 && !_halfHealthUnlocked)
        {
            _halfHealthUnlocked = true;
            Console.WriteLine("  [AchievementSystem]  Досягнення отримано: \"Half Health\"");
        }

        if (currentHp <= 0 && !_firstDeathUnlocked)
        {
            _firstDeathUnlocked = true;
            Console.WriteLine("  [AchievementSystem]  Досягнення отримано: \"First Death\"");
        }
    }
}

public class GameLogger : IHealthObserver
{
    private int _eventIndex;

    public void OnHealthChanged(int currentHp, int damage)
    {
        _eventIndex++;
        Console.WriteLine($"  [GameLogger] #{_eventIndex:D3} | Отримано урону: {damage} | Поточне HP: {currentHp}");
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var player = new Player(100);
        var uiHealthBar = new UIHealthBar();
        var soundSystem = new SoundSystem();
        var achievementSystem = new AchievementSystem();
        var gameLogger = new GameLogger();

        player.Subscribe(uiHealthBar);
        player.Subscribe(soundSystem);
        player.Subscribe(achievementSystem);
        player.Subscribe(gameLogger);

        player.TakeDamage(20);   
        player.TakeDamage(35);   
        player.TakeDamage(20);  
        player.TakeDamage(10);   
        player.TakeDamage(15);   
        player.TakeDamage(10);   
    }
}