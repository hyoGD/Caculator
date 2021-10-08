using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
public class Caculator : MonoBehaviour
{
    public Text Input;
    string inputString;
    int sceneID;
    int[] number = new int[2];
    string check;
    double ketqua;
    bool ngoac = true;
    bool kq_dauvao = false;
    int i = 0;

    public void ButtonPressed()
    {
        if (kq_dauvao == true)
        {
            Input.text = "";
            inputString = "";
            kq_dauvao = false;
        }
      //  Debug.Log(EventSystem.current.currentSelectedGameObject.name);

        string buttonvalue = EventSystem.current.currentSelectedGameObject.name;
        inputString += buttonvalue;

        int arg;
        if (int.TryParse(buttonvalue, out arg))
        {
            if (i > 1)
            {
                i = 0;
            }
            number[i] = arg;
            i = i + 1;
        }
        else
        {
            switch (buttonvalue)
            {
                case "+":
                    check = buttonvalue;
                    break;
                case "-":
                    check = buttonvalue;
                    break;
                case "x":
                    check = buttonvalue;
                    break;
                case "÷":
                    check = buttonvalue;
                    break;
                case "=":
                    switch (check)
                    {
                        case "+":
                            ketqua = number[0] + number[1] ;
                            break;
                        case "-":
                            ketqua = number[0] - number[1];
                            break;
                        case "x":
                            ketqua = number[0] * number[1];
                            break;
                        case "÷":
                            ketqua = number[0] / number[1];
                            break;
                    }
                    inputString = ketqua.ToString();
                    kq_dauvao = true;
                    number = new int[2];
                    break;
            }
        }

        //  inputString += buttonvalue;

        Input.text = inputString;
    }

    public void Reset(int sceneID)
    {
        SceneManager.LoadScene(sceneID);

    }

    public void Delete()
    {
        if (Input.text.Length != 0)
        {
            if (inputString.Substring(inputString.Length - 1).Equals("("))
            {
                ngoac = true;
                Debug.Log("Mo ngoac");
            }

            if (inputString.Substring(inputString.Length - 1).Equals(")"))
            {
                ngoac = false;
                Debug.Log("Dong ngoac");
            }

        }

        // Debug.Log(inputString.Substring(inputString.Length-1));
        if (Input.text.Length > 0)
        {
            inputString = inputString.Substring( 0,inputString.Length - 1);
            
            Input.text = inputString;

        }
        if (Input.text == "")
        {

            Input.text = "0";
        }
       
    }
        public void Ngoac()
        {
            if (ngoac == true)
            {
            inputString += "(";
                Input.text = inputString;
                ngoac = false;
            }
            else
            {
            inputString += ")";
            Input.text = inputString;
                ngoac = true;
            }
        }

    public void  nhiPhan()
    {   
        int d = int.Parse(inputString);
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
            int l= s.Length;

            for (int i = 0; i < 8 - l; i++)
            {
                s = s + "0";
                Debug.Log(s.Length);
            }
        }

        string s1 = "";
        for (int i = s.Length - 1; i >= 0; i--)
        {
            s1 += s[i];
        }
        Input.text = s1 + "₂";
    }
  
}

    

