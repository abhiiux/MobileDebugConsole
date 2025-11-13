using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace MobileDebugger
{
    public class ConsoleHandler : MonoBehaviour
    {
        [SerializeField] GameObject messagePrefab;
        public string debugTimer
        {
            get
            {
                return $" [ {DateTime.Now:HH:mm:ss} ] ";
            }
        }
        List<TMP_Text> messageList = new List<TMP_Text>();


        void OnEnable()
        {
            Application.logMessageReceived += CreateMessage;
        }
        void OnDisable()
        {
            Application.logMessageReceived -= CreateMessage;
        }

        public void CreateMessage(string message, string stackTrace, LogType logType)
        {
            string latestMessage = message;
            GameObject customMessage = Instantiate(messagePrefab);
            if (customMessage.TryGetComponent<TMP_Text>(out TMP_Text _text))
            {
                messageList.Add(_text);
                customMessage.transform.SetParent(this.transform, false);

                PrintAccordingToType(logType, _text);
                _text.text = debugTimer + latestMessage;

                if (customMessage.transform.GetChild(0).TryGetComponent<TMP_Text>(out TMP_Text _scriptText))
                {
                    _scriptText.text = $"{ExtractDetailsFromMethod(stackTrace)}";
                }
            }
        }

        private string ExtractDetailsFromMethod(string stackTrace)
        {
            string after;
            string path = stackTrace;

            int index = path.IndexOf("Scripts/");

            if (index != -1)
            {
                after = path.Substring(index + "Scripts/".Length);
            }
            else
            {
                after = " ";
            }
            return after;
        }
        private void PrintAccordingToType(LogType type, TMP_Text text)
        {
            switch (type)
            {
                case LogType.Log:
                    text.color = Color.black;
                    break;
                case LogType.Warning:
                    text.color = Color.yellow;
                    break;
                case LogType.Error:
                    text.color = Color.red;
                    break;
            }
        }
    }
}
