using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HumanAircraftAttributes : MonoBehaviour 
{
	//Humam Ships Atributes
	/*Neste script, eu armazeno os valores de todos os
	 * atributos das naves Humanas.
	 * Tambem executo os randoms, para valores que 
	 * nao sao "constantes".
	 * ------------------------------------------------------------------------------
	 * Damage = Define o quanto de dano a bala inflige no player.
	 * Cadence = Define quantas vezes a nave irá atirar ao passar pelo cenário.
	 * PercenteCadence = Define qual a chance da nave atirar o mínimo de vezes, ou o máximo de vezes.
	 * PercenteHit = Define qual a chance da bala disparada pela nave ir diretamente no player.
	 * Dispersion = Define quantas balas a nave ira disparar a cada passada.
	 * Defense_Rate = Define qual o valor da defesa, que varia entre sei minimo e seu maximo.
	 * YPositions = Armazena as posiçoes em Y que as navez podem passar.
	 */

	public static HumanAircraftAttributes Instance;
	//Valores Constantes
	public int[,] HShips_Basic_Attributes = new int[6,7]; //Armazena Dano[0, X], Velocidade do Projetil[1, X], Velocidade de movimento[2, X], vida[3, X], ContadorParaMover [4,X], Score[5,X].
	public List<GameObject> Bullets;
	public List<float> YPositions;
	//Valores Variaveis
	public List<int> Cadence, Dispersion,Defense_Rate, YDelays;
	public List<float> PercenteCadence, PercenteHit, PercentageToCompare;
	public bool PleaseRandom;//Caso essa variavel se torne true, novos random sao feitos(apenas para nao constantes).

	void Start () 	//As funçoes terminadas em "Define" ou "Inicializations" serao chamadas apenas no Start
	{ 
		Lists_Inicializations ();
		Basic_Attributes_Define();
	}

	void Update () //As funçoes terminadas em "Random" serao chamadas no Start e no Update
	{
		if(PleaseRandom)
		{
			Cadence_Random();
			Dispersion_Random();
			Defense_Rate_Random();
			YDelays_Random();
			PleaseRandom = false;
		}
	}
	//-------------------------------Voids da cadencia das naves.--------------------------------
	void Cadence_Random()
	{
		for(int i = 0; i < 5; i++)//Fazendo o sorteio de todos as porcentagens.
		{PercentageToCompare[i] = Random.value;}
		//Caso o valor do sorteio seja menor que a Porcentagem de cadencia, o minimo de tiros ocorre, senao, o maximo de tiros ocorre.
		if (PercentageToCompare[0] < PercenteCadence [0]) //Aircraft01
		{Cadence[0] = 0;} 
		else 
		{Cadence[0] = 1;}
		if (PercentageToCompare[1] < PercenteCadence [1]) //Aircraft02
		{Cadence[1] = 0;} 
		else 
		{Cadence[1] = 1;}
		if (PercentageToCompare[2] < PercenteCadence [2]) //Aircraft03
		{Cadence[2] = 1;} 
		else 
		{Cadence[2] = 2;}
		if (PercentageToCompare[3] < PercenteCadence [3]) //Aircraft04
		{Cadence[3] = 1;} 
		else 
		{Cadence[3] = 2;}
		if (PercentageToCompare[4] < PercenteCadence [4]) //VTOLBoss
		{Cadence[4] = 2;} 
		else 
		{Cadence[4] = 3;}
	}//------------------------------------------------------------------------------------------------------
	
	void Dispersion_Random()
	{
		Dispersion[0] = 1;											// A Aircraft01 pode atirar 0 ou 1 bala cada vez que for atirar
		Dispersion[1] = 1;											// A Aircraft02 vai atirar 1 bala cada vez que for atirar
		Dispersion[2] = Random.Range(1,2);							// A Aircraft03 pode atirar entre 1 e 2 balas cada vez que for atirar
		Dispersion[3] = Random.Range(1,2);							// A Aircraft04 pode atirar entre 1 e 2 balas cada vez que for atirar
		Dispersion[4] = Random.Range(2,3);	
	}

	void Defense_Rate_Random()
	{	// Os valores da defesa da Cargo_Aircraft e Passenger_Aircraft sao consecutivamente 15 e 0
		Defense_Rate[0] = Random.Range (10, 16);					// O valor da defesa da Aircraft01 pode ser entre 10 e 15
		Defense_Rate[1] = Random.Range (10, 16);					// O valor da defesa da Aircraft02 pode ser entre 10 e 15
		Defense_Rate[2] = Random.Range (15, 21);					// O valor da defesa da Aircraft03 pode ser entre 15 e 20
		Defense_Rate[3] = Random.Range (15, 26);					// O valor da defesa da Aircraft04 pode ser entre 15 e 25
		Defense_Rate[4] = Random.Range (25, 41);					// O valor da defesa da VTOLBoss pode ser entre 25 e 40
	}

	void YDelays_Random()
	{
		YDelays [0] = 1;
		YDelays [1] = 1;
		YDelays [2] = Random.Range(1,2);
		YDelays [3] = Random.Range(1,2);
		YDelays [4] = Random.Range(1,6);
		YDelays [5] = 0;
		YDelays [6] = 0;
	}

	void Basic_Attributes_Define()
	{
		//Aircraft01
		HShips_Basic_Attributes [0, 0] = 5;  //Damage
		HShips_Basic_Attributes [1, 0] = 15; //BulletSpeed
		HShips_Basic_Attributes [2, 0] = 15; //MovSpeed
		HShips_Basic_Attributes [3, 0] = 40; //Life
		HShips_Basic_Attributes [4, 0] = 900;//CounterToMove
		HShips_Basic_Attributes [5, 0] = 50; //Score
		//Aircraft02
		HShips_Basic_Attributes [0, 1] = 10; //Damage
		HShips_Basic_Attributes [1, 1] = 20; //BulletSpeed
		HShips_Basic_Attributes [2, 1] = 20; //MovSpeed
		HShips_Basic_Attributes [3, 1] = 50; //Life
		HShips_Basic_Attributes [4, 1] = 600;//CounterToMove
		HShips_Basic_Attributes [5, 1] = 150;//Score
		//Aircraft03
		HShips_Basic_Attributes [0, 2] = 15; //Damage
		HShips_Basic_Attributes [1, 2] = 30; //BulletSpeed
		HShips_Basic_Attributes [2, 2] = 25; //MovSpeed
		HShips_Basic_Attributes [3, 2] = 80; //Life
		HShips_Basic_Attributes [4, 2] = 300;//CounterToMove
		HShips_Basic_Attributes [5, 2] = 325;//Score
		//Aircraft04
		HShips_Basic_Attributes [0, 3] = 25; //Damage
		HShips_Basic_Attributes [1, 3] = 40; //BulletSpeed
		HShips_Basic_Attributes [2, 3] = 45; //MovSpeed
		HShips_Basic_Attributes [3, 3] = 160;//Life
		HShips_Basic_Attributes [4, 3] = 150;//CounterToMove
		HShips_Basic_Attributes [5, 3] = 500;//Score
		//VTOL boss
		HShips_Basic_Attributes [0, 4] = 40;  //Damage
		HShips_Basic_Attributes [1, 4] = 50;  //BulletSpeed
		HShips_Basic_Attributes [2, 4] = 65;  //MovSpeed em Y
		HShips_Basic_Attributes [3, 4] = 500; //Life
		HShips_Basic_Attributes [4, 4] = 150; //CounterToMove
		HShips_Basic_Attributes [5, 4] = 1000;//Score
		//Cargo_Aircraft
		HShips_Basic_Attributes [0, 5] = 0;  //Damage
		HShips_Basic_Attributes [1, 5] = 0;  //BulletSpeed
		HShips_Basic_Attributes [2, 5] = 50; //MovSpeed
		HShips_Basic_Attributes [3, 5] = 20; //Life
		HShips_Basic_Attributes [4, 5] = 60; //CounterToMove
		HShips_Basic_Attributes [5, 5] = 250;//Score
		//Passenger_Aircraft
		HShips_Basic_Attributes [0, 6] = 0;   //Damage
		HShips_Basic_Attributes [1, 6] = 0;   //BulletSpeed
		HShips_Basic_Attributes [2, 6] = 25;  //MovSpeed
		HShips_Basic_Attributes [3, 6] = 20;  //Life
		HShips_Basic_Attributes [4, 6] = 120; //CounterToMove
		HShips_Basic_Attributes [5, 6] = -100;//Score
	}

	void Lists_Inicializations()//Chamada no Start, inicia as listas, para que valores possam ser atribuidos a elas.
	{
		//--------Iniciando a Lista "PercenteCadence":---				Define a porcentagem de dar o minimo de disparos
		PercenteCadence.Insert(0, 0.7f);								//70% Aircraft01
		PercenteCadence.Insert(1, 0.6f);								//60% Aircraft02
		PercenteCadence.Insert(2, 0.5f);								//50% Aircraft03
		PercenteCadence.Insert(3, 0.3f);								//30% Aircraft04
		PercenteCadence.Insert(4,0.25f);								//25% VTOLBoss
		//--------Iniciando a Lista "PercentageToCompare"-
		for(int i = 0; i < 5; i++)
		{
			PercentageToCompare.Insert(i, Random.value);
		}
		//--------Iniciando a Lista "Cadence":-----------
		Cadence.Insert (0, 0);											//Iniciando a cadencia de Aircraft01 no valor minimo
		Cadence.Insert (1, 0);											//Iniciando a cadencia de Aircraft02 no valor minimo
		Cadence.Insert (2, 1);											//Iniciando a cadencia de Aircraft03 no valor minimo
		Cadence.Insert (3, 1);											//Iniciando a cadencia de Aircraft04 no valor minimo
		Cadence.Insert (4, 2);											//Iniciando a cadencia de VTOLBoss no valor minimo
		//--------Iniciando a Lista "PercenteHit":-------
		PercenteHit.Insert(0, 0.8f);									//Se o sorteio de Aircraft01 for maior que PercenteHit[0], a bala acerta o canhao.
		PercenteHit.Insert(1, 0.6f);									//Se o sorteio de Aircraft02 for maior que PercenteHit[1], a bala acerta o canhao.
		PercenteHit.Insert(2, 0.5f);									//Se o sorteio de Aircraft03 for maior que PercenteHit[2], a bala acerta o canhao.
		PercenteHit.Insert(3, 0.4f);									//Se o sorteio de Aircraft04 for maior que PercenteHit[3], a bala acerta o canhao.
		PercenteHit.Insert(4,0.25f);									//Se o sorteio de VTOLBoss for maior que PercenteHit[4], a bala acerta o canhao.
		//--------Iniciando a Lista "yDelays":-----------				Como funciona: NavePosition.Y = yDelays[YIndex];
		YDelays.Insert (0, 1);
		YDelays.Insert (1, 1);
		YDelays.Insert (2, Random.Range(1,2));
		YDelays.Insert (3, Random.Range(1,2));
		YDelays.Insert (4, Random.Range	(1,6));
		YDelays.Insert (5, 0);
		YDelays.Insert (6, 0);
		//--------Iniciando a Lista "Dispersion":--------
		Dispersion.Insert(0, 1);										// A Aircraft01 pode atirar 0 ou 1 bala cada vez que for atirar
		Dispersion.Insert(1, 1);										// A Aircraft02 vai atirar 1 bala cada vez que for atirar
		Dispersion.Insert(2, Random.Range(1,2));						// A Aircraft03 pode atirar entre 1 e 2 balas cada vez que for atirar
		Dispersion.Insert(3, Random.Range(1,2));						// A Aircraft04 pode atirar entre 1 e 2 balas cada vez que for atirar
		Dispersion.Insert(4, Random.Range(2,3));						// A VTOLBoss pode atirar entre 2 e 3 balas cada vez que for atirar
		//--------Iniciando a Lista "Defense_Rate":------				(Dano do tiro recebido - Defesa da nave)
		Defense_Rate.Insert(0, Random.Range (10, 16));					// O valor da defesa da Aircraft01 pode ser entre 10 e 15
		Defense_Rate.Insert(1, Random.Range (10, 16));					// O valor da defesa da Aircraft02 pode ser entre 10 e 15
		Defense_Rate.Insert(2, Random.Range (15, 21));					// O valor da defesa da Aircraft03 pode ser entre 15 e 20
		Defense_Rate.Insert(3, Random.Range (15, 26));					// O valor da defesa da Aircraft04 pode ser entre 15 e 25
		Defense_Rate.Insert(4, Random.Range (25, 41));					// O valor da defesa da VTOLBoss pode ser entre 25 e 40
		Defense_Rate.Insert(5, 15);										// O valor da defesa da Cargo_Aircraft pode ser entre 25 e 40
		Defense_Rate.Insert(6, 0);										// O valor da defesa da Passenger_Aircraft pode ser entre 25 e 40
		//--------Iniciando a Lista "YPositions":--------
		YPositions.Insert(0, 17f);
		YPositions.Insert(1, 13.5f);
		YPositions.Insert (2, 10f);
		YPositions.Insert (3, 6.5f);
		YPositions.Insert (4, 3f);
		YPositions.Insert (5, -0.5f);
		YPositions.Insert (5, -4f);
	}
}