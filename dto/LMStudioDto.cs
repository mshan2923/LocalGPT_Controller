using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocalGPTController.dto
{
    internal class LMStudioDto
    {
    }

    public enum Role {system, user};

    [Serializable]
    public class LM_Message
    {
        /*
        public LM_Message(Role role = Role.user, string content = "")
        {
            this.role = role.ToString();
            this.content = content;
        }
        */

        public LM_Message(string role, string content)
        {
            this.role = role;
            this.content = content;
        }

        public string role;
        public string content;
    }

    [Serializable]
    public class LM_RequestDto
    {
        public LM_RequestDto(List<LM_Message> messages = null, float temp = 0.2f,
            int max_token = -1, bool stream = false)
        {
            if (messages != null)
                this.messages = messages;
            this.temperature = temp;
            this.max_tokens = max_token;
            this.stream = stream;
        }
        /// <summary>
        /// Role : user , One massge
        /// </summary>
        public LM_RequestDto(string message = "", float temp = 0.2f,
    int max_token = -1, bool stream = false)
        {
            this.messages = new List<LM_Message> { new LM_Message(Role.user.ToString(), message)};
            this.temperature = temp;
            this.max_tokens = max_token;
            this.stream = stream;
        }

        public List<LM_Message> messages;
        public float temperature;
        public int max_tokens;
        public bool stream;
    }

    [Serializable]
    public class LM_ResponseDto
    {
        public struct Choice
        {
            public int index;
            public LM_Message message;
            public string finish_reason;
        }
        public struct Usage
        {
            public int prompt_tokens;
            public int completion_tokens;
            public int total_tokens;
        }

        public string id;
        public string @object;
        public double created;
        public string model;
        public List<Choice> choices;
        public Usage usage;


        public LM_ResponseDto(string id, string @object, double created)
        { 
            this.id = id; 
            this.@object = @object;
            this.created = created;
        }
    }
}
