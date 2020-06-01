package iot.emergency;

import iot.pojo.RingRecord;

public class KeyEventEmergencyListener extends EmergencyListener  {

    @Override
    protected boolean abnormal(RingRecord record) {
        return record.getKeyEvent().normal();
    }

    @Override
    protected EmergencyEvent newEmergency(RingRecord record) {
        return new EmergencyEvent(EmergencyType.KEYEVENT, record);
    }
    
}
