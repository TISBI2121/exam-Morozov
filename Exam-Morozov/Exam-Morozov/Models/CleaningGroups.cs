//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Exam_Morozov.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class CleaningGroups
    {
        public int Id { get; set; }
        public int Cleaner { get; set; }
        public Nullable<int> Grops { get; set; }
    
        public virtual Groups Groups { get; set; }
        public virtual User User { get; set; }
    }
}