package iot.emergency;

import iot.pojo.RingRecord;

public class OverstepEmergencyListener extends EmergencyListener {

    @Override
    protected boolean abnormal(RingRecord record) {
        
        
        
        return false;
    }

    @Override
    protected EmergencyEvent newEmergency(RingRecord record) {
        return new EmergencyEvent(EmergencyType.OVERSTEP, record);
    }
    
}
