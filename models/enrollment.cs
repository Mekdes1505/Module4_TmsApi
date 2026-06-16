namespace TmsApi.Models
{
    public class Enrollment
    {
        public int Id { get; set; }
        public Student Student { get; set; } = new Student();
        public Course Course { get; set; } = new Course();
    }
}
