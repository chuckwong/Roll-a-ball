using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed;
	private int count;

	public GameObject mainLight;

	private bool isWin;

	void Start ()
	{
		count = 0;
	}

	void OnGUI ()
	{
		GUI.Label (new Rect(10, 10, 200, 50), "Roll-A-Ball by junhaow");

		GUI.Label (new Rect(10, 60, 200, 50), "Count: " + count);

		if (count >= 12) {
			if (!isWin) {
				GetComponents<AudioSource>()[1].Play ();
				isWin = true;
			}
			GUI.Label (new Rect(10, 110, 200, 50), "你这只蠢猪赢了...");
		}
	}

	void FixedUpdate ()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Debug.Log ("h - " + moveHorizontal + "   v - " + moveVertical);

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);

	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.tag == "PickUp") {
			
			other.gameObject.SetActive(false);

			count = count + 1;

			GetComponents<AudioSource>()[0].Play ();

			// change the color of the mainLight
			mainLight.GetComponent<Light>().color = new Color(Random.value, Random.value, Random.value);
		}
	}
}
