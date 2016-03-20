using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour 
{
	public int Force;

	void Update () 
	{
		//Testando de quem esta bala e "filho", dependendo de quem seja o pai desta bala, ela recebe atributos diferentes
		switch(this.gameObject.transform.parent.name)
		{
		case "MainCannon":
			this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(0, Force);
			break;
			
		case "RightCannon":
			this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-Force, Force);
			break;
			
		case "LeftCannon":
			this.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(Force, Force);
			break;
		}

		if(this.gameObject.transform.position.y > 20)
		{
			Destroy(this.gameObject);
		}
	}

	void OnTriggerEnter2D(Collider2D Other)
	{
		if(Other.gameObject.tag == "Enemy")
		{
			Destroy(this.gameObject);
			Destroy(Other.gameObject);
		}
	}
}
