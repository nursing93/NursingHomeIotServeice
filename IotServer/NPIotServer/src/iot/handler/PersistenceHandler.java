package iot.handler;

import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.ChannelInboundHandlerAdapter;
import iot.pojo.RingRecord;

public class PersistenceHandler extends ChannelInboundHandlerAdapter {
    
    @Override
    public void channelRead(ChannelHandlerContext ctx, Object msg) {
        RingRecord record = (RingRecord)msg;
        System.out.println("[----------- PersistenceHandler -----------]");
        persistence(record);
        ctx.fireChannelRead(record);
    }
    
    private void persistence(RingRecord record) {
        //TODO 持久化手环数据
        System.out.println(record.toString());
    }
    
}
