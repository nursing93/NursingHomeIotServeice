package iot.emergency;

import iot.pojo.Position;
import iot.pojo.RingRecord;
import iot.tools.PositionJudge;

public class OverstepEmergencyListener extends EmergencyListener {

    @Override
    protected boolean abnormal(RingRecord record) {
        Position[] polygon = getSafeArea(record.getId());
        PositionJudge judge = new PositionJudge(record.getPosition(), polygon);
        return judge.judge();
    }

    @Override
    protected EmergencyEvent newEmergency(RingRecord record) {
        return new EmergencyEvent(EmergencyType.OVERSTEP, record);
    }
    
    private Position[] getSafeArea(int elderId) {
        //TODO 从数据库获取安全区域
        Position[] polygon = new Position[3];
        polygon[0] = new Position(108.11111, 34.11111);
        polygon[1] = new Position(108.11111, 34.33333);
        polygon[2] = new Position(108.33333, 34.33333);
        return polygon;
    }
}
