package iot.observer;

public interface EventSourse {
    
    void addListener(EventListener listener);
    void removeListener(EventListener listener);
    
}
