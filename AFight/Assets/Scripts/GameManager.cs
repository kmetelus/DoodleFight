using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public Transform p1Spawn;
  public GameObject player1;

  public float timeLeft;
  private const float MAX_TIME = 99f;
  public Text timerText;

	// Use this for initialization
	void Start () {
    Instantiate(player1, p1Spawn.transform, false);
    timeLeft = MAX_TIME;
    timerText.text = "TIME\n" + Mathf.Round(timeLeft);
	}

	// Update is called once per frame
	void Update () {
    timeLeft -= (timeLeft < 0) ? 0 : Time.deltaTime;
    timerText.text = "TIME\n" + Mathf.Round(timeLeft);
	}
}
