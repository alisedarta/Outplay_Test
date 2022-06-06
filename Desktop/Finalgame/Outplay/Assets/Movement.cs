using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] Transform[] points;
    [SerializeField] float speed;
    [SerializeField] GameObject particles;
    [SerializeField] GameObject mainPlayer;
    [SerializeField] AudioSource audioSource;
    Transform nextPoint;
    int nextIndex;
    // Start is called before the first frame update
    void Start()
    {
        nextPoint = points[0];
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    void Move()
    {
        if(transform.position == nextPoint.position)
        {
            nextIndex++;
            if (nextIndex < points.Length)
            {
                nextPoint = points[nextIndex];
            }
            
        }
        if (transform.position == points[points.Length - 1].position)
        {
            particles.transform.position = mainPlayer.transform.position;
            particles.GetComponent<ParticleSystem>().Play();
            mainPlayer.SetActive(false);
            audioSource.Play();
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPoint.position, speed * Time.deltaTime);
        }
    }
}
