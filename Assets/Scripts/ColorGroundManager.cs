using UnityEngine;
using System.Collections;

public class ColorGroundManager : MonoBehaviour {
	public GameObject arena;
	private SpriteRenderer rendererArena;
	public GameObject[] groundList;
	private Animator[] animatorList;
	private SpriteRenderer[] rendererList;

	// Use this for initialization
	void Start () {
		rendererArena = arena.GetComponent<SpriteRenderer> ();
		animatorList = new Animator[groundList.Length];
		rendererList = new SpriteRenderer[groundList.Length];
		for(int i = 0; i < groundList.Length; i++) {
			animatorList[i] = groundList[i].GetComponent<Animator>();
			rendererList[i] = groundList[i].GetComponent<SpriteRenderer>();
		}
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ShowRed () {
		animatorList [0].SetBool ("StartAnimate", true);
	}
	public void ShowGreen () {
		animatorList [1].SetBool ("StartAnimate", true);
	}
	public void ShowBlue () {
		animatorList [2].SetBool ("StartAnimate", true);
	}
	public void ShowYellow () {
		animatorList [3].SetBool ("StartAnimate", true);
	}

	public void HideRed () {
		animatorList [0].SetBool ("StartAnimate", false);
		rendererArena.color = rendererList [0].color;
	}
	public void HideGreen () {
		animatorList [1].SetBool ("StartAnimate", false);
		rendererArena.color = rendererList [1].color;
	}
	public void HideBlue () {
		animatorList [2].SetBool ("StartAnimate", false);
		rendererArena.color = rendererList [2].color;
	}
	public void HideYellow () {
		animatorList [3].SetBool ("StartAnimate", false);
		rendererArena.color = rendererList [3].color;
	}

}
