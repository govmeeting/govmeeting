using System;
using System.Collections.Generic;
using System.Text;

namespace GM.ApplicationCore.Entities.TopicsDto
{
    public class TopicDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public List<CategoryDto> Categories { get; private set; }
    }
}
