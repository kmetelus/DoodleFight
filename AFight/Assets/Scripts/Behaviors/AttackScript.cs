using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : StateMachineBehaviour {

  public float movementForward;
  protected Fighter fighter;
  protected PlayerController p;
  protected AnimationScript a;
  private SpriteRenderer sr;
  public float direction;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    fighter = (fighter == null) ? animator.gameObject.GetComponent<Fighter>() : fighter;
    p = fighter.GetComponentInParent<PlayerController>();
    a = fighter.GetComponentInParent<AnimationScript>();
    sr = fighter.GetComponentInParent<SpriteRenderer>();
    direction = (sr.flipX) ? -1 : 1;

    a.canFlip = false;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	   fighter.rb.AddRelativeForce(Vector2.right * movementForward * direction);
     p.vDir = direction;
	}

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    a.canFlip = true;
	}

	// OnStateMove is called right after Animator.OnAnimatorMove(). Code that processes and affects root motion should be implemented here
	//override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}

	// OnStateIK is called right after Animator.OnAnimatorIK(). Code that sets up animation IK (inverse kinematics) should be implemented here.
	//override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
	//
	//}
}
