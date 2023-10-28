using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class Inputs
{
    private GameObject _testObject;

    [UnitySetUp]
    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }

    [UnityTest]
    public IEnumerator TestUserInput()
    {
        //Создадим объект тестирования Assing
        yield return new WaitForSeconds(1);
        _testObject = (GameObject)Resources.Load("ModelPlayer");
        MovePlayer _testObjectScript = _testObject.GetComponent<MovePlayer>();
        Debug.Log($"Создан объект - {_testObject}");

        //Действие теста Act
        Vector3 startPointTransform = _testObject.gameObject.transform.position;
        _testObjectScript.InputData=new InputData { Move = new Vector2(1, 1) };
        _testObjectScript.isRun=true;
        _testObjectScript.speedMove = 1000;
        _testObjectScript.Move();
        yield return new WaitForSeconds(1);
        Vector3 finishPointTransform = _testObject.gameObject.transform.position;

        //Сравним Assert
        Debug.Log($"Результат - {startPointTransform} {finishPointTransform}");
        UnityEngine.Assertions.Assert.IsFalse(startPointTransform == finishPointTransform);
    }

    [UnityTearDown]
    public void CloseScene()
    {
        GameObject.Destroy(_testObject);
    }
}
