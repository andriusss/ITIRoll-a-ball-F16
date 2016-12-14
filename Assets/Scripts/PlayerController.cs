using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed = 3.0f;
	public Text winText;
	public Text countText;

	private int count;

	Rigidbody rb;
	// Use this for initialization
	void Start () 
	{
		count = 0;
		SetCountText ();
		winText.text = "";
		rb = GetComponent<Rigidbody> ();

	}
	

	//FixedUpdate is for physics 
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (speed * movement);
	}

	void OnTriggerEnter(Collider other)
	{
		if(other.gameObject.CompareTag("PickUp"))
			{
				other.gameObject.SetActive(false);
				count++;
				SetCountText ();
			}
	}

	void SetCountText()
	{

		countText.text = "Count: " + count.ToString ();
		if (count >= 5) {
			winText.text = "You Win!";
		}
	}
}
