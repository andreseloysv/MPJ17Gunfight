using System.Collections;
using System.Collections.Generic;
using UnityEngine;

interface ICustomInput {
	Vector3 getVector3Direction();
	Vector3 getVector3Direction(float x,float y,float z);
	//Vector3 moveCharacter(float x, float y, float z);
}
