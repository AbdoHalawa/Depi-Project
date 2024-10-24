﻿// <auto-generated />
using System;
using ELearningPlatform.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ELearningPlatform.Migrations
{
    [DbContext(typeof(ELearningContext))]
    [Migration("20241023184551_v101")]
    partial class v101
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ELearningPlatform.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicationUser_Id")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Salary")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("city")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUser_Id")
                        .IsUnique()
                        .HasFilter("[ApplicationUser_Id] IS NOT NULL");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ELearningPlatform.Models.ApplicationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Crs_Catogery")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Crs_Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Crs_Cover_Path")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Crs_Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Crs_Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Crs_Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Course_Codes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Codes");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Course_Lectures", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.ToTable("Lectures");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Course_Students", b =>
                {
                    b.Property<int>("Student_ID")
                        .HasColumnType("int");

                    b.Property<int>("Course_ID")
                        .HasColumnType("int");

                    b.Property<int>("Code_ID")
                        .HasColumnType("int");

                    b.HasKey("Student_ID", "Course_ID", "Code_ID");

                    b.HasIndex("Code_ID");

                    b.HasIndex("Course_ID");

                    b.ToTable("Course_Students");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Exam_Questions", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnswerFour")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerOne")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerThree")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AnswerTwo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CorrectAnswer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ExamId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ExamId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Instructor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicationUser_Id")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUser_Id")
                        .IsUnique()
                        .HasFilter("[ApplicationUser_Id] IS NOT NULL");

                    b.ToTable("Instructors");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Instructor_Courses", b =>
                {
                    b.Property<int>("InstructorId")
                        .HasColumnType("int");

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.HasKey("InstructorId", "CourseId");

                    b.HasIndex("CourseId");

                    b.ToTable("Instructor_Courses");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Lecture_Documents", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("FilePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LectureId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Lecture_Exams", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LectureId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("Exams");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Lecture_Videos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LectureId")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("VideoData")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("LectureId");

                    b.ToTable("Videos");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("ApplicationUser_Id")
                        .HasColumnType("int");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUser_Id")
                        .IsUnique()
                        .HasFilter("[ApplicationUser_Id] IS NOT NULL");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Admin", b =>
                {
                    b.HasOne("ELearningPlatform.Models.ApplicationUser", "User")
                        .WithOne("Admin")
                        .HasForeignKey("ELearningPlatform.Models.Admin", "ApplicationUser_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Course_Codes", b =>
                {
                    b.HasOne("ELearningPlatform.Models.Course", "Course")
                        .WithMany("Crs_Codes")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Course_Lectures", b =>
                {
                    b.HasOne("ELearningPlatform.Models.Course", "Course")
                        .WithMany("Crs_Lectures")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Course_Students", b =>
                {
                    b.HasOne("ELearningPlatform.Models.Course_Codes", "Code")
                        .WithMany()
                        .HasForeignKey("Code_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELearningPlatform.Models.Course", "Course")
                        .WithMany("Crs_Students")
                        .HasForeignKey("Course_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELearningPlatform.Models.Student", "Student")
                        .WithMany("Course_Students")
                        .HasForeignKey("Student_ID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Code");

                    b.Navigation("Course");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Exam_Questions", b =>
                {
                    b.HasOne("ELearningPlatform.Models.Lecture_Exams", "Exam")
                        .WithMany("ExamQuestions")
                        .HasForeignKey("ExamId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Exam");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Instructor", b =>
                {
                    b.HasOne("ELearningPlatform.Models.ApplicationUser", "User")
                        .WithOne("Instructor")
                        .HasForeignKey("ELearningPlatform.Models.Instructor", "ApplicationUser_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Instructor_Courses", b =>
                {
                    b.HasOne("ELearningPlatform.Models.Course", "Course")
                        .WithMany("Crs_Instructor")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ELearningPlatform.Models.Instructor", "Instructor")
                        .WithMany("Crs_Instructor")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Course");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Lecture_Documents", b =>
                {
                    b.HasOne("ELearningPlatform.Models.Course_Lectures", "Lecture")
                        .WithMany("Documents")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Lecture_Exams", b =>
                {
                    b.HasOne("ELearningPlatform.Models.Course_Lectures", "Lecture")
                        .WithMany("Exams")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Lecture_Videos", b =>
                {
                    b.HasOne("ELearningPlatform.Models.Course_Lectures", "Lecture")
                        .WithMany("Videos")
                        .HasForeignKey("LectureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Lecture");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Student", b =>
                {
                    b.HasOne("ELearningPlatform.Models.ApplicationUser", "User")
                        .WithOne("Student")
                        .HasForeignKey("ELearningPlatform.Models.Student", "ApplicationUser_Id")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("User");
                });

            modelBuilder.Entity("ELearningPlatform.Models.ApplicationUser", b =>
                {
                    b.Navigation("Admin");

                    b.Navigation("Instructor");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Course", b =>
                {
                    b.Navigation("Crs_Codes");

                    b.Navigation("Crs_Instructor");

                    b.Navigation("Crs_Lectures");

                    b.Navigation("Crs_Students");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Course_Lectures", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Exams");

                    b.Navigation("Videos");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Instructor", b =>
                {
                    b.Navigation("Crs_Instructor");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Lecture_Exams", b =>
                {
                    b.Navigation("ExamQuestions");
                });

            modelBuilder.Entity("ELearningPlatform.Models.Student", b =>
                {
                    b.Navigation("Course_Students");
                });
#pragma warning restore 612, 618
        }
    }
}
