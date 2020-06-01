package iot.emergency;

import iot.pojo.RingRecord;
import iot.tools.PositionJudge;

public class OverstepEmergencyListener extends EmergencyListener {

    @Override
    protected boolean abnormal(RingRecord record) {
        PositionJudge judge = new PositionJudge(record);
        return judge.judge();
    }

    @Override
    protected EmergencyEvent newEmergency(RingRecord record) {
        return new EmergencyEvent(EmergencyType.OVERSTEP, record);
    }
    
}
