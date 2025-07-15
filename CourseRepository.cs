public class CourseRepository
{
    private List<Course> courses = new List<Course>();

    public CourseRepository()
    {
        courses.Add(new Course(101, "Programming in C#", 10));
    }

    public Course GetById(int id)
    {
        return courses.FirstOrDefault(c => c.CourseId == id);
    }
    public void addCourse(Course course)
    {
        courses.Add(course);
    }
    public List<Course> GetAll()
    {
        return courses;
    }
    public List<string> getAllTitles()
    {
        List<string> titles = new List<string>();
        foreach (var course in courses)
        {
            titles.Add(course.Title);
        }
        return titles;
    }
}
