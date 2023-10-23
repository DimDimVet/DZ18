using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class NewTestScript
{
    private Healt _char;

    //tresh
    //// A Test behaves as an ordinary method
    //[Test]
    //public void NewTestScriptSimplePasses()
    //{
    //    // Use the Assert class to test conditions
    //}

    //// A UnityTest behaves like a coroutine in Play Mode. In Edit Mode you can use
    //// `yield return null;` to skip a frame.

    [SetUp]//под этим мы указываем метод который определит последовательсность контроля
    public void TestSetup()
    {
        StartTestMetod();
    }

    [UnityTest]//Первая группа тестов
    public IEnumerator A_PlayerTest()
    {
        yield return new WaitForSeconds(5);
        FindObjectPlayer();
        PosTestMetod();

        //yield return null;
        //Assert.AreEqual(true,true);//проверим что true равен true
    }

    private void StartTestMetod()
    {
        SceneManager.LoadScene(0);//загрузим сцену

    }

    private void FindObjectPlayer()
    {
        _char = GameObject.FindObjectOfType<Healt>();//найдем объект со скриптом
    }

    private void PosTestMetod()
    {
        UnityEngine.Assertions.Assert.IsNotNull(_char);
    }

    [UnityTest]//Вторая группа тестов
    public IEnumerator B_HealtPlayerTest()
    {

        if (_char == null)
        {
            yield return null;
        }

        _char.HealtCount = 0;
        yield return new WaitForSeconds(1);
        UnityEngine.Assertions.Assert.IsNull(_char);//объект должен быть нулем
    }
}

//Цель практической работы
//Научиться работать с Unit-тестами.



//Что нужно сделать
//Внедрите в проект Test Framework.
//Напишите для игры пять разных Unit-тестов, которые должны проверять разные модули игры.


//Советы и рекомендации
//Старайтесь разносить тесты по разным классам в соответствии с тем, что они проверяют.



//Что оценивается
//Наличие Unit-тестов в проекте и их проходимость.



//Как отправить работу на проверку
//Пришлите архив проекта Unity через форму ниже.
