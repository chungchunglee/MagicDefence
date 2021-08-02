using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class MonsterLauncher : MonoBehaviour
    {
        [SerializeField] private Monster weakMonsterPrefab;
        [SerializeField] private Monster strongMonsterPrefab;

        private Factory _weakMonsterFactory;

        // Start is called before the first frame update
        private void Start()
        {
            _weakMonsterFactory = new Factory(weakMonsterPrefab);
            StartCoroutine(WeakMonsterCoroutine());
        }

        // Update is called once per frame
        private void Update()
        {
            
        }
        
        private IEnumerator WeakMonsterCoroutine()
        {
            while (true)
            {
                OnWeakMonsterSpawn();
                yield return new WaitForSeconds(5.0f);
            }
        }

        private void OnWeakMonsterSpawn()
        {
            var weakMonster = _weakMonsterFactory.Get();
            weakMonster.transform.position = new Vector3(this.transform.position.x, -1.8f,0);
            weakMonster.destroyed += OnWeakMonsterDestroyed;
        }
        
        private void OnWeakMonsterDestroyed(RecycleObject diedWeakMonster)
        {
            diedWeakMonster.destroyed -= OnWeakMonsterDestroyed;
            _weakMonsterFactory.Restore(diedWeakMonster);
        }
    }
}
