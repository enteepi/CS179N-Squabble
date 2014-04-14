var remoteIP = "127.0.0.1";
var remotePort = 25000;
var listenPort = 25000;
var useNat = false;
var yourIP = "";
var yourPort = "";

function OnGUI() {
	if (Network.peerType == NetworkPeerType.Disconnected) {
		if (GUI.Button(Rect(10,10,100,30), "Connect")) {
			/*Network.useNat = useNat;		DEPRICATED FORM*/
			Network.Connect(remoteIP, remotePort);
		}
		
		if (GUI.Button(Rect(10,50,100,30), "Start Server")) {
			/*Network.useNat = useNat;		DEPRICATED FORM*/
			Network.InitializeServer(4, listenPort, useNat);
			
			var gObjs : GameObject[] = FindObjectsOfType(GameObject);
			for (var gObj : GameObject in gObjs) {
				gObj.SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);
			}
		}  
		
		remoteIP = GUI.TextField(Rect(120,10,100,20), remoteIP);
		remotePort = parseInt(GUI.TextField(Rect(230,10,40,20), remotePort.ToString()));
		
	} else {
		var ipaddress = Network.player.ipAddress;
		var port = Network.player.port.ToString();
		
		GUI.Label(Rect(140,20,250,40), "IP Address: " + ipaddress + ":" + port);
		
		if (GUI.Button(Rect(10,10,100,50), "Disconnect")) {
			Network.Disconnect(200);
		}
	}
}

function OnConnectedToServer() {
	var gObjs : GameObject[] = FindObjectsOfType(GameObject);
	for (var gObj : GameObject in gObjs) {
		gObj.SendMessage("OnNetworkLoadedLevel", SendMessageOptions.DontRequireReceiver);
	}
}