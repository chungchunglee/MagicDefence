using System.Collections;
using UnityEngine;

namespace Script
{
    public class MonsterLauncher : MonoBehaviour
    {
        [SerializeField] private Monster weakMonsterPrefab;

        private Factory _weakMonsterFactory;

        // Start is called before the first frame update
        private void Start()
        {
            _weakMonsterFactory = new Factory(weakMonsterPrefab);
            StartCoroutine(WeakMonsterCoroutine());
        }

        private IEnumerator WeakMonsterCoroutine()
        {
            while (true)
            {
                OnWeakMonsterSpawn();
                yield return new WaitForSeconds(0.5f);
            }
        }

        private void OnWeakMonsterSpawn()
        {
            var weakMonster = _weakMonsterFactory.Get();
            var randomInt = Random.Range(0, 3); // y 축 랜덤좌표
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
    }
}
