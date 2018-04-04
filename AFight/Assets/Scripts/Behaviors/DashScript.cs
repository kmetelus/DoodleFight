using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DashScript : StateMachineBehaviour {

  public float DASH_POWER;
  protected Fighter fighter;
  protected PlayerController p;
	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    Debug.Log("DASHSHSHHSHSH");
    fighter = (fighter == null) ? animator.gameObject.GetComponent<Fighter>() : fighter;
    p = fighter.GetComponentInParent<PlayerController>();
    fighter.hittable = false;
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	// override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    // p.dash = true;
    // fighter.rb.AddRelativeForce(Vector2.up * DASH_POWER);
    // fighter.rb.velocity = new Vector2(0f, 0f);
	// }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    fighter.rb.AddRelativeForce(Vector2.right * DASH_POWER * p.dashDir);
    p.dash = false;
    fighter.hittable = true;
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
