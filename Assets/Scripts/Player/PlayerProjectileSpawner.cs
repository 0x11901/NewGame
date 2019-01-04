using UnityEngine;

namespace Player
{
    public class PlayerProjectileSpawner : MonoBehaviour
    {
        [SerializeField] private bool useEcs;
        [SerializeField] private bool spreadShot;

        [Header("Input")] public KeyCode spawnKey = KeyCode.Mouse0;

        [Header("Spawner Settings")] public GameObject projectilePrefab;
        public Transform spawnPoint;

        public float spawnRate;
        private float timer;


        [Header("Particles")] public ParticleSystem spawnParticles;


        [Header("Audio")] public AudioSource spawnAudioSource;


        private void Update()
        {
            timer += Time.deltaTime;

            if (Input.GetKey(spawnKey) && timer >= spawnRate)
            {
                SpawnProjectile();
            }
        }


        private void SpawnProjectile()
        {
            timer = 0f;
            Instantiate(projectilePrefab, spawnPoint.position, spawnPoint.rotation);

            if (spawnParticles)
            {
                spawnParticles.Play();
            }

            if (spawnAudioSource)
            {
                spawnAudioSource.Play();
            }
        }
    }
}