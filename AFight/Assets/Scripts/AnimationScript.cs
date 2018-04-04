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
    if (Mathf.Abs(p.hDir) > 0) {
      a.SetBool("MOVE", true);
    } else {
      // Debug.Log("STOP");
      a.SetBool("MOVE", false);
    }
    sr.flipX = (p.hDir < 0) ? true : (p.hDir > 0) ? false : sr.flipX;


    if (p.vDir > 0 && p.grounded) {
      // Debug.Log("HEO");
      a.SetBool("JUMP", true);
      a.SetBool("GROUNDED", false);
    } else if (!p.grounded) {
      a.SetBool("GROUNDED", false);
    }else {
      // Debug.Log("ONOOOO");
      a.SetBool("JUMP", false);
      a.SetBool("GROUNDED", true);
      // Debug.Log(p.grounded);
    }

    a.SetBool("DASH", p.dash);
    a.SetBool("DEFEND", p.defending);
	}
}
