﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementBehaviorScript : StateMachineBehaviour {

  public float horizontalForce;
  public float verticalForce;

  protected Fighter fighter;
  protected PlayerController p;
  protected AnimationScript a;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    // Debug.Log(stateInfo.length);
    // Debug.Log(stateInfo.shortNameHash);
    // Debug.Log(animator.GetBool("GROUNDED") + " " + animator.GetBool("DASH"));
	  fighter = (fighter == null) ? animator.gameObject.GetComponent<Fighter>() : fighter;
    p = fighter.GetComponentInParent<PlayerController>();
    a = fighter.GetComponentInParent<AnimationScript>();
    // Debug.Log(stateInfo.shortNameHash);
    a.canFlip = true;

	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    // Debug.Log(animator.GetBool("GROUNDED") + " " + animator.GetBool("DASH"));
    if (animator.GetBool("MOVE")) {
      // Debug.Log("EREOI");
      fighter.rb.AddRelativeForce(Vector2.right * horizontalForce * p.hDir);  // Speed will be limited in the Fighter Scipt
    }

    if (p.vDir > 0) {
        p.shouldLand = false;
    }
    // p.canJump = true;

    if (animator.GetBool("FALLING")) {
      p.shouldLand = fighter.rb.velocity.y <= 0;
      fighter.rb.AddRelativeForce(Vector2.right * PlayerController.FALL_CONTROL * p.hDir);
    }

	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	// override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
  //
	// }

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
