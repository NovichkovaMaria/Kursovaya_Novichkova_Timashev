﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BeautySalonBusinessLogic.Enums
{
    public enum OrderStatus
    {
        Принят = 0,
        Выполняется = 1,
        Готов = 2,
        Оплачен = 3,
        Оплачен_не_полностью = 4
    }
}
