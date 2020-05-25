package test;

import iot.bootstrap.IotServerBootStrap;

public class FrameworkBaseTest {

    public static void main(String[] args) {
        
        IotServerBootStrap iotServer = new IotServerBootStrap(1514);
        iotServer.start();
        
    }

}
