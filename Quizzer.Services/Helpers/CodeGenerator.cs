namespace Quizzer.Services.Helpers;

public static class CodeGenerator
{
    public static int GenerateUniqueQuizCode()
    {
        Random rnd = new Random();
        int quizCode = rnd.Next(100000, 999999);
        
        return quizCode;
    }
}