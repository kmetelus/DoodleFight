using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayControls : MonoBehaviour {

  public GameObject playButton;
  public GameObject exitButton;
  public GameObject viewControlsButton;
  public Text controls;

	public void Display() {
    playButton.SetActive(!playButton.activeInHierarchy);
    exitButton.SetActive(!exitButton.activeInHierarchy);
    controls.enabled = !controls.enabled;
  }

	void Awake () {
    controls.enabled = false;
	}
}
