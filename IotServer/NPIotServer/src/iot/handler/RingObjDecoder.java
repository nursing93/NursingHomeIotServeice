package iot.handler;

import java.io.IOException;

import com.fasterxml.jackson.core.JsonParseException;
import com.fasterxml.jackson.databind.JsonMappingException;
import com.fasterxml.jackson.databind.ObjectMapper;

import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.ChannelInboundHandlerAdapter;
import iot.pojo.RingRecord;

public class RingObjDecoder extends ChannelInboundHandlerAdapter {
    
    @Override
    public void channelRead(ChannelHandlerContext ctx, Object msg) throws JsonParseException, JsonMappingException, IOException {
        String ringJson = (String)msg;
        RingRecord record = readObject(ringJson);
        System.out.println("[----------- RingObjDecoder -----------]");
        System.out.println(record.toString());
        ctx.fireChannelRead(record);
    }
    
    RingRecord readObject(String json) throws JsonParseException, JsonMappingException, IOException {
        //TODO 确认是否存在更优的方式
        ObjectMapper mapper = new ObjectMapper();
        RingRecord obj = mapper.readValue(json, RingRecord.class);
        return obj;
    }
    
}
