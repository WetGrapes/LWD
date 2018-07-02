using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;

public class Generation : MonoBehaviour {
	[SerializeField] GameObject[] Obs = new GameObject[4];

	[SerializeField] int MaxRnd = 200;
	[SerializeField] int MaxGround = 150;
	[SerializeField] int MaxSphere = 50;
	[SerializeField] int MaxClock = 10;
	[SerializeField] int MaxBlb = 2;
	int[,] gm = new int[9,250];
	int cl, rnd, lastClock, lastCrystal;
	float xpos, ypos, size;
	/*[ContextMenu("Gener")]
	void Gener()
	{
		for (int i = 0; i < gm.GetLength (1); i++) {
			lastClock--;
			lastCrystal--;
			for (int j = 0; j < gm.GetLength (0); j++) {
				rnd = Random.Range (0, MaxRnd);
				if (j == 0 || j == gm.GetLength (0) - 1) {
					gm [j, i] = 1;
				} else {
					if (rnd < MaxGround) {
						gm [j, i] = 1;
						cl++;
					}
					if (rnd < MaxSphere)
						gm [j, i] = 2;
					
					if (rnd < MaxClock && lastClock < 0) {
						gm [j, i] = 3;
						lastClock = 10;
					}
					if (rnd < MaxBlb && lastCrystal < 0) {
						gm [j, i] = 4;
						lastCrystal = 50;
					}

					if (i > 0 && gm [j, (i - 1)] != 0) {
						if (i > 1 && gm [j, (i - 2)] != 0) {
							if ((j > 1 && gm [(j - 1), i] != 0)
							   || (j < gm.GetLength (0) - 2 && gm [(j + 1), i] != 0)) {
								gm [j, i] = 1;
								cl++;
							}
						}
					}
					if (i > 0 && gm [j, (i - 1)] == 1) {
						if ((j > 1 && gm [(j - 1), i] == 1)
						   || (j < gm.GetLength (0) - 2 && gm [(j + 1), i] == 1)) {
							gm [j, (i - 1)] = 0;
							cl++;
						}
					}
				}
				if (cl > 3) {
					gm [Random.Range (1, gm.GetLength (0)-1), i] = 0;
					gm [Random.Range (1, gm.GetLength (0)-1), i] = 0;
					cl = 0;
				}
				Debug.Log ("[" + gm [0, i] + ", " + gm [1, i] + ", " +
				gm [2, i] + ", " + gm [3, i] + ", " + gm [4, i] + ", " +
				gm [5, i] + ", " + gm [6, i] + ", " + gm [7, i] + ", " + gm [8, i] + "]");
			}
		}

	}*/

	IEnumerator Start () {

		size = 1;//Obs [1].GetComponent<SpriteRenderer> ().sprite.bounds.size.x;
		xpos = -4 ;
		ypos = 2 ;
		print (size);
		for (int i = 0; i < gm.GetLength (1); i++) {
			lastClock--;
			lastCrystal--;
			yield return new WaitForSeconds (0.0f);
			for (int j = 0; j < gm.GetLength (0); j++) {
				rnd = Random.Range (0, MaxRnd);
				if (j == 0 || j == gm.GetLength (0) - 1) {
					gm [j, i] = 1;
				} else {
					if (rnd < MaxGround) {
						gm [j, i] = 1;
						cl++;
					}
					if (rnd < MaxSphere)
						gm [j, i] = 2;
					
					if (rnd < MaxClock && lastClock < 0) {
						gm [j, i] = 3;
						lastClock = 10;
					}
					if (rnd < MaxBlb && lastCrystal < 0) {
						gm [j, i] = 4;
						lastCrystal = 50;
					}

					if (i > 0 && gm [j, (i - 1)] != 0) {
						if (i > 1 && gm [j, (i - 2)] != 0) {
							if ((j > 1 && gm [(j - 1), i] != 0)
								|| (j < gm.GetLength (0) - 2 && gm [(j + 1), i] != 0)) {
								gm [j, i] = 1;
								cl++;
							}
						}
					}
					if (i > 0 && gm [j, (i - 1)] == 1) {
						if ((j > 1 && gm [(j - 1), i] == 1)
							|| (j < gm.GetLength (0) - 2 && gm [(j + 1), i] == 1)) {
							gm [j, (i - 1)] = 0;
							cl++;
						}
					}
				}
				if (cl > 3) {
					gm [Random.Range (1, gm.GetLength (0)-1), i] = 0;
					gm [Random.Range (1, gm.GetLength (0)-1), i] = 0;
					cl = 0;
				}
				Debug.Log ("[" + gm [0, i] + ", " + gm [1, i] + ", " +
					gm [2, i] + ", " + gm [3, i] + ", " + gm [4, i] + ", " +
					gm [5, i] + ", " + gm [6, i] + ", " + gm [7, i] + ", " + gm [8, i] + "]");
			}
		}


		for (int i = 0; i < gm.GetLength (1); i++) {
			//yield return new WaitForSeconds (0.001f);
			for (int j = 0; j < gm.GetLength (0); j++) {
				if (Obs [gm [j, i]] != null) {
					Vector3 vc = new Vector3 (xpos, ypos, 0);
					GameObject ob = Instantiate (Obs [gm [j, i]], vc, Quaternion.identity) as GameObject;
				}
				xpos += size;
			}
			xpos = -4 * size;
			ypos -= size;
		}
		


	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
