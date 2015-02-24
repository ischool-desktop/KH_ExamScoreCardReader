﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ExamScoreCardReader.UDT;
using FISCA.UDT;

namespace ExamScoreCardReader.Mapper
{
    internal class SubjectCodeMapper : CodeMapper
    {
        private static CodeMapper _instance;

        public static CodeMapper Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new SubjectCodeMapper();
                return _instance;
            }
        }

        private SubjectCodeMapper()
        {
        }

        protected override void LoadCodes()
        {
            base.LoadCodes();

            AccessHelper helper = new AccessHelper();

            foreach (SubjectCode item in helper.Select<SubjectCode>())
            {
                if (!CodeMap.ContainsKey(item.Code))
                    CodeMap.Add(item.Code, item.Subject);
            }
        }
    }
}
