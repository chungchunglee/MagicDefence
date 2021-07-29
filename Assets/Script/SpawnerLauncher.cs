using UnityEngine;

namespace Script
{
    public class SpawnerLauncher : MonoBehaviour
    {
        [SerializeField] private Spawner spawnerPrefab;
        private Spawner _spawner;

        private GameObject _weakMonster;
        private Monster _monster;
        
        // Start is called before the first frame update
        private void Start()
        {

        }

        // Update is called once per frame
        private void Update()
        {
            if (_spawner != null)
            {
                if (_spawner._hp == 0)
                {
                    _monster.Attack -= _spawner.OnDamaged;
                }
            }
        }

        public void OnSpawnerButtonPressed()
        {
            _weakMonster = GameObject.FindWithTag("Weak Monster"); // 임시 테스트용
            _monster = _weakMonster.GetComponent<Monster>();
            _spawner = Instantiate(spawnerPrefab);
            _monster.Attack += _spawner.OnDamaged;
        }
    }
}
