import java.util.ArrayList;

class Thread
{
    int id;
    int priority;
    String state;
    String localization;
    ArrayList<Observer> observerList = new ArrayList<Observer>();
    
    Thread(int id, int priority, String localization) {
        this.id = id;
        this.priority = priority;
        this.state = "created";
        this.localization = localization;
    }
    
    public void start() {
        state = "running";
        notifyObservers();
    }
    
    public void abort() {
        state = "aborted";
        notifyObservers();
    }
    
    public void sleep() {
        state = "sleeping";
        notifyObservers();
    }
    
    public void suspend() {
        state = "suspended";
        notifyObservers();
    }
    
    public void subscribe(Observer observerItem) {
        observerList.add(observerItem);
    }
    
    public void unsubscribe(Observer observerItem) {
        observerList.remove(observerItem);
    }
    
    private void notifyObservers() {
        for (Observer observerItem : observerList) {
            observerItem.update();
        }
    }
    
    public void printStateToConsole() {
        System.out.println(state);
    }
}

abstract class Observer
{
    abstract void update();
}

class Dashboard extends Observer
{
    public void update() {
        System.out.println("Dashboard received update");
    }
}

class Main
{
    public static void main (String[] args) {
        Thread thread1 = new Thread(1, 0, "en-us");
        thread1.printStateToConsole();
        
        Dashboard dashboard1 = new Dashboard();
        thread1.subscribe(dashboard1);
        thread1.start();
        thread1.printStateToConsole();
    }
}