package iot.pojo;

//TODO 接受gps，转换为百度坐标后存储
public class Position {
    private double lng;
    private double lat;
    
    public double getLng() {
        return lng;
    }
    public void setLng(double lng) {
        this.lng = lng;
    }
    public double getLat() {
        return lat;
    }
    public void setLat(double lat) {
        this.lat = lat;
    }
    @Override
    public String toString() {
        String position = "{Position = " + super.toString() 
                        + ", lng = " + lng 
                        + ", lat = " + lat + "}";
        return position;
    }
    
}
