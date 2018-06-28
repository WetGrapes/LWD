using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Sprites;

public class UIBehaviour : MonoBehaviour {

	void Start () {
		WithStart ();
		WithStartAnother ();
	}
	protected virtual void WithStart(){}
	protected virtual void WithStartAnother(){}



}
