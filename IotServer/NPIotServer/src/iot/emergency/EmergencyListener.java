package iot.emergency;

import iot.observer.Event;
import iot.observer.EventListener;
import iot.pojo.RingRecord;
import iot.pojo.RingRecordAdaptor;

public abstract class EmergencyListener implements EventListener {

    @Override
    public void notify(Event e) {
        RingRecord record = ((RingRecordAdaptor)e).getRecord();
        if(abnormal(record)) {
            EmergencyCache.instance().cacheEvent(newEmergency(record));
        }
    }
    
    protected abstract boolean abnormal(RingRecord record);
    protected abstract EmergencyEvent newEmergency(RingRecord record);

}
