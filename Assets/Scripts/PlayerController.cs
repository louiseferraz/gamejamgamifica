using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

//Controle do jogador
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float speed; //velocidade do jogador
    [SerializeField] private GameObject trailRenderer;
    [SerializeField] private float trailTime = 3;


    private float dashSpeed;


    private void Start() 
    {
        dashSpeed = speed * 2;
    }

    //onde está o jogador
    void Update()
    {
        Mover();  
    }

    //Método de movimento do jogador
    private void Mover()
    {
        var horizontal = Input.GetAxis("Horizontal") * Vector3.right;
        var vertical = Input.GetAxis("Vertical") * Vector3.up;
           
        var direction = (horizontal + vertical).normalized * Time.deltaTime * speed;
        
        transform.position += direction;
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.tag == "Boots")
        {
            Destroy(other.gameObject);
            speed = dashSpeed; 
            StartCoroutine(DeactivateSpeed());
        }
    }

    private IEnumerator DeactivateSpeed()
    {
        yield return new WaitForSeconds(trailTime);

        speed = dashSpeed / 2;
    }
}