using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public Transform p1Spawn;
  public Transform p2Spawn;
  public GameObject player1;
  public GameObject player2;
  public Slider p1HealthSlider;
  public Slider p2HealthSlider;
  public Slider p1MeterSlider;
  public Image p1Fill;
  public Slider p2MeterSlider;
  public Image p2Fill;

  private Color ready;

  private GameObject activeP1;
  private GameObject activeP2;

  public float timeLeft;
  private const float MAX_TIME = 99f;
  public Text timerText;

	// Use this for initialization
	void Start () {
    activeP1 = Instantiate(player1, p1Spawn.transform, false);
    activeP2 = Instantiate(player2, p2Spawn.transform, false);
    activeP1.gameObject.tag = "Player1";
    activeP2.gameObject.tag = "Player2";
    ready = p1Fill.color;
    // activeP1 = GameObject.FindWithTag("Player1");
    // activeP2 = GameObject.FindWithTag("Player2");

    timeLeft = MAX_TIME;
    timerText.text = "TIME\n" + Mathf.Round(timeLeft);
	}

	// Update is called once per frame
	void Update () {
    timeLeft -= (timeLeft < 0) ? 0 : Time.deltaTime;
    timerText.text = "TIME\n" + Mathf.Round(timeLeft);

    p1HealthSlider.value = activeP1.GetComponent<Fighter>().current_health;
    p2HealthSlider.value = activeP2.GetComponent<Fighter>().current_health;

    if (!activeP1.GetComponent<Fighter>().enough_meter) {
      p1Fill.color = Color.red;
    } else {
      p1Fill.color = ready;
    }

    if (!activeP2.GetComponent<Fighter>().enough_meter) {
      p2Fill.color = Color.red;
    } else {
      p2Fill.color = ready;
    }

    p1MeterSlider.value = activeP1.GetComponent<Fighter>().current_meter;
    p2MeterSlider.value = activeP2.GetComponent<Fighter>().current_meter;
    // Debug.Log(p1HealthSlider.value + ", " + p2HealthSlider.value);
	}
}
