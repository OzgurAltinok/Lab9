﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lab09
{
    [Serializable]
    public class MSc : Student
    {
        public MSc(string name, string surname, int no) : base(name, surname, no)
        {

        }

        public MSc()
        {

        }
    }
}
