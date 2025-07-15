public class Course
{
    public int CourseId { get; set; }
    public string Title { get; set; }
    public int ECTS { get; set; }

    public Course(int courseId, string title, int ects)
    {
        CourseId = courseId;
        Title = title;
        ECTS = ects;
    }
}
