package iot.handler;

import io.netty.buffer.ByteBuf;
import io.netty.channel.ChannelHandlerContext;
import io.netty.channel.ChannelInboundHandlerAdapter;

public class RegroupMsgHandler extends ChannelInboundHandlerAdapter {

    @Override
    public void channelRead(ChannelHandlerContext ctx, Object msg) {
        //TODO 解决拆包粘包问题，生成Json串
        ByteBuf buf = (ByteBuf)msg;
        String ringJson = getRingJson(buf);
        
        System.out.println("[----------- RegroupMsgDecoder -----------]");
        System.out.println(ringJson);
        ctx.fireChannelRead(ringJson);
    }
    
    String getRingJson(ByteBuf in) {
        byte[] bytes = new byte[in.readableBytes()];
        in.getBytes(0, bytes);
        return new String(bytes);
    }
}
