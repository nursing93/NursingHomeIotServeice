package iot.emergency;

import iot.pojo.RingRecord;

public class PhysicalEmergencyListener extends EmergencyListener {

    @Override
    protected EmergencyEvent getEmergency(RingRecord record) {
        EmergencyEvent emergency = new EmergencyEvent();
        //TODO 配置生理参数异常信息
        return emergency;
    }

    @Override
    protected boolean abnormal(RingRecord record) {
      //TODO 生理参数异常判断
        return false;
    }

}
