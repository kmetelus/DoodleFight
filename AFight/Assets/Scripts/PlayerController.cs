using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {


  // Character Movement Variabeles
  // Movement Speed
  public float hDir;
  public float vDir;
  public const float MIN_SPEED = 0.03f;
  public const float MAX_SPEED = 5f;
  public const float DECELERATION_FACTOR = 5f;
  public bool decelerate = false;

  // Input Variables
    // Dash variables
  public bool dash = false;
  public float dashDir = 1f;

    // Attacking variables
  public bool attacking = false;
    // Defense Variables
  public bool defending = false;

    // Jumping Variables
  public bool grounded = true;
  public bool fastfall = false;
  public bool canJump = true;
  public bool tryFallThrough = false;
  public bool successFallThrough = false;
  public const float MAX_JUMP_TIME = 0.25f;
  public const float AIR_SPEED = 50f;
  public const float FALL_CONTROL = 1.25f;
  public const float DEFAULT_FALL_MULTIPLIER = 1f;
  public const float FAST_FALL_MULTIPLIER = 15f;


  private Rigidbody2D rb;

  // Use this for initialization
  void Start()  {
      rb = GetComponent<Rigidbody2D>();
  }

  void Update()  {

      //Store horizontal movement input direction
      hDir = Input.GetAxis("HMovement");
      dashDir = (hDir != 0 && !dash) ? hDir : dashDir;

      //Store vertical movement input direction
      vDir = Input.GetAxis("VMovement");

      decelerate = (hDir == 0 && rb.velocity.magnitude > MIN_SPEED && grounded) ? true : false;
      fastfall = (vDir < 0 && !grounded) ? true : false;
      tryFallThrough = (vDir < 0) ? true : tryFallThrough;

      dash = Input.GetButtonDown("Dash");
      defending = Input.GetButton("Defend");
      attacking = Input.GetButton("Attack");

      // // Movement and Dash Handling
      // if (Input.GetButtonDown("HMovement")) {
      //   if (dash_buffer_time > 0 && dtp == 1) {
      //     dashDir = !dash ? hDir : dashDir; // Set the dash direction
      //     dash = true;
      //   } else {
      //     dash_buffer_time = 1f;
      //     dtp += 1;
      //   }
      // }
      //
      // if (dash_buffer_time > 0) {
      //   dash_buffer_time -= Time.deltaTime;  // Allow dash for 0.5s (dash_buffer_time)
      // } else {
      //   dtp = 0;
      //   dash = false;
      // }

      // if (dash) {
      //   // gameObject.transform.position = new Vector3(x + (DASH_PUSH * dashDir), y, z);
      //   rb.velocity =  rb.velocity.normalized * DASH_SPEED;
      // } else {
      //   // Debug.Log((Vector2.right * WALK_SPEED) * hDir);
      //   Vector2 horizontalMovement = new Vector2(hDir, 0);
      //   rb.AddForce((Vector2.right * WALK_SPEED) * hDir * ACCELERATION);
      //   rb.AddForce(horizontalMovement * WALK_SPEED);
      //   rb.velocity = (rb.velocity.magnitude > WALK_SPEED) ? rb.velocity.normalized * WALK_SPEED : rb.velocity;
      // }

/*
*
* Jump Handling
*
*/
      //
      // if (vDir < 0) {
      //     rb.gravityScale = FAST_FALL_MULTIPLIER;
      // } else if (vDir > 0 && grounded) {
      //
      //   // Debug.Log("2");
      //     rb.gravityScale = JUMP_RESIST;
      //     Vector2 jumpTragectory = new Vector2(hDir * 10f, vDir * JUMP_HEIGHT);
      //     rb.AddForce(jumpTragectory);
      // } else {
      //     rb.gravityScale = (rb.gravityScale == FAST_FALL_MULTIPLIER) ? FAST_FALL_MULTIPLIER : FALL_MULTIPLIER;
      // }
    }
}
