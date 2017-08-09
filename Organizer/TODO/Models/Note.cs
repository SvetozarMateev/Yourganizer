using System;
using TODO.Contracts;

namespace TODO.Models
{
    public class Note : Assignment,INote, ISaveable,IAssignement
    {      
        private bool isFavourite;

        public Note(string title, string content, bool isFavourite = false, DateTime dateOfCreation = default(DateTime))
            :base(title, content, dateOfCreation)
        {
           
            this.IsFavourite = isFavourite;
        }

        
        public bool IsFavourite
        {
            get
            {
                return this.isFavourite;
            }
            set
            {
                this.isFavourite = value;
            }
        }

        public string FormatUserInfoForDB()
        {
            return $"{this.Title}***{this.IsFavourite}***{this.DateOfCreation.ToString("dd/MM/yyyy")}***{this.Content}";
        }
        public override string ToString()
        {
            return $"   ###{this.Title}### created: {this.DateOfCreation:dd/MM/yyyy}" + Environment.NewLine +
                   $"      DESCRIPTION:{this.Content}.";
        }
    }
}
