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
            EmergencyEvent emergency = getEmergency(record);
            emergency.cache();
        }
    }
    
    protected abstract EmergencyEvent getEmergency(RingRecord record);
    protected abstract boolean abnormal(RingRecord record);
}
