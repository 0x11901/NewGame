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
        public int spreadAmount;
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
            var rotation = spawnPoint.eulerAngles;

            if (useEcs)
            {
                if (spreadShot)
                {
                    SpawnBulletSpreadEcs(rotation);
                }
                else
                {
                    SpawnBulletEcs(rotation);
                }
            }
            else
            {
                if (spreadShot)
                {
                    SpawnBulletSpread(rotation);
                }
                else
                {
                    SpawnBullet(rotation);
                }
            }


            if (spawnParticles)
            {
                spawnParticles.Play();
            }

            if (spawnAudioSource)
            {
                spawnAudioSource.Play();
            }
        }

        private void SpawnBullet(Vector3 rotation)
        {
            Instantiate(projectilePrefab, spawnPoint.position, Quaternion.Euler(rotation));
        }

        private void SpawnBulletSpread(Vector3 rotation)
        {
            var max = spreadAmount / 2;
            var min = -max;
            var tempRotation = rotation;
            for (var x = min; x < max; ++x)
            {
                tempRotation.x = (rotation.x + 3 * x) % 360;

                for (var y = min; y < max; ++y)
                {
                    tempRotation.y = (rotation.y + 3 * y) % 360;

                    Instantiate(projectilePrefab, spawnPoint.position, Quaternion.Euler(tempRotation));
                }
            }
        }

        private void SpawnBulletEcs(Vector3 rotation)
        {
            // EntityManager manager = World
        }

        private void SpawnBulletSpreadEcs(Vector3 rotation)
        {
            var max = spreadAmount / 2;
            var min = -max;
            var tempRotation = rotation;
            for (var x = min; x < max; ++x)
            {
                tempRotation.x = (rotation.x + 3 * x) % 360;

                for (var y = min; y < max; ++y)
                {
                    tempRotation.y = (rotation.y + 3 * y) % 360;
                    //TODO: ecs
                }
            }
        }
    }
}