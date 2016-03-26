using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanAircraftAttributes : MonoBehaviour 
{
	//Humam Ships Atributes
	/*Neste script, eu armazeno os valores de todos os
	 * atributos de todos os tipos de nave.
	 * Tambem executo os randoms, para valores que 
	 * nao sao "constantes".
	 * ------------------------------------------------------------------------------
	 * Damage = Define o quanto de dano a bala do inimigo inflige no player.
	 * Cadence = Define quantas vezes a nave irá atirar ao passar pelo cenário.
	 * PercenteCadence = Define qual a chance da nave atirar o mínimo de balas, ou o máximo de balas.
	 * Hit_Chance = Define qual a chance da bala disparada pela nave ir diretamente no player.
	 * Dispersion_Rate = Define quantas balas a nave pode vir a disparar a cada passada.
	 * Defense_Value = Define qual o valor mínimo e máximo de defesa. Esse valor é sorteado cada vez que a nave leva dano.
	 * YPositions = Armazena as posiçoes em Y que as navez podem passar.
	 */

	public static HumanAircraftAttributes Instance;

	public int[,] HShips_Basic_Attributes = new int[6,7]; //Armazena Dano[0, X], Velocidade do Projetil[1, X], Velocidade de movimento[2, X], vida[3, X], ContadorParaMover [4,X], Score[5,X]. 

	public List<int> Cadence, Dispersion_Rate,Defense_Value, YDelays;
	public List<float> PercenteCadence, Hit_Chance, YPositions;

	public List<GameObject> Bullets;
	public bool PleaseRandom;//Caso essa variavel se torne true, novos random sao feitos(apenas para as variaveis que sao definidas atraves de um random).

	void Start () 
	{ 
		//As funçoes terimadas em "ValueDefine" so serao chamadas no start, pois elas apenas definem valores para as variaveis.
		Basic_Attributes_ValueDefine();//Start
		Hit_Chance_ValueDefine ();//Start
		PercenteCadende_ValueDefine ();//Start
		YDelays_ValueRandom ();//NotStart
		Cadence_ValueRandom();//NotStart
		Bullet_Dispersion_ValueRandom();//NotStart
		Defense_Rate_ValueRandom();//NotStart
	}

	void Update () 
	{
		if(PleaseRandom)
		{
			/*Cadence_ValueRandom();
			Bullet_Dispersion_ValueRandom();
			Defense_Rate_ValueRandom();
			YDelays_ValueRandom();
			PleaseRandom = false;*/
		}
	}

	//-------------------------------Voids relacionadas a cadencia das naves.--------------------------------
	void PercenteCadende_ValueDefine()
	{
		//Define a porcentagem de dar o minimo de disparos
		PercenteCadence.Insert(0, 0.7f);//70% Aircraft01
		PercenteCadence.Insert(1, 0.6f);;//60% Aircraft02
		PercenteCadence.Insert(2, 0.5f);;//50% Aircraft03
		PercenteCadence.Insert(3, 0.3f);//30% Aircraft04
		PercenteCadence.Insert(4, 0.25f);//25% VTOLBoss
	}

	void Cadence_ValueRandom()
	{
		List<float> Percentage = new List<float>(6);

		for(int i = 0; i < Percentage.Capacity; i++)//Fazendo o sorteio de todos as porcentagens.
		{
			Percentage.Add (Random.value);
		}
		//Caso o valor do sorteio seja menor que a Porcentagem de cadencia, o minimo de tiros ocorre, senao, o maximo de tiros ocorre.
		if (Percentage[0] < PercenteCadence [0]) //Aircraft01
		{Cadence.Insert(0, 0);} 
		else 
		{Cadence.Insert(0, 1);}
		if (Percentage[1] < PercenteCadence [1]) //Aircraft02
		{Cadence.Insert(1, 0);} 
		else 
		{Cadence.Insert(1, 1);}
		if (Percentage[2] < PercenteCadence [2]) //Aircraft03
		{Cadence.Insert(2, 1);} 
		else 
		{Cadence.Insert(2, 2);}
		if (Percentage[3] < PercenteCadence [3]) //Aircraft04
		{Cadence.Insert(3, 1);} 
		else 
		{Cadence.Insert(3, 2);}
		if (Percentage[4] < PercenteCadence [4]) //VTOLBoss
		{Cadence.Insert(4, 2);} 
		else 
		{Cadence.Insert(4, 3);}
	}//------------------------------------------------------------------------------------------------------

	void Hit_Chance_ValueDefine()//Define a chance da bala ir diretamente para um alvo
	{//Sorteio e efetuado na propria classe da nave
		Hit_Chance.Insert(0, 0.8f);//Se o sorteio de Aircraft01 for maior que Hit_Chance[0], a bala acerta o canhao.
		Hit_Chance.Insert(1, 0.6f);//Se o sorteio for Aircraft02 que Hit_Chance[1], a bala acerta o canhao.
		Hit_Chance.Insert(2, 0.5f);//Se o sorteio for Aircraft03 que Hit_Chance[2], a bala acerta o canhao.
		Hit_Chance.Insert(3, 0.4f);//Se o sorteio for Aircraft04 que Hit_Chance[3], a bala acerta o canhao.
		Hit_Chance.Insert(4, 0.25f);//Se o sorteio for VTOLBoss que Hit_Chance[4], a bala acerta o canhao.
	}

	void YDelays_ValueRandom()
	{//Valor do delay em Y. Como funciona: Start > YIndex = 1 / QuandoNaveForPassarPeloCenario > YIndex += YDelay > Position.Y = [YIndex];
		YDelays.Insert (0, 1);
		YDelays.Insert (1, 1);
		YDelays.Insert (2, Random.Range(1,2));
		YDelays.Insert (3, Random.Range(1,2));
		YDelays.Insert (4, Random.Range	(1,6));
		YDelays.Insert (5, 0);
		YDelays.Insert (6, 0);
	}

	void Bullet_Dispersion_ValueRandom()
	{
		Dispersion_Rate.Insert(0, 1);// A Aircraft01 pode atirar 0 ou 1 bala a cada passada
		Dispersion_Rate.Insert(1, 1);// A Aircraft02 vai atirar 1 bala a cada passada
		Dispersion_Rate.Insert(2, Random.Range(1,2));// A Aircraft03 pode atirar entre 1 e 2 balas a cada passada
		Dispersion_Rate.Insert(3, Random.Range(1,2));// A Aircraft04 pode atirar entre 1 e 2 balas a cada passada
		Dispersion_Rate.Insert(4, Random.Range(2,3));// A VTOLBoss pode atirar entre 2 e 3 balas
	}

	void Defense_Rate_ValueRandom()
	{
		//A cada tiro que e levado, a nave recebe (Dano do tiro - Defesa da nave) de dano.
		Defense_Value.Insert(0, Random.Range (10, 16));// O valor da defesa da Aircraft01 pode ser entre 10 e 15
		Defense_Value.Insert(1, Random.Range (10, 16));// O valor da defesa da Aircraft02 pode ser entre 10 e 15
		Defense_Value.Insert(2, Random.Range (15, 21));// O valor da defesa da Aircraft03 pode ser entre 15 e 20
		Defense_Value.Insert(3, Random.Range (15, 26));// O valor da defesa da Aircraft04 pode ser entre 15 e 25
		Defense_Value.Insert(4, Random.Range (25, 41));// O valor da defesa da VTOLBoss pode ser entre 25 e 40
		Defense_Value.Insert(5, 15);// O valor da defesa da Cargo_Aircraft pode ser entre 25 e 40
		Defense_Value.Insert(6, 0);// O valor da defesa da Passenger_Aircraft pode ser entre 25 e 40
	}

	void Basic_Attributes_ValueDefine()
	{
		//Aircraft01
		HShips_Basic_Attributes [0, 0] = 5; //Damage
		HShips_Basic_Attributes [1, 0] = 15; //BulletSpeed
		HShips_Basic_Attributes [2, 0] = 15; //MovSpeed
		HShips_Basic_Attributes [3, 0] = 40; //Life
		HShips_Basic_Attributes [4, 0] = 900; //CounterToMove
		HShips_Basic_Attributes [5, 0] = 50; //Score
		//Aircraft02
		HShips_Basic_Attributes [0, 1] = 10; //Damage
		HShips_Basic_Attributes [1, 1] = 20; //BulletSpeed
		HShips_Basic_Attributes [2, 1] = 20; //MovSpeed
		HShips_Basic_Attributes [3, 1] = 50; //Life
		HShips_Basic_Attributes [4, 1] = 600; //CounterToMove
		HShips_Basic_Attributes [5, 1] = 150; //Score
		//Aircraft03
		HShips_Basic_Attributes [0, 2] = 15; //Damage
		HShips_Basic_Attributes [1, 2] = 30; //BulletSpeed
		HShips_Basic_Attributes [2, 2] = 25; //MovSpeed
		HShips_Basic_Attributes [3, 2] = 80; //Life
		HShips_Basic_Attributes [4, 2] = 300; //CounterToMove
		HShips_Basic_Attributes [5, 2] = 325; //Score
		//Aircraft04
		HShips_Basic_Attributes [0, 3] = 25; //Damage
		HShips_Basic_Attributes [1, 3] = 40; //BulletSpeed
		HShips_Basic_Attributes [2, 3] = 45; //MovSpeed
		HShips_Basic_Attributes [3, 3] = 160; //Life
		HShips_Basic_Attributes [4, 3] = 150; //CounterToMove
		HShips_Basic_Attributes [5, 3] = 500; //Score
		//VTOL boss
		HShips_Basic_Attributes [0, 4] = 40; //Damage
		HShips_Basic_Attributes [1, 4] = 50; //BulletSpeed
		HShips_Basic_Attributes [2, 4] = 65; //MovSpeed em Y
		HShips_Basic_Attributes [3, 4] = 500; //Life
		HShips_Basic_Attributes [4, 4] = 150; //CounterToMove
		HShips_Basic_Attributes [5, 4] = 1000; //Score
		//Cargo_Aircraft
		HShips_Basic_Attributes [0, 5] = 0; //Damage
		HShips_Basic_Attributes [1, 5] = 0; //BulletSpeed
		HShips_Basic_Attributes [2, 5] = 50; //MovSpeed
		HShips_Basic_Attributes [3, 5] = 20; //Life
		HShips_Basic_Attributes [4, 5] = 60; //CounterToMove
		HShips_Basic_Attributes [5, 5] = 250; //Score
		//Passenger_Aircraft
		HShips_Basic_Attributes [0, 6] = 0; //Damage
		HShips_Basic_Attributes [1, 6] = 0; //BulletSpeed
		HShips_Basic_Attributes [2, 6] = 25; //MovSpeed
		HShips_Basic_Attributes [3, 6] = 20; //Life
		HShips_Basic_Attributes [4, 6] = 120; //CounterToMove
		HShips_Basic_Attributes [5, 6] = -100; //Score

		//YPositions
		YPositions.Insert(0, 17f);
		YPositions.Insert(1, 13.5f);
		YPositions.Insert (2, 10f);
		YPositions.Insert (3, 6.5f);
		YPositions.Insert (4, 3f);
		YPositions.Insert (5, -0.5f);
	}
}
