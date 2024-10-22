using ELearningPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace ELearningPlatform.Repositery
{
    public class ExamRepositery : IExamRepositery
    {
        ELearningContext context;
        public ExamRepositery(ELearningContext context)
        {
            this.context = context;
        }
        public void AddExamToLecture(int id, Lecture_Exams exam)
        {
            var lecture = context.Lectures.FirstOrDefault(l => l.Id == id);
            exam.LectureId = id;
            exam.Id = 0;
            exam.Date = DateTime.Now.Date;
            context.Exams.Add(exam);
            context.SaveChanges();
        }
        public Lecture_Exams GetExamById(int id)
        {
            return context.Exams.Include(l => l.ExamQuestions).FirstOrDefault(e => e.Id == id);
        }
        public void AddQuestionsToExam(int id, List<Exam_Questions> examQuestions)
        {
            var exam = context.Exams.FirstOrDefault(l => l.Id == id);
            foreach (var examQuestion in examQuestions)
            {
                examQuestion.ExamId = exam.Id;
            }
            context.Questions.AddRange(examQuestions);
            context.SaveChanges();
        }
        public void UpdateExam(int id, Lecture_Exams exam)
        {
            var OldExam = GetExamById(id);
            if (OldExam == null)
            {
                throw new Exception($"Exam with ID {id} not found.");
            }
            if (exam.Name != null)
            {
                OldExam.Name = exam.Name;
            }
            if (exam.Description != null)
            {
                OldExam.Description = exam.Description;
            }
            if (exam.ExamQuestions != null)
            {
                foreach (var newQuestion in exam.ExamQuestions)
                {
                    var existingQuestion = OldExam.ExamQuestions
                        .FirstOrDefault(q => q.Id == newQuestion.Id);

                    if (existingQuestion != null)
                    {
                        // Update existing question
                        existingQuestion.Title = newQuestion.Title;
                        existingQuestion.AnswerOne = newQuestion.AnswerOne;
                        existingQuestion.AnswerTwo = newQuestion.AnswerTwo;
                        existingQuestion.AnswerThree = newQuestion.AnswerThree;
                        existingQuestion.AnswerFour = newQuestion.AnswerFour;
                        existingQuestion.CorrectAnswer = newQuestion.CorrectAnswer;

                        // Mark the question as modified
                        context.Entry(existingQuestion).State = EntityState.Modified;
                    }
                }
            }
            context.SaveChanges();



        }
        public void DeleteExam(int id)
        {
            var exam = GetExamById(id);
            context.Exams.Remove(exam);
            context.SaveChanges();
        }

    }
}
