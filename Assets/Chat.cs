using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Chat : MonoBehaviour 
{
	//-----
	private List<string> message = new List<string> ();
	private string inputMessage="";
	private string nname="UEKI:";
	//-----
	void OnGUI()
	{
		if (!NetworkViewManager.connected) 
		{
			return;
		}
		GUILayout.Space (20);
		//400のおおきさでGUILayOUTを並べる
		GUILayout.BeginHorizontal (GUILayout.Width (40));
		//input message
		inputMessage = GUILayout.TextField (inputMessage);
		//Send message
		if (GUILayout.Button ("SEND") || Input.GetKeyUp(KeyCode.Return)){
			NetworkView view = GetComponent<NetworkView>();
			view.RPC ("chatMessage",RPCMode.All,nname+inputMessage);
			//inputMessge=""
			inputMessage = string.Empty;
		}
		GUILayout.EndHorizontal ();
		List<string> mes = new List<string> (message);
		mes.Reverse();
		foreach (string s in mes) 
		{
			GUILayout.Label(s);
		}

		//Remove message(number)
		//if (GUILayout.Button ("REMOVE")) {
		//	message.RemoveAt (0);
		//}
		//All clear
		//if (GUILayout.Button ("CLEAR")) {
		//	message.Clear ();
		//}

//		for (int i=0; i<message.Count; i++) 
//		{
//			GUILayout.Label (message [i]);
//		}
	
		// loop
		foreach (string s in message) {
			GUILayout.Label (s);
		}
		if (message.Count > 10) 
		{
			message.RemoveAt(0);
		}
	}
		[RPC]//りもーとぷろしーじゃーこーる
		public void chatMessage(string msg)
		{
			message.Add(msg);
		}
//		message.ForEach (s => GUILayout.Label (s));

	}