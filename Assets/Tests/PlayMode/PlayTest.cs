using NUnit.Framework;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayTest
{
    private Healt gameObject;

    [SetUp]
    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }

    [UnityTest]
    public IEnumerator InstantPlayer()
    {
        var gameGameObject =
        MonoBehaviour.Instantiate(Resources.Load<GameObject>("Resources/ModelPlayer"));
        var _testObject = gameGameObject.GetComponent<Healt>();
        yield return new WaitForSeconds(5);

        Debug.Log($"{gameGameObject}< {_testObject}");
        _testObject.HealtCount=100;

        yield return new WaitForSeconds(1);

        UnityEngine.Assertions.Assert.IsNotNull(_testObject);
    }
}
