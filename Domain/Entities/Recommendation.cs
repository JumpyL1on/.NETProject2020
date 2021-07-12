using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities
{
    public class Recommendation
    {
        public int Id { get; protected set; }
        [DataType(DataType.MultilineText)] public string Content { get; protected set; }

        protected Recommendation()
        {
        }

        public void Update(string content)
        {
            Content = content;
        }
    }
}