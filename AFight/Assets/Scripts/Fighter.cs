using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {
  public enum PlayerType { HUMAN, AI };

  public static float MAX_HEALTH = 100f;
  public float current_health;
  public PlayerType player;
  private Animator a;
  private PlayerController p;

  public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
    rb = GetComponent<Rigidbody2D>();
    a = GetComponent<Animator>();
    p = gameObject.GetComponentInParent<PlayerController>();

    current_health = MAX_HEALTH;
	}

	// Update is called once per frame
	void Update () {
    if (rb.velocity.magnitude > PlayerController.MAX_SPEED) {
      rb.velocity = rb.velocity.normalized * PlayerController.MAX_SPEED;
      // Debug.Log("GOING");
    }

    rb.drag = (p.decelerate) ? PlayerController.DECELERATION_FACTOR : 0;
    rb.gravityScale = (p.fastfall) ? PlayerController.FAST_FALL_MULTIPLIER : PlayerController.DEFAULT_FALL_MULTIPLIER;
	}

  public float getPercentHealth() {
    return current_health / MAX_HEALTH;
  }
}
