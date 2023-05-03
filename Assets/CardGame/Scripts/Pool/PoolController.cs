using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace CardGame.Pool
{
    namespace Pools
    {
        public class PoolController : MonoBehaviour
        {
            [SerializeField] private GameObject _prefab;

            private Queue<GameObject> _pool;


            private void Awake()
            {
                _pool = new Queue<GameObject>();
            }


            public GameObject GetFromPool(Transform parent)
            {
                var obj = _pool.Count > 0 ? _pool.Dequeue() : Instantiate(_prefab, null);

                obj.transform.SetParent(parent);
                obj.transform.localScale = Vector3.one;
                obj.SetActive(true);

                return obj;
            }


            public void GiveToPool(GameObject obj)
            {
                obj.SetActive(false);
                _pool.Enqueue(obj);
                //obj.transform.SetParent(transform);
            }
        }
    }
}