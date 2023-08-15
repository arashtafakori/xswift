﻿using CoreX.Base;

namespace CoreX.Domain
{
    public class LogicalIssue : IIssue
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
