﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace BeautySalonBusinessLogic.ViewModel
{
    [DataContract]
    public class ClientViewModel
    {
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [DisplayName("ФИО")]
        public string ClientFIO { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; }

        [DataMember]
        [DisplayName("Почта")]
        public string Email { get; set; }

        [DataMember]
        [DisplayName("Пароль")]
        public string Password { get; set; }

        [DataMember]
        [DisplayName("Номер телефона")]
        public string Phone { get; set; }

        [DataMember]
        [DisplayName("Блокировка")]
        public bool isBlocked { get; set; }
    }
}
