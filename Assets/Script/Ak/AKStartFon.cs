using System.Collections;
using UnityEngine;

public class AKStartFon : MonoBehaviour
{
    [SerializeField] private AK.Wwise.Event audioEvent;
    private void OnEnable()
    {
        StartCoroutine(Example());
    }
    private void OnDisable()
    {
        audioEvent.Stop(this.gameObject);
    }

    private IEnumerator Example()
    {
        yield return new WaitForSeconds(1f);
        audioEvent.Post(this.gameObject);
    }
}
