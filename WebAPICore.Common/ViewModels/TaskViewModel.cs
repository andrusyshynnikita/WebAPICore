using System;
using System.Collections.Generic;
using System.Text;

namespace WebAPICore.Common.ViewModels
{
    public class TaskViewModel 
    {
        public int Id { get; set; }
        public string User_Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public bool Status { get; set; }
        public string AudioFileName { get; set; }
        public byte[] AudioFileContent { get; set; }
    }
}
