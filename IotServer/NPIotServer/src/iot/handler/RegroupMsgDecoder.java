package iot.handler;

import java.util.List;

import io.netty.buffer.ByteBuf;
import io.netty.channel.ChannelHandlerContext;
import io.netty.handler.codec.ByteToMessageDecoder;

public class RegroupMsgDecoder extends ByteToMessageDecoder {

    @Override
    protected void decode(ChannelHandlerContext ctx, ByteBuf in, List<Object> out) throws Exception {
        //TODO 解决拆包粘包问题，生成Json串
        
        String ringJson = getRingJson(in);
        out.add(ringJson);
    }
    
    String getRingJson(ByteBuf in) {
        
        return in.toString();
    }
}
