using UnityEngine;

namespace Script
{
    public class SpawnerLauncher : MonoBehaviour
    {
        [SerializeField] private Spawner spawnerPrefab;

        private Factory _spawnerFactory;
        
        // Start is called before the first frame update
        private void Start()
        {
            _spawnerFactory = new Factory(spawnerPrefab);
        }

        public void OnSpawnerButtonPressed()
        {
            var spawner = _spawnerFactory.Get();
            // y축 랜덤좌표
            var randomInt = Random.Range(0, 3);
            var newY = randomInt switch
            {
                0 => -0.8f,
                1 => 1.6f,
                2 => 4.0f,
                _ => 0
            };
            spawner.transform.position = new Vector3(this.transform.position.x, newY,0);
            spawner.destroyed += OnSpawnerDestroyed;
        }

        private void OnSpawnerDestroyed(RecycleObject diedSpawner)
        {
            diedSpawner.destroyed -= OnSpawnerDestroyed;
            _spawnerFactory.Restore(diedSpawner);
        }
    }
}