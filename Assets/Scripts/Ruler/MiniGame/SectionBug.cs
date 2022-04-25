using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionBug : MonoBehaviour
{
    [SerializeField]
    private GameObject PREFAB_Bug;
    private void Start()
    {
        this.StartCoroutine(this.IENMakeBugs());
    }
    private IEnumerator IENMakeBugs()
    {
        while(true)
        {
            var bug = Object.Instantiate<GameObject>(
                    this.PREFAB_Bug, this.transform).GetComponent<Bug>();
            bug.Open();

            yield return new WaitForSeconds(0.5f);
        }
    }
}
