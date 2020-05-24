package iot.bootstrap;

import io.netty.bootstrap.ServerBootstrap;
import io.netty.channel.ChannelFuture;
import io.netty.channel.ChannelHandler;
import io.netty.channel.ChannelInitializer;
import io.netty.channel.ChannelOption;
import io.netty.channel.EventLoopGroup;
import io.netty.channel.nio.NioEventLoopGroup;
import io.netty.channel.socket.SocketChannel;
import io.netty.channel.socket.nio.NioServerSocketChannel;
import io.netty.handler.logging.LogLevel;
import io.netty.handler.logging.LoggingHandler;
import iot.emergency.KinestateEmergencyListener;
import iot.emergency.OverstepEmergencyListener;
import iot.emergency.PhysicalEmergencyListener;
import iot.handler.EmergencyRecognizeHandler;
import iot.handler.PersistenceHandler;
import iot.handler.RegroupMsgDecoder;
import iot.handler.RingObjDecoder;

public class IotServerBootStrap {
    private final int servicePort;

    public IotServerBootStrap() {
        this(1514);
    }

    public IotServerBootStrap(int servicePort) {
        this.servicePort = servicePort; 
    }

    public void start(){
        EventLoopGroup bossGroup=new NioEventLoopGroup(1);
        EventLoopGroup workGroup=new NioEventLoopGroup();
        ServerBootstrap boot=new ServerBootstrap();
        boot.group(bossGroup, workGroup)
            .channel(NioServerSocketChannel.class)
            .option(ChannelOption.SO_BACKLOG, 100)    //TODO 后续定制服务端Channel
            .handler(new LoggingHandler(LogLevel.INFO))
            .childHandler(getChildChannelHandler());
        
        try {
            ChannelFuture future = boot.bind(servicePort).sync();
            startupLog();
            future.channel().closeFuture().sync();    //TODO ???
        } catch (InterruptedException e) {
            e.printStackTrace();
        }
        finally
        {
            bossGroup.shutdownGracefully();    //TODO 作用???
            workGroup.shutdownGracefully();
        }
        
    }
    
    private ChannelHandler getChildChannelHandler() {
        ChannelHandler handler = new ChannelInitializer<SocketChannel>() {
            @Override
            protected void initChannel(SocketChannel ch) throws Exception {
                ch.pipeline()
                  .addLast(new RegroupMsgDecoder())
                  .addLast(new RingObjDecoder())
                  .addLast(getEmergencyHandler())    //TODO 考虑持久化与告警的顺序
                  .addLast(new PersistenceHandler());
                  //TODO 添加其他handler
            }
        };
        
       return handler;
    }
    
    private EmergencyRecognizeHandler getEmergencyHandler() {
        EmergencyRecognizeHandler handler = new EmergencyRecognizeHandler();
        handler.addListener(new OverstepEmergencyListener());
        handler.addListener(new PhysicalEmergencyListener());
        handler.addListener(new KinestateEmergencyListener());
        return handler;
    }
    
    private void startupLog()
    {
        System.out.println("*******************************************");
        System.out.println("************ IoTServer started ************");
        System.out.println("*******************************************");
    }
    
}
