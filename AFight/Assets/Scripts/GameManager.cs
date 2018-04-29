using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public Transform p1Spawn;
  public Transform p2Spawn;
  public GameObject player1;
  public GameObject player2;

  public float timeLeft;
  private const float MAX_TIME = 99f;
  public Text timerText;

	// Use this for initialization
	void Start () {
    Instantiate(player1, p1Spawn.transform, false);
    Instantiate(player2, p2Spawn.transform, false);
    player1.gameObject.tag = player2.gameObject.tag = "Player";
    timeLeft = MAX_TIME;
    timerText.text = "TIME\n" + Mathf.Round(timeLeft);
	}

	// Update is called once per frame
	void Update () {
    timeLeft -= (timeLeft < 0) ? 0 : Time.deltaTime;
    timerText.text = "TIME\n" + Mathf.Round(timeLeft);
	}
}
