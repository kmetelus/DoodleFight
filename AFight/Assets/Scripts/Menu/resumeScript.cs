using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumeScript : MonoBehaviour {

  public GameObject resumeButton;
  public GameObject returnButton;

  public void unPause() {
    Time.timeScale = 1;
    resumeButton.SetActive(false);
    returnButton.SetActive(false);
  }
}
