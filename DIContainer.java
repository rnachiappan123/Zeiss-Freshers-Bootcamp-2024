import java.util.Map;
import java.util.HashMap;

interface DIContainerInterface
{
    <T> void registerService(Class<T> serviceType, T serviceInstance);
    <T> T resolveService(Class<T> serviceType);
}

interface EngineInterface
{
    public void start();
}

interface TransmissionInterface
{
    public void move();
}

interface StartupMotorInterface
{
    public void startup();
}

interface FuelPumpInterface
{
    public void pump();
}

class DIContainer implements DIContainerInterface
{
    Map<Class<?>, Object> serviceInstances = new HashMap<>();
    
    public <T> void registerService(Class<T> serviceType, T serviceInstance) {
        serviceInstances.put(serviceType, serviceInstance);
    }
    
    public <T> T resolveService(Class<T> serviceType) {
        T serviceInstance = (T) serviceInstances.get(serviceType);
        
        if (serviceInstance == null) {
            throw new IllegalArgumentException("No registered instance found for type: " + serviceType.getName());
        }
        
        return serviceInstance;
    }
}

class Car
{
    EngineInterface IEngine;
    TransmissionInterface ITransmission;
    
    Car(EngineInterface engine, TransmissionInterface transmission) {
        IEngine = engine;
        ITransmission = transmission;
    }
    
    public void start() {
        System.out.println("Car started");
    }
}

class Engine implements EngineInterface
{
    StartupMotorInterface IStartupMotor;
    FuelPumpInterface IFuelPump;
    
    Engine(StartupMotorInterface startupmotor, FuelPumpInterface fuelpump) {
        IStartupMotor = startupmotor;
        IFuelPump = fuelpump;
    }
    
    public void start() {
        System.out.println("Engine started");
    }
}

class Transmission implements TransmissionInterface
{
    public void move() {
        System.out.println("move() transmission");
    }
}

class StartupMotor implements StartupMotorInterface
{
    public void startup() {
        System.out.println("startup() motor");
    }
}

class FuelPump implements FuelPumpInterface
{
    public void pump() {
        System.out.println("pump() fuel");
    }
}

class Main
{
    public static void main (String[] args) {
        DIContainerInterface diContainer = new DIContainer();
        
        diContainer.registerService(FuelPumpInterface.class, new FuelPump());
        diContainer.registerService(StartupMotorInterface.class, new StartupMotor());
        diContainer.registerService(TransmissionInterface.class, new Transmission());
        diContainer.registerService(EngineInterface.class, new Engine(diContainer.resolveService(StartupMotorInterface.class), diContainer.resolveService(FuelPumpInterface.class)));
        diContainer.registerService(Car.class, new Car(diContainer.resolveService(EngineInterface.class), diContainer.resolveService(TransmissionInterface.class)));
        
        Car newCar = diContainer.resolveService(Car.class);
        newCar.start();
    }
}