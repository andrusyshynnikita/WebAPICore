using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICore.Common.DBModels
{
    public class TaskDB : BaseDBModel
    {
        public string User_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string AudioFileName { get; set; }
    }
}
