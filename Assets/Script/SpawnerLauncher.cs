using UnityEngine;

namespace Script
{
    public class SpawnerLauncher : MonoBehaviour
    {
        [SerializeField] private Spawner spawnerPrefab;
        private Spawner _spawner;

        private GameObject _weakMonster;
        private Monster _monster;
        private bool _isSpawnerNotNull;

        // Start is called before the first frame update
        private void Start()
        {
            _isSpawnerNotNull = _spawner != null;
        }

        // Update is called once per frame
        private void Update()
        {
            if (!_isSpawnerNotNull) return;
            if (_spawner.hp == 0)
            {
                _monster.attack -= _spawner.OnDamaged;
            }
        }

        public void OnSpawnerButtonPressed()
        {
            _weakMonster = GameObject.FindWithTag("Weak Monster"); // 임시 테스트용
            _monster = _weakMonster.GetComponent<Monster>();
            _spawner = Instantiate(spawnerPrefab);
            _spawner.transform.position = this.transform.position;
            _monster.attack += _spawner.OnDamaged;
        }
    }
}
