using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerManager.Domain.Models.User
{
    public class JobTitle
    {
        public int Id { get; private set; }
        public string TitleName { get; private set; }
        public string? Description { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public string? CreatedBy { get; private set; }

        public JobTitle(int id, string titleName, string? description = null, string? createdBy = null)
        {
            if(string.IsNullOrWhiteSpace(titleName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(titleName));
            }

            TitleName = titleName;
            Description = description;
            CreatedAt = DateTime.UtcNow;
            CreatedBy = createdBy;
        }

        public void UpdateDescription(string? newDescription)
        {
            Description = newDescription;
        }
    }
}
