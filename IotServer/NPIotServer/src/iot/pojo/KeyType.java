package iot.pojo;

public enum KeyType {
	SOS("SOS");
	//TODO add other types
	private String name;
	
	private KeyType(String keyType) {
		this.name = keyType;
	}
	
	public String getName() {
		return name;
	}
}
