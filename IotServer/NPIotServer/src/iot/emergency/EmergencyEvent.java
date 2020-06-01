package iot.emergency;

import iot.observer.Event;
import iot.pojo.RingRecord;

public class EmergencyEvent implements Event {
    private RingRecord record;
    EmergencyType type = EmergencyType.INVALID;
    
    public EmergencyEvent(EmergencyType type, RingRecord record) {
        this.record = record;
        this.type = type;
    }
    
    public RingRecord getRecord() {
        return record;
    }

    public void setRecord(RingRecord record) {
        this.record = record;
    }

    public EmergencyType getType() {
        return type;
    }

    public void setType(EmergencyType type) {
        this.type = type;
    }

    public int getElderId() {
        return record.getId();
    }
}
