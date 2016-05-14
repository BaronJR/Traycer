using UnityEngine;
using System.Collections;

public class ExitGame : MonoBehaviour {

	public void ExitClicked(){
		Application.Quit ();
	}

	void Update() {
		if (Input.GetKey ("escape"))
			Application.Quit ();
	}
}
