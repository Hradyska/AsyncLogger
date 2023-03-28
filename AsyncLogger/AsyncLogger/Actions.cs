using static AsyncLogger.BusinessException;

namespace AsyncLogger
{
    public static class Actions
    {
         public static bool Info()
         {
           return true;
         }

         public static bool Warning()
         {
            throw new BusinessException(DateTime.Now, "Skipped logic in method:");
         }

         public static bool Error()
         {
            throw new Exception("I broke a logic.");
         }
    }
}
