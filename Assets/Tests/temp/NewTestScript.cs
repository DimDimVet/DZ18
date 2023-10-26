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

    [SetUp]//��� ���� �� ��������� ����� ������� ��������� ������������������� ��������
    public void TestSetup()
    {
        SceneManager.LoadScene(0);//�������� �����
    }

    //[TearDown]
    //public void Teardown()
    //{
    //    SceneManager.UnloadScene(0);//�������� �����
    //    //UnityEngine.Object.Destroy(_char1.gameObject);
    //}

    [UnityTest]//������ ������ ������
    public IEnumerator A_PlayerTest()
    {
        yield return new WaitForSeconds(5);
        _char = GameObject.FindObjectOfType<Healt>();//������ ������ �� ��������
        UnityEngine.Assertions.Assert.IsNotNull(_char);

        _char.HealtCount = 100;
        yield return new WaitForSeconds(1);
        //UnityEngine.Assertions.Assert.IsNotNull(_char);//������ ������ ���� �����

        //yield return null;
        //Assert.AreEqual(true,true);//�������� ��� true ����� true
    }

    [UnityTest]//������ ������ ������
    public IEnumerator B_HealtPlayerTest()
    {
        //if (_char == null)
        //{
        //    yield return null;
        //}

        _char.HealtCount = 100;
        yield return new WaitForSeconds(1);
        UnityEngine.Assertions.Assert.IsNotNull(_char);//������ ������ ���� �����
    }

    [UnityTest]//������ ������ ������
    public IEnumerator C_HealtPlayerTest()
    {
        if (_char == null)
        {
            yield return null;
        }

        //_char.HealtCount = 0;
        //yield return new WaitForSeconds(1);
        //UnityEngine.Assertions.Assert.IsNull(_char);//������ ������ ���� �����
    }
}

//���� ������������ ������
//��������� �������� � Unit-�������.



//��� ����� �������
//�������� � ������ Test Framework.
//�������� ��� ���� ���� ������ Unit-������, ������� ������ ��������� ������ ������ ����.


//������ � ������������
//���������� ��������� ����� �� ������ ������� � ������������ � ���, ��� ��� ���������.



//��� �����������
//������� Unit-������ � ������� � �� ������������.



//��� ��������� ������ �� ��������
//�������� ����� ������� Unity ����� ����� ����.
