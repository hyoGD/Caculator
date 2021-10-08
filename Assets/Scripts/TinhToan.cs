using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
public class TinhToan : MonoBehaviour
{
    public Text input;
    public Text Show;
    public Text report;
    string first = "";
    string second = "";
    char function;
    double result = 0.0;
    string userInput = "";
    bool check= false;
   
    bool ngoac = true;


    public void ButtoncLick()
    {
        if (check)
        {
            userInput = "";
            check = false;
            //input.text = "";
        }
        userInput += EventSystem.current.currentSelectedGameObject.name;
        input.text = userInput;

        if (userInput == ".")
        {
            if (!input.text.Contains("."))
            {
                input.text += userInput;
            }
        }
    }
    public void Dau_phay()
    {

        if (!input.text.Contains("."))
        {
            userInput = ".";
            input.text += ",";
        }
    }
    public void ClearButon(int scenID )
    {
        //second = "";
        //first = "";
        //userInput = "";
        //result = 0.0;
        //input.text = "0";
        //Show.text = "";
        //report.text = "";
        SceneManager.LoadScene(scenID);
    }
    public void Chia()
    {
        input.text += "÷";
        function = '/';
        Show.text = input.text;

        first = userInput;
        userInput = "";
       
    }
    public void Nhan()
    {
        input.text += "x";
        function = '*';
        Show.text = input.text;

        first = userInput;
        userInput = "";     
    }
    public void Cong()
    {     
        function = '+';
        input.text += "+";
        Show.text = input.text;
      
        first = userInput;
        userInput = "";
   
    }
    public void Tru()
    {
        input.text += "-";
        function = '-';
        Show.text = input.text;

        first = userInput;
        userInput = "";    
    }
    public void Mu()
    {
        input.text += "^";
        function = '^';
        Show.text = input.text;

        first = userInput;
        userInput = "";
    }
    public void Bi()
    {
        input.text += "π";
        function = 'π';
        userInput = Mathf.PI.ToString();
        input.text = userInput;
        first = userInput;

        check = true;
    }

    public void Ketqua()
    {
        second = userInput;
       
        double firstNum, secondNum;
        firstNum = double.Parse(first);
        secondNum = double.Parse(second);

        if (input.text.Length == 0)
        {
            input.text = "0";
        }
       
        switch (function)
        {
            case '+':
                Show.text = first + " + " + second + " =  ";
                result = firstNum + secondNum;
                break;
            case '-':
                Show.text = first + " - " + second + " =  ";
                result = firstNum - secondNum;
                break;
            case '*':
                Show.text = first + " × " + second + " =  ";
                result = firstNum * secondNum;
                break;
            case '/':
                Show.text = first + " ÷ " + second + " =  ";
                result = firstNum / secondNum;
                break;
            case '^':
                Show.text = first + "^" + second + " =  ";
                int a = int.Parse(first);
                int b = int.Parse(second);
                result = Mathf.Pow(a,b);
                break;

        }
       
        input.text =  result.ToString();
        userInput = result.ToString();
        first = userInput;
        check = true;

        Debug.Log(firstNum + "      " + secondNum);
    }

    public void Delete()
    {
        if (input.text.Length != 0)
        {
            if (userInput.Substring(userInput.Length - 1).Equals("("))
            {
                ngoac = true;
                Debug.Log("Mo ngoac");
            }
            if (userInput.Substring(userInput.Length - 1).Equals(")"))
            {
                ngoac = false;
                Debug.Log("Dong ngoac");
            }
        }

        if (input.text.Length > 0)
        {
            userInput = userInput.Substring(0, userInput.Length - 1);
            input.text = userInput;

        }

        if (input.text == "")
        {

            input.text = "0";
        }      
    }

    public void Ngoac()
    {
        if (ngoac == true)
        {
            userInput += "(";
            input.text = userInput;
            ngoac = false;
        }
        else
        {
           userInput += ")";
            input.text = userInput;
            ngoac = true;
        }
    }
   

    public void nhiPhan()
    {
        int d = int.Parse(userInput);
        Show.text = d + " = ";
        string s = "";
        int c = d;

        for (int i = 0; i < c; i++)
        {
            if (d > 0)
            {
                s = s + d % 2;
                d = d / 2;
            }
        }

        if (s.Length < 8)
        {
            int l = s.Length;

            for (int i = 0; i < 8 - l; i++)
            {
                s = s + "0";
               
            }
        }
//dao? chuoi
        string s1 = "";
        for (int i = s.Length - 1; i >= 0; i--)
        {
            s1 += s[i];
        }
       
        input.text= s1 +  "₂";
        userInput = s1;
        check = true;
    }
   
    public void BatPhan_ThapPhan()
    {
        int n1, n5, p = 1, k, ch = 1;     
        int dec = 0, i = 1, j, d;
        n1 = int.Parse(userInput);
        Show.text = n1 + "₈" + " = ";
        n5 = n1;
        for (; n1 > 0; n1 = n1 / 10)
        {
            k = n1 % 10;
            if (k >= 8)
            {
                ch = 0;
            }
        }
        switch (ch)
        {
            case 0:
               report.text = "so vua nhap khong phai la so trong he bat phan!";
                break;
            case 1:
                report.text = "";
                n1 = n5;
                for (j = n1; j > 0; j = j / 10)
                {
                    d = j % 10;
                    if (i == 1)
                    {
                        p = p * 1;
                    }
                    else
                    {
                        p = p * 8;
                    }
                    dec = dec + (d * p);
                    i++;
                }
                input.text = dec.ToString();
                check = true;
                break;
        }
    }
   
    public void ThapPhan_BatPhan()
    {
        int n, i, j, dn;
        int ocno = 0;
        n = int.Parse(userInput);
        Show.text = n + " = ";
        dn = n;
        i = 1;
        for (j = n; j > 0; j = j / 8)
        {
            ocno = ocno + (j % 8) * i;
            i = i * 10;
            n = n / 8;
        }
       
        input.text = ocno.ToString() + "₈";
        userInput = ocno.ToString();
        check = true;
    }
    public void Thap_Phan()
    {
        int n = int.Parse(userInput);
        Show.text = n + "₂" + " = ";
        int n1, p = 1;
        int dec = 0, i = 1, d;
        n1 = n;
        for (int j = n; j > 0; j = j / 10)
        {
            d = j % 10;
            if (i == 1)
            {
                p = p * 1;
            }
            else
            {
                p = p * 2;
            }
            dec = dec + (d * p);
            i++;
        }
        input.text = dec.ToString() ;
        check = true;
    }

    public void DichTrai_Bit()
    {
        int y = int.Parse(userInput);
        int x;
        x = y << 1;
        input.text = x.ToString();
        check = true;
    }
    public void DichPhai_Bit()
    {
        int y = int.Parse(userInput);
        int x;
        x = y >> 1;
        input.text = x.ToString();
        check = true;
    }

    public void And()
    {
        bool ketqua;
        bool a = true;
        bool b = false;
        ketqua = a && b;
        input.text = ketqua.ToString();
        check = true;
    }
    public void NOT()
    {
        bool ketqua;
        bool a = true;
        bool b = false;
        ketqua = !a;
        input.text = ketqua.ToString();
        check = true;
    }
    public void OR()
    {
        bool ketqua;
        bool a = true;
        bool b = false;
        ketqua = a || b;
        input.text = ketqua.ToString();
        check = true;
    }
}

