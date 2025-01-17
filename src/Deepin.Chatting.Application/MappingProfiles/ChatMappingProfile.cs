using System;
using AutoMapper;
using Deepin.Chatting.Application.Models;
using Deepin.Chatting.Domain.ChatAggregate;

namespace Deepin.Chatting.Application.MappingProfiles;

public class ChatMappingProfile : Profile
{
    public ChatMappingProfile()
    {
        CreateMap<Chat, ChatDto>(MemberList.Destination);
        CreateMap<GroupInfo, ChatInfo>(MemberList.Destination);
        CreateMap<ChatMember, ChatMemberDto>(MemberList.Destination);
    }
}
