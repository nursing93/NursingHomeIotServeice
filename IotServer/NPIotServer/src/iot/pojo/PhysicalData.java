package iot.pojo;

public class PhysicalData {
    private int heartRate;
    private int bloodPressuer;
    private double temperature;

    public int getHeartRate() {
        return heartRate;
    }
    public void setHeartRate(int heartRate) {
        this.heartRate = heartRate;
    }
    public int getBloodPressuer() {
        return bloodPressuer;
    }
    public void setBloodPressuer(int bloodPressuer) {
        this.bloodPressuer = bloodPressuer;
    }
    public double getTemperature() {
        return temperature;
    }
    public void setTemperature(double temperature) {
        this.temperature = temperature;
    }
    
    @Override
    public String toString() {
        String physical = "{PhysicalData = " + super.toString() 
                + ", heartRate = " + heartRate 
                + ", bloodPressuer = " + bloodPressuer 
                + ", temperature = " + temperature + "}";
        return physical;
    }
}
