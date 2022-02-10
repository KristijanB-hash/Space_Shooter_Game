using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScript : MonoBehaviour
{
	public float speed;
	private Transform playerPos;
	private Player player;
	public GameObject effect;

	void Start(){
		player=GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerPos=GameObject.FindGameObjectWithTag("Player").transform;
	}

	void Update(){

		transform.position=Vector2.MoveTowards(transform.position,playerPos.position,speed*Time.deltaTime); 
		
	}

	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			Instantiate(effect,transform.position,Quaternion.identity);
			player.health--;
			player.GetComponent<Health>().health--;
			Destroy(gameObject);
		}
		if(other.CompareTag("Projectile")){
			Die(other);
		}
		if (other.CompareTag("Barier"))
		{
			Destroy(gameObject);
			Instantiate(effect, transform.position, Quaternion.identity);
		}
	}

	private void Die(Collider2D other)
	{
		Instantiate(effect,transform.position,Quaternion.identity);
		Destroy(other.gameObject);
		Destroy(gameObject);
	}

}
