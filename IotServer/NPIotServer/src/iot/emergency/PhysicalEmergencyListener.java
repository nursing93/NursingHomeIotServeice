package iot.emergency;

import iot.pojo.PhysicalData;
import iot.pojo.RingRecord;

public class PhysicalEmergencyListener extends EmergencyListener {

    @Override
    protected boolean abnormal(RingRecord record) {
        PhysicalData physical = record.getPhysical();
        boolean result = normalHeartRate(physical.getHeartRate())
                      && normalBloodPress(physical.getBloodPressuer())
                      && normalTemperature(physical.getTemperature());
        return result;
    }
    
    private boolean normalHeartRate(int heartRate) {
        return heartRate > 65 && heartRate < 85;
    }
    
    private boolean normalBloodPress(int bloodPressuer) {
        return bloodPressuer >= 90 && bloodPressuer < 140;
    }
    
    private boolean normalTemperature(double temperature) {
        return temperature > 36.5 && temperature < 38.0;
    }

    @Override
    protected EmergencyEvent newEmergency(RingRecord record) {
        return new EmergencyEvent(EmergencyType.PYSICAL, record);
    }

}
