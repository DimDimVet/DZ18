using System;
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;
using UnityEngine.Windows;

public class NewTestScript
{
    private Healt _char;

    [SetUp]//под этим мы указываем метод который определит последовательсность контроля
    public void TestSetup()
    {
        SceneManager.LoadScene(0);//загрузим сцену
    }

    //[TearDown]
    //public void Teardown()
    //{
    //    SceneManager.UnloadScene(0);//загрузим сцену
    //    //UnityEngine.Object.Destroy(_char1.gameObject);
    //}

    [UnityTest]//Первая группа тестов
    public IEnumerator A_PlayerTest()
    {
        yield return new WaitForSeconds(5);
        _char = GameObject.FindObjectOfType<Healt>();//найдем объект со скриптом
        UnityEngine.Assertions.Assert.IsNotNull(_char);

        _char.HealtCount = 100;
        yield return new WaitForSeconds(1);
        //UnityEngine.Assertions.Assert.IsNotNull(_char);//объект должен быть нулем

        //yield return null;
        //Assert.AreEqual(true,true);//проверим что true равен true
    }

    [UnityTest]//Вторая группа тестов
    public IEnumerator B_HealtPlayerTest()
    {
        //if (_char == null)
        //{
        //    yield return null;
        //}

        _char.HealtCount = 100;
        yield return new WaitForSeconds(1);
        UnityEngine.Assertions.Assert.IsNotNull(_char);//объект должен быть нулем
    }

    [UnityTest]//Вторая группа тестов
    public IEnumerator C_HealtPlayerTest()
    {
        if (_char == null)
        {
            yield return null;
        }

        //_char.HealtCount = 0;
        //yield return new WaitForSeconds(1);
        //UnityEngine.Assertions.Assert.IsNull(_char);//объект должен быть нулем
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
