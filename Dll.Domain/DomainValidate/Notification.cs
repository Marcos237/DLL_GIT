using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Domain.Entity
{
    public class Notification
    { 
        public int Value { get; set; }
        public string Menssagem { get; set; }
        public DateTime Data { get; set; }


        public Notification()
        {

        }
        public Notification(int _value, string _mensagem, DateTime _data)
        {
            Value = _value;
            Menssagem = _mensagem;
            Data = _data;
        }
    }
}
