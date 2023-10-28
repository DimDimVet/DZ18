using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PlayerTest
{
    private GameObject _testObject;

    [UnitySetUp]
    public void StartScene()
    {
        SceneManager.LoadScene(0);
    }

    [UnityTest]
    public IEnumerator InstantPlayer()
    {
        //Создадим объект тестирования Assing
        yield return new WaitForSeconds(1);
        _testObject = (GameObject)Resources.Load("ModelPlayer");
        Debug.Log($"Создан объект - {_testObject}");

        //Действие теста Act
        bool isRegistrator =_testObject.GetComponent<Registrator>() is Registrator;
        bool isMovePlayer = _testObject.GetComponent<MovePlayer>() is MovePlayer;
        bool isAnim= _testObject.GetComponent<AnimPlayer>() is AnimPlayer;
        bool isHealt = _testObject.GetComponent<Healt>() is Healt;

        //Сравним Assert
        Debug.Log($"Результат - {_testObject}");
        Debug.Log($"Результат - {isRegistrator},{isMovePlayer},{isAnim},{isHealt}");
        UnityEngine.Assertions.Assert.IsNotNull(_testObject);
        UnityEngine.Assertions.Assert.IsTrue(isRegistrator);
        UnityEngine.Assertions.Assert.IsTrue(isMovePlayer);
        UnityEngine.Assertions.Assert.IsTrue(isAnim);
        UnityEngine.Assertions.Assert.IsTrue(isHealt);

    }

    [UnityTest]
    public IEnumerator DeadPlayer()
    {
        //Создадим объект тестирования Assing
        yield return new WaitForSeconds(1);
        _testObject = (GameObject)Resources.Load("ModelPlayer");
        int _hash = 0;
        Debug.Log($"Создан объект - {_testObject}");

        //Действие теста Act
        Healt _testObjectScript = _testObject.GetComponent<Healt>();
        _testObjectScript.HealtContoll(_hash,int.MaxValue);

        //Сравним Assert
        Debug.Log($"Результат - {_testObjectScript.Dead}");
        UnityEngine.Assertions.Assert.AreEqual(true, _testObjectScript.Dead);
    }

    [UnityTearDown]
    public void CloseScene()
    {
        GameObject.Destroy(_testObject);
    }
}
