package iot.pojo;

//TODO 确认数据内容
public class Kinestate {

    private Acceleration acc;
    private Palstance pal;

    public Acceleration getAcc() {
        return acc;
    }
    public void setAcc(Acceleration acc) {
        this.acc = acc;
    }
    public Palstance getPal() {
        return pal;
    }
    public void setPal(Palstance pal) {
        this.pal = pal;
    }

    @Override
    public String toString() {
        String kinestate = "{Kinestate = " + super.toString() + ", acc = " + acc.toString()
               + ", pal = " + pal.toString() + "}";
        return kinestate;
    }

}
