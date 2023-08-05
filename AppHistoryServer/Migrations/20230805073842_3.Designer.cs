﻿// <auto-generated />
using System;
using AppHistoryServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AppHistoryServer.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230805073842_3")]
    partial class _3
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("AppHistoryServer.Dtos.ContentDtos.Node", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Component")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Node");
                });

            modelBuilder.Entity("AppHistoryServer.Dtos.ContentDtos.Variant.Variant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Index")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.ToTable("Variant");
                });

            modelBuilder.Entity("AppHistoryServer.Models.ArchiveBook", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("Downloads")
                        .HasColumnType("integer");

                    b.Property<string>("FileUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Grade")
                        .HasColumnType("integer");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ArchiveBook");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Date", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("DateNumber")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TopicId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Dates");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<int>("Minutes")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("AppHistoryServer.Models.PassedUserQuestions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ChooseIndex")
                        .HasColumnType("integer");

                    b.Property<int>("QuestionId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("UserId");

                    b.ToTable("PassedUserQuestions");
                });

            modelBuilder.Entity("AppHistoryServer.Models.PassedUserQuizzes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("QuizId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("QuizId");

                    b.HasIndex("UserId");

                    b.ToTable("PassedUserQuizzes");
                });

            modelBuilder.Entity("AppHistoryServer.Models.PassedUserTopics", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<double>("PassedPercent")
                        .HasColumnType("double precision");

                    b.Property<int>("TopicId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.HasIndex("UserId");

                    b.ToTable("PassedUserTopics");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int?>("ArchiveBookId")
                        .HasColumnType("integer");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<int>("CorrectVarianIndex")
                        .HasColumnType("integer");

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TopicId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ArchiveBookId");

                    b.HasIndex("AuthorId");

                    b.HasIndex("TopicId");

                    b.ToTable("Question");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Quiz", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<bool>("IsVerified")
                        .HasColumnType("boolean");

                    b.Property<int>("Number")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Quiz");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Term", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("TermText")
                        .HasColumnType("integer");

                    b.Property<int>("TopicId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Term");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<int>("ModuleId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("contentId")
                        .HasColumnType("integer");

                    b.Property<int>("number")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ModuleId");

                    b.HasIndex("contentId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("AppHistoryServer.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp with time zone")
                        .HasDefaultValueSql("CURRENT_TIMESTAMP");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastPlay")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int?>("LastTopicId")
                        .HasColumnType("integer");

                    b.Property<int>("League")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasDefaultValue(0);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("ShockDay")
                        .HasColumnType("integer");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("LastTopicId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("PassedUserQuestionsPassedUserQuizzes", b =>
                {
                    b.Property<int>("PassedQuestionsId")
                        .HasColumnType("integer");

                    b.Property<int>("PassedUserQuizzesId")
                        .HasColumnType("integer");

                    b.HasKey("PassedQuestionsId", "PassedUserQuizzesId");

                    b.HasIndex("PassedUserQuizzesId");

                    b.ToTable("PassedUserQuestionsPassedUserQuizzes");
                });

            modelBuilder.Entity("QuestionQuiz", b =>
                {
                    b.Property<int>("QuestionsId")
                        .HasColumnType("integer");

                    b.Property<int>("QuizzesId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionsId", "QuizzesId");

                    b.HasIndex("QuizzesId");

                    b.ToTable("QuestionQuiz");
                });

            modelBuilder.Entity("QuestionVariant", b =>
                {
                    b.Property<int>("QuestionsId")
                        .HasColumnType("integer");

                    b.Property<int>("VariantsId")
                        .HasColumnType("integer");

                    b.HasKey("QuestionsId", "VariantsId");

                    b.HasIndex("VariantsId");

                    b.ToTable("QuestionVariant");
                });

            modelBuilder.Entity("QuizUser", b =>
                {
                    b.Property<int>("AddedFavoritedUsersId")
                        .HasColumnType("integer");

                    b.Property<int>("FavoritedQuizzesId")
                        .HasColumnType("integer");

                    b.HasKey("AddedFavoritedUsersId", "FavoritedQuizzesId");

                    b.HasIndex("FavoritedQuizzesId");

                    b.ToTable("FavoritedUserQuizzes", (string)null);
                });

            modelBuilder.Entity("AppHistoryServer.Models.Date", b =>
                {
                    b.HasOne("AppHistoryServer.Models.Topic", "Topic")
                        .WithMany("Dates")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("AppHistoryServer.Models.PassedUserQuestions", b =>
                {
                    b.HasOne("AppHistoryServer.Models.Question", "Question")
                        .WithMany("PassedUserQuestions")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppHistoryServer.Models.User", "User")
                        .WithMany("PassedUserQuestions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppHistoryServer.Models.PassedUserQuizzes", b =>
                {
                    b.HasOne("AppHistoryServer.Models.Quiz", "Quiz")
                        .WithMany("PassedUserQuizzes")
                        .HasForeignKey("QuizId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppHistoryServer.Models.User", "User")
                        .WithMany("PassedUserQuizzes")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Quiz");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppHistoryServer.Models.PassedUserTopics", b =>
                {
                    b.HasOne("AppHistoryServer.Models.Topic", "Topic")
                        .WithMany("PassedUserTopics")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppHistoryServer.Models.User", "User")
                        .WithMany("PassedUserTopics")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");

                    b.Navigation("User");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Question", b =>
                {
                    b.HasOne("AppHistoryServer.Models.ArchiveBook", "ArchiveBook")
                        .WithMany("Questions")
                        .HasForeignKey("ArchiveBookId");

                    b.HasOne("AppHistoryServer.Models.User", "Author")
                        .WithMany("CreatedQuestions")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppHistoryServer.Models.Topic", "Topic")
                        .WithMany("Questions")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ArchiveBook");

                    b.Navigation("Author");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Quiz", b =>
                {
                    b.HasOne("AppHistoryServer.Models.User", "Author")
                        .WithMany("CreatedQuizzes")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Term", b =>
                {
                    b.HasOne("AppHistoryServer.Models.Topic", "Topic")
                        .WithMany("Terms")
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Topic", b =>
                {
                    b.HasOne("AppHistoryServer.Models.Module", "Module")
                        .WithMany()
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppHistoryServer.Dtos.ContentDtos.Node", "content")
                        .WithMany()
                        .HasForeignKey("contentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Module");

                    b.Navigation("content");
                });

            modelBuilder.Entity("AppHistoryServer.Models.User", b =>
                {
                    b.HasOne("AppHistoryServer.Models.Topic", "LastTopic")
                        .WithMany()
                        .HasForeignKey("LastTopicId");

                    b.Navigation("LastTopic");
                });

            modelBuilder.Entity("PassedUserQuestionsPassedUserQuizzes", b =>
                {
                    b.HasOne("AppHistoryServer.Models.PassedUserQuestions", null)
                        .WithMany()
                        .HasForeignKey("PassedQuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppHistoryServer.Models.PassedUserQuizzes", null)
                        .WithMany()
                        .HasForeignKey("PassedUserQuizzesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuestionQuiz", b =>
                {
                    b.HasOne("AppHistoryServer.Models.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppHistoryServer.Models.Quiz", null)
                        .WithMany()
                        .HasForeignKey("QuizzesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuestionVariant", b =>
                {
                    b.HasOne("AppHistoryServer.Models.Question", null)
                        .WithMany()
                        .HasForeignKey("QuestionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppHistoryServer.Dtos.ContentDtos.Variant.Variant", null)
                        .WithMany()
                        .HasForeignKey("VariantsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("QuizUser", b =>
                {
                    b.HasOne("AppHistoryServer.Models.User", null)
                        .WithMany()
                        .HasForeignKey("AddedFavoritedUsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("AppHistoryServer.Models.Quiz", null)
                        .WithMany()
                        .HasForeignKey("FavoritedQuizzesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AppHistoryServer.Models.ArchiveBook", b =>
                {
                    b.Navigation("Questions");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Question", b =>
                {
                    b.Navigation("PassedUserQuestions");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Quiz", b =>
                {
                    b.Navigation("PassedUserQuizzes");
                });

            modelBuilder.Entity("AppHistoryServer.Models.Topic", b =>
                {
                    b.Navigation("Dates");

                    b.Navigation("PassedUserTopics");

                    b.Navigation("Questions");

                    b.Navigation("Terms");
                });

            modelBuilder.Entity("AppHistoryServer.Models.User", b =>
                {
                    b.Navigation("CreatedQuestions");

                    b.Navigation("CreatedQuizzes");

                    b.Navigation("PassedUserQuestions");

                    b.Navigation("PassedUserQuizzes");

                    b.Navigation("PassedUserTopics");
                });
#pragma warning restore 612, 618
        }
    }
}
