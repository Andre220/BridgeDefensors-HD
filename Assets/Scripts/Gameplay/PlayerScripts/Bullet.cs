using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public int BulletSpeed;

	void Start()
	{
		BulletSpeed = GameObject.Find ("GameAdmin").GetComponent<PlayerAttributes> ().Weapon_Equipped_BulletSpeed;
	}

	void Update () 
	{
		//Testando de quem esta bala e "filho", dependendo de quem seja o pai desta bala, ela recebe atributos diferentes
		switch(this.gameObject.transform.parent.name)
		{
		case "MainCannon":
			this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, BulletSpeed);
			break;
			
		case "RightCannon":
			this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-BulletSpeed, BulletSpeed);
			break;
			
		case "LeftCannon":
			this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(BulletSpeed, BulletSpeed);
			break;
		}

		if(this.gameObject.transform.position.y > 20)
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D Other)
	{
		if(Other.gameObject.tag == "Ship")
		{
			Destroy(this.gameObject);
			Destroy(Other.gameObject);
		}
	}
}
