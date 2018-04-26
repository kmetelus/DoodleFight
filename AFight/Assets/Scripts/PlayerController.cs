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
      
    }
}
