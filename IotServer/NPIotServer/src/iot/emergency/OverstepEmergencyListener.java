package iot.emergency;

import iot.pojo.RingRecord;

public class OverstepEmergencyListener extends EmergencyListener {

    @Override
    protected EmergencyEvent getEmergency(RingRecord record) {
        EmergencyEvent emergency = new EmergencyEvent();
        //TODO ����Խ����Ϣ
        return emergency;
    }

    @Override
    protected boolean abnormal(RingRecord record) {
      //TODO Խ���߼�
        return false;
    }

}