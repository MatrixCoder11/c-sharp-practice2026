
public interface ITemperatureObserver
{
    void Update(double temperature);
}

public class TemperatureSensor
{
    
    private readonly List<ITemperatureObserver> _observers = new();
    private double _temperature;

    
    public void Subscribe(ITemperatureObserver observer)
    {
        _observers.Add(observer);
    }

    
    public void Unsubscribe(ITemperatureObserver observer)
    {
        _observers.Remove(observer);
    }

    
    public void SetTemperature(double temperature)
    {
        _temperature = temperature;
        Console.WriteLine($"\n[Sensor] Температура змінилась на: {temperature}°C");
        Notify();
    }

    
    private void Notify()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_temperature);
        }
    }
}

public class Display : ITemperatureObserver
{
    public void Update(double temperature)
    {
        Console.WriteLine($"  [Display] Поточна температура: {temperature}°C");
    }
}

public class AirConditioner : ITemperatureObserver
{
    public void Update(double temperature)
    {
        if (temperature < 17)
        {
            Console.WriteLine("  [AirConditioner] Увімкнено ОБІГРІВ");
        }
        else if (temperature <= 25)
        {
            Console.WriteLine("  [AirConditioner] Вимкнено (комфортна температура)");
        }
        else
        {
            Console.WriteLine("  [AirConditioner] Увімкнено ОХОЛОДЖЕННЯ");
        }
    }
}

public class SecuritySystem : ITemperatureObserver
{
    public void Update(double temperature)
    {
        if (temperature > 40)
        {
            Console.WriteLine(" УВАГА: Небезпечний ПЕРЕГРІВ!");
        }
        else if (temperature < 5)
        {
            Console.WriteLine(" ПОПЕРЕДЖЕННЯ: Ризик ЗАМЕРЗАННЯ систем!");
        }

    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        var sensor = new TemperatureSensor();

        var display = new Display();
        var airCon = new AirConditioner();
        var security = new SecuritySystem();

        sensor.Subscribe(display);
        sensor.Subscribe(airCon);
        sensor.Subscribe(security);

        sensor.SetTemperature(22);   
        sensor.SetTemperature(10);   
        sensor.SetTemperature(30);   
        sensor.SetTemperature(45);   
        sensor.SetTemperature(3);    
    }
}