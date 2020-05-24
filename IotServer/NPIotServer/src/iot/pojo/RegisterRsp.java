package iot.pojo;

public class RegisterRsp {
    private RegisterResult result;
    private int imsi;
    private int userId;

    public RegisterResult getResult() {
        return result;
    }
    public void setResult(RegisterResult result) {
        this.result = result;
    }
    public int getImsi() {
        return imsi;
    }
    public void setImsi(int imsi) {
        this.imsi = imsi;
    }
    public int getUserId() {
        return userId;
    }
    public void setUserId(int userId) {
        this.userId = userId;
    }
}
