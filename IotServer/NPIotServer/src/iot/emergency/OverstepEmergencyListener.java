package iot.emergency;

import iot.pojo.RingRecord;

public class OverstepEmergencyListener extends EmergencyListener {

    @Override
    protected EmergencyEvent getEmergency(RingRecord record) {
        EmergencyEvent emergency = new EmergencyEvent();
        //TODO 配置越界信息
        return emergency;
    }

    @Override
    protected boolean abnormal(RingRecord record) {
      //TODO 越界逻辑
        return false;
    }

}
