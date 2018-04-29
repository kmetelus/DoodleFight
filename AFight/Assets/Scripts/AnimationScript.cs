using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationScript : MonoBehaviour {

  private SpriteRenderer sr;
  private Animator a;
  private PlayerController p;
  private Fighter f;

  public bool canFlip = true;

  public const float MAX_FRAMES = 30;
	// Use this for initialization
	void Start () {
		sr = GetComponent<SpriteRenderer>();
    a = GetComponent<Animator>();
    p = gameObject.GetComponentInParent<PlayerController>();
    f = gameObject.GetComponentInParent<Fighter>();
	}

	// Update is called once per frame
	void Update () {

    a.SetBool("MOVE", Mathf.Abs(p.hDir) > 0 && !a.GetBool("FALLING"));
    // Debug.Log(a.GetBool("MOVE"));
    sr.flipX = (canFlip) ? ((p.hDir < 0) ? true : (p.hDir > 0) ? false : sr.flipX) : sr.flipX;

    if (p.vDir > 0 && p.grounded && p.canJump && !p.shouldLand) {
      // Debug.Log("HEO");
      a.SetBool("JUMP", true);
      a.SetBool("GROUNDED", false);
    } else if (!p.grounded) {
      a.SetBool("GROUNDED", false);
      // a.SetBool("JUMP", p.vDir > 0);
    } else {
      // Debug.Log("ONOOOO");
      a.SetBool("JUMP", false);
      a.SetBool("GROUNDED", (p.grounded && !p.successFallThrough));
      a.SetBool("FALLING", false);
      // Debug.Log(p.grounded);
    }

    a.SetBool("FALLING", (!p.grounded && !p.canJump && !a.GetBool("JUMP")) || (p.tryFallThrough && p.grounded && p.successFallThrough));
    a.SetBool("DASH", p.dash);
    a.SetBool("DEFEND", p.defending);
    a.SetBool("ATTACK1", p.attacking && p.resetAttack);
    a.SetBool("SPECIAL", p.special && f.enough_meter);
    a.SetBool("HIT", p.isHit);
    a.SetBool("DEAD", p.isDead);
	}
}
