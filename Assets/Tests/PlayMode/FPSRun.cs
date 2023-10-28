using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class FPSRun
{
    private GameObject _testObject;

    [SetUp]
    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }

    [UnityTest]
    public IEnumerator FPSAction()
    {
        //�������� ������ ������������ Assing
        yield return new WaitForSeconds(1);
        FPSCount _testObjectScript = GameObject.FindObjectOfType<FPSCount>();
        Debug.Log($"������ ������ - {_testObjectScript.gameObject.name}");

        //�������� ����� Act
        yield return new WaitForSeconds(1);
        _testObjectScript.CountFPS();
        int rezult =_testObjectScript.FPS;

        //������� Assert
        Debug.Log($"��������� - {rezult}");
        UnityEngine.Assertions.Assert.IsNotNull(_testObjectScript);
        UnityEngine.Assertions.Assert.IsFalse(0==rezult);
    }
}
