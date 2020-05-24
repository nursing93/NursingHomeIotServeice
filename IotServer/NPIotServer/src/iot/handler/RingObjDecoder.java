package iot.handler;

import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.ChannelInboundHandlerAdapter;
import iot.pojo.RingRecord;

public class RingObjDecoder extends ChannelInboundHandlerAdapter {
    
    @Override
    public void channelRead(ChannelHandlerContext ctx, Object msg) {
        //TODO Json反序列化为RingObj
        String ringJson = (String)msg;
        RingRecord record = readObject(ringJson);
        
        
        ctx.fireChannelRead(record);
    }
    
    RingRecord readObject(String json) {
        RingRecord obj = null;
        
        return obj;
    }
    
}
