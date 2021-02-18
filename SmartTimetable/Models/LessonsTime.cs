using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartTimetable.Models
{
    public static class LessonsTime
    {
        
        public static LessonTimeModel firstLes = new LessonTimeModel("09:35", "10:55");
        public static LessonTimeModel secondLes = new LessonTimeModel("11:15", "12:35");
        public static LessonTimeModel thirdLes = new LessonTimeModel("12:50", "14:10");
        public static LessonTimeModel fourthLes = new LessonTimeModel("14:25", "15:45");
        public static LessonTimeModel fifthLes = new LessonTimeModel("15:50", "17:10");

        public static List<LessonTimeModel> lessonTimes = new List<LessonTimeModel>() {firstLes,secondLes,thirdLes,fourthLes, fifthLes };
       
    }
}
