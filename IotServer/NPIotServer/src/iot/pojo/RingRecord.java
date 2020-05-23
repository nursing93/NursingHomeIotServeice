package iot.pojo;

public class RingRecord {
	private int id;
	private int battery;
	private PhysicalData physical;
	private Position position;
	private Kinestate kinestat;
	private String time;    //TODO ≈‰÷√Œ™≤ªΩ‚Œˆjson
	
	public String getTime() {
		return time;
	}
	public void setTime(String time) {
		this.time = time;
	}
	public int getId() {
		return id;
	}
	public void setId(int id) {
		this.id = id;
	}
	public int getBattery() {
		return battery;
	}
	public void setBattery(int battery) {
		this.battery = battery;
	}
	public PhysicalData getPhysical() {
		return physical;
	}
	public void setPhysical(PhysicalData physical) {
		this.physical = physical;
	}
	public Position getPosition() {
		return position;
	}
	public void setPosition(Position position) {
		this.position = position;
	}
	public Kinestate getKinestat() {
		return kinestat;
	}
	public void setKinestat(Kinestate kinestat) {
		this.kinestat = kinestat;
	}
}
