using UnityEngine;
using System.Collections;

public class ColorGroundScript : MonoBehaviour {
	public GameObject after;
	public GameObject before;
	private Animator animAfter, animBefore, anim;

	// Use this for initialization
	void Start () {
		animAfter = after.GetComponent<Animator> ();
		animBefore = before.GetComponent<Animator> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void showNext() {
		animAfter.SetBool ("StartAnimate", true);
	}

	public void setBeforeToIdle() {
		animBefore.SetBool ("StartAnimate", false);
	}

	public void setIdle() {
		anim.SetBool ("StartAnimate", false);
	}
}
