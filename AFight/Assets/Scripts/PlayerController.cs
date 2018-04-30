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
  public bool resetAttack = true;
  public bool special = false;
    // Defense Variables
  public bool defending = false;
  public bool isHit = false;
  public bool isDead = false;

    // Jumping Variables
  public bool grounded = true;
  public bool fastfall = false;
  public bool canJump = true;
  public bool shouldLand = false;
  public bool tryFallThrough = false;
  public bool successFallThrough = false;
  public const float MAX_JUMP_TIME = 0.25f;
  public const float AIR_SPEED = 50f;
  public const float FALL_CONTROL = 1.25f;
  public const float DEFAULT_FALL_MULTIPLIER = 1f;
  public const float FAST_FALL_MULTIPLIER = 15f;

  //Input variables
  public string xMov;
  public string yMov;
  public string dashInput;
  public string defendInput;
  public string attackInput;
  public string specialInput;


  private Rigidbody2D rb;

  // Use this for initialization
  void Start()  {
      rb = GetComponent<Rigidbody2D>();
  }

  void Update()  {

      //Store horizontal movement input direction
      hDir = (Input.GetAxis(xMov) >= 0.5) ? 1 : (Input.GetAxis(xMov) <= -0.5) ? -1 : 0;
      dashDir = (hDir != 0 && !dash) ? hDir : dashDir;

      //Store vertical movement input direction
      vDir = (Input.GetAxis(yMov) >= 0.5) ? 1 : (Input.GetAxis(yMov) <= -0.5) ? -1 : 0;

      dash = Input.GetButtonDown(dashInput);
      defending = Input.GetButton(defendInput) && grounded;
      attacking = Input.GetButton(attackInput);
      special = Input.GetButton(specialInput);

      decelerate = (hDir == 0 && rb.velocity.magnitude > MIN_SPEED && grounded) || defending || attacking;
      fastfall = (vDir < 0 && !grounded);
      tryFallThrough = (vDir < 0) ? true : tryFallThrough;



    }
}
