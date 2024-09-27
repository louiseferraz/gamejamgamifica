using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int maxHealth = 2;
    public int currentHealth;
    private Vector3 initialPos;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        initialPos = transform.position;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        // Estamos checando se a "tag" do nosso objeto é Player.
        if(tag == "Player")
        {
            // Caso o objeto de fato seja o player, vamos mover ele para a posição inicial do jogo.
            transform.position = initialPos;
        }

        if(currentHealth == 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
