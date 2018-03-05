using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {

	private PlayerController p;

	void Start () {
		  p = gameObject.GetComponentInParent<PlayerController>();
	}

  void OnTriggerEnter2D(Collider2D o) {
      if (o.gameObject.CompareTag("Ground")) {
          p.grounded = true;
      }

  }
  void OnTriggerStay2D(Collider2D o) {
      if (o.gameObject.CompareTag("Ground")) {
          p.grounded = true;
      }
  }
  void OnTriggerExit2D(Collider2D o) {
      if (o.gameObject.CompareTag("Ground")) {
          p.grounded = false;  
      }
  }
	// Update is called once per frame
	void Update () {

	}
}
