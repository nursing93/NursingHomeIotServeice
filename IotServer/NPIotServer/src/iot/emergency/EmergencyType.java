package iot.emergency;

public enum EmergencyType {
    
    INVALID(0), PYSICAL(1), OVERSTEP(2), KINESTATE(3), KEYEVENT(4);
    private int value;
    private EmergencyType(int value) {
        this.value = value;
    }
    public int getValue() {
        return value;
    }
    public void setValue(int value) {
        this.value = value;
    }
    
}
