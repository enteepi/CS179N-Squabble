#pragma strict

function Start () {

}

function Update () {
	if (LineMouse.myPoints != null) {
		for(var point : Vector3 in LineMouse.myPoints) {
			MoveObject(GameObject.Find("Player").transform, GameObject.Find("Player").transform.position, point, 0.5);
		}
	}
}

function MoveObject (thisTransform : Transform, startPos : Vector3, endPos : Vector3, time : float) {
    var i = 0.0;
    var rate = 1.0/time;
    while (i < 1.0) {
        i += Time.deltaTime * rate;
        thisTransform.LookAt(endPos);
        thisTransform.position = Vector3.Lerp(startPos, endPos, i);
		//Chaaracter Controller Beginnings
//		var moveVector : Vector3 = endPos - startPos;
//    	GameObject.Find("Player").GetComponent(CharacterController).Move(moveVector);
        yield; 
    }
}

function OnTriggerEnter (other : Collider) {
	var playerPos : Vector3 = GameObject.Find("Player").transform.position;
	var boundPos : Vector3 = new Vector3(playerPos.x,1,playerPos.z);
	MoveObject(GameObject.Find("Player").transform, GameObject.Find("Player").transform.position, boundPos, 0.5);
}
