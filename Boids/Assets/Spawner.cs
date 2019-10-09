using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    static public Spawner S;
    static public List<Boid> boids;

    [Header("Spawning")]
    public Boid boidPrefab;
    public Transform boidAnchor;
    public int numBoids = 100;
    public float spawnRadius = 100f;
    public float spawnDelay = 0.1f;

    [Header("Boids")]
    public float velocity = 30f;
    public float neighborDist = 30f;
    public float collDist = 4f;
    public float velMatching = 0.25f;
    public float flockCentering = 0.2f;
    public float collAvoid = 2f;
    public float attractPull = 2f;
    public float attractPush = 2f;
    public float attactPushDist = 5f;

    // LAB 1
    public bool attackingCamera
    {
         get; private set;
    }

    void Awake()
    {
        S = this;
        boids = new List<Boid>();
        attackingCamera = false;
    }

    public void InstantiateBoid()
    {   
        if (boids.Count < numBoids && !attackingCamera)
        {
            Invoke("InstantiateBoid", spawnDelay);
            Boid boid = Instantiate<Boid>(boidPrefab);
            boid.transform.SetParent(boidAnchor);
            boids.Add(boid);
        }
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        attackingCamera = Input.GetKey(KeyCode.A);
        InstantiateBoid();
	}
}
