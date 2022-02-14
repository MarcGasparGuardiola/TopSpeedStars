using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Text.RegularExpressions;

namespace Gameplay.controllers
{
    public class Register : MonoBehaviour
    {
        public GameObject username;
        public GameObject password;
        public GameObject email;
        public GameObject confpassword;
        private string Username;
        private string Password;
        private string Email;
        private string Confpassword;
        private string form;
        private bool EmailValid = false;


        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            Username = username.GetComponent<InputField>().text;
            Password = password.GetComponent<InputField>().text;
            Email = email.GetComponent<InputField>().text;
            Confpassword = confpassword.GetComponent<InputField>().text;
        }
    }
}