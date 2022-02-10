using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
	public float speed;
	public int health=10;

	private Rigidbody2D rb;
	private Vector2 moveVelocity;

	void Start()
	{
		rb=GetComponent<Rigidbody2D>();
	}

	void Update(){

		if(health<=0){
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
		}

		Vector2 moveInput=new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
		//Debug.Log(moveInput);
		moveVelocity=moveInput.normalized*speed;
		Vector2 oosPos = transform.position;
		if(transform.position.y >= 5.4f)
			oosPos.y = -5f;
		if(transform.position.y <= -5.4f)
			oosPos.y = 5f;
		if(transform.position.x >= 9.2f)
			oosPos.x = -9f;
		if(transform.position.x <= -9.2f)
			oosPos.x = 9f;

		transform.position = oosPos;

	}

	void FixedUpdate(){
		rb.MovePosition(rb.position+moveVelocity * Time.fixedDeltaTime);
	}
}
