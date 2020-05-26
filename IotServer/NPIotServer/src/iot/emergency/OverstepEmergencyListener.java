package iot.emergency;

import iot.observer.Event;
import iot.observer.EventListener;
import iot.pojo.RingRecord;
import iot.pojo.RingRecordAdaptor;

public class OverstepEmergencyListener implements EventListener {

    @Override
    public void notify(Event e) {
        RingRecord record = ((RingRecordAdaptor)e).getRecord();
        //TODO Ô½½çÂß¼­
        System.out.println("[-- Emergency --] OverstepEmergencyListener:" + record.getPosition().toString());
    }

}
