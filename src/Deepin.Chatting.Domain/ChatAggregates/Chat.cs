using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deepin.Chatting.Domain.ChatAggregates;
public class Chat
{
    private ICollection<ChatMember> _members;
    public ChatType Type { get; private set; }
    public string CreatedBy { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    public bool IsDeleted { get; private set; }
    public GroupInfo GroupInfo { get; private set; }
    public IReadOnlyCollection<ChatMember> Members => (IReadOnlyCollection<ChatMember>)_members;
}
