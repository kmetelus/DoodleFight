using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

  public bool gameOver;

  public GameObject resumeButton;
  public GameObject playAgainButton;
  public GameObject returnButton;
  public Text winnerText;

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
  private const float MAX_TIME = 60f;
  public Text timerText;

	// Use this for initialization
	void Awake () {

    gameOver = false;

    playAgainButton.SetActive(false);
    returnButton.SetActive(false);
    resumeButton.SetActive(false);
    winnerText.enabled = false;


    activeP1 = Instantiate(player1, p1Spawn.transform, false);
    activeP2 = Instantiate(player2, p2Spawn.transform, false);
    activeP1.gameObject.tag = "Player1";
    activeP2.gameObject.tag = "Player2";
    ready = p1Fill.color;

    timeLeft = MAX_TIME;
    timerText.text = "TIME\n" + Mathf.Round(timeLeft);
    StartCoroutine(Wait());
	}

  IEnumerator Wait()
    {
        yield return new WaitForSeconds(3);
    }

	// Update is called once per frame
	void Update () {

    if (Input.GetButton("Cancel")) {
      Time.timeScale = 0;
      pauseMenu();
    }

    // Subtract from Time
    if (!gameOver) {
      timeLeft -= (timeLeft < 0) ? 0 : Time.deltaTime;
      timerText.text = "TIME\n" + Mathf.Round(timeLeft);
    }

    // Update UI
    p1HealthSlider.value = activeP1.GetComponent<Fighter>().current_health;
    p2HealthSlider.value = activeP2.GetComponent<Fighter>().current_health;

    p1MeterSlider.value = activeP1.GetComponent<Fighter>().current_meter;
    p2MeterSlider.value = activeP2.GetComponent<Fighter>().current_meter;

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

    // Check for Game Over
    if (p1HealthSlider.value <= 0) {
      gameOver = true;
      winnerText.text = "Player 2 Wins!";
      displayButtons();
    }

    if (p2HealthSlider.value <= 0) {
      gameOver = true;
      winnerText.text = "Player 1 Wins!";
      displayButtons();
    }

    if (timeLeft == 0) {
      gameOver = true;
      if (p1HealthSlider.value < p2HealthSlider.value) {
        winnerText.text = "Player 2 Wins!";
        displayButtons();
      } else if (p1HealthSlider.value > p2HealthSlider.value) {
        winnerText.text = "Player 1 Wins!";
        displayButtons();
      } else {
        winnerText.text = "iT'S a DraW?!?!";
        displayButtons();
      }
    }
	}

  void displayButtons() {
    playAgainButton.SetActive(true);
    returnButton.SetActive(true);
    winnerText.enabled = true;
  }

  void pauseMenu() {
    returnButton.SetActive(true);
    resumeButton.SetActive(true);
  }
}
