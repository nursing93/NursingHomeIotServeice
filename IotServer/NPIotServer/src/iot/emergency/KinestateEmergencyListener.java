package iot.emergency;

import iot.pojo.RingRecord;

public class KinestateEmergencyListener extends EmergencyListener  {

    @Override
    protected boolean abnormal(RingRecord record) {
        // TODO implement the Kinestate condition
        return false;
    }

    @Override
    protected EmergencyEvent newEmergency(RingRecord record) {
        return new EmergencyEvent(EmergencyType.KINESTATE, record);
    }
    
}
