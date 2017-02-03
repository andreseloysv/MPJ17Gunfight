using UnityEngine;

public class CustomInput : ICustomInput {
	public Vector3 getVector3Direction(){
		Vector3 axisDirection;
		axisDirection = new Vector3 (Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw ("Vertical"));
		return axisDirection;
	}

public Vector3 getVector3Direction(float x,float y,float z){
		Vector3 axisDirection;
		axisDirection = new Vector3 (x, 0, z);
		return axisDirection;
	}
}
