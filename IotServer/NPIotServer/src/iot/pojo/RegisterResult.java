package iot.pojo;

public enum RegisterResult {
    SUCCESS(0), FAILD_NULL(1), FAILD_REPEATED(2); 
    private int value;

    private RegisterResult(int value) {
        this.value = value;
    }

    public int getValue() {
        return value;
    }
}
