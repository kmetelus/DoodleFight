using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

  private SpriteRenderer sr;
  private Animator a;
  private PlayerController p;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
    a = GetComponent<Animator>();
    p = gameObject.GetComponentInParent<PlayerController>();
	}

	// Update is called once per frame
	void Update () {
    // if (Mathf.Abs(p.hDir) > 0) {
    //   a.SetBool("MOVE", true);
    // } else {
    //   // Debug.Log("STOP");
    //   a.SetBool("MOVE", false);
    // }
    a.SetBool("MOVE", Mathf.Abs(p.hDir) > 0 && !a.GetBool("FALLING"));
    // Debug.Log(a.GetBool("MOVE"));
    sr.flipX = (p.hDir < 0) ? true : (p.hDir > 0) ? false : sr.flipX;


    if (p.vDir > 0 && p.grounded && p.canJump) {
      // Debug.Log("HEO");
      a.SetBool("JUMP", true);
      a.SetBool("GROUNDED", false);
    } else if (!p.grounded) {
      a.SetBool("GROUNDED", false);
      // a.SetBool("JUMP", p.vDir > 0);
    } else {
      // Debug.Log("ONOOOO");
      a.SetBool("JUMP", false);
      a.SetBool("GROUNDED", true);
      a.SetBool("FALLING", false);
      // Debug.Log(p.grounded);
    }

    a.SetBool("FALLING", !p.grounded && !p.canJump && !a.GetBool("JUMP"));

    a.SetBool("DASH", p.dash);
    a.SetBool("DEFEND", p.defending);
	}
}
