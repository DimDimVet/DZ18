using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using NUnit.Framework;

public class BullAction
{
    private GameObject _testObject;

    [SetUp]
    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }

    [UnityTest]
    public IEnumerator InstantBull()
    {
        //�������� ������ ������������ Assing
        yield return new WaitForSeconds(3);
        _testObject = (GameObject)Resources.Load("Bull");
        Debug.Log($"������ ������ - {_testObject}");

        //�������� ����� Act
        bool isBull = _testObject.GetComponent<Bull>() is Bull;

        //������� Assert
        Debug.Log($"��������� - {isBull}");
        UnityEngine.Assertions.Assert.IsNotNull(_testObject);
        UnityEngine.Assertions.Assert.IsTrue(isBull);
    }

    [UnityTest]
    public IEnumerator MoveBull()
    {
        //�������� ������ ������������ Assing
        yield return new WaitForSeconds(5);
        _testObject = (GameObject)Resources.Load("Bull");
        _testObject.AddComponent<Renderer>();
        Debug.Log($"������ ������ - {_testObject}");

        //�������� ����� Act
        Bull _testObjectScript = _testObject.GetComponent<Bull>();
        _testObjectScript.ShootBull(true, _testObject.gameObject.transform);
        Vector3 startPointTransform = _testObject.gameObject.transform.position;
        _testObjectScript.isRun = true;
        _testObjectScript.isStop = true;
        _testObjectScript.MoveBull();
        yield return new WaitForSeconds(1);
        Vector3 finishPointTransform = _testObject.gameObject.transform.position;

        //������� Assert
        Debug.Log($"��������� - {startPointTransform} {finishPointTransform}");
        UnityEngine.Assertions.Assert.IsFalse(startPointTransform == finishPointTransform);
    }

    [UnityTearDown]
    public void CloseScene()
    {
        GameObject.Destroy(_testObject);
    }
}
