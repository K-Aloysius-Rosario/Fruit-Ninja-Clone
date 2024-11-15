using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
public class Objects : MonoBehaviour
{
    private Rigidbody targetRb;
    private int lowerBound = -6;
    [SerializeField] ParticleSystem explosionEffects;
    [SerializeField] int scorePoint;
    private Spawner spawnerScript;
    private void Awake()
    {
        targetRb = GetComponent<Rigidbody>();
        spawnerScript = GameObject.Find("GameManager").GetComponent<Spawner>();
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnTarget();
        if(spawnerScript.gameOver == true)
        {
            Destroy(gameObject);
        }
    }
    // Update is called once per frame
    void Update()
    {
    }
    void SpawnTarget()
    {
        targetRb.AddForce(Vector3.up * PickForce(), ForceMode.Impulse);
        targetRb.AddTorque(PickTorque(), PickTorque(), PickTorque(), ForceMode.Impulse);
        transform.position = PickPos();
        float PickForce()
        {
            return Random.Range(13.0f, 15.0f);
        }
        Vector3 PickPos()
        {
            return new Vector3(Random.Range(-4, 4), -2.5f, Random.Range(1.5f, -2.0f));
        }
        float PickTorque()
        {
            return Random.Range(-9, 9);
        }
    }
    void OnMouseDown()
    {
        Destroy(gameObject);
        Instantiate(explosionEffects,transform.position,transform.rotation);
        spawnerScript.Score(scorePoint);
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
    }
    
}
