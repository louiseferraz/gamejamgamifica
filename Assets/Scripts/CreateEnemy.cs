using UnityEngine;

public class CreateEnemies : MonoBehaviour
{
    // Modelo do inimigo a ser criado
    [SerializeField] private EnemyMovement enemyModel;
    // Intervalo de tempo entre dois inimigos a serem criados
    [SerializeField] private float intervalBetweenSpawns = 4f;
    // Distância do jogador no qual o inimigo será criado
    [SerializeField] private float distance;

    //Contador para criação de inimigos, no qual informa o intervalo de tempo de criação de cada um
    private float counter;

    //Método de criação dos inimigos
    private void Update() 
    {
        counter += Time.deltaTime;
    
        if(counter >= intervalBetweenSpawns)
        {
            counter = 0;
            Spawn();
        }
    }

    //Randomizar o local de nascimento dos inimigos.

    private void Spawn()
    {
        Vector3 position = Random.insideUnitCircle.normalized * distance;
        var enemy = Instantiate(enemyModel, transform.position + position, Quaternion.identity);
    }
}