using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int Vida;
    private Rigidbody2D rig;
    public int Velocidade;
    public int ForcaPulo;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rig.velocity = new Vector2(Velocidade, rig.velocity.y);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.velocity = new Vector2(rig.velocity.x, ForcaPulo);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Life")
        {
            Vida += 10;
            Debug.Log($"Valor da vida = {Vida}");
            Destroy(collision.gameObject);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Spike")
        {
            Vida -= 10;
            Debug.Log($"Valor da vida = {Vida}");
        }
    }
}
