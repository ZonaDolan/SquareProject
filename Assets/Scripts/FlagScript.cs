using UnityEngine;
using System.Collections;

public class FlagScript : MonoBehaviour {
	public float netralDelay = 1f;
	private bool isNetral;

	private BoxCollider2D flagCollider;
	public GameObject currentCarrier;
	private GameObject ground;

	// Use this for initialization
	void Start () {
		flagCollider = GetComponent<BoxCollider2D> (); 
		currentCarrier = null;
		ground = GameObject.Find("BaseGround");
		this.transform.parent = ground.transform;
		isNetral = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (isNetral) {
			netralDelay -= 0.2f;
			if(netralDelay <= 0) {
				isNetral = false;
				flagCollider.enabled = true;
				netralDelay = 1f;
			}
		}
	}

	void OnTriggerEnter2D (Collider2D obj) {
		if (obj.tag == "Player" && currentCarrier == null) {
			print ("COLLIDE FLAG");
			currentCarrier = obj.gameObject;
			this.transform.parent = obj.transform;
			obj.SendMessage("SetAsFlagHolder");
		}
	}

	public void RemoveCarrier () {
		print("Carrier Removed");
		this.transform.parent = ground.transform;
		currentCarrier = null;
		isNetral = true;
		flagCollider.enabled = false;
	}
}
