﻿// <auto-generated />
using System;
using Deepin.Chatting.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Deepin.Chatting.Infrastructure.Migrations
{
    [DbContext(typeof(ChattingDbContext))]
    partial class ChattingDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("chatting")
                .HasAnnotation("ProductVersion", "9.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Deepin.Chatting.Domain.ChatAggregate.Chat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("created_at");

                    b.Property<string>("CreatedBy")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("created_by");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("boolean")
                        .HasColumnName("is_deleted");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("type");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.HasKey("Id");

                    b.ToTable("chats", "chatting");
                });

            modelBuilder.Entity("Deepin.Chatting.Domain.ChatAggregate.ChatMember", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<string>("DisplayName")
                        .HasColumnType("text")
                        .HasColumnName("display_name");

                    b.Property<DateTime>("JoinedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("joined_at");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("updated_at");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<Guid>("chat_id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("chat_id");

                    b.ToTable("chat_members", "chatting");
                });

            modelBuilder.Entity("Deepin.Chatting.Domain.ChatAggregate.ChatReadStatus", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("id");

                    b.Property<Guid>("ChatId")
                        .HasColumnType("uuid")
                        .HasColumnName("chat_id");

                    b.Property<DateTime>("LastReadAt")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("last_read_at");

                    b.Property<string>("LastReadMessageId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("last_read_message_id");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("ChatId");

                    b.ToTable("chat_read_statuses", "chatting");
                });

            modelBuilder.Entity("Deepin.Chatting.Domain.ChatAggregate.Chat", b =>
                {
                    b.OwnsOne("Deepin.Chatting.Domain.ChatAggregate.GroupInfo", "GroupInfo", b1 =>
                        {
                            b1.Property<Guid>("ChatId")
                                .HasColumnType("uuid");

                            b1.Property<string>("AvatarFileId")
                                .HasColumnType("text")
                                .HasColumnName("avatar_file_id");

                            b1.Property<string>("Description")
                                .HasColumnType("text")
                                .HasColumnName("description");

                            b1.Property<bool>("IsPublic")
                                .HasColumnType("boolean")
                                .HasColumnName("is_public");

                            b1.Property<string>("Name")
                                .HasColumnType("text")
                                .HasColumnName("name");

                            b1.Property<string>("UserName")
                                .HasColumnType("text")
                                .HasColumnName("user_name");

                            b1.HasKey("ChatId");

                            b1.ToTable("chats", "chatting");

                            b1.WithOwner()
                                .HasForeignKey("ChatId");
                        });

                    b.Navigation("GroupInfo");
                });

            modelBuilder.Entity("Deepin.Chatting.Domain.ChatAggregate.ChatMember", b =>
                {
                    b.HasOne("Deepin.Chatting.Domain.ChatAggregate.Chat", null)
                        .WithMany("Members")
                        .HasForeignKey("chat_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Deepin.Chatting.Domain.ChatAggregate.ChatReadStatus", b =>
                {
                    b.HasOne("Deepin.Chatting.Domain.ChatAggregate.Chat", null)
                        .WithMany("ReadStatuses")
                        .HasForeignKey("ChatId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Deepin.Chatting.Domain.ChatAggregate.Chat", b =>
                {
                    b.Navigation("Members");

                    b.Navigation("ReadStatuses");
                });
#pragma warning restore 612, 618
        }
    }
}
