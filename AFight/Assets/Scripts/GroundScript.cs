using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScript : MonoBehaviour {

	private PlayerController p;

	void Start () {
		  p = gameObject.GetComponentInParent<PlayerController>();
	}

  void OnTriggerEnter2D(Collider2D o) {
      p.canJump = p.vDir <= 0;
      Debug.Log(p.canJump);
      if ((o.gameObject.CompareTag("Ground") || o.gameObject.CompareTag("Platform")) && p.vDir <= 0 && p.canLand) {
          Debug.Log("ENTERED");
          p.grounded = true;
      }
  }
  void OnTriggerStay2D(Collider2D o) {
      // if (p.canLand) {
          p.grounded = (o.gameObject.CompareTag("Ground") || o.gameObject.CompareTag("Platform")) ? true : false;
          // Debug.Log(p.grounded);
      // }
      p.canJump = p.vDir <= 0;
  }
  void OnTriggerExit2D(Collider2D o) {
      if (o.gameObject.CompareTag("Ground") || o.gameObject.CompareTag("Platform")) {
          p.grounded = p.canJump = false;
          Debug.Log("GONE");
      }
  }
	// Update is called once per frame
	void Update () {

	}
}
