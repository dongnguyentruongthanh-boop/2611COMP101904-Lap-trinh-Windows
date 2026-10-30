namespace StudentCardPrinter
{
    // Gom du lieu can ve len the, dung chung cho preview va in
    public class StudentCardInfo
    {
        public string StudentId { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string ClassName { get; set; } = string.Empty;
        public string Faculty { get; set; } = string.Empty;
        public string Course { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = string.Empty;
        public Image? Photo { get; set; }
    }
}
