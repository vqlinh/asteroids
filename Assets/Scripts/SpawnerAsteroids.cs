using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerAsteroids : MonoBehaviour
{
    public Asteroid AsteroidPrefabs;
    public float SpawnRate = 2.0f;
    public int SpawnAmount = 1;
    public float SpawnDistance = 1.0f;
    public float TrajectoryVariance = 1.0f;
    private void Start()
    {
        InvokeRepeating(nameof(Spawn), this.SpawnRate, this.SpawnRate);
    }
    private void Spawn()
    {
        for (int i = 0; i < this.SpawnAmount; i++)
        {
            Vector3 SpawnDirection = Random.insideUnitCircle.normalized * this.SpawnDistance;
            Vector3 SpawnPoint = this.transform.position + SpawnDirection;

            float variance = Random.Range(-this.TrajectoryVariance, this.TrajectoryVariance);
            Quaternion rotation = Quaternion.AngleAxis(variance, Vector3.forward);
            Asteroid Asteroid = Instantiate(this.AsteroidPrefabs, SpawnPoint, rotation);
            Asteroid.Size = Random.Range(Asteroid.MinSize, Asteroid.MaxSize);
            Asteroid.SetTrajectory(rotation * -SpawnDirection);
        }
    }
}
