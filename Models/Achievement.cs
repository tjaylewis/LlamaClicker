using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LlamaClicker.Models
{
    [Serializable()]
    class Achievement
    {
        private string title;
        public string Title
        {
            get { return title; }
            set { title = value; }
        }

        private string description;

        public string Description
        {
            get { return description; }
            set { description = value; }
        }

        public Achievement(string title, string description)
        {
            Title = title;
            Description = description;
        }
    }
}
