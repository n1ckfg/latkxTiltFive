using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LatkInputTiltFive : MonoBehaviour {


	public LightningArtist latk;

	private void Awake() {
		if (latk == null) latk = GetComponent<LightningArtist>();
	}

	public void clickOn()
    {
		latk.clicked = true;
    }

	public void clickOff()
    {
		latk.clicked = false;
    }

}
