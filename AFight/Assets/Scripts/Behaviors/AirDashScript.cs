using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDashScript : StateMachineBehaviour {

    public float AIR_DASH_POWER;
    protected Fighter fighter;
    protected PlayerController p;

	 // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
	override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
    Debug.Log("AIR DASH");
    fighter = (fighter == null) ? animator.gameObject.GetComponent<Fighter>() : fighter;
    p = fighter.GetComponentInParent<PlayerController>();
    fighter.hittable = false;
    fighter.rb.AddRelativeForce(Vector2.right * AIR_DASH_POWER * p.dashDir);
	}

	// OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
	// override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
  //
	// }

	// OnStateExit is called when a transition ends and the state machine finishes evaluating this state
	override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) {
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
