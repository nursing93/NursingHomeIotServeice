package iot.handler;

import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.ChannelInboundHandlerAdapter;
import iot.pojo.RingRecord;

public class PersistenceHandler extends ChannelInboundHandlerAdapter {
    
    @Override
    public void channelRead(ChannelHandlerContext ctx, Object msg) {
        RingRecord record = (RingRecord)msg;
        //TODO 手环数据持久化
        System.out.println("[----------- PersistenceHandler -----------]");
        System.out.println(record.toString());
        ctx.fireChannelRead(record);
    }
    
}
