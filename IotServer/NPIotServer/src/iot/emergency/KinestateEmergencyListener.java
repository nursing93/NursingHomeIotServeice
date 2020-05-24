package iot.emergency;

import iot.pojo.RingRecord;

public class KinestateEmergencyListener extends EmergencyListener {

    @Override
    protected EmergencyEvent getEmergency(RingRecord record) {
        EmergencyEvent emergency = new EmergencyEvent();
        //TODO 配置生理参数异常信息
        return emergency;
    }

    @Override
    protected boolean abnormal(RingRecord record) {
        // TODO 判断姿态异常逻辑
        return false;
    }

}
