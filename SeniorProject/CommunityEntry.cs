using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeniorProject
{
    class CommunityEntry
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return this.Title + "\n" + this.Description;
        }
    }
}
