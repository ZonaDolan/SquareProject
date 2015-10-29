using UnityEngine;
using System.Collections;

public class PlayerControllerScript : MonoBehaviour {

	public float speed = 3f;

	private Vector3 movement;
	private Animator animator;
	private FlagScript flag;

	public GameObject blaster;
	public bool isHoldingFlag;

	public float rechargeAttack = 2f;
	private bool canAttack;

	// Use this for initialization
	void Start () {
		animator = blaster.GetComponent<Animator> ();
		flag = GameObject.Find("Flag").GetComponent<FlagScript>();
		isHoldingFlag = false;
		canAttack = true;
	}

	void FixedUpdate () {
		if (!canAttack) {
			rechargeAttack -= Time.deltaTime;
			if(rechargeAttack <= 0) {
				canAttack = true;
				rechargeAttack = 2f;
			}
		}
		MoveAvatar ();
	}

	// Update is called once per frame
	void Update () {
		bool moveUp = Input.GetKey (KeyCode.UpArrow);
		bool moveDown = Input.GetKey (KeyCode.DownArrow);
		bool moveLeft = Input.GetKey (KeyCode.LeftArrow);
		bool moveRight = Input.GetKey (KeyCode.RightArrow);
		bool attack = Input.GetKeyDown (KeyCode.Space);

		movement = Vector3.zero;
		if (moveUp) {
			movement.y = 1f;
		}
		if (moveDown) {
			movement.y = -1f;
		}
		if (moveLeft) {
			movement.x = -1f;
		}
		if (moveRight) {
			movement.x = 1f;
		}

		if (attack && canAttack) {
			animator.SetTrigger("Blast");
			canAttack = false;
		}

	}

	public void SetAsFlagHolder () {
		print ("FLAG HOLDER");
		isHoldingFlag = true;
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player" && isHoldingFlag) {
			flag.GetComponent<FlagScript>().RemoveCarrier();
		}
	}

	private void MoveAvatar () {
		transform.position += movement * speed * Time.deltaTime;
	}

}
