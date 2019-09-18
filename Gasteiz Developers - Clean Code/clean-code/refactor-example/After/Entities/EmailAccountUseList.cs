using System.Collections.Generic;
using System.Linq;

namespace After.Entities
{
    public class EmailAccountUseList : List<EmailAccountUse>
    {
        public void Append(string emailServer)
        {
            bool alreadyAddedToList = this.Any(it => it.EmailServer == emailServer);

            if (alreadyAddedToList)
            {
                this
                    .Single(it => it.EmailServer == emailServer)
                    .Add();
            }
            else
            {
                EmailAccountUse emailAccount = new EmailAccountUse(emailServer);
                this.Add(emailAccount);
            }
        }
    }
}