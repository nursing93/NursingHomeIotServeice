package iot.pojo;

public enum KeyEvent {
    NON(0), SOS(1);
    
    private int value;
    
    private KeyEvent(int value) {
        this.value = value;
    }
    
    public int getValue() {
        return value;
    }
    
    public boolean normal() {
        return this == NON;
    }
}
