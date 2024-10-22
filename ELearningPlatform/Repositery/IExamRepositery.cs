using ELearningPlatform.Models;

namespace ELearningPlatform.Repositery
{
    public interface IExamRepositery
    {
        void AddExamToLecture(int id, Lecture_Exams exam);
        void UpdateExam(int id, Lecture_Exams exam);
        void DeleteExam(int id);
        Lecture_Exams GetExamById(int id);
        void AddQuestionsToExam(int id, List<Exam_Questions> examQuestions);
    }
}
