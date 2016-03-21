using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerAttributes : MonoBehaviour 
{
	public static PlayerAttributes PlayerAttributesInstance;

	//Matrizes com os atributos de cada arma.
	//Veja a planilha em anexo (Atributos das Armas).
	public int[,] Weapon_308_Attribute_Matrix = new int[6,5];
	public int[,] Weapon_500_Attribute_Matrix = new int[6,5];

	[Header("Bullet Pref")]
	public GameObject Bullet;

	[HideInInspector]public bool MainCanShoot, RightCanShoot, LeftCanShoot;
	[HideInInspector]public float MainDelay, RightDelay, LeftDelay;
	[HideInInspector]public float MainStartDelay, RightStartDelay, LeftStartDelay;

	[Range(0,5)]public int Weapon_Equip_Index;
	public List<bool> Weapon_Equipped;
	
	//Weapon Equipped
	[HideInInspector]public int Weapon_Equipped_Level, Weapon_Equipped_Damage, Weapon_Equipped_Cadence, Weapon_Equipped_BulletSpeed, Weapon_Equipped_Range, Weapon_Equipped_Life, Weapon_Equipped_Defense; 
	
	//308 Vars
	[HideInInspector]public int Weapon_308_Level,Weapon_308_Damage, Weapon_308_Cadence, Weapon_308_BulletSpeed, Weapon_308_Range, Weapon_308_Life, Weapon_308_Defense;
	
	//500 Vars
	[HideInInspector]public int Weapon_500_Level,Weapon_500_Damage, Weapon_500_Cadence, Weapon_500_BulletSpeed, Weapon_500_Range, Weapon_500_Life, Weapon_500_Defense;
	
	void Start () 
	{
		//Atribuindo os valores a matrix de cada tipo de canhao, conforme os valores que estao na planilha
		_308_Matrix_Attribute ();
		_500_Matrix_Attribute ();

		//Atribuindo o valor inicial das variaveis de delay
		MainStartDelay = MainDelay;
		RightStartDelay = RightDelay;
		LeftStartDelay = LeftDelay;

		//Atribuindo o nivel dos canhoes
		Weapon_308_Level = 1;
		Weapon_500_Level = 4;
	}

	void Update()
	{
		//Decrescendo os delays
		MainDelay--;
		RightDelay--;
		LeftDelay--;

		//Atribuindo os valores das variaveis de cada canhao com os valores das tabelas, e modificando eles em funçao do nivel
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

		Equipping_Weapon ();

		Cadence_calculation ();
	}
	
	void Equipping_Weapon()
	{
		for(int i = 0; i < Weapon_Equipped.Count; i++)
		{
			if(i != Weapon_Equip_Index)
			{
				Weapon_Equipped[i] = false;
			}else
			{
				Weapon_Equipped[i] = true;
			}
		}

		if(Weapon_Equipped[0] == true)
		{
			Weapon_Equipped_Level = Weapon_308_Level;
			Weapon_Equipped_Damage = Weapon_308_Damage;
			Weapon_Equipped_Cadence = Weapon_308_Cadence;
			Weapon_Equipped_BulletSpeed = Weapon_308_BulletSpeed;
			Weapon_Equipped_Range = Weapon_308_Range;
			Weapon_Equipped_Life = Weapon_308_Life;
			Weapon_Equipped_Defense = Weapon_308_Defense;
		}

		if(Weapon_Equipped[1] == true)
		{
			Weapon_Equipped_Level = Weapon_500_Level;
			Weapon_Equipped_Damage = Weapon_500_Damage;
			Weapon_Equipped_Cadence = Weapon_500_Cadence;
			Weapon_Equipped_BulletSpeed = Weapon_500_BulletSpeed;
			Weapon_Equipped_Range = Weapon_500_Range;
			Weapon_Equipped_Life = Weapon_500_Life;
			Weapon_Equipped_Defense = Weapon_500_Defense;
		}
	}

	void Cadence_calculation()
	{
		if (MainDelay < 0)
			MainCanShoot = true;
		else
			MainCanShoot = false;

		if (RightDelay < 0)
			RightCanShoot = true;
		else
			RightCanShoot = false;

		if (LeftDelay < 0)
			LeftCanShoot = true;
		else
			LeftCanShoot = false;
	}

	void _308_Matrix_Attribute()
	{
		//Atribuindo os valores da matriz
		//Coluna 01
		Weapon_308_Attribute_Matrix [0, 0] = 40; //Damage
		Weapon_308_Attribute_Matrix [1, 0] = 30; //Cadence
		Weapon_308_Attribute_Matrix [2, 0] = 25; //BulletSpeed
		Weapon_308_Attribute_Matrix [3, 0] = 100;//Range
		Weapon_308_Attribute_Matrix [4, 0] = 30; //Life
		Weapon_308_Attribute_Matrix [5, 0] = 0;  //Defense
		//Coluna 02
		Weapon_308_Attribute_Matrix [0, 1] = 50; //Damage
		Weapon_308_Attribute_Matrix [1, 1] = 30; //Cadence
		Weapon_308_Attribute_Matrix [2, 1] = 30; //BulletSpeed
		Weapon_308_Attribute_Matrix [3, 1] = 100;//Range
		Weapon_308_Attribute_Matrix [4, 1] = 40; //Life
		Weapon_308_Attribute_Matrix [5, 1] = 10; //Defense
		//Coluna 03
		Weapon_308_Attribute_Matrix [0, 2] = 60; //Damage
		Weapon_308_Attribute_Matrix [1, 2] = 25; //Cadence
		Weapon_308_Attribute_Matrix [2, 2] = 35; //BulletSpeed
		Weapon_308_Attribute_Matrix [3, 2] = 100;//Range
		Weapon_308_Attribute_Matrix [4, 2] = 50; //Life
		Weapon_308_Attribute_Matrix [5, 2] = 15; //Defense
		//Coluna 04
		Weapon_308_Attribute_Matrix [0, 3] = 70; //Damage
		Weapon_308_Attribute_Matrix [1, 3] = 25; //Cadence
		Weapon_308_Attribute_Matrix [2, 3] = 40; //BulletSpeed
		Weapon_308_Attribute_Matrix [3, 3] = 100;//Range
		Weapon_308_Attribute_Matrix [4, 3] = 70; //Life
		Weapon_308_Attribute_Matrix [5, 3] = 25; //Defense
		//Coluna 05
		Weapon_308_Attribute_Matrix [0, 4] = 80; //Damage
		Weapon_308_Attribute_Matrix [1, 4] = 20; //Cadence
		Weapon_308_Attribute_Matrix [2, 4] = 45; //BulletSpeed
		Weapon_308_Attribute_Matrix [3, 4] = 100;//Range
		Weapon_308_Attribute_Matrix [4, 4] = 100;//Life
		Weapon_308_Attribute_Matrix [5, 4] = 50; //Defense
	}

	void _500_Matrix_Attribute()
	{
		//Atribuindo os valores da matriz
		//Coluna 01
		Weapon_500_Attribute_Matrix [0, 0] = 40; //Damage
		Weapon_500_Attribute_Matrix [1, 0] = 30; //Cadence
		Weapon_500_Attribute_Matrix [2, 0] = 25; //BulletSpeed
		Weapon_500_Attribute_Matrix [3, 0] = 100;//Range
		Weapon_308_Attribute_Matrix [4, 0] = 30; //Life
		Weapon_308_Attribute_Matrix [5, 0] = 0;  //Defense
		//Coluna 02
		Weapon_500_Attribute_Matrix [0, 1] = 50; //Damage
		Weapon_500_Attribute_Matrix [1, 1] = 30; //Cadence
		Weapon_500_Attribute_Matrix [2, 1] = 30; //BulletSpeed
		Weapon_500_Attribute_Matrix [3, 1] = 100;//Range
		Weapon_308_Attribute_Matrix [4, 1] = 40; //Life
		Weapon_308_Attribute_Matrix [5, 1] = 10; //Defense
		//Coluna 03
		Weapon_500_Attribute_Matrix [0, 2] = 60; //Damage
		Weapon_500_Attribute_Matrix [1, 2] = 25; //Cadence
		Weapon_500_Attribute_Matrix [2, 2] = 35; //BulletSpeed
		Weapon_500_Attribute_Matrix [3, 2] = 100;//Range
		Weapon_308_Attribute_Matrix [4, 2] = 50; //Life
		Weapon_308_Attribute_Matrix [5, 2] = 15; //Defense
		//Coluna 04
		Weapon_500_Attribute_Matrix [0, 3] = 70; //Damage
		Weapon_500_Attribute_Matrix [1, 3] = 25; //Cadence
		Weapon_500_Attribute_Matrix [2, 3] = 40; //BulletSpeed
		Weapon_500_Attribute_Matrix [3, 3] = 100;//Range
		Weapon_308_Attribute_Matrix [4, 3] = 70; //Life
		Weapon_308_Attribute_Matrix [5, 3] = 25; //Defense
		//Coluna 05
		Weapon_500_Attribute_Matrix [0, 4] = 80; //Damage
		Weapon_500_Attribute_Matrix [1, 4] = 20; //Cadence
		Weapon_500_Attribute_Matrix [2, 4] = 45; //BulletSpeed
		Weapon_500_Attribute_Matrix [3, 4] = 100;//Range
		Weapon_308_Attribute_Matrix [4, 4] = 100;//Life
		Weapon_308_Attribute_Matrix [5, 4] = 50; //Defense
	}
}
