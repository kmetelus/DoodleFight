using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ReadyScript : MonoBehaviour {

  public bool p1Ready;
  public bool p2Ready;

  public Text p1ReadyText;
  public Text p2ReadyText;


	// Use this for initialization
	void Start () {
    p1Ready = p2Ready = p1ReadyText.enabled = p2ReadyText.enabled = false;
	}

	// Update is called once per frame
	void Update () {
    p1Ready = (p1Ready) ? true : Input.GetButton("Attack");
    p2Ready = (p2Ready) ? true : Input.GetButton("Attack2");

    p1ReadyText.enabled = p1Ready;
    p2ReadyText.enabled = p2Ready;

    if (p1Ready && p2Ready) {
      SceneManager.LoadScene(1);
    }

    if (Input.GetButton("Defend")) {
      SceneManager.LoadScene(1);
    }

	}
}
