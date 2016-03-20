using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttributes : MonoBehaviour 
{
	public static PlayerAttributes PlayerAttributesInstance;

	public bool CanShoot;
	//Matrizes com os atributos de cada arma.
	//Veja a planilha em anexo (Atributos das Armas).
	public int[,] Weapon_308_Attribute_Matrix = new int[6,5];
	public int[,] Weapon_500_Attribute_Matrix = new int[6,5];

	public List<bool> Weapon_Equiped;

	[HideInInspector]
	//308 Vars
	public int Weapon_308_Level,Weapon_308_Damage, Weapon_308_Cadence, Weapon_308_BulletSpeed, Weapon_308_Range, Weapon_308_Life, Weapon_308_Defense;
	//500 Vars
	public int Weapon_500_Level,Weapon_500_Damage, Weapon_500_Cadence, Weapon_500_BulletSpeed, Weapon_500_Range, Weapon_500_Life, Weapon_500_Defense;
	
	void Start () 
	{
		_308_Matrix_Attribute ();
		_500_Matrix_Attribute ();

		Weapon_Equiped [0] = true;//.308
		Weapon_Equiped [1] = false;//.500
	}

	void update()
	{
		Weapon_308_Damage = Weapon_308_Attribute_Matrix [0, Weapon_308_Level - 1];
		Weapon_308_Cadence = Weapon_308_Attribute_Matrix [1, Weapon_308_Level - 1];
		Weapon_308_BulletSpeed = Weapon_308_Attribute_Matrix [2, Weapon_308_Level - 1];
		Weapon_308_Range = Weapon_308_Attribute_Matrix [3, Weapon_308_Level - 1];
		Weapon_308_Life = Weapon_308_Attribute_Matrix [4, Weapon_308_Level - 1];
		Weapon_308_Defense = Weapon_308_Attribute_Matrix [5, Weapon_308_Level - 1];

		Weapon_500_Damage = Weapon_500_Attribute_Matrix [0, Weapon_500_Level - 1];
		Weapon_500_Cadence = Weapon_500_Attribute_Matrix [1, Weapon_500_Level - 1];
		Weapon_500_BulletSpeed = Weapon_500_Attribute_Matrix [2, Weapon_500_Level - 1];
		Weapon_500_Range = Weapon_500_Attribute_Matrix [3, Weapon_500_Level - 1];
		Weapon_500_Life = Weapon_308_Attribute_Matrix [4, Weapon_500_Level - 1];
		Weapon_500_Defense = Weapon_308_Attribute_Matrix [5, Weapon_500_Level - 1];
	}

	void Cadence_calculation()
	{

	}

	void _308_Matrix_Attribute()
	{
		//Atribuindo os valores da matriz
		//Coluna 01
		Weapon_308_Attribute_Matrix [0, 0] = 40;
		Weapon_308_Attribute_Matrix [1, 0] = 30;
		Weapon_308_Attribute_Matrix [2, 0] = 25;
		Weapon_308_Attribute_Matrix [3, 0] = 100;
		Weapon_308_Attribute_Matrix [4, 0] = 30;
		Weapon_308_Attribute_Matrix [5, 0] = 0;
		//Coluna 02
		Weapon_308_Attribute_Matrix [0, 1] = 50;
		Weapon_308_Attribute_Matrix [1, 1] = 30;
		Weapon_308_Attribute_Matrix [2, 1] = 30;
		Weapon_308_Attribute_Matrix [3, 1] = 100;
		Weapon_308_Attribute_Matrix [4, 0] = 40;
		Weapon_308_Attribute_Matrix [5, 0] = 10;
		//Coluna 03
		Weapon_308_Attribute_Matrix [0, 2] = 60;
		Weapon_308_Attribute_Matrix [1, 2] = 25;
		Weapon_308_Attribute_Matrix [2, 2] = 35;
		Weapon_308_Attribute_Matrix [3, 2] = 100;
		Weapon_308_Attribute_Matrix [4, 0] = 50;
		Weapon_308_Attribute_Matrix [5, 0] = 15;
		//Coluna 04
		Weapon_308_Attribute_Matrix [0, 3] = 70;
		Weapon_308_Attribute_Matrix [1, 3] = 25;
		Weapon_308_Attribute_Matrix [2, 3] = 40;
		Weapon_308_Attribute_Matrix [3, 3] = 100;
		Weapon_308_Attribute_Matrix [4, 0] = 70;
		Weapon_308_Attribute_Matrix [5, 0] = 25;
		//Coluna 05
		Weapon_308_Attribute_Matrix [0, 4] = 80;
		Weapon_308_Attribute_Matrix [1, 4] = 20;
		Weapon_308_Attribute_Matrix [2, 4] = 45;
		Weapon_308_Attribute_Matrix [3, 4] = 100;
		Weapon_308_Attribute_Matrix [4, 0] = 100;
		Weapon_308_Attribute_Matrix [5, 0] = 50;
	}

	void _500_Matrix_Attribute()
	{
		//Atribuindo os valores da matriz
		//Coluna 01
		Weapon_500_Attribute_Matrix [0, 0] = 40;
		Weapon_500_Attribute_Matrix [1, 0] = 30;
		Weapon_500_Attribute_Matrix [2, 0] = 25;
		Weapon_500_Attribute_Matrix [3, 0] = 100;
		Weapon_308_Attribute_Matrix [4, 0] = 30;
		Weapon_308_Attribute_Matrix [5, 0] = 0;
		//Coluna 02
		Weapon_500_Attribute_Matrix [0, 1] = 50;
		Weapon_500_Attribute_Matrix [1, 1] = 30;
		Weapon_500_Attribute_Matrix [2, 1] = 30;
		Weapon_500_Attribute_Matrix [3, 1] = 100;
		Weapon_308_Attribute_Matrix [4, 0] = 40;
		Weapon_308_Attribute_Matrix [5, 0] = 10;
		//Coluna 03
		Weapon_500_Attribute_Matrix [0, 2] = 60;
		Weapon_500_Attribute_Matrix [1, 2] = 25;
		Weapon_500_Attribute_Matrix [2, 2] = 35;
		Weapon_500_Attribute_Matrix [3, 2] = 100;
		Weapon_308_Attribute_Matrix [4, 0] = 50;
		Weapon_308_Attribute_Matrix [5, 0] = 15;
		//Coluna 04
		Weapon_500_Attribute_Matrix [0, 3] = 70;
		Weapon_500_Attribute_Matrix [1, 3] = 25;
		Weapon_500_Attribute_Matrix [2, 3] = 40;
		Weapon_500_Attribute_Matrix [3, 3] = 100;
		Weapon_308_Attribute_Matrix [4, 0] = 70;
		Weapon_308_Attribute_Matrix [5, 0] = 25;
		//Coluna 05
		Weapon_500_Attribute_Matrix [0, 4] = 80;
		Weapon_500_Attribute_Matrix [1, 4] = 20;
		Weapon_500_Attribute_Matrix [2, 4] = 45;
		Weapon_500_Attribute_Matrix [3, 4] = 100;
		Weapon_308_Attribute_Matrix [4, 0] = 100;
		Weapon_308_Attribute_Matrix [5, 0] = 50;
	}
}
