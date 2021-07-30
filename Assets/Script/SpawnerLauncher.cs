using UnityEngine;

namespace Script
{
    public class SpawnerLauncher : MonoBehaviour
    {
        [SerializeField] private Spawner spawnerPrefab;

        private Factory _spwanerFactory;
        
        // Start is called before the first frame update
        private void Start()
        {
            _spwanerFactory = new Factory(spawnerPrefab);
        }

        // Update is called once per frame
        private void Update()
        {

        }

        public void OnSpawnerButtonPressed()
        {
            var spawner = _spwanerFactory.Get();
            spawner.transform.position = new Vector3(this.transform.position.x, -0.8f,0);
            spawner.destroyed += OnSpawnerDestroyed;
        }

        private void OnSpawnerDestroyed(RecycleObject diedSpawner)
        {
            var lastBulletPosition = diedSpawner.transform.position;
            diedSpawner.destroyed -= OnSpawnerDestroyed;
            _spwanerFactory.Restore(diedSpawner);
        }
    }
}