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
        //Создадим объект тестирования Assing
        yield return new WaitForSeconds(1);
        FPSCount _testObjectScript = GameObject.FindObjectOfType<FPSCount>();
        Debug.Log($"Найден объект - {_testObjectScript.gameObject.name}");

        //Действие теста Act
        yield return new WaitForSeconds(1);
        _testObjectScript.CountFPS();
        int rezult =_testObjectScript.FPS;

        //Сравним Assert
        Debug.Log($"Результат - {rezult}");
        UnityEngine.Assertions.Assert.IsNotNull(_testObjectScript);
        UnityEngine.Assertions.Assert.IsFalse(0==rezult);
    }
}
