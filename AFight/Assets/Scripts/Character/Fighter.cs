using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour {
  public enum PlayerType { HUMAN, AI };

  // HEALTH VALUES

  public static float MAX_HEALTH = 100f;
  public float current_health;
  public float temp_health;
  public static float MAX_METER = 100f;
  public float current_meter;

  // GAMEPLAY VALUES
  public bool enough_meter = false;
  public bool hittable = true;
  public bool attackState = false;
  public bool finalAttackState = false;
  public bool specialState = false;
  public float direction;


  // COMPONENT REFERENCES
  public PlayerType player;
  private PlayerController p;

  public Rigidbody2D rb;

	// Use this for initialization
	void Start () {
    rb = GetComponent<Rigidbody2D>();
    p = gameObject.GetComponentInParent<PlayerController>();

    current_health = MAX_HEALTH;
    temp_health = 0;
    current_meter = 0f;
    InvokeRepeating("RegenHealth", 1 ,1);
	}

  void RegenHealth() {
    if (temp_health > 0 && !p.isDead) {
      current_health += 1;
      temp_health--;
    }
  }

	// Update is called once per frame
	void Update () {
    if (rb.velocity.magnitude > PlayerController.MAX_SPEED) {
      rb.velocity = rb.velocity.normalized * PlayerController.MAX_SPEED;
    }
    // Debug.Log(current_health);

    enough_meter = current_meter > 25;
    current_meter = (current_meter > MAX_METER) ? MAX_METER : current_meter;

    rb.drag = (p.decelerate) ? PlayerController.DECELERATION_FACTOR : 0;
    rb.gravityScale = (p.fastfall) ? PlayerController.FAST_FALL_MULTIPLIER : PlayerController.DEFAULT_FALL_MULTIPLIER;
 }

  private void getPushed(float horizontalForce, float verticalForce, float direction, bool defended) {
    rb.AddRelativeForce(Vector2.right * horizontalForce * direction * 1f);
    if (!defended) {
      rb.AddRelativeForce(Vector2.up * verticalForce * 1f);
    }
  }

  public void takeDamage(float damage, float h, float v, float dir, bool d) {
    if (!d) {
      p.isHit = true;
      current_health -= damage;
      temp_health += damage/2;
      getPushed(h, v, dir, d);
      p.isDead = current_health <= 0f;
    } else {
      current_health -= damage/3;
      temp_health += (damage/3)/2;
      getPushed(h, v, dir, d);
    }
      current_meter += 1.5f;

  }


}
