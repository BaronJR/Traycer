using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ReloadOnClick : MonoBehaviour {

	public void ReloadClicked(){
		SceneManager.LoadScene("Main");
	}
}
