using System.ComponentModel;

namespace AquiPaga_API_RESTful.Enums
{
    public enum TaskStatus
    {
        [Description("Não iniciada")]
        NotStarted = 1,
        [Description("Em andamento")]
        InProgress = 2,
        [Description("Concluída")]
        Completed = 3,
    }
}
