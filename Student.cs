public class Student : Person
{
    public static int studentCount = 0;
    public int StudentId { get; set; }

    public List<int> EnrolledCourseIds { get; set; } = new List<int>();

    public Student(string name)
        : base(name)
    {
        StudentId = ++studentCount;
    }

    public void EnrollInCourse(int courseId)
    {
        if (!EnrolledCourseIds.Contains(courseId))
        {
            EnrolledCourseIds.Add(courseId);
        }
    }
}
