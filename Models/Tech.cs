﻿using System;
using System.Collections.Generic;

namespace DotNetNote.Models
{
    /// <summary>
    /// Techs 테이블과 일대일로 연결되는 클래스
    /// </summary>
    public class Tech
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
