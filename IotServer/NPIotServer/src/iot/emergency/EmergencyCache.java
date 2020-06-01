package iot.emergency;

import java.util.HashMap;
import java.util.LinkedList;
import java.util.List;
import java.util.Map;

public class EmergencyCache {
    private static EmergencyCache instance;
    private Map<Integer, List<EmergencyEvent>> eventsMap;
    
    public static EmergencyCache instance() {
        if(instance == null) {
            instance = new EmergencyCache();
        }
        return instance;
    }
    
    private EmergencyCache() {
        eventsMap = new HashMap<Integer, List<EmergencyEvent>>();
    }
    
    //TODO 线程同步
    public List<EmergencyEvent> getEvents(int nursingHomeId) {
        List<EmergencyEvent> events = eventsMap.remove(nursingHomeId);
        if(events == null) {
            events = new LinkedList<EmergencyEvent>();
        }
        return events;
    }
    
    //TODO 线程同步
    public void cacheEvent(EmergencyEvent e) {
        int nursingHomeId = e.getElderId() / 10000;
        List<EmergencyEvent> events = eventsMap.get(nursingHomeId);
        if(events == null) {
            events = new LinkedList<EmergencyEvent>();
        }
        events.add(e);
    }
}
