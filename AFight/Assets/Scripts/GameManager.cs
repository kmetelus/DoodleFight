using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

  public Transform p1Spawn;
  public GameObject player1;

	// Use this for initialization
	void Start () {
    Instantiate(player1, p1Spawn.transform, false);
	}

	// Update is called once per frame
	void Update () {

	}
}
