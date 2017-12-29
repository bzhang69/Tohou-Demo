using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolf_script : MonoBehaviour {

    private Animator anim;
    int itwHash = Animator.StringToHash("WalkToIdle");
    int idleStateHash = Animator.StringToHash("Base Layer.Wolf_Skeleton|Wolf_Idle_");
    int walkStateHash = Animator.StringToHash("Wolf_Skeleton|Wolf_Walk_cycle_");

    void Start () {
        anim = GetComponent<Animator>();
	}
	
	void Update () {
        AnimatorStateInfo si = anim.GetCurrentAnimatorStateInfo(0);
		if(Input.GetKeyDown(KeyCode.Space) && si.fullPathHash == idleStateHash)
        {
            Debug.Log("Test");
            anim.Play(walkStateHash);
            anim.SetTrigger(itwHash);
        }
	}
}
