using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {

	private PlayerController p;

	void Start () {
		  p = gameObject.GetComponentInParent<PlayerController>();
	}

  void OnTriggerEnter2D(Collider2D o) {
      if (o.gameObject.CompareTag("Ground") || o.gameObject.CompareTag("Platform")) {
          Debug.Log("ENTERED");
          p.grounded = true;
      }
  }
  void OnTriggerStay2D(Collider2D o) {
      p.grounded = (o.gameObject.CompareTag("Ground") || o.gameObject.CompareTag("Platform")) ? true : false;
  }
  void OnTriggerExit2D(Collider2D o) {
      if (o.gameObject.CompareTag("Ground") || o.gameObject.CompareTag("Platform")) {
          p.grounded = false;
          // Debug.Log("OUT");
      }
  }
	// Update is called once per frame
	void Update () {

	}
}
