using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {

	private PlayerController p;
  private BoxCollider2D bc;

	void Start () {
		  p = gameObject.GetComponentInParent<PlayerController>();
      bc = gameObject.GetComponent<BoxCollider2D>();
	}

  void OnTriggerEnter2D(Collider2D o) {
      if (((o.gameObject.CompareTag("Ground") || o.gameObject.CompareTag("Platform")) && p.vDir <= 0) || p.shouldLand) {
        p.tryFallThrough = p.successFallThrough = false;
        p.canJump = p.vDir <= 0;
        // Debug.Log("ENTERED");
        p.grounded = o.gameObject.CompareTag("Ground") || o.gameObject.CompareTag("Platform");
      }
      bc.enabled = true;
  }
  void OnTriggerStay2D(Collider2D o) {
      if (o.gameObject.CompareTag("Ground")) {
        p.grounded = true;
      }
      p.canJump = true;
      bc.enabled = !(o.gameObject.CompareTag("Platform") && p.tryFallThrough);
      p.successFallThrough = !bc.enabled;

  }
  void OnTriggerExit2D(Collider2D o) {
      if (o.gameObject.CompareTag("Ground") || o.gameObject.CompareTag("Platform")) {
          p.grounded = p.canJump = false;
          // Debug.Log("GONE");
          bc.enabled = true;
      }
  }
	// Update is called once per frame
	void Update () {

	}
}
