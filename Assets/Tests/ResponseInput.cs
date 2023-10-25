using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class ResponseInput
{
    private MovePlayer _input;

    //[SetUp]//под этим мы указываем метод который определит последовательсность контроля
    //public void TestSetup()
    //{
    //    StartTestMetod();
    //}

    //private void StartTestMetod()
    //{
    //    SceneManager.LoadScene(0);//загрузим сцену

    //}

    [UnityTest]
    public IEnumerator C_ResponseInput()
    {
        yield return new WaitForSeconds(1);
        //FindObject1();
        //PosTestMetod1();
        //if (_input == null)
        //{
        //    yield return null;
        //}

        //yield return new WaitForSeconds(2);
        //PosTestMetod();
    }

    private void FindObject1()
    {
        _input = GameObject.FindObjectOfType<MovePlayer>();//найдем объект со скриптом
        Debug.Log(_input);
    }

    private void PosTestMetod1()
    {
        UnityEngine.Assertions.Assert.IsNotNull(_input);
    }
}
