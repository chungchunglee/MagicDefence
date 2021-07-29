using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class MonsterLauncher : MonoBehaviour
    {
        [SerializeField] private Monster weakMonsterPrefab;
        [SerializeField] private Monster strongMonsterPrefab;
        private Monster _weakMonster;
        
        // Start is called before the first frame update
        private void Start()
        {
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
            _weakMonster = Instantiate(weakMonsterPrefab);
            _weakMonster.transform.position = new Vector3(this.transform.position.x, -1.8f,0);
        }
    }
}
