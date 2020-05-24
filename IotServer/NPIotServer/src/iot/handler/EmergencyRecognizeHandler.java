package iot.handler;

import java.util.LinkedList;
import java.util.List;

import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.ChannelInboundHandlerAdapter;
import iot.observer.EventListener;
import iot.observer.EventSourse;
import iot.pojo.RingRecord;
import iot.pojo.RingRecordAdaptor;

public class EmergencyRecognizeHandler extends ChannelInboundHandlerAdapter implements EventSourse {
    private List<EventListener> listeners = new LinkedList<EventListener>(); 
    
    @Override
    public void channelRead(ChannelHandlerContext ctx, Object msg) {
        RingRecordAdaptor record = new RingRecordAdaptor((RingRecord)msg);
        handleEmergency(record);
        
        ctx.fireChannelRead(record);
    }

    void handleEmergency(RingRecordAdaptor record) {
        for(EventListener listener : listeners) {
            listener.notify(record);
        }
    }
    
    @Override
    public void addListener(EventListener listener) {
        listeners.add(listener);
    }

    @Override
    public void removeListener(EventListener listener) {
        listeners.remove(listener);
    }
    
}
