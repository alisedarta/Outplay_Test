using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    [SerializeField] GameObject prefab;
    [SerializeField] GameObject mainPlayer;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] GameObject particles;
    [SerializeField] AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        
        spawn();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void spawn()
    {
        float posX;
        float posY;
        Vector2 pos;
        for (int i = 0; i < 100; i++)
        {
            posX = Random.Range(spriteRenderer.sprite.bounds.min.x - 3.5f, spriteRenderer.sprite.bounds.max.x + 3.5f);
            posY = Random.Range(spriteRenderer.sprite.bounds.min.y - 1.5f, spriteRenderer.sprite.bounds.max.y + 1.5f);
            pos = new Vector2(posX, posY);

            Instantiate(prefab, pos, Quaternion.identity);
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            particles.transform.position = mainPlayer.transform.position;
            particles.GetComponent<ParticleSystem>().Play();
           
            mainPlayer.SetActive(false);
            audioSource.Play();

        }
    }
}
