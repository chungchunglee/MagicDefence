using System.Collections;
using UnityEngine;

namespace Script
{
    public class MonsterLauncher : MonoBehaviour
    {
        [SerializeField] private Monster weakMonsterPrefab;
        [SerializeField] private StrongMonster strongMonsterPrefab;

        private Factory _weakMonsterFactory;
        private Factory _strongMonsterFactory;

        // Start is called before the first frame update
        private void Start()
        {
            _weakMonsterFactory = new Factory(weakMonsterPrefab);
            _strongMonsterFactory = new Factory(strongMonsterPrefab);
            StartCoroutine(MonsterCoroutine());
        }

        private IEnumerator MonsterCoroutine()
        {
            while (true)
            {
                OnWeakMonsterSpawn();
                OnStrongMonsterSpawn();
                yield return new WaitForSeconds(2.5f);
            }
        }

        private void OnWeakMonsterSpawn()
        {
            var weakMonster = _weakMonsterFactory.Get();
            var randomInt = Random.Range(0, 3); // y축 랜덤좌표
            var newY = randomInt switch
            {
                0 => -1.8f,
                1 => 0.6f,
                2 => 3.0f,
                _ => 0
            };
            weakMonster.transform.position = new Vector3(this.transform.position.x, newY,0);
            weakMonster.destroyed += OnWeakMonsterDestroyed;
        }
        
        private void OnWeakMonsterDestroyed(RecycleObject diedWeakMonster)
        {
            diedWeakMonster.destroyed -= OnWeakMonsterDestroyed;
            _weakMonsterFactory.Restore(diedWeakMonster);
        }
        
        private void OnStrongMonsterSpawn()
        {
            var strongMonster = _strongMonsterFactory.Get();
            var randomInt = Random.Range(0, 3); // y축 랜덤좌표
            var newY = randomInt switch
            {
                0 => -1.8f,
                1 => 0.6f,
                2 => 3.0f,
                _ => 0
            };
            strongMonster.transform.position = new Vector3(this.transform.position.x, newY,0);
            strongMonster.destroyed += OnStrongMonsterDestroyed;
        }
        
        private void OnStrongMonsterDestroyed(RecycleObject diedStrongMonster)
        {
            diedStrongMonster.destroyed -= OnStrongMonsterDestroyed;
            _strongMonsterFactory.Restore(diedStrongMonster);
        }
    }
}
