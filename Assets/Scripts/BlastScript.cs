using UnityEngine;
using System.Collections;

public class BlastScript : MonoBehaviour {
	private Rigidbody2D parentRigidBody;

	// Use this for initialization
	void Start () {
		parentRigidBody = GetComponentInParent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void StartBlast () {
		parentRigidBody.mass = 100f;
	}

	public void EndBlast () {
		parentRigidBody.mass = 1f;
	}
}
