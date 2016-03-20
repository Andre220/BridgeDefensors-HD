using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemyBullet : MonoBehaviour 
{
	/*FIX : Make Bullet lookat the target gameobject corretly*/

	//Gameobject que armazena os canhoes (player)
	public GameObject PlayerGameObject;

	//Gameobject que sera o alvo desta bala
	public GameObject ThisTarget;

	//Velocidade da bala
	public float Speed;

	void Start () 
	{
		//Escolhendo um alvo dentre os alvos disponiveis no ScriptAdmin
		this.ThisTarget = SpaceShipsAdmin.instance.Targets [Random.Range(0, SpaceShipsAdmin.instance.Targets.Count)];
		PlayerGameObject = GameObject.Find ("Player");
	}
	

	void Update () 
	{
		Damage ();
		Death ();
		LookTarget ();
		this.gameObject.transform.position = Vector2.MoveTowards (this.gameObject.transform.position, ThisTarget.transform.position, Speed * Time.deltaTime);

		//Caso o alvo deste objeto tenha sido destruido, esta bala procura outro alvo.
		if(this.ThisTarget == null)
		{
			Destroy(this.gameObject);
			//this.ThisTarget = SpaceShipsAdmin.instance.Targets [Random.Range(0, SpaceShipsAdmin.instance.Targets.Count)];
		}
	}

	void LookTarget()
	{
		/*Vector3 TargetDirection = this.ThisTarget.transform.position - this.gameObject.transform.position;
		float Angle = Mathf.Atan2(TargetDirection.y, TargetDirection.x) * Mathf.Rad2Deg;

		this.gameObject.transform.rotation = Quaternion.Euler (0, 0, Angle * -1);*/

		Quaternion NewRotation = Quaternion.LookRotation (this.gameObject.transform.position - this.ThisTarget.transform.position, Vector3.forward);
		NewRotation.x = 0.0f;
		NewRotation.y = 0.0f;
		gameObject.transform.rotation = Quaternion.Slerp (this.gameObject.transform.rotation, NewRotation, this.Speed * Time.deltaTime);
	}

	void Damage()
	{
		if(this.gameObject.transform.position == ThisTarget.transform.position)
		{
			switch(this.ThisTarget.gameObject.name)
			{
				case "MainCannon":
					Destroy(this.gameObject);
					//this.ThisTarget.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerGameObject.GetComponent<Player>().MainCannonSprites[];
				break;
				case "LeftCannon":
					Destroy(this.gameObject);
					//this.ThisTarget.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerGameObject.GetComponent<Player>().LeftCannonSprites[];
				break;
				case "RightCannon":
					Destroy(this.gameObject);
					//this.ThisTarget.gameObject.GetComponent<SpriteRenderer>().sprite = PlayerGameObject.GetComponent<Player>().RightCannonSprites[];
				break;
				case "City":
					Destroy(this.gameObject);
				break;
			}
		}
	}

	void Death()
	{
		/*if(PlayerGameObject.GetComponent<Player>().MainCannonLife <= 0)
		{
			//GameObject A = GameObject.Find("MainCannon") as GameObject;
			//Destroy(A);
			Destroy (GameObject.Find("MainCannon"));
			//SpaceShipsAdmin.instance.Targets.Remove(A);
		}
		if(PlayerGameObject.GetComponent<Player>().RightCannonLife <= 0)
		{
			GameObject A = GameObject.Find("RightCannon") as GameObject;
			Destroy(A);
			SpaceShipsAdmin.instance.Targets.Remove(A);
		}

		if(PlayerGameObject.GetComponent<Player>().LeftCannonLife <= 0)
		{
			GameObject A = GameObject.Find("LeftCannon") as GameObject;
			Destroy(A);
			SpaceShipsAdmin.instance.Targets.Remove(A);
		}
		if(PlayerGameObject.GetComponent<Player>().CityLife <= 0)
		{
			GameObject A = GameObject.Find("City") as GameObject;
			Destroy(A);
			SpaceShipsAdmin.instance.Targets.Remove(A);
		}*/
	}
}
